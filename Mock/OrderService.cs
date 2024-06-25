using System.Collections.Generic;
using System.Linq;
using order.Models;

namespace order.Mock
{
    public interface IOrderService
    {
        void AddOrder(OrderModel order);
        List<OrderModel> GetOrders();
        OrderModel? GetOrderById(int id);
        void RemoveOrder(OrderModel order);
        void UpdateOrder(OrderModel order);
    }

    public class OrderService : IOrderService
    {
        private List<OrderModel> _orders;
        private readonly IMenuService _menuService;
        private readonly ICategoryService _categoryService;

        public OrderService(IMenuService menuService, ICategoryService categoryService)
        {
            _orders = new List<OrderModel>();
            _menuService = menuService;
            _categoryService = categoryService;
        }

        public void AddOrder(OrderModel order)
        {
            order.OrderID = _orders.Count + 1;
            order.Menu = _menuService.GetMenuById(order.DishID);
            _orders.Add(order);
        }

        public List<OrderModel> GetOrders()
        {
            foreach (var order in _orders)
            {
                order.Menu = _menuService.GetMenuById(order.DishID);
                if (order.Menu != null)
                {
                    order.Menu.Category = _categoryService.GetCategoryById(order.Menu.CategoryID);
                }
            }
            return _orders;
        }

        public OrderModel? GetOrderById(int id)
        {
            return _orders.FirstOrDefault(o => o.OrderID == id);
        }
        public void RemoveOrder(OrderModel order)
        {
            _orders.Remove(order);
        }

        public void UpdateOrder(OrderModel order)
        {
            var existingOrder = GetOrderById(order.OrderID);
            if (existingOrder != null)
            {
                existingOrder.DishID = order.DishID;
                existingOrder.Menu = order.Menu;
                existingOrder.Qty = order.Qty;
                existingOrder.OrderTime = order.OrderTime;
                existingOrder.DeliveryTime = order.DeliveryTime;
                existingOrder.TableNumber = order.TableNumber;
            }
        }
    }
}
