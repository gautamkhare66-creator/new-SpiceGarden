using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;

namespace SpiceGardenWebForms
{
    public partial class MyOrders : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null) { Response.Redirect("Login.aspx?returnUrl=" + Uri.EscapeDataString(Request.RawUrl), false); return; }
            OrdersGrid.DataSource = new OrderBLL().GetUserOrders(Convert.ToInt32(Session["UserId"])); OrdersGrid.DataBind();
        }
    }
}
