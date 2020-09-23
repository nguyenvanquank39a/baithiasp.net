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
    public class TaiKhoanController : Controller
    {
        private SinhVienEntities db = new SinhVienEntities();

        // GET: /TaiKhoan/
        public ActionResult Index()
        {
            return View(db.TaiKhoans.ToList());
        }

        // GET: /TaiKhoan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // GET: /TaiKhoan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TaiKhoan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TenTaiKhoan,MatKhau")] TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoans.Add(taikhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taikhoan);
        }

        // GET: /TaiKhoan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // POST: /TaiKhoan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TenTaiKhoan,MatKhau")] TaiKhoan taikhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taikhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taikhoan);
        }

        // GET: /TaiKhoan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            if (taikhoan == null)
            {
                return HttpNotFound();
            }
            return View(taikhoan);
        }

        // POST: /TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaiKhoan taikhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taikhoan);
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
