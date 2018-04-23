using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using DevExpress.Xpf.PivotGrid.Internal;

namespace DXPivotGrid_SelectingCellTemplate {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            picotGridControl1.DataSource =
                new nwindDataSetTableAdapters.SalesPersonTableAdapter().GetData();
        }
    }
    public class CellTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            Window mainWindow = Application.Current.MainWindow;
            CellsAreaItem cell = (CellsAreaItem)item;

            // Calculates the share of a cell value in the Row Grand Total value.
            double share = Convert.ToDouble(cell.Value) / Convert.ToDouble(cell.RowTotalValue);

            // Applies the Default template to the Row Grand Total cells.
            if (cell.RowValue == null)
                return mainWindow.FindResource("DefaultCellTemplate") as DataTemplate;

            // If the share is too far from 50%, the Highlighted template is selected.
            // Otherwise, the Normal template is applied to the cell.
            if (share > 0.7 || share < 0.3)
                return mainWindow.FindResource("HighlightedCellTemplate") as DataTemplate;
            else
                return mainWindow.FindResource("NormalCellTemplate") as DataTemplate;
        }
    }
    public class RoundConverter : MarkupExtension, IValueConverter {
        #region IValueConverter Members
        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture) {
            return System.Convert.ToInt32(value);
        }
        public object ConvertBack(object value, Type targetType,
                                  object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
        #endregion
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
