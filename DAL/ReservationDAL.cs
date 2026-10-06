using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.DAL
{
    public class ReservationDAL
    {
        private readonly DatabaseHelper database;
        public ReservationDAL() { database = new DatabaseHelper(); }

        public int Insert(Reservation reservation)
        {
            string sql = "INSERT INTO Reservations (UserId, CustomerName, Email, Phone, ReservationDate, ReservationTime, NumberOfGuests, SpecialRequest, Status, CreatedDate) VALUES (@UserId, @CustomerName, @Email, @Phone, @ReservationDate, @ReservationTime, @NumberOfGuests, @SpecialRequest, @Status, @CreatedDate); SELECT SCOPE_IDENTITY();";
            return Convert.ToInt32(database.ExecuteScalar(sql, new SqlParameter("@UserId", SqlDbType.Int) { Value = reservation.UserId ?? (object)DBNull.Value }, new SqlParameter("@CustomerName", SqlDbType.NVarChar, 100) { Value = reservation.CustomerName }, new SqlParameter("@Email", SqlDbType.NVarChar, 150) { Value = reservation.Email }, new SqlParameter("@Phone", SqlDbType.NVarChar, 20) { Value = reservation.Phone }, new SqlParameter("@ReservationDate", SqlDbType.Date) { Value = reservation.ReservationDate }, new SqlParameter("@ReservationTime", SqlDbType.Time) { Value = reservation.ReservationTime }, new SqlParameter("@NumberOfGuests", SqlDbType.Int) { Value = reservation.NumberOfGuests }, new SqlParameter("@SpecialRequest", SqlDbType.NVarChar, 500) { Value = reservation.SpecialRequest ?? (object)DBNull.Value }, new SqlParameter("@Status", SqlDbType.NVarChar, 30) { Value = reservation.Status }, new SqlParameter("@CreatedDate", SqlDbType.DateTime) { Value = DateTime.UtcNow }));
        }

        public List<Reservation> GetReservations(string search = null)
        {
            string sql = "SELECT ReservationId, UserId, CustomerName, Email, Phone, ReservationDate, ReservationTime, NumberOfGuests, SpecialRequest, Status, CreatedDate FROM Reservations";
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(search)) { sql += " WHERE CustomerName LIKE @Search OR Email LIKE @Search OR Status LIKE @Search"; parameters.Add(new SqlParameter("@Search", SqlDbType.NVarChar, 150) { Value = "%" + search.Trim() + "%" }); }
            List<Reservation> result = new List<Reservation>();
            using (SqlDataReader reader = database.ExecuteReader(sql, parameters.ToArray()))
            {
                while (reader.Read()) result.Add(new Reservation { ReservationId = reader.GetInt32(0), UserId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1), CustomerName = reader.GetString(2), Email = reader.GetString(3), Phone = reader.GetString(4), ReservationDate = reader.GetDateTime(5), ReservationTime = reader.GetTimeSpan(6), NumberOfGuests = reader.GetInt32(7), SpecialRequest = reader.IsDBNull(8) ? null : reader.GetString(8), Status = reader.GetString(9), CreatedDate = reader.GetDateTime(10) });
            }
            return result;
        }

        public List<Reservation> GetUserReservations(int userId)
        {
            List<Reservation> result = new List<Reservation>();
            using (SqlDataReader reader = database.ExecuteReader("SELECT ReservationId, UserId, CustomerName, Email, Phone, ReservationDate, ReservationTime, NumberOfGuests, SpecialRequest, Status, CreatedDate FROM Reservations WHERE UserId = @UserId ORDER BY ReservationDate DESC", new SqlParameter("@UserId", SqlDbType.Int) { Value = userId }))
            {
                while (reader.Read()) result.Add(new Reservation { ReservationId = reader.GetInt32(0), UserId = reader.GetInt32(1), CustomerName = reader.GetString(2), Email = reader.GetString(3), Phone = reader.GetString(4), ReservationDate = reader.GetDateTime(5), ReservationTime = reader.GetTimeSpan(6), NumberOfGuests = reader.GetInt32(7), SpecialRequest = reader.IsDBNull(8) ? null : reader.GetString(8), Status = reader.GetString(9), CreatedDate = reader.GetDateTime(10) });
            }
            return result;
        }

        public void UpdateStatus(int id, string status) { database.ExecuteNonQuery("UPDATE Reservations SET Status = @Status WHERE ReservationId = @ReservationId", new SqlParameter("@Status", SqlDbType.NVarChar, 30) { Value = status }, new SqlParameter("@ReservationId", SqlDbType.Int) { Value = id }); }
        public int GetReservationCount() { return Convert.ToInt32(database.ExecuteScalar("SELECT COUNT(*) FROM Reservations")); }
    }
}
