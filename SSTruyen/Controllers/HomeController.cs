using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using SSTruyen.Areas.admin.Controllers;
using SSTruyen.Models;

namespace SSTruyen.Controllers
{
    public class HomeController : Controller
    {
        private XuLy tool = new XuLy();
        private TruyenDBContext db = new TruyenDBContext();
        // GET: Home
        public ActionResult Index()
        {
            var listTheLoai = db.TheLoais.ToList();
            ViewBag.listTheLoai = listTheLoai;
            ViewBag.listTruyen = db.Truyens.ToList();
            ViewBag.listHot = tool.getTruyenHay();
            ViewBag.listNew = tool.getChapMoi();
            return View();
        }

        // GET: Home/Truyen/id
        public ActionResult Truyen(string id)
        {
            var listTheLoai = db.TheLoais.ToList();
            ViewBag.listTheLoai = listTheLoai;
            ViewBag.listChap = tool.listChapTheoTruyen(id);
            var theloaitruyen = tool.listTheLoai(id);
            string res = "";
            foreach(var x in theloaitruyen)
            {
                res = res + x + ",";
            }
            res = res.Substring(0, res.Length - 1);
            ViewBag.theloai = res;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.truyen = db.Truyens.Find(id);
            return View();
        }

        // GET: Home/Chap/id
        public ActionResult Chap(int id)
        {
            var listTheLoai = db.TheLoais.ToList();
            ViewBag.listTheLoai = listTheLoai;
            var chap = db.ChapTruyens.Find(id);
            ViewBag.chap = chap;
            ViewBag.tentruyen = tool.getTenTruyen(db.ChapTruyens.Find(id).IDtruyen);
            ViewBag.idtruyen = tool.getIDTruyen(tool.getTenTruyen(db.ChapTruyens.Find(id).IDtruyen));
            return View();
        }

        // GET: Home/theloai/id
        public ActionResult Theloai(int id)
        {
            var listTheLoai = db.TheLoais.ToList();
            ViewBag.listTheLoai = listTheLoai;
            ViewBag.listtruyen = tool.listTheLoaiTruyen(id);
            return View();
        }


    }
}
