using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperUtils
{
    class DraggableLayout:FlowLayoutPanel
    {
        public DraggableLayout()
        {
            this.DragDrop += DraggableLayout_DragDrop;
        }

        private void DraggableLayout_DragDrop(object sender, DragEventArgs e)
        {
            Control sourceCtrl = (Control)e.Data.GetData(typeof(Control));
            Point p = this.PointToClient(new Point(e.X, e.Y));
            var item = this.GetChildAtPoint(p);
            int index = this.Controls.GetChildIndex(item, false);
        }
    }


}
