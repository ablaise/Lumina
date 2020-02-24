namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "ItemAction", columnHash: 0xb1f26af0 )]
    public class ItemAction : IExcelRow
    {
        // column defs from Wed, 15 Jan 2020 17:17:16 GMT

        /* offset: 0026 col: 0
         *  name: CondLv
         *  type: 
         */

        /* offset: 0027 col: 1
         *  name: CondBattle
         *  type: 
         */

        /* offset: 0027 col: 2
         *  name: CondPVP
         *  type: 
         */

        /* offset: 0027 col: 3
         *  name: CondPVPOnly
         *  type: 
         */

        /* offset: 0000 col: 4
         *  name: Type
         *  type: 
         */

        /* offset: 0002 col: 5
         *  name: Data
         *  repeat count: 9
         */

        /* offset: 0004 col: 6
         *  no SaintCoinach definition found
         */

        /* offset: 0006 col: 7
         *  no SaintCoinach definition found
         */

        /* offset: 0008 col: 8
         *  no SaintCoinach definition found
         */

        /* offset: 000a col: 9
         *  no SaintCoinach definition found
         */

        /* offset: 000c col: 10
         *  no SaintCoinach definition found
         */

        /* offset: 000e col: 11
         *  no SaintCoinach definition found
         */

        /* offset: 0010 col: 12
         *  no SaintCoinach definition found
         */

        /* offset: 0012 col: 13
         *  no SaintCoinach definition found
         */

        /* offset: 0014 col: 14
         *  name: Data{HQ}
         *  repeat count: 9
         */

        /* offset: 0016 col: 15
         *  no SaintCoinach definition found
         */

        /* offset: 0018 col: 16
         *  no SaintCoinach definition found
         */

        /* offset: 001a col: 17
         *  no SaintCoinach definition found
         */

        /* offset: 001c col: 18
         *  no SaintCoinach definition found
         */

        /* offset: 001e col: 19
         *  no SaintCoinach definition found
         */

        /* offset: 0020 col: 20
         *  no SaintCoinach definition found
         */

        /* offset: 0022 col: 21
         *  no SaintCoinach definition found
         */

        /* offset: 0024 col: 22
         *  no SaintCoinach definition found
         */



        // col: 04 offset: 0000
        public ushort Type;

        // col: 05 offset: 0002
        public ushort[] Data;

        // col: 14 offset: 0014
        public ushort[] DataHQ;

        // col: 00 offset: 0026
        public byte CondLv;

        // col: 01 offset: 0027
        private byte packed27;
        public bool CondBattle => ( packed27 & 0x1 ) == 0x1;
        public bool CondPVP => ( packed27 & 0x2 ) == 0x2;
        public bool CondPVPOnly => ( packed27 & 0x4 ) == 0x4;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 4 offset: 0000
            Type = parser.ReadOffset< ushort >( 0x0 );

            // col: 5 offset: 0002
            Data = new ushort[9];
            Data[0] = parser.ReadOffset< ushort >( 0x2 );
            Data[1] = parser.ReadOffset< ushort >( 0x4 );
            Data[2] = parser.ReadOffset< ushort >( 0x6 );
            Data[3] = parser.ReadOffset< ushort >( 0x8 );
            Data[4] = parser.ReadOffset< ushort >( 0xa );
            Data[5] = parser.ReadOffset< ushort >( 0xc );
            Data[6] = parser.ReadOffset< ushort >( 0xe );
            Data[7] = parser.ReadOffset< ushort >( 0x10 );
            Data[8] = parser.ReadOffset< ushort >( 0x12 );

            // col: 14 offset: 0014
            DataHQ = new ushort[9];
            DataHQ[0] = parser.ReadOffset< ushort >( 0x14 );
            DataHQ[1] = parser.ReadOffset< ushort >( 0x16 );
            DataHQ[2] = parser.ReadOffset< ushort >( 0x18 );
            DataHQ[3] = parser.ReadOffset< ushort >( 0x1a );
            DataHQ[4] = parser.ReadOffset< ushort >( 0x1c );
            DataHQ[5] = parser.ReadOffset< ushort >( 0x1e );
            DataHQ[6] = parser.ReadOffset< ushort >( 0x20 );
            DataHQ[7] = parser.ReadOffset< ushort >( 0x22 );
            DataHQ[8] = parser.ReadOffset< ushort >( 0x24 );

            // col: 0 offset: 0026
            CondLv = parser.ReadOffset< byte >( 0x26 );

            // col: 1 offset: 0027
            packed27 = parser.ReadOffset< byte >( 0x27 );


        }
    }
}