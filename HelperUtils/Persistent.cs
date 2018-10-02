using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field,AllowMultiple=false)]
    public class Persistent : System.Attribute
    {
        public double version;

        public Persistent()
        {
            version = 1.0;
        }
    }
}
