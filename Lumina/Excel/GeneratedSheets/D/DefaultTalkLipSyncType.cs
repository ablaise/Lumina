namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "DefaultTalkLipSyncType", columnHash: 0xda365c51 )]
    public class DefaultTalkLipSyncType : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0000 col: 0
         *  name: ActionTimeline
         *  type: 
         */



        // col: 00 offset: 0000
        public int ActionTimeline;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            ActionTimeline = parser.ReadOffset< int >( 0x0 );


        }
    }
}