using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.Singleton
{
    internal class OSThird
    {
        private static readonly Lazy<OSThird> lazy = new Lazy<OSThird>(() => new OSThird());
        public string Name { get; private set; }
        private OSThird()
        {
            this.Name = new Guid().ToString();
        }

        public static OSThird GetInstance()
        {
            return lazy.Value;
        }
    }
}
