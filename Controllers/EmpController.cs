using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc3839_7622.Models;

namespace mvc3839_7622.Controllers
{
    public class EmpController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        // GET: Emp
        public ActionResult Add(int id = 0)
        {
            ViewBag.kk = "Save";
            tblemployee obj = new tblemployee();
            if(id>0)
            {

            var data = (from a in _db.tblemployees where a.id==id select a).ToList();
            obj.id = data[0].id;
            obj.name = data[0].name;
            obj.city = data[0].city;
            obj.salary = data[0].salary;
            obj.age = data[0].age;
                ViewBag.kk = "Update";
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Add(tblemployee _emp)
        {
            if (_emp.id > 0)
            {
                _db.Entry(_emp).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                _db.tblemployees.Add(_emp);
            }
            _db.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            var data = _db.tblemployees.ToList();
            return View(data);
        }

        public ActionResult Del(int id=0)
        {
            var data = _db.tblemployees.Find(id);
            _db.tblemployees.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Show");
        }
    }
}