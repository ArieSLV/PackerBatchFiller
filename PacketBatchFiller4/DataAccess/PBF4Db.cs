using System;
using System.Data.Entity;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class PBF4Db : DbContext
    {
        // Your context has been configured to use a 'PBF4Db' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PacketBatchFiller4.PBF4Db' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PBF4Db' 
        // connection string in the application configuration file.
        public PBF4Db()
            : base("name=PBF4Db")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<BankDetails> BankDetailses { get; set; }
        public virtual DbSet<Citizenship> Citizenships { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(property => property.HasColumnType("datetime2"));
            modelBuilder.Properties<DateTime?>().Configure(property => property.HasColumnType("datetime2"));
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}