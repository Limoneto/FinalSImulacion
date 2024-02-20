using Final_Simuluacion__EJercicio_303_.Entidades;
using Final_Simuluacion__EJercicio_303_.Logica.Extras;
using Final_Simuluacion__EJercicio_303_.Logica.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simuluacion__EJercicio_303_.Logica.Servidores
{
    class ColocadoresDeRuedas
    {
        public static double media;
        public static int desviacion;
        
        public static uint biciletasTerminadas=0;

        public static List<uint> cola = new List<uint>();

        public static bool atendiendo = false;
        private static bool sePuedeColocar = false;

        private static short servidorIdMasPronto = 0;

        public static int cantidadColaMax = 0;
        private static uint[] bicisEsperandoRuedas = {0,0};

        public static bool  HayBicis()
        {
            return (cola.Count != 0);
        }
            public static void Reiniciar()
        {
            ColocadorDeRueda1.Reiniciar();
            ColocadorDeRueda2.Reiniciar();
            atendiendo = false;
            sePuedeColocar = false;
            servidorIdMasPronto = 0;
            cantidadColaMax = 0;
            bicisEsperandoRuedas[0] = 0; bicisEsperandoRuedas[1] = 0;
            cola = new List<uint>();
            biciletasTerminadas = 0;
        }

        public static void Actualizar()
        {
            ColocadorDeRueda1.Actualizar();
            ColocadorDeRueda2.Actualizar();
           
        }

        public static double ProxRelojFin() 
        {
            if (servidorIdMasPronto == 1)
            {
                return ColocadorDeRueda1.relojFinTrabajo;
            }
            else 
            {
                return ColocadorDeRueda2.relojFinTrabajo;
            }
        }
        public static void IngresaBicicleta(uint id)
        {

            cola.Add(id);
            SePuedeSeguirColocando();
            OrdenarBicileta();
        }
        private static void OrdenarBicileta()
        {
            if (!sePuedeColocar) { ActualizarMax(); Turnos.Contar(); }
            else
            {
                if (!ColocadorDeRueda1.Atendiendo || !ColocadorDeRueda2.Atendiendo)
                {
                    ComenzarATrabajar();
                }
            }
        }
        private static void ActualizarMax()
        {
            if (cola.Count > cantidadColaMax) { cantidadColaMax = cola.Count; }
        }
        public static bool HayBicicletas()
        {
            if (cola.Count > 0) { return true; }
            return false;
        }

        public static void TerminarTrabajo()
        {
            IndicarFinTrabajoAlServidor();
            CalcularServidorMasRapido();
            SePuedeSeguirColocando();
            if (!ColocadorDeRueda1.Atendiendo || !ColocadorDeRueda2.Atendiendo)
            { if (cola.Count > 0 && sePuedeColocar) { ComenzarATrabajar(); }
                else { Turnos.Contar(); }
            }

        }
        private static void IndicarFinTrabajoAlServidor()
        {
            if (servidorIdMasPronto == 1) { ColocadorDeRueda1.TerminarTrabajo(); }
            else { ColocadorDeRueda2.TerminarTrabajo(); }
            
        }

        private static void ComenzarATrabajar()
        {
            uint id = cola[0]; 
            Bicicleta biciCola = Bicicletas.ObtenerBicicleta(id);
            if (biciCola.Estado == 2 && !atendiendo)
            {
                ColocadorDeRueda1.ComenzarATrabajar(id);
                SePuedeSeguirColocando(); if (sePuedeColocar)
                {
                    ColocadorDeRueda2.ComenzarATrabajar(id);
                }
            }
            else if (ColocadorDeRueda1.Atendiendo)
            {
                ColocadorDeRueda2.ComenzarATrabajar(id);
            }
            else { ColocadorDeRueda1.ComenzarATrabajar(id); }
            
            atendiendo = true; //empieza a atender
            cola.RemoveAt(0);
            
            CalcularServidorMasRapido();
            SePuedeSeguirColocando();
        }

        public static void ReingresarBicicletaParaTerminar(short colocador, uint idBici)
        {
            if (sePuedeColocar)
            {
                atendiendo = true; //empieza a atender
                if (colocador == 1) { ColocadorDeRueda1.ComenzarATrabajar(idBici); }
                else { ColocadorDeRueda2.ComenzarATrabajar(idBici); }
            }
            else 
            {
                if (colocador == 1) {bicisEsperandoRuedas[0] = idBici; }
                else { bicisEsperandoRuedas[1] = idBici; ; }
            }
            
            CalcularServidorMasRapido();
            SePuedeSeguirColocando();
        }

        public static void AlertarLlegadaDeRuedas() 
        {
            SePuedeSeguirColocando();
            QuitarBicisDeListaDeEspera();
        }
        private static void SePuedeSeguirColocando() 
        {
            if (Evento.ruedas > 0)
            {
                sePuedeColocar = true;                
            }
            else { sePuedeColocar = false; }
        }

        public static void QuitarBicisDeListaDeEspera() 
        {
            bool noPaso = true;
            for (short i = 0; i < 2; i++)
            {
                if (!sePuedeColocar) { break; }
                if (bicisEsperandoRuedas[i] != 0) 
                {
                   // Console.WriteLine(bicisEsperandoRuedas[i]);
                    
                    ReingresarBicicletaParaTerminar((short)(i+1), bicisEsperandoRuedas[i]);
                    bicisEsperandoRuedas[i] = 0;
                    noPaso = false;
                }
            }
            if (noPaso && cola.Count>0 && sePuedeColocar)
            {
                if (!ColocadorDeRueda1.Atendiendo || !ColocadorDeRueda2.Atendiendo) { ComenzarATrabajar(); }
                
            }
        }

       
        private static void CalcularServidorMasRapido()
        {
            if (ColocadorDeRueda1.Atendiendo)
            {
                if (ColocadorDeRueda2.Atendiendo)
                {
                    if (ColocadorDeRueda1.relojFinTrabajo <= ColocadorDeRueda2.relojFinTrabajo) { servidorIdMasPronto = 1; atendiendo = true; }
                    else { servidorIdMasPronto = 2; atendiendo = true; }
                }
                else { servidorIdMasPronto = 1; atendiendo = true; }
            }
            else
            {
                if (ColocadorDeRueda2.Atendiendo)
                {
                    atendiendo = true;
                    servidorIdMasPronto = 2;
                }
                else
                {
                    atendiendo = false;
                    servidorIdMasPronto = 0;
                }
            }
        }

        public static short EsFinDeAtencion() 
        {
            short nroTipo;
            if (servidorIdMasPronto == 1)
            {
                nroTipo = Bicicletas.ObtenerBicicleta(ColocadorDeRueda1.id).Estado;
                if (nroTipo == 6) { return 6; }
                else { return 5; }
            }
            else 
            {
                nroTipo = Bicicletas.ObtenerBicicleta(ColocadorDeRueda2.id).Estado;
                if (nroTipo == 6) { return 6; }
                else { return 5; }
            }
            
        }

        public static string[] ToArrayString()
        {
             /*
            string[] stringColocador1 = ColocadorDeRueda1.ToArrayString();
            string[] stringColocador2 = ColocadorDeRueda2.ToArrayString();

            string[] printArray = new string[2 + stringColocador1.Length + stringColocador2.Length]; //Podría hardcodearse pero le agrega acoplamiento al código y le quita cohesion

            printArray[0]=(cola.Count.ToString());
            printArray[1]=(cantidadColaMax.ToString());

            stringColocador1.CopyTo(printArray, 2);
            stringColocador2.CopyTo(printArray, stringColocador1.Length);
            */
            
            string[] printArray = new string[13]; //2 + 5 + 5

            printArray[0] = (cola.Count.ToString());
            printArray[1] = (cantidadColaMax.ToString());
            printArray[2] = (Evento.ruedas).ToString();

            ColocadorDeRueda1.ToArrayString().CopyTo(printArray, 3);
            ColocadorDeRueda2.ToArrayString().CopyTo(printArray, 8);
            return printArray;
            
        }
    }
}
