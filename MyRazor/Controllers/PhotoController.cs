using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyRazor.Controllers
{
    public class PhotoController : Controller
    {
        // GET: PhotoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhotoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhotoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoController/Create
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

        // GET: PhotoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhotoController/Edit/5
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

        // GET: PhotoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhotoController/Delete/5
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
