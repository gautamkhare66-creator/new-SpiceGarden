using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms.Admin
{
    public partial class Categories : Page
    {
                public TextBox CategoryNameInput { get { return (TextBox)FindControl("CategoryNameInput"); } }
                public TextBox DescriptionInput { get { return (TextBox)FindControl("DescriptionInput"); } }
                public Button SaveButton { get { return (Button)FindControl("SaveButton"); } }
                public Label Message { get { return (Label)FindControl("Message"); } }
                public GridView CategoriesGrid { get { return (GridView)FindControl("CategoriesGrid"); } }
    }
}
