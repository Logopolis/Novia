using Api.DataFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class FundViewModel
    {
        public bool Active { get; set; }

        public decimal CurrentUnitPrice { get; set; }

        public string FundManager { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public static FundViewModel FromFundDetails(FundDetails fundDetails)
        {
            return new FundViewModel
            {
                Active = fundDetails.Active,
                CurrentUnitPrice = Math.Round(fundDetails.CurrentUnitPrice, 2),
                Code = fundDetails.MarketCode,
                FundManager = fundDetails.FundManager,
                Name = fundDetails.Name
            };
        }
    }
}
