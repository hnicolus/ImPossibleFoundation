using System;

namespace ImPossibleFoundation.Clocking
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
