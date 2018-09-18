using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    class SignatureInfo
    {
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}
