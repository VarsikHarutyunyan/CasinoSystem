
using System;
using System.Collections.Generic;
using System.Text;
using CasinoSystem.Data.Entities.Base;
using Microsoft.AspNetCore.Identity;
using CasinoSystem.Shared.Enums;

namespace CasinoSystem.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Balance { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdateAt { get; set; }
    }
}
