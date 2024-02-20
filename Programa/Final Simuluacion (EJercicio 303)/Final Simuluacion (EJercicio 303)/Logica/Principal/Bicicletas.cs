using Final_Simuluacion__EJercicio_303_.Entidades;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Simuluacion__EJercicio_303_.Logica.Principal
{
    public static class Bicicletas
    {
        public static uint cantidadMaxBiciletas = 0;
        private static Hashtable hashBiciletas = new Hashtable();

        public static void Reiniciar()
        {
            cantidadMaxBiciletas = 0;
            hashBiciletas = new Hashtable();

        }
        public static int CuantasBicisHay()
        {
            return hashBiciletas.Count;
        }
        public static void AgregaBicicleta(Bicicleta bici) 
        {
            cantidadMaxBiciletas++;
            hashBiciletas.Add(bici.id, bici);
        }
        public static void QuitarBicicleta(uint id)
        {
            hashBiciletas.Remove(id);
        }

        public static bool HayBicis()
        {
            return (hashBiciletas.Count!=0);
        }

        public static Bicicleta ObtenerBicicleta (uint id) 
        {
            return (Bicicleta)hashBiciletas[id];
        }

        public static string[] ToArrayString()
        {
            
            try
            {   uint i = 2;
            string[] print = new string[2 + hashBiciletas.Count * 5];
            print[0] = Simulacion.nroSimulacion.ToString();
            print[1] = Evento.relojActual.ToString();
                foreach (DictionaryEntry elemento in hashBiciletas)
            {
                ((Bicicleta)elemento.Value).ToArrayString().CopyTo(print, i);
                i += 5;
            }
            return print;
            }
            catch (Exception e)
            {
                Simulacion.exceptionBicis = e;
                Simulacion.mataFuegosBicis = true;
                uint i = 2, j=1;
                string[] print = new string[2 + 100 * 5];
                print[0] = Simulacion.nroSimulacion.ToString();
                print[1] = Evento.relojActual.ToString();
                foreach (DictionaryEntry elemento in hashBiciletas)
                {
                    if (j == 100) { break; }
                    ((Bicicleta)elemento.Value).ToArrayString().CopyTo(print, i);
                    i += 5;
                }
                return print;
            }
            
        }
    }
}
