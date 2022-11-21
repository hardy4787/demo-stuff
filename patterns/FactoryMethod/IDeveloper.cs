using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.FactoryMethod
{
    internal interface IDeveloper
    {
        IHouse CreateHouse();
    }
}
