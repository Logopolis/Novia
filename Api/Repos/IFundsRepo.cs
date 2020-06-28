using Api.DataFiles;
using System.Collections.Generic;

namespace Api.Repos
{
    public interface IFundsRepo
    {
        IEnumerable<FundDetails> GetAll();
    }
}
