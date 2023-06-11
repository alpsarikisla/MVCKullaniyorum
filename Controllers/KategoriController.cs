using MVCKullaniyorum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKullaniyorum.Controllers
{
    public class KategoriController : Controller
    {
        veksisbu_nrthwndEntities db = new veksisbu_nrthwndEntities();
        // GET: Kategori
        //Genelde Listeleme işlemleri için Index Kullanılır
        public ActionResult Index()
        {
            List<Categories> kategoriler = db.Categories.ToList();
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(string Isim, string aciklama)
        {
            Categories c = new Categories();
            c.CategoryName = Isim;
            c.Description = aciklama;
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories c)
        {
            try
            {
                int sayi = db.Categories.Count(x => x.CategoryName == c.CategoryName);
                if (sayi == 0)
                {
                    db.Categories.Add(c);
                    db.SaveChanges();
                    ViewBag.sonuc = "Basarili";
                }
                else
                {
                    ViewBag.sonuc = "Basarisiz";
                }
                
            }
            catch
            {
                ViewBag.sonuc = "Basarisiz";
            }
            return View(c);
        }
    }
}