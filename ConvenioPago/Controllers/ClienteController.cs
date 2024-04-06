using Microsoft.AspNetCore.Mvc;
using ConvenioPago.Core.Interfaces;
using ConvenioPago.Core.Constantes;
using ConvenioPago.Models;
using ConvenioPago.Negocio;
using Microsoft.AspNetCore.Authorization;

namespace ConvenioPago.Controllers
{    
    [ApiController]
    [Route("cliente")]
    public class ClienteController :ControllerBase
    {
      
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;            
        }

        [HttpPost]
        [Route("consultar")]
        public dynamic ConsultarCliente(Cliente cliente)
        {
            try
            {
                string token = Request.Headers.Where(x => x.Key == Mensajes.AUTORIZAR).FirstOrDefault().Value;
                if(token == Mensajes.TOKEN) 
                { 
                        List<IntencionPago> respuesta = _cliente.ValidarCliente(cliente);                       
                    return new
                    {
                        succes = true,
                        message = Mensajes.EXITO,
                        result = respuesta
                    };
                }
                else
                {
                    return new
                    {
                        succes = false,
                        message = Mensajes.ERROR_TOKEN,
                        result = string.Empty
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    succes = false,
                    message = Mensajes.ERROR,
                    result = ex
                };                
            }



        }


    }
}
