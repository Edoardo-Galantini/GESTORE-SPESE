using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GESTORE_SPESE.States;

namespace GESTORE_SPESE
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Creation of the StateContext object for the operation of the State Pattern
            StateContext ctx = new StateContext();

            // State update 
            ctx.UpdateState();
            ctx.UpdateState();
            ctx.UpdateState();
        }
    }
}
