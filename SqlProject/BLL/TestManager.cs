using SqlProject.Interfaces.Managers;
using SqlProject.Interfaces.Models;
using SqlProject.Interfaces.Repository;
using SqlProject.Models;

namespace SqlProject.BLL;

public class TestManager : ITestManager
{
    private IActorRepository ActorRepository { get; }

    public TestManager(IActorRepository actorRepository)
    {
        ActorRepository = actorRepository;
    }

    public async Task<TestModel> GetTestModel()
    {
        await Task.Delay(1000); // Simulate some async work

        var random = new Random();
        var value = random.Next(1, 101);

        return new TestModel() { Text = "Hello World!", Value = value};
    }

    public async Task<List<Actor>> SearchActorsAsync(string name)
    {
        return await ActorRepository.GetActorsByNameAsync(name);
    }
}
