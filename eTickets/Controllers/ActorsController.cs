using eTickets.Data.Services.Actors;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
namespace eTickets.Controllers;
public class ActorsController(IActorsService services) : Controller
{
    private readonly IActorsService _services = services;
    public async Task<IActionResult> Index() {
        var data = await _services.GetAllAsync();
        return View(data);
    }
    //Get: Actors/Create
    public IActionResult Create() => View();
    [HttpPost]
    public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor) {
        if (!ModelState.IsValid)
             return View(actor);
        await _services.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }
    //Get: Actors/Details/:id
    public async Task<ActionResult> Details(int id)
    {
        var actorDetails = await _services.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);
    }
    //Get: Actors/Edit
    public async Task<IActionResult> Edit(int id)
    {
        var actorDetails = await _services.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
            return View(actor);
        await _services.UpdateAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }
    //Get: Actors/Delete
    public async Task<IActionResult> Delete(int id)
    {
        var actorDetails = await _services.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        return View(actorDetails);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actorDetails = await _services.GetByIdAsync(id);
        if (actorDetails == null) return View("NotFound");
        await _services.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}