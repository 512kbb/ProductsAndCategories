using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ProductsAndCategories.Views.Home
{
    public class CategoriesPage : PageModel
    {
        private readonly ILogger<CategoriesPage> _logger;

        public CategoriesPage(ILogger<CategoriesPage> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}