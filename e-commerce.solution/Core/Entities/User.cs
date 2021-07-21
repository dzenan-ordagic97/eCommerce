using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class User: IdentityUser<int>
    {
        public bool Sys_Deleted { get; set; }
    }
}
