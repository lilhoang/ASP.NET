using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalApp.Helper;
using DigitalApp.Models;

namespace DigitalApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // GET: Home
        public ActionResult Index()
        {           
          return View(ListMayTinh.listMayTinh);
        }
        public ActionResult AddMayTinh() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMayTinh(string maMay, string dongMay, double giaBan, DateTime ngaySanXuat, string hangSanXuat)
        {
            ListMayTinh.listMayTinh.Add(new MayTinh()
            {
                MaMay = maMay,
                DongMay = dongMay,
                GiaBan = giaBan,
                NgaySanXuat = ngaySanXuat,
                HangSanXuat = hangSanXuat,
            });
            return RedirectToAction("Index");
        }
        
        public ActionResult ThemMoi2()
        {
            return View(new MayTinh() { GiaBan = 0, NgaySanXuat = DateTime.Now} );
        }

        [HttpPost]
        public ActionResult ThemMoi2(MayTinh model)
        {
            //ListMayTinh.listMayTinh.Add(new MayTinh()
            //{
            //    MaMay = model.MaMay,
            //    DongMay = model.DongMay,
            //    GiaBan = model.GiaBan,
            //    NgaySanXuat = model.NgaySanXuat,
            //    HangSanXuat = model.HangSanXuat,
            //});
            if(ModelState.IsValid == true)
            {
                ListMayTinh.listMayTinh.Add(model);
                return RedirectToAction("Index");
            }    
            else
            {
                //Kèm thông báo lỗi
                ModelState.AddModelError("","Bạn chưa nhập đủ dữ liệu");
                return View(model);
            }    
        }

    }
}


        