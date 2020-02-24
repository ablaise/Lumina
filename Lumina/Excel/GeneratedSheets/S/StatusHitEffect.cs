namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "StatusHitEffect", columnHash: 0xd870e208 )]
    public class StatusHitEffect : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0000 col: 0
         *  name: Location
         *  type: 
         */



        // col: 00 offset: 0000
        public ushort Location;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Location = parser.ReadOffset< ushort >( 0x0 );


        }
    }
}