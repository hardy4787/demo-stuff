using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.AbstractFactory
{
    internal class BlackTubelight : ITubelight
    {
        public void SwitchOff()
        {
            Console.WriteLine("BlackTubelight off");
        }

        public void SwitchOn()
        {
            Console.WriteLine("BlackTubelight on");
        }
    }
}
