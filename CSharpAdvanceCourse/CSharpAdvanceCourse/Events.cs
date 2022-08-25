using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpAdvanceCourse.Events;

namespace CSharpAdvanceCourse
{
    public delegate void CambioFormaPagoHandler(TipoPago tipoPago, TipoAlerta tipoAlerta);

    public class Events
    {
        public Events()
        {
            Console.WriteLine("Ingrese una forma de pago: ");
            Console.WriteLine("1- Tarjeta \n2- Trasferencia \n3- Otros");
            string tipoPago = Console.ReadLine();
            FormaDePago fm = new FormaDePago();
            fm.CambioFormaPago += fm_SeleccionFormaPago;

            fm.Tipo = (TipoPago) Enum.Parse(typeof(TipoPago), tipoPago);
        }

        static void fm_SeleccionFormaPago(TipoPago tipoPago, TipoAlerta tipoAlerta)
        {
            if (tipoAlerta.Equals(TipoAlerta.Error))
            {
                Console.WriteLine("Error, forma de pago no corresponde");
            }
            else if (tipoAlerta.Equals(TipoAlerta.Exito))
            {
                Console.WriteLine($"Forma de pago seleccionada: {tipoPago.ToString()}");
            }
        }

        public enum TipoAlerta
        {
            Error = 1,
            Advertencia = 2,
            Exito = 3,
        }

        public enum TipoPago
        {
            Tarjeta = 1,
            Transferencia = 2,
            Otros = 3,
        }
    }

    public class FormaDePago
    {
        public event CambioFormaPagoHandler CambioFormaPago;
        private TipoPago tipo;

        public TipoPago Tipo
        {
            get { return tipo; }
            set 
            {
                TipoAlerta tipoAlerta = TipoAlerta.Error;
                if (value.Equals(TipoPago.Tarjeta) || value.Equals(TipoPago.Transferencia) || value.Equals(TipoPago.Otros))
                {
                    tipo = value;
                    tipoAlerta = TipoAlerta.Exito;
                }
                CambioFormaPago(tipo, tipoAlerta);
            }
        }

    }


}
