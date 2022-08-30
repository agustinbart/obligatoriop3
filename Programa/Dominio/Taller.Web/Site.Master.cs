using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void cerrarSesion(object sender, EventArgs e)
        {
            if (Request.Cookies["IdUsuario"] != null)
            {
                Response.Cookies["IdUsuario"].Expires = DateTime.Now.AddDays(-1);
            }

            if (Request.Cookies["IdAdmin"] != null)
            {
                Response.Cookies["IdAdmin"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Redirect("~/");
        }
    }
}