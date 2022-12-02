using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;
using WorldCupCRUD.Controllers;
using WorldCupCRUD.Models;

namespace WorldCupCRUD.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult DanhSachTran()
        {
            return View(ListMatchs.listMatchs);
        }

        public ActionResult ThemMoi()
        {
            return View(new Matchs() { ID = 0});
        }

        [HttpPost]
        public ActionResult ThemMoi(Matchs model, HttpPostedFileBase fileAnh, HttpPostedFileBase fileAnh2)
        {
            if(model.ID == 0)
            {
                ModelState.AddModelError("", "ID phải nhập lớn hơn 0");
                return View(model);
            }    
            if(fileAnh.ContentLength>0)
            {
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model.UrlHinhAnh = "/Data/" + fileAnh.FileName; 
            }
            if (fileAnh2.ContentLength > 0)
            {
                string rootFolder = Server.MapPath("/Data2/");
                string pathImage = rootFolder + fileAnh2.FileName;
                fileAnh2.SaveAs(pathImage);
                model.UrlHinhAnh2 = "/Data2/" + fileAnh2.FileName;
            }

            ListMatchs.listMatchs.Add(model);

            return RedirectToAction("DanhSachTran");
        }

        public ActionResult CapNhat(int idMatch)
        {
            var Matchs = ListMatchs.listMatchs.SingleOrDefault(m => m.ID == idMatch); 

            return View(Matchs);
        }

        [HttpPost]
        public ActionResult CapNhat(Matchs model, HttpPostedFileBase fileAnh, HttpPostedFileBase fileAnh2) 
        {
            if (fileAnh.ContentLength>0)
            {
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileAnh.FileName;
                fileAnh.SaveAs(pathImage);
                model.UrlHinhAnh = "/Data/" + fileAnh.FileName;
            }
            if (fileAnh2.ContentLength>0)
            {
                string rootFolder = Server.MapPath("/Data2/");
                string pathImage = rootFolder + fileAnh2.FileName;
                fileAnh2.SaveAs(pathImage);
                model.UrlHinhAnh2 = "/Data2/" + fileAnh2.FileName;
            }

            var Matchs = ListMatchs.listMatchs.SingleOrDefault(m => m.ID == model.ID);

            Matchs.Team1= model.Team1;
            Matchs.Team2= model.Team2;
            Matchs.UrlHinhAnh = model.UrlHinhAnh;
            Matchs.UrlHinhAnh2 = model.UrlHinhAnh2;
            Matchs.Score = model.Score;

            return RedirectToAction("DanhSachTran");

        }

        public ActionResult Xoa(int idMatch)
        {
            var Matchs = ListMatchs.listMatchs.SingleOrDefault(m => m.ID == idMatch);

            ListMatchs.listMatchs.Remove(Matchs);
            return RedirectToAction("DanhSachTran");
        }

    }
}