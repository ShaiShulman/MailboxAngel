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
        public event EventHandler<MenuItemSelectedEventArgs> MenuItemSelected;

        private int _selectedItem;
        public int SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value;
                onMenuItemSelected(_selectedItem);
            }
        }

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
                    Control ctrl=new SideMenuItem(item, null);
                    ctrl.Click += ((se, ee) => { onMenuItemSelected(ctlContainer.Controls.IndexOf((Control)se)); });
                    ctlContainer.Controls.Add(ctrl);
                }

        }
        #region eventhandlers
        protected void onMenuItemSelected(int item)
        {
            _selectedItem = item;
            foreach (Control ctrl in ctlContainer.Controls)
                ((SideMenuItem)ctrl).Selected = (ctlContainer.Controls.IndexOf(ctrl) == item);
            if (MenuItemSelected != null)
                MenuItemSelected(this, new MenuItemSelectedEventArgs() { SelectedItem = item });
        }
        #endregion
    }


        #region eventargs
        public class MenuItemSelectedEventArgs
    {
        private int _selectedItem;
        public int SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }

    }

    #endregion

    //[Serializable]
    //public class SideMenuItemDescription
    //{
    //    private string _label;
    //    public string Label
    //    {
    //        get { return _label; }
    //        set { _label = value; }
    //    }

    //    private Control _pane;
    //    public Control Pane
    //    {
    //        get { return _pane; }
    //        set { _pane = value; }
    //    }

    //}
}
