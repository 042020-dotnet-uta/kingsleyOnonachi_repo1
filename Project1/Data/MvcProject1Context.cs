using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using MvcProject1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MvcProject1.Data
{
    public class MvcProject1Context :DbContext
    {
        public MvcProject1Context(DbContextOptions<MvcProject1Context> options):
            base(options)
        {

        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Defaultstore> Defaultstore { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orderlist> Orderlist { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<Orders> Order { get; set; }


    }
}
