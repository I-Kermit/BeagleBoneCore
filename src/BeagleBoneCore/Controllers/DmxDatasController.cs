//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web.Mvc;
//using BeagleboneMVC.Models;
//using BeagleBoneCore.Services;
//using Dmx.Entities;
//using Microsoft.AspNetCore.Mvc;
//
//namespace BeagleBoneCore.Controllers
//{
//    public class DmxDatasController : Controller
//    {
//        private readonly DmxService _dmxService;
//
//
//        private ApplicationDbContext db = new ApplicationDbContext();
//
//        public DmxDatasController(DmxService dmxService)
//        {
//            _dmxService = dmxService;
//        }
//
//        // GET: DmxDatas
//        public ActionResult Index()
//        {
//            return View(db.DmxDatas.ToList());
//        }
//
//        // GET: DmxDatas/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            DmxData dmxData = db.DmxDatas.Find(id);
//            if (dmxData == null)
//            {
//                return HttpNotFound();
//            }
//            return View(dmxData);
//        }
//
//        // GET: DmxDatas/Create
//        public ActionResult Create()
//        {
//            return View();
//        }
//
//        // POST: DmxDatas/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Id,NumberOfChannels")] DmxData dmxData)
//        {
//            if (ModelState.IsValid)
//            {
//                db.DmxDatas.Add(dmxData);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//
//            return View(dmxData);
//        }
//
//        // GET: DmxDatas/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            DmxData dmxData = db.DmxDatas.Find(id);
//            if (dmxData == null)
//            {
//                return HttpNotFound();
//            }
//            return View(dmxData);
//        }
//
//        // POST: DmxDatas/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Id,NumberOfChannels")] DmxData dmxData)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(dmxData).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(dmxData);
//        }
//
//        // GET: DmxDatas/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            DmxData dmxData = db.DmxDatas.Find(id);
//            if (dmxData == null)
//            {
//                return HttpNotFound();
//            }
//            return View(dmxData);
//        }
//
//        // POST: DmxDatas/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            DmxData dmxData = db.DmxDatas.Find(id);
//            db.DmxDatas.Remove(dmxData);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }
//
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
