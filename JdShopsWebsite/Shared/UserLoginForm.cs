using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JdShopsWebsite.Shared
{
    public class UserLoginForm
    {
        public int? Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
