using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceCourse
{
    public class Lambda
    {
        delegate int Operacion(int x, int y);
        public Lambda()
        {
            Operacion op = (a, b) => a * b;
            var res = op(2,3);

            Console.WriteLine(res);

            Operacion potencia = (a, b) =>
            {
                Console.WriteLine($"{a} elevado a {b}");
                return (int)Math.Pow(a, b);
            };

            var resPot = potencia(2,3);
            Console.WriteLine(resPot);

            //Delegado reservado entregado por .Net
            Func<int, int, int> potenciaFunc = (a, b) => (int)Math.Pow(a, b);
            var resFunc = potenciaFunc(2, 5);
            Console.WriteLine(resFunc);

            for(int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"5 elevado a {i} es igual a {potenciaFunc(5, i)}");
            }

        }
    
    }
}
