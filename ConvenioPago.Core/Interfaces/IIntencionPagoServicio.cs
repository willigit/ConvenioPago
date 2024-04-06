using ConvenioPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenioPago.Core.Interfaces
{
    public interface IIntencionPagoServicio
    {
        string ValidarIntencionPago(IntencionPago intencionPago);
    }
}
