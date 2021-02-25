using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sekreter_Randevu_Sistemi
{
    public partial class checkpassword1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mesaj = Request.QueryString["msg"];
            Response.Write(mesaj);
            if (Convert.ToBoolean(Session["giris"]) != true)
                Response.Redirect("login.aspx?msg=Öncelikle giriş yapmalısınız!");
        }
    }
}