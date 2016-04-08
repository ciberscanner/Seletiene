using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SeletieneDPS.data;

namespace SeletieneDPS.Controllers
{
    public class productservicesController : Controller
    {
        private seletieneEntities db = new seletieneEntities();

        // GET: productservices
        [Authorize(Roles = "Administrador, Callcenter")]
        public ActionResult Index(string state, string searchString)
        {
            var productservice = db.productservice.Include(p => p.category).Include(p => p.state1).Include(p => p.state2).Include(p => p.userapp);

            if (!String.IsNullOrEmpty(searchString))
            {

                switch (state)
                {
                    case "Todo":
                        productservice = productservice.Where(s => s.name.Contains(searchString)
                                       || s.userapp.name1.Contains(searchString) || s.description.Contains(searchString));
                        break;
                    case "Revisado":
                        productservice = productservice.Where(s => s.name.Contains(searchString)
                                       || s.userapp.name1.Contains(searchString) || s.description.Contains(searchString)
                                       & s.state2.value.Equals("Si"));

                        break;
                    case "Sin_Revisar":
                        productservice = productservice.Where(s => s.name.Contains(searchString)
                                       || s.userapp.name1.Contains(searchString) || s.description.Contains(searchString)
                                       & s.state2.value.Equals("No"));
                        break;
                    default:

                        break;
                }
            }else
            {
                switch (state)
                {
                    case "Todo":

                        break;
                    case "Revisado":
                        productservice = productservice.Where(s => s.state2.value.Equals("Si"));

                        break;
                    case "Sin_Revisar":
                        productservice = productservice.Where(s => s.state2.value.Equals("No"));
                        break;
                    default:

                        break;
                }

            }
            productservice = productservice.OrderBy(s => s.dateup);
            return View(productservice.ToList());
        }

        // GET: productservices/Details/5
        [Authorize(Roles = "Administrador, Callcenter")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productservice productservice = db.productservice.Find(id);
            if (productservice == null)
            {
                return HttpNotFound();
            }
            return View(productservice);
        }

        // GET: productservices/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.idcategory = new SelectList(db.category, "id", "name");
            ViewBag.state = new SelectList(db.state, "id", "value");
            ViewBag.dpsvalidation = new SelectList(db.state, "id", "value");
            ViewBag.idowner = new SelectList(db.userapp, "id", "id_card");
            return View();
        }

        // POST: productservices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,idcategory,idowner,name,description,dateup,dpsvalidation,schedule,state")] productservice productservice)
        {
            if (ModelState.IsValid)
            {
                db.productservice.Add(productservice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcategory = new SelectList(db.category, "id", "name", productservice.idcategory);
            ViewBag.state = new SelectList(db.state, "id", "value", productservice.state);
            ViewBag.dpsvalidation = new SelectList(db.state, "id", "value", productservice.dpsvalidation);
            ViewBag.idowner = new SelectList(db.userapp, "id", "id_card", productservice.idowner);
            return View(productservice);
        }

        // GET: productservices/Edit/5
        [Authorize(Roles = "Administrador, Callcenter")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productservice productservice = db.productservice.Find(id);
            if (productservice == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcategory = new SelectList(db.category, "id", "name", productservice.idcategory);
            ViewBag.state = new SelectList(db.state, "id", "value", productservice.state);
            ViewBag.dpsvalidation = new SelectList(db.state, "id", "value", productservice.dpsvalidation);
            ViewBag.idowner = new SelectList(db.userapp, "id", "id_card", productservice.idowner);
            return View(productservice);
        }

        // POST: productservices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,idcategory,idowner,name,description,dateup,dpsvalidation,schedule,state")] productservice productservice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productservice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcategory = new SelectList(db.category, "id", "name", productservice.idcategory);
            ViewBag.state = new SelectList(db.state, "id", "value", productservice.state);
            ViewBag.dpsvalidation = new SelectList(db.state, "id", "value", productservice.dpsvalidation);
            ViewBag.idowner = new SelectList(db.userapp, "id", "id_card", productservice.idowner);
            return View(productservice);
        }

        // GET: productservices/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productservice productservice = db.productservice.Find(id);
            if (productservice == null)
            {
                return HttpNotFound();
            }
            return View(productservice);
        }

        // POST: productservices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productservice productservice = db.productservice.Find(id);
            db.productservice.Remove(productservice);
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
