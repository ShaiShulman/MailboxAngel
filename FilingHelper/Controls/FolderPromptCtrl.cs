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
        public event EventHandler OpenFolder;
        public FolderPromptCtrl()
        {
            InitializeComponent();
        }

        public void SetText(string title, string message, bool showFolderBtn = false)
        {
            lblNormalText.Text = title;
            lblBoldText.Text = message;
            btnUndo.Enabled = true;
            btnOpenFolder.Visible = showFolderBtn;
        }


        #region events

        protected void onUndo()
        {
            if (Undo != null)
                Undo(this,EventArgs.Empty);
        }

        protected void onOpenFolder()
        {
            if (OpenFolder != null)
                OpenFolder(this, EventArgs.Empty);
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

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            onOpenFolder();
        }
    }
}
