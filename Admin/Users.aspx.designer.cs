using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms.Admin
{
    public partial class Users : Page
    {
                public TextBox SearchInput { get { return (TextBox)FindControl("SearchInput"); } }
                public Button SearchButton { get { return (Button)FindControl("SearchButton"); } }
                public GridView UsersGrid { get { return (GridView)FindControl("UsersGrid"); } }
    }
}
