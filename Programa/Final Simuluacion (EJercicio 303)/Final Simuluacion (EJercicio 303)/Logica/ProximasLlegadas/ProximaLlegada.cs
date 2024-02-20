using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simuluacion__EJercicio_303_.Logica.ProximasLlegadas
{
    public static class ProximaLlegada
    {
        public static short IdProx = 0;
        public static double relojProxLLegada = 0;

        public static void Reiniciar()
        {
            IdProx = 0;
            relojProxLLegada = 0;
            ProximaLlegadaBicicleta.Reiniciar();
            ProximaLlegadaRuedas.Reiniciar();
        }

        public static void NuevaLlegada() 
        {
            if (ProximaLlegadaBicicleta.relojProxLllegada <= ProximaLlegadaRuedas.relojProxLllegada) 
            {
                IdProx = 2; relojProxLLegada = ProximaLlegadaBicicleta.relojProxLllegada;
            }
            else 
            {
                IdProx = 3; relojProxLLegada = ProximaLlegadaRuedas.relojProxLllegada;
            }
        }

    }
}
