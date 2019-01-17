using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public class CounterList<T>
        where T:ICounterListItem
    {
        Dictionary<T, int> _dictionary;
        public CounterList(IEqualityComparer<T> comparer)
        {
            _dictionary = new Dictionary<T, int>(comparer);
        }
        public void Add(T item)
        {
            if (_dictionary.ContainsKey(item))
                _dictionary[item]++;
            else
                _dictionary.Add(item, 0);
        }
        public void Add(T item,int count)
        {
            if (_dictionary.ContainsKey(item))
                _dictionary[item]++;
            else
                _dictionary.Add(item, count);
        }

        public int this[T key]
        {
            get
            {
                return _dictionary[key];
            }
        }

        public bool Empty
        {
            get
            {
                return _dictionary.Count == 0;
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

        public Dictionary<T, int> GetDictionary()
        {
            return _dictionary;
        }

        public void WriteJson(JsonWriter writer)
        {
            foreach (var item in _dictionary)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("Folder");
                writer.WriteValue(item.Key.ToString());
                writer.WritePropertyName("Counter");
                writer.WriteValue(item.Value);
                writer.WriteEndObject();
            }
        }

        //public void PopulatefromJson()

    }

    public interface ICounterListItem
    {
        string Description { get; }
    }
}
