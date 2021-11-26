using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTORE_SPESE.Calculations
{
    public interface IVisitor
    {
        // Exposes a property
        float Result { get; }

        // Method that takes an Item as a parameter
        void Visit(Models.Item item);

        // Method to reset visitor status
        void Reset();
    }
}
