using System;
using System.Threading.Tasks;

using CalculatorsTest.Core.Services;

namespace CalculatorsTest.UseCases.AppServices;

public class IndexProvider : IIndexProvider
{
    public Task<int> GetIndex(int indexCode, DateTime settlementDate)
    {
        return Task.FromResult(indexCode);
    }
}
