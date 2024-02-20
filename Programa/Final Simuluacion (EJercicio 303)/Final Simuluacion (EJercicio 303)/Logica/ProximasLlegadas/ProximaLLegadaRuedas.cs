using Final_Simuluacion__EJercicio_303_.Logica.Extras;
using Final_Simuluacion__EJercicio_303_.Logica.ProximasLlegadas;
using Final_Simuluacion__EJercicio_303_.Logica.Servidores;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simuluacion__EJercicio_303_.Logica.ProximasLlegadas
{
    public static class ProximaLlegadaRuedas
    {
        public static double tiempo;
        public static uint idUltimaBici = 0;
        public static double RND;
        
        public static double probabilidad; public static uint cantidad1;
        public static uint cantidad2;

        public static double relojProxLllegada = 0;
        public static uint ruedas = 0;
        public static bool showRND = true;

        public static void Reiniciar()
        {
            idUltimaBici = 0;
            relojProxLllegada = 0;
            ruedas = 0;
            showRND = true;
        }

        public static void Actualizar()
        {
            showRND = false;
        }

        public static void GenerarProxLlegada()
        { 
            relojProxLllegada += tiempo;
            CuantasRuedas();
            showRND = true;
            ProximaLlegada.NuevaLlegada();

        }

        public static void GenerarEntradaDeRuedas()
        {
            Evento.ruedas += ruedas;
            Evento.relojActual = relojProxLllegada;
            
            ColocadoresDeRuedas.AlertarLlegadaDeRuedas();
            Turnos.Contar();
            GenerarProxLlegada();
        }

        private static void CuantasRuedas() 
        {
            RND = General.ObtenerRND();
            if (RND < probabilidad ) { ruedas = cantidad1; } else{ ruedas = cantidad2; }
        }

        public static string[] ToArrayString()
        {
            string[] print = new string[3];
            if (showRND) { print[0] = RND.ToString(); print[1] = ruedas.ToString(); }
            else { print[0] = print[1] = "";  }
            
            print[2] = relojProxLllegada.ToString();
            return print;
        }

    }
        
}
