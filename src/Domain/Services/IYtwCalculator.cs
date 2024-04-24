using System;
using System.Threading.Tasks;

using CalculatorsTest.Domain.Models;

namespace CalculatorsTest.Domain.Services;

public interface IYtwCalculator
{
    public Task<decimal?> CalculateYtwForBond(Bond bond);
    public Task<decimal?> CalculateYtwForBond(Bond bond, DateTime settlementDate);
}
