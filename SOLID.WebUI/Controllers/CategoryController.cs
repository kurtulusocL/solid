using Microsoft.AspNetCore.Mvc;
using SOLID.Business.Abstract;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SOLID.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_categoryService.GetAllIncluding().OrderByDescending(i => i.CreatedDate).ToPagedList(page, 15));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Create(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var updateCategory = _categoryService.GetById(id);
            if (updateCategory != null)
            {
                return View(updateCategory);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(model);
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var deleteCategory = _categoryService.GetById(id);
            if (deleteCategory != null)
            {
                _categoryService.Delete(deleteCategory);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
