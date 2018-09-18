using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class HistoryManagerBase<T>: IEnumerable<T>
        where T:HelperUtils.HistoryListItemBase
    {
        protected int _listSize;
        protected LimitedUniqueQueue<T> _list;

        public IEnumerable<T> GetList()
        {
            return _list.Where(x => x.Active).OrderBy(x => x.Persist);
        }
        public T Find(Func<T, bool> predicate)
        {
            return _list.First(predicate);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    return _list.GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _list.GetEnumerator();
        //}

        public HistoryManagerBase(int size)
        {
            _listSize = size;
            _list = new LimitedUniqueQueue<T>(size);
        }



    }
}
