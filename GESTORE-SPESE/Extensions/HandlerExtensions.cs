using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE.Extensions
{
    class HandlerExtensions
    {
        private TextBox txtName;
        private TextBox txtProduct;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private ComboBox cbCategory;
        private DateTime lblDate;

        public string Name { get => txtName.Text; }
        public string Product { get => txtProduct.Text; }
        public float Price { get => float.Parse(txtPrice.Text); }
        public int Quantity { get => int.Parse(txtQuantity.Text); }
        public string Category { get => cbCategory.Text; }
        public DateTime Date { get => lblDate; }

        public HandlerExtensions(TextBox txtName, TextBox txtProduct, TextBox txtPrice, TextBox txtQuantity, ComboBox cbCategory, DateTime lblDate)
        {
            this.txtName = txtName;
            this.txtProduct = txtProduct;
            this.txtPrice = txtPrice;
            this.txtQuantity = txtQuantity;
            this.cbCategory = cbCategory;
            this.lblDate = lblDate;
        }

        // Reset
        internal void ResetFields()
        {
            txtName.Text = "";
            txtProduct.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            cbCategory.Text = "";
        }

        // Fill in the fields 
        internal void FillFields(Item item)
        {
            txtName.Text = item.Name;
            txtProduct.Text = item.Product;
            txtPrice.Text = item.Price.ToString();
            txtQuantity.Text = item.Quantity.ToString();
            cbCategory.Text = item.Category;
            lblDate = item.Date;
        }

        // Input validation
        internal void HandlePriceInput(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == ',');
        }

        // Input validation
        internal void HandleQuantityInput(KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        // Check that the fields are filled in 
        internal bool CheckFields()
        {
            return !string.IsNullOrEmpty(txtName.Text)
                && !string.IsNullOrEmpty(txtProduct.Text)
                && !string.IsNullOrEmpty(txtPrice.Text)
                && !string.IsNullOrEmpty(txtQuantity.Text);
        }
    }
}
