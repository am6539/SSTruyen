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
    public class ChapTruyensController : Controller
    {
        private TruyenDBContext db = new TruyenDBContext();
        private XuLy tool = new XuLy();

        // GET: admin/ChapTruyens
        public ActionResult Index()
        {
            var truyen = db.Truyens.ToList();
            return View(truyen);
        }

        // GET: admin/ChapTruyens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tentruyen = tool.getTenTruyen(id);
            List<ChapTruyen> listChap = tool.listChapTheoTruyen(id);
            ViewBag.listChap = listChap;
            ViewBag.tentruyen = tentruyen;
            return View();
        }

        // GET: admin/ChapTruyens/Create
        public ActionResult Create()
        {
            ViewBag.IDtruyen = new SelectList(db.Truyens, "IDTruyen", "tentruyen");
            return View();
        }

        // POST: admin/ChapTruyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "stt,IDtruyen,chap,tenchap,noidung")] ChapTruyen chapTruyen)
        {
            if (ModelState.IsValid)
            {
                db.ChapTruyens.Add(chapTruyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDtruyen = new SelectList(db.Truyens, "IDTruyen", "tentruyen", chapTruyen.IDtruyen);
            return View(chapTruyen);
        }

        // GET: admin/ChapTruyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChapTruyen chapTruyen = db.ChapTruyens.Find(id);
            if (chapTruyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDtruyen = new SelectList(db.Truyens, "IDTruyen", "tentruyen", chapTruyen.IDtruyen);
            return View(chapTruyen);
        }

        // POST: admin/ChapTruyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "stt,IDtruyen,chap,tenchap,noidung")] ChapTruyen chapTruyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chapTruyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDtruyen = new SelectList(db.Truyens, "IDTruyen", "tentruyen", chapTruyen.IDtruyen);
            return View(chapTruyen);
        }

        // GET: admin/ChapTruyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChapTruyen chapTruyen = db.ChapTruyens.Find(id);
            if (chapTruyen == null)
            {
                return HttpNotFound();
            }
            return View(chapTruyen);
        }

        // POST: admin/ChapTruyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChapTruyen chapTruyen = db.ChapTruyens.Find(id);
            db.ChapTruyens.Remove(chapTruyen);
            db.SaveChanges();
            return RedirectToAction("Index");
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
