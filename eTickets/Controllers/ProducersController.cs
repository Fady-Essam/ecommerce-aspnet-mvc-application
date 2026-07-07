using eTickets.Data.Services.Producers;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
namespace eTickets.Controllers;
public class ProducersController(IProducerService producerService) : Controller
{
    private readonly IProducerService _service = producerService;
    public async Task<IActionResult> Index() {
        var data = await _service.GetAllAsync();
        return View(data);
    }
    //Get: Producers/Details/1
    public async Task<IActionResult> Details(int id)
    {
        var producers = await _service.GetByIdAsync(id);
        if (producers == null) return View("NotFound");
        return View(producers);
    }
    //Get: Producers/Create
    public IActionResult Create() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
    {
        if (!ModelState.IsValid) return View(producer);
        await _service.AddAsync(producer);
        return RedirectToAction(nameof(Index));
    }
}