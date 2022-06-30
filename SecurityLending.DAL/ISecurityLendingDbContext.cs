using Microsoft.EntityFrameworkCore;
using SecurityLending.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLending.DAL
{
   public interface ISecurityLendingDbContext<T> where T: Customer
    {
        public DbSet<T> List { get; set; }

        public int SaveChanges();
    }
}
