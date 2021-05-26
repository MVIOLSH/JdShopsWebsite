using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JdShopsWebsite.Services
{
    public class LoginModel
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string passwordHash { get; set; }

       
    }
}
