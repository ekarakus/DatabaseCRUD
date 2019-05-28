using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DatabaseCRUD.Controllers
{
    public class personelController : Controller
    {
        private readonly Db _context;

        public personelController(Db context)
        {
            _context = context;
        }

        public IActionResult Duzenle(int id)
        {
            personel p = _context
                .personeller
                .Where(x => x.personelNo == id)
                .FirstOrDefault();

            ViewBag.cinsiyetler =
                new SelectList(_context.cinsiyetler.ToList(),
                "cinsiyetId", "cinsiyetAdi");

            return View(p);
        }
        [HttpPost]
        public IActionResult Duzenle(personel p)
        {
            ViewBag.cinsiyetler =
                  new SelectList(_context.cinsiyetler.ToList(),
                  "cinsiyetId", "cinsiyetAdi");
            if (ModelState.IsValid)
            {
                _context.personeller.Update(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Sil(int id)
        {
            //no bilgisine denk gelen personel elde ediliyor
            personel p = _context
                .personeller
                .Where(x => x.personelNo == id)
                .FirstOrDefault();
            //kayıt silindi olarak işaretleniyor
            _context.personeller.Remove(p);
            //veritabanı güncelleniyor
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            List<personel> elemanlar = _context
                .personeller
                .Include(x => x.cinsiyet)
                .ToList();
            return View(elemanlar);
        }

        public IActionResult Ekle()
        {
            ViewBag.cinsiyetler =
                new SelectList(_context.cinsiyetler.ToList(),
                "cinsiyetId", "cinsiyetAdi");
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(personel p)
        {
            if (ModelState.IsValid)
            {
                //hata yok ekleme işlemi yap
                _context.personeller.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cinsiyetler =
               new SelectList(_context.cinsiyetler.ToList(),
               "cinsiyetId", "cinsiyetAdi");
            return View();
        }
    }
}