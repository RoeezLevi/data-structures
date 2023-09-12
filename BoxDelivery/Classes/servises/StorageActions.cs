using System;
using System.Collections.Generic;

namespace BoxDelivery.Classes
{
    public class StorageActions : Storage
    {
        /*        public static string AddBox(Box box)
                {
                    sortedBoxList.Enqueue(box);
                    return sortedBoxList.ToString();
                }*/
        /* public static string RemoveBox(Box box)
         {
             if (sortedBoxList.DequeueBox(box) == -1)
             {
                 if (sortedBoxList.FindSmallestBiggerBox(box) != null)
                     return sortedBoxList.FindSmallestBiggerBox(box).ToString();
             }
             return sortedBoxList.ToString();
         }*/
        /*public static Box RemoveNextGoodBox(Box box)
        {

        }*/
        public static List<string> ConvretSetToList(SortedSetOfBox sortedBoxList)
        {
            List<string> list = new List<string>();
            foreach (Box currentbox in sortedBoxList.GetsortedBox)
            {
                list.Add($"{currentbox.ToString()},{currentbox.Amount}");//|              
            }
            return list;
        }
        public static SortedSetOfBox TurnDataListToSortedSet(List<string> list)
        {
            SortedSetOfBox sortedBox = new SortedSetOfBox();
            /*BoxQueue<Box> queue = new BoxQueue<Box>();*/
            /*string[] boxes = list.ToString().Split('|');*/
            for (int i = 0; i < list.Count; i++)
            {
                string[] info = list[i].Split(',');
                Box box = new Box(double.Parse(info[0]), double.Parse(info[1]), int.Parse(info[3]), DateTime.Parse(info[2]));
                for (int j = 0; j < int.Parse(info[3]); j++)
                    sortedBox.Enqueue(box);

                /*for (int k = 0; k < int.Parse(info[3]); k++)
                {                   
                }*/
            }
            return sortedBox;
        }
        public static List<string> ConvretListBoxToString(List<Box> list)
        {
            /* BoxQueue<Box> temp = new BoxQueue<Box>();*/
            List<string> templist = new List<string>();
            foreach (Box currentbox in list)
            {
                templist.Add($"{currentbox.ToString()},{currentbox.Amount}");//|                                  
            }
            return templist;
        }
        public static List<Box> TurnDataListToBox(List<string> list)
        {
            
            List<Box> boxlst = new List<Box>();
           
            /*string[] boxes = list.ToString().Split('|');*/
            for (int i = 0; i < list.Count; i++)
            {
                string[] info = list[i].Split(',');
                Box box = new Box(double.Parse(info[0]), double.Parse(info[1]), int.Parse(info[3]), DateTime.Parse(info[2]));
                boxlst.Add(box);
                /*for (int k = 0; k < int.Parse(info[3]); k++)
                {               }*/
            }
            /* while (index < list.Count)
             {
                 BoxQueue<Box> boxQueue = new BoxQueue<Box>();
                 bool val = true;
                 while (val == true)
                 {
                     if (boxlst[index].CompareTo(boxlst[index + 1]) != 0 || boxlst[index + 1] == null)
                     {
                         val = false;
                     }
                     boxQueue.Enqueue(boxlst[index]);
                 }
                 temp.Add(boxQueue);
             }*/
            return boxlst;
        }
        public static void Exit()
        {
            LoadAndSave.SaveItemsInFile(StorageActions.ConvretSetToList(Storage.sortedBoxList));
            LoadAndSave.SaveLowInStockInFile(StorageActions.ConvretListBoxToString(Storage.LowInStock));
            LoadAndSave.SaveRestockInFile(StorageActions.ConvretListBoxToString(Storage.NeedToRestock));
            LoadAndSave.SaveAvailableInFile(StorageActions.ConvretListBoxToString(Storage.AvailabelInStock));
            LoadAndSave.SaveAvailableInFile(StorageActions.ConvretListBoxToString(Storage.NotSelling));
        }
    }
}
