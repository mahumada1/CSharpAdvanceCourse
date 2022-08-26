using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceCourse
{
    public class Extension
    {
        public Extension()
        {
            var lista = new List<int> { 10, 2, 5, 6, 7, 8 };
            Console.WriteLine($"Resultado multiplicación : {lista.MultiplicarValores()}");
        }
    }

    public static class ListasExtension
    {
        public static int MultiplicarValores (this List<int> valores)
        {
            int mult = 1;
            for(int i=0; i< valores.Count; i++)
            {
                mult *= valores[i];
            }
            return mult;
        }
    }

}
