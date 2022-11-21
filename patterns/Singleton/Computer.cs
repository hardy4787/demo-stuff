using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.Singleton
{
    internal class Computer
    {
        public OSFirst? OS { get; set; }
        public void Launch(string osName)
        {
            OS = OSSecond.instance(osName);
        }
    }
}
