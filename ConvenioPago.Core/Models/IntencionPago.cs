namespace ConvenioPago.Models
{
    public class IntencionPago : Cliente
    {                      
        public int MontoConvenio { get; set; }
        public int MontoDeuda { get; set; }
        public string? FechaConvenio{ get; set; }
        public string? Motivo {  get; set; }
        public bool Exitoso{ get; set; }

    }
}