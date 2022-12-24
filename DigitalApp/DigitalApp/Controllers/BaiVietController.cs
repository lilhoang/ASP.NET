using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalApp.Models;
namespace DigitalApp.Controllers
{
    public class BaiVietController : Controller
    {
        // GET: BaiViet
        public ActionResult DanhSach()
        {
            BanHang_TestEntities db = new BanHang_TestEntities();
            return View(db.BaiViets.ToList());
        }

        public ActionResult ThemMoi()
        {
            return View(new BaiViet());
        }
        [HttpPost]
        public ActionResult ThemMoi(BaiViet model)
        {
            BanHang_TestEntities db = new BanHang_TestEntities();
            if (string.IsNullOrEmpty(model.TenBaiViet))
            {
                ModelState.AddModelError("", "Thiếu tên bài viết");
                return View(model);
            }
            db.BaiViets.Add(model);
            db.SaveChanges();

            return RedirectToAction("DanhSach");

        }
    }
}