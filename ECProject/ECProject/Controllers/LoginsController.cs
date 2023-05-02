using ECProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECProject.Controllers
{
    public class LoginsController : Controller
    {
        ECDbContext db;
        public LoginsController(ECDbContext dbc)
        {
            db = dbc;
        }
        // GET: LoginsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Login l)
        {
            db.UserLogins.Add(l);
            db.SaveChanges();
            ViewBag.m = "Account Created Successfully";
            return View();
        }


        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(Login lg)
        {
            var x = from a in db.UserLogins where a.Email.Equals(lg.Email) && a.Password.Equals(lg.Password) select a;
            if (x.Any())
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.m = "Wrong Credentials";
            }
            return View();
        }


        // GET: LoginsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
