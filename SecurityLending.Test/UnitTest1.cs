using Moq;
using NUnit.Framework;
using SecurityLenders.DAL.abstraction;
using SecurityLending.models;
using SecurityLending.services;
using SecurityLending.services.abstraction;

namespace SecurityLending.Test
{
    public class Tests
    {
        Borrower returnedBorrower;
        ICustomersService<Borrower> borrowerService;
        Mock<ICustomerRepository<Borrower>> mocBorrowerRepo;

        [SetUp]
        public void Setup()
        {
            returnedBorrower = new Borrower { Name = "bggf", Count = 200, Currency = "AUD", Id = 1 };
            mocBorrowerRepo = new Mock<ICustomerRepository<Borrower>>();
            mocBorrowerRepo.Setup(c => c.Create(returnedBorrower)).Returns(4);
            borrowerService = new CustomerService<Borrower>(mocBorrowerRepo.Object);
        }

        [Test]
        public void Test_Create_New_Borrower_With_Valid_Input() => Assert.IsTrue(borrowerService.CreateNewCustomer(returnedBorrower));
    }
}
