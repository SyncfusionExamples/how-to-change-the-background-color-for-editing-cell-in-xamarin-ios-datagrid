using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Syncfusion.SfDataGrid.Renderers;
using Syncfusion.SfDataGrid;
using Syncfusion.SfNumericTextBox.iOS;
using CoreGraphics;

namespace GridIniOS
{
    public class NumericColumnRenderer : GridCellNumericRenderer
    {
        public NumericColumnRenderer()
        {

        }

        public override void OnInitializeEditView(DataColumnBase dataColumn, SfNumericTextBox view)
        {
            base.OnInitializeEditView(dataColumn, view);
            view.BackgroundColor = UIColor.Cyan;
        }              
    }
}