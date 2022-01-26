using DiscountCalculator.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountCalculator.Service
{
    public class ApiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
