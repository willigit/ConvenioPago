using ConvenioPago.Core.Interfaces;
using ConvenioPago.Core.Constantes;
using ConvenioPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenioPago.Negocio
{
    public class Validaciones : ICliente
    {
        /// <summary>
        /// validar datos de cliente que consulta en el sistema 
        /// </summary>
        /// <param name="cliente">datos del cliente</param>
        /// <returns>registros consultados o mensajes de busqueda</returns>
        public List<IntencionPago> ValidarCliente(Cliente cliente)
        {
            List<IntencionPago> intenciones;
            string cedula = cliente.Cedula ?? string.Empty;
            try
            {


                if (!ValidarCedula(cedula))
                {
                    intenciones = new List<IntencionPago>{
                    new() {
                        Motivo = Mensajes.CEDULA_INCORRECTA,
                        Exitoso = false
                    }
                };
                }
                else
                {
                    Cliente clienteExistente = ValidarClienteExiste(cedula);
                    if (clienteExistente.Cedula == null)
                    {
                        intenciones = new List<IntencionPago>
                        {
                            new()
                            {
                                Motivo = Mensajes.NO_CLIENTE,
                                Exitoso = false
                            }
                        };
                    }
                    else
                    {
                        if(clienteExistente.DiasMora > 120) { 
                            intenciones = BuscarListaConvenios(cedula);
                            if (intenciones.Count() <= 0)
                            {
                                intenciones.Add(new()
                                {
                                    Cedula = cedula,
                                    Correo = cliente.Correo,
                                    DiasMora = cliente.DiasMora,
                                    Exitoso = true,
                                    Nombre = cliente.Nombre,
                                    MontoDeuda = 10000
                                });
                            }
                        }
                        else
                        {
                            intenciones = new List<IntencionPago>
                            {
                                new()
                                {
                                    Nombre = clienteExistente.Nombre,                                    
                                    Motivo = Mensajes.DIAS_MORA + clienteExistente.DiasMora.ToString(),
                                    Exitoso = true
                                }
                            };
                        }

                    }
                }

                return intenciones;
            }
            catch (Exception)
            {                
                throw;
            }


        }
        private List<IntencionPago> BuscarListaConvenios(string cedula)
        {
            _ = new List<IntencionPago>();
            List<IntencionPago> nuevaIntencionPagos = new List<IntencionPago>();

            List<IntencionPago> intencionPagos = Datos.ListadoConvenioAnteriores();
            for (int i = 0; i < intencionPagos.Count; i++)
            {
                //Busca si texto se encuentra en ArrayList.
                if (intencionPagos[i].Cedula == cedula)
                {
                    nuevaIntencionPagos.Add(intencionPagos[i]);
                }
            }
           
            return nuevaIntencionPagos;
        }

            /// <summary>
            /// buscar en los datos del arreglo si la Cedula ingresada existe
            /// </summary>
            /// <param name="cedula">cedula a buscar</param>
            /// <returns>datos del cliente buscado</returns>
            private Cliente ValidarClienteExiste(string cedula)
        {            
            List<Cliente> listanombres = new List<Cliente>();

            listanombres = Datos.ListadoClientes();

            for (int i = 0; i < listanombres.Count; i++)
            {
                //Busca si texto se encuentra en ArrayList.
                if (listanombres[i].Cedula == cedula)
                {
                    return listanombres[i];
                }
            }         
            return new Cliente();
        }


        /// <summary>
        /// Validar si el número de cédula es correcto
        /// </summary>
        /// <param name="cedula">cedula a buscar</param>
        /// <returns>true o false de la validacion de CI</returns>
        private bool ValidarCedula(string cedula)
        {            

            bool estado = false;
            char[] valced = new char[13];
            int provincia;
            if (cedula.Length >= 10)
            {
                valced = cedula.Trim().ToCharArray();
                provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                if (provincia > 0 && provincia < 31) 
                {                   
                    estado = VerificaCedula(valced);               
                }
            }
            return estado;
        }
        /// <summary>
        /// valida el digito verificador
        /// </summary>
        /// <param name="validarCedula">cedula</param>
        /// <returns>resultado de validacion</returns>
        private static bool VerificaCedula(char[] validarCedula)
        {
            int aux = 0, par = 0, impar = 0, verifi;          
            
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(validarCedula[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(validarCedula[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(validarCedula[9].ToString()))
                return true;
            else
                return false;
        }
    }
}
