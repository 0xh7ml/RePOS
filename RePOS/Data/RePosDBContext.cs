using Microsoft.EntityFrameworkCore;
using RePOS.Models;
using System.Collections.Generic;
using System.Linq;


namespace RePOS.Data
{
    public class RePosDBContext: DbContext
    {
        public RePosDBContext(DbContextOptions<RePosDBContext> options) : base(options){}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
