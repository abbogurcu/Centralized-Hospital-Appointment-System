using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sekreter_Randevu_Sistemi
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mesaj = Request.QueryString["msg"];
            Response.Write(mesaj);
            if (!Page.IsPostBack) {
                string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
                SqlConnection baglantiNesnesi = new SqlConnection(baglantiYolu);
                SqlCommand komutNesnesi = new SqlCommand("select * from periyotKontrol", baglantiNesnesi);
                baglantiNesnesi.Open();
                SqlDataReader reader = komutNesnesi.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        DateTime date = DateTime.Now.Date;
                        DateTime date2 = Convert.ToDateTime((reader["tarih"]));
                        if (date2 <= date) {
                            SqlConnection baglantiNesnesi2 = new SqlConnection(baglantiYolu);
                            SqlCommand komutNesnesi2 = new SqlCommand("delete from periyotKontrol where tarih='"+date2+"'", baglantiNesnesi2);
                            baglantiNesnesi2.Open();
                            komutNesnesi2.ExecuteNonQuery();
                            baglantiNesnesi2.Close();
                        }
                    }
                }
                baglantiNesnesi.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SekreterAdi = String.Format("{0}", Request.Form["TextBox1"]);
            string SekreterSifre = String.Format("{0}", Request.Form["TextBox2"]);
            bool varMi = DBMethods.loginCheck(SekreterAdi, SekreterSifre);
            if (varMi == false)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "alert('Yanlış kullanıcı adı veya şifre!'); setInterval(function(){location.href='login.aspx';},250);", true);
            else
            {
                Session["giris"] = true;
                Response.Redirect("checkpassword.aspx");
            }
        }
    }
}