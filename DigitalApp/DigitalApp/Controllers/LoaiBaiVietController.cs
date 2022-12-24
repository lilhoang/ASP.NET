using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalApp.Models;

namespace DigitalApp.Controllers
{
    public class LoaiBaiVietController : Controller
    {
        // GET: LoaiBaiViet
        public ActionResult DanhSach()
        {
            BanHang_TestEntities db = new BanHang_TestEntities();
            return View(db.LoaiBaiViets.ToList());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(LoaiBaiViet model)
        {
            if(string.IsNullOrEmpty (model.TenLoai) == true)
            {
                ModelState.AddModelError("", "Thiếu Thông Tin Tên loại bài viết");
                return View(model);
            }
            BanHang_TestEntities db = new BanHang_TestEntities();

            try
            {
                db.LoaiBaiViets.Add(model);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }  
            
        }

        public ActionResult CapNhat(int id)
        {
            BanHang_TestEntities db = new BanHang_TestEntities();
            var model = db.LoaiBaiViets.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult CapNhat(LoaiBaiViet model)
        {
            if (string.IsNullOrEmpty(model.TenLoai) == true)
            {
                ModelState.AddModelError("", "Thiếu Thông Tin Tên loại bài viết");
                return View(model);
            }
            BanHang_TestEntities db = new BanHang_TestEntities();
            var updateModel = db.LoaiBaiViets.Find(model.ID);

            try
            {
                updateModel.TenLoai = model.TenLoai;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

        }

        public ActionResult Xoa(int id)
        {
            BanHang_TestEntities db = new BanHang_TestEntities();
            var model = db.LoaiBaiViets.Find(id);
            db.LoaiBaiViets.Remove(model);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}