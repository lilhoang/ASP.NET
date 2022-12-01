using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult ThemMoi(KhachHang model)
        {
            if(model.ID == 0)
            {
                ModelState.AddModelError("", "ID phải nhập lớn hơn 0");
                return View(model);
            }
            DanhSachKhachHang.dsKhachHang.Add(model);


            return RedirectToAction("DanhSachKhach");
        }
    }
}