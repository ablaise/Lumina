namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "GatheringLeve", columnHash: 0xfa74e4d0 )]
    public class GatheringLeve : IExcelRow
    {
        // column defs from Wed, 15 Jan 2020 17:17:16 GMT

        /* offset: 0000 col: 0
         *  name: Route
         *  repeat count: 4
         */

        /* offset: 0004 col: 1
         *  no SaintCoinach definition found
         */

        /* offset: 0008 col: 2
         *  no SaintCoinach definition found
         */

        /* offset: 000c col: 3
         *  no SaintCoinach definition found
         */

        /* offset: 0010 col: 4
         *  name: RequiredItem[0]
         *  type: 
         */

        /* offset: 002c col: 5
         *  name: RequiredItemQty[0]
         *  type: 
         */

        /* offset: 0014 col: 6
         *  name: RequiredItem[1]
         *  type: 
         */

        /* offset: 002d col: 7
         *  name: RequiredItemQty[1]
         *  type: 
         */

        /* offset: 0018 col: 8
         *  name: RequiredItem[2]
         *  type: 
         */

        /* offset: 002e col: 9
         *  name: RequiredItemQty[2]
         *  type: 
         */

        /* offset: 001c col: 10
         *  name: RequiredItem[3]
         *  type: 
         */

        /* offset: 002f col: 11
         *  name: RequiredItemQty[3]
         *  type: 
         */

        /* offset: 0030 col: 12
         *  name: ItemNumber
         *  type: 
         */

        /* offset: 0020 col: 13
         *  name: Rule
         *  type: 
         */

        /* offset: 0031 col: 14
         *  name: Varient
         *  type: 
         */

        /* offset: 0028 col: 15
         *  name: Objective[0]
         *  type: 
         */

        /* offset: 002a col: 16
         *  name: Objective[1]
         *  type: 
         */

        /* offset: 0024 col: 17
         *  name: BNpcEntry
         *  type: 
         */

        /* offset: 0032 col: 18
         *  name: UseSecondaryTool
         *  type: 
         */



        // col: 00 offset: 0000
        public int[] Route;

        // col: 04 offset: 0010
        public int RequiredItem0;

        // col: 06 offset: 0014
        public int RequiredItem1;

        // col: 08 offset: 0018
        public int RequiredItem2;

        // col: 10 offset: 001c
        public int RequiredItem3;

        // col: 13 offset: 0020
        public int Rule;

        // col: 17 offset: 0024
        public int BNpcEntry;

        // col: 15 offset: 0028
        public ushort Objective0;

        // col: 16 offset: 002a
        public ushort Objective1;

        // col: 05 offset: 002c
        public byte RequiredItemQty0;

        // col: 07 offset: 002d
        public byte RequiredItemQty1;

        // col: 09 offset: 002e
        public byte RequiredItemQty2;

        // col: 11 offset: 002f
        public byte RequiredItemQty3;

        // col: 12 offset: 0030
        public byte ItemNumber;

        // col: 14 offset: 0031
        public byte Varient;

        // col: 18 offset: 0032
        private byte packed32;
        public bool UseSecondaryTool => ( packed32 & 0x1 ) == 0x1;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Route = new int[4];
            Route[0] = parser.ReadOffset< int >( 0x0 );
            Route[1] = parser.ReadOffset< int >( 0x4 );
            Route[2] = parser.ReadOffset< int >( 0x8 );
            Route[3] = parser.ReadOffset< int >( 0xc );

            // col: 4 offset: 0010
            RequiredItem0 = parser.ReadOffset< int >( 0x10 );

            // col: 6 offset: 0014
            RequiredItem1 = parser.ReadOffset< int >( 0x14 );

            // col: 8 offset: 0018
            RequiredItem2 = parser.ReadOffset< int >( 0x18 );

            // col: 10 offset: 001c
            RequiredItem3 = parser.ReadOffset< int >( 0x1c );

            // col: 13 offset: 0020
            Rule = parser.ReadOffset< int >( 0x20 );

            // col: 17 offset: 0024
            BNpcEntry = parser.ReadOffset< int >( 0x24 );

            // col: 15 offset: 0028
            Objective0 = parser.ReadOffset< ushort >( 0x28 );

            // col: 16 offset: 002a
            Objective1 = parser.ReadOffset< ushort >( 0x2a );

            // col: 5 offset: 002c
            RequiredItemQty0 = parser.ReadOffset< byte >( 0x2c );

            // col: 7 offset: 002d
            RequiredItemQty1 = parser.ReadOffset< byte >( 0x2d );

            // col: 9 offset: 002e
            RequiredItemQty2 = parser.ReadOffset< byte >( 0x2e );

            // col: 11 offset: 002f
            RequiredItemQty3 = parser.ReadOffset< byte >( 0x2f );

            // col: 12 offset: 0030
            ItemNumber = parser.ReadOffset< byte >( 0x30 );

            // col: 14 offset: 0031
            Varient = parser.ReadOffset< byte >( 0x31 );

            // col: 18 offset: 0032
            packed32 = parser.ReadOffset< byte >( 0x32 );


        }
    }
}