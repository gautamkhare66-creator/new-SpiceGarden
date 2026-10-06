using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class Cart : Page
    {
                public Label Message { get { return (Label)FindControl("Message"); } }
                public GridView CartGrid { get { return (GridView)FindControl("CartGrid"); } }
    }
}
