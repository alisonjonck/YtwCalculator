using System;

using CalculatorsTest.Core.Services;

namespace CalculatorsTest.UseCases.AppServices;

public class TimeService : ITimeService
{
    public DateTime UtcNow { get; set; }

    public TimeService()
    {
        UtcNow = DateTime.UtcNow;
    }
}
