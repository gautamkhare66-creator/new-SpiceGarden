using System;
using System.Web;
using System.Web.UI;

namespace SpiceGardenWebForms
{
    public static class AuthorizationHelper
    {
        public static bool IsAdmin(Page page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));
            return page.Session["UserId"] != null && string.Equals(page.Session["Role"] as string, "Admin", StringComparison.OrdinalIgnoreCase);
        }

        public static void EnsureAdmin(Page page)
        {
            if (page == null) throw new ArgumentNullException(nameof(page));
            if (page.Session["UserId"] == null)
            {
                page.Session["ReturnUrl"] = page.Request.RawUrl;
                page.Response.Redirect("../Login.aspx?returnUrl=" + Uri.EscapeDataString(page.Request.RawUrl), false);
            }
            else if (!IsAdmin(page))
            {
                page.Response.Redirect("../Default.aspx", false);
            }
        }
    }
}
