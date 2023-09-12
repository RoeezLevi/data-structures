using System;
using System.Collections.Generic;

namespace BoxDelivery.Classes
{
    public class SortedSetOfBox
    {
        private static HashSet<Box> sortedBox = new HashSet<Box>();


        public SortedSetOfBox()
        {
            sortedBox = new HashSet<Box>();
        }
        public HashSet<Box> GetsortedBox
        {
            get { return sortedBox; }
        }

        //add box to thor or create new thor

        public bool Enqueue(Box box)
        {
            Box targetBox = FindTargetBox(box);
            if (targetBox == null)
            {
                targetBox = new Box(box.X, box.Y, 1);
                sortedBox.Add(targetBox);
                Storage.AvailabelInStock.Add(targetBox);
                Storage.LowInStock.Add(targetBox);
                if (Storage.NeedToRestock.Contains(targetBox))
                    Storage.NeedToRestock.Remove(targetBox);
                try
                {
                    int place = 0;
                    foreach (Box Currentbox in sortedBox)
                    {
                        if (Currentbox.CompareTo(box) == 0)
                        {
                            break;
                        }
                        place++;
                    }
                    Storage.NeedToRestock.RemoveAt(place);
                }
                catch { }
                return true;
            }
            else
            {
                /*                if (targetBox.IsExpiered() == true)
                                {
                                    while (targetBox.IsExpiered() == true && targetBox.Amount != 0)
                                    {
                                        targetBox.Amount = targetBox.Amount - 1;
                                    }
                                }*/
                if (targetBox.Amount <= Storage.MinBoxes && Storage.LowInStock.Contains(targetBox) == false)
                {
                    targetBox.Amount = targetBox.Amount + 1;
                    targetBox.ExpireDate = DateTime.Now.AddMonths(2);
                    Storage.LowInStock.Add(targetBox);
                    return true;///if added
                }
                if (targetBox.Amount < Storage.MaxBoxes)
                {
                    targetBox.Amount = targetBox.Amount + 1;
                    targetBox.ExpireDate = DateTime.Now.AddMonths(2);
                    /*   sortedBox.Remove(targetBox);
                       sortedBox.Add(targetBox);*/
                    if (targetBox.Amount > Storage.MinBoxes && Storage.LowInStock.Contains(targetBox) == true)
                        Storage.LowInStock.Remove(targetBox);
                    return true;///if added
                }
                else
                    return false;///if not added


            }
        }
        /*        public void Add(BoxQueue<Box> Queue)
                {
                    sortedBox.Add(Queue);
                }*/
        //find thor of box
        public Box FindTargetBox(Box box)
        {
            foreach (Box Currentbox in sortedBox)
            {
                if (Currentbox.IsExpiered() == true)
                {
                    sortedBox.Remove(Currentbox);
                    Storage.NeedToRestock.Add(Currentbox);
                    Storage.AvailabelInStock.Remove(Currentbox);
                    Storage.LowInStock.Remove(Currentbox);
                }
                else
                {
                    if (Currentbox.IsOld() == true)
                    {
                        if (Storage.NotSelling.Contains(Currentbox) == false)
                        {
                            Storage.NotSelling.Add(Currentbox);
                        }
                    }
                    if (Currentbox.CompareTo(box) == 0)/////////////////לבדוק מה אם מה שאני מוצא פג תוקף
                    {
                        return Currentbox;
                    }
                    if (Currentbox.IsEmpty())
                    {
                        sortedBox.Remove(Currentbox);
                        Storage.NeedToRestock.Add(Currentbox);
                        Storage.AvailabelInStock.Remove(Currentbox);
                        Storage.LowInStock.Remove(Currentbox);
                    }
                    /* else if (Storage.NotSelling.Contains(queue) == true)
                     {
                         Storage.NotSelling.Remove(queue);
                     }*/

                }

            }
            return null;
        }
        /*public Box Dequeue()
        {
            if (sortedBox.Count == 0)
            {
                throw new InvalidOperationException("SortedSetOfQueues is empty");
            }

            BoxQueue<Box> highestPriorityQueue = sortedBox.Min;
            Box box = highestPriorityQueue.Dequeue();

            if (highestPriorityQueue.Count == 0)
            {
                sortedBox.Remove(sortedBox.Min);
            }

            return box;
        }*/
        //remove box 1 if about to end 0 if ended -1 if not found
        public int DequeueBox(Box box)
        {

            foreach (var currentbox in sortedBox)
            {
                if (currentbox.CompareTo(box) == 0)
                {
                    if (currentbox.IsExpiered() == true)
                    {
                        sortedBox.Remove((Box)currentbox);
                        Storage.NeedToRestock.Add(currentbox);
                        Storage.AvailabelInStock.Remove(currentbox);
                        Storage.LowInStock.Remove(currentbox);
                        return -1;
                    }
                    /* if (queue.Size() == 1)
                         queue.Dequeue();*/
                    /*if (queue.IsEmpty())*/
                    if (currentbox.Amount == 1)
                    {
                        sortedBox.Remove(currentbox);
                        Storage.NeedToRestock.Add(currentbox);
                        Storage.AvailabelInStock.Remove(currentbox);
                        Storage.LowInStock.Remove(currentbox);
                        return 0;
                    }
                    else
                    {
                        currentbox.Amount = currentbox.Amount - 1;


                        if (currentbox.IsOld() == true)
                        {
                            if (Storage.NotSelling.Contains(currentbox) == false)
                            {
                                Storage.NotSelling.Add(currentbox);
                            }
                        }
                        else if (Storage.NotSelling.Contains(currentbox) == true)
                        {
                            Storage.NotSelling.Remove(currentbox);
                        }



                        if (currentbox.Amount <= Storage.MinBoxes)
                        {
                            if (Storage.LowInStock.Contains(currentbox) == false)
                                Storage.LowInStock.Add(currentbox);
                           
                        }
                       
                        return 1;
                    }

                }
            }
            return -1; // Box not found in any queue
        }
        //search for the next smallest box 
        public Box FindSmallestBiggerBox(Box box)
        {
            foreach (var currentbox in sortedBox)
            {
                Box topBox = currentbox;
                if (topBox != null)
                {
                    if (topBox.X >= box.X && topBox.Y >= box.Y)
                    {
                        /* Box temp = queue.Dequeue();
                         if (queue.TotalSize() <= Storage.MinBoxes && queue.TotalSize() > 0)
                         {
                             Console.WriteLine($"the box {temp.X} by {temp.Y} is almost finished");///////////////////
                         }
                         if (queue.TotalSize() == 0)
                         {
                             Console.WriteLine($"the box {temp.X} by {temp.Y} finished");///////////////////
                             sortedBox.Remove(queue);
                         }*/
                        return topBox;
                    }
                }
            }
            return null;
        }
        public Box FindSmallestBiggerBoxByPrecentage(Box box, double Precent)
        {
            foreach (var currentbox in sortedBox)
            {
                Box topBox = currentbox;

                if (topBox != null)
                {
                    if (topBox.X >= box.X && topBox.Y >= box.Y && topBox.Volume <= ((box.Volume / 100) * Precent) + box.Volume)
                    {
                        /* Box temp = queue.Dequeue();
                         if (queue.TotalSize() <= Storage.MinBoxes && queue.TotalSize() > 0)
                         {
                             Console.WriteLine($"the box {temp.X} by {temp.Y} is almost finished");///////////////////
                         }
                         if (queue.TotalSize() == 0)
                         {
                             Console.WriteLine($"the box {temp.X} by {temp.Y} finished");///////////////////
                             sortedBox.Remove(queue);
                         }*/
                        return topBox;
                    }
                }
            }
            return null;
        }
        public bool IsEmpty()
        {
            return sortedBox.Count == 0;
        }
        public int TotalSize()
        {
            int totalSize = 0;
            foreach (var currentbox in sortedBox)
            {
                totalSize++;
            }
            return totalSize;
        }
        public override string ToString()
        {
            string strings = "";
            foreach (Box currentbox in sortedBox)
            {
                strings += $"X:{currentbox.X} Y:{currentbox.Y} Amount:{currentbox.Amount}\n";
            }
            return strings;
        }
    }
}
