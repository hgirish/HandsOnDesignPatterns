using FlixOne.Web.Common;
using FlixOne.Web.Models;
using FlixOne.Web.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FlixOne.Web.Controllers;

public class ProductController: Controller
{
    private readonly IInventoryRepository _inventoryRepository;

    public ProductController(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }
    public IActionResult Index() =>
        View(_inventoryRepository.GetProducts().ToProductvm());

    public IActionResult Details(Guid id) =>
        View(_inventoryRepository.GetProduct(id).ToProductvm());

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromBody] Product product)
    {
        try
        {
            _inventoryRepository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }
    public IActionResult Edit(Guid id) => 
        View(_inventoryRepository.GetProduct(id));

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Guid id, [FromBody] Product product) 
    {
        try
        {
            _inventoryRepository.UpdateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }

    public IActionResult Delete(Guid id) => 
        View(_inventoryRepository.GetProduct(id));

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Guid id, [FromBody] Product product)
    {
        try
        {
            _inventoryRepository.RemoveProduct(product);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return View();
        }
    }

}
