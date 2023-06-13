using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHouse.Model.Data
{
    public class StoreHouseContext: DbContext
    {
        public StoreHouseContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Manager> Managers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ChangeStatus> ChangeStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=WIN-CHQUHPO6EJL\\SQLEXPRESS;Database=StoreHouse;Trusted_Connection=true;;MultipleActiveResultSets=true; TrustServerCertificate=true");            
        }
    }
}
