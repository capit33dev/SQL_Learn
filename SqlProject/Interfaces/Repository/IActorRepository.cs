using SqlProject.Models;

namespace SqlProject.Interfaces.Repository;

public interface IActorRepository
{
    Task<List<Actor>> GetActorsByNameAsync(string name);
}
