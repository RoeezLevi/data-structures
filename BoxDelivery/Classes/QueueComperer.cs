/*using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDelivery.Classes
{
    public class QueueComperer : IComparer<Queue<Box>>
    {

        public int Compare(Queue<Box> queue1, Queue<Box> queue2)
        {
            if (queue1 == null || queue2 == null)
                throw new ArgumentNullException();

            if (queue1.Count == 0 || queue2.Count == 0)
                throw new InvalidOperationException("BoxQueue is empty.");

            Box box1 = queue1.Peek();
            Box box2 = queue2.Peek();

            int xComparison = box1.X.CompareTo(box2.X);
            if (xComparison != 0)
                return xComparison;

            return box1.Y.CompareTo(box2.Y);
        }
    }



}



*/