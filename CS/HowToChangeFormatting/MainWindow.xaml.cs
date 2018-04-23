#region #usings
using System.Windows;
using System.Drawing;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraRichEdit.API.Native;
#endregion #usings

namespace HowToChangeFormatting {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            richEditControl1.Document.LoadDocument("SampleText.rtf", DocumentFormat.Rtf);
        }

        private void btn_FormatChar_Click(object sender, RoutedEventArgs e) {
            #region #formatchar
            Document doc = richEditControl1.Document;
            DocumentRange range = doc.Selection;
            CharacterProperties cp = doc.BeginUpdateCharacters(range);
            cp.FontName = "Comic Sans MS";
            cp.FontSize = 18;
            cp.ForeColor = Color.Yellow;
            cp.BackColor = Color.Blue;
            cp.Underline = UnderlineType.DoubleWave;
            cp.UnderlineColor = Color.White;
            doc.EndUpdateCharacters(cp);
            #endregion #formatchar
        }

        private void btn_FormatParagraph_Click(object sender, RoutedEventArgs e) {
            #region #formatparagraph
            Document doc = richEditControl1.Document;            
            DocumentRange range = doc.Selection;
            ParagraphProperties pp = doc.BeginUpdateParagraphs(range);
            // Center paragraph
            pp.Alignment = ParagraphAlignment.Center;
            // Set triple spacing
            pp.LineSpacingType = ParagraphLineSpacing.Multiple;
            pp.LineSpacingMultiplier = 3;
            // Set left indent at 0.5".
            // Default unit is 1/300 of an inch (a document unit).
            pp.LeftIndent = Units.InchesToDocumentsF(0.5f);
            // Set tab stop at 1.5"
            TabInfoCollection tbiColl = pp.BeginUpdateTabs(true);
            TabInfo tbi = new TabInfo();
            tbi.Alignment = TabAlignmentType.Center;
            tbi.Position = Units.InchesToDocumentsF(1.5f);
            tbiColl.Add(tbi);
            pp.EndUpdateTabs(tbiColl);
            doc.EndUpdateParagraphs(pp);
            #endregion #formatparagraph
        }
    }
}
