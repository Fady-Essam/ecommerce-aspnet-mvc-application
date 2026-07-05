using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services;
public class ActorService(AppDbContext context) : IActorsService
{
    private readonly AppDbContext _context = context;

    public async Task Add(Actor actor)
    {
        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        CheckExist(id); // Validates existence; throws if not found
        await _context.Actors.Where(n => n.Id == id).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Actor>> GetAll()
    {
        return await _context.Actors.ToListAsync();
    }

    public async Task<Actor> GetById(int id)
    {
        return await Task.FromResult(CheckExist(id));
    }

    public async Task Update(int id, Actor newActor)
    {
        CheckExist(id); // Validates existence
        await _context.Actors.Where(n => n.Id == id).ExecuteUpdateAsync(n => n
            .SetProperty(a => a.FullName, newActor.FullName)
            .SetProperty(a => a.ProfilePictureURL, newActor.ProfilePictureURL)
            .SetProperty(a => a.Bio, newActor.Bio));
    }

    private Actor CheckExist(int id)
    {
        return _context.Actors.FirstOrDefault(n => n.Id == id)
            ?? throw new Exception($"The actor with id: {id} does not exist");
    }
}
