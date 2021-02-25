using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sekreter_Randevu_Sistemi
{
    public partial class randevuUpdateDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mesaj = Request.QueryString["msg"];
            Response.Write(mesaj);
            if (Convert.ToBoolean(Session["giris"]) != true)
                Response.Redirect("login.aspx?msg=Öncelikle giriş yapmalısınız!");
            if (!Page.IsPostBack)
            {
                DataSet klinikler = DBMethods.KlinikleriCek();
                DropDownList1.DataTextField = "KlinikAdi";
                DropDownList1.DataValueField = "KlinikID";
                DropDownList1.DataSource = klinikler.Tables[0];
                DropDownList1.DataBind();

                DataSet doktorlar = DBMethods.doktorlariCek(Convert.ToInt32(DropDownList1.SelectedItem.Value));
                DropDownList2.DataTextField = "Doktor";
                DropDownList2.DataValueField = "DoktorID";
                DropDownList2.DataSource = doktorlar.Tables[0];
                DropDownList2.DataBind();

                int RandevuNo = Convert.ToInt32(Session["randevuNo"]);
                string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
                SqlConnection baglanti = new SqlConnection(baglantiYolu);
                SqlCommand komut = new SqlCommand("select Randevular.RandevuNo,Randevular.TC,Randevular.Adi,Randevular.Soyadi,Klinikler.KlinikAdi,Doktorlar.Doktor,Randevular.Tarih,Saatler.Saat from Randevular inner join Klinikler on Klinikler.KlinikID = Randevular.KlinikID inner join Doktorlar on Doktorlar.DoktorID = Randevular.DoktorID inner join Saatler on Saatler.SaatID = Randevular.SaatID where RandevuNo='" + RandevuNo + "'", baglanti);
                komut.Parameters.AddWithValue("@RandevuNo", RandevuNo);

                baglanti.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    TextBox4.Text = reader[1].ToString();
                    TextBox5.Text = reader[2].ToString();
                    TextBox6.Text = reader[3].ToString();
                    DropDownList1.SelectedIndex = Convert.ToInt32(DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText(reader[4].ToString())));
                    DropDownList2.SelectedIndex = Convert.ToInt32(DropDownList2.Items.IndexOf(DropDownList2.Items.FindByText(reader[5].ToString())));
                    
                    TextBox7.Text = ((DateTime)reader[6]).ToShortDateString();
                    Session["Calendar"] = TextBox7.Text;

                    DataSet saatler = DBMethods.SaatleriCek2(Convert.ToInt32(DropDownList2.SelectedItem.Value), Convert.ToDateTime(TextBox7.Text), RandevuNo);
                    RadioButtonList1.DataTextField = "Saat";
                    RadioButtonList1.DataValueField = "SaatID";
                    RadioButtonList1.DataSource = saatler.Tables[0];
                    RadioButtonList1.DataBind();

                    Session["SaatRadioButton"] = reader[7].ToString();
                    RadioButtonList1.SelectedIndex = Convert.ToInt32(RadioButtonList1.Items.IndexOf(RadioButtonList1.Items.FindByText(reader[7].ToString())));
                }
                baglanti.Close();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataSet doktorlar = DBMethods.doktorlariCek(Convert.ToInt32(DropDownList1.SelectedItem.Value));
            DropDownList2.DataTextField = "Doktor";
            DropDownList2.DataValueField = "DoktorID";
            DropDownList2.DataSource = doktorlar.Tables[0];
            DropDownList2.DataBind();

            String asd = String.Format("{0}", Request.Form["TextBox7"]);


            if (doktorlar.Tables[0].Rows.Count != 0 && !String.IsNullOrEmpty(asd))
            {
                DateTime Tarih = DateTime.ParseExact(asd, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DataSet saatler = DBMethods.SaatleriCek(Convert.ToInt32(DropDownList2.SelectedItem.Value), Tarih.Date);
                RadioButtonList1.DataTextField = "Saat";
                RadioButtonList1.DataValueField = "SaatID";
                RadioButtonList1.DataSource = saatler.Tables[0];
                RadioButtonList1.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert alert-success", "alert('Bu kliniğe ait doktor bulunmamakta!'); setInterval(function(){location.href='randevuInsert.aspx';},250);", true);
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String asd = String.Format("{0}", Request.Form["TextBox7"]);

            if (DropDownList2.Items.Count > 0 && !String.IsNullOrEmpty(asd))
            {
                DateTime Tarih = DateTime.ParseExact(asd, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DataSet saatler = DBMethods.SaatleriCek(Convert.ToInt32(DropDownList2.SelectedItem.Value), Tarih.Date);
                RadioButtonList1.DataTextField = "Saat";
                RadioButtonList1.DataValueField = "SaatID";
                RadioButtonList1.DataSource = saatler.Tables[0];
                RadioButtonList1.DataBind();
            }
        }


        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {
            String asd = String.Format("{0}", Request.Form["TextBox7"]);

            if (DropDownList2.Items.Count > 0 && !String.IsNullOrEmpty(asd))
            {
                DateTime Tarih = DateTime.ParseExact(asd, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                DataSet saatler = DBMethods.SaatleriCek(Convert.ToInt32(DropDownList2.SelectedItem.Value), Tarih.Date);
                RadioButtonList1.DataTextField = "Saat";
                RadioButtonList1.DataValueField = "SaatID";
                RadioButtonList1.DataSource = saatler.Tables[0];
                RadioButtonList1.DataBind();
            }
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            if (DropDownList2.Items.Count > 0)
            {
                String asd = String.Format("{0}", Request.Form["TextBox5"]);
                if (!String.IsNullOrEmpty(asd))
                {
                    DateTime Tarih = DateTime.ParseExact(asd, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    string TC = String.Format("{0}", Request.Form["TextBox4"]);
                    String resultString = Regex.Match(TC, @"\d+").Value;
                    if (resultString.Length == TC.Length && resultString.Length == 11)
                    {
                        string Adi = String.Format("{0}", Request.Form["TextBox5"]);
                        string Soyadi = String.Format("{0}", Request.Form["TextBox6"]);
                        int KlinikID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
                        int DoktorID = Convert.ToInt32(DropDownList2.SelectedItem.Value);
                        int SaatID = Convert.ToInt32(RadioButtonList1.SelectedItem.Value);
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert alert-success", "alert('" + DBMethods.RandevuGuncelle(TC, Adi, Soyadi, KlinikID, DoktorID, Tarih, SaatID, Convert.ToInt32(Session["randevuNo"])) + "'); setInterval(function(){location.href='randevuSearch.aspx';},250);", true);
                    }
                    else {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert alert-success", "alert('TC Kimlik 11 haneli ve rakam olmalidir.');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert alert-success", "alert('Tarih seçiniz!');", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert alert-success", "alert('Bu kliniğe ait doktor bulunmamakta!'); setInterval(function(){location.href='randevuUpdateDelete.aspx';},250);", true);
            }
        }
    }
}