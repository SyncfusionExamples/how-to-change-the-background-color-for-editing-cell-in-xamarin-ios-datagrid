using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Syncfusion.SfDataGrid;
using CoreGraphics;

namespace GridIniOS
{
   public class MyViewController:UIViewController
    {
        SfDataGrid dataGrid;
        ViewModel viewModel;
        public MyViewController()
        {
            dataGrid = new SfDataGrid();
            viewModel = new ViewModel();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.White;
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            dataGrid.AutoGenerateColumns = false;
            dataGrid.AllowEditing = true;
            dataGrid.EditTapAction = TapAction.OnTap;
            dataGrid.CellRenderers.Remove("Numeric");
            dataGrid.CellRenderers.Add("Numeric", new NumericColumnRenderer());
            var numericColumn = new GridNumericColumn();
            numericColumn.MappingName = "OrderID";
            numericColumn.AllowEditing = true;
            dataGrid.Columns.Add(numericColumn);

            this.View.AddSubview(dataGrid);
        }
        public override void ViewDidLayoutSubviews()
        {
            dataGrid.Frame = new CGRect(0, 50, View.Frame.Width, View.Frame.Height - 20);
            base.ViewDidLayoutSubviews();
        }
    }
}