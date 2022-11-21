using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.SimpleFactory
{
    internal class FanFactory
    {
        public IFan Create(FanType type)
        {
            return type switch
            {
                FanType.Black => new BlackFan(),
                FanType.White => new WhiteFan(),
                _ => new WhiteFan(),
            };
        }
    }
}
