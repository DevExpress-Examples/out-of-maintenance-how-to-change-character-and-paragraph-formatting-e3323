Imports Microsoft.VisualBasic
#Region "#usings"
Imports System.Windows
Imports System.Drawing
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.Utils
Imports DevExpress.XtraRichEdit.API.Native
#End Region ' #usings

Namespace HowToChangeFormatting
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			richEditControl1.Document.LoadDocument("SampleText.rtf", DocumentFormat.Rtf)
		End Sub

		Private Sub btn_FormatChar_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
'			#Region "#formatchar"
			Dim doc As Document = richEditControl1.Document
			Dim range As DocumentRange = doc.Selection
			Dim cp As CharacterProperties = doc.BeginUpdateCharacters(range)
			cp.FontName = "Comic Sans MS"
			cp.FontSize = 18
			cp.ForeColor = Color.Yellow
			cp.BackColor = Color.Blue
			cp.Underline = UnderlineType.DoubleWave
			cp.UnderlineColor = Color.White
			doc.EndUpdateCharacters(cp)
'			#End Region ' #formatchar
		End Sub

		Private Sub btn_FormatParagraph_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
'			#Region "#formatparagraph"
			Dim doc As Document = richEditControl1.Document
			Dim range As DocumentRange = doc.Selection
			Dim pp As ParagraphProperties = doc.BeginUpdateParagraphs(range)
			' Center paragraph
			pp.Alignment = ParagraphAlignment.Center
			' Set triple spacing
			pp.LineSpacingType = ParagraphLineSpacing.Multiple
			pp.LineSpacingMultiplier = 3
			' Set left indent at 0.5".
			' Default unit is 1/300 of an inch (a document unit).
			pp.LeftIndent = Units.InchesToDocumentsF(0.5f)
			' Set tab stop at 1.5"
			Dim tbiColl As TabInfoCollection = pp.BeginUpdateTabs(True)
            Dim tbi As New DevExpress.XtraRichEdit.API.Native.TabInfo()
			tbi.Alignment = TabAlignmentType.Center
			tbi.Position = Units.InchesToDocumentsF(1.5f)
			tbiColl.Add(tbi)
			pp.EndUpdateTabs(tbiColl)
			doc.EndUpdateParagraphs(pp)
'			#End Region ' #formatparagraph
		End Sub
	End Class
End Namespace
