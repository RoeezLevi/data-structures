using System;
using System.Collections.Generic;

namespace BoxDelivery.Classes
{

    /*    public class BoxQueue
        {
            private Queue<Box> boxes = new Queue<Box>();

            public void Enqueue(Box box)
            {
                boxes.Enqueue(box);
            }

            public Box Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return boxes.Dequeue();
            }

            public Box Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return boxes.Peek();
            }

            public bool IsEmpty()
            {
                return boxes.Count == 0;
            }

            public int TotalSize()
            {
                return boxes.Count;
            }
        }*/
    public class BoxQueue<T> :/* IComparer<Queue<Box>>,*/ IComparable<BoxQueue<Box>>
    {
        /*public int Compare(Queue<Box> queue1, Queue<Box> queue2)
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
        }*/
        private Queue<Box> boxes = new Queue<Box>();
        public BoxQueue()
        {
            Queue<Box> boxes = new Queue<Box>();
        }
        //add
        public void Enqueue(Box box)
        {
            boxes.Enqueue(box);
        }
        ///remove
        public Box Dequeue()
        {
            if (!IsEmpty())
            {

                return boxes.Dequeue();
            }
            else
            {
                throw new InvalidOperationException("BoxQueue is empty");
            }
        }
        //see first
        public Box Peek()
        {
            if (!IsEmpty())
            {
                return boxes.Peek();
            }
            else
                return null;
            /*            else
                        {
                            throw new InvalidOperationException("BoxQueue is empty");
                        }*/
        }
        public bool Contains(Box box)
        {
            return boxes.Contains(box);
        }
        public bool IsEmpty()
        {
            if (boxes.Count == 0 || boxes == null)
                return true;
            return false;
        }

        public int Size()
        {
            return boxes.Count;
        }

        public int CompareTo(BoxQueue<Box> otherQueue)
        {
            if (this.IsEmpty() && otherQueue.IsEmpty())
            {
                return 0; // Both queues are empty, so they are equal
            }
            else if (this.IsEmpty())
            {
                return -1; // This queue is empty, so it's considered smaller
            }
            else if (otherQueue.IsEmpty())
            {
                return 1; // Other queue is empty, so it's considered smaller
            }
            else
            {
                Box box1 = this.Peek();
                Box box2 = otherQueue.Peek();

                int xComparison = box1.X.CompareTo(box2.X);
                if (xComparison != 0)
                    return xComparison;

                return box1.Y.CompareTo(box2.Y);
            }
        }
    }

}
