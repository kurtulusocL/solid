using Microsoft.AspNetCore.Mvc;
using SOLID.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.WebUI.ViewComponents
{
    public class HitComponent:ViewComponent
    {
        IProductService _productService;
        public HitComponent(IProductService productService)
        {
            _productService = productService;
        }
        public IViewComponentResult Invoke(int? id)
        {
            return View(_productService.HitRead(id));
        }
    }
}
