using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Lumina.Data.Files.Excel;
using Lumina.Data.Structs.Excel;
using Lumina.Extensions;
using Lumina.Text;

namespace Lumina.Excel
{
    public class RowParser
    {
        private readonly ExcelSheetImpl _sheet;
        private readonly ExcelDataFile _dataFile;

        private ExcelDataOffset _offset;
        private ExcelDataRowHeader _rowHeader;

        private long _rowOffset;

        public uint Row;
        public uint SubRow;
        public uint RowCount => _rowHeader.RowCount;

        private MemoryStream Stream => _dataFile.FileStream;

        /// <summary>
        /// Provides access to the base data generated for a sheet
        /// </summary>
        public ExcelSheetImpl Sheet => _sheet;

        public RowParser( ExcelSheetImpl sheet, ExcelDataFile dataFile )
        {
            _sheet = sheet;
            _dataFile = dataFile;
        }

        public RowParser( ExcelSheetImpl sheet, ExcelDataFile dataFile, uint row )
            : this( sheet, dataFile )
        {
            SeekToRow( row );
        }

        public RowParser( ExcelSheetImpl sheet, ExcelDataFile dataFile, uint row, uint subRow )
            : this( sheet, dataFile, row )
        {
            SeekToRow( row, subRow );
        }

        /// <summary>
        /// Moves the parser to a row in the current page given its index
        /// </summary>
        /// <param name="row">The row index to seek to</param>
        /// /// <exception cref="IndexOutOfRangeException">Given row index was out of bounds</exception>
        public void SeekToRow( uint row )
        {
            if( !TrySeekToRow( row ) )
            {
                throw new IndexOutOfRangeException( $"the row {row} could not be found in the sheet!" );
            }
        }
        
        /// <summary>
        /// Moves the parser to a row in the current page given its index
        /// </summary>
        /// <param name="row">The row index to seek to</param>
        /// <returns>true if the row was seeked to successfully, false if the row wasn't found or otherwise</returns>
        public bool TrySeekToRow( uint row )
        {
            Row = row;

            if( !_dataFile.RowData.TryGetValue( Row, out var offset ) )
            {
                return false;
            }

            _offset = offset;
            
            var br = _dataFile.Reader;

            Stream.Position = _offset.Offset;

            _rowHeader = br.ReadStructure< ExcelDataRowHeader >();

            if( BitConverter.IsLittleEndian )
            {
                _rowHeader.DataSize = BinaryPrimitives.ReverseEndianness( _rowHeader.DataSize );
                _rowHeader.RowCount = BinaryPrimitives.ReverseEndianness( _rowHeader.RowCount );
            }

            // header is 6 bytes large, data normally starts here except in the case of variant 2 sheets but we'll keep it anyway
            _rowOffset = _offset.Offset + 6;

            return true;
        }

        /// <summary>
        /// Moves the parser to a row + subrow in the current page given their indexes
        /// </summary>
        /// <param name="row">The row index to seek to</param>
        /// <param name="subRow">The subrow index to seek to</param>
        /// <exception cref="IndexOutOfRangeException">Given subrow index was out of bounds</exception>
        public void SeekToRow( uint row, uint subRow )
        {
            if( !TrySeekToRow( row, subRow ) )
            {
                throw new IndexOutOfRangeException( $"subrow {subRow} > {_rowHeader.RowCount}!" );
            }
        }

        /// <summary>
        /// Moves the parser to a row + subrow in the current page given their indexes
        /// </summary>
        /// <param name="row">The row index to seek to</param>
        /// <param name="subRow">The subrow index to seek to</param>
        /// /// <returns>true if the row and subrow was seeked to successfully, false if the row or subrow wasn't found or otherwise</returns>
        public bool TrySeekToRow( uint row, uint subRow )
        {
            if( !TrySeekToRow( row ) )
            {
                return false;
            }
            
            SubRow = subRow;
            
            if( subRow > _rowHeader.RowCount )
            {
                return false;
            }
            
            _rowOffset = CalculateSubRowOffset( subRow );

            return true;
        }

        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        public long CalculateSubRowOffset( uint subRow )
        {
            // +6 is the ExcelDataRowHeader
            return _offset.Offset + 6 + ( subRow * _sheet.Header.DataOffset + 2 * ( subRow + 1 ) );
        }

        /// <summary>
        /// Read n bytes starting from the row offset + offset
        /// </summary>
        /// <param name="offset">The offset inside the row</param>
        /// <param name="count">The number of bytes to read</param>
        /// <returns>A copy of the read bytes</returns>
        public byte[] ReadBytes( int offset, int count )
        {
            var br = _dataFile.Reader;

            Stream.Position = _rowOffset + offset;

            return br.ReadBytes( count );
        }

        /// <summary>
        /// Reads a structure from an offset inside the current row
        /// </summary>
        /// <param name="offset">The offset to start reading from</param>
        /// <typeparam name="T">The type of struct to read out from the row</typeparam>
        /// <returns>The read structure filled from the row data</returns>
        public T ReadStructure< T >( int offset ) where T : struct
        {
            var br = _dataFile.Reader;

            Stream.Position = _rowOffset + offset;

            return br.ReadStructure< T >();
        }

        /// <summary>
        /// Reads structures from an offset inside the current row
        /// </summary>
        /// <param name="offset">The offset to start reading from</param>
        /// <param name="count">The number of structures to read sequentially</param>
        /// <typeparam name="T">The type of struct to read out from the row</typeparam>
        /// <returns>The read structures filled from the row data</returns>
        public List< T > ReadStructures< T >( int offset, int count ) where T : struct
        {
            var br = _dataFile.Reader;

            Stream.Position = _rowOffset + offset;

            return br.ReadStructures< T >( count );
        }

        /// <summary>
        /// Reads structures from an offset inside the current row
        /// </summary>
        /// <param name="offset">The offset to start reading from</param>
        /// <param name="count">The number of structures to read sequentially</param>
        /// <typeparam name="T">The type of struct to read out from the row</typeparam>
        /// <returns>The read structures filled from the row data</returns>
        public T[] ReadStructuresAsArray< T >( int offset, int count ) where T : struct
        {
            var br = _dataFile.Reader;

            Stream.Position = _rowOffset + offset;

            return br.ReadStructuresAsArray< T >( count );
        }

        private object ReadFieldInternal( ExcelColumnDataType type )
        {
            var br = _dataFile.Reader;

            object? data = null;

            switch( type )
            {
                case ExcelColumnDataType.String:
                {
                    var stringOffset = br.ReadUInt32();
                    var raw = br.ReadRawOffsetData( _rowOffset + _sheet.Header.DataOffset + stringOffset );
                    data = new SeString( raw );

                    break;
                }
                case ExcelColumnDataType.Bool:
                {
                    data = br.ReadByte() != 0;
                    break;
                }
                case ExcelColumnDataType.Int8:
                {
                    data = br.ReadSByte();
                    break;
                }
                case ExcelColumnDataType.UInt8:
                {
                    data = br.ReadByte();
                    break;
                }
                case ExcelColumnDataType.Int16:
                {
                    data = br.ReadInt16();
                    break;
                }
                case ExcelColumnDataType.UInt16:
                {
                    data = br.ReadUInt16();
                    break;
                }
                case ExcelColumnDataType.Int32:
                {
                    data = br.ReadInt32();
                    break;
                }
                case ExcelColumnDataType.UInt32:
                {
                    data = br.ReadUInt32();
                    break;
                }
                // case ExcelColumnDataType.Unk:
                // break;
                case ExcelColumnDataType.Float32:
                {
                    data = br.ReadSingle();
                    break;
                }
                case ExcelColumnDataType.Int64:
                {
                    data = br.ReadUInt64();
                    break;
                }
                case ExcelColumnDataType.UInt64:
                {
                    data = br.ReadUInt64();
                    break;
                }
                // case ExcelColumnDataType.Unk2:
                // break;
                case ExcelColumnDataType.PackedBool0:
                case ExcelColumnDataType.PackedBool1:
                case ExcelColumnDataType.PackedBool2:
                case ExcelColumnDataType.PackedBool3:
                case ExcelColumnDataType.PackedBool4:
                case ExcelColumnDataType.PackedBool5:
                case ExcelColumnDataType.PackedBool6:
                case ExcelColumnDataType.PackedBool7:
                {
                    var shift = (int)type - (int)ExcelColumnDataType.PackedBool0;
                    var bit = 1 << shift;

                    var rawData = br.ReadByte();

                    data = ( rawData & bit ) == bit;

                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException( "type", $"invalid excel column type: {type}" );
            }

            return data;
        }

        /// <summary>
        /// Read a field from the current stream position
        /// </summary>
        /// <param name="type">The sheet type to read</param>
        /// <typeparam name="T">The CLR type to store the read data in</typeparam>
        /// <returns>The read data stored in the provided type</returns>
        /// <exception cref="ArgumentOutOfRangeException">An invalid column type was provided</exception>
        private T? ReadField< T >( ExcelColumnDataType type )
        {
            var data = ReadFieldInternal( type );

            if( _sheet.GameData.Options.ExcelSheetStrictCastingEnabled )
            {
                return (T)data;
            }

            // todo: this is fucking shit but is a wip fix so that you can still ReadField< string > and get something back because 1am brain can't figure it out rn
            if( typeof( T ) == typeof( string ) && data is SeString seString )
            {
                // haha fuck you c#
                return (T)(object)seString.RawString;
            }

            if( data is T castedData )
            {
                return castedData;
            }

            return default;
        }

        /// <summary>
        /// Given a bitset with 1 flag set, find which index that bit is set at
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        [MethodImpl( MethodImplOptions.AggressiveInlining )]
        private byte GetBitPosition( byte flag )
        {
            byte count = 0;

            while( flag != 1 )
            {
                flag >>= 1;
                count++;
            }

            return count;
        }

        /// <summary>
        /// Read a type from an offset in the row
        /// </summary>
        /// <param name="offset">The offset to read from</param>
        /// <param name="bit">Read a specific bit from the underlying position - useful for bools</param>
        /// <typeparam name="T">The type to store the data in</typeparam>
        /// <returns>The read data contained in the provided type</returns>
        public T? ReadOffset< T >( ushort offset, byte bit = 0 )
        {
            Stream.Position = _rowOffset + offset;

            if( bit == 0 )
            {
                return ReadField< T >( _sheet.ColumnsByOffset[ offset ].Type );
            }
            
            var pos = GetBitPosition( bit );
            var flag = ExcelColumnDataType.PackedBool0 + pos;

            return ReadField< T >( flag );
        }

        /// <summary>
        /// Read a type from an offset in the row
        /// </summary>
        /// <param name="offset">The offset to read from</param>
        /// <param name="type">The excel column type to read</param>
        /// <returns>The read data contained in the provided type</returns>
        public T? ReadOffset< T >( int offset, ExcelColumnDataType type )
        {
            Stream.Position = _rowOffset + offset;

            return ReadField< T >( type );
        }

        /// <summary>
        /// Read a type from a column index in the row
        /// </summary>
        /// <param name="column">The column index to lookup</param>
        /// <typeparam name="T">The type to store the read data in</typeparam>
        /// <returns>The read data contained in the provided type</returns>
        public T? ReadColumn< T >( int column )
        {
            var col = _sheet.Columns[ column ];

            Stream.Position = _rowOffset + col.Offset;

            return ReadField< T >( col.Type );
        }

        /// <summary>
        /// Grab the raw value from the sheet.
        /// </summary>
        /// <remarks>
        /// This effectively acts as a variant and the object encapsulates it. You'll still need to do a type check or safely cast it to avoid exceptions
        /// but this can be useful when you don't need to care about it's type and can use it as is - e.g. ToString and so on
        /// </remarks>
        /// <param name="column">The column index to read from</param>
        /// <returns>An object containing the data from the row.</returns>
        public object ReadColumnRaw( int column )
        {
            var col = _sheet.Columns[ column ];

            Stream.Position = _rowOffset + col.Offset;

            return ReadFieldInternal( col.Type );
        }
    }
}