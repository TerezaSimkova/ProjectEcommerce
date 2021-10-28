using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEcommerce.MVC.Models
{
    public class UtenteLoginViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public Role Ruolo { get; set; }
        public string ReturnUrl { get; set; }
    }
    public enum Role
    {
        Administrator = 1,
        Fornitore = 2,
        User = 3
    }
}
