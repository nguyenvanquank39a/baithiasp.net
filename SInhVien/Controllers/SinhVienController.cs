using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SInhVien.Context;

namespace SInhVien.Controllers
{
    public class SinhVienController : Controller
    {
        private SinhVienEntities db = new SinhVienEntities();

        // GET: /SinhVien/
        public ActionResult Index()
        {
            return View(db.ThongTins.ToList());
        }

        // GET: /SinhVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongtin = db.ThongTins.Find(id);
            if (thongtin == null)
            {
                return HttpNotFound();
            }
            return View(thongtin);
        }

        // GET: /SinhVien/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SinhVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,MaSv,HoTen,NamSinh,SoDienThoaiSV,Lop,Khoa,HoTenChuTro,DiaChiNoiCuTru,NgayDangKy,NgayHuy")] ThongTin thongtin)
        {
            if (ModelState.IsValid)
            {
                db.ThongTins.Add(thongtin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongtin);
        }

        // GET: /SinhVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongtin = db.ThongTins.Find(id);
            if (thongtin == null)
            {
                return HttpNotFound();
            }
            return View(thongtin);
        }

        // POST: /SinhVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,MaSv,HoTen,NamSinh,SoDienThoaiSV,Lop,Khoa,HoTenChuTro,DiaChiNoiCuTru,NgayDangKy,NgayHuy")] ThongTin thongtin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongtin);
        }

        // GET: /SinhVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongtin = db.ThongTins.Find(id);
            if (thongtin == null)
            {
                return HttpNotFound();
            }
            return View(thongtin);
        }

        // POST: /SinhVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTin thongtin = db.ThongTins.Find(id);
            db.ThongTins.Remove(thongtin);
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
