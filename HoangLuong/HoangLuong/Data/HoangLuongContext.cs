using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoangLuong.Models;

namespace HoangLuong.Data
{
    public class HoangLuongContext : DbContext
    {
        public HoangLuongContext (DbContextOptions<HoangLuongContext> options)
            : base(options)
        {
        }

        public DbSet<HoangLuong.Models.Employee> Employee { get; set; } = default!;
    }
}
