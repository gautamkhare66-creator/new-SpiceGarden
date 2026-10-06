using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms.Admin
{
    public partial class MenuManagement : Page
    {
                public DropDownList CategoryInput { get { return (DropDownList)FindControl("CategoryInput"); } }
                public TextBox ItemNameInput { get { return (TextBox)FindControl("ItemNameInput"); } }
                public TextBox DescriptionInput { get { return (TextBox)FindControl("DescriptionInput"); } }
                public TextBox PriceInput { get { return (TextBox)FindControl("PriceInput"); } }
                public TextBox ImageUrlInput { get { return (TextBox)FindControl("ImageUrlInput"); } }
                public CheckBox AvailableInput { get { return (CheckBox)FindControl("AvailableInput"); } }
                public Button SaveButton { get { return (Button)FindControl("SaveButton"); } }
                public Label Message { get { return (Label)FindControl("Message"); } }
                public GridView MenuGrid { get { return (GridView)FindControl("MenuGrid"); } }
    }
}
