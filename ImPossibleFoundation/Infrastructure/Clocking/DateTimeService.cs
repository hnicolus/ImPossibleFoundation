using System;
using ImPossibleFoundation.Clocking;

namespace CodeClinic.Infrastructure.Services
{
    public class ClockService : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}
