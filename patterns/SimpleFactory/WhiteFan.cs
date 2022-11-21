using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.SimpleFactory
{
    internal class WhiteFan : IFan
    {
        public void SwitchOff()
        {
            Console.WriteLine("WhiteFan off");
        }

        public void SwitchOn()
        {
            Console.WriteLine("WhiteFan on");
        }
    }
}
