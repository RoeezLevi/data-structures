namespace BoxDelivery.Classes
{
    public class StartApp
    {
        public static bool StartRun()
        {
            while (true)
            {
                try
                {

                    Storage.sortedBoxList = StorageActions.TurnDataListToSortedSet(LoadAndSave.GetItemList());                 
                    Storage.NeedToRestock = StorageActions.TurnDataListToBox(LoadAndSave.GetRestockList());
                    return true;
                }
                catch
                {
                    LoadAndSave.SaveItemsInFile(StorageActions.ConvretSetToList(Storage.sortedBoxList));
                    LoadAndSave.SaveLowInStockInFile(StorageActions.ConvretListBoxToString(Storage.LowInStock));
                    LoadAndSave.SaveRestockInFile(StorageActions.ConvretListBoxToString(Storage.NeedToRestock));
                    LoadAndSave.SaveAvailableInFile(StorageActions.ConvretListBoxToString(Storage.AvailabelInStock));
                    LoadAndSave.SaveAvailableInFile(StorageActions.ConvretListBoxToString(Storage.NotSelling));
                }

                  return false;
             
            }
        }
    }
}
