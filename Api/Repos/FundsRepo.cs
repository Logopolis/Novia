using Api.DataFiles;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Api.Repos
{
    public class FundsRepo : IFundsRepo
    {
        public IEnumerable<FundDetails> GetAll()
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            return JsonConvert.DeserializeObject<List<FundDetails>>(file);
        }
    }
}
