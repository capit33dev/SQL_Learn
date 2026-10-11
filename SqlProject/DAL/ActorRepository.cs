using Npgsql;
using SqlProject.Interfaces.Repository;
using SqlProject.Models;

namespace SqlProject.DAL;

public class ActorRepository : IActorRepository
{
    private readonly string _connectionString;

    public ActorRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DvdRentalPostgresConnection")
                            ?? throw new InvalidOperationException("Connection string not found.");
    }

    public async Task<List<Actor>> GetActorsByNameAsync(string namePart)
    {
        var actors = new List<Actor>();

        using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        string query = "SELECT actor_id, first_name, last_name FROM actor WHERE first_name ILIKE @name";

        using var command = new NpgsqlCommand(query, connection);
        command.Parameters.AddWithValue("@name", $"%{namePart}%");

        using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            actors.Add(new Actor
            {
                ActorId = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2)
            });
        }

        return actors;
    }
}
