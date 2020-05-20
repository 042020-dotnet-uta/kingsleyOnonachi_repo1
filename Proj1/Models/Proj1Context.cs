using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proj1.Data;
using Proj1.Models;


namespace Proj1.Models
{
    public class Proj1Context : DbContext
    {
        public Proj1Context(DbContextOptions<Proj1Context> options) :
            base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    base.OnModelCreating(modelbuilder);

        //    modelbuilder.Entity<OrderList>()
        //        .HasOne<Order> ("OrderID")
        //        .WithMany()
        //        .HasForeignKey("OrderID")
        //        .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
        //}
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DefaultStore> Defaultstore { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<OrderList> Orderlist { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Order> Order { get; set; }
         
    }
}
