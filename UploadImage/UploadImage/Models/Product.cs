using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UploadImage.Models;


namespace UploadImage.Models
{
    [PrimaryKey(nameof(Id))]
    public class Product
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<ProductImage>? ProductImage { get; set; }
    }
}
