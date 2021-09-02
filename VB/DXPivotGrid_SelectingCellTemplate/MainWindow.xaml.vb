Imports System
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Markup
Imports DevExpress.Xpf.PivotGrid.Internal

Namespace DXPivotGrid_SelectingCellTemplate
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			picotGridControl1.DataSource = (New nwindDataSetTableAdapters.SalesPersonTableAdapter()).GetData()
		End Sub
	End Class
	Public Class CellTemplateSelector
		Inherits DataTemplateSelector

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
'INSTANT VB NOTE: The variable mainWindow was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
			Dim mainWindow_Conflict As Window = Application.Current.MainWindow
			Dim cell As CellsAreaItem = DirectCast(item, CellsAreaItem)

			' Calculates the share of a cell value in the Row Grand Total value.
			Dim share As Double = Convert.ToDouble(cell.Value) / Convert.ToDouble(cell.RowTotalValue)

			' Applies the Default template to the Row Grand Total cells.
			If cell.RowValue Is Nothing Then
				Return TryCast(mainWindow_Conflict.FindResource("DefaultCellTemplate"), DataTemplate)
			End If

			' If the share is too far from 50%, the Highlighted template is selected.
			' Otherwise, the Normal template is applied to the cell.
			If share > 0.7 OrElse share < 0.3 Then
				Return TryCast(mainWindow_Conflict.FindResource("HighlightedCellTemplate"), DataTemplate)
			Else
				Return TryCast(mainWindow_Conflict.FindResource("NormalCellTemplate"), DataTemplate)
			End If
		End Function
	End Class
	Public Class RoundConverter
		Inherits MarkupExtension
		Implements IValueConverter

		#Region "IValueConverter Members"
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Return System.Convert.ToInt32(value)
		End Function
		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New NotImplementedException()
		End Function
		#End Region
		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return Me
		End Function
	End Class
End Namespace
