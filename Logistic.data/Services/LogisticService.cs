using Logistic.data.Model;
using Logistic.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.Data.Services
{
    public class LogisticService:ILogisticService
    {
        LogisticDbContext logisticDbContext;
        public LogisticService(LogisticDbContext db)
        {
             logisticDbContext = db;
        }

        public async Task DeleteDepotByIdAsync(int id)
        {
            List<Vehicle> vehicles = await logisticDbContext.Vehicles.Select(o => o).Where(o => o.DepotId == id).ToListAsync();
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DepotId = null;
            }
            await logisticDbContext.SaveChangesAsync();
            logisticDbContext.Depots.Remove(await logisticDbContext.Depots.Select(d => d).Where(d => d.Id == id).SingleAsync());
            await logisticDbContext.SaveChangesAsync();
            await CalculateOrders();
        }

        public async Task DeleteOrderByIdAsync(int id)
        {
            Order order = await logisticDbContext.Orders.Select(o => o).Where(o => o.Id == id).SingleAsync();
            logisticDbContext.Orders.Remove(order);
            await logisticDbContext.SaveChangesAsync();
            await CalculateOrders();
        }

        public async Task DeleteUserByIdAsync(int id)
        {
            List<Order> orders = await logisticDbContext.Orders.Select(o => o).Where(o => o.UserId == id).ToListAsync();
            foreach(Order order in orders)
            {
                logisticDbContext.Orders.Remove(order);
            }
            await logisticDbContext.SaveChangesAsync();
            await CalculateOrders();
            User user = await logisticDbContext.Users.Select(u => u).Where(u => u.Id == id).SingleAsync();
            logisticDbContext.Users.Remove(user);
            await logisticDbContext.SaveChangesAsync();
            
        }

        public async Task DeleteVehicleByIdAsync(int id)
        {
            List<Order> orders = await logisticDbContext.Orders.Select(o => o).Where(o => o.VehicleId == id).ToListAsync();
            foreach (Order order in orders)
            {
                order.VehicleId = null;
            }
            await logisticDbContext.SaveChangesAsync();
            Vehicle vehicle = await logisticDbContext.Vehicles.Select(v => v).Where(v => v.Id == id).SingleAsync();
            logisticDbContext.Vehicles.Remove(vehicle);
            await logisticDbContext.SaveChangesAsync();
            await CalculateOrders();
        }

        public async Task<Depot> GetDepotByIdAsync(int id)
        {
            return await logisticDbContext.Depots.FindAsync(id);

        }

        public async Task<IEnumerable<Depot>> GetDepotsAsync()
        {
            return await logisticDbContext.Depots.OrderBy(g => g.Id).ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await logisticDbContext.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await logisticDbContext.Orders.OrderBy(g => g.ShippingDate).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateAsync(DateTime date)
        {
            return await logisticDbContext.Orders.Select(o => o).Where(o => o.ShippingDate.Date == date.Date && o.Delivered != "y").ToListAsync();
        }
        public async Task<IEnumerable<OrderWithEmail>> GetOrdersWithEmailAsync()
        {
            List<Order> orders =  await logisticDbContext.Orders.OrderBy(g => g.ShippingDate).ToListAsync();
            List<OrderWithEmail> orderWithEmails = new List<OrderWithEmail>();
            foreach(Order order in orders)
            {
                orderWithEmails.Add(new OrderWithEmail() {
                    order = order,
                    email = logisticDbContext.Users.Select(u => u).Where( u => u.Id == order.UserId).Select(u=> u.Email).Single()
                });
            }
            return orderWithEmails;

        }

        public async Task<IEnumerable<OrderWithEmail>> GetOrdersWithEmailByDateAsync(DateTime date)
        {
            List<Order> orders = await logisticDbContext.Orders.Select(o => o).Where(o => o.ShippingDate.Date == date.Date && o.Delivered!="y").ToListAsync();
            List<OrderWithEmail> orderWithEmails = new List<OrderWithEmail>();
            foreach (Order order in orders)
            {
                orderWithEmails.Add(new OrderWithEmail()
                {
                    order = order,
                    email = logisticDbContext.Users.Select(u => u).Where(u => u.Id == order.UserId).Select(u => u.Email).Single()
                });
            }
            return orderWithEmails;
        }
        public async Task<IEnumerable<OrderWithEmail>> GetOrdersWithEmailByDateDeliveredAsync(DateTime date)
        {
            List<Order> orders = await logisticDbContext.Orders.Select(o => o).Where(o => o.ShippingDate.Date == date.Date && o.Delivered =="y").ToListAsync();
            List<OrderWithEmail> orderWithEmails = new List<OrderWithEmail>();
            foreach (Order order in orders)
            {
                orderWithEmails.Add(new OrderWithEmail()
                {
                    order = order,
                    email = logisticDbContext.Users.Select(u => u).Where(u => u.Id == order.UserId).Select(u => u.Email).Single()
                });
            }
            return orderWithEmails;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await logisticDbContext.Users.FindAsync(id);
        }
        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int id)
        {
            return await logisticDbContext.Orders.Select(o => o).Where(o => o.UserId == id).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await logisticDbContext.Users.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int id)
        {
            return await logisticDbContext.Vehicles.FindAsync(id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            return await logisticDbContext.Vehicles.ToListAsync();
        }

        public async Task InsertOrUpdateDepotAsync(Depot depot)
        {
            if (depot.Id != null)
            {

                logisticDbContext.Depots.Update(depot);
                logisticDbContext.SaveChanges();
                await CalculateOrders();
            }
            else
            {

                await logisticDbContext.Depots.AddAsync(depot);
                logisticDbContext.SaveChanges();
            }
        }

        public async Task InsertOrUpdateOrderAsync(Order order)
        {
            if (order.Id != null)
            {

                logisticDbContext.Orders.Update(order);
                await logisticDbContext.SaveChangesAsync();
                await CalculateOrders();
     
            }
            else
            {
                await logisticDbContext.Orders.AddAsync(order);
                await logisticDbContext.SaveChangesAsync();
                await CalculateOrdersByShippingDate(order.ShippingDate);
                await logisticDbContext.SaveChangesAsync();
            }
            
        }


        public async Task InsertOrUpdateUserAsync(User user)
        {
            if (user.Id != null)
            {

                logisticDbContext.Users.Update(user);
            }
            else
            {
                await logisticDbContext.Users.AddAsync(user);
            }
            await logisticDbContext.SaveChangesAsync();
        }

        public async Task InsertOrUpdateVehicleAsync(Vehicle vehicle)
        {
            Depot depot = await logisticDbContext.Depots.Select(d => d).Where(d => d.Id == vehicle.DepotId).SingleAsync();

            if (vehicle.Id != null)
            {
                logisticDbContext.Vehicles.Update(vehicle);
            }
            else
            {
                await logisticDbContext.Vehicles.AddAsync(vehicle);
                
            }
            await logisticDbContext.SaveChangesAsync();
            await CalculateOrders();
            await logisticDbContext.SaveChangesAsync();
        }
        private async Task<IEnumerable<Order>> GetOrderByVehicleId(int id)
        {
            return await logisticDbContext.Orders.Select(o => o).Where(o => o.VehicleId == id).ToListAsync();
        }
        private async Task<IEnumerable<Order>> GetOrderByVehicleIdAndShippingDate(int id, DateTime shippingDate)
        {
            return await logisticDbContext.Orders.Select(o => o).Where(o => o.VehicleId == id && o.ShippingDate == shippingDate).ToListAsync();
        }
        private async Task CalculateOrders()
        {
            List<Order> orders = (List<Order>)await GetOrdersAsync();
            List<DateTime> ordersDate = orders.Select(d => d.ShippingDate.Date).ToList();
            List<DateTime> dates = new List<DateTime>();
            foreach(DateTime date in ordersDate)
            {
                if (!dates.Contains(date))
                {
                    dates.Add(date);
                }
            }
            foreach(DateTime date in dates)
            {
                await CalculateOrdersByShippingDate(date);
            }
            await logisticDbContext.SaveChangesAsync();


        }

        private async Task CalculateOrdersByShippingDate(DateTime shippingDate)
        {

            List<Vehicle> vehicles = (List<Vehicle>) await GetVehiclesAsync();

            List<Order> orders = (List<Order>)await GetOrdersByDateAsync(shippingDate);
            foreach(Order order in orders)
            {
                order.VehicleId = null;
            }
            Dictionary<Vehicle, List<Order>?> orderToVehicle = new Dictionary<Vehicle,  List<Order>?>();
            foreach (Vehicle vehicle1 in vehicles)
            {
                orderToVehicle.Add(vehicle1, null);
            }

            foreach (Order order in orders)
            {
                Order order2 = null;
                Vehicle vehicle2 = null;
                int vehicle2_lastX = 0;
                int vehicle2_lastY = 0;
                foreach (Vehicle vehicle in vehicles)
                {
                    int currentX;
                    int currentY;
                    if(orderToVehicle[vehicle] == null)
                    {
                        orderToVehicle[vehicle] = new List<Order>();
                    }
                    if (orderToVehicle[vehicle].Count() > 0)
                    {
                        currentX = orderToVehicle[vehicle].Last().TransportToX;
                        currentY = orderToVehicle[vehicle].Last().TransportToY;
                    }
                    else
                    {
                        if(vehicle.DepotId != null)
                        {
                            Depot depot = await GetDepotByIdAsync((int)vehicle.DepotId);
                            currentX = depot.LocationX;
                            currentY = depot.LocationY;
                        }
                        else
                        {
                            continue;
                        }                     
                    }
                    foreach(Order currentOrder in orders)
                    {
                        if(currentOrder.VehicleId != null ||currentOrder.Weight>vehicle.MaxWeight||currentOrder.Size>vehicle.MaxSize)
                        {
                            continue;
                        }
                        if(order2 == null)
                        {
                            order2 = currentOrder;
                            vehicle2 = vehicle;
                            vehicle2_lastX = currentX;
                            vehicle2_lastY = currentY;
                        }
                        else
                        {
                            if (Math.Sqrt((currentX - currentOrder.TransportFromX) * (currentX - currentOrder.TransportFromX)
                                + (currentY - currentOrder.TransportFromY) * (currentY - currentOrder.TransportFromY))
                            < Math.Sqrt((order2.TransportFromX - vehicle2_lastX) * (order2.TransportFromX - vehicle2_lastX)
                                + (order2.TransportFromY - vehicle2_lastY) * (order2.TransportFromY - vehicle2_lastY)))
                            {
                                order2 = currentOrder;
                                vehicle2 = vehicle;
                                vehicle2_lastX = currentX;
                                vehicle2_lastY = currentY;
                            }

                        }
                    }
                }
                if(vehicle2 != null)
                {
                    order2.VehicleId = vehicle2.Id;
                    order2.Vehicle = vehicle2;
                    orderToVehicle[vehicle2].Add(order2);
                }
                
            }
            
                        
        }

        
    }
}
