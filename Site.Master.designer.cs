using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpiceGardenWebForms
{
    public partial class SiteMaster : MasterPage
    {
        private System.ComponentModel.IContainer components;
        protected override void Dispose(bool disposing) { if (components != null) components.Dispose(); base.Dispose(disposing); }
        protected void InitializeComponent() { }
        protected override System.Web.UI.PageContentPlaceHolder CreateMainContent() { return new PageContentPlaceHolder(); }
        public SiteMaster() { InitializeComponent(); }
        protected override void OnInit(Event args) { base.OnInit(args); }
    }
}
