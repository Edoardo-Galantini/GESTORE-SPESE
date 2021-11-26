using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE.Extensions
{
    public static class ItemExtensions
    {
        // From Item to ListViewItem
        public static ListViewItem ToListViewItem(this Item item)
        {
            string[] row = { item.Name, item.Product, item.Price.ToString(), item.Quantity.ToString(), item.Category, item.Date.ToString("d") };
            return new ListViewItem(row);

        }

        // From ListViewItem to Item
        public static Item ToItem(this ListViewItem item)
        {
            return new Item
            {
                Name = item.SubItems[0].Text,
                Product = item.SubItems[1].Text,
                Price = float.Parse(item.SubItems[2].Text),
                Quantity = int.Parse(item.SubItems[3].Text),
                Category = item.SubItems[4].Text,
                Date = DateTime.Parse(item.SubItems[5].Text),
            };
        }
    }
}
