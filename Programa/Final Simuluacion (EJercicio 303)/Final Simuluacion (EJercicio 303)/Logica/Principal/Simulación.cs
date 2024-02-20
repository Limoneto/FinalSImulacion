using Final_Simuluacion__EJercicio_303_.Capa_de_presentacion;
using Final_Simuluacion__EJercicio_303_.Entidades;
using Final_Simuluacion__EJercicio_303_.Logica.Extras;
using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using Final_Simuluacion__EJercicio_303_.Logica.ProximasLlegadas;
using Final_Simuluacion__EJercicio_303_.Logica.Servidores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_.Logica
{
    class Simulacion
    {
        public static double tiempo;
        public static double desde;

        public static int cantidad;

        public static System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

        public static bool  mataFuegosBicis = false;

        public static CapaPresentacion capa;

        public static void SetCapa(ref CapaPresentacion capaRef) 
        {
            capa = capaRef;
        }

       // public static Resultados capa;

        public static bool yaSIMULO=false;

        public static uint nroSimulacion = 0 ;
        public static uint nroAMostrar = 0;

        public static Exception exceptionBicis;

        //public static double reloj;

        public static void ReiniciarClasesSiEsNecesario() 
        {
            if (yaSIMULO) 
            {
                nroSimulacion = 0;
                nroAMostrar = 0;
                Bicicleta.Reiniciar();
                Turnos.Reiniciar();
                Bicicletas.Reiniciar();
                Evento.Reiniciar();
                ProximaLlegada.Reiniciar();
                ColocadoresDeRuedas.Reiniciar();
                Pintura.Reiniciar();
                capa.Reiniciar();
                mataFuegosBicis = false;
                exceptionBicis = null;
            }
        }
        private static void CargarCampos(int cantidadIteraciones, double tiempoSimulacion, double desdeSimulacion, double ProxLlegadaBicicletaMedia, double ProxLlegadaRuedasTiempo, uint EventoRuedas, double ProxLlegadaRuedasProbabilidad1, uint ProxLlegadaRuedasCantidad1, uint ProxLlegadaRuedasCantidad2, double PinturaMedia, double PinturaDesviacion, double PinturaMax, double PinturaMin, double ColocadorRueda1Media, double ColocadorRueda2Media)
        {
            tiempo = tiempoSimulacion ;
            desde = desdeSimulacion;
            cantidad = cantidadIteraciones;
            ReiniciarClasesSiEsNecesario();
            ProximaLlegadaBicicleta.media = ProxLlegadaBicicletaMedia;
            ProximaLlegadaRuedas.tiempo = ProxLlegadaRuedasTiempo;
            Evento.ruedas = EventoRuedas;
            ProximaLlegadaRuedas.probabilidad = ProxLlegadaRuedasProbabilidad1 / 100;
            ProximaLlegadaRuedas.cantidad1 = ProxLlegadaRuedasCantidad1;
            ProximaLlegadaRuedas.cantidad2 = ProxLlegadaRuedasCantidad2;
            Pintura.media = PinturaMedia;
            Pintura.desviacion = PinturaDesviacion;
            Pintura.max = PinturaMax;
            Pintura.min = PinturaMin;
            ColocadorDeRueda1.media = ColocadorRueda1Media;
            ColocadorDeRueda2.media = ColocadorRueda2Media;
            yaSIMULO = true;
        }
      
        public static void SimularConGuardadoParcial(int cantidadIteraciones,double tiempoSimulacion, double desdeSimulacion,  double ProxLlegadaBicicletaMedia , double ProxLlegadaRuedasTiempo , uint EventoRuedas , double ProxLlegadaRuedasProbabilidad1 , uint ProxLlegadaRuedasCantidad1, uint ProxLlegadaRuedasCantidad2, double PinturaMedia , double PinturaDesviacion, double PinturaMax, double PinturaMin, double ColocadorRueda1Media, double ColocadorRueda2Media)
        {
            CargarCampos(cantidadIteraciones, tiempoSimulacion, desdeSimulacion, ProxLlegadaBicicletaMedia, ProxLlegadaRuedasTiempo, EventoRuedas, ProxLlegadaRuedasProbabilidad1, 
                ProxLlegadaRuedasCantidad1, ProxLlegadaRuedasCantidad2, PinturaMedia, PinturaDesviacion, PinturaMax, PinturaMin, ColocadorRueda1Media, ColocadorRueda2Media);
            if (capa.MuestraBicis())
            {
                SimulacionConGuardadoParcial();
            }
            else 
            {
                SimulacionConGuardadoParcialSinBicis();
            }
        }

        private static void SimulacionConGuardadoParcialSinBicis() 
        {
            GenerarInicioSimulacionConGuardadoParcialSinBicis();
            for (nroSimulacion = 1; Evento.relojActual < tiempo; nroSimulacion++)
            {
                GuardarFilaConGuardadoParcialSinBicis();
                Evento.ProximoEvento();
                
            }
            GenerarFinSimulacionConGuardadoParcialSinBicis();
        }

        private static void GenerarInicioSimulacionConGuardadoParcialSinBicis()
        {
            watch = System.Diagnostics.Stopwatch.StartNew();
            Evento.GenerarInicioSimulacion();
            capa.IngresarFilaTablaBicicleteria(Evento.ToArrayString());
            Evento.ProximoEvento();

        }
        private static void GenerarFinSimulacionConGuardadoParcialSinBicis()
        {
            watch.Stop();
            capa.IngresarUltimaFilaTablaBicicleteria(Evento.GenerarFinSimulacion());
            PasarDatosFinales();
        }

        private static void GuardarFilaConGuardadoParcialSinBicis()
        {
            if (nroAMostrar <= cantidad && Evento.relojActual >= desde)
            {
                nroAMostrar++;
                capa.IngresarFilaTablaBicicleteria(Evento.ToArrayString());
            }
            if (Evento.nrotipoAnterior == 6) { Bicicletas.QuitarBicicleta(Evento.idABorrar); }

        }
        private static void SimulacionConGuardadoParcial()
        {
            GenerarInicioSimulacionConGuardadoParcial();
            for (nroSimulacion = 1; Evento.relojActual <= tiempo; nroSimulacion++)
            {
                GuardarFilaConGuardadoParcial();
                Evento.ProximoEvento();
                
                
            }
            GenerarFinSimulacionConGuardadoParcial();
            
            
        }

        private static void GenerarInicioSimulacionConGuardadoParcial()
        {
            watch = System.Diagnostics.Stopwatch.StartNew();
            
            
            Evento.GenerarInicioSimulacion();
            capa.IngresarFilaTablaBicicleteria(Evento.ToArrayString());
            capa.IngresarFilaTablaBicicletas(Bicicletas.ToArrayString());
            Evento.ProximoEvento();
        }
        private static void GenerarFinSimulacionConGuardadoParcial()
        {
            watch.Stop();
            
            capa.IngresarUltimaFilaTablaBicicleteria(Evento.GenerarFinSimulacion());
            capa.IngresarUltimaFilaTablaBicicletas();
            PasarDatosFinales();

            if (mataFuegosBicis) 
            {
                MessageBox.Show(exceptionBicis.Message + "\n\n\nLa cantidad de bicis a mostrar excedia los limites de la tabla", "Demaciadas Bicis para Mosrtrar");
            }
        }

        private static void GuardarFilaConGuardadoParcial()
        {
            if (nroAMostrar < cantidad && Evento.relojActual >= desde)
            {
                nroAMostrar++;
                capa.IngresarFilaTablaBicicleteria(Evento.ToArrayString());
                if (!mataFuegosBicis)
                {
                    capa.IngresarFilaTablaBicicletas(Bicicletas.ToArrayString());
                }
            }
            if (Evento.nrotipoAnterior == 6) { Bicicletas.QuitarBicicleta(Evento.idABorrar); }

        }

        private static void PasarDatosFinales() 
        {
            //long elapsedMs = watch.ElapsedMilliseconds;
            
            capa.CargarDatosFinales(Turnos.numeroTurno, Turnos.acumuladorcontadorRuedaNoBici, Turnos.acumuladorcontadorBiciNoRueda, Turnos.acumuladorTotal, Pintura.cantidadColaMax,
            Pintura.tiempoOcioso, Pintura.CalcularVelocidad(), ColocadoresDeRuedas.cantidadColaMax, ColocadorDeRueda1.tiempoOcioso, ColocadorDeRueda1.CalcularVelocidad(), ColocadorDeRueda2.tiempoOcioso,
            ColocadorDeRueda2.CalcularVelocidad(), ColocadoresDeRuedas.biciletasTerminadas, Bicicleta.PromedioAtencion(), watch.ElapsedMilliseconds,nroSimulacion-1);
        }
    }
}
