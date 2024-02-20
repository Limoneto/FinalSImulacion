using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Simuluacion__EJercicio_303_.Logica.Extras;
using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using Final_Simuluacion__EJercicio_303_.Logica.ProximasLlegadas;
using Final_Simuluacion__EJercicio_303_.Logica.Servidores;

namespace Final_Simuluacion__EJercicio_303_.Logica
{
    public static class Evento
    {

        private static short nroTipo = 1;
        public static double relojActual = 0;
        public static double relojAnterior = 0;
        public static uint ruedas;
        public static uint idABorrar = 0;
        public static short nrotipoAnterior;
        

        public static int NroTipo { get => nroTipo; }
       

        public static List<uint> bicisParaBorrar = new List<uint>();

        public static void Reiniciar()
        {
            nroTipo = 1;
            relojActual = 0;
            relojAnterior = 0;
        }
        private static void Actualizar()
        {
            ProximaLlegadaRuedas.Actualizar();
            ProximaLlegadaBicicleta.Actualizar();
            Pintura.Actualizar();
            ColocadorDeRueda1.Actualizar();
            ColocadorDeRueda2.Actualizar();
            Turnos.Actualizar();
            
        }
        public static bool HayRuedas() { return (ruedas != 0); }
        private static string generarNombre()
        {
            switch (nroTipo)
            {
                case 1:
                    return "Inicio_simulacion";
                    
                case 2:
                    return "llegada_bicilceta";
                    
                case 3:
                    return "llegada_ruedas";
                    
                case 4:
                    return "fin_atencion_pintura";
                    
                case 5:
                    return "fin_colocacion_rueda";
                    
                case 6:
                    return "fin_atencion_bicicleta";
                    
                default:
                    return "EstadoNoConocido";
                    
            }

        }

        private static void SaberProxEvento()
        {
            double proxReloj = ProximaLlegada.relojProxLLegada;
            //Llegada
            if (Pintura.atendiendo)
            {
                if (proxReloj <= Pintura.relojFinTrabajo)
                {
                    if (ColocadoresDeRuedas.atendiendo)
                    {
                        if (proxReloj <= ColocadoresDeRuedas.ProxRelojFin())
                        {
                            nroTipo = ProximaLlegada.IdProx;
                        }
                        else
                        {
                            nroTipo = ColocadoresDeRuedas.EsFinDeAtencion();
                        }
                    }
                    else
                    {
                        nroTipo = ProximaLlegada.IdProx;
                    }
                }
                else
                {
                    proxReloj = Pintura.relojFinTrabajo;
                    if (ColocadoresDeRuedas.atendiendo)
                    {
                        if (proxReloj <= ColocadoresDeRuedas.ProxRelojFin())
                        {
                            nroTipo = 4;
                        }
                        else
                        {
                            nroTipo = ColocadoresDeRuedas.EsFinDeAtencion();
                        }
                    }
                    else 
                    {
                        nroTipo = 4;
                    }
                }
            }
            else
            {
                if (ColocadoresDeRuedas.atendiendo)
                {
                    if (proxReloj <= ColocadoresDeRuedas.ProxRelojFin())
                    {
                        nroTipo = ProximaLlegada.IdProx;
                    }
                    else
                    {
                        nroTipo = ColocadoresDeRuedas.EsFinDeAtencion();
                    }
                }
                else 
                {
                    nroTipo = ProximaLlegada.IdProx;
                }
            }
        }

        public static void ProximoEvento()
        {
            Actualizar();
            relojAnterior = relojActual;
            SaberProxEvento();
            nrotipoAnterior = nroTipo;
            switch (nroTipo)
            {
                case 1:
                    GenerarInicioSimulacion();
                    break;
                case 2:
                    GenerarLlegadaBicicleta();
                    break;
                case 3:
                    GenerarLlegadaRuedas();
                    break;
                case 4:
                    GenerarFinAtencionPintura();
                    break;
                case 5:
                    GenerarFinColocacionRueda();
                    break;
                case 6:
                    GenerarFinColocacionRueda();
                    break;
                default:
                    Console.WriteLine(nroTipo);
                    throw new Exception();
            }
            
        }
        public static void GenerarInicioSimulacion()
        {
            //Turnos.contadorBiciNoRueda.Add(0);
            //Turnos.contadorRuedaNoBici.Add(0);
            //Turnos.contadorTotal.Add(0);
            ProximaLlegadaRuedas.GenerarProxLlegada();
            ProximaLlegadaBicicleta.GenerarProxLlegada();
        }

        public static void GenerarLlegadaBicicleta()
        {
            ProximaLlegadaBicicleta.LlegadaBicileta();
           
        }

        public static void GenerarLlegadaRuedas()
        {
            ProximaLlegadaRuedas.GenerarEntradaDeRuedas();
        }

        public static void GenerarFinAtencionPintura()
        {
            Pintura.TerminarTrabajo();
        }
        public static void GenerarFinColocacionRueda()
        {
            ColocadoresDeRuedas.TerminarTrabajo();
        }
        public static double TiempoTranscurrido()
        {
            return relojActual - relojAnterior;
        }

        
        public static void MandarABorrarBici(uint id)
        {
            bicisParaBorrar.Add(id);
        }

        public static string[] ToArrayString()
        {
            /*
            string[] printEvento, printProximaLlegadaBicicleta, printProximaLlegadaRuedas, printPintura, printColocadoresDeRuedas, printTurnos, printBicicletas;

            printProximaLlegadaBicicleta = ProximaLlegadaBicicleta.ToArrayString();//.CopyTo(printArray,3);
            printProximaLlegadaRuedas = ProximaLlegadaRuedas.ToArrayString();//.CopyTo(printArray, 6);
            printPintura = Pintura.ToArrayString();//.CopyTo(printArray, 9);
            printColocadoresDeRuedas = ColocadoresDeRuedas.ToArrayString();//.CopyTo(printArray, 16);
            printTurnos = Turnos.ToArrayString();//.CopyTo(printArray, 26);
            printBicicletas = Bicicletas.ToArrayString();
            
            
            printEvento = new string[3 + printProximaLlegadaBicicleta.Length + printProximaLlegadaRuedas.Length + printPintura.Length + printColocadoresDeRuedas.Length + printTurnos.Length + printBicicletas.Length] ;

            printEvento[0] = (Simulacion.nroSimulacion.ToString());
            printEvento[1] = (generarNombre());
            printEvento[2] = (relojActual.ToString());

            printProximaLlegadaBicicleta.CopyTo(printEvento, 3);
            printProximaLlegadaRuedas.CopyTo(printEvento, printProximaLlegadaBicicleta.Length);
            printPintura.CopyTo(printEvento, printProximaLlegadaRuedas.Length);
            printColocadoresDeRuedas.CopyTo(printEvento, printPintura.Length);
            printTurnos.CopyTo(printEvento, printColocadoresDeRuedas.Length);
            printBicicletas.CopyTo(printEvento, printTurnos.Length);
            */
            
            string[] printEvento = new string[ 35  ]; // 1 + 2 + 3 + 3 + 8 + 13 + 5 = 34
            printEvento[0] = (Simulacion.nroSimulacion.ToString());
            printEvento[1] = (generarNombre());
            printEvento[2] = (relojActual.ToString());
            ProximaLlegadaBicicleta.ToArrayString().CopyTo(printEvento , 3);
            ProximaLlegadaRuedas.ToArrayString().CopyTo(printEvento, 6);
            Pintura.ToArrayString().CopyTo(printEvento, 9);
            ColocadoresDeRuedas.ToArrayString().CopyTo(printEvento, 17);
            Turnos.ToArrayString().CopyTo(printEvento, 30);
           
            

            return printEvento;
        }

        public static string[] GenerarFinSimulacion()
        {
            string[] printEvento = Enumerable.Repeat<string>("", 35 ).ToArray(); // 1 + 2 + 3 + 3 + 8 + 13 + 5 = 34

            printEvento[0] = (Simulacion.nroSimulacion-1).ToString();
            printEvento[1] = "FinSimulacion";
            printEvento[2] = relojAnterior.ToString();
            printEvento[10] = Pintura.cantidadColaMax.ToString();
            printEvento[16] = Pintura.tiempoOcioso.ToString();
            printEvento[18] = ColocadoresDeRuedas.cantidadColaMax.ToString();
            printEvento[24] = ColocadorDeRueda1.tiempoOcioso.ToString();
            printEvento[29] = ColocadorDeRueda2.tiempoOcioso.ToString();
            Turnos.ToArrayString().CopyTo(printEvento, 30);


            return printEvento;
        }
    }
}
