using Microsoft.EntityFrameworkCore;
using RePOS.Models;
using System.Collections.Generic;
using System.Linq;


namespace RePOS.Data
{
    public class RePosDBContext: DbContext
    {
        public RePosDBContext(DbContextOptions<RePosDBContext> options) : base(options){}
        public DbSet<TbCategory> Categories { get; set; }
        public DbSet<TbItem> Items { get; set; }
        public DbSet<TbOrder> Orders { get; set; }
        public DbSet<TbOrderItem> OrderItems { get; set; }
        public DbSet<TbStaff> Staff { get; set; }
        public DbSet<TbPaymentMethod> PaymentMethods { get; set; }
    }
}
