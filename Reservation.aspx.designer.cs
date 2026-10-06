using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class Reservation : Page
    {
                public TextBox CustomerNameInput { get { return (TextBox)FindControl("CustomerNameInput"); } }
                public TextBox EmailInput { get { return (TextBox)FindControl("EmailInput"); } }
                public TextBox PhoneInput { get { return (TextBox)FindControl("PhoneInput"); } }
                public TextBox DateInput { get { return (TextBox)FindControl("DateInput"); } }
                public DropDownList TimeInput { get { return (DropDownList)FindControl("TimeInput"); } }
                public DropDownList GuestsInput { get { return (DropDownList)FindControl("GuestsInput"); } }
                public TextBox SpecialRequestInput { get { return (TextBox)FindControl("SpecialRequestInput"); } }
                public Label ErrorMessage { get { return (Label)FindControl("ErrorMessage"); } }
                public Button ReserveButton { get { return (Button)FindControl("ReserveButton"); } }
    }
}
