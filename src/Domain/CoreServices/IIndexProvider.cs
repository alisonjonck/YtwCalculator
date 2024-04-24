using System;
using System.Threading.Tasks;

namespace CalculatorsTest.Core.Services;

public interface IIndexProvider
{
    public Task<int> GetIndex(int indexCode, DateTime settlementDate);
}
