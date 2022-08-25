using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceCourse
{
    public class Tuplas
    {
        public Tuplas()
        {
            var tupla = ("Manuel", "Velazquez", 50);
            Console.WriteLine($"Valor 1: {tupla.Item1}, Valor 2: {tupla.Item2}, Valor 3: {tupla.Item3}");

            var tuplaNom = (Nombre: "Manuel", Apellido: "Velazquez", Edad: 50);
            Console.WriteLine($"Valor 1: {tuplaNom.Nombre}, Valor 2: {tuplaNom.Apellido}, Valor 3: {tuplaNom.Edad}");

            (string Nombre, string Apellido, int Edad) tuplatipo = (Nombre: "Manuel", Apellido: "Velazquez", Edad: 50);
            Console.WriteLine($"Valor 1: {tuplatipo.Nombre}, Valor 2: {tuplatipo.Apellido}, Valor 3: {tuplatipo.Edad}");

            tuplatipo.Nombre = "Otro Nombre";
            tuplatipo.Apellido = "Otro Apellido";
            tuplatipo.Edad = 100;
            Console.WriteLine($"Valor 1: {tuplatipo.Nombre}, Valor 2: {tuplatipo.Apellido}, Valor 3: {tuplatipo.Edad}");

        }
    }
}
