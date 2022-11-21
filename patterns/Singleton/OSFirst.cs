using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns.Singleton
{
    internal class OSFirst
    {
        public string Name { get; private set; }
        private static readonly object lockObject = new();
        private static OSFirst? _instance;

        private OSFirst(string name)
        {
            this.Name = name;
        }

        public static OSFirst GetInstance(string name)
        {
            if (_instance == null)
            {
                lock (lockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new OSFirst(name);
                    }

                }
            }
            return _instance;
        }
    }
}
