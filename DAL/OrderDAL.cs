using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.DAL
{
    public class OrderDAL
    {
        private readonly DatabaseHelper database;
        public OrderDAL() { database = new DatabaseHelper(); }

        public int InsertOrder(Order order, List<OrderItem> items)
        {
            using (SqlConnection connection = database.OpenConnection())
            using (SqlTransaction transaction = connection.BeginTransaction())
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.Transaction = transaction;
                command.CommandText = "INSERT INTO Orders (UserId, OrderDate, TotalAmount, Status, DeliveryAddress) VALUES (@UserId, @OrderDate, @TotalAmount, @Status, @DeliveryAddress); SELECT SCOPE_IDENTITY();";
                command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.Int) { Value = order.UserId });
                command.Parameters.Add(new SqlParameter("@OrderDate", SqlDbType.DateTime) { Value = order.OrderDate });
                command.Parameters.Add(new SqlParameter("@TotalAmount", SqlDbType.Decimal, 10, 2) { Value = order.TotalAmount });
                command.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar, 30) { Value = order.Status });
                command.Parameters.Add(new SqlParameter("@DeliveryAddress", SqlDbType.NVarChar, 500) { Value = order.DeliveryAddress ?? (object)DBNull.Value });
                int orderId = Convert.ToInt32(command.ExecuteScalar());
                command.CommandText = "INSERT INTO OrderItems (OrderId, MenuItemId, Quantity, UnitPrice, Subtotal) VALUES (@OrderId, @MenuItemId, @Quantity, @UnitPrice, @Subtotal)";
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@OrderId", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@MenuItemId", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@UnitPrice", SqlDbType.Decimal, 10, 2));
                command.Parameters.Add(new SqlParameter("@Subtotal", SqlDbType.Decimal, 10, 2));
                foreach (OrderItem item in items)
                {
                    command.Parameters["@OrderId"].Value = orderId;
                    command.Parameters["@MenuItemId"].Value = item.MenuItemId;
                    command.Parameters["@Quantity"].Value = item.Quantity;
                    command.Parameters["@UnitPrice"].Value = item.UnitPrice;
                    command.Parameters["@Subtotal"].Value = item.Subtotal;
                    command.ExecuteNonQuery();
                }
                transaction.Commit();
                return orderId;
            }
        }

        public List<Order> GetOrders(string search = null)
        {
            string sql = "SELECT OrderId, UserId, OrderDate, TotalAmount, Status, DeliveryAddress FROM Orders";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(search)) { sql += " WHERE Status LIKE @Search OR DeliveryAddress LIKE @Search"; parameters.Add(new SqlParameter("@Search", SqlDbType.NVarChar, 500) { Value = "%" + search.Trim() + "%" }); }
            List<Order> result = new List<Order>();
            using (SqlDataReader reader = database.ExecuteReader(sql, parameters.ToArray()))
            {
                while (reader.Read()) result.Add(new Order { OrderId = reader.GetInt32(0), UserId = reader.GetInt32(1), OrderDate = reader.GetDateTime(2), TotalAmount = reader.GetDecimal(3), Status = reader.GetString(4), DeliveryAddress = reader.IsDBNull(5) ? null : reader.GetString(5) });
            }
            return result;
        }

        public List<Order> GetUserOrders(int userId)
        {
            List<Order> result = new List<Order>();
            using (SqlDataReader reader = database.ExecuteReader("SELECT OrderId, UserId, OrderDate, TotalAmount, Status, DeliveryAddress FROM Orders WHERE UserId = @UserId ORDER BY OrderDate DESC", new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }))
            {
                while (reader.Read()) result.Add(new Order { OrderId = reader.GetInt32(0), UserId = reader.GetInt32(1), OrderDate = reader.GetDateTime(2), TotalAmount = reader.GetDecimal(3), Status = reader.GetString(4), DeliveryAddress = reader.IsDBNull(5) ? null : reader.GetString(5) });
            }
            return result;
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            List<OrderItem> result = new List<OrderItem>();
            using (SqlDataReader reader = database.ExecuteReader("SELECT oi.OrderItemId, oi.OrderId, oi.MenuItemId, m.ItemName, oi.Quantity, oi.UnitPrice, oi.Subtotal FROM OrderItems oi INNER JOIN MenuItems m ON m.MenuItemId = oi.MenuItemId WHERE oi.OrderId = @OrderId", new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderId }))
            {
                while (reader.Read()) result.Add(new OrderItem { OrderItemId = reader.GetInt32(0), OrderId = reader.GetInt32(1), MenuItemId = reader.GetInt32(2), ItemName = reader.GetString(3), Quantity = reader.GetInt32(4), UnitPrice = reader.GetDecimal(5), Subtotal = reader.GetDecimal(6) });
            }
            return result;
        }

        public void UpdateOrderStatus(int orderId, string status) { database.ExecuteNonQuery("UPDATE Orders SET Status = @Status WHERE OrderId = @OrderId", new SqlParameter("@Status", SqlDbType.NVarChar, 30) { Value = status }, new SqlParameter("@OrderId", SqlDbType.Int) { Value = orderId }); }
        public int GetOrderCount() { return Convert.ToInt32(database.ExecuteScalar("SELECT COUNT(*) FROM Orders")); }
        public decimal GetTotalSales() { return Convert.ToDecimal(database.ExecuteScalar("SELECT COALESCE(SUM(TotalAmount), 0) FROM Orders WHERE Status = 'Delivered'")); }
    }
}
