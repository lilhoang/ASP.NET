using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
            //1. lấy danh sách dữ liệu trong bảng
            BanHang_TestEntities db = new BanHang_TestEntities();
            List<KhachHang> danhSachKhachHang = db.KhachHangs.ToList();
            return View(danhSachKhachHang);
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(KhachHang model)
        {
            //2. Thêm mới bản ghi
            BanHang_TestEntities db = new BanHang_TestEntities();
            db.KhachHangs.Add(model);
            //lưu lại thay đổi
            db.SaveChanges();

            return RedirectToAction("DanhSachKhach");

        }

        public ActionResult CapNhat(int id)
        {
            //3. Tìm đối tượng theo ID
            BanHang_TestEntities db = new BanHang_TestEntities();
            KhachHang model = db.KhachHangs.Find(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult CapNhat(KhachHang model)
        {
            BanHang_TestEntities db = new BanHang_TestEntities();
            // tìm đối tượng
            var updateModel = db.KhachHangs.Find(model.ID);
            // Gán Giá Trị 
            updateModel.SoDienThoai = model.SoDienThoai;
            updateModel.TenKhachHang = model.TenKhachHang;
            updateModel.DiaChi = model.DiaChi;
            updateModel.idLoaiKhachHang = model.idLoaiKhachHang;

            //lưu thay đổi

            db.SaveChanges();

            return RedirectToAction("DanhSachKhach");

        }

        public ActionResult Xoa(int id)
        {
            BanHang_TestEntities db = new BanHang_TestEntities();

            var updateModel = db.KhachHangs.Find(id);
            //Lệnh Xóa
            db.KhachHangs.Remove(updateModel);

            db.SaveChanges();

            return RedirectToAction("DanhSachKhach");
        }

        public ActionResult XoaKhachHangTheoNhom(int idLoaiKhachHang)
        {
            // 1: Xóa dữ liệu bảng cần xóa : loại khách hàng
            BanHang_TestEntities db = new BanHang_TestEntities();
            var modelLoaiKhachHang = db.LoaiKhachHangs.Find(idLoaiKhachHang);
            db.LoaiKhachHangs.Remove(modelLoaiKhachHang);
            db.SaveChanges();
            // 2: Xóa bảng con liên quan: Khách hàng: xóa luôn các Khách hàng thuộc nhóm đó
            var danhSachKhachHangThuocNhom = db.KhachHangs.Where(m=>m.idLoaiKhachHang == idLoaiKhachHang).ToList();
            db.KhachHangs.RemoveRange(danhSachKhachHangThuocNhom);
            db.SaveChanges();
            // Xóa lẻ:
            foreach(var KhachHang in danhSachKhachHangThuocNhom) 
            {
                if(KhachHang.DiaChi == "TN")
                {
                    db.KhachHangs.Remove(KhachHang);
                }    
            }
            db.SaveChanges();

            return RedirectToAction("DanhSachKhach");
        }   
    }
}