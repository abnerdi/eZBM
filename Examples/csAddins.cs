using System.Windows.Forms;
using BCOM = Bentley.Interop.MicroStationDGN;
using BM = Bentley.MicroStation;
using BMI = Bentley.MicroStation.InteropServices;

namespace eZBM.Examples
{
    /// <summary>
    /// MicroStation looks for this class that is
    /// derived from Bentley.MicroStation.AddIn.
    /// </summary>
    /// <remarks>要使一个.NET 程序集能够作为Addins 在Mstn 下运行，需要满足如下三个条件：
    /// ①包含有一个派生于Bentley.MicroStation.Addin 的类；
    /// ②该派生类必须提供一个单参数(IntPtr 类型的MDL 描述符)的构造函数，且该构造函数需要链接到基类构造函数上；
    /// ③该派生类必须覆盖Addin 基类中的虚方法Run()。</remarks>
    [BM.AddIn(MdlTaskID = "csAddins")]
    internal sealed class csAddins : BM.AddIn
    {
        public static csAddins MSAddin = null;
        public static BCOM.Application MSApp = null;

        /// <summary>
        /// Private constructor required for all AddIn classes derived from 
        /// Bentley.MicroStation.AddIn.
        /// </summary>
        private csAddins(System.IntPtr mdlDesc) : base(mdlDesc)
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
            MessageBox.Show("进入");

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
        internal static csAddins Addin
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
