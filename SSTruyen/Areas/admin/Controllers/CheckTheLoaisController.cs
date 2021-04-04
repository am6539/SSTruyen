using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSTruyen.Models;

namespace SSTruyen.Areas.admin.Controllers
{
    public class CheckTheLoaisController : Controller
    {
        private TruyenDBContext db = new TruyenDBContext();
        private XuLy tool = new XuLy();

        // GET: admin/CheckTheLoais
        public ActionResult Index()
        {
            return View(db.Truyens.ToList());
        }

        // GET: admin/CheckTheLoais/Details/5
        public ActionResult Details(string id)
        {
            Truyen mytruyen = db.Truyens.Find(id);
            List<string> listTheLoai = tool.listTheLoai(id);
            ViewBag.listTheLoai = listTheLoai;
            return View(mytruyen);
        }

        // GET: admin/CheckTheLoais/Create
        public ActionResult Create()
        {
            ViewBag.IDtruyen = new SelectList(db.Truyens, "IDTruyen", "tentruyen");
            ViewBag.IDtheloai = new SelectList(db.TheLoais, "IDtheloai", "theloai1");
            
            return View();
        }



        // POST: admin/CheckTheLoais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,IDtheloai,IDtruyen")] CheckTheLoai checkTheLoai)
        {
            if (ModelState.IsValid)
            {
                db.CheckTheLoais.Add(checkTheLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDtheloai = new SelectList(db.TheLoais, "IDtheloai", "theloai1", checkTheLoai.IDtheloai);
            ViewBag.IDtruyen = new SelectList(db.Truyens, "IDTruyen", "tentruyen", checkTheLoai.IDtruyen);
            return View(checkTheLoai);
        }

        // GET: admin/CheckTheLoais/Delete/5
        public ActionResult Delete(string tentruyen,string theloai)
        {
            int idCheck = tool.findIDCheck(tentruyen, theloai);
            var Check = db.CheckTheLoais.Find(idCheck);
            var idTruyen = tool.getIDTruyen(tentruyen);
            db.CheckTheLoais.Remove(Check);
            db.SaveChanges();
            return RedirectToAction(idTruyen,"Checktheloais/Details");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
