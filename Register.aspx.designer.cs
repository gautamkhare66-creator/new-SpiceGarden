using System.Web.UI;

namespace SpiceGardenWebForms
{
    public partial class Register : Page
    {
                public TextBox FullNameInput { get { return (TextBox)FindControl("FullNameInput"); } }
                public TextBox EmailInput { get { return (TextBox)FindControl("EmailInput"); } }
                public TextBox PhoneInput { get { return (TextBox)FindControl("PhoneInput"); } }
                public TextBox PasswordInput { get { return (TextBox)FindControl("PasswordInput"); } }
                public TextBox ConfirmPasswordInput { get { return (TextBox)FindControl("ConfirmPasswordInput"); } }
                public Label ErrorMessage { get { return (Label)FindControl("ErrorMessage"); } }
                public Button RegisterButton { get { return (Button)FindControl("RegisterButton"); } }
    }
}
