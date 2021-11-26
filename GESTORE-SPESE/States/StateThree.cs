using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTORE_SPESE.States
{
    class StateThree : IStates
    {
        // Each state can have only one instance so Singleton Pattern is used 
        private static readonly StateThree instance = new StateThree();

        private StateThree() { }

        public static StateThree Instance { get => instance; }

        public void UpdateState(StateContext ctx)
        {
            Application.EnableVisualStyles();

            // Creation of the Form
            Logout form3 = new Logout();
            Application.Run(form3);
        }
    }
}
