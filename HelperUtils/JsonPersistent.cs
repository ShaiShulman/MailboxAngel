using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    public abstract class JsonPersistent<T>
        where T:class
    {
        protected abstract string GetFileName();
        protected void Save(string obj)
        {
            using (var writer = new StreamWriter(GetFileName(), false))
            {
                writer.Write(obj);
                writer.Close();
            }
        }

        protected string LoadText()
        {
            return File.ReadAllText(GetFileName());
        }
    }
}
