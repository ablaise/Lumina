// ReSharper disable All

using Lumina.Text;
using Lumina.Data;
using Lumina.Data.Structs.Excel;

namespace Lumina.Excel.GeneratedSheets
{
    [Sheet( "ActionIndirection", columnHash: 0xc8901190 )]
    public class ActionIndirection : ExcelRow
    {
        
        public LazyRow< Action > Name { get; set; }
        public LazyRow< ClassJob > ClassJob { get; set; }
        public int Unknown2 { get; set; }
        
        public override void PopulateData( RowParser parser, GameData gameData, Language language )
        {
            base.PopulateData( parser, gameData, language );

            Name = new LazyRow< Action >( gameData, parser.ReadColumn< int >( 0 ), language );
            ClassJob = new LazyRow< ClassJob >( gameData, parser.ReadColumn< sbyte >( 1 ), language );
            Unknown2 = parser.ReadColumn< int >( 2 );
        }
    }
}