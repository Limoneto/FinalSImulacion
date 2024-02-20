using Final_Simuluacion__EJercicio_303_.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_.Capa_de_presentacion
{
    public partial class Iniciar : Form
    {
        public Iniciar()
        {
            InitializeComponent();
        }

        private void btnInicar_Click(object sender, EventArgs e)
        {
            CapaPresentacion capa = new CapaPresentacion();
            Simulacion.SetCapa(ref capa);
            this.Hide();
            capa.ShowDialog();
            MessageBox.Show("Gracias por su atencion!!!"+"\n\n"+"Cordialmente se despide Juan Manuel Casella");
            this.Close();
        }
    }
}
