using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HoangLuong.Data;
using System;
using System.Linq;

namespace HoangLuong.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HoangLuongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HoangLuongContext>>()))
            {
                // Look for any movies.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        Id = "EM001",
                        Name = "John Carter",
                        Department = "HR",
                        Salary = 3000
                    },

                    new Employee
                    {
                        Id = "EM002",
                        Name = "Michael Bean",
                        Department = "SC",
                        Salary = 1300
                    },

                    new Employee
                    {
                        Id = "EM003",
                        Name = "Jimmy Floy",
                        Department = "MD",
                        Salary = 2000
                    },

                    new Employee
                    {
                        Id = "EM004",
                        Name = "Mary Brown",
                        Department = "MD",
                        Salary = 2000
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
