namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "PartyContentTextData", columnHash: 0xdebb20e3 )]
    public class PartyContentTextData : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0000 col: 0
         *  name: Data
         *  type: 
         */



        // col: 00 offset: 0000
        public string Data;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Data = parser.ReadOffset< string >( 0x0 );


        }
    }
}