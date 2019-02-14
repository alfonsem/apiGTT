using System;
namespace proyectoPrueba.Models
{
    public class Users
    {
        public long id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }

        public Users()
        {
        }
    }
}
