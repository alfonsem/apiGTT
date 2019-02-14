using System;
namespace proyectoPrueba.Models
{
    public class Certificates
    {
        public long id { get; set; }
        public string serialNumber { get; set; }
        public string subject { get; set; }
        public string notAfer { get; set; }
        public string issuer { get; set; }
        public string file64 { get; set; }
        public string alias { get; set; }
        public string nomCliente { get; set; }
        public string repositorio { get; set; }
        public string observaciones { get; set; }

        public Certificates()
        {
        }
    }
}
