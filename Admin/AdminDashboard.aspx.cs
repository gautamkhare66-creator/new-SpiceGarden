using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.DAL;

namespace SpiceGardenWebForms.Admin
{
    public partial class AdminDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorizationHelper.EnsureAdmin(this);
            TotalUsersLabel.Text = new UserDAL().GetUserCount().ToString();
            TotalCategoriesLabel.Text = new CategoryDAL().GetCategoryCount().ToString();
            TotalMenuLabel.Text = new MenuDAL().GetMenuCount().ToString();
            TotalOrdersLabel.Text = new OrderDAL().GetOrderCount().ToString();
            TotalReservationsLabel.Text = new ReservationDAL().GetReservationCount().ToString();
        }
    }
}
