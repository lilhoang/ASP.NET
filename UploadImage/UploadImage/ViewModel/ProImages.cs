using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using UploadImage.Models;

namespace UploadImage.ViewModel
{
    public class ProImages
    {

        public List<IFormFile> Images { get; set; }

        public Product Product { get; set; }

    }
}
