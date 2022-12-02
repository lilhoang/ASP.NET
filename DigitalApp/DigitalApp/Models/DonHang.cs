using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalApp.Models
{
    public class DonHang
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime NgayDatHang { get; set; }

        public List<MayTinh> MayTinhDatMua = new List<MayTinh>();
    }

}
