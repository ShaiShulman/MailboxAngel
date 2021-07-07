using HelperUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttachmentManager
{
    /// <summary>
    /// 
    /// Arguments for an event when an attachment is dragged up to down in the list
    /// 
    /// </summary>
    public class AttachmentMoveEventArgs:EventArgs
    {
        private AttachmentCommand _attach;

        public AttachmentCommand Attach
        {
            get { return _attach; }
            set { _attach = value; }
        }


        private MoveDirection _direction;
        public MoveDirection Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        private AttachmentCommand _beforeAfterAttach;
        public AttachmentCommand BeforeAfterAttach
        {
            get { return _beforeAfterAttach; }
            set { _beforeAfterAttach = value; }
        }

        public AttachmentMoveEventArgs(AttachmentCommand Attach, MoveDirection Direction,AttachmentCommand BeforeAfterAttach=null)
        {
            _attach = Attach;
            _direction = Direction;
            _beforeAfterAttach = BeforeAfterAttach;
        }
    }
}
