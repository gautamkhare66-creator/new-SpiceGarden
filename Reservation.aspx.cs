using System;
using System.Web;
using System.Web.UI;
using SpiceGardenWebForms.BLL;
using SpiceGardenWebForms.Models;

namespace SpiceGardenWebForms
{
    public partial class Reservation : Page
    {
        protected void ReserveButton_Click(object sender, EventArgs e)
        {
            try
            {
                ReservationBLL bll = new ReservationBLL();
                Models.Reservation reservation = new Models.Reservation { CustomerName = CustomerNameInput.Text.Trim(), Email = EmailInput.Text.Trim(), Phone = PhoneInput.Text.Trim(), ReservationDate = DateTime.Parse(DateInput.Text), ReservationTime = TimeSpan.Parse(TimeInput.SelectedValue), NumberOfGuests = Convert.ToInt32(GuestsInput.SelectedValue), SpecialRequest = SpecialRequestInput.Text.Trim() };
                bll.AddReservation(reservation);
                ErrorMessage.Text = "Reservation submitted successfully. We will confirm it shortly."; ErrorMessage.CssClass = "success-message";
            }
            catch (Exception) { ErrorMessage.Text = "Unable to submit the reservation. Please try again."; ErrorMessage.CssClass = "error-message"; }
        }
    }
}
