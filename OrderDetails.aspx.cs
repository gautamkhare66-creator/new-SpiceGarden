using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;

namespace SpiceGardenWebForms
{
    public partial class OrderDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null) { Response.Redirect("Login.aspx", false); return; }
            int orderId = Convert.ToInt32(Request.QueryString["orderId"]);
            bool isOwner = new OrderBLL().GetUserOrders(Convert.ToInt32(Session["UserId"])).Exists(order => order.OrderId == orderId);
            if (!isOwner) { Response.Redirect("MyOrders.aspx", false); return; }
            DetailsGrid.DataSource = new OrderBLL().GetOrderDetails(orderId); DetailsGrid.DataBind();
        }
    }
}
