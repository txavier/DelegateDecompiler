﻿// Contributed by @JonPSmith (GitHub) www.thereformedprogrammer.com

using System.Data.Entity;

namespace DelegateDecompiler.EntityFramework.Tests.EfItems
{
    public class EfTestDbContext : DbContext
    {
        static EfTestDbContext() 
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfTestDbContext>()); 
        }

        public EfTestDbContext() : base("name=DelegateDecompilerEfTestDb") { }

        public DbSet<EfParent> EfParents { get; set; }
        public DbSet<EfChild> EfChildren { get; set; }
        public DbSet<EfGrandChild> EfGrandChildren { get; set; }

        public DbSet<EfPerson> EfPersons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EfPerson>().Computed(x => x.FullNameNoAttibute);
            modelBuilder.Entity<EfPerson>().Computed(x => x.GetFullNameNoAttibute());
            base.OnModelCreating(modelBuilder);
        }

    }
}
