using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms.Admin
{
    public partial class Categories : Page
    {
        private readonly CategoryBLL bll = new CategoryBLL();
        private int editingId;
        protected void Page_Load(object sender, EventArgs e) { AuthorizationHelper.EnsureAdmin(this); Bind(); }
        protected void SaveButton_Click(object sender, EventArgs e) { try { Category category = new Category { CategoryId = editingId, CategoryName = CategoryNameInput.Text.Trim(), Description = DescriptionInput.Text.Trim() }; if (editingId == 0) bll.AddCategory(category); else bll.UpdateCategory(category); Message.Text = "Category saved."; editingId = 0; Reset(); Bind(); } catch (Exception) { Message.Text = "Unable to save the category."; } }
        protected void CategoriesGrid_RowCommand(object sender, GridViewCommandEventArgs e) { if (e.CommandName == "Edit") { Category category = bll.GetCategories().Find(x => x.CategoryId == Convert.ToInt32(e.CommandArgument)); if (category != null) { editingId = category.CategoryId; CategoryNameInput.Text = category.CategoryName; DescriptionInput.Text = category.Description; } } else if (e.CommandName == "Delete") { bll.DeleteCategory(Convert.ToInt32(e.CommandArgument)); Bind(); Message.Text = "Category deleted."; } }
        private void Bind() { CategoriesGrid.DataSource = bll.GetCategories(); CategoriesGrid.DataBind(); }
        private void Reset() { CategoryNameInput.Text = string.Empty; DescriptionInput.Text = string.Empty; }
    }
}
