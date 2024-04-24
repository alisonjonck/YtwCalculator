using System;
using System.Threading.Tasks;

using CalculatorsTest.Domain.Models;
using CalculatorsTest.Core.Services;

namespace CalculatorsTest.UseCases.AppServices;

public class ImtcCalculator : IImtcCalculator
{
    public decimal? CalculateYtw(Bond bond, DateTime settlementDate, int index)
    {
        return index * 0.1m;
    }
}
