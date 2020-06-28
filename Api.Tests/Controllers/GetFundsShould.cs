using NUnit.Framework;
using Moq;
using Api.Repos;
using Api.DataFiles;
using System;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Api.Tests.Extensions;
using Microsoft.Extensions.Logging;
using Api.Models;

namespace Api.Tests.Controllers
{
    [TestFixture]
    public class FundsControllerTests
    {
        private Mock<IFundsRepo> _stubFundsRepo;
        private Mock<ILogger<FundsController>> _dummyLogger;

        private FundsController _controllerUnderTest;

        private const string _goodMarketCode = "CODE";
        private const string _goodManagerName = "Manager McManager";
        private static readonly FundDetails _firstFundDetails = new FundDetails
        {
            Active = true,
            CurrentUnitPrice = 10.011M,
            FundManager = "ABC Investments",
            Id = Guid.Parse("bbac70b6-a785-48f2-ba3e-5c6a414cbab6"),
            MarketCode = _goodMarketCode,
            Name = _goodManagerName
        };

        private static readonly FundDetails _secondFundDetails = new FundDetails
        {
            Active = true,
            CurrentUnitPrice = 10.021M,
            FundManager = "123 Investments",
            Id = Guid.Parse("cbac70b6-a785-48f2-ba3e-5c6a414cbab7"),
            MarketCode = "XXXX",
            Name = "Other McManagerson"
        };

        private static readonly FundViewModel _firstFundViewModel = new FundViewModel
        {
            Active = true,
            CurrentUnitPrice = 10.01M,
            FundManager = "ABC Investments",
            Code = _goodMarketCode,
            Name = _goodManagerName
        };

        private static readonly FundViewModel _secondFundViewModel = new FundViewModel
        {
            Active = true,
            CurrentUnitPrice = 10.02M,
            FundManager = "123 Investments",
            Code = "XXXX",
            Name = "Other McManagerson"
        };

        [SetUp]
        public void SetUp()
        {
            _dummyLogger = new Mock<ILogger<FundsController>>();
            _stubFundsRepo = new Mock<IFundsRepo>();
            _stubFundsRepo
                .Setup(r => r.GetAll())
                .Returns(new[] { _firstFundDetails, _secondFundDetails });
            
            _controllerUnderTest = new FundsController(_stubFundsRepo.Object, _dummyLogger.Object);
        }

        [Test]
        public void should_return_all_funds()
        {
            var result = _controllerUnderTest.Get();

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.True(okResult.Value.ObjectMembersEqual(new[] { _firstFundViewModel, _secondFundViewModel }));
        }

        [Test]
        public void should_get_funds_by_manager()
        {
            var result = _controllerUnderTest.Get(_goodManagerName);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.True(okResult.Value.ObjectMembersEqual(new[] { _firstFundViewModel }));
        }

        [Test]
        public void should_get_a_fund()
        {
            var result = _controllerUnderTest.Get(null, _goodMarketCode);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.True(okResult.Value.ObjectMembersEqual(_firstFundViewModel));
        }

        [Test]
        public void should_return_404_when_fund_not_found()
        {
            var result = _controllerUnderTest.Get(null, "STRANGE CODE");

            Assert.IsInstanceOf(typeof(NotFoundResult), result);
        }
    }
}
