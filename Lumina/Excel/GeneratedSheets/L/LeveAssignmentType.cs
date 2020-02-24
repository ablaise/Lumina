namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "LeveAssignmentType", columnHash: 0x7c19f23c )]
    public class LeveAssignmentType : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0008 col: 0
         *  name: IsFaction
         *  type: 
         */

        /* offset: 0004 col: 1
         *  name: Icon
         *  type: 
         */

        /* offset: 0000 col: 2
         *  name: Name
         *  type: 
         */



        // col: 02 offset: 0000
        public string Name;

        // col: 01 offset: 0004
        public int Icon;

        // col: 00 offset: 0008
        private byte packed8;
        public bool IsFaction => ( packed8 & 0x1 ) == 0x1;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 2 offset: 0000
            Name = parser.ReadOffset< string >( 0x0 );

            // col: 1 offset: 0004
            Icon = parser.ReadOffset< int >( 0x4 );

            // col: 0 offset: 0008
            packed8 = parser.ReadOffset< byte >( 0x8 );


        }
    }
}