using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.AbstractFactory
{
    internal interface IElectricalFactory
    {
        IPipe GetPipe();
        ITubelight GetTubelight();
    }
}
