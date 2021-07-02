using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOLID.Business.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SOLID.WebUI.Controllers
{
    public class PictureController : Controller
    {
        IPictureService _pictureService;
        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_pictureService.GetAllIncluding().OrderByDescending(i => i.CreatedDate).ToPagedList(page, 30));
        }
        public IActionResult Product(int? id)
        {
            return View(_pictureService.GetProduct(id));
        }
        public IActionResult Edit(int? id)
        {
            var updatePhoto = _pictureService.GetAllIncluding().Where(i => i.ProductId == id).FirstOrDefault(i => i.Id == id);

            if (updatePhoto != null)
            {
                return View(updatePhoto);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Picture model, IEnumerable<IFormFile> images)
        {
            foreach (var image in images)
            {
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;

                _pictureService.Update(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var deletePicture = _pictureService.GetById(id);
            if (deletePicture != null)
            {
                _pictureService.Delete(deletePicture);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
