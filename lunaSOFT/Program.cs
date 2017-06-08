using System;
using System.Windows.Forms;
using lunaSOFT.FrontEnd.Login;
using lunaSOFT.FrontEnd;

namespace lunaSOFT
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmRegistrarPedido());
        }
    }
}
