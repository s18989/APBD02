using System;
using System.Collections.Generic;

namespace APBD02
{
    public class StudentPorownywacz : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Equals(x.numerIndeksu, y.numerIndeksu);
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase.GetHashCode(obj.numerIndeksu);
        }
    }
}
