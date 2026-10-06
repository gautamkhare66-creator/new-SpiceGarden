using System;
using System.Web;
using System.Web.UI;

namespace SpiceGardenWebForms
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abstain();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Default.aspx", false);
        }
    }
}
