using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using VehicleManager.API.Models;

namespace VehicleManager.API.Data
{
    public class VehicleManagerDataContext : DbContext 
    {
        // Constructor
        public VehicleManagerDataContext() : base("VehicleManager")
        {

        }

        //DbSets
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Sale> Sales { get; set; }
        public IDbSet<Vehicle> Vehicles { get; set; }

        // model Configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // vehice has many sales
            modelBuilder.Entity<Vehicle>()
                .HasMany(Vehicle => Vehicle.Sales)
                .WithRequired(sale => sale.Vehicle)
                .HasForeignKey(sale => sale.VehicleId);

            // Customer has many sales
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Sales)
                .WithRequired(sale => sale.Customer)
                .HasForeignKey(sale => sale.CustomerId);
        }

    }
}