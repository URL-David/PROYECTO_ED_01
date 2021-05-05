using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PROYECTO_ED_01.Controllers
{
    public class VacunaC19Controller : Controller
    {
        // GET: VacunaC19Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: VacunaC19Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VacunaC19Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VacunaC19Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: VacunaC19Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VacunaC19Controller/Edit/5
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

        // GET: VacunaC19Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VacunaC19Controller/Delete/5
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
