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

namespace Final_Simuluacion__EJercicio_303_.Logica.ProximasLlegadas { 
    public static class ProximaLlegadaBicicleta
    {
        public static double RND; 
        public static double media;
        public static double relojProxLllegada=0;
        public static double tiempoProxLllegada = 0;
        public static bool showRND=true;

        public static void Reiniciar() 
        {
            relojProxLllegada = 0;
            tiempoProxLllegada = 0;
            showRND = true;
        }
        public static void Actualizar()
        {
           showRND = false; 
        }

        public static void GenerarProxLlegada() 
        {
            RND = General.ObtenerRND();
            showRND = true;
            //RNDString = false;
            tiempoProxLllegada = Math.Round(- media * Math.Log(1 - RND),4);
            relojProxLllegada = Evento.relojActual + tiempoProxLllegada;
            
            ProximaLlegada.NuevaLlegada();
        }

        private static void MostarDatos() { }
        public static void LlegadaBicileta()
        {
            Evento.relojActual = relojProxLllegada;
            Bicicleta bicicEntrante = new Bicicleta();
            Bicicletas.AgregaBicicleta(bicicEntrante);
            
            Pintura.IngresaBicicleta(bicicEntrante.id);
            //Turnos.Contar();
            GenerarProxLlegada();
        }
        public static string[] ToArrayString()
        {
            string[] print = new string[3];
            if (showRND) { print[0] = RND.ToString(); print[1] = tiempoProxLllegada.ToString(); }
            else { print[0] = ""; print[1] = ""; }           
            print[2] = relojProxLllegada.ToString();
            return print;
        }

    }
}
