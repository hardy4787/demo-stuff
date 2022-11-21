using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.FactoryMethod
{
    internal class WoodHouse: IHouse
    {
        public WoodHouse()
        {
            Console.WriteLine("WoodHouse");
        }

        public void OpenWindow()
        {
            Console.WriteLine("OpenWindow in WoodHouse");
        }
    }
}
