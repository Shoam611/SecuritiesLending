using Moq;
using NUnit.Framework;
using SecurityLending.models;
using SecurityLending.services.abstraction;
namespace SecurityLending.Test
{
    public class Tests
    {
         ICustomersService<Borrower> borrowerService;
        Borrower returnedBorrower;
        Mock<ICustomerRepository<Borrower>> mocBorrowerRepo;

        [SetUp]
        public void Setup()
        {
            returnedBorrower = new Borrower {Name ="bggf", Count=200,Currency="AUD",Id=1 };
            borrowerService = new CustomerService<Borrower>(mocBorrowerRepo.Object);

            mocBorrowerRepo = new Mock<ICustomerRepository<Borrower>>();
            
            mocBorrowerRepo.Setup(c => c.Create(returnedBorrower))
                                .Returns(4);
            //BorrowerController = new BorrowersController(mocBorrowerService.Object);
        }

        [Test]
        public void Test1()
        {
            var res = borrowerService.CreateNewCustomer(returnedBorrower);

            Assert.IsTrue(res);
        }
    }
}
