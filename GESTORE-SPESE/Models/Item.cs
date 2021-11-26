using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTORE_SPESE.Calculations;

namespace GESTORE_SPESE.Models
{
    // Item inherits the accept method for the operation of the Visitor Pattern
    public class Item : IVisitorHost
    {
        //  Item Fields 
        public string Name { get; set; }
        public string Product { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }

        // Two Items with the same product are treated as one 
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return base.Equals(obj);
            }

            var other = obj as Item;

            return string.Compare(Identifier(this),
                Identifier(other)) == 0;

        }

        public override int GetHashCode() { return 0; }

        private string Identifier(Item item)
        {
            return item.Product;  
        }

        // Implementation of the Accept method that invokes the corresponding Visit method for the object
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
