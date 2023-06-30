using Business.Interfaces;
using Data.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Business.Services;
public class EmployeeService : IEmployeeService
{
    private readonly Container _container;

    public EmployeeService(CosmosClient cosmosDbClient, string databaseName, string containerName)
    {
        _container = cosmosDbClient.GetContainer(databaseName, containerName);
    }
    public async Task AddAsync(Employee employee)
    {
        await _container.CreateItemAsync(employee, new PartitionKey(employee.Id));
    }

    public async Task DeleteAsync(string id)
    {
        await _container.DeleteItemAsync<Employee>(id, new PartitionKey(id));
    }

    public async Task<IEnumerable<Employee>> GetAllEmployees()
    {
        var OrderedEmployees = _container.GetItemLinqQueryable<Employee>();
        var iterator = OrderedEmployees.ToFeedIterator();
        var result = await iterator.ReadNextAsync();
        return result;
    }

    public async Task<Employee> GetById(string id)
    {
        try
        {
            var response = await _container.ReadItemAsync<Employee>(id, new PartitionKey(id));
            return response.Resource;
        }catch(Exception)
        {
            throw;
        } 
    }

    public async Task UpdateAsync(string id, Employee employee)
    {
        await _container.UpsertItemAsync(employee, new PartitionKey(id));
    }
}
