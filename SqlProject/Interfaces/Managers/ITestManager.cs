using SqlProject.Interfaces.Models;
using SqlProject.Models;

namespace SqlProject.Interfaces.Managers;

public interface ITestManager
{
    public Task<TestModel> GetTestModel();
    Task<List<Actor>> SearchActorsAsync(string name);
}
