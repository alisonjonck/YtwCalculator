using System;

namespace CalculatorsTest.Core.Services;

public interface ITimeService
{
    public DateTime UtcNow { get; set; }
}
