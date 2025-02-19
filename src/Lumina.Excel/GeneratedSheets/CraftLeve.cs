// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "CraftLeve", columnHash: 0x51a3acc3 )]
    public class CraftLeve : ExcelRow
    {
        public struct UnkStruct3Struct
        {
            public int Item;
            public ushort ItemCount;
        }
        
        public LazyRow< Leve > Leve { get; set; }
        public LazyRow< CraftLeveTalk > CraftLeveTalk { get; set; }
        public byte Repeats { get; set; }
        public UnkStruct3Struct[] UnkStruct3 { get; set; }
        
        public override void PopulateData( RowParser parser, GameData gameData, Language language )
        {
            base.PopulateData( parser, gameData, language );

            Leve = new LazyRow< Leve >( gameData, parser.ReadColumn< int >( 0 ), language );
            CraftLeveTalk = new LazyRow< CraftLeveTalk >( gameData, parser.ReadColumn< int >( 1 ), language );
            Repeats = parser.ReadColumn< byte >( 2 );
            UnkStruct3 = new UnkStruct3Struct[ 4 ];
            for( var i = 0; i < 4; i++ )
            {
                UnkStruct3[ i ] = new UnkStruct3Struct();
                UnkStruct3[ i ].Item = parser.ReadColumn< int >( 3 + ( i * 2 + 0 ) );
                UnkStruct3[ i ].ItemCount = parser.ReadColumn< ushort >( 3 + ( i * 2 + 1 ) );
            }
        }
    }
}