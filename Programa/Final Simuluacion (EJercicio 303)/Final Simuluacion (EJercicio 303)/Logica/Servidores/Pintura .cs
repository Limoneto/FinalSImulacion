using Final_Simuluacion__EJercicio_303_.Entidades;
using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_.Logica.Servidores
{
    public static class Pintura
    {
        public static double media;
        
        public static double desviacion;
        
        public static double max;
        public static double min;

        public static List<uint> cola = new List<uint>();
        //public static uint cola = 0;

        public static bool atendiendo = false;

        public static uint id;
       // public static bool showId;
 
        public static double RND1;
        public static double RND2;
        public static bool showRND = false;

        public static double tiempo1;
        public static double tiempo2;
        public static short tiempoAUsar = 0;

        public static double trabajosTerminados = 0, tiempoTrabajado = 0;

        public static double relojFinTrabajo = 0;

        public static int cantidadColaMax = 0;
        public static double tiempoOcioso = 0;

        public static void Reiniciar()
        {
            showRND = false;
            cola = new List<uint>();
            atendiendo = false;
            tiempoAUsar = 0;
            relojFinTrabajo = 0;
            cantidadColaMax = 0;
            tiempoOcioso = 0;
            trabajosTerminados = 0;
            tiempoTrabajado = 0;

        }
        public static void Actualizar() 
        {
            showRND = false;
            CalcularTiempoOcioso();
        }

        public static double ProxRelojFin()
        {
            if (atendiendo) { return relojFinTrabajo; }
            else { return -1; }
        }

        public static double CalcularVelocidad()
        {
            if (trabajosTerminados == 0) { return 0; }
            else
            {
                return Math.Round(tiempoTrabajado / trabajosTerminados, 4);
            }
        }

        private static void MostrarDatos() { showRND = true; }
        public static void IngresaBicicleta(uint id)
        {
            cola.Add(id);
            OrdenarBicileta(); 
        }
        private static void OrdenarBicileta() 
        {
            if (atendiendo) { ActualizarMax(); }
            else { ComenzarATrabajar(); }
        }
        private static void ActualizarMax()
        {
            if (cola.Count > cantidadColaMax) { cantidadColaMax = cola.Count; }
        }
        private static void CalcularTiempoOcioso()
        {
            if (!atendiendo)
            {
                double aux = Math.Truncate((tiempoOcioso + Evento.TiempoTranscurrido()) * 1000) / 1000;

                tiempoOcioso = aux;
            }
        }

        private static bool HayBicicletas() 
        {
            if (cola.Count > 0) { return true; }
            return false;
        }
        public static void TerminarTrabajo()
        {
            atendiendo = false;
            trabajosTerminados++;
            if (tiempoAUsar == 1) { tiempoTrabajado = Math.Round( tiempo1 + tiempoTrabajado , 4); }
            else { tiempoTrabajado = Math.Round(tiempo2 + tiempoTrabajado, 4); }

            InformarFinTrabajo();

            Evento.relojActual = relojFinTrabajo;

            ColocadoresDeRuedas.IngresaBicicleta(id);
            
            BuscarBiciEnCola();

        
        }
        private static void BuscarBiciEnCola() 
        {
            if (cola.Count > 0) { ComenzarATrabajar(); }
        }
        private static void InformarFinTrabajo()
        {
            Bicicletas.ObtenerBicicleta(id).MandarAColaRueda(); //Mandarlo a las ruedas
        }
        private static void ComenzarATrabajar()
        {
            atendiendo = true; //empieza a atender
            id = cola[0];   cola.RemoveAt(0);
            InformarComienzoTrabajo();
            UsarTiempo();
            MostrarDatos(); 
        }
        private static void InformarComienzoTrabajo() 
        {
            Bicicletas.ObtenerBicicleta(id).MandarAPintar();    //Cambio de estado de la bici
        }
        private static void UsarTiempo()
        {
            if (tiempoAUsar == 0) { ObtenerTiempos(); UsarTiempo(); }
            else if (tiempoAUsar == 2) { tiempoAUsar--; relojFinTrabajo = Evento.relojActual + tiempo1; }
            else { tiempoAUsar--; 
                relojFinTrabajo = Evento.relojActual + tiempo2;
            } //tiempoAUsar == 1
        }
        private static void ObtenerTiempos()
        {
            RND1 = General.ObtenerRND();
            RND2 = General.ObtenerRND();
            tiempoAUsar = 2;
            GenerarTiemposNormal();
        }
        public static void GenerarTiemposNormal()
        {
            // double x = (Math.Sqrt(-2 * (Math.Log(RND1))) * (Math.Cos(2 * (Math.PI) * RND2))) * desviacion + media;
            tiempo1 = Math.Round( ( (Math.Sqrt(-2 * (Math.Log(RND1))) * (Math.Cos(2 * (Math.PI) * RND2))) * desviacion + media ) , 4);
            //tiempo1= (Math.Truncate(x * 10000) / 10000);
            if (tiempo1 < 0) { tiempo1 *= (-1); }
            if (tiempo1 <= min) { ObtenerTiempos(); }
            if (tiempo1 >= max) { ObtenerTiempos(); }
            //x = (Math.Sqrt(-2 * (Math.Log(RND1))) * (Math.Sin(2 * (Math.PI) * RND2))) * desviacion + media;
            //tiempo2 = (Math.Truncate(x * 10000) / 10000);
            tiempo2 = Math.Round( ((Math.Sqrt(-2 * (Math.Log(RND1))) * (Math.Sin(2 * (Math.PI) * RND2))) * desviacion + media) , 4);
            if (tiempo2 < 0) { tiempo2 *= (-1); }
            if (tiempo2 <= min) { ObtenerTiempos(); }
            if (tiempo2 >= max) { ObtenerTiempos(); }
        }

        public static string[] ToArrayString()
        {
            string[] print = new string[8];
            print[0] = cola.Count.ToString();
            print[1] = cantidadColaMax.ToString();
            if (atendiendo)
            {
                print[2] = id.ToString();
                if (showRND)
                {
                    print[3] = RND1.ToString();
                    print[4] = RND2.ToString();
                    if (tiempoAUsar == 1) { print[5] = tiempo1.ToString(); }
                    else { print[5] = tiempo2.ToString(); }
                }
                else
                {
                    print[3] = print[4] = print[5] = "";
                }
                print[6] = relojFinTrabajo.ToString();
            }
            else 
            {
                print[2] = "Libre";
                print[3] = print[4] = print[5] = print[6] = "";
            }
            print[7] = tiempoOcioso.ToString();
            
            return print;
        }

    }
}
