using Logistic.data.Model;
using Logistic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.Data.Services
{
    public interface ILogisticService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<IEnumerable<Depot>> GetDepotsAsync();
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();
        Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date);
        Task<User> GetUserByIdAsync(int id);
        Task<Depot> GetDepotByIdAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id);
        Task<Vehicle> GetVehicleByIdAsync(int id);
        Task InsertOrUpdateUserAsync(User user);
        Task InsertOrUpdateDepotAsync(Depot depot);
        Task InsertOrUpdateOrderAsync(Order order);
        Task InsertOrUpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleByIdAsync(int id);
        Task DeleteUserByIdAsync(int id);
        Task DeleteDepotByIdAsync(int id);
        Task DeleteOrderByIdAsync(int id);
        Task<IEnumerable<OrderWithEmail>> GetOrdersWithEmailAsync();
        Task<IEnumerable<OrderWithEmail>> GetOrdersWithEmailByDateAsync(DateTime date);
        Task<IEnumerable<OrderWithEmail>> GetOrdersWithEmailByDateDeliveredAsync(DateTime date);


    }
}
