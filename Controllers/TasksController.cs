using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewTask.Models;

namespace ViewTask.Controllers;

public class TasksController : Controller
{
    private static readonly string[] Markets = ["WellMart", "Silpo", "ATB", "Furshet", "Metro"];

    private static Dictionary<string, int> CreateShoppingList() => new()
    {
        ["Milk"] = 2, ["Bread"] = 2, ["Cake"] = 1,
        ["Ice Cream"] = 5, ["Cola"] = 10
    };

    public IActionResult SprintTasks() => View();
    public IActionResult Greetings() => View();
    public IActionResult ProductInfo() => View();

    public IActionResult SuperMarkets()
    {
        ViewBag.SuperMarkets = Markets.ToList();
        return View();
    }

    public IActionResult ShoppingList() => View(CreateShoppingList());

    [HttpGet]
    public IActionResult ShoppingCart()
    {
        var model = new ShoppingCartViewModel
        {
            Supermarket = Markets[0], ShippingDate = DateTime.Today
        };
        PopulateOptions(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ShoppingCart(ShoppingCartViewModel model)
    {
        PopulateOptions(model);
        if (!Markets.Contains(model.Supermarket))
            ModelState.AddModelError(nameof(model.Supermarket), "Choose a supermarket from the list.");
        if (!model.ShippingDate.HasValue || !model.ShippingDates.Contains(model.ShippingDate.Value))
            ModelState.AddModelError(nameof(model.ShippingDate), "Choose one of the available shipping dates.");
        var products = CreateShoppingList();
        if (model.Products is null || model.Products.Any(product => !products.ContainsKey(product)))
            ModelState.AddModelError(nameof(model.Products), "Choose products from the list.");
        if (!ModelState.IsValid)
            return View(model);
        return View("ShoppingCartResult", model);
    }

    private static void PopulateOptions(ShoppingCartViewModel model)
    {
        model.Supermarkets = Markets.Select(name => new SelectListItem(name, name)).ToList();
        model.AvailableProducts = CreateShoppingList().Keys
            .Select(name => new SelectListItem(name, name)).ToList();
        model.ShippingDates = Enumerable.Range(0, 3).Select(offset => DateTime.Today.AddDays(offset)).ToList();
    }
}
