using System;
using System.Collections.Generic;
using SpiceGardenWebForms.DAL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL orderDal;
        public OrderBLL() { orderDal = new OrderDAL(); }
        public int PlaceOrder(int userId, string deliveryAddress, Dictionary<int, int> cart, List<MenuItem> menuItems)
        {
            decimal total = 0;
            List<OrderItem> items = new List<OrderItem>();
            foreach (KeyValuePair<int, int> item in cart)
            {
                MenuItem menuItem = menuItems.Find(x => x.MenuItemId == item.Key);
                if (menuItem == null || item.Value <= 0) throw new ArgumentException("Invalid cart item.");
                decimal subtotal = menuItem.Price * item.Value;
                total += subtotal;
                items.Add(new OrderItem { MenuItemId = menuItem.MenuItemId, Quantity = item.Value, UnitPrice = menuItem.Price, Subtotal = subtotal });
            }
            if (items.Count == 0) throw new InvalidOperationException("Your cart is empty.");
            Order order = new Order { UserId = userId, OrderDate = DateTime.UtcNow, TotalAmount = total, Status = "Pending", DeliveryAddress = deliveryAddress };
            return orderDal.InsertOrder(order, items);
        }
        public List<Order> GetUserOrders(int userId) { return orderDal.GetUserOrders(userId); }
        public List<OrderItem> GetOrderDetails(int orderId) { return orderDal.GetOrderDetails(orderId); }
        public List<Order> GetOrders(string search = null) { return orderDal.GetOrders(search); }
        public void UpdateStatus(int orderId, string status) { orderDal.UpdateOrderStatus(orderId, status); }
    }
}
