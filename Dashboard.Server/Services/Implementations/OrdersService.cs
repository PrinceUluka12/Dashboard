using Dashboard.Server.Data;
using Dashboard.Server.Models;
using Dashboard.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Server.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _db;

        public OrdersService(AppDbContext db)
        {
           _db = db;
        }
        public async Task<List<Order>> GetAll()
        {
            try
            {
                var data = await _db.Orders.ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                return new List<Order>();
            }
        }

        public async Task<bool> PostToDb(List<Order> data)
        {
            try
            {
                await _db.Orders.AddRangeAsync(data);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
