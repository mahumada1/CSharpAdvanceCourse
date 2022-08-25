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
            fm.CambioFormaPago += fm_ContinuarProcesoEvento;
            fm.CambioFormaPagoArgs += fm_SleccionformaPagoArgs;

            fm.Tipo = (TipoPago)Enum.Parse(typeof(TipoPago), tipoPago);

            

        }

        static void fm_SleccionformaPagoArgs(object obj, CamposTipoEventArgs args)
        {
            if (args.TipoAlerta.Equals(TipoAlerta.Error))
            {
                Console.WriteLine("Error, forma de pago no corresponde EVENTARGS");
            }
            else if (args.TipoAlerta.Equals(TipoAlerta.Exito))
            {
                Console.WriteLine($"Forma de pago seleccionada EVENTARGS: {args.TipoPago}");
            }
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

        static void fm_ContinuarProcesoEvento(TipoPago tipoPago, TipoAlerta tipoAlerta)
        {
            bool estatus = false;
            if (tipoAlerta.Equals(TipoAlerta.Exito))
            {
                Console.WriteLine($"Mensaje de existo desde segundo evento. {tipoPago}");
                return;
            }

            Console.WriteLine("Mensaje no verificado.");
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

        public event EventHandler<CamposTipoEventArgs> CambioFormaPagoArgs;

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
                CambioFormaPagoArgs(this, new CamposTipoEventArgs
                {
                    TipoAlerta = tipoAlerta,
                    TipoPago = tipo,
                });
            }
        }
    }

    public class CamposTipoEventArgs : EventArgs
    {
        public TipoPago TipoPago { get; set; }
        public TipoAlerta TipoAlerta { get; set; }
    }


}
