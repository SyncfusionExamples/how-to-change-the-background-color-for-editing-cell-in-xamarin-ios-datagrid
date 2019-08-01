using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Syncfusion.SfDataGrid;
using Syncfusion.Data.Extensions;
using CoreGraphics;

namespace GridIniOS
{
    public class CustomCell:GridCell
    {
        //private UILabel label;
        private UITextField edit;
        public CustomCell()
        {
            //label = new UILabel();
            //this.AddSubview(label);
            edit = new UITextField();
            edit.AllowsEditingTextAttributes = true;
            if (edit.Text == "Linod")
            {
                edit.TextColor = UIColor.Blue;
                edit.BackgroundColor = UIColor.Black;
            }
            edit.EditingChanged += Edit_EditingChanged;
            this.edit.ShouldReturn += (textField) =>
            {
                edit.ResignFirstResponder();
                return true;
            };
            this.AddSubview(edit);
        }
        public override void WillMoveToWindow(UIWindow window)
        {
            List<UIGestureRecognizer> gesturelist;
            if (this.GestureRecognizers != null)
            {
                gesturelist = new List<UIGestureRecognizer>();
                foreach (var gesture in this.GestureRecognizers)
                    gesturelist.Add(gesture);
                gesturelist.FirstOrDefault(ges => ges is UITapGestureRecognizer).ShouldRecognizeSimultaneously = (gestureRecognizer, otherGestureRecognizer) => true;
            }
            base.WillMoveToWindow(window);
        }
        private void Edit_EditingChanged(object sender, EventArgs e)
        {
            var edited = this.DataColumn.Renderer.DataGrid.View.GetItemProperties();
            edited.SetValue(this.DataColumn.RowData, edit.Text, this.DataColumn.GridColumn.MappingName);
        }

        public override void LayoutSubviews()
        {
            edit.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            edit.Text = Convert.ToString(DataColumn.CellValue);
            base.LayoutSubviews();
        }
        protected override void UnLoad()
        {
            this.RemoveFromSuperview();
        }

        protected override double GetAutoHeight(object RowData)
        {
            return 50;
        }
        //public override void LayoutSubviews()
        //{
        //    label.Frame = new CoreGraphics.CGRect(0,0, this.Frame.Width, this.Frame.Height);
        //    label.Text = DataColumn.FormattedCellvalue;
        //    if (label.Text == "Frans" || label.Text== "Linod")
        //        label.BackgroundColor = UIColor.Purple;
        //    else if (label.Text == "Simob")
        //        label.BackgroundColor = UIColor.Gray;
        //    else
        //        label.BackgroundColor = UIColor.Clear;
        //    base.LayoutSubviews();
        //}
    }
}