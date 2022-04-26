using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Final_mvc.Models;

namespace Final_mvc.Controllers
{
    public class OrdersStatusController : Controller
    {
        private Final_MVCEntities db = new Final_MVCEntities();

        // GET: OrdersStatus
        public ActionResult Index()
        {
            var ordersStatus = db.OrdersStatus.Include(o => o.Agent).Include(o => o.DeliveryNote).Include(o => o.Product);
            return View(ordersStatus.ToList());
        }

        // GET: OrdersStatus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersStatu ordersStatu = db.OrdersStatus.Find(id);
            if (ordersStatu == null)
            {
                return HttpNotFound();
            }
            return View(ordersStatu);
        }

        // GET: OrdersStatus/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName");
            ViewBag.OrderID = new SelectList(db.DeliveryNotes, "DeliveryID", "AID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: OrdersStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,AID,ProductID,ProductName,Quantity,Payment")] OrdersStatu ordersStatu)
        {
            if (ModelState.IsValid)
            {
                db.OrdersStatus.Add(ordersStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", ordersStatu.AID);
            ViewBag.OrderID = new SelectList(db.DeliveryNotes, "DeliveryID", "AID", ordersStatu.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", ordersStatu.ProductID);
            return View(ordersStatu);
        }

        // GET: OrdersStatus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersStatu ordersStatu = db.OrdersStatus.Find(id);
            if (ordersStatu == null)
            {
                return HttpNotFound();
            }
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", ordersStatu.AID);
            ViewBag.OrderID = new SelectList(db.DeliveryNotes, "DeliveryID", "AID", ordersStatu.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", ordersStatu.ProductID);
            return View(ordersStatu);
        }

        // POST: OrdersStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,AID,ProductID,ProductName,Quantity,Payment")] OrdersStatu ordersStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AID = new SelectList(db.Agents, "AID", "AName", ordersStatu.AID);
            ViewBag.OrderID = new SelectList(db.DeliveryNotes, "DeliveryID", "AID", ordersStatu.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", ordersStatu.ProductID);
            return View(ordersStatu);
        }

        // GET: OrdersStatus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersStatu ordersStatu = db.OrdersStatus.Find(id);
            if (ordersStatu == null)
            {
                return HttpNotFound();
            }
            return View(ordersStatu);
        }

        // POST: OrdersStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OrdersStatu ordersStatu = db.OrdersStatus.Find(id);
            db.OrdersStatus.Remove(ordersStatu);
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
