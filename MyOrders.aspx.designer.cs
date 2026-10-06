using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class MyOrders : Page
    {
                public GridView OrdersGrid { get { return (GridView)FindControl("OrdersGrid"); } }
    }
}
