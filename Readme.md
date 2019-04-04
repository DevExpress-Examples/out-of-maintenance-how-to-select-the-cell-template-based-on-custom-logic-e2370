<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/DXPivotGrid_SelectingCellTemplate/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/DXPivotGrid_SelectingCellTemplate/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/DXPivotGrid_SelectingCellTemplate/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/DXPivotGrid_SelectingCellTemplate/MainWindow.xaml.vb))
<!-- default file list end -->
# How to select the cell template based on custom logic


<p>The following example demonstrates how to select the cell template based on custom logic.</p><p>In this example, data cell values are represented by progress bars. The template used to display the data cells is selected based on the share of the data cell value in the Row Grand Total value. If this share is bigger than 80% or less than 20%, a red progress bar is displayed in the cell. Otherwise, a blue bar is displayed.</p>

<br/>


