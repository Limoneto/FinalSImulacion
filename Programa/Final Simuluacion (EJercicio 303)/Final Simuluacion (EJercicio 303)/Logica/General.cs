using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Simuluacion__EJercicio_303_.Logica
{
    static class General
    {
        public static Random random = new Random();

        public static double[] GenerarRNDNormal(int media, int desviacion)
        {
            double[] res = new double[4];
            res[0] = ObtenerRND();
            res[1] = ObtenerRND();
            double x = (Math.Sqrt(-2 * (Math.Log(res[0]))) * (Math.Cos(2 * (Math.PI) * res[1]))) * desviacion + media;
            res[2] = (Math.Truncate(x * 10000) / 10000);
            if (res[2] < 0) { res[2] = res[2] * (-1); }
            x = (Math.Sqrt(-2 * (Math.Log(res[0]))) * (Math.Sin(2 * (Math.PI) * res[1]))) * desviacion + media;
            res[3] = (Math.Truncate(x * 10000) / 10000);
            if (res[3] < 0) { res[3] = res[3] * (-1); }
            return res;
        }

        public static double ObtenerRND()
        {
            double x = Math.Round(random.NextDouble(), 6);
            return x;
        }

        public static double Acotar(double numero, double cantidad)
        {
            int acote = Convert.ToInt32(Math.Pow(10, cantidad)); 
            return (Math.Truncate(numero * acote) / acote);
        }
    }
}
