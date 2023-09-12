using System;
using System.Collections.Generic;

namespace BoxDelivery.Classes
{
    public class Storage
    {
        public static int MaxBoxes = 15;
        public static int MinBoxes = 5;
        /*BinaryTree<BoxQueue<Box>> storage = new BinaryTree<BoxQueue<Box>>();*/
        public static SortedSetOfBox sortedBoxList = new SortedSetOfBox();

        public static List<Box> LowInStock = new List<Box>();
        public static List<Box> NeedToRestock = new List<Box>();
        public static List<Box> AvailabelInStock = new List<Box>();
        public static List<Box> NotSelling = new List<Box>();
        /* public static List<string> StorageDataFile = new List<string>();*/


        // Create a sorted set using the custom comparer
        /* public static string AddBox(Box box)
         {
             sortedBoxList.Enqueue(box);
            return sortedBoxList.ToString();
         }
         public static string RemoveBox(Box box)
         {
             sortedBoxList.DequeueBox(box);
             return sortedBoxList.ToString();
         }*/
        /*public static void ShowStorage(SortedSetOfBox sortedBoxList)
        {
            foreach (var queue in sortedBoxList) 
            {
               
            
        }*/
    }
}
