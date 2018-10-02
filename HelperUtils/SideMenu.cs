using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelperUtils
{
    public partial class SideMenu : UserControl
    {
        //private List<SideMenuItemDescription> _item;
        private string[] _items;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string[] Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        //private string[] _items;

        //public string[] Items
        //{
        //    get { return _items; }
        //    set { _items = value; }
        //}


        public SideMenu()
        {
            InitializeComponent();
        }

        private void SideMenu_Load(object sender, EventArgs e)
        {
            if (Items!=null)
                foreach (var item in Items)
                {
                    ctlContainer.Controls.Add(new SideMenuItem(item,null));
                }

        }
    }
    [Serializable]
    public class SideMenuItemDescription
    {
        private string _label;
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private Control _pane;
        public Control Pane
        {
            get { return _pane; }
            set { _pane = value; }
        }

    }
}
