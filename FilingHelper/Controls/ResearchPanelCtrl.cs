using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using System.Diagnostics;
using HelperUtils;

namespace FilingHelper.Controls
{
    public partial class ResearchPanelCtrl : UserControl
    {
        const int WIDTH_PADDING= 15;
        public event EventHandler<DropMailEventArgs> MailItemDropped;
        public int totalWidth
        {
            get { return pnlItemsList.Width + WIDTH_PADDING; }
            set { this.Width = value - WIDTH_PADDING; }
        }

        public ResearchPanelCtrl()
        {
            InitializeComponent();
            pnlItemsList.AcceptableDragType = typeof(ResearchItemSingleCtrl);
            pnlItemsList.AllowExternalDrop = true;
            pnlItemsList.Resize += PnlItemsList_Resize;
            pnlItemsList.ExternalDrop += PnlItemsList_ExternalDrop;
        }
        
        public ResearchPanelCtrl(MailHistoryManager listManager) : this()
        {
            listManager.NewMailItem += ListManager_NewMailItem;
            foreach (var item in listManager)
            {
                ResearchItemSingleCtrl ctrl = new ResearchItemSingleCtrl(item);
                ctrl.ControlRemoved += Ctrl_ControlRemoved;
                ctrl.Width = pnlItemsList.Width;
                ctrl.ToolStripShown += Ctrl_ToolStripShown;
                pnlItemsList.AddControl(ctrl);
            }
        }

        private void Ctrl_ToolStripShown(object sender, EventArgs e)
        {
            foreach (ResearchItemSingleCtrl item in pnlItemsList.Controls)
            {
                if (item != (ResearchItemSingleCtrl)sender)
                    item.HideToolStrip();
            }
        }

        private void ListManager_NewMailItem(object sender, MailItemEventArgs e)
        {
            ResearchItemSingleCtrl ctrl = new ResearchItemSingleCtrl(e.ItemInfo);
            ctrl.ControlRemoved += Ctrl_ControlRemoved;
            ctrl.Width = pnlItemsList.Width;
            ctrl.ToolStripShown += Ctrl_ToolStripShown;
            ctrl.Visible = e.ItemInfo.Persist || !btnShowPinned.Checked;
            Control first = firstNonPersistent();
            if (first==null)
                pnlItemsList.AddControl(ctrl);
            else
                pnlItemsList.AddControl(ctrl, MoveDirection.Before,first);
        }

        private ResearchItemSingleCtrl firstNonPersistent()
        {
            ResearchItemSingleCtrl found = null;
            int i = 0;
            while (found==null && i<pnlItemsList.Controls.Count)
            {
                Control ctrl = pnlItemsList.Controls[i];
                if (ctrl is ResearchItemSingleCtrl
                    && !((ResearchItemSingleCtrl)ctrl).MailInfo.Persist)
                    found = (ResearchItemSingleCtrl)ctrl;
                i++;
            }
            return found;
        }

        private void PnlItemsList_Resize(object sender, EventArgs e)
        {
            foreach (Control item in pnlItemsList.Controls)
            {
                item.Width = pnlItemsList.Width;
                item.Refresh();
            }
        }

        protected void onMailItemDropped(MailItem item)
        {
            if (MailItemDropped != null)
                MailItemDropped(this, new DropMailEventArgs(item));
        }

         private void pnlItemsList_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
            pnlItemsList.BackColor = System.Drawing.SystemColors.ActiveCaption;
        }

        private void pnlItemsList_DragLeave(object sender, EventArgs e)
        {
            pnlItemsList.BackColor = System.Drawing.SystemColors.ButtonFace;
        }

        private IEnumerable<ResearchItemSingleCtrl> createChildControl()
        {
            Explorer explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            Selection selection = explorer.Selection;
            List<ResearchItemSingleCtrl> controls = new List<ResearchItemSingleCtrl>();
            foreach (MailItem item in selection)
            {
                ResearchItemSingleCtrl ctrl = new ResearchItemSingleCtrl(new MailInfo(item as MailItem));
                ctrl.ControlRemoved += Ctrl_ControlRemoved;
                ctrl.Width = pnlItemsList.Width;
                ctrl.ToolStripShown += Ctrl_ToolStripShown;
                controls.Add(ctrl);
            }
            return controls;
        }

        private void Ctrl_ControlRemoved(object sender, EventArgs e)
        {
            pnlItemsList.Controls.Remove((Control)sender);
        }

        private void PnlItemsList_ExternalDrop(object sender, HelperUtils.ExternalDropEventArgs e)
        {
            pnlItemsList.BackColor = System.Drawing.SystemColors.ButtonFace;
            IEnumerable<ResearchItemSingleCtrl> controls = createChildControl();
            foreach (var item in controls)
            {
                pnlItemsList.AddControl(item,e.Direction,e.DropPosition);
            }
            pnlItemsList.finalizeLayout();
        }

        private void pnlItemsList_DragDrop(object sender, DragEventArgs e)
        {
            IEnumerable<ResearchItemSingleCtrl> controls = createChildControl();
            foreach (var item in controls)
            {
                pnlItemsList.AddControl(item);
            }
            pnlItemsList.finalizeLayout();
        }

        private void pnlItemsList_MouseEnter(object sender, EventArgs e)
        {
            foreach (ResearchItemSingleCtrl item in pnlItemsList.Controls)
            {
                item.HideToolStrip();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowPinned_Click(object sender, EventArgs e)
        {
            filterPinned(btnShowPinned.Checked);
        }

        private void filterPinned(bool filter)
        {
            foreach (Control ctrl in pnlItemsList.Controls)
            {
                if(ctrl is ResearchItemSingleCtrl)
                {
                    if (!((ResearchItemSingleCtrl)ctrl).MailInfo.Persist)
                    {
                        ctrl.Visible = !filter;
                    }
                }
            }
        }
    }
    #region EventArgs
    public class DropMailEventArgs:EventArgs
    {
        private MailItem _item;

        public MailItem Item
        {
            get { return _item; }
            set { _item = value; }
        }

        public DropMailEventArgs(MailItem Item)
        {
            _item = Item;
        }

    }
    #endregion
}
