using Final_Simuluacion__EJercicio_303_.Entidades;
using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simuluacion__EJercicio_303_.Logica.Servidores
{
    class ColocadorDeRueda2
    {
        public static bool atendiendo = false;

        public static double media;
        
        public static uint id;

        public static double RND;
        public static bool showRND = false;

        public static double tiempo;

        public static double relojFinTrabajo = 0;

        public static double tiempoOcioso = 0 , tiempoTrabajado =0, trabajosTerminados=0;
        public static bool Atendiendo { get => atendiendo; }

        public static double CalcularVelocidad() 
        {
            if (trabajosTerminados == 0) { return 0; }
            else 
            {
                return Math.Round( tiempoTrabajado / trabajosTerminados, 4);
            }
        }

        public static void Reiniciar()
        {
            atendiendo = false;
            relojFinTrabajo = 0;
            tiempoOcioso = 0; tiempoTrabajado = 0; trabajosTerminados = 0; 
            showRND = false;
        }

        public static void Actualizar()
        {
            showRND = false;
            CalcularTiempoOcioso();
        }

        private static void MostrarDatos() { showRND = true; }

        private static void CalcularTiempoOcioso()
        {
            if (!atendiendo)
            {
                double aux = Math.Truncate( (tiempoOcioso + Evento.TiempoTranscurrido()) * 1000) / 1000;
                
                tiempoOcioso = aux;
            }
        }

        public static void TerminarTrabajo()
        {
            atendiendo = false;

            trabajosTerminados++;
            tiempoTrabajado = Math.Round(tiempoTrabajado + tiempo, 4);

            Evento.relojActual = relojFinTrabajo;

            switch (InformarFinTrabajoYDevolverEstadoBici())
            {
                case 5:
                    ColocadoresDeRuedas.ReingresarBicicletaParaTerminar(2,id);
                    break;
                case 7:
                    Evento.idABorrar=id;
                    break;
                default:
                    break;
            }


        }
        private static short InformarFinTrabajoYDevolverEstadoBici()
        {
            Bicicleta bici = Bicicletas.ObtenerBicicleta(id);
            bici.RuedaColocada(); //Mandarlo a las ruedas
            return bici.Estado;
        }
        

        public static void ComenzarATrabajar(uint idBici)
        {
            Evento.ruedas--;
            atendiendo = true; //empieza a atender
           // Console.WriteLine(idBici);
            id = idBici;
            InformarComienzoTrabajo();
            ObtenerTiempos();
            UsarTiempo();
            MostrarDatos();
        }
                
        private static void InformarComienzoTrabajo()
        {
            Bicicletas.ObtenerBicicleta(id).ColocandoRueda();    //Cambio de estado de la bici
        }
        private static void UsarTiempo()
        {
            relojFinTrabajo = Evento.relojActual + tiempo;
        }
        private static void ObtenerTiempos()
        {
            RND = General.ObtenerRND();
            showRND = true;
            tiempo = Math.Round(- media * Math.Log(1 - RND), 4);
        }
        public static string[] ToArrayString()
        {
            string[] print = new string[5];
            if (atendiendo)
            {
                print[0] = id.ToString();
                if (showRND)
                {
                    print[1] = RND.ToString();
                    print[2] = tiempo.ToString();
                }
                else
                {
                    print[1] = print[2] = "";
                }
                print[3] = relojFinTrabajo.ToString();
            }
            else
            {
                print[0] = "Libre";
                print[1] = print[2] = print[3] = "";
            }
            print[4] = tiempoOcioso.ToString();
            return print;
        }

    }
}