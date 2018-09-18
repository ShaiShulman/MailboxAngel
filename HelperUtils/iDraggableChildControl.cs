using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public interface iDraggableChildControl
    {
        event EventHandler<ChildDragEventArgs> ControlDragOver;
        event EventHandler ControlDragLeave;
        event EventHandler<ChildDragEventArgs> ControlDropOver;

    }

    public class ChildDragEventArgs : EventArgs
    {
        private ChildDragDirection _direction;

        public ChildDragDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public ChildDragEventArgs(ChildDragDirection Direction)
        {
            _direction = Direction;
        }
    }
    public enum ChildDragDirection { Before, After }

}
