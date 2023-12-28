using Dashboard.Server.Models;

namespace Dashboard.Server.Services.Interfaces
{
    public interface IOrdersService
    {
        Task<bool> PostToDb(List<Order> data);
        Task<List<Order>> GetAll();
    }
}
