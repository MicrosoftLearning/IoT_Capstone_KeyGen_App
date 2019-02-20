using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IoT.Capstone.KeyGen.Admin.Models
{
    // database details
    // iotmppkeygen.database.windows.net
    // server admin - keygenboss
    // password: GJXCKXc6cA4f
    // region: West US 2
    // db: KeyGenDB
    // Server=tcp:iotmppkeygen.database.windows.net,1433;Initial Catalog=KeyGenDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
    // Server=tcp:iotmppkeygen.database.windows.net,1433;Initial Catalog=KeyGenDB;Persist Security Info=False;User ID=keygenboss;Password=GJXCKXc6cA4f;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
    public class KeyGenContext :DbContext
    {
        public KeyGenContext(DbContextOptions<KeyGenContext> options)
            : base(options)
        { }

        public DbSet<EdxUser> EdxUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EdxUser>()
                .HasIndex(b => b.EdxId)
                .IsUnique();
        }
    }
}
