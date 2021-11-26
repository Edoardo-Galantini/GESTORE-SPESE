using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE.Calculations
{
    class TotalSpending : IVisitor
    {
        private float value = 0;

        // implementation of the IVisitor interface 
        public float Result => value; 

        public void Reset() => value = 0;

        // Total calculation
        public void Visit(Item item) => value += item.Price * item.Quantity;
    }
}
