using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;

namespace SpiceGardenWebForms
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e) { if (Session["UserId"] != null) Response.Redirect("Default.aspx", false); }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL bll = new UserBLL();
                Models.User user = bll.Login(EmailInput.Text.Trim(), PasswordInput.Text);
                if (user == null) { ErrorMessage.Text = "Invalid email or password."; return; }
                Session["UserId"] = user.UserId; Session["UserName"] = user.FullName; Session["Role"] = user.Role;
                Response.Redirect(string.Equals(user.Role, "Admin", StringComparison.OrdinalIgnoreCase) ? "Admin/AdminDashboard.aspx" : "Default.aspx", false);
            }
            catch (Exception) { ErrorMessage.Text = "Unable to sign in. Please try again."; }
        }
    }
}
