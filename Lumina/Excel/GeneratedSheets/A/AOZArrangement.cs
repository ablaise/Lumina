namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "AOZArrangement", columnHash: 0x2020acf6 )]
    public class AOZArrangement : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0000 col: 0
         *  name: AOZContentBriefingBNpc
         *  type: 
         */

        /* offset: 0002 col: 1
         *  no SaintCoinach definition found
         */



        // col: 00 offset: 0000
        public ushort AOZContentBriefingBNpc;

        // col: 01 offset: 0002
        public ushort unknown2;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            AOZContentBriefingBNpc = parser.ReadOffset< ushort >( 0x0 );

            // col: 1 offset: 0002
            unknown2 = parser.ReadOffset< ushort >( 0x2 );


        }
    }
}