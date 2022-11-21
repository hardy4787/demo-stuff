using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.AbstractFactory
{
    internal class IndianElectricalFactory : IElectricalFactory
    {
        public IPipe GetPipe()
        {
            return new IndianPipe();
        }

        public ITubelight GetTubelight()
        {
            return new BlackTubelight();
        }
    }
}
