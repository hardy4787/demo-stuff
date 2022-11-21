using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.AbstractFactory
{
    internal class USPipe : IPipe
    {
        public void Transform()
        {
            Console.WriteLine("USPipe Transform");
        }
    }
}
