using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retorno = 0;
            operador = ValidarOperador(operador);

            switch (operador)
            {
                case "+":
                    retorno = num1+num2;
                    break;
                case "-":
                    retorno = num1-num2;
                    break;
                case "*":
                    retorno = num1*num2;
                    break;
                case "/":
                    retorno = num1/num2;
                    break;
            }
            return retorno;
        }

        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            switch (operador)
            {
                case "+":
                    retorno = "+";
                    break;
                case "-":
                    retorno = "-";
                    break;
                case "*":
                    retorno = "*";
                    break;
                case "/":
                    retorno = "/";
                    break;
            }
            return retorno;
        }
    }
}
