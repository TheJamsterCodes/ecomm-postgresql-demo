using System.Collections;
using ECommPostgresDemo;
using Microsoft.Extensions.Configuration;
using Npgsql;

IConfiguration config = ConfigurationHelper.Config;

string connectionString = config.GetConnectionString("PostgreSQL");

await using var dataSource = NpgsqlDataSource.Create(connectionString);

// Retrieve all rows
await using (var cmd = dataSource.CreateCommand("SELECT * FROM products"))
await using (var reader = await cmd.ExecuteReaderAsync())
{    
    var products = new ArrayList();
    while (await reader.ReadAsync())
    {
        var product = new 
        { 
            Id = reader.GetInt32(0), 
            Name = reader.GetString(1), 
            Type = reader.GetString(2)
        };
        products.Add(product);
    }
}
