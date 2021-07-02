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
    public class ProductController : Controller
    {
        IProductService _productService;
        ICategoryService _categoryService;
        ICommentService _commentService;
        IPictureService _pictureService;

        IProductDetailService _productDetailService;
        public ProductController(IProductService productService, ICategoryService categoryService, ICommentService commentService, IPictureService pictureService, IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
            _productService = productService;
            _commentService = commentService;
            _categoryService = categoryService;
            _pictureService = pictureService;
        }
        public IActionResult Index(int page = 1)
        {
            return View(_productService.GetAllIncluding().OrderByDescending(i => i.CreatedDate).ToPagedList(page, 20));
        }
        public IActionResult Detail(int id)
        {
            return View(_productService.GetById(id));
        }
        public IActionResult CategoryProduct(int? id)
        {
            return View(_productService.Category(id).ToList());
        }
        public IActionResult ProductDetail(int? id)
        {
            return View(_productService.GetProductDetail(id));
        }
        public IActionResult HitRead(int? id)
        {
            return PartialView(_productService.HitRead(id));
        }
        public ActionResult Create()
        {
            ViewBag.Categories = _categoryService.GetAllIncluding();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(model);
            }
            return RedirectToAction(nameof(Create));
        }
        public ActionResult Edit(int id)
        {
            var updateProduct = _productService.GetById(id);
            if (updateProduct != null)
            {
                return View(updateProduct);
            }
            return RedirectToAction(nameof(Edit));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(model);
            }
            return RedirectToAction(nameof(Edit));
        }
        public IActionResult CommentCreate(int id)
        {
            ViewBag.ProductId = _productService.GetById(id);
            Comment model = new Comment
            {
                ProductId = id,
            };
            return View("CommentCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CommentCreate(int? productId, string namesurname, string email, string subject, string text)
        {
            var model = new Comment
            {
                ProductId = productId,
                NameSurname = namesurname,
                EMail = email,
                Subject = subject,
                Text = text
            };
            if (ModelState.IsValid)
            {
                _commentService.Create(model);
            }
            return RedirectToAction("Index", "Comment");
        }        
        public IActionResult ProductDetailCreate(int id)
        {
            ViewBag.ProductId = _productService.GetById(id);
            ProductDetail model = new ProductDetail
            {
                ProductId = id,
            };
            return View("ProductDetailCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProductDetailCreate(int? productId, string detail, string subdetail)
        {
            var model = new ProductDetail
            {
                ProductId = productId,
                Detail = detail,
                Subdetail = subdetail
            };
            if (ModelState.IsValid)
            {
                _productDetailService.Create(model);
            }
            return RedirectToAction("Index", "ProductDetail");
        }

        public IActionResult PhotoCreate(int id)
        {
            ViewBag.ProductId = _productService.GetById(id);
            Picture model = new Picture
            {
                ProductId = id,
            };
            return View("PhotoCreate", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PhotoCreate(int? productId, IEnumerable<IFormFile> images)
        {

            foreach (var image in images)
            {
                var model = new Picture
                {
                    ProductId = productId
                };
                var path = Path.GetExtension(image.FileName);
                var photoName = Guid.NewGuid() + path;
                var upload = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product/" + photoName);
                var stream = new FileStream(upload, FileMode.Create);
                image.CopyTo(stream);
                model.ImageUrl = photoName;

                _pictureService.Create(model);
            }
            return RedirectToAction("Index", "Picture");
        }
        public IActionResult Delete(int id)
        {
            var deleteProduct = _productService.GetById(id);
            if (deleteProduct != null)
            {
                _productService.Delete(deleteProduct);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
