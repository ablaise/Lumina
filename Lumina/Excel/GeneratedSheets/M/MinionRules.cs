namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "MinionRules", columnHash: 0x9db0e48f )]
    public class MinionRules : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0000 col: 0
         *  name: Rule
         *  type: 
         */

        /* offset: 0004 col: 1
         *  name: Description
         *  type: 
         */



        // col: 00 offset: 0000
        public string Rule;

        // col: 01 offset: 0004
        public string Description;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            Rule = parser.ReadOffset< string >( 0x0 );

            // col: 1 offset: 0004
            Description = parser.ReadOffset< string >( 0x4 );


        }
    }
}