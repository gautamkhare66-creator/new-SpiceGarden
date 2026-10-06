using System.Web.UI;

namespace SpiceGardenWebForms
{
    public partial class Login : Page
    {
                public TextBox EmailInput { get { return (TextBox)FindControl("EmailInput"); } }
                public TextBox PasswordInput { get { return (TextBox)FindControl("PasswordInput"); } }
                public Label ErrorMessage { get { return (Label)FindControl("ErrorMessage"); } }
                public Button LoginButton { get { return (Button)FindControl("LoginButton"); } }
    }
}
