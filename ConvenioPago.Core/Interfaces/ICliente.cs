using ConvenioPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenioPago.Core.Interfaces
{
    public interface ICliente
    {
        /// <summary>
        /// validar si el cliente tiene registros pendientes para un convenio de pago
        /// </summary>
        /// <param name="cliente">informacion de cliente</param>
        /// <returns></returns>
        List<IntencionPago> ValidarCliente(Cliente cliente);
    }
}
