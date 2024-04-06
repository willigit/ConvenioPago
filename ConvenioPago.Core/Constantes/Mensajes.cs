using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenioPago.Core.Constantes
{
    public class Mensajes
    {
        public const string CEDULA_INCORRECTA = "El número de cédula ingresado esta incorrecta";
        public const string NO_CLIENTE = "No existe información del cliente, contactese con PagueYa";
        public const string DIAS_MORA = "Cliente no aplica convenio dias de mora: ";
        public const string EXITO = "Consulta Exitosa";
        public const string ERROR = "Error en la Consulta";
        public const string ERROR_MONTO = "Ingrese un monto para el convenio";
        public const string ERROR_MOTIVO = "Ingrese un motivo para el convenio";
        public const string ERROR_TOKEN = "Token incorrecto";
        public const string OK = "Convenio de pago registrado";
        public const string TOKEN = "pagueYa";
        public const string AUTORIZAR = "Authorization";
    }
}
