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
        public ActionResult Details(string id)
        {
            return View(service.GetPhotoById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Photo model)
        {
            if (model.Name != "step")
                ModelState.AddModelError("", "Вы ввели в поле Name не STEP");
            if (model.Extension != "step")
                ModelState.AddModelError("", "Вы ввели поле Extension не STEP");
            //var status = service.AddOrEditPhoto(model);
            //if (status.status == StatusEnum.OK)
            //    return RedirectToAction("index");
            //ModelState.AddModelError("Name", "Такое имя и расширение уже существуют");
            return View();
        }

        public ActionResult Edit(string id)
        {
            return View(service.GetPhotoById(id));
        }

        // POST: PhotoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Photo model)
        {
            try
            {
                var status = service.AddOrEditPhoto(model);
                if (status.status == StatusEnum.OK)
                    return RedirectToAction("index");
                ModelState.AddModelError("Name", "Error");
                return View();
            }
            catch (Exception err)
            {
                ModelState.AddModelError("Name", err.Message);
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

        //public ActionResult MyCheck(string name)
        //{
        //    if (name == "step")
        //        return Json(true);
        //    return Json(false);
        //}

    }
}
