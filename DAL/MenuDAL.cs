using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.DAL
{
    public class MenuDAL
    {
        private readonly DatabaseHelper database;
        public MenuDAL() { database = new DatabaseHelper(); }

        public List<MenuItem> GetMenu(string search = null, int? categoryId = null)
        {
            string sql = "SELECT m.MenuItemId, m.CategoryId, c.CategoryName, m.ItemName, m.Description, m.Price, m.ImageUrl, m.IsAvailable FROM MenuItems m INNER JOIN Categories c ON c.CategoryId = m.CategoryId WHERE m.IsAvailable = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(search)) { sql += " AND (m.ItemName LIKE @Search OR m.Description LIKE @Search OR c.CategoryName LIKE @Search)"; parameters.Add(new SqlParameter("@Search", SqlDbType.NVarChar, 150) { Value = "%" + search.Trim() + "%" }); }
            if (categoryId.HasValue) { sql += " AND m.CategoryId = @CategoryId"; parameters.Add(new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId.Value }); }
            List<MenuItem> result = new List<MenuItem>();
            using (SqlDataReader reader = database.ExecuteReader(sql, parameters.ToArray()))
            {
                while (reader.Read()) result.Add(new MenuItem { MenuItemId = reader.GetInt32(0), CategoryId = reader.GetInt32(1), CategoryName = reader.GetString(2), ItemName = reader.GetString(3), Description = reader.IsDBNull(4) ? null : reader.GetString(4), Price = reader.GetDecimal(5), ImageUrl = reader.IsDBNull(6) ? null : reader.GetString(6), IsAvailable = reader.GetBoolean(7) });
            }
            return result;
        }

        public MenuItem GetMenuItem(int id)
        {
            string sql = "SELECT MenuItemId, CategoryId, ItemName, Description, Price, ImageUrl, IsAvailable FROM MenuItems WHERE MenuItemId = @MenuItemId";
            using (SqlDataReader reader = database.ExecuteReader(sql, new SqlParameter("@MenuItemId", SqlDbType.Int) { Value = id }))
            {
                if (!reader.Read()) return null;
                return new MenuItem { MenuItemId = reader.GetInt32(0), CategoryId = reader.GetInt32(1), ItemName = reader.GetString(2), Description = reader.IsDBNull(3) ? null : reader.GetString(3), Price = reader.GetDecimal(4), ImageUrl = reader.IsDBNull(5) ? null : reader.GetString(5), IsAvailable = reader.GetBoolean(6) };
            }
        }

        public int Insert(MenuItem item)
        {
            string sql = "INSERT INTO MenuItems (CategoryId, ItemName, Description, Price, ImageUrl, IsAvailable) VALUES (@CategoryId, @ItemName, @Description, @Price, @ImageUrl, @IsAvailable); SELECT SCOPE_IDENTITY();";
            return Convert.ToInt32(database.ExecuteScalar(sql, new SqlParameter("@CategoryId", SqlDbType.Int) { Value = item.CategoryId }, new SqlParameter("@ItemName", SqlDbType.NVarChar, 150) { Value = item.ItemName }, new SqlParameter("@Description", SqlDbType.NVarChar, 500) { Value = item.Description ?? (object)DBNull.Value }, new SqlParameter("@Price", SqlDbType.Decimal, 10, 2) { Value = item.Price }, new SqlParameter("@ImageUrl", SqlDbType.NVarChar, 500) { Value = item.ImageUrl ?? (object)DBNull.Value }, new SqlParameter("@IsAvailable", SqlDbType.Bit) { Value = item.IsAvailable }));
        }

        public void Update(MenuItem item)
        {
            database.ExecuteNonQuery("UPDATE MenuItems SET CategoryId = @CategoryId, ItemName = @ItemName, Description = @Description, Price = @Price, ImageUrl = @ImageUrl, IsAvailable = @IsAvailable WHERE MenuItemId = @MenuItemId", new SqlParameter("@CategoryId", SqlDbType.Int) { Value = item.CategoryId }, new SqlParameter("@ItemName", SqlDbType.NVarChar, 150) { Value = item.ItemName }, new SqlParameter("@Description", SqlDbType.NVarChar, 500) { Value = item.Description ?? (object)DBNull.Value }, new SqlParameter("@Price", SqlDbType.Decimal, 10, 2) { Value = item.Price }, new SqlParameter("@ImageUrl", SqlDbType.NVarChar, 500) { Value = item.ImageUrl ?? (object)DBNull.Value }, new SqlParameter("@IsAvailable", SqlDbType.Bit) { Value = item.IsAvailable }, new SqlParameter("@MenuItemId", SqlDbType.Int) { Value = item.MenuItemId });
        }

        public void Delete(int id) { database.ExecuteNonQuery("DELETE FROM MenuItems WHERE MenuItemId = @MenuItemId", new SqlParameter("@MenuItemId", SqlDbType.Int) { Value = id }); }
        public int GetMenuCount() { return Convert.ToInt32(database.ExecuteScalar("SELECT COUNT(*) FROM MenuItems")); }
    }
}
