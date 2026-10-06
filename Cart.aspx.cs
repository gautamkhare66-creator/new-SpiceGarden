using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms
{
    public partial class Cart : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            if (cart == null || cart.Count == 0) { CartGrid.Visible = false; return; }
            List<KeyValuePair<MenuItem, int>> rows = new List<KeyValuePair<MenuItem, int>>();
            foreach (KeyValuePair<int, int> item in cart) { MenuItem menuItem = new MenuBLL().GetMenuItem(item.Key); if (menuItem != null) rows.Add(new KeyValuePair<MenuItem, int>(menuItem, item.Value)); }
            CartGrid.DataSource = rows; CartGrid.DataBind();
        }
        protected void CartGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            if (cart == null) return;
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Increase") cart[id]++;
            else if (e.CommandName == "Decrease") cart[id] = cart[id] > 1 ? cart[id] - 1 : 0;
            else if (e.CommandName == "Remove") cart.Remove(id);
            if (e.CommandName == "Decrease" && cart[id] == 0) cart.Remove(id);
            Response.Redirect("Cart.aspx", false);
        }
        protected void ClearButton_Click(object sender, EventArgs e) { Session.Remove("Cart"); Response.Redirect("Cart.aspx", false); }
    }
}
