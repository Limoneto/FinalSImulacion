using Final_Simuluacion__EJercicio_303_.Logica;
using Final_Simuluacion__EJercicio_303_.Logica.Servidores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_.Entidades
{
    public class Bicicleta
    {
        public static uint idBicicletas = 0;
        public static double tiempoAcumuladoAtencion = 0;
        public double tiempoAtencion = 0;
        public uint id;
        private ushort ruedasColocadas = 0;
        private ushort ruedasColocandose = 0;
        private double relojEntrada =0 , relojSalida = 0;
        private short estado = 0;

        public short Estado { get => estado; }
        public Bicicleta()
        {
            idBicicletas++;
            relojEntrada = Evento.relojActual;
            this.id = idBicicletas;
        }
        public static void Reiniciar() 
        {
            idBicicletas = 0;
            tiempoAcumuladoAtencion = 0;
        }

        private string StringEstado()
        {
            switch (estado)
            {
                case 0:
                    return "EsperandoPintura";
                case 1:
                    return "SiendoPintada";
                case 2:
                    return "Esperando2Ruedas";
                case 3:
                    return "SiendoColocadaPrimeraRueda";
                case 4:
                    return "SiendoColocadas2Ruedas";
                /*
                 * Cuando terminan de colocar la primera rueda
                 */
                case 5:
                    return "EsperandoUltimaRueda";
                case 6:
                    return "SiendoColocadaUltimaRueda";
                case 7:
                    return "RuedasColocadas";
                default:
                    return "EstadoNoConocido";
            }
        }
        //Cambiar estado de la bi
        public void MandarAColaPintura() { estado = 0; }
        public void MandarAPintar() { estado = 1; }
        public void MandarAColaRueda() { estado = 2; }
        public void ColocandoRueda()
        {
            if (ruedasColocandose == 0)
            {
                estado = 3;
            }
            else 
            {
                if (ruedasColocadas == 0)
                {
                    estado = 4;
                }
                else 
                {
                    estado = 6;
                }
            }
            ruedasColocandose++;
        }
        public void RuedaColocada()
        {
            if (ruedasColocadas == 0)
            {
                if (ruedasColocandose == 1)
                {
                    estado = 5;
                }
                else
                {
                    estado = 6;
                }
            }
            else
            {
                estado = 7;
                
                ColocadoresDeRuedas.biciletasTerminadas++;
                relojSalida = Evento.relojActual;
                tiempoAtencion = relojSalida - relojEntrada;
                
                double aux = (Math.Truncate((Math.Truncate( (tiempoAcumuladoAtencion) * 1000) / 1000) + (Math.Truncate((tiempoAtencion) * 1000) / 1000))*10)/10;
                tiempoAcumuladoAtencion = aux;
               


            }
            
            ruedasColocadas++;
        }

        public static double PromedioAtencion() 
        {
            // Console.WriteLine("Tiempo-" + tiempoAcumuladoAtencion.ToString() + "Reloj-" + Evento.relojActual.ToString());
            if (ColocadoresDeRuedas.biciletasTerminadas == 0) { return 0; } else{ return Math.Round(tiempoAcumuladoAtencion / ColocadoresDeRuedas.biciletasTerminadas, 4); }
        }
        public string[] ToArrayString()
        {
            string[] print = new string[5];
            print[0] = id.ToString();
            print[1] = StringEstado();
            print[2] = relojEntrada.ToString();
            if (estado == 7) 
            { print[3] = relojSalida.ToString(); 
                print[4] = tiempoAtencion.ToString(); }
            else { print[3] = print[4] = ""; }

            return print;
        }
    } 
}
