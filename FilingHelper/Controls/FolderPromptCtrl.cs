using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilingHelper
{
    public partial class FolderPromptCtrl : UserControl
    {
        public event EventHandler Undo;
        public FolderPromptCtrl()
        {
            InitializeComponent();
        }

        public void SetText(string title,string message)
        {
            lblNormalText.Text = title;
            lblBoldText.Text = message;
            btnUndo.Enabled = true;
        }


        #region events

        protected void onUndo()
        {
            if (Undo != null)
                Undo(this,EventArgs.Empty);
        }

        #endregion

        private void btnUndo_Click(object sender, EventArgs e)
        {
            btnUndo.Enabled = false;
            onUndo();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
