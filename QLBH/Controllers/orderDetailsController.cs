using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class orderDetailsController : Controller
    {
        private QLBHDbContext db = new QLBHDbContext();

        // GET: orderDetails
        public ActionResult Index()
        {
            var orderDetails = db.orderDetails.Include(o => o.order).Include(o => o.product);
            return View(orderDetails.ToList());
        }

        // GET: orderDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetail orderDetail = db.orderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // GET: orderDetails/Create
        public ActionResult Create()
        {
            ViewBag.order_id = new SelectList(db.orders, "id", "status");
            ViewBag.product_id = new SelectList(db.products, "id", "name");
            return View();
        }

        // POST: orderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,order_id,price,quantity,created_at")] orderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.orderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.order_id = new SelectList(db.orders, "id", "status", orderDetail.order_id);
            ViewBag.product_id = new SelectList(db.products, "id", "name", orderDetail.product_id);
            return View(orderDetail);
        }

        // GET: orderDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetail orderDetail = db.orderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_id = new SelectList(db.orders, "id", "status", orderDetail.order_id);
            ViewBag.product_id = new SelectList(db.products, "id", "name", orderDetail.product_id);
            return View(orderDetail);
        }

        // POST: orderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,order_id,price,quantity,created_at")] orderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.order_id = new SelectList(db.orders, "id", "status", orderDetail.order_id);
            ViewBag.product_id = new SelectList(db.products, "id", "name", orderDetail.product_id);
            return View(orderDetail);
        }

        // GET: orderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orderDetail orderDetail = db.orderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: orderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            orderDetail orderDetail = db.orderDetails.Find(id);
            db.orderDetails.Remove(orderDetail);
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
