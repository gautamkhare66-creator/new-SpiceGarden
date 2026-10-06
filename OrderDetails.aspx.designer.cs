using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class OrderDetails : Page
    {
                public GridView DetailsGrid { get { return (GridView)FindControl("DetailsGrid"); } }
    }
}
