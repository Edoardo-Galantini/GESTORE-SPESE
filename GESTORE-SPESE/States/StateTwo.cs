using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GESTORE_SPESE.States
{
    class StateTwo : IStates
    {
        // Each state can have only one instance so Singleton Pattern is used 
        private static readonly StateTwo instance = new StateTwo();

        private StateTwo() { }

        public static StateTwo Instance { get => instance; }

        public void UpdateState(StateContext ctx)
        {
            Application.EnableVisualStyles();

            // Creation of the Form
            // The database address is specified to the form 
            HandlerPage handlerPage = new HandlerPage(Database.LocalDB.GetInstance(@"fileDB.txt"));
            Application.Run(handlerPage);

            // Release of the resources used by the form 
            handlerPage.Dispose();

            // The status is updated
            ctx.CurrentState = StateThree.Instance;
        }
    }
}
