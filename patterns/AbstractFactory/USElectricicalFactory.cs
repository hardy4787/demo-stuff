using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.AbstractFactory
{
    internal class USElectricicalFactory : IElectricalFactory
    {
        public IPipe GetPipe()
        {
            return new USPipe();
        }

        public ITubelight GetTubelight()
        {
            return new WhiteTubelight();
        }
    }
}
