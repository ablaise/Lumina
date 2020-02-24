namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "AnimaWeapon5", columnHash: 0xe777b7a6 )]
    public class AnimaWeapon5 : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0000 col: 0
         *  name: Item
         *  type: 
         */

        /* offset: 0004 col: 1
         *  no SaintCoinach definition found
         */

        /* offset: 0005 col: 2
         *  name: SecondaryStatTotal
         *  type: 
         */

        /* offset: 0006 col: 3
         *  name: Parameter
         *  repeat count: 5
         */

        /* offset: 0007 col: 4
         *  no SaintCoinach definition found
         */

        /* offset: 0008 col: 5
         *  no SaintCoinach definition found
         */

        /* offset: 0009 col: 6
         *  no SaintCoinach definition found
         */

        /* offset: 000a col: 7
         *  no SaintCoinach definition found
         */



        // col: 00 offset: 0000
        public int Item;

        // col: 01 offset: 0004
        public byte unknown4;

        // col: 02 offset: 0005
        public byte SecondaryStatTotal;

        // col: 03 offset: 0006
        public byte[] Parameter;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Item = parser.ReadOffset< int >( 0x0 );

            // col: 1 offset: 0004
            unknown4 = parser.ReadOffset< byte >( 0x4 );

            // col: 2 offset: 0005
            SecondaryStatTotal = parser.ReadOffset< byte >( 0x5 );

            // col: 3 offset: 0006
            Parameter = new byte[5];
            Parameter[0] = parser.ReadOffset< byte >( 0x6 );
            Parameter[1] = parser.ReadOffset< byte >( 0x7 );
            Parameter[2] = parser.ReadOffset< byte >( 0x8 );
            Parameter[3] = parser.ReadOffset< byte >( 0x9 );
            Parameter[4] = parser.ReadOffset< byte >( 0xa );


        }
    }
}