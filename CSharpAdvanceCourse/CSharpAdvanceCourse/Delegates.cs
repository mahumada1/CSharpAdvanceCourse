using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceCourse
{

    public delegate float CalcularTotal(float subtotal);
    public delegate void CalcularTotalRef(ref float subtotal);

    public class Delegates
    {
        public Delegates()
        {
            var vueloNac = new VueloNacional
            {
                Redondo = true
            };

            CalcularTotal deltotal = vueloNac.CalcularMontoTotal;

            float precio = 5500f;

            Console.WriteLine($"El costo vuelo Nacional es {deltotal(precio)}");

            var vueloInt = new VueloInternacional
            {
                Destino = 559,
                Redondo = true
            };

            deltotal = vueloInt.CalcularMontoTotal;
            Console.WriteLine($"El costo vuelo Internacional es {deltotal(precio)}");

            Console.WriteLine($"El costo vuelo Internacional con descuento {CalcularConDescuento(precio, deltotal)}");


            //MULTICAST
            CalcularTotal totalB = vueloInt.CalcularMontoTotal;
            totalB += CalcularTotalSeguro;
            Console.WriteLine($"El costo vuelo Internacional con multicast es {totalB(precio)}");

            CalcularTotalRef totalRef = vueloInt.CalcularMontoTotalRef;
            totalRef += CalcularTotalSeguroRef;
            totalRef(ref precio);
            Console.WriteLine($"El costo vuelo Internacional con multicast REF es {precio}");

        }

        static float CalcularTotalSeguro(float monto)
        {
            return monto * 55f;
        }

        static void CalcularTotalSeguroRef(ref float monto)
        {
            monto = monto * 155f;
        }

        static float CalcularConDescuento(float monto, CalcularTotal total)
        {
            var valor = total(monto);
            return valor - (valor * 0.35f);
        }

    }

    public class VueloNacional
    {
        public float IVA => 0.19f;
        public float Tua => 220f;
        public bool Redondo { get; set; }
        public float CalcularMontoTotal(float monto)
        {
            return monto + (monto * IVA) + Tua;
        }
    }

    public class VueloInternacional
    {
        public float IVA => 0.19f;
        public float Tua => 220f;
        public bool Redondo { get; set; }
        public int Destino { get; set; }
        public float CalcularMontoTotal(float monto)
        {
            return monto + (monto * IVA) + Tua + (Destino == 559 ? 1000 : 0);
        }

        public void CalcularMontoTotalRef(ref float monto)
        {
            monto = monto + (monto * IVA) + Tua + (Destino == 559 ? 1000 : 0);
        }
    }



}
