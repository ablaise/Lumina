namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "AnimaWeapon5Param", columnHash: 0x5eb59ccb )]
    public class AnimaWeapon5Param : IExcelRow
    {
        // column defs from Sat, 15 Jun 2019 16:05:03 GMT

        /* offset: 0004 col: 0
         *  name: BaseParam
         *  type: 
         */

        /* offset: 0000 col: 1
         *  name: Name
         *  type: 
         */



        // col: 01 offset: 0000
        public string Name;

        // col: 00 offset: 0004
        public byte BaseParam;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 1 offset: 0000
            Name = parser.ReadOffset< string >( 0x0 );

            // col: 0 offset: 0004
            BaseParam = parser.ReadOffset< byte >( 0x4 );


        }
    }
}