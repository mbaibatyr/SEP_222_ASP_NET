using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRazor.Abstract;
using MyRazor.Models;

namespace MyRazor.Controllers
{
    public class PhotoController : Controller
    {
        IPhoto<Photo> service;
        public PhotoController(IPhoto<Photo> service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View(service.GetPhotoAllorById("0"));
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

        [HttpPost]
        public ActionResult Create(Photo model)
        {            
            var status = service.AddOrEditPhoto(model);
            if (status.status == StatusEnum.OK)
                return RedirectToAction("index");
            ModelState.AddModelError("", "Такое имя и расширение уже существуют");
            return View();
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
