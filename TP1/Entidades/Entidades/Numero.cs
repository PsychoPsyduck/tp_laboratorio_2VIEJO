using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        private static double ValidarNumero(string strNumero)
        {
            double retorno = 0;
            double auxDecimal;
            bool isValid = double.TryParse(strNumero, out auxDecimal); ;

            if (isValid)
            {
                retorno = auxDecimal;
            }
            return retorno;
        }

        public string SetNumero
        {
            set
            {
                if (ValidarNumero(value) != 0)
                {
                    this.numero = ValidarNumero(value);
                }
            }
        }

        public static string BinarioDecimal(string binario)
        {
            string retorno = "";
            double auxDecimal = 0;
            double auxCifras;
            int i;
            bool isValido = double.TryParse(binario, out auxCifras);

            if (isValido)
            {
                auxCifras = binario.Length;
                for (i = 0; i < auxCifras; i++)
                {

                    if (binario.ElementAt(i) != '0' && binario.ElementAt(i) != '1')
                    {
                        return "Valor invalido";
                    }
                    else if (binario.ElementAt(i) == '1')
                    {
                        auxDecimal = auxDecimal + Math.Pow(2, auxCifras - i - 1);
                    }
                }
                retorno = Convert.ToString(auxDecimal);
            }
            return retorno;
        }

        public static string DecimalBinario(double numero)
        {
            double auxOperacion;
            int auxContador = 0;
            double auxSumador = 0;
            string retorno = "";
            int i;

            do
            {
                auxOperacion = Math.Pow(2, auxContador);
                auxContador++;
            } while (numero >= auxOperacion);

            for (i = auxContador - 2; i >= 0; i--)
            {
                auxOperacion = Math.Pow(2, i);
                if (auxSumador + auxOperacion <= numero)
                {
                    auxSumador = auxSumador + auxOperacion;
                    retorno = retorno + "1";
                }
                else
                {
                    retorno = retorno + "0";
                }
            }
            return retorno;
        }

        public static string DecimalBinario(string numero)
        {
            bool isValid;
            double auxCalculo = 0;
            string retorno = "Valor invalido";

            isValid = double.TryParse(numero, out auxCalculo);
            if (true)
            {
                retorno = DecimalBinario(auxCalculo);
            }
            return retorno;
        }
        
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno=0;

            if (n2.numero != 0)
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
