using System;
using System.Collections.Generic;
using SpiceGardenWebForms.DAL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.BLL
{
    public class MenuBLL
    {
        private readonly MenuDAL menuDal;
        public MenuBLL() { menuDal = new MenuDAL(); }
        public List<MenuItem> GetMenu(string search = null, int? categoryId = null) { return menuDal.GetMenu(search, categoryId); }
        public MenuItem GetMenuItem(int id) { return menuDal.GetMenuItem(id); }
        public int AddMenuItem(MenuItem item) { if (string.IsNullOrWhiteSpace(item.ItemName) || item.CategoryId <= 0 || item.Price <= 0) throw new ArgumentException("Please enter valid menu information."); return menuDal.Insert(item); }
        public void UpdateMenuItem(MenuItem item) { if (string.IsNullOrWhiteSpace(item.ItemName) || item.CategoryId <= 0 || item.Price <= 0) throw new ArgumentException("Please enter valid menu information."); menuDal.Update(item); }
        public void DeleteMenuItem(int id) { menuDal.Delete(id); }
    }
}
