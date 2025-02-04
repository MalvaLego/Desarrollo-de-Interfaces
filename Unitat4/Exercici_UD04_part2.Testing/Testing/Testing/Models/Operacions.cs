using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Models
{
    public class Operacions
    {
        
        public static int Sumar(int primero, int segundo)
        {
            int suma = primero + segundo;
            return suma;
        }

        public static int Restar(int primero, int segundo)
        {
            int resta = primero - segundo;
            return resta;
        }

        public static int Multiplicar(int primero, int segundo)
        {
            int multi = primero * segundo;
            return multi;
        }

        public static String Dividir(int primero, int segundo)
        {
            if (segundo==0)
            {
                throw new ArgumentException("No se puede dividir entre 0");
            } 
            
            double div = primero / segundo;
            return div.ToString();   
        }
    }
}
