using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class CounterList<T>
    {
        Dictionary<T, int> _dictionary;
        public CounterList()
        {
            _dictionary = new Dictionary<T, int>();
        }
        public void Add(T item)
        {
            if (_dictionary.ContainsKey(item))
                _dictionary[item]++;
            else
                _dictionary.Add(item, 0);
        }

        public int this[T key]
        {
            get
            {
                return _dictionary[key];
            }
        }

        public void Remove(T key)
        {
            if (_dictionary.ContainsKey(key))
                _dictionary.Remove(key);
        }

        public T[] GetTop(int items)
        {
            return _dictionary.OrderByDescending(x => x.Value).Take(items).Select(x => x.Key).ToArray();
        }
    }
}
