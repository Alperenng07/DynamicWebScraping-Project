using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }

        public DbSet<FCurrency> FCurrencys { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ProcessSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessSaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                }
            }
        }
    }
}
