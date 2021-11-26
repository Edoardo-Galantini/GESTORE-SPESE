using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GESTORE_SPESE.Models;

namespace GESTORE_SPESE.Calculations
{
    class AvgSpending : IVisitor
    {
        private List<float> values = new List<float>();

        // implementation of the IVisitor interface 
        public float Result
        {
            // Avarange calculation
            get => values.Count > 0 ? values.Average() : 0;
        }

        public void Reset() => values.Clear();

        public void Visit(Item item) => values.Add(item.Price);
    }
}
