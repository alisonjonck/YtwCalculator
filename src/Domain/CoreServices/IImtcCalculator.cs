using System;
using System.Threading.Tasks;

using CalculatorsTest.Domain.Models;

namespace CalculatorsTest.Core.Services;

public interface IImtcCalculator
{
    public decimal? CalculateYtw(Bond bond, DateTime settlementDate, int index);
}
