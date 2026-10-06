using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SpiceGardenWebForms.DAL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDal;
        public UserBLL() { userDal = new UserDAL(); }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create()) return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public bool ValidatePassword(string password, string hash) { return HashPassword(password) == hash; }
        public bool IsValidEmail(string email) { return new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").IsMatch(email); }
        public User Register(string fullName, string email, string phone, string password) { if (string.IsNullOrWhiteSpace(fullName) || !IsValidEmail(email) || password.Length < 8) throw new ArgumentException("Please enter valid registration details."); if (userDal.FindByEmail(email) != null) throw new InvalidOperationException("An account with this email already exists."); return new User { FullName = fullName.Trim(), Email = email.Trim().ToLowerInvariant(), Phone = phone?.Trim(), PasswordHash = HashPassword(password), Role = "Customer", CreatedDate = DateTime.UtcNow }; }
        public User Login(string email, string password) { User user = userDal.FindByEmail(email); return user != null && ValidatePassword(password, user.PasswordHash) ? user : null; }
        public List<User> GetUsers(string search = null) { return userDal.GetUsers(search); }
        public void RegisterUser(User user) { user.UserId = userDal.Register(user); }
    }
}
