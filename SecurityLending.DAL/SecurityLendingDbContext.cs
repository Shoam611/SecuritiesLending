using SecurityLending.models;
using Microsoft.EntityFrameworkCore;

namespace SecurityLending.DAL
{
    public class SecurityLendingDbContext :DbContext ,ISecurityLendingDbContext<Lender>, ISecurityLendingDbContext<Borrower>, ISecurityLendingDbContext<Lead>
    {
        public SecurityLendingDbContext(DbContextOptions<SecurityLendingDbContext> options)
            : base(options) {  }

        public DbSet<Lender> Lenders{ get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Lead> Leads{ get; set; }

        DbSet<Lender> ISecurityLendingDbContext<Lender>.List { get ; set ; }
        DbSet<Lead> ISecurityLendingDbContext<Lead>.List { get; set; }
        DbSet<Borrower> ISecurityLendingDbContext<Borrower>.List { get; set; }
    }
}
