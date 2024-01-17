using System;
using System.Collections.Generic;
using System.Web.Http;

namespace APIRest.Controllers
{
    public class MathController : ApiController
    {
        public IHttpActionResult Get([FromUri] List<int> numbers)
        {
            int retVal = CalculateMCM(numbers);

            return Ok(retVal);
        }

        public IHttpActionResult Get([FromUri] int number)
        {
            int retVal = number + 1;

            return Ok(retVal);
        }

        private int CalculateMCM([FromUri] List<int> numeros)
        {
            // Inicializar el MCM con el primer número de la lista
            int mcm = numeros[0];

            // Calcular el MCM iterativamente con los demás números de la lista
            for (int i = 1; i < numeros.Count; i++)
            {
                mcm = CalculateMCMBetweenTwoNumbers(mcm, numeros[i]);
            }

            return mcm;
        }

        private int CalculateMCD(int num1, int num2)
        {
            int a = Math.Max(num1, num2);
            int b = Math.Min(num1, num2);

            int mcd;
            do
            {
                mcd = b;
                b = a % b;
                a = mcd;
            } while (b != 0);

            return mcd;
        }

        private int CalculateMCMBetweenTwoNumbers(int num1, int num2)
        {
            int a = Math.Max(num1, num2);
            int b = Math.Min(num1, num2);
            int mcm = a / CalculateMCD(a, b) * b;
            return mcm;
        }
    }
}