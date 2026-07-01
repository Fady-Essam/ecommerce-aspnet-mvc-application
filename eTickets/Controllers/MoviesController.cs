using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace eTickets.Controllers;
public class MoviesController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;
    public async Task<IActionResult> Index()
    {
        var data = await _context.Movies.ToListAsync();
        return View(data);
    }
}