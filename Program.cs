using System.Windows.Forms;
using BCOM = Bentley.Interop.MicroStationDGN;
using BM = Bentley.MicroStation;
using BMI = Bentley.MicroStation.InteropServices;

namespace eZBM
{
    /// <summary>
    /// MicroStation looks for this class that is
    /// derived from Bentley.MicroStation.AddIn.
    /// </summary>
    [BM.AddIn(MdlTaskID = "PowerCivilAddin1")]
    internal sealed class Program : BM.AddIn
    {
        public static Program MSAddin = null;
        public static BCOM.Application MSApp = null;

        /// <summary>
        /// Private constructor required for all AddIn classes derived from 
        /// Bentley.MicroStation.AddIn.
        /// </summary>
        private Program(System.IntPtr mdlDesc) : base(mdlDesc)
        {
            MSAddin = this;
        }

        /// <summary>
        /// Initializes the AddIn Called by the AddIn loader after
        /// it has created the instance of this AddIn class
        /// </remarks>
        /// <param name="commandLine"></param>
        /// <returns>0 on success</returns>
        protected override int Run(string[] commandLine)
        {
            MessageBox.Show(@"Hello World");

            MSApp = BMI.Utilities.ComApp;
            //  Register reload and unload events, and show the form
            ReloadEvent += new ReloadEventHandler(PowerCivilAddin1_ReloadEvent);
            UnloadedEvent += new UnloadedEventHandler(PowerCivilAddin1_UnloadedEvent);
            return 0;
        }

        /// <summary>
        /// Static property that the rest of the application uses 
        /// get the reference to the AddIn.
        /// </summary>
        internal static Program Addin
        {
            get { return MSAddin; }
        }

        /// <summary>
        /// Static property that the rest of the application uses to
        /// get the reference to the COM object model's main application object.
        /// </summary>
        internal static BCOM.Application ComApp
        {
            get { return MSApp; }
        }

        /// <summary>
        /// Handles MDL LOAD requests after the application has been loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void PowerCivilAddin1_ReloadEvent(BM.AddIn sender, ReloadEventArgs eventArgs)
        {
            //TODO: add specific handling For this Event here          
        }

        /// <summary>
        /// Handles MDL UNLOAD requests after the application has been unloaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void PowerCivilAddin1_UnloadedEvent(BM.AddIn sender, UnloadedEventArgs eventArgs)
        {
            //TODO: add specific handling For this Event here
        }

        /// <summary>
        /// Handles MDL ONUNLOAD requests when the application is being unloaded.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnUnloading(UnloadingEventArgs eventArgs)
        {
            base.OnUnloading(eventArgs);
        }
    }
}
