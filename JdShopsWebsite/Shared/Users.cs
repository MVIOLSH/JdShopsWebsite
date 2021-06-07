﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JdShopsWebsite.Shared
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public bool IsValidated { get; set; }
    }
}
