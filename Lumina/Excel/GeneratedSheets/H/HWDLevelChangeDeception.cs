namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "HWDLevelChangeDeception", columnHash: 0xda365c51 )]
    public class HWDLevelChangeDeception : IExcelRow
    {
        // column defs from Wed, 15 Jan 2020 17:17:16 GMT

        /* offset: 0000 col: 0
         *  name: Image
         *  type: 
         */



        // col: 00 offset: 0000
        public int Image;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Image = parser.ReadOffset< int >( 0x0 );


        }
    }
}