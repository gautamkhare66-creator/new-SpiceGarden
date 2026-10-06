using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.DAL
{
    public class UserDAL
    {
        private readonly DatabaseHelper database;

        public UserDAL() { database = new DatabaseHelper(); }

        public int Register(User user)
        {
            string sql = "INSERT INTO Users (FullName, Email, PasswordHash, Phone, Role, CreatedDate) VALUES (@FullName, @Email, @PasswordHash, @Phone, @Role, @CreatedDate); SELECT SCOPE_IDENTITY();";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", SqlDbType.NVarChar, 100) { Value = user.FullName },
                new SqlParameter("@Email", SqlDbType.NVarChar, 150) { Value = user.Email.ToLowerInvariant() },
                new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 255) { Value = user.PasswordHash },
                new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = user.Phone ?? (object)DBNull.Value },
                new SqlParameter("@Role", SqlDbType.NVarChar, 20) { Value = user.Role },
                new SqlParameter("@CreatedDate", SqlDbType.DateTime) { Value = DateTime.UtcNow }
            };
            return Convert.ToInt32(database.ExecuteScalar(sql, parameters));
        }

        public User FindByEmail(string email)
        {
            string sql = "SELECT UserId, FullName, Email, PasswordHash, Phone, Role, CreatedDate FROM Users WHERE Email = @Email";
            SqlParameter[] parameters = { new SqlParameter("@Email", SqlDbType.NVarChar, 150) { Value = email.ToLowerInvariant() } };
            using (SqlDataReader reader = database.ExecuteReader(sql, parameters))
            {
                if (!reader.Read()) return null;
                return new User { UserId = reader.GetInt32(0), FullName = reader.GetString(1), Email = reader.GetString(2), PasswordHash = reader.GetString(3), Phone = reader.IsDBNull(4) ? null : reader.GetString(4), Role = reader.GetString(5), CreatedDate = reader.GetDateTime(6) };
            }
        }

        public List<User> GetUsers(string search)
        {
            string sql = "SELECT UserId, FullName, Email, Phone, Role, CreatedDate FROM Users";
            if (!string.IsNullOrWhiteSpace(search))
            {
                sql += " WHERE FullName LIKE @Search OR Email LIKE @Search OR Role LIKE @Search";
            }
            SqlParameter[] parameters = string.IsNullOrWhiteSpace(search) ? new SqlParameter[0] : new[] { new SqlParameter("@Search", SqlDbType.NVarChar, 150) { Value = "%" + search.Trim() + "%" } };
            List<User> users = new List<User>();
            using (SqlDataReader reader = database.ExecuteReader(sql, parameters))
            {
                while (reader.Read()) users.Add(new User { UserId = reader.GetInt32(0), FullName = reader.GetString(1), Email = reader.GetString(2), Phone = reader.IsDBNull(3) ? null : reader.GetString(3), Role = reader.GetString(4), CreatedDate = reader.GetDateTime(5) });
            }
            return users;
        }

        public int GetUserCount() { return Convert.ToInt32(database.ExecuteScalar("SELECT COUNT(*) FROM Users")); }
    }
}
