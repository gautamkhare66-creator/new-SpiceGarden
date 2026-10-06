using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;

namespace SpiceGardenWebForms.Admin
{
    public partial class Users : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorizationHelper.EnsureAdmin(this);
            Bind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void Bind()
        {
            UsersGrid.DataSource = new UserBLL().GetUsers(SearchInput.Text);
            UsersGrid.DataBind();
        }
    }
}
