using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE.Calculations
{
    class BalanceCalculation : IVisitor
    {
        private float res = 0;
        private float value = 0;
        private float balance = 10000;

        // implementation of the IVisitor interface 
        public float Result => res;

        public void Reset()
        {
            res = 0;
            value = 0;
        }

        public void Visit(Item item)
        {
            // Balance calculation
            value += item.Price * item.Quantity;
            res = balance - value;
        }
    }
}
