using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanceCourse
{
    public class Delegates
    {
        public delegate float CalcularTotal(float subtotal);

        public float CalcularSubtotalInternacional (float subtotal)
        {
            return 0;
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
    }



}
