using ImPossibleFoundation.Common.Models;
using System;
using System.Threading.Tasks;

namespace ImPossibleFoundation.Identity
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(Guid userId);
        Task<string> GetUserEmailAsync(Guid userId);
        Task<bool> IsInRoleAsync(Guid userId, string role);
        Task<bool> AuthorizeAsync(Guid userId, string policyName);
        Task<(Result Result, Guid UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(Guid userId);
    }
}
