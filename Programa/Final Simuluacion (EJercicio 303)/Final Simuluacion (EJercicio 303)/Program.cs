using Final_Simuluacion__EJercicio_303_.Capa_de_presentacion;
using Final_Simuluacion__EJercicio_303_.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_
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
            Application.Run(new Iniciar());
        }
    }
}
