using System;
using System.Threading.Tasks;

using CalculatorsTest.Domain.Models;
using CalculatorsTest.Core.Services;
using CalculatorsTest.Domain.Services;

namespace CalculatorsTest.Calculators;

public class YtwCalculator : IYtwCalculator
{
    private readonly IImtcCalculator _calculator;
    private readonly IIndexProvider _indexProvider;
    private readonly ITimeService _timeService;

    public YtwCalculator(IImtcCalculator calculator, IIndexProvider indexProvider, ITimeService timeService)
    {
        _calculator = calculator;
        _indexProvider = indexProvider;
        _timeService = timeService;
    }

    public async Task<decimal?> CalculateYtwForBond(Bond bond)
    {
        var settlementDate = _timeService.UtcNow.Date;
        return await CalculateYtwForBond(bond, settlementDate);
    }

    public async Task<decimal?> CalculateYtwForBond(Bond bond, DateTime settlementDate)
    {
        if (bond is null) 
        {
            throw new ArgumentNullException(nameof(bond));
        }

        var indexCode = bond switch
        {
            Bond b when b.CouponType == CouponType.Variable => IndexNames.USTR_CMT,
            Bond b when b.BondType == BondType.Municipal => IndexNames.MuniAAA,
            _ => IndexNames.USTR_CMT
        };

        var index = await _indexProvider.GetIndex((int)indexCode, settlementDate);
        var ytw = _calculator.CalculateYtw(bond, settlementDate, index);
        return ytw;
    }
}
