using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UploadImage.Models;

namespace UploadImage.Models
{
    
    public class ProductImage
    {
        public int Id { get; set; }

        public string? ImageUrl { get; set; }

        public Product? Product { get; set; }

    }
}
