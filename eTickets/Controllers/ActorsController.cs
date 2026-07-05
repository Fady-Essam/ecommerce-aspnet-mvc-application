using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace eTickets.Controllers;
public class ActorsController(IActorsService services) : Controller
{
    private readonly IActorsService _services = services;
    public async Task<IActionResult> Index() {
        var data = await _services.GetAll();
        return View(data);
    }
    public async Task<IActionResult> Create() {
        return View();
    }
}