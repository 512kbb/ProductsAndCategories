using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProductsAndCategories.Views.Home
{
    public class CategoryPage : PageModel
    {
        private readonly ILogger<CategoryPage> _logger;

        public CategoryPage(ILogger<CategoryPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}