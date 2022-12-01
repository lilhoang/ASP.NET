using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using DigitalApp.Models;

namespace DigitalApp.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult DanhSachKhach()
        {
            return View(DanhSachKhachHang.dsKhachHang);
        }

        public ActionResult ThemMoi()
        {
            return View(new KhachHang() { ID = 0});
        }

        [HttpPost]
        public ActionResult ThemMoi(KhachHang model, HttpPostedFileBase fileAnh)
        {
            if(model.ID == 0)
            {
                ModelState.AddModelError("", "ID phải nhập lớn hơn 0");
                return View(model);
            }
            if(fileAnh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Data/");

                string pathImage = rootFolder + fileAnh.FileName;

                fileAnh.SaveAs(pathImage);

                model.UrlHinhAnh= "/Data/" +fileAnh.FileName;
            }    


            DanhSachKhachHang.dsKhachHang.Add(model);


            return RedirectToAction("DanhSachKhach");
        }

        public ActionResult CapNhat(int idKhachHang)
        {
            //tìm ra đối tg khách hàng cần sửa
            var KhachHang = DanhSachKhachHang.dsKhachHang.SingleOrDefault(m => m.ID == idKhachHang);
            //truyền thông tin đối tg cần sửa sang view
            return View(KhachHang);
        }

        [HttpPost]
        public ActionResult CapNhat(KhachHang model, HttpPostedFileBase fileAnh)
        {
            if(string.IsNullOrEmpty(model.Name)== true)
            {
                ModelState.AddModelError("", "Bạn chưa nhập tên khách hàng");
            }
            if (fileAnh.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Data/");

                string pathImage = rootFolder + fileAnh.FileName;

                fileAnh.SaveAs(pathImage);

                model.UrlHinhAnh = "/Data/" + fileAnh.FileName;
            }
            //tìm đối tg cần sửa
            var KhachHang = DanhSachKhachHang.dsKhachHang.SingleOrDefault(m => m.ID == model.ID);
            // Cập nhật dữ liệu mới cho đối tượng cần sửa
            KhachHang.Name = model.Name;
            KhachHang.PhoneNumber = model.PhoneNumber;
            KhachHang.Email = model.Email;
            KhachHang.Sex= model.Sex;
            KhachHang.UrlHinhAnh = model.UrlHinhAnh;

            return RedirectToAction("DanhSachKhach");
        }


        
        public ActionResult Xoa(int idKhachhang)
        {
            //tìm đối tg cần Xoa
            var KhachHang = DanhSachKhachHang.dsKhachHang.SingleOrDefault(m => m.ID == idKhachhang);
            //thực hiện xóa
            DanhSachKhachHang.dsKhachHang.Remove(KhachHang);
            return RedirectToAction("DanhSachKhach");
        }
    }
}