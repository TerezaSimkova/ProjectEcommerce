using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.CORE.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Ruolo { get; set; }
    }
    public enum Role
    {
        Administrator=1,
        Fornitore=2,
        User=3
    }
}
