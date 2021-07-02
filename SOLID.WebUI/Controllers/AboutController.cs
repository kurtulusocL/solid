using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOLID.Business.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.WebUI.Controllers
{
    public class AboutController : Controller
    {
        IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IActionResult Index()
        {
            return View(_aboutService.GetAll());
        }
        public IActionResult Detail(int id)
        {
            return View(_aboutService.GetById(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(About model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/about/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Photo = photoName;
            }

            _aboutService.Create(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var updateAbout = _aboutService.GetById(id);
            if (updateAbout != null)
            {
                return View(updateAbout);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(About model, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/about/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.Photo = photoName;
            }

            _aboutService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var deleteAbout = _aboutService.GetById(id);
            if (deleteAbout != null)
            {
                _aboutService.Delete(deleteAbout);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
