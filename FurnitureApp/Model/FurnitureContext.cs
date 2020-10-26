using FurnitureApp.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FurnitureApp.Model
{
    public class FornitureContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> Equipment_types { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public FornitureContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["OldMysqlConnection"].ConnectionString);
        }
    }
}
