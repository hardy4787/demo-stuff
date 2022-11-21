using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.FactoryMethod
{
    internal class WoodDeveloper : IDeveloper
    {
        public IHouse CreateHouse()
        {
            return new WoodHouse();
        }
    }
}
