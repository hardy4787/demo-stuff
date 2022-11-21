using System;
using System.Collections.Generic;
using System.Text;
using Linq.Objects;

namespace Linq.Comparers
{
    class EntrantComparer : IEqualityComparer<Entrant>
    {
        public bool Equals(Entrant x, Entrant y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            return x.LastName == y.LastName && x.Year == y.Year && x.SchoolNumber == y.SchoolNumber;
        }

        public int GetHashCode(Entrant obj)
        {
            return (obj.LastName, obj.Year, obj.SchoolNumber).GetHashCode();
        }
    }
}
