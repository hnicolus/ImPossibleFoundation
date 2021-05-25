using Microsoft.AspNetCore.Identity;
using System;

namespace ImPossibleFoundation.Infrastructure.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() { }
        public AppRole(string roleName) : base(roleName) { }
    }
}
