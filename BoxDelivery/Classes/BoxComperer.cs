/*using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDelivery.Classes
{
    public class BoxComparer : IComparer<Box>
    {
        public static readonly BoxComparer Comparer = new BoxComparer();

        public int Compare(Box box1, Box box2)
        {
            int xComparison = box1.X.CompareTo(box2.X);
            if (xComparison != 0)
                return xComparison;

            return box1.Y.CompareTo(box2.Y);
        }
    }
}
*/