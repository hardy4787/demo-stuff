using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.AbstractFactory
{
    internal class WhiteTubelight : ITubelight
    {
        public void SwitchOff()
        {
            Console.WriteLine("WhiteTubelight off");
        }

        public void SwitchOn()
        {
            Console.WriteLine("WhiteTubelight on");
        }
    }
}
