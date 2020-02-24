namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "CabinetCategory", columnHash: 0xc6207018 )]
    public class CabinetCategory : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0008 col: 0
         *  name: MenuOrder
         *  type: 
         */

        /* offset: 0000 col: 1
         *  name: Icon
         *  type: 
         */

        /* offset: 0004 col: 2
         *  name: Category
         *  type: 
         */



        // col: 01 offset: 0000
        public int Icon;

        // col: 02 offset: 0004
        public int Category;

        // col: 00 offset: 0008
        public byte MenuOrder;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 1 offset: 0000
            Icon = parser.ReadOffset< int >( 0x0 );

            // col: 2 offset: 0004
            Category = parser.ReadOffset< int >( 0x4 );

            // col: 0 offset: 0008
            MenuOrder = parser.ReadOffset< byte >( 0x8 );


        }
    }
}