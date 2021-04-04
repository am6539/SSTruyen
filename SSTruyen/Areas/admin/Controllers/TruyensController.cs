using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SSTruyen.Models;

namespace SSTruyen.Areas.admin.Controllers
{
    public class TruyensController : Controller
    {
        private TruyenDBContext db = new TruyenDBContext();

        // GET: admin/Truyens
        public ActionResult Index()
        {
            return View(db.Truyens.ToList());
        }

        // GET: admin/Truyens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truyen truyen = db.Truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // GET: admin/Truyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Truyens/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTruyen,tentruyen,tacgia,nguon,trangthai,yeuthich,gioithieu")] Truyen truyen, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string urlImage = Server.MapPath("~/Assets/image/" + fileName);
                        file.SaveAs(urlImage);
                    }
                    ViewBag.FileStatus = "Tạo truyện mới thành công.";
                }
                catch (Exception)
                {
                    ViewBag.FileStatus = "Lỗi upload ảnh.";
                }
                truyen.anh = file.FileName;
                db.Truyens.Add(truyen);
                db.SaveChanges();
            }
            return View(truyen);
        }

        // GET: admin/Truyens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truyen truyen = db.Truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // POST: admin/Truyens/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTruyen,tentruyen,tacgia,nguon,trangthai,yeuthich,gioithieu,anh")] Truyen truyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(truyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(truyen);
        }

        // GET: admin/Truyens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Truyen truyen = db.Truyens.Find(id);
            if (truyen == null)
            {
                return HttpNotFound();
            }
            return View(truyen);
        }

        // POST: admin/Truyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Truyen truyen = db.Truyens.Find(id);
            db.Truyens.Remove(truyen);
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
