using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms
{
    public partial class Register : Page
    {
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserBLL bll = new UserBLL();
                User user = bll.Register(FullNameInput.Text, EmailInput.Text, PhoneInput.Text, PasswordInput.Text);
                bll.RegisterUser(user);
                Session["UserId"] = user.UserId; Session["UserName"] = user.FullName; Session["Role"] = user.Role;
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex) { ErrorMessage.Text = ex.Message; }
        }
    }
}
