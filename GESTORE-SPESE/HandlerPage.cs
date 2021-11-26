using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTORE_SPESE.Database;
using GESTORE_SPESE.Extensions;
using GESTORE_SPESE.Calculations;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE
{
    public partial class HandlerPage : Form
    {
        private List<Item> items = new List<Item>();
        private readonly LocalDB db;
        private HandlerExtensions editor;
        private Dictionary<IVisitor, TextBox> visitors;

        public HandlerPage(LocalDB database)
        {
            InitializeComponent();

            InitializeCalulations();

            // Database instance using singleton pattern
            db = database;

            // object creation to which the features of the element are passed
            editor = new HandlerExtensions(txtName, txtProduct, txtPrice, txtQuantity, cbCategory, dtpDate.Value);
            LoadDB();
        }

        // Assign the default value to the auto-implemented property 
        internal HandlerExtensions HandlerExtensions
        {
            get => default;
            set { }
        }

        // Assign the default value to the auto-implemented property 
        public Item Item
        {
            get => default;
            set { }
        }

        // Method that initializes the calculations 
        private void InitializeCalulations()
        {
            visitors = new Dictionary<IVisitor, TextBox> {
                { new TotalSpending(), this.txtTotalValue },
                { new AvgSpending(), this.txtAvgValue },
                { new BalanceCalculation(), this.txtBalance}
            };
        }

        // Method that populates the listView
        private void LoadDB()
        {
            try
            {
                items = db.GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema nel caricamento dei dati dal Database!");
                Console.Error.WriteLine(ex.StackTrace);
                return;
            }

            // The listView is cleaned and updated 
            this.lstItems.Items.Clear();
            this.lstItems.Items.AddRange(items.Select(i => i.ToListViewItem()).ToArray());

            // The calculations are updated
            UpdateCalculations();
        }

        // Method that scrolls the dictionary with the various visitor inside 
        private void UpdateCalculations()
        {
            foreach (var pair in visitors)
            {
                var visitor = pair.Key;
                var textBox = pair.Value;
                visitor.Reset();

                items.ToList().ForEach(i => visitor.Visit(i));
                textBox.Text = visitor.Result.ToString();
            };
        }

        // Method to save data
        private void SaveDB()
        {
            db.SaveData(items);
        }

        // Check if fields have been filled in
        private bool CheckItemField()
        {
            return editor.CheckFields();
        }

        // Method to store the item
        private void MemorizeItem()
        {
            var item = new Item
            {
                Name = editor.Name,
                Product = editor.Product,
                Price = editor.Price,
                Quantity = editor.Quantity,
                Category = editor.Category,
                Date = editor.Date,
            };

            int index;
            if ((index = items.IndexOf(item)) >= 0)
            {
                items[index] = item;
            }
            else
            {
                items.Add(item);
            }

            // Save and load the storage
            SaveDB();
            LoadDB();
        }

        // Method to fill Item fields
        private void FillItemEditFields(Item item)
        {
            editor.FillFields(item);
        }

        // Method allowing reset of fields
        private void ResetItemEditFields()
        {
            editor.ResetFields();
        }

        // Price validation
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            editor.HandlePriceInput(e);
        }

        // Quantity validation
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            editor.HandleQuantityInput(e);
        }

        // Method for adding a new item
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckItemField())
            {
                MemorizeItem();
                ResetItemEditFields();
            }
            else
            {
                MessageBox.Show("I campi Nome, Prodotto, Prezzo e Quatità o alcuni di essi " +
                                "non sono stati inseriti!");
            }
        }

        // Method allowing deletion of the item
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler eliminare definitivamente l'elemento?",
                                "Cancella elemento",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ListViewItem listItem in this.lstItems.SelectedItems)
                {
                    this.items.Remove(listItem.ToItem());
                    break;
                }

                SaveDB();
                LoadDB();
            }
        }

        // Method that allows the edit of the Item
        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in this.lstItems.SelectedItems)
            {
                FillItemEditFields(listItem.ToItem());
                this.items.Remove(listItem.ToItem());
                break;
            }

            SaveDB();
            LoadDB();
        }

        // Method to close the Form 
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sei sicuro di voler effettuare il Log Out?",
                                "Log Out",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
