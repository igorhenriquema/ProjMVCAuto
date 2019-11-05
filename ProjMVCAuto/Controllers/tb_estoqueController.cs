using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjMVCAuto;

namespace ProjMVCAuto.Controllers
{
    public class tb_estoqueController : Controller
    {
        private dbprojmvcautoEntities db = new dbprojmvcautoEntities();

        // GET: tb_estoque
        public ActionResult Index()
        {
            return View(db.tb_estoque.ToList());
        }

        // GET: tb_estoque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_estoque tb_estoque = db.tb_estoque.Find(id);
            if (tb_estoque == null)
            {
                return HttpNotFound();
            }
            return View(tb_estoque);
        }

        // GET: tb_estoque/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_estoque/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,produto")] tb_estoque tb_estoque)
        {
            if (ModelState.IsValid)
            {
                db.tb_estoque.Add(tb_estoque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_estoque);
        }

        // GET: tb_estoque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_estoque tb_estoque = db.tb_estoque.Find(id);
            if (tb_estoque == null)
            {
                return HttpNotFound();
            }
            return View(tb_estoque);
        }

        // POST: tb_estoque/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,produto")] tb_estoque tb_estoque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_estoque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_estoque);
        }

        // GET: tb_estoque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_estoque tb_estoque = db.tb_estoque.Find(id);
            if (tb_estoque == null)
            {
                return HttpNotFound();
            }
            return View(tb_estoque);
        }

        // POST: tb_estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_estoque tb_estoque = db.tb_estoque.Find(id);
            db.tb_estoque.Remove(tb_estoque);
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
