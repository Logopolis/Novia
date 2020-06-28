using NUnit.Framework;
using Moq;
using System.Linq;
using Api.Repos;
using Api.DataFiles;

namespace Api.Tests.FundsControllerTests
{
    [TestFixture]
    public class GetFundsShould
    {
        private IFundsRepo _stubFundsRepo;
        private readonly List<FundDetails> _funds;

        [SetUp]
        public void SetUp()
        {
            _stubFundsRepo = MockRepository.GenerateStub<IFundsRepo>();
        }

        [Test]
        public void Get_a_fund()
        {
            Assert.IsTrue(true);
        }
    }
}
