using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.FactoryMethod
{
    internal class PanelHouse: IHouse
    {
        public PanelHouse()
        {
            Console.WriteLine("PanelHouse");
        }

        public void OpenWindow()
        {
            Console.WriteLine("OpenWindow in PanelHouse");
        }
    }
}
