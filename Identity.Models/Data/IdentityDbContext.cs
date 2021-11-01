using Identity.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyFirstOpenIddict.Common.Data.EFCore;

namespace Identity.Models.Data
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public DatabaseSettings DatabaseSettings { get; private set; }

        public IdentityDbContext(DbContextOptions<IdentityDbContext> contextOptions, IOptions<DatabaseSettings> options) : base(contextOptions)
        {
            DatabaseSettings = options.Value;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            TableConfiguration(modelBuilder);
            SetAuditableConfiguration(modelBuilder);
            //SeedData(modelBuilder);
        }

        //private void SeedData(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.DefaultSystemUserData();
        //    modelBuilder.DefaultSystemRoleData();
        //}

        private void TableConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(t =>
            {
                t.HasOne(c => c.UserProfile).WithOne(c => c.User).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<UserProfile>(t =>
            {
                t.HasIndex(f => f.EmployeeCode).IsUnique().HasDatabaseName("Idx_UserProfile_EmployeeCode");
            });

            
        }

        private void SetAuditableConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuditableConfiguration<User>());
            modelBuilder.ApplyConfiguration(new AuditableConfiguration<UserProfile>());

            modelBuilder.ApplyConfiguration(new SchemaTableConfiguration<User>(DatabaseSettings.DefaultSchema));
            modelBuilder.ApplyConfiguration(new SchemaTableConfiguration<UserProfile>(DatabaseSettings.DefaultSchema));
        }

    }
}
