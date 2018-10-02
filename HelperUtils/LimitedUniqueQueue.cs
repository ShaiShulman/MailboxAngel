using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class LimitedUniqueQueue<T>:IEnumerable<T> where T : ILimitedQueueItem
    {
        private int limit;
        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }

        private List<T> _list = new List<T>();

        public bool Enqueue(T item)
        {
            T existing = _list.FirstOrDefault(x => x.UniqueID == item.UniqueID);
            if (existing != null)
            {
                if (existing.Persist || existing.Avoid)
                    return false;
                _list.Remove(existing);
            }
            for (int i = _list.Count()-1; i >=0 &&  _list.Where(x => !x.Avoid).Count()>=limit && _list.Exists(x => !x.Persist); i--)
            {
                if (!_list[i].Persist)
                {
                    _list.RemoveAt(i);
                    i++;
                }
            }
            _list.Insert(0,item);
            return (existing == null);
        }

        public T Dequeue()
        {
            T item = _list.Last();
            _list.Remove(item);
            return item;
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_list).GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index >= _list.Count)
                    throw new IndexOutOfRangeException();
                return _list[index];
            }
        }

        public LimitedUniqueQueue(int limit)
        {
            this.limit = limit;
        }

        public void Fill(IEnumerable<T> source)
        {
            _list = source.ToList();
        }
    }

    public interface ILimitedQueueItem
    {
        bool Persist
        {
            get;
            set;
        }
        bool Avoid
        {
            get;
            set;
        }
        string UniqueID
        {
            get;
        }
    }
}
