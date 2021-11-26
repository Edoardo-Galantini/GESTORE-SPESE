using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTORE_SPESE.Calculations
{
    public interface IVisitorHost
    {
        // Method that accepts a Visitor 
        void Accept(IVisitor visitor);
    }
}
