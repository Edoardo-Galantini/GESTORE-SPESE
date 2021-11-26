using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESTORE_SPESE.States
{
    class StateOne : IStates
    {
        // Each state can have only one instance so Singleton Pattern is used 
        private static readonly StateOne instance = new StateOne();

        private StateOne() { }

        public static StateOne Instance { get => instance; }

        public void UpdateState(StateContext ctx)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creation of the Form
            Login login = new Login();
            Application.Run(login);

            // Release of the resources used by the form 
            login.Dispose();

            // The status is updated 
            ctx.CurrentState = StateTwo.Instance;
        }
    }
}
