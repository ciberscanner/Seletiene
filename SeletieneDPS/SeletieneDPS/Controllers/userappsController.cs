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
    public class userappsController : Controller
    {
        private seletieneEntities db = new seletieneEntities();

        // GET: userapps
        [Authorize(Roles = "Administrador, Callcenter")]
        public ActionResult Index(string sortOrder, string searchString, string state)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var userapp = db.userapp.Include(u => u.city1).Include(u => u.collective1).Include(u => u.state).Include(u => u.state1);

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (state)
                {
                    case "Todo":
                        userapp = userapp.Where(s => s.name1.Contains(searchString)
                                       || s.lastname1.Contains(searchString) || s.id_card.Contains(searchString)
                                       || s.email.Contains(searchString) || s.telephone.Contains(searchString));
                        break;
                    case "Revisado":
                        userapp = userapp.Where(s => s.name1.Contains(searchString)
                                       || s.lastname1.Contains(searchString) || s.id_card.Contains(searchString)
                                       || s.email.Contains(searchString) || s.telephone.Contains(searchString)
                                       & s.state.value.Equals("Si"));

                        break;
                    case "Sin_Revisar":
                        userapp = userapp.Where(s => s.name1.Contains(searchString)
                                       || s.lastname1.Contains(searchString) || s.id_card.Contains(searchString)
                                       || s.email.Contains(searchString) || s.telephone.Contains(searchString)
                                       & s.state.value.Equals("No"));
                        break;
                    default:

                        break;
                }
                
            }
            else
            {
                switch (state)
                {
                    case "Todo":

                        break;
                    case "Revisado":
                        userapp = userapp.Where(s => s.state.value.Equals("Si"));

                        break;
                    case "Sin_Revisar":
                        userapp = userapp.Where(s => s.state.value.Equals("No"));
                        break;
                    default:

                        break;
                }

            }

            switch (sortOrder)
            {
                case "name_desc":
                    userapp = userapp.OrderBy(s => s.name1);
                    break;
                case "Date":
                    
                    break;
                case "date_desc":
                    
                    break;
                default:
                    
                    break;
            }

            return View(userapp.ToList());
        }

        // GET: userapps/Details/5
        [Authorize(Roles = "Administrador, Callcenter")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userapp userapp = db.userapp.Find(id);
            if (userapp == null)
            {
                return HttpNotFound();
            }
            return View(userapp);
        }

        // GET: userapps/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.city = new SelectList(db.city, "ID", "Name");
            ViewBag.collective = new SelectList(db.collective, "id", "nombre");
            ViewBag.active = new SelectList(db.state, "id", "value");
            ViewBag.suspended = new SelectList(db.state, "id", "value");
            return View();
        }

        // POST: userapps/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_card,name1,name2,lastname1,lastname2,birthdate,registrationdate,city,collective,telephone,cellphone,email,passw,active,suspended")] userapp userapp)
        {
            if (ModelState.IsValid)
            {
                db.userapp.Add(userapp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.city = new SelectList(db.city, "ID", "Name", userapp.city);
            ViewBag.collective = new SelectList(db.collective, "id", "nombre", userapp.collective);
            ViewBag.active = new SelectList(db.state, "id", "value", userapp.active);
            ViewBag.suspended = new SelectList(db.state, "id", "value", userapp.suspended);
            return View(userapp);
        }

        // GET: userapps/Edit/5
        [Authorize(Roles = "Administrador, Callcenter")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userapp userapp = db.userapp.Find(id);
            if (userapp == null)
            {
                return HttpNotFound();
            }
            ViewBag.city = new SelectList(db.city, "ID", "Name", userapp.city);
            ViewBag.collective = new SelectList(db.collective, "id", "nombre", userapp.collective);
            ViewBag.active = new SelectList(db.state, "id", "value", userapp.active);
            ViewBag.suspended = new SelectList(db.state, "id", "value", userapp.suspended);
            return View(userapp);
        }

        // POST: userapps/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_card,name1,name2,lastname1,lastname2,birthdate,registrationdate,city,collective,telephone,cellphone,email,passw,active,suspended")] userapp userapp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userapp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.city = new SelectList(db.city, "ID", "Name", userapp.city);
            ViewBag.collective = new SelectList(db.collective, "id", "nombre", userapp.collective);
            ViewBag.active = new SelectList(db.state, "id", "value", userapp.active);
            ViewBag.suspended = new SelectList(db.state, "id", "value", userapp.suspended);
            return View(userapp);
        }

        // GET: userapps/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userapp userapp = db.userapp.Find(id);
            if (userapp == null)
            {
                return HttpNotFound();
            }
            return View(userapp);
        }

        // POST: userapps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userapp userapp = db.userapp.Find(id);
            db.userapp.Remove(userapp);
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
