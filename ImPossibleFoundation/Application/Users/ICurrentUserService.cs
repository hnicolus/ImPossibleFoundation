using System;

namespace ImPossibleFoundation.Users
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}
