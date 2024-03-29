﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoSystem.Shared.Models
{
    public class AuthModel
    {
        public string AccessToken { get; set; }
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public long Expires { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
