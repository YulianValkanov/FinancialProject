using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Theatre.Data.Models;
using FinancialServices.Data.Models;
using FinancialServices.Contracts;


namespace FinancialServices.Data
{
  
    public class FinanceDbContext : IdentityDbContext<User>
    {

        public FinanceDbContext(DbContextOptions<FinanceDbContext> options)
            : base(options)
        {
   

        } 

        public DbSet<Company> Companies { get; set; }

        public DbSet<Kid> Kids { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<ReportData> ReportDatas { get; set; }

        public DbSet<MapingCompanyReport> MapingCompanyReports { get; set; }

        public DbSet<MapingManager> MapingManagers { get; set; }

        public DbSet<MapingOwnerPerson> MapingOwnerPersons { get; set; }

        public DbSet<MapingOwnerCompany> MapingOwnerCompanies { get; set; }

        public DbSet<Credit> Credits { get; set; }

        public DbSet<PNL> PNLs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MapingCompanyReport>()
                .HasKey(x => new { x.IdEik, x.ReportId });

            builder.Entity<MapingManager>()
            .HasKey(x => new { x.IdEik, x.IdEgn });


                    builder.Entity<MapingOwnerPerson>()
            .HasKey(x => new { x.IdEik, x.IdEgn });


            builder.Entity<MapingOwnerCompany>()
          .HasKey(x => new { x.IdEik, x.IdEikOwner });


            builder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();


            //builder
            //    .Entity<Genre>()
            //    .HasData(new Genre()
                
            //    });

            base.OnModelCreating(builder);
        }

    
      
    }
}