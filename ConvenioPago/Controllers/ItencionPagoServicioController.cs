using Microsoft.AspNetCore.Mvc;
using ConvenioPago.Core.Interfaces;
using ConvenioPago.Models;
using Microsoft.AspNetCore.Authorization;
using ConvenioPago.Core.Constantes;
namespace ConvenioPago.Controllers
{    
    [ApiController]
    [Route("convenio")]
    public class ItencionPagoServicioController : ControllerBase
    {
        private readonly IIntencionPagoServicio _intencionPagoServicio;

        public ItencionPagoServicioController(IIntencionPagoServicio intencionPagoServicio)
        {
            _intencionPagoServicio = intencionPagoServicio;
        }

     
        [HttpPost]
        [Route("registrar")]
        public dynamic RegistrarNuevoConvenio(IntencionPago intencionPago)
        {
            string token = Request.Headers.Where(x => x.Key == Mensajes.AUTORIZAR).FirstOrDefault().Value;
            if (token == Mensajes.TOKEN)
            {
                string validacion = _intencionPagoServicio.ValidarIntencionPago(intencionPago);

                if (validacion.Length > 0)
                {
                    return new
                    {
                        succes = false,
                        message = validacion,
                        result = ""
                    };
                }            

                return new
                {
                    succes = true,
                    message = Mensajes.OK,
                    result = intencionPago
                };
            }
            else
            {
                return new
                {
                    succes = false,
                    message = Mensajes.ERROR_TOKEN,
                    result = ""
                };
            }
        }

    }
}
