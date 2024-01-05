using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CasinoSystem.Data.Entities;
using CasinoSystem.Data.Entities.Base;

namespace CasinoSystem.Data.DataContext
{
    public class CasinoContext :  IdentityDbContext<ApplicationUser, CasinoRole, int>
    {
        public CasinoContext(DbContextOptions<CasinoContext> options)
      : base(options)
        { }
        public CasinoContext() : base() { }

        public DbSet<Bonus> Bonuses { get; set; }
        public IQueryable<TEntity> ReaderSet<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>().AsQueryable();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<CasinoRole>().ToTable("CasinoRole");

            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");


        }
    }
}