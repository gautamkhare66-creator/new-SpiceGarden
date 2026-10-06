using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;

namespace SpiceGardenWebForms
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PopularDishesRepeater.DataSource = new MenuBLL().GetMenu(null, null);
                PopularDishesRepeater.DataBind();
            }
            catch (Exception) { PopularDishesRepeater.Visible = false; }
        }
    }
}
