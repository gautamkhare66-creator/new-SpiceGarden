using System.Web.UI;

namespace SpiceGardenWebForms.Admin
{
    public partial class AdminDashboard : Page
    {
                public Label TotalUsersLabel { get { return (Label)FindControl("TotalUsersLabel"); } }
                public Label TotalCategoriesLabel { get { return (Label)FindControl("TotalCategoriesLabel"); } }
                public Label TotalMenuLabel { get { return (Label)FindControl("TotalMenuLabel"); } }
                public Label TotalOrdersLabel { get { return (Label)FindControl("TotalOrdersLabel"); } }
                public Label TotalReservationsLabel { get { return (Label)FindControl("TotalReservationsLabel"); } }
    }
}
