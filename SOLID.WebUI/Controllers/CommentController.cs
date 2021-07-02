using Microsoft.AspNetCore.Mvc;
using SOLID.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.WebUI.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index(int page=1)
        {
            return View(_commentService.GetAllIncluding());
        }
        public IActionResult Product(int? id)
        {
            return View(_commentService.GetProduct(id));
        }
        public IActionResult Detail(int id)
        {
            return View(_commentService.GetById(id));
        }
        public IActionResult Delete(int id)
        {
            var deleteComment = _commentService.GetById(id);
            if (deleteComment != null)
            {
                _commentService.Delete(deleteComment);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
