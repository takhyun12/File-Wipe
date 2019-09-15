using System;
using System.Windows.Forms;
using System.Threading;

namespace File_Wipe_1._0
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isNew = true;
            Mutex mutex = new Mutex(true, "File_Wipe_1.0", out isNew);
            if (isNew == false)
            {
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
                mutex.ReleaseMutex();
            }
        }
    }
}
