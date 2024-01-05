using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoSystem.Data.Entities
{
    public  class CasinoRole : IdentityRole<int>
    {
        public CasinoRole() { }
        public CasinoRole(string roleName)
        {
            this.Name = roleName;
        }
    }
}

