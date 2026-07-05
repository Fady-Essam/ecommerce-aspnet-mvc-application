using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        public Task<IEnumerable<Actor>> GetAll();
        public Task<Actor> GetById(int id);
        public Task Add(Actor actor);
        public Task Update(int id, Actor newActor);
        public Task Delete(int id);
    }
}
