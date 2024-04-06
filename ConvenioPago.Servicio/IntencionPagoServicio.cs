using ConvenioPago.Core.Constantes;
using ConvenioPago.Core.Interfaces;
using ConvenioPago.Models;
using System.ComponentModel.DataAnnotations;

namespace ConvenioPago.Negocio
{
    public class IntencionPagoServicio : IIntencionPagoServicio
    {
        /// <summary>
        /// validar intencion de pago antes de guardar
        /// </summary>
        /// <param name="intencionPago">datos de pago</param>
        /// <returns>mensajes de transaccion</returns>
        public string ValidarIntencionPago(IntencionPago intencionPago)
        {
            string validacion = string.Empty;

            // Validar que el monto a pagar sea mayor que cero
            if (intencionPago.MontoConvenio <= 0)
            {
                validacion = Mensajes.ERROR_MONTO;
            }
            else 
            { 
                string motivo = intencionPago.Motivo??=string.Empty;
                if(motivo.Length <= 5)
                {
                    validacion = Mensajes.ERROR_MOTIVO;
                }else
                {
                    validacion = string.Empty;
                }
            }
            return validacion;
        }
    }
}
