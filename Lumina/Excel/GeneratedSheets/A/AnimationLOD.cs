namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "AnimationLOD", columnHash: 0x261cfad0 )]
    public class AnimationLOD : IExcelRow
    {
        // column defs from Wed, 15 Jan 2020 17:17:16 GMT

        /* offset: 0000 col: 0
         *  name: CameraDistance
         *  type: 
         */

        /* offset: 0004 col: 1
         *  name: SampleInterval
         *  type: 
         */

        /* offset: 0008 col: 2
         *  name: BoneLOD
         *  type: 
         */

        /* offset: 0009 col: 3
         *  name: AnimationEnable
         *  repeat count: 8
         */

        /* offset: 000a col: 4
         *  no SaintCoinach definition found
         */

        /* offset: 000b col: 5
         *  no SaintCoinach definition found
         */

        /* offset: 000c col: 6
         *  no SaintCoinach definition found
         */

        /* offset: 000d col: 7
         *  no SaintCoinach definition found
         */

        /* offset: 000e col: 8
         *  no SaintCoinach definition found
         */

        /* offset: 000f col: 9
         *  no SaintCoinach definition found
         */

        /* offset: 0010 col: 10
         *  no SaintCoinach definition found
         */



        // col: 00 offset: 0000
        public float CameraDistance;

        // col: 01 offset: 0004
        public float SampleInterval;

        // col: 02 offset: 0008
        public sbyte BoneLOD;

        // col: 03 offset: 0009
        public bool[] AnimationEnable;


        public int RowId { get; set; }
        public int SubRowId { get; set; }

        public void PopulateData( RowParser parser, Lumina lumina )
        {
            RowId = parser.Row;
            SubRowId = parser.SubRow;

            // col: 0 offset: 0000
            CameraDistance = parser.ReadOffset< float >( 0x0 );

            // col: 1 offset: 0004
            SampleInterval = parser.ReadOffset< float >( 0x4 );

            // col: 2 offset: 0008
            BoneLOD = parser.ReadOffset< sbyte >( 0x8 );

            // col: 3 offset: 0009
            AnimationEnable = new bool[8];
            AnimationEnable[0] = parser.ReadOffset< bool >( 0x9 );
            AnimationEnable[1] = parser.ReadOffset< bool >( 0xa );
            AnimationEnable[2] = parser.ReadOffset< bool >( 0xb );
            AnimationEnable[3] = parser.ReadOffset< bool >( 0xc );
            AnimationEnable[4] = parser.ReadOffset< bool >( 0xd );
            AnimationEnable[5] = parser.ReadOffset< bool >( 0xe );
            AnimationEnable[6] = parser.ReadOffset< bool >( 0xf );
            AnimationEnable[7] = parser.ReadOffset< bool >( 0x10 );


        }
    }
}