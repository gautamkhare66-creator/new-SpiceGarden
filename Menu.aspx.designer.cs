using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class Menu : Page
    {
                public TextBox SearchInput { get { return (TextBox)FindControl("SearchInput"); } }
                public Button SearchButton { get { return (Button)FindControl("SearchButton"); } }
                public DropDownList CategoryFilter { get { return (DropDownList)FindControl("CategoryFilter"); } }
                public GridView MenuGrid { get { return (GridView)FindControl("MenuGrid"); } }
                public Label ErrorMessage { get { return (Label)FindControl("ErrorMessage"); } }
    }
}
