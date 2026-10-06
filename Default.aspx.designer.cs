using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class Default : Page
    {
        public Repeater PopularDishesRepeater { get; set; }
        public Default() { InitializeComponent(); }
        private void InitializeComponent() { }
    }
}
