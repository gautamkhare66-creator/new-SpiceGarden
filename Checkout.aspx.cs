using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms
{
    public partial class Checkout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null) { Response.Redirect("Login.aspx?returnUrl=" + Uri.EscapeDataString(Request.RawUrl), false); return; }
            Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"];
            if (cart == null || cart.Count == 0) { PlaceOrderButton.Visible = false; Message.Text = "Your cart is empty."; return; }
            List<KeyValuePair<MenuItem, int>> rows = new List<KeyValuePair<MenuItem, int>>();
            decimal total = 0;
            foreach (KeyValuePair<int, int> entry in cart) { MenuItem item = new MenuBLL().GetMenuItem(entry.Key); if (item != null) { rows.Add(new KeyValuePair<MenuItem, int>(item, entry.Value)); total += item.Price * entry.Value; } }
            SummaryGrid.DataSource = rows; SummaryGrid.DataBind(); TotalLabel.Text = total.ToString("C"); CustomerLabel.Text = "Logged in as " + Session["UserName"] + "\r\nDelivery address is entered below.";
        }
        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null) { Response.Redirect("Login.aspx", false); return; }
                Dictionary<int, int> cart = (Dictionary<int, int>)Session["Cart"]; if (cart == null || cart.Count == 0) { Message.Text = "Your cart is empty."; return; }
                if (string.IsNullOrWhiteSpace(AddressInput.Text)) { Message.Text = "Please enter a delivery address."; return; }
                int orderId = new OrderBLL().PlaceOrder(Convert.ToInt32(Session["UserId"]), AddressInput.Text.Trim(), cart, new MenuBLL().GetMenu());
                Session.Remove("Cart"); Message.Text = "Order #" + orderId + " was placed successfully."; Response.Redirect("MyOrders.aspx", false);
            }
            catch (Exception) { Message.Text = "Unable to save the order. Please try again."; }
        }
    }
}
