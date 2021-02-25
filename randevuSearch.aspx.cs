using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sekreter_Randevu_Sistemi
{
    public partial class randevuSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mesaj = Request.QueryString["msg"];
            Response.Write(mesaj);
            if (Convert.ToBoolean(Session["giris"]) != true)
                Response.Redirect("login.aspx");
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = DBMethods.RandevuBul(String.Format("{0}", Request.Form["TextBox1"]));
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label randevuNo = (Label)GridView1.Rows[e.RowIndex].FindControl("randevuno");
            Session["randevuNo"] = randevuNo.Text;
            Response.Redirect("randevuUpdateDelete.aspx");
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label randevuNo = (Label)GridView1.Rows[e.RowIndex].FindControl("randevuno");
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            SqlCommand komutEkle = new SqlCommand("delete from Randevular where RandevuNo=@RandevuNo", baglanti);
            komutEkle.Parameters.AddWithValue("@RandevuNo", randevuNo.Text);
            baglanti.Open();
            komutEkle.ExecuteNonQuery();
            baglanti.Close();
            GridView1.DataSource = DBMethods.RandevuBul(String.Format("{0}", Request.Form["TextBox1"]));
            GridView1.DataBind();
        }
    }
}