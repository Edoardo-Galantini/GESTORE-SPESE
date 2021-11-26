using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTORE_SPESE.States
{
    public class StateContext
    {
        public StateContext()
        {
            // It initializes with the with the first state 
            this.CurrentState = StateOne.Instance;
        }

        public IStates CurrentState { get; set; }

        // Method that calls the current state
        public void UpdateState()
        {
            CurrentState.UpdateState(this);
        }
    }
}
