using Final_Simuluacion__EJercicio_303_.Logica;
using Final_Simuluacion__EJercicio_303_.Logica.Extras;
using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using Final_Simuluacion__EJercicio_303_.Logica.Servidores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_.Capa_de_presentacion
{
    public partial class CapaPresentacion : Form
    {
        
        public int cantidadBicicletas = 1;
        public uint nroSim = 0;
        public int lastIndex = 0;
        
        public void MostarGrilla() 
        {
            tabControl.SelectedIndex = 0;
        }
        public void Reiniciar()
        {
            cantidadBicicletas = 1;
            dgvTablaBicicleteria.Rows.Clear();
            dgvTablaBicicletas.Rows.Clear();
            dgvTablaBicicletas.Columns.Clear();
            CargarTablaBicicletas();
            esRojo = false;
        }

        public bool MuestraBicis() 
        {
            return chkMostrarBicis.Checked;
        }

        public CapaPresentacion()
        {
            InitializeComponent();
            CargarTablaBicicleteria();
            CargarTablaBicicletas();

        }
        public void CargarTablaBicicleteria()
        {
            dgvTablaBicicleteria.EnableHeadersVisualStyles = false;
            
            dgvTablaBicicleteria.Columns.Add("NroSimulacion", "NroSimulacion");
            //dgvResultados.Columns[0].Width = 190;
            dgvTablaBicicleteria.Columns[0].HeaderCell.Style.BackColor = Color.DarkGreen;
            dgvTablaBicicleteria.Columns[0].DefaultCellStyle.BackColor = Color.LawnGreen;

            dgvTablaBicicleteria.Columns.Add("Evento", "Evento");
            //gvResultados.Columns[1].Width = 190;
            dgvTablaBicicleteria.Columns[1].HeaderCell.Style.BackColor = Color.DarkGreen;
            dgvTablaBicicleteria.Columns[1].DefaultCellStyle.BackColor = Color.LawnGreen;
            dgvTablaBicicleteria.Columns.Add("Reloj", "Reloj");
            dgvTablaBicicleteria.Columns[2].HeaderCell.Style.BackColor = Color.DarkGreen;
            dgvTablaBicicleteria.Columns[2].DefaultCellStyle.BackColor = Color.LawnGreen;

            dgvTablaBicicleteria.Columns.Add("ProxLlegadaBicicletasRND", "RNDBici");
            dgvTablaBicicleteria.Columns[3].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[3].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            dgvTablaBicicleteria.Columns.Add("ProxLlegadaBicicletasTiempo", "Tiempo");
            //dgvResultados.Columns[3].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns.Add("ProxLlegadaBicicletasReloj", "ProxLlegadaBici");
            dgvTablaBicicleteria.Columns[5].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[5].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            dgvTablaBicicleteria.Columns.Add("ProxLlegadaRuedasRND", "RNDRueda");
            dgvTablaBicicleteria.Columns[6].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[6].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("ProxLlegadaRuedasTiempo", "Ruedas");
            dgvTablaBicicleteria.Columns.Add("ProxLlegadaRuedasReloj", "ProxLlegadaRueda");
            dgvTablaBicicleteria.Columns[8].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[8].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            dgvTablaBicicleteria.Columns.Add("PinturaCola", "ColaPintura");
            dgvTablaBicicleteria.Columns.Add("PinturaColaMax", "ColaPinturaMax");
            dgvTablaBicicleteria.Columns[10].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[10].DefaultCellStyle.BackColor = Color.Cyan;
            dgvTablaBicicleteria.Columns.Add("PinturaId", "IdBiciPintandose");
            dgvTablaBicicleteria.Columns[11].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[11].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("PinturaRND1", "RNDPintura1");
            dgvTablaBicicleteria.Columns[12].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[12].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("PinturaRND2", "RNDPintura2");
            dgvTablaBicicleteria.Columns[13].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[13].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("PinturaTiempo", "Tiempo");
            dgvTablaBicicleteria.Columns.Add("PinturaReloj", "FinPintura");
            dgvTablaBicicleteria.Columns[15].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[15].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("PinturaTiempoOcioso", "TiempoOciosoPintor");
            dgvTablaBicicleteria.Columns[16].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[16].DefaultCellStyle.BackColor = Color.Cyan;

            dgvTablaBicicleteria.Columns.Add("ColocadoresCola", "ColaColocadores");
            dgvTablaBicicleteria.Columns.Add("ColocadoresColaMax", "ColaMaxColocadores");
            dgvTablaBicicleteria.Columns[18].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[18].DefaultCellStyle.BackColor = Color.Cyan;
            dgvTablaBicicleteria.Columns.Add("EventoRuedas", "RuedasExistentes");

            dgvTablaBicicleteria.Columns.Add("Colocador1Id", "IdBiciColocador1");
            dgvTablaBicicleteria.Columns[20].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[20].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("Colocador1RND", "RNDColocador1");
            dgvTablaBicicleteria.Columns[21].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[21].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("Colocador1Tiempo", "Tiempo");
            dgvTablaBicicleteria.Columns.Add("Colocador1Reloj", "FinColocacionRueda(1)");
            dgvTablaBicicleteria.Columns[23].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[23].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("Colocador1TiempoOcioso", "TiempoOciosoColocador1");
            dgvTablaBicicleteria.Columns[24].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[24].DefaultCellStyle.BackColor = Color.Cyan;

            dgvTablaBicicleteria.Columns.Add("Colocador2Id", "IdBiciColocador2");
            dgvTablaBicicleteria.Columns[25].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[25].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("Colocador2RND", "RNDColocador2");
            dgvTablaBicicleteria.Columns[26].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[26].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("Colocador2Tiempo", "Tiempo");
            dgvTablaBicicleteria.Columns.Add("Colocador2Reloj", "FinColocacionRueda(2)");
            dgvTablaBicicleteria.Columns[28].HeaderCell.Style.BackColor = Color.LightGray;
            dgvTablaBicicleteria.Columns[28].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgvTablaBicicleteria.Columns.Add("Colocador2TiempoOcioso", "TiempoOciosoColocador2");
            dgvTablaBicicleteria.Columns[29].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[29].DefaultCellStyle.BackColor = Color.Cyan;

            dgvTablaBicicleteria.Columns.Add("TurnoNro", "NroTurno");
            dgvTablaBicicleteria.Columns.Add("TurnoContadorBiciNoRueda", "CantHuboBiciYNoRuedaTurno");
            dgvTablaBicicleteria.Columns[31].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[31].DefaultCellStyle.BackColor = Color.Cyan;
            dgvTablaBicicleteria.Columns.Add("TurnoContadorRuedaNoBici", "CantHuboRuedaYNoBiciTurno");
            dgvTablaBicicleteria.Columns[32].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[32].DefaultCellStyle.BackColor = Color.Cyan;
            dgvTablaBicicleteria.Columns.Add("TurnoContadorTotal", "CantTotalTurno");
            dgvTablaBicicleteria.Columns[33].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[33].DefaultCellStyle.BackColor = Color.Cyan;
            dgvTablaBicicleteria.Columns.Add("TurnoAcumuladorTotal", "AcumuladorTotal");
            dgvTablaBicicleteria.Columns[34].HeaderCell.Style.BackColor = Color.DarkCyan;
            dgvTablaBicicleteria.Columns[34].DefaultCellStyle.BackColor = Color.Cyan;
        }
        public void CargarTablaBicicletas() 
        {
            dgvTablaBicicletas.EnableHeadersVisualStyles = false;
            dgvTablaBicicletas.Columns.Add("NroSim", "NroSim");
            dgvTablaBicicletas.Columns[0].HeaderCell.Style.BackColor = Color.DarkGreen;
            dgvTablaBicicletas.Columns[0].DefaultCellStyle.BackColor = Color.LawnGreen;
            dgvTablaBicicletas.Columns.Add("RelojSim", "Reloj");
            dgvTablaBicicletas.Columns[1].HeaderCell.Style.BackColor = Color.DarkGreen;
            dgvTablaBicicletas.Columns[1].DefaultCellStyle.BackColor = Color.LawnGreen;

            dgvTablaBicicletas.Columns.Add("CasillaBiciId-" + (dgvTablaBicicletas.Columns.Count).ToString(), "IdBicic");
            dgvTablaBicicletas.Columns.Add("CasillaBiciEstado" + (dgvTablaBicicletas.Columns.Count).ToString(), "EstadoBici");
            dgvTablaBicicletas.Columns.Add("CasillaBiciEntrada-" + (dgvTablaBicicletas.Columns.Count).ToString(), "RelojEntada");
            dgvTablaBicicletas.Columns.Add("CasillaBiciSalida-" + (dgvTablaBicicletas.Columns.Count).ToString(), "RelojSalida");
            dgvTablaBicicletas.Columns.Add("CasillaBiciTiempo-" + (dgvTablaBicicletas.Columns.Count).ToString(), "TiempoAtencion");
            dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 5].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 4].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 3].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 2].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 1].HeaderCell.Style.BackColor = Color.Chocolate;
            dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 5].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 4].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 3].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 2].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 1].DefaultCellStyle.BackColor = Color.SandyBrown;
        }
        public void IngresarUltimaFilaTablaBicicleteria(string[] fila) 
        {
            dgvTablaBicicleteria.Rows.Add(fila);
            dgvTablaBicicleteria.Rows[0].DefaultCellStyle.BackColor = Color.Khaki;
            dgvTablaBicicleteria.Rows[dgvTablaBicicleteria.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Goldenrod;
        }
        public void IngresarUltimaFilaTablaBicicletas()
        {
            dgvTablaBicicletas.Rows[0].DefaultCellStyle.BackColor = Color.Khaki;
        }
        public void IngresarFilaTablaBicicleteria(string[] fila)
        {
            dgvTablaBicicleteria.Rows.Add(fila); 
        }

        bool esRojo = false; 
        public void IngresarFilaTablaBicicletas(string[] fila)
        {
            //int  cantidadBicisNuevas = (int)(Bicicletas.CuantasBicisHay() - cantidadBicicletas);
            int bicisAtraer = (fila.Length - 2) / 5;
            int cantidadBicisNuevas = (int)(bicisAtraer) - cantidadBicicletas;
            try
            {
                if (cantidadBicisNuevas != 0)
                {
                    for (int j = 0; j < cantidadBicisNuevas; j++)
                    {

                        dgvTablaBicicletas.Columns.Add("CasillaBiciId-" + (dgvTablaBicicletas.Columns.Count).ToString(), "IdBicic");
                        dgvTablaBicicletas.Columns.Add("CasillaBiciEstado" + (dgvTablaBicicletas.Columns.Count).ToString(), "EstadoBici");
                        dgvTablaBicicletas.Columns.Add("CasillaBiciEntrada-" + (dgvTablaBicicletas.Columns.Count).ToString(), "RelojEntada");
                        dgvTablaBicicletas.Columns.Add("CasillaBiciSalida-" + (dgvTablaBicicletas.Columns.Count).ToString(), "RelojSalida");
                        dgvTablaBicicletas.Columns.Add("CasillaBiciTiempo-" + (dgvTablaBicicletas.Columns.Count).ToString(), "TiempoAtencion");
                        cantidadBicicletas++;

                        if (!esRojo)
                        {
                            esRojo = true;
                            dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 5].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 4].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 3].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 2].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 1].HeaderCell.Style.BackColor = Color.Crimson;
                            dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 5].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 4].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 3].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 2].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 1].DefaultCellStyle.BackColor = Color.IndianRed;
                        }
                        else
                        {
                            esRojo = false;
                            dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 5].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 4].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 3].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 2].HeaderCell.Style.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 1].HeaderCell.Style.BackColor = Color.Chocolate;
                            dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 5].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 4].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 3].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 2].DefaultCellStyle.BackColor = dgvTablaBicicletas.Columns[dgvTablaBicicletas.Columns.Count - 1].DefaultCellStyle.BackColor = Color.SandyBrown;
                        }
                    }
                }
                dgvTablaBicicletas.Rows.Add(fila);


            }

            catch (Exception e) 
            {
                
                string[] subfila = new string[dgvTablaBicicletas.Columns.Count];
                Array.Copy(fila, 0, subfila, 0, dgvTablaBicicletas.Columns.Count);
                

                dgvTablaBicicletas.Rows.Add(subfila);
                Simulacion.exceptionBicis = e;
                Simulacion.mataFuegosBicis = true;
            }

        }


        private void OnlyIntergers(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar.Equals('')) { e.Handled = false; }
            
            else
            {
                Console.WriteLine(e.KeyChar);
                e.Handled = true;
            }
        }
        private void OnlyDoubles(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = ((TextBox)sender);
            if (textbox.TextLength.Equals(0))
            {
                OnlyIntergers(sender, e);
            }
            else
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (e.KeyChar.Equals(','))
                {
                    bool pass = false;
                    foreach (char digit in textbox.Text)
                    {
                        if (digit.Equals(',')) { pass = true; }

                    }
                    e.Handled = pass;
                }
                else if (e.KeyChar.Equals('')) { e.Handled = false; }
                
                else
                {
                    e.Handled = true;
                }
            }


        }
        

        private void Iniciar()
        {
            if (btnGuardarCambios.Visible)
            {
                MessageBox.Show("Debe actualizar antes de simular");
            }
            else
            {
                if (txtCantidadSimulaciones.Text == "" || txtDesde.Text == "" || txtHasta.Text == "" || double.Parse(txtHasta.Text) == 0)
                {
                    MessageBox.Show("Debe completar los datos de la simulación, no se aceptan 0 en el tiempo final");
                }
                else
                {
                    if (!validarIntervalos())
                    {
                        MessageBox.Show("Intervalo desde-hasta no válido");
                    }
                    else
                    {
                        Simulacion.SimularConGuardadoParcial(int.Parse(txtCantidadSimulaciones.Text), double.Parse(txtHasta.Text), double.Parse(txtDesde.Text), double.Parse(txtProximaLlegadaBicicletasMedia.Text), 
                            double.Parse(txtProximaLlegadaRuedasTiempo.Text), uint.Parse(txtEventoRuedas.Text), double.Parse(txtProximaLlegadaRuedasProbababilidad1.Text),
                            uint.Parse(txtProximaLlegadaRuedasCantidad1.Text), uint.Parse(txtProximaLlegadaRuedasCantidad2.Text), double.Parse(txtPinturaMedia.Text), 
                            double.Parse(txtPinturaDesviacion.Text), double.Parse(txtPinturaMax.Text), double.Parse(txtPinturaMin.Text), double.Parse(txtColocador1Media.Text), double.Parse(txtColocador2Media.Text));
                        lblSimulacionTerminada.Visible = true;
                    }
                }
            }
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            lblSimulacionTerminada.Visible = false;
            Iniciar();

        }
        private void CambiarEstadosTextBox()
        {
            bool valor;
            if (!btnGuardarCambios.Visible) { valor = true; } else { valor = false; }

            txtProximaLlegadaBicicletasMedia.Enabled = valor;
            txtProximaLlegadaBicicletasDesviacion.Enabled = valor;
            txtProximaLlegadaRuedasTiempo.Enabled = valor;
            txtProximaLlegadaRuedasProbababilidad1.Enabled = valor;
            txtProximaLlegadaRuedasProbababilidad2.Enabled = valor;
            txtProximaLlegadaRuedasCantidad1.Enabled = valor;
            txtProximaLlegadaRuedasCantidad2.Enabled = valor;
            txtPinturaMedia.Enabled = valor;
            txtPinturaDesviacion.Enabled = valor;
            txtColocador1Media.Enabled = valor;
            txtColocador1Desviacion.Enabled = valor;
            txtColocador2Media.Enabled = valor;
            txtColocador2Desviacion.Enabled = valor;
            txtEventoRuedas.Enabled = valor;
            txtPinturaMax.Enabled =valor;
            txtPinturaMin.Enabled = valor;
            lastIndex = 0;
            btnGuardarCambios.Visible = valor;
            nroSim = 0;
            dgvDatosFinales.Rows.Clear();
        }

        private void cambios_CheckedChanged(object sender, EventArgs e)
        {
            CambiarEstadosTextBox();
        }

        private bool validarIntervalos()
        {
            bool resultado = true;
            double desde = double.Parse(txtDesde.Text);
            double hasta = double.Parse(txtHasta.Text);
            if ( desde >= hasta)
            {
                resultado = false;

            }
            return resultado;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                CambiarEstadosTextBox();
            }
        }

        private bool validarDatos()
        {
            bool resultado = true;
            string mensaje = ""; double n;


            if (!Double.TryParse(txtProximaLlegadaBicicletasMedia.Text, out n)) { mensaje += "\n---ProximaLLegadaBicicletas (Media): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaBicicletasMedia.Text) <= 0) { mensaje += "\n---ProximaLLegadaBicicletas (Media): valor no apto numéricamente"; }

            if (!Double.TryParse(txtProximaLlegadaBicicletasDesviacion.Text, out n)) { mensaje += "\n---ProximaLLegadaBicicletas (Desviacion): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaBicicletasDesviacion.Text) <= 0) { mensaje += "\n---ProximaLLegadaBicicletas (Desviacion): valor no apto numéricamente"; }

            if (!Double.TryParse(txtProximaLlegadaRuedasTiempo.Text, out n)) { mensaje += "\n---ProximaLLegadaRuedas (Tiempo): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaRuedasTiempo.Text) <= 0) { mensaje += "\n---ProximaLLegadaRuedas (Tiempo): valor no apto numéricamente"; }

            if (!Double.TryParse(txtProximaLlegadaRuedasProbababilidad1.Text, out n)) { mensaje += "\n---ProximaLLegadaRuedas (Probabilidad 1): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaRuedasProbababilidad1.Text) <= 0) { mensaje += "\n---ProximaLLegadaRuedas (Probabilidad 1): valor no apto numéricamente"; }

            if (!Double.TryParse(txtProximaLlegadaRuedasProbababilidad2.Text, out n)) { mensaje += "\n---ProximaLLegadaRuedas (Probabilidad 2): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaRuedasProbababilidad2.Text) <= 0) { mensaje += "\n---ProximaLLegadaRuedas (Probabilidad 2): valor no apto numéricamente"; }

            if (!Double.TryParse(txtProximaLlegadaRuedasCantidad1.Text, out n)) { mensaje += "\n---ProximaLLegadaRuedas (Cantidad 1): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaRuedasCantidad1.Text) < 0) { mensaje += "\n---ProximaLLegadaRuedas (Cantidad 1): valor no apto numéricamente"; }

            if (!Double.TryParse(txtProximaLlegadaRuedasCantidad2.Text, out n)) { mensaje += "\n---ProximaLLegadaRuedas (Cantidad 2): valor no numérico"; }
            else if (double.Parse(txtProximaLlegadaRuedasCantidad2.Text) < 0) { mensaje += "\n---ProximaLLegadaRuedas (Cantidad 2): valor no apto numéricamente"; }


            if (!Double.TryParse(txtPinturaMedia.Text, out n)) { mensaje += "\n---Pintura (Media): valor no numérico"; }
            else if (double.Parse(txtPinturaMedia.Text) <= 0) { mensaje += "\n---Pintura (Media): valor no apto numéricamente"; }
            if (!Double.TryParse(txtPinturaDesviacion.Text, out n)) { mensaje += "\n---Pintura (Desviacion): valor no numérico"; }
            else if (double.Parse(txtPinturaDesviacion.Text) <= 0) { mensaje += "\n---Pintura (Desviacion): valor no apto numéricamente"; }
            if (!Double.TryParse(txtPinturaMax.Text, out n)) { mensaje += "\n---Pintura (Máximo): valor no numérico"; }
            else if (double.Parse(txtPinturaMax.Text) <= 0) { mensaje += "\n---Pintura (Máximo): valor no apto numéricamente"; }
            else
            {
                if (Double.TryParse(txtPinturaMedia.Text, out n))
                {
                    if (double.Parse(txtPinturaMax.Text) <= double.Parse(txtPinturaMedia.Text)) { mensaje += "\n---Pintura (Máximo): valor no apto numéricamente"; }
                }
            }
            if (!Double.TryParse(txtPinturaMin.Text, out n)) { mensaje += "\n---Pintura (Mínimo): valor no numérico"; }
            else if (double.Parse(txtPinturaMin.Text) <= 0) { mensaje += "\n---Pintura (Mínimo): valor no apto numéricamente"; }
            else 
            {
                if (Double.TryParse(txtPinturaMedia.Text, out n)) 
                { 
                    if (double.Parse(txtPinturaMin.Text) >= double.Parse(txtPinturaMedia.Text)) 
                    { mensaje += "\n---Pintura (Mínimo): valor no apto numéricamente"; } 
                }
            }

            if (!Double.TryParse(txtEventoRuedas.Text, out n)) { mensaje += "\n---Ruedas iniciales: valor no numérico"; }
            else if (double.Parse(txtEventoRuedas.Text) < 0) { mensaje += "\n---Ruedas iniciales: valor no apto numéricamente"; }

            if (!Double.TryParse(txtColocador1Media.Text, out n)) { mensaje += "\n---Colocador 1 (Media): valor no numérico"; }
            else if (double.Parse(txtColocador1Media.Text) <= 0) { mensaje += "\n---Colocador 1 (Media): valor no apto numéricamente"; }
            if (!Double.TryParse(txtColocador1Desviacion.Text, out n)) { mensaje += "\n---Colocador 1 (Desviacion): valor no numérico"; }
            else if (double.Parse(txtColocador1Desviacion.Text) <= 0) { mensaje += "\n---Colocador 1  (Desviacion): valor no apto numéricamente"; }

            if (!Double.TryParse(txtColocador2Media.Text, out n)) { mensaje += "\n---Colocador 2 (Media): valor no numérico"; }
            else if (double.Parse(txtColocador2Media.Text) <= 0) { mensaje += "\n---Colocador 2 (Media): valor no apto numéricamente"; }
            if (!Double.TryParse(txtColocador2Desviacion.Text, out n)) { mensaje += "\n---Colocador 2 (Desviacion): valor no numérico"; }
            else if (double.Parse(txtColocador2Desviacion.Text) <= 0) { mensaje += "\n---Colocador 2 (Desviacion 2): valor no apto numéricamente"; }
            


            if (!mensaje.Equals("")) { MessageBox.Show("Los siguientes parametros cargados son erroneos:\n" + mensaje, "Error"); resultado = false; }

            return resultado;
        }

        private void txtProximaLlegadaBicicletasMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la desviacion
            try { txtProximaLlegadaBicicletasDesviacion.Text = (1 / Convert.ToDouble(txtProximaLlegadaBicicletasMedia.Text)).ToString(); }
            catch (Exception) { }
        }

        private void txtProximaLlegadaBicicletasDesviacion_KeyPress(object sender, KeyPressEventArgs e)
        {         
            OnlyDoubles(sender, e);
            //Actualizar la Media
            try { txtProximaLlegadaBicicletasMedia.Text = (1 / Convert.ToDouble(txtProximaLlegadaBicicletasDesviacion.Text)).ToString(); }
            catch (Exception) { }
        }

        private void txtProximaLlegadaRuedasTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);

        }

        private void txtPinturaMedia_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
        }

        private void txtPinturaDesviacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
        }

        private void txtColocador1Media_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la desviacion
            try { txtColocador1Desviacion.Text = (1 / Convert.ToDouble(txtColocador1Media.Text)).ToString(); }
            catch (Exception) { }

        }

        private void txtColocador1Desviacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la Media
            try { txtColocador1Media.Text = (1 / Convert.ToDouble(txtColocador1Desviacion.Text)).ToString(); }
            catch (Exception) { }

        }

        private void txtColocador2Media_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la desviacion
            try { txtColocador2Desviacion.Text = (1 / Convert.ToDouble(txtColocador2Media.Text)).ToString(); }
            catch (Exception) { }
        }

        private void txtColocador2Desviacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la Media
            try { txtColocador2Media.Text = (1 / Convert.ToDouble(txtColocador2Desviacion.Text)).ToString(); }
            catch (Exception) { }
        }

        private void txtProximaLlegadaRuedasProbababilidad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la probabilidad dependiente
            try { txtProximaLlegadaRuedasProbababilidad2.Text = (100 - Convert.ToDouble(txtProximaLlegadaRuedasProbababilidad1.Text)).ToString(); }
            catch (Exception) { }
        }

        private void txtProximaLlegadaRuedasProbababilidad2_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
            //Actualizar la probabilidad dependiente
            try { txtProximaLlegadaRuedasProbababilidad1.Text = (100 - Convert.ToDouble(txtProximaLlegadaRuedasProbababilidad2.Text)).ToString(); }
            catch (Exception) { }
        }

        private void txtProximaLlegadaRuedasCantidad1_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyIntergers(sender, e);
        }

        private void txtProximaLlegadaRuedasCantidad2_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyIntergers(sender, e);
        }

        private void txtCantidadSimulaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyIntergers(sender, e);

        }

        private void txtDesde_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyIntergers(sender, e);

        }

        private void txtHasta_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
        }

        private void txtEventoRuedas_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
        }

        private void txtPinturaMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
        }

        private void txtPinturaMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDoubles(sender, e);
        }
                
        private void chkcambios_CheckedChanged(object sender, EventArgs e)
        {
            CambiarEstadosTextBox();
        }

        public void CargarDatosFinales(int numeroTurno, int ruedasNoBici, int bicisNoRuedas , int acumuladorTotalRuedasBicis, int colaMaxPintura , 
            double tiempoOciosoPintor, double tiempoPromedioPintor, int colaMaxRuedas, double tiempoOciosoColocador1, double velocidadPromedioColocador1, double tiempoOciosoColocador2,
            double velocidadPromedioColocador2, uint bicicletasTerminadas, double promedioTiempoAtencion, long tiempoSimulacion , uint nroSimulaciones) 
        {
            nroSim++;
            object[] fila = new object[17];
            fila[0] = nroSim; fila[1] = numeroTurno; fila[2] = ruedasNoBici; fila[3] = bicisNoRuedas; fila[4] = acumuladorTotalRuedasBicis; fila[5] = colaMaxPintura; fila[6] = tiempoOciosoPintor; fila[7] = tiempoPromedioPintor; fila[8] = colaMaxRuedas; 
            fila[9] = tiempoOciosoColocador1; fila[10] = velocidadPromedioColocador1; fila[11] = tiempoOciosoColocador2; fila[12] = velocidadPromedioColocador2; fila[13] = bicicletasTerminadas;
            if (bicicletasTerminadas == 0) { fila[14] = "No calculable"; }
            else { fila[14] = promedioTiempoAtencion; }
            fila[15] = tiempoSimulacion; fila[16] = nroSimulaciones;
            dgvDatosFinales.Rows.Add(fila);
            CargarFilaEnTextBoxes(fila, dgvDatosFinales.Rows.Count-1);
        }

        public void CargarFilaEnTextBoxes(object[] fila, int index) 
        {
            int numeral, denominador; double division;

            /*fila[0] = nroSim*/; txtTurnos.Text = fila[1].ToString(); 
            txtRuedasNoBicis.Text = fila[2].ToString() ;  
            txtBicisNoRuedas.Text = fila[3].ToString() ;  
            txtAcumuladorTotal.Text = fila[4].ToString();
            denominador = (int)((object)fila[1]);

            if (denominador == 0) { division = 0; txtPromedioRuedaNoBici.Text = division.ToString(); txtPromedioBiciNoRueda.Text = division.ToString(); txtPromedioTotal.Text = division.ToString(); }
            else 
            { 
                numeral = (int)((object)fila[2]);
                division = numeral / denominador; 
                txtPromedioRuedaNoBici.Text = division.ToString();
                numeral = (int)((object)fila[3]);
                division = numeral / denominador;
                txtPromedioBiciNoRueda.Text = division.ToString();
                numeral = (int)((object)fila[4]);
                division = numeral / denominador;
                txtPromedioTotal.Text = division.ToString();
            }
            
            

            txtColaMaxPintar.Text = fila[5].ToString(); txtTiempoOciosoPintor.Text = fila[6].ToString(); txtVelocidadPintor.Text = fila[7].ToString(); 
            txtColaMaxRueda.Text = fila[8].ToString();  txtTiempoOciosoColocador1.Text = fila[9].ToString(); txtVelocidadColocador1.Text = fila[10].ToString();
            txtTiempoOciosoColocador2.Text = fila[11].ToString(); txtVelocidadColocador2.Text = fila[12].ToString(); 
            txtCantidadBicis.Text = fila[13].ToString(); txtTiempoAtencion.Text = fila[14].ToString();
            TimeSpan t = TimeSpan.FromMilliseconds((long)fila[15]);
            string tiempoString = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
            txtTiempoSimulacion.Text = tiempoString;
            txtNroSimulaciones.Text = fila[16].ToString();

            dgvDatosFinales.Rows[lastIndex].DefaultCellStyle.BackColor = Color.White;
            dgvDatosFinales.Rows[index].DefaultCellStyle.BackColor = Color.Coral;
            lastIndex = index;
            
        }

        private void dgvDatosFinales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            object[] fila = new object[17];
            if (e.RowIndex >= 0)
            {
                fila[0] = dgvDatosFinales.Rows[e.RowIndex].Cells[0].Value;
                fila[1] = dgvDatosFinales.Rows[e.RowIndex].Cells[1].Value;
                fila[2] = dgvDatosFinales.Rows[e.RowIndex].Cells[2].Value;
                fila[3] = dgvDatosFinales.Rows[e.RowIndex].Cells[3].Value;
                fila[4] = dgvDatosFinales.Rows[e.RowIndex].Cells[4].Value;
                fila[5] = dgvDatosFinales.Rows[e.RowIndex].Cells[5].Value;
                fila[6] = dgvDatosFinales.Rows[e.RowIndex].Cells[6].Value;
                fila[7] = dgvDatosFinales.Rows[e.RowIndex].Cells[7].Value;
                fila[8] = dgvDatosFinales.Rows[e.RowIndex].Cells[8].Value;
                fila[9] = dgvDatosFinales.Rows[e.RowIndex].Cells[9].Value;
                fila[10] = dgvDatosFinales.Rows[e.RowIndex].Cells[10].Value;
                fila[11] = dgvDatosFinales.Rows[e.RowIndex].Cells[11].Value;
                fila[12] = dgvDatosFinales.Rows[e.RowIndex].Cells[12].Value;
                fila[13] = dgvDatosFinales.Rows[e.RowIndex].Cells[13].Value;
                fila[14] = dgvDatosFinales.Rows[e.RowIndex].Cells[14].Value;
                fila[15] = dgvDatosFinales.Rows[e.RowIndex].Cells[15].Value;
                fila[16] = dgvDatosFinales.Rows[e.RowIndex].Cells[16].Value;
                CargarFilaEnTextBoxes(fila, e.RowIndex);
            }
        }

        private void CapaPresentacion_Load(object sender, EventArgs e)
        {
            #region DobleBuffered DataGridViews
            this.SuspendLayout();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvTablaBicicleteria, new object[] { true });
            this.ResumeLayout();

            this.SuspendLayout();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvTablaBicicletas, new object[] { true });
            this.ResumeLayout();

            this.SuspendLayout();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvDatosFinales, new object[] { true });
            this.ResumeLayout();
            #endregion
        }

        
    }
}
