using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using Final_Simuluacion__EJercicio_303_.Logica.Servidores;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simuluacion__EJercicio_303_.Logica.Extras
{
    public static class Turnos
    {
        public static int numeroTurno = 1;
        public static double tiempomax = 480; // 480 = 8 * 60 
        public static int acumuladorTotal = 0;
        public static int contadorBiciNoRueda = 0; 
        public static int contadorRuedaNoBici = 0;
        public static int contadorTotal = 0;
        public static int acumuladorcontadorRuedaNoBici = 0;
        public static int acumuladorcontadorBiciNoRueda = 0;

        public static void Reiniciar()
        {
            numeroTurno = 1;
            tiempomax = 480;

            contadorBiciNoRueda = 0;
            contadorRuedaNoBici = 0;
            contadorTotal = 0;

            acumuladorcontadorRuedaNoBici = 0;
            acumuladorcontadorBiciNoRueda = 0;
            acumuladorTotal = 0;

        }
        public static void Actualizar() 
        {
            if (Evento.relojActual >= tiempomax) { NuevoTurno(); }
            
        }
        private static void ActualizarTiempoMax() 
        {
            tiempomax = (numeroTurno + 1) * 480;
        }
        public static void Contar()
        {
            bool ruedas = Evento.HayRuedas() , bicisEsperandoRuedas = ColocadoresDeRuedas.HayBicicletas();
            if ( ruedas && !bicisEsperandoRuedas){ acumuladorTotal++; acumuladorcontadorRuedaNoBici++; contadorRuedaNoBici++; contadorTotal++; }
            else if (bicisEsperandoRuedas && !ruedas) { acumuladorTotal++; acumuladorcontadorBiciNoRueda++; contadorBiciNoRueda++; contadorTotal++;}
        }
        private static void NuevoTurno()
        {
            ActualizarTiempoMax();
            numeroTurno++;
            contadorBiciNoRueda = 0;
            contadorRuedaNoBici = 0;
            contadorTotal = 0;

        }

        public static string[] ToArrayStringTurno() 
        {
            string[] print = new string [4];
            print[0] = numeroTurno.ToString();
            print[1] = contadorBiciNoRueda.ToString();
            print[2] = contadorRuedaNoBici.ToString();
            print[3] = contadorTotal.ToString();
            return print;
        }

        public static string[] ToArrayString()
        {
            string[] print = new string[5];

            print[0] = numeroTurno.ToString();
            print[1] = contadorBiciNoRueda.ToString();
            print[2] = contadorRuedaNoBici.ToString();
            print[3] = contadorTotal.ToString();
            print[4] = acumuladorTotal.ToString();
           // print[5] = Math.Round((double) ((double) acumuladorTotal / (double) numeroTurno), 4).ToString();

            return print;
        }
    }
}/*public static List<uint> contadorBiciNoRueda = new List<uint>(); 
        public static List<uint> contadorRuedaNoBici = new List<uint>();
        public static List<uint> contadorTotal = new List<uint>();

        public static void Actualizar() 
        {
            if (Evento.relojActual > tiempomax) { NuevoTurno(); }
            
        }
        private static void ActualizarTiempoMax() 
        {
            tiempomax = (numeroTurno + 1) * 480;
        }
        public static void Contar()
        {
            int indice = contadorBiciNoRueda.Count-1;
            if (Evento.HayRuedas() && !Bicicletas.HayBicis()){ acumuladorTotal++; contadorRuedaNoBici[indice]++; contadorTotal[indice]++; }
            else if (Bicicletas.HayBicis() && !Evento.HayRuedas()) { acumuladorTotal++; contadorBiciNoRueda[indice]++; contadorTotal[indice]++;}
        }
        private static void NuevoTurno()
        {
            numeroTurno++;
            ActualizarTiempoMax();
            ActualizarContadores();
            
        }
        private static void ActualizarContadores()
        {
            contadorBiciNoRueda.Remove(0);
            contadorBiciNoRueda.Add(0);
            contadorRuedaNoBici.Remove(0);
            contadorRuedaNoBici.Add(0);
            contadorTotal.Remove(0);
            contadorTotal.Add(0);
        }

        public static string[] ToArrayStringTurno() 
        {
            string[] print = new string [4];
            print[0] = numeroTurno.ToString();
            print[1] = contadorBiciNoRueda.Last().ToString();
            print[2] = contadorRuedaNoBici.Last().ToString();
            print[3] = contadorTotal.Last().ToString();
            return print;
        }

        public static string[] ToArrayString()
        {
            string[] print = new string[5];

            print[0] = numeroTurno.ToString();
            print[1] = contadorBiciNoRueda.Last().ToString();
            print[2] = contadorRuedaNoBici.Last().ToString();
            print[3] = contadorTotal.Last().ToString();
            print[4] = acumuladorTotal.ToString();
           // print[5] = Math.Round((double) ((double) acumuladorTotal / (double) numeroTurno), 4).ToString();

            return print;
        }
    }*/
