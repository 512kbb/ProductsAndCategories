using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProdAndCatContext _context;

    public HomeController(ILogger<HomeController> logger, ProdAndCatContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        List<Product> AllProducts = _context.Products.ToList();
        ViewBag.AllProducts = AllProducts;
        return View();
    }

    [HttpPost("products/new")]
    public IActionResult AddProduct(Product newProduct)
    {
        if (ModelState.IsValid == false)
        {
            return View("Index");
        }
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("categories")]
    public IActionResult CategoriesPage()
    {
        List<Category> AllCategories = _context.Categories.ToList();
        ViewBag.AllCategories = AllCategories;
        return View();
    }
    [HttpPost("categories/new")]
    public IActionResult AddCategory(Category newCategory)
    {
        if (ModelState.IsValid == false)
        {
            return View("CategoriesPage");
        }
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("CategoriesPage");
    }

    [HttpGet("products/{productId}")]
    public IActionResult ProductPage(int productId)
    {
        Product? product = _context.Products
            .Include(p => p.Associations)
            .ThenInclude(a => a.Category)
            .FirstOrDefault(p => p.ProductId == productId);
        List<Category> AllCategories = _context.Categories.ToList();
        List<Category> ProductCategories = product.Associations.Select(a => a.Category).ToList();
        List<Category> NotProductCategories = AllCategories.Except(ProductCategories).ToList();
        ViewBag.Product = product;
        ViewBag.ProductCategories = ProductCategories;
        ViewBag.NotProductCategories = NotProductCategories;
        return View();
    }

    [HttpGet("categories/{categoryId}")]
    public IActionResult CategoryPage(int categoryId)
    {
        Category? category = _context.Categories
            .Include(c => c.Associations)
            .ThenInclude(a => a.Product)
            .FirstOrDefault(c => c.CategoryId == categoryId);
        List<Product> AllProducts = _context.Products.ToList();
        List<Product> CategoryProducts = category.Associations.Select(a => a.Product).ToList();
        List<Product> NotCategoryProducts = AllProducts.Except(CategoryProducts).ToList();
        ViewBag.Category = category;
        ViewBag.CategoryProducts = CategoryProducts;
        ViewBag.NotCategoryProducts = NotCategoryProducts;
        return View();
    }

    [HttpPost("products/{productId}/addcategory")]
    public IActionResult AddCategoryToProduct(int productId, Association newAssociation)
    {
        if (ModelState.IsValid == false)
        {
            return RedirectToAction("ProductPage", new { productId = productId });
        }
        newAssociation.ProductId = productId;
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("ProductPage", new { productId = productId });
    }

    [HttpPost("categories/{categoryId}/addproduct")]
    public IActionResult AddProductToCategory(int categoryId, Association newAssociation)
    {
        if (ModelState.IsValid == false)
        {
            return RedirectToAction("CategoryPage", new { categoryId = categoryId });
        }
        newAssociation.CategoryId = categoryId;
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("CategoryPage", new { categoryId = categoryId });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
