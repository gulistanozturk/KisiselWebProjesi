using KisiselWebProjesi.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebProjesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.homePages.ToList();
            return View(deger);
        }

        public ActionResult AnaSayfaGetir(int id)
        {
            var ag = c.homePages.Find(id);

            return View("AnaSayfaGetir", ag);
        }

        public ActionResult AnaSayfaGüncelle(HomePage homePage)
        {
            var hp = c.homePages.Find(homePage.id);
            hp.isim = homePage.isim;
            hp.profil = homePage.profil;
            hp.unvan = homePage.unvan;
            hp.aciklama = homePage.aciklama;
            hp.iletisim = homePage.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ikonList()
        {

            var deger = c.icons.ToList();
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniIkon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniIkon(icons p)
        {
            c.icons.Add(p);
            c.SaveChanges();
            return RedirectToAction("ikonList");
        } 

        public ActionResult ikonGetir(int id)
        {
            var ig = c.icons.Find(id);
            return View("ikonGetir", ig);
        }


        public ActionResult ikonGüncelle(icons x)
        {

            var ig = c.icons.Find(x.id);
            ig.icon = x.icon;
            ig.link = x.link;
            c.SaveChanges() ;
            return RedirectToAction("ikonlist");
        }

        public ActionResult ikonSil(int id)
        {
            var sl = c.icons.Find(id);
            c.icons.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("ikonList");
        }
    }
}