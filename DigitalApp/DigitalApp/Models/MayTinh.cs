using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalApp.Models
{
    public class MayTinh
    {
        public string MaMay { get; set; }
        public string DongMay { get; set;}
        public double GiaBan { get; set;}
        public DateTime NgaySanXuat { get; set;}

        public string HangSanXuat { get; set;}

        public List<MayTinh> KhoiTao5May()
        {
            List<MayTinh> danhSachMayTinh = new List<MayTinh>();
            MayTinh may1 = new MayTinh();
            may1.MaMay = "001";
            may1.DongMay = "Gaming";
            may1.GiaBan = 20000000;
            may1.NgaySanXuat = new DateTime(2022, 12, 1);
            may1.HangSanXuat = "Acer";

            danhSachMayTinh.Add(may1);

            MayTinh may2 = new MayTinh();
            may2.MaMay = "002";
            may2.DongMay = "Gaming";
            may2.GiaBan = 30000000;
            may2.NgaySanXuat = new DateTime(2022, 4, 3);
            may2.HangSanXuat = "Dell";

            danhSachMayTinh.Add(may2);

            MayTinh may3 = new MayTinh();
            may3.MaMay = "003";
            may3.DongMay = "Office";
            may3.GiaBan = 20000000;
            may3.NgaySanXuat = new DateTime(2022, 12, 14);
            may3.HangSanXuat = "Lenovo";

            danhSachMayTinh.Add(may3);


            MayTinh may4 = new MayTinh();
            may4.MaMay = "004";
            may4.DongMay = "Gaming";
            may4.GiaBan = 20000000;
            may4.NgaySanXuat = new DateTime(2022, 12, 1);
            may4.HangSanXuat = "Asus";

            danhSachMayTinh.Add(may4);

            MayTinh may5 = new MayTinh();
            may5.MaMay = "005";
            may5.DongMay = "Gaming";
            may5.GiaBan = 20000000;
            may5.NgaySanXuat = new DateTime(2022, 12, 1);
            may5.HangSanXuat = "Acer";

            danhSachMayTinh.Add(may5);

            return danhSachMayTinh;

        }
    }
}