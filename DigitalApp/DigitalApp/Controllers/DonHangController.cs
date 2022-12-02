
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalApp.Models;

namespace DigitalApp.Controllers
{
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult DanhSachHang()
        {
            return View(StaticDonHang.DanhSachDonHang);
        }

        public ActionResult ThemDonHang()
        {
            return View(new DonHang());
        }


        [HttpPost]
        public ActionResult ThemDonHang(DonHang model)
        {
            StaticDonHang.DanhSachDonHang.Add(model);
            return RedirectToAction("DanhSachHang");
        }

        public ActionResult CapNhatDonHang(int idDonHang)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == idDonHang);
            return View(updateModel);
        }


        [HttpPost]
        public ActionResult CapNhatDonHang(DonHang model)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == model.ID);
            updateModel.Name = model.Name;
            updateModel.NgayDatHang = model.NgayDatHang;
            updateModel.Address = model.Address;
            updateModel.PhoneNumber = model.PhoneNumber;


            return RedirectToAction("DanhSachHang");
        }

        public ActionResult XoaDonHang(int idDonHang)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == idDonHang);
            StaticDonHang.DanhSachDonHang.Remove(updateModel);
            return RedirectToAction("DanhSachHang");
        }
        public ActionResult ChiTiet(int idDonHang)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == idDonHang);
            return View(updateModel);
        }

        public ActionResult ThemChiTiet(int idDonHang)
        {
            ViewBag.idDonHang = idDonHang;
            return View(new MayTinh());
        }

        [HttpPost]
        public ActionResult ThemChiTiet(MayTinh model, int idDonHang)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m=> m.ID == idDonHang);
            updateModel.MayTinhDatMua.Add(model);
            return RedirectToAction("ChiTiet", new {idDonHang = idDonHang});
        }

        public ActionResult CapNhatChiTiet(int idDonHang, string maMay)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == idDonHang);
            var mayTinhCanSua = updateModel.MayTinhDatMua.SingleOrDefault(m=> m.MaMay== maMay);
            ViewBag.idDonHang = idDonHang;
            return View(mayTinhCanSua);
        }
        [HttpPost]
        public ActionResult CapNhatChiTiet(MayTinh model, int idDonHang)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == idDonHang);
            var mayTinhCanSua = updateModel.MayTinhDatMua.SingleOrDefault(m => m.MaMay == model.MaMay);
            mayTinhCanSua.NgaySanXuat = model.NgaySanXuat;
            mayTinhCanSua.DongMay = model.DongMay;
            mayTinhCanSua.HangSanXuat = model.HangSanXuat;
            mayTinhCanSua.GiaBan = model.GiaBan;
            return RedirectToAction("ChiTiet", new { idDonHang = idDonHang });
        }

        public ActionResult XoaChiTiet(MayTinh model, int idDonHang)
        {
            var updateModel = StaticDonHang.DanhSachDonHang.SingleOrDefault(m => m.ID == idDonHang);
            var mayTinhCanSua = updateModel.MayTinhDatMua.SingleOrDefault(m => m.MaMay == model.MaMay);
            updateModel.MayTinhDatMua.Remove(mayTinhCanSua);
            return RedirectToAction("ChiTiet", new { idDonHang = idDonHang });
        }
    }
}