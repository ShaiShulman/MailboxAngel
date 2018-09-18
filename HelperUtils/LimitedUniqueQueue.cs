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

        private List<T> list = new List<T>();

        public void Enqueue(T item)
        {
            T existing = list.FirstOrDefault(x => x.ToString() == item.ToString());
            if (existing != null)
            {
                if (existing.Persist || existing.Avoid)
                    return;
                list.Remove(existing);
            }
            for (int i = list.Count()-1; i >=0 &&  list.Where(x => !x.Avoid).Count()>=limit && list.Exists(x => !x.Persist); i--)
            {
                if (!list[i].Persist)
                {
                    list.RemoveAt(i);
                    i++;
                }
            }
            list.Insert(0,item);
        }

        public T Dequeue()
        {
            T item = list.Last();
            list.Remove(item);
            return item;
        }

        public T[] ToArray()
        {
            return list.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        public T this[int index]
        {
            get
            {
                if (index >= list.Count)
                    throw new IndexOutOfRangeException();
                return list[index];
            }
        }

       


        public LimitedUniqueQueue(int limit)
        {
            this.limit = limit;
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
    }
}
