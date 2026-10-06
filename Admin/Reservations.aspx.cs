using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SpiceGardenWebForms.BLL;

namespace SpiceGardenWebForms.Admin
{
    public partial class Reservations : Page
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

        protected void ReservationsGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                GridView grid = (GridView)sender;
                DropDownList statusSelect = (DropDownList)grid.Rows[e.RowIndex].FindControl("StatusSelect");
                new ReservationBLL().UpdateStatus(Convert.ToInt32(e.CommandArgument), statusSelect.SelectedValue);
                Bind();
            }
        }

        private void Bind()
        {
            ReservationsGrid.DataSource = new ReservationBLL().GetReservations(SearchInput.Text);
            ReservationsGrid.DataBind();
        }
    }
}
