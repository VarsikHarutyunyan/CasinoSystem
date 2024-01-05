using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoSystem.Shared
{
    public class AddClaimToRoleModel
    {
        public string RoleId { get; set; }
        public List<string> Claims { get; set; }
    }
}
