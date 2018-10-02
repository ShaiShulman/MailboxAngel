using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HelperUtils
{
    public abstract class XMLPersistent<T>
        where T:class
    {
        protected abstract string BaseNodeName { get; }
        protected abstract string GetFileName();
        protected void SaveAll(IEnumerable<object> list)
        {
            XmlDocument document = new XmlDocument();
            XmlNode parent = document.AppendChild(document.CreateElement(BaseNodeName));
            foreach (var item in list)
            {
                saveObject(item, parent);
            }
            document.Save(GetFileName());
        }
        private void saveObject(object data, XmlNode baseNode)
        {
            Type type = data.GetType();
            XmlElement objectNode = baseNode.OwnerDocument.CreateElement(type.Name);

            foreach (PropertyInfo item in type.GetProperties())
            {
                Attribute atr=item.GetCustomAttribute<Persistent>();
                if (atr!=null)
                {
                    XmlElement node = baseNode.OwnerDocument.CreateElement(item.Name);
                    node.InnerText = item.GetValue(data).ToString();
                    objectNode.AppendChild(node);
                }
            }
            baseNode.AppendChild(objectNode);
        }
        protected List<T> loadAll()
        {
            XmlDocument document = new XmlDocument();
            string fname = GetFileName();
            if (!File.Exists(fname))
                return null;
            document.Load(fname);
            List<T> list = new List<T>();
            foreach (XmlNode node in document.SelectNodes(String.Format("/{0}/{1}",BaseNodeName,typeof(T).Name)).Cast<XmlNode>().Reverse())
            {
                T item = loadObject(node);
                if (item != null)
                    list.Add(item);
                    
            }
            return list;

        }
        protected T loadObject(XmlNode objectNode)
        {
            if (objectNode.ChildNodes.Count == 0)
                return null;
            T result = Activator.CreateInstance<T>();
            Type type = result.GetType();
            foreach (XmlNode element in objectNode.ChildNodes)
            {
                PropertyInfo property = type.GetProperty(element.Name);
                if (property!=null)
                {
                    switch (property.PropertyType.Name)
                    {
                        case "Int32":
                            property.SetValue(result, Convert.ToInt32(element.InnerText));
                            break;
                        case "String":
                            property.SetValue(result, element.InnerText);
                            break;
                        case "Boolean":
                            property.SetValue(result, Convert.ToBoolean(element.InnerText.Trim().ToLower()=="true"));
                            break;


                    }
                }
            }
            return result;
        }
    }
}
