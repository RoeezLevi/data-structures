using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxDelivery.Classes
{
    internal class LoadAndSave
    {
        static string ItemsPath = "Storage.json";
        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public static void SaveItemsInFile(List<string> list)
        {
            string content = JsonConvert.SerializeObject(list, settings);
            File.WriteAllText(ItemsPath, content);
        }
        public static List<string> GetItemList()
        {
            string Datafromfile = File.ReadAllText(ItemsPath);
            object list = JsonConvert.DeserializeObject(Datafromfile, settings);
            List<string> mylist = list as List<string>;
            return mylist;
        }
        static string RestockPath = "Restock.json";
        public static void SaveRestockInFile(List<string> list)
        {
            string content = JsonConvert.SerializeObject(list, settings);
            File.WriteAllText(RestockPath, content);
        }
        public static List<string> GetRestockList()
        {
            string Datafromfile = File.ReadAllText(RestockPath);
            object list = JsonConvert.DeserializeObject(Datafromfile, settings);
            List<string> mylist = list as List<string>;
            return mylist;
        }
        static string AvailablePath = "Available.json";
        public static void SaveAvailableInFile(List<string> list)
        {
            string content = JsonConvert.SerializeObject(list, settings);
            File.WriteAllText(AvailablePath, content);
        }
        public static List<string> GetAvailableList()
        {
            string Datafromfile = File.ReadAllText(AvailablePath);
            object list = JsonConvert.DeserializeObject(Datafromfile, settings);
            List<string> mylist = list as List<string>;
            return mylist;
        }
        static string LowInStockPath = "LowInStock.json";
        public static void SaveLowInStockInFile(List<string> list)
        {
            string content = JsonConvert.SerializeObject(list, settings);
            File.WriteAllText(LowInStockPath, content);
        }
        public static List<string> GetLowInStockList()
        {
            string Datafromfile = File.ReadAllText(LowInStockPath);
            object list = JsonConvert.DeserializeObject(Datafromfile, settings);
            List<string> mylist = list as List<string>;
            return mylist;
        }
        static string NotSellingPath = "NotSelling.json";
        public static void SaveNotSellingInFile(List<string> list)
        {
            string content = JsonConvert.SerializeObject(list, settings);
            File.WriteAllText(NotSellingPath, content);
        }
        public static List<string> GetNotSellingList()
        {
            string Datafromfile = File.ReadAllText(NotSellingPath);
            object list = JsonConvert.DeserializeObject(Datafromfile, settings);
            List<string> mylist = list as List<string>;
            return mylist;
        }
    }
}
