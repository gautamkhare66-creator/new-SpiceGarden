using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class Checkout : Page
    {
                public TextBox AddressInput { get { return (TextBox)FindControl("AddressInput"); } }
                public GridView SummaryGrid { get { return (GridView)FindControl("SummaryGrid"); } }
                public Label TotalLabel { get { return (Label)FindControl("TotalLabel"); } }
                public Label CustomerLabel { get { return (Label)FindControl("CustomerLabel"); } }
                public Label Message { get { return (Label)FindControl("Message"); } }
                public Button PlaceOrderButton { get { return (Button)FindControl("PlaceOrderButton"); } }
    }
}
