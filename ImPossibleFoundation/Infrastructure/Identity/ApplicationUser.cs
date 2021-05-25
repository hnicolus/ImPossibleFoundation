using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImPossibleFoundation.Infrastructure.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Avatar { get; set; }
        public string Bio { get; set; }
    }
}
