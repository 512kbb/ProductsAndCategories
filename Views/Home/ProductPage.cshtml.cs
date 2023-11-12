using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProductsAndCategories.Views.Home
{
    public class ProductPage : PageModel
    {
        private readonly ILogger<ProductPage> _logger;

        public ProductPage(ILogger<ProductPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}