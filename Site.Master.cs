using System;
using System.Web;
using System.Web.UI;

namespace SpiceGardenWebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Control loginNav = FindControl("LoginNav") as Control;
            Control registerNav = FindControl("RegisterNav") as Control;
            Control welcomeNav = FindControl("WelcomeNav") as Control;
            Control logoutNav = FindControl("LogoutNav") as Control;
            Control adminNav = FindControl("AdminNav") as Control;
            Label welcomeLabel = FindControl("WelcomeLabel") as Label;

            if (Session["UserId"] != null)
            {
                bool isAdmin = string.Equals(Session["Role"] as string, "Admin", StringComparison.OrdinalIgnoreCase);
                if (loginNav != null) loginNav.Visible = false;
                if (registerNav != null) registerNav.Visible = false;
                if (welcomeNav != null) welcomeNav.Visible = true;
                if (logoutNav != null) logoutNav.Visible = true;
                if (adminNav != null) adminNav.Visible = isAdmin;
                if (welcomeLabel != null) welcomeLabel.Text = "Welcome, " + (Session["UserName"] as string ?? "Guest");
            }
        }
    }
}
