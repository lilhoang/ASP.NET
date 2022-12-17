using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HoangLuong.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public int Salary { get; set; }
    }
}
