using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.SimpleFactory
{
    internal class BlackFan : IFan
    {
        public void SwitchOff()
        {
            Console.WriteLine("BlackFan off");
        }

        public void SwitchOn()
        {
            Console.WriteLine("BlackFan on");
        }
    }
}
