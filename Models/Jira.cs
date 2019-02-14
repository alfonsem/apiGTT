using System;
namespace proyectoPrueba.Models
{
    public class Jira
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string componente { get; set; }
        public string descripcion { get; set; }

        public Jira()
        {
        }
    }
}
