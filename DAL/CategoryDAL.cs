using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.DAL
{
    public class CategoryDAL
    {
        private readonly DatabaseHelper database;
        public CategoryDAL() { database = new DatabaseHelper(); }

        public List<Category> GetCategories(string search = null)
        {
            string sql = "SELECT CategoryId, CategoryName, Description FROM Categories";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += " WHERE CategoryName LIKE @Search OR Description LIKE @Search";
                parameters.Add(new SqlParameter("@Search", SqlDbType.NVarChar, 100) { Value = "%" + search.Trim() + "%" });
            }
            List<Category> result = new List<Category>();
            using (SqlDataReader reader = database.ExecuteReader(sql, parameters.ToArray()))
            {
                while (reader.Read()) result.Add(new Category { CategoryId = reader.GetInt32(0), CategoryName = reader.GetString(1), Description = reader.IsDBNull(2) ? null : reader.GetString(2) });
            }
            return result;
        }

        public int Insert(Category category)
        {
            string sql = "INSERT INTO Categories (CategoryName, Description) VALUES (@CategoryName, @Description); SELECT SCOPE_IDENTITY();";
            return Convert.ToInt32(database.ExecuteScalar(sql, new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100) { Value = category.CategoryName }, new SqlParameter("@Description", SqlDbType.NVarChar, 250) { Value = category.Description ?? (object)DBNull.Value }));
        }

        public void Update(Category category)
        {
            database.ExecuteNonQuery("UPDATE Categories SET CategoryName = @CategoryName, Description = @Description WHERE CategoryId = @CategoryId", new SqlParameter("@CategoryName", SqlDbType.NVarChar, 100) { Value = category.CategoryName }, new SqlParameter("@Description", SqlDbType.NVarChar, 250) { Value = category.Description ?? (object)DBNull.Value }, new SqlParameter("@CategoryId", SqlDbType.Int) { Value = category.CategoryId });
        }

        public void Delete(int categoryId) { database.ExecuteNonQuery("DELETE FROM Categories WHERE CategoryId = @CategoryId", new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId }); }
        public int GetCategoryCount() { return Convert.ToInt32(database.ExecuteScalar("SELECT COUNT(*) FROM Categories")); }
    }
}
