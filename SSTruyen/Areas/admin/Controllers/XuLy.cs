using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSTruyen.Models;

namespace SSTruyen.Areas.admin.Controllers
{
    public class XuLy
    {
        private TruyenDBContext db = new TruyenDBContext();
        public XuLy() {}
        public List<string> listTheLoai(string idTruyen)
        {
            List<CheckTheLoai> listCheck = db.CheckTheLoais.ToList();
            List<int> temp = new List<int>();
            foreach (CheckTheLoai x in listCheck)
            {
                if(x.IDtruyen == idTruyen)
                {
                    temp.Add(x.IDtheloai);
                }
            }
            List<string> res = new List<string>();
            List<TheLoai> listTheLoai = db.TheLoais.ToList();
            foreach (int x in temp)
            {
                foreach (TheLoai y in listTheLoai)
                {
                    if (x == y.IDtheloai)
                    {
                        res.Add(y.theloai1);
                    }
                }
            }
            return res;
        }
        public List<string> listAllTheLoai()
        {
            List<string> res = new List<string>();
            List<TheLoai> listTheLoai = db.TheLoais.ToList();
            foreach (TheLoai x in listTheLoai)
            {
                res.Add(x.theloai1);
            }
            return res;
        }
        public string getIDTruyen(string tentruyen)
        {
            string res = "";
            List<Truyen> listTruyen = db.Truyens.ToList();
            foreach (Truyen x in listTruyen)
            {
                if (x.tentruyen == tentruyen)
                {
                    res = x.IDTruyen;
                }
            }
            return res;
        }
        public string getTenTruyen(string IDTruyen)
        {
            string res = "";
            List<Truyen> listTruyen = db.Truyens.ToList();
            foreach (Truyen x in listTruyen)
            {
                if (x.IDTruyen == IDTruyen)
                {
                    res = x.tentruyen;
                }
            }
            return res;
        }
        public int findIDTheLoai(string theloai)
        {
            List<TheLoai> listTheLoai = db.TheLoais.ToList();
            int res = 0;
            foreach (TheLoai x in listTheLoai)
            {
                if (x.theloai1 == theloai)
                {
                    res = x.IDtheloai;
                }
            }
            return res;

        }
        public int findIDCheck(string tentruyen, string theloai)
        {
            List<CheckTheLoai> listCheck = db.CheckTheLoais.ToList();
            int idTheLoai = findIDTheLoai(theloai);
            string idTruyen = getIDTruyen(tentruyen);
            int res = 0;
            foreach (CheckTheLoai x in listCheck)
            {
                if (x.IDtheloai == idTheLoai && x.IDtruyen == idTruyen)
                {
                    res = x.stt;
                }
            }
            return res;
        }
        public List<ChapTruyen> listChapTheoTruyen(string id)
        {
            List<ChapTruyen> listChap = db.ChapTruyens.ToList();
            List<ChapTruyen> res = new List<ChapTruyen>();
            foreach (ChapTruyen x in listChap)
            {
                if (x.IDtruyen == id)
                {
                    res.Add(x);
                }
            }
            return res;
        }
        public List<Truyen> getTruyenHay()
        {
            List<Truyen> listTruyen = db.Truyens.ToList();
            List<Truyen> res = new List<Truyen>();
            var temp = listTruyen.OrderBy(x => x.yeuthich).ToList();
            for(int i = temp.Count - 1; i >= 0; --i)     
            {
                if (i == 7) break;
                res.Add(temp[i]);
            }
            return res;
        }
        public List<ChapTruyen> getChapMoi()
        {
            List<ChapTruyen> listChap = db.ChapTruyens.ToList();
            List<ChapTruyen> res = new List<ChapTruyen>();
            var temp = listChap.OrderBy(x => x.stt).ToList();
            for (int i = temp.Count-1; i >= 0; --i)
            {
                if (i == 15) break;
                temp[i].noidung = getTenTruyen(temp[i].IDtruyen);
                res.Add(temp[i]);
            }
            return res;
        }
        public List<Truyen> listTheLoaiTruyen(int id)
        {
            var listTheLoai = db.CheckTheLoais.ToList();
            List<CheckTheLoai> temp = new List<CheckTheLoai>();
            foreach(CheckTheLoai x in listTheLoai)
            {
                if(x.IDtheloai == id)
                {
                    temp.Add(x);
                }
            }
            var listTruyen = db.Truyens.ToList();
            List<Truyen> res = new List<Truyen>();
            foreach (Truyen x in listTruyen)
            {
                foreach (var y in temp)
                {
                    if (x.IDTruyen == y.IDtruyen)
                    {
                        res.Add(x);
                    }
                }
            }
            return res;
        }
    }
}