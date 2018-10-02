using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public abstract class HistoryListItemBase : ILimitedQueueItem
    {
        public virtual bool Active { get; }
        public virtual string UniqueID { get; }

        protected bool _persist;
        public  bool Persist
        {
            get { return _persist; }
            set { _persist = value; }
        }
        protected bool _avoid;
        public bool Avoid
        {
            get { return _avoid; }
            set { _avoid = value; }
        }

    }

}
