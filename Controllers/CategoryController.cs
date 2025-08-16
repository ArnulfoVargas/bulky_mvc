using Bulky.DataAccess;
using Bulky.DataAccess.Repository;
using Bulky.Models.Entities;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bulky.Controllers;

public class CategoryController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }
    
    public async Task<IActionResult> Index()
    {
        var categories = await _unitOfWork.Category.Take();
        
        return View(new CategoriesListViewModel
        {
            Categories = categories
        });
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(nameof(category.Name), "Category cannot have same value as Display Order");
            return View(category);
        }
        
        // if (category is { Name: "" or null, DisplayOrder: 0 or < 1  } )
        if (!ModelState.IsValid)
        {
            // ViewBag.Error = "Invalid Category";
            return View(category);
        }
        
        _unitOfWork.Category.Add(category);
        await _unitOfWork.Save();
        TempData["success"] = "Category created";
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int? id)
    {
        if (id is null or 0) return RedirectToAction("Create", "Category");
        
        var cat = await _unitOfWork.Category.Get(x => x.Id == id);
        if (cat is null)
        {
            TempData["error"] = "Category not found";
            return RedirectToAction("Create", "Category");
        }
        
        return View("Create",cat);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Category category)
    {
        if (category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(nameof(category.Name), "Category cannot have same value as Display Order");
            return View("Create", category);
        }
        
        if (!ModelState.IsValid)
        {
            return View("Create", category);
        }
        _unitOfWork.Category.Update(category);
        await _unitOfWork.Save();
        TempData["success"] = "Category updated";
        return RedirectToAction("Index",  "Category");
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var cat = await _unitOfWork.Category.Get(x => x.Id == id);
        if (cat is null) return RedirectToAction("Index", "Category");
        _unitOfWork.Category.Delete(cat);
        await _unitOfWork.Save();
        TempData["success"] = "Category deleted";
        return RedirectToAction("Index", "Category");
    }
}