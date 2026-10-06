using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.Admin
{
    public partial class MenuManagement : Page
    {
        private readonly MenuBLL bll = new MenuBLL();
        private readonly BLL.CategoryBLL categoryBll = new BLL.CategoryBLL();
        private int editingId;
        protected void Page_Load(object sender, EventArgs e) { AuthorizationHelper.EnsureAdmin(this); CategoryInput.Items.Add(new ListItem("Select category", "0")); foreach (Category category in categoryBll.GetCategories()) CategoryInput.Items.Add(new ListItem(category.CategoryName, category.CategoryId.ToString())); Bind(); }
        protected void SaveButton_Click(object sender, EventArgs e) { try { MenuItem item = new MenuItem { MenuItemId = editingId, CategoryId = Convert.ToInt32(CategoryInput.SelectedValue), ItemName = ItemNameInput.Text.Trim(), Description = DescriptionInput.Text.Trim(), Price = Convert.ToDecimal(PriceInput.Text), ImageUrl = ImageUrlInput.Text.Trim(), IsAvailable = AvailableInput.Checked }; if (editingId == 0) bll.AddMenuItem(item); else bll.UpdateMenuItem(item); Message.Text = "Menu item saved."; editingId = 0; Reset(); Bind(); } catch (Exception) { Message.Text = "Unable to save the menu item."; } }
        protected void MenuGrid_RowCommand(object sender, GridViewCommandEventArgs e) { if (e.CommandName == "Edit") { MenuItem item = bll.GetMenuItem(Convert.ToInt32(e.CommandArgument)); if (item != null) { editingId = item.MenuItemId; CategoryInput.SelectedValue = item.CategoryId.ToString(); ItemNameInput.Text = item.ItemName; DescriptionInput.Text = item.Description; PriceInput.Text = item.Price.ToString(); ImageUrlInput.Text = item.ImageUrl; AvailableInput.Checked = item.IsAvailable; } } else if (e.CommandName == "Delete") { bll.DeleteMenuItem(Convert.ToInt32(e.CommandArgument)); Bind(); Message.Text = "Menu item deleted."; } }
        private void Bind() { MenuGrid.DataSource = bll.GetMenu(); MenuGrid.DataBind(); }
        private void Reset() { ItemNameInput.Text = string.Empty; DescriptionInput.Text = string.Empty; PriceInput.Text = string.Empty; ImageUrlInput.Text = string.Empty; AvailableInput.Checked = true; }
    }
}
