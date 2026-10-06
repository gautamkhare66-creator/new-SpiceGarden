using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms
{
    public partial class Menu : Page
    {
        private readonly MenuBLL menuBll = new MenuBLL();
        private readonly BLL.CategoryBLL categoryBll = new BLL.CategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) CategoryFilter.Items.Add(new ListItem("All Categories", "0"));
            foreach (Models.Category category in categoryBll.GetCategories()) CategoryFilter.Items.Add(new ListItem(category.CategoryName, category.CategoryId.ToString()));
            BindMenu();
        }
        protected void SearchButton_Click(object sender, EventArgs e) { BindMenu(); }
        protected void CategoryFilter_SelectedIndexChanged(object sender, EventArgs e) { BindMenu(); }
        protected void MenuGrid_PageIndexChanging(object sender, GridViewPageEventArgs e) { MenuGrid.PageIndex = e.NewPageIndex; BindMenu(); }
        protected void MenuGrid_RowCommand(object sender, GridViewCommandEventArgs e) { if (e.CommandName == "Add") { int id = Convert.ToInt32(e.CommandArgument); MenuItem item = menuBll.GetMenuItem(id); AddToCart(item); Response.Redirect("Cart.aspx", false); } }
        private void BindMenu() { int? categoryId = CategoryFilter.SelectedValue == "0" ? (int?)null : Convert.ToInt32(CategoryFilter.SelectedValue); List<MenuItem> menu = menuBll.GetMenu(SearchInput.Text, categoryId); MenuGrid.DataSource = menu; MenuGrid.DataBind(); }
        private void AddToCart(MenuItem item) { if (item == null || !item.IsAvailable) return; Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"]; if (cart == null) { cart = new Dictionary<int, int>(); Session["Cart"] = cart; } int quantity; cart.TryGetValue(item.MenuItemId, out quantity); cart[item.MenuItemId] = quantity + 1; }
    }
}
