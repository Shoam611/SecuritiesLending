using Moq;
using NUnit.Framework;
using SecurityLending.models;
using SecurityLending.services.abstraction;
namespace SecurityLending.Test
{
    public class Tests
    {
        Mock<ICustomersService<Borrower>> mocCustService;

        [SetUp]
        public void Setup()
        {
            mocCustService = new Mock<ICustomersService<Borrower>>();

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}