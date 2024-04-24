using Xunit;

using CalculatorsTest.Calculators;
using CalculatorsTest.Domain.Models;
using CalculatorsTest.Core.Services;
using CalculatorsTest.UseCases.AppServices;

namespace CalculatorsTest.Tests.Calculators;

public class YtwCalculatorTests
{
    ITimeService _timeService;
    IIndexProvider _indexProvider;

    ImtcCalculator _imtcCalculator;
    
    public YtwCalculatorTests()
    {
        _timeService = new TimeService();
        _indexProvider = new IndexProvider();
        _imtcCalculator = new ImtcCalculator();
    }
    
    [Fact]
    public async void CalculateYtwForBondThrowsArgumentNullIfNullBondTest()
    {
        var calculator = new YtwCalculator(null, null, _timeService);

        await Assert.ThrowsAsync<ArgumentNullException>(() => calculator.CalculateYtwForBond(null));
    }

    [Fact]
    public async void CalculateYtwForBondWithoutDateUsesUtcNowTest()
    {
        var calculator = new YtwCalculator(_imtcCalculator, _indexProvider, _timeService);

        var bond = new Bond();

        var ytw = await calculator.CalculateYtwForBond(bond);
        
        Assert.NotNull(ytw);
    }

    [Fact]
    public async void CalculateYtwForBondDefaultIndexGeneratorLogicTest()
    {
        var calculator = new YtwCalculator(_imtcCalculator, _indexProvider, _timeService);

        var bond = new Bond()
        {
            CouponType = CouponType.Unknown,
            BondType = BondType.Unknown
        };

        var ytw = await calculator.CalculateYtwForBond(bond);
        
        Assert.NotNull(ytw);
    }

    [Fact]
    public async void CalculateYtwForBondCouponTypeEqualsVariableTest()
    {
        var calculator = new YtwCalculator(_imtcCalculator, _indexProvider, _timeService);

        var bond = new Bond()
        {
            CouponType = CouponType.Variable
        };

        var ytw = await calculator.CalculateYtwForBond(bond);
        
        Assert.NotNull(ytw);
    }

    [Fact]
    public async void CalculateYtwForBondTypeEqualsMunicipalTest()
    {
        var calculator = new YtwCalculator(_imtcCalculator, _indexProvider, _timeService);

        var bond = new Bond()
        {
            BondType = BondType.Municipal
        };

        var ytw = await calculator.CalculateYtwForBond(bond);
        
        Assert.NotNull(ytw);
    }
}