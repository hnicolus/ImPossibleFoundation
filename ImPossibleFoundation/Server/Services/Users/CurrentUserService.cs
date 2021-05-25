using System;
using System.Security.Claims;
using ImPossibleFoundation.Users;
using Microsoft.AspNetCore.Http;

namespace ImPossibleFoundation.Users
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var userStringId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrWhiteSpace(userStringId))
            {
                UserId = Guid.Parse(userStringId);
            }
        }

        public Guid UserId { get; }
    }
}