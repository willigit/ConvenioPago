using ConvenioPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvenioPago.Negocio
{
    public class Datos
    {       
        public static List<IntencionPago> ListadoConvenioAnteriores()
        {
            List<IntencionPago> intenciones = new List<IntencionPago>
          {
              new() {
                  Cedula = "1713379954",
                  Nombre = "Ricardo Gomez",
                  Correo = "ricardo@gmail.com",
                  DiasMora = 120,
                  MontoConvenio = 250,
                  MontoDeuda = 5000,
                  FechaConvenio =  "2022/11/02",
                  Exitoso = true

              },
                new() {
                  Cedula = "1713379954",
                  Nombre = "Ricardo Gomez",
                  Correo = "ricardo@gmail.com",
                  DiasMora = 125,
                  MontoConvenio = 250,
                  MontoDeuda = 5000,
                  FechaConvenio = "2023/05/20",
                  Exitoso = true
              },
                new() {
                  Cedula = "1713379954",
                  Nombre = "Ricardo Gomez",
                  Correo = "ricardo@gmail.com",
                  DiasMora = 125,
                  MontoConvenio = 250,
                  MontoDeuda = 5000,
                  FechaConvenio =  "2024/01/02",
                  Exitoso = true
                },
                new() {
                  Cedula = "1712252970",
                   Nombre = "Danny Quevedo",
                  Correo = "danny@gmail.com",
                  DiasMora = 145,
                  MontoConvenio = 250,
                  MontoDeuda = 15000,
                  FechaConvenio =  "2024/01/02",
                  Exitoso = true
                }
          };
            return intenciones;
        }

        public static List <Cliente> ListadoClientes()
        {
            List<Cliente> ListaClientes = new List<Cliente>
          {
              new() {
                  Cedula = "1717738023",
                  Nombre = "Pepito Perez",
                  Correo = "pepitop@gmail.com",
                  DiasMora = 119
              },
                new() {
                  Cedula = "1713379954",
                  Nombre = "Ricardo Gomez",
                  Correo = "ricardo@gmail.com",
                  DiasMora = 125
              },
                new() {
                  Cedula = "1704772373",
                  Nombre = "Silvia Padilla",
                  Correo = "silvia@gmail.com",
                  DiasMora = 0
                },
                new() {
                  Cedula = "1712252970",
                  Nombre = "Danny Quevedo",
                  Correo = "danny@gmail.com",
                  DiasMora = 130
                }
          };
            return ListaClientes;

        }
    }
}
