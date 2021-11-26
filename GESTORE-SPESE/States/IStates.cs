using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTORE_SPESE.States
{
    public interface IStates
    {
        // Method that allows to go to the next state 
        void UpdateState(StateContext ctx);
    }
}
