using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE.Database
{
    public class LocalDB
    {
        private readonly string DBPath;

        private static LocalDB instance;

        // Implementation of the singleton pattern
        public static LocalDB GetInstance(string dbFilePath)
        {
            if(instance == null)
            {
                instance = new LocalDB(dbFilePath);
            }
            return instance;
        }

        protected LocalDB(string datafile)
        {
            DBPath = datafile;
        }

        // Method that gets the data from json
        public List<Models.Item> GetData()
        {
            List<Item> items = null;
            try
            {
                // Parsing via library specific to Json format
                JArray jsonArray = JArray.Parse(File.ReadAllText(DBPath));
                items = jsonArray.ToObject<List<Item>>();
            }
            catch(Exception)
            {
                items = new List<Item>();
            }
            return items;
        }

        // Method that save data writing a json file
        public void SaveData(List<Models.Item> items)
        {
            JArray itemsArray = new JArray(
                items.Select(i => new JObject
                {
                    { "Name", i.Name },
                    { "Product", i.Product },
                    { "Price", i.Price },
                    { "Quantity", i.Quantity },
                    { "Category", i.Category },
                    { "Date", i.Date },
                })
            );
            File.WriteAllText(DBPath, itemsArray.ToString());
        }
    }
}
