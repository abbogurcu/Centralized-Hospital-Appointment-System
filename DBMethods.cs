using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace Sekreter_Randevu_Sistemi
{
    public class DBMethods
    {
        public static bool loginCheck(string SekreterAdi, string SekreterSifre)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Sekreterler where SekreterAdi=@SekreterAdi and SekreterSifre=@SekreterSifre";
            SqlCommand komut = new SqlCommand();
            komut.CommandText = sql;
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@SekreterAdi", SekreterAdi);
            komut.Parameters.AddWithValue("@SekreterSifre", SekreterSifre);
            DataSet sonucDS = new DataSet();
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            baglanti.Open();
            adaptor.Fill(sonucDS);
            baglanti.Close();
            bool sonuc = false;
            if (sonucDS.Tables[0].Rows.Count > 0)
                sonuc = true;
            else
                sonuc = false;
            return sonuc;
        }


        public static DataSet KlinikleriCek()
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglantiNesnesi = new SqlConnection(baglantiYolu);

            string sql = "select * from Klinikler";
            SqlCommand komutNesnesi = new SqlCommand(sql, baglantiNesnesi);

            DataSet KliniklerDS = new DataSet();

            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            baglantiNesnesi.Open();
            adaptor.Fill(KliniklerDS);
            baglantiNesnesi.Close();

            return KliniklerDS;
        }


        public static DataSet doktorlariCek(int KlinikID)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglantiNesnesi = new SqlConnection(baglantiYolu);

            string sql = "select * from Doktorlar where KlinikID=" + KlinikID;
            SqlCommand komutNesnesi = new SqlCommand(sql, baglantiNesnesi);

            DataSet doktorlarDS = new DataSet();

            SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi);
            baglantiNesnesi.Open();
            adaptor.Fill(doktorlarDS);
            baglantiNesnesi.Close();

            return doktorlarDS;
        }

        public static DataSet SaatleriCek(int doktorID, DateTime newDate)
        {

            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglantiNesnesi = new SqlConnection(baglantiYolu);
            SqlCommand komutNesnesi = new SqlCommand("select periyotId from Doktorlar where DoktorID='" + doktorID + "'", baglantiNesnesi);
            int periyotId = 0;
            baglantiNesnesi.Open();
            SqlDataReader reader = komutNesnesi.ExecuteReader();
            while (reader.Read())
            {
                periyotId = Convert.ToInt32(reader["periyotId"]);
            }
            baglantiNesnesi.Close();


            SqlCommand komutNesnesi2 = new SqlCommand("select * from periyotKontrol where doktorId='" + doktorID + "'", baglantiNesnesi);
            baglantiNesnesi.Open();
            SqlDataReader reader2 = komutNesnesi2.ExecuteReader();
            DateTime olunca = new DateTime();
            while (reader2.Read())
            {
                olunca = ((DateTime)reader2["tarih"]).Date;
                if (newDate.Year < olunca.Year)
                {
                    periyotId = Convert.ToInt32(reader2["periyotId"]);
                }
                if (newDate.Year == olunca.Year)
                {
                    if (newDate.Month < olunca.Month)
                    {
                        periyotId = Convert.ToInt32(reader2["periyotId"]);
                    }
                }

                if (newDate.Year == olunca.Year)
                {
                    if (newDate.Month == olunca.Month)
                    {
                        if (newDate.Day < olunca.Day)
                        {
                            periyotId = Convert.ToInt32(reader2["periyotId"]);
                        }
                    }
                }
            }
            baglantiNesnesi.Close();

            SqlCommand komutNesnesi5 = new SqlCommand("select * from Randevular where DoktorID='" + doktorID + "' and Tarih=@Tarih", baglantiNesnesi);
            komutNesnesi5.Parameters.AddWithValue("@Tarih", newDate.Date);
            baglantiNesnesi.Open();
            SqlDataReader reader4 = komutNesnesi5.ExecuteReader();
            Boolean randevuVarmi = false;
            while (reader4.Read())
            {
                if (reader4.HasRows)
                {
                    randevuVarmi = true;
                }
            }
            baglantiNesnesi.Close();

            if (randevuVarmi == true)
            {
                SqlCommand komutNesnesi4 = new SqlCommand("select SaatID, Saat from Saatler where periyotID='"+periyotId+"' and SaatID NOT IN (select SaatID from Randevular where DoktorID='" + doktorID + "' and Tarih=@Tarih)", baglantiNesnesi);
                komutNesnesi4.Parameters.AddWithValue("@Tarih", newDate.Date);
                SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi4);
                DataSet sonucDS = new DataSet();

                baglantiNesnesi.Open();
                adaptor.Fill(sonucDS);
                baglantiNesnesi.Close();

                return sonucDS;
            }
            else
            {
                SqlCommand komutNesnesi4 = new SqlCommand("select * from Saatler where periyotId='" + periyotId + "'", baglantiNesnesi);
                komutNesnesi4.Parameters.AddWithValue("@Tarih", newDate.Date);
                SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi4);
                DataSet sonucDS = new DataSet();

                baglantiNesnesi.Open();
                adaptor.Fill(sonucDS);
                baglantiNesnesi.Close();

                return sonucDS;
            }
        }

        public static DataSet SaatleriCek2(int doktorID, DateTime newDate, int a)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglantiNesnesi = new SqlConnection(baglantiYolu);
            SqlCommand komutNesnesi = new SqlCommand("select periyotId from Doktorlar where DoktorID='" + doktorID + "'", baglantiNesnesi);
            int periyotId = 0;
            baglantiNesnesi.Open();
            SqlDataReader reader = komutNesnesi.ExecuteReader();
            while (reader.Read())
            {
                periyotId = Convert.ToInt32(reader["periyotId"]);
            }
            baglantiNesnesi.Close();


            SqlCommand komutNesnesi2 = new SqlCommand("select * from periyotKontrol where doktorId='" + doktorID + "'", baglantiNesnesi);
            baglantiNesnesi.Open();
            SqlDataReader reader2 = komutNesnesi2.ExecuteReader();
            DateTime olunca = new DateTime();
            while (reader2.Read())
            {
                olunca = ((DateTime)reader2["tarih"]).Date;
                if (newDate.Year < olunca.Year)
                {
                    periyotId = Convert.ToInt32(reader2["periyotId"]);
                }
                if (newDate.Year == olunca.Year)
                {
                    if (newDate.Month < olunca.Month)
                    {
                        periyotId = Convert.ToInt32(reader2["periyotId"]);
                    }
                }

                if (newDate.Year == olunca.Year)
                {
                    if (newDate.Month == olunca.Month)
                    {
                        if (newDate.Day < olunca.Day)
                        {
                            periyotId = Convert.ToInt32(reader2["periyotId"]);
                        }
                    }
                }
            }
            baglantiNesnesi.Close();

            SqlCommand komutNesnesi5 = new SqlCommand("select * from Randevular where DoktorID='" + doktorID + "' and Tarih=@Tarih", baglantiNesnesi);
            komutNesnesi5.Parameters.AddWithValue("@Tarih", newDate.Date);
            baglantiNesnesi.Open();
            SqlDataReader reader4 = komutNesnesi5.ExecuteReader();
            Boolean randevuVarmi2 = false;
            Boolean randevuBenimmi = false;
            int sayac = 0;
            while (reader4.Read())
            {
                if (reader4.HasRows)
                {
                    randevuVarmi2 = true;
                }
                if (Convert.ToInt32(reader4["RandevuNo"]) == a)
                {
                    randevuBenimmi = true;
                }
                sayac++;
            }
            baglantiNesnesi.Close();



            if (randevuVarmi2 == false || (sayac == 1 && randevuBenimmi == true))
            {
                SqlCommand komutNesnesi4 = new SqlCommand("select * from Saatler where periyotId='" + periyotId + "'", baglantiNesnesi);
                komutNesnesi4.Parameters.AddWithValue("@Tarih", newDate.Date);
                SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi4);
                DataSet sonucDS = new DataSet();

                baglantiNesnesi.Open();
                adaptor.Fill(sonucDS);
                baglantiNesnesi.Close();

                return sonucDS;
            }
            else if (sayac > 1 && randevuBenimmi == true)
            {
                int SaatID = 0;
                SqlCommand komutNesnesi6 = new SqlCommand("select SaatID from Randevular where RandevuNo='" + a + "'", baglantiNesnesi);
                baglantiNesnesi.Open();
                SqlDataReader reader5 = komutNesnesi6.ExecuteReader();
                while (reader5.Read())
                {
                    SaatID = Convert.ToInt32(reader5["SaatID"]);
                }
                baglantiNesnesi.Close();

                SqlCommand komutNesnesi4 = new SqlCommand("select * from Saatler where periyotId='" + periyotId + "' and SaatID NOT IN (select SaatID from Randevular where DoktorID='" + doktorID + "' and Tarih=@Tarih) or SaatID='" + SaatID + "'", baglantiNesnesi);
                komutNesnesi4.Parameters.AddWithValue("@Tarih", newDate.Date);
                SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi4);
                DataSet sonucDS = new DataSet();
                baglantiNesnesi.Open();
                adaptor.Fill(sonucDS);
                baglantiNesnesi.Close();

                return sonucDS;
            }
            else {
                SqlCommand komutNesnesi4 = new SqlCommand("select * from Saatler where periyotId='" + periyotId + "' and SaatID NOT IN (select SaatID from Randevular where DoktorID='" + doktorID + "' and Tarih=@Tarih)", baglantiNesnesi);
                komutNesnesi4.Parameters.AddWithValue("@Tarih", newDate.Date);
                SqlDataAdapter adaptor = new SqlDataAdapter(komutNesnesi4);
                DataSet sonucDS = new DataSet();
                baglantiNesnesi.Open();
                adaptor.Fill(sonucDS);
                baglantiNesnesi.Close();
                return sonucDS;
            }
        }

        public static String RandevuEkle(String TC,String Adi,String Soyadi,int KlinikID,int DoktorID,DateTime Tarih,int SaatID)
        {
            string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baran\Documents\Hastane Bilgi Sistemi\Hastane Bilgi Sistemi\Hastane.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komutNesnesi = new SqlCommand("select * from Hasta where TC=@TC", baglanti);
            komutNesnesi.Parameters.AddWithValue("@TC", TC);
            SqlDataReader drr = komutNesnesi.ExecuteReader();
            if (drr.Read())
            {
                baglanti.Close();
            }
            else
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand komutEkle2 = new SqlCommand("insert into Hasta values(@TC,@adi,@soyadi);", baglanti);
                komutEkle2.Parameters.AddWithValue("@TC", TC);
                komutEkle2.Parameters.AddWithValue("@adi", Adi);
                komutEkle2.Parameters.AddWithValue("@soyadi", Soyadi);
                komutEkle2.ExecuteNonQuery();
                baglanti.Close();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            baglanti.Open();
            SqlCommand komutKontrol = new SqlCommand("select * from Randevular where DoktorID=@DoktorID and Tarih=@Tarih and SaatID=@SaatID", baglanti);
            komutKontrol.Parameters.AddWithValue("@DoktorID", DoktorID);
            komutKontrol.Parameters.AddWithValue("@Tarih", Tarih);
            komutKontrol.Parameters.AddWithValue("@SaatID", SaatID);
            SqlDataReader dr = komutKontrol.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Close();
                return "Seçilen Doktor için böyle bir randevu zaten mevcut,farklı gün veya saat deneyin!";
            }
            else
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand komutEkle = new SqlCommand("insert into Randevular(TC,Adi,Soyadi,KlinikID,DoktorID,Tarih,SaatID) values(@TC,@adi,@soyadi,@KlinikID,@DoktorID,@Tarih,@SaatID);", baglanti);
                komutEkle.Parameters.AddWithValue("@TC", TC);
                komutEkle.Parameters.AddWithValue("@adi", Adi);
                komutEkle.Parameters.AddWithValue("@soyadi", Soyadi);
                komutEkle.Parameters.AddWithValue("@KlinikID", KlinikID);
                komutEkle.Parameters.AddWithValue("@DoktorID", DoktorID);
                komutEkle.Parameters.AddWithValue("@Tarih", Tarih);
                komutEkle.Parameters.AddWithValue("@SaatID", SaatID);
                komutEkle.ExecuteNonQuery();
                baglanti.Close();
                return "Randevu eklendi!";
            }
        }


        public static String RandevuGuncelle(String TC, String Adi, String Soyadi, int KlinikID, int DoktorID, DateTime Tarih, int SaatID,int randevuNo)
        {
            string baglantiYolu = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Baran\Documents\Hastane Bilgi Sistemi\Hastane Bilgi Sistemi\Hastane.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            baglanti.Open();
            SqlCommand komutKontrol = new SqlCommand("select * from Randevular where DoktorID=@DoktorID and Tarih=@Tarih and SaatID=@SaatID", baglanti);
            komutKontrol.Parameters.AddWithValue("@DoktorID", DoktorID);
            komutKontrol.Parameters.AddWithValue("@Tarih", Tarih);
            komutKontrol.Parameters.AddWithValue("@SaatID", SaatID);
            SqlDataReader dr = komutKontrol.ExecuteReader();
            if (dr.Read())
            {
                baglanti.Close();
                return "Seçilen Doktor için böyle bir randevu zaten mevcut,farklı gün veya saat deneyin!";
            }
            else
            {
                baglanti.Close();
                baglanti.Open();
                SqlCommand komutEkle = new SqlCommand("update Randevular set KlinikID=@KlinikID,DoktorID=@DoktorID,Tarih=@Tarih,SaatID=@SaatID where RandevuNo='"+randevuNo+"'", baglanti);
                komutEkle.Parameters.AddWithValue("@TC", TC);
                komutEkle.Parameters.AddWithValue("@adi", Adi);
                komutEkle.Parameters.AddWithValue("@soyadi", Soyadi);
                komutEkle.Parameters.AddWithValue("@KlinikID", KlinikID);
                komutEkle.Parameters.AddWithValue("@DoktorID", DoktorID);
                komutEkle.Parameters.AddWithValue("@Tarih", Tarih);
                komutEkle.Parameters.AddWithValue("@SaatID", SaatID);
                komutEkle.ExecuteNonQuery();
                baglanti.Close();
                return "Randevu güncellendi!";
            }
        }



        public static DataSet RandevuBul(string TC)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select Randevular.RandevuNo,Randevular.TC,Randevular.Adi,Randevular.Soyadi,Klinikler.KlinikAdi,Doktorlar.Doktor,Randevular.Tarih,Saatler.Saat from Randevular inner join Klinikler on Klinikler.KlinikID = Randevular.KlinikID inner join Doktorlar on Doktorlar.DoktorID = Randevular.DoktorID inner join Saatler on Saatler.SaatID = Randevular.SaatID where TC like @TC+'%'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@TC", TC);
            SqlDataAdapter adaptor = new SqlDataAdapter();
            adaptor.SelectCommand = komut;
            DataSet sonucAra = new DataSet();
            baglanti.Open();
            adaptor.Fill(sonucAra);
            baglanti.Close();
            return sonucAra;
        }


        public static void RandevuSil(int RandevuNo)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "delete from Randevular where RandevuNo=@RandevuNo";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@RandevuNo", RandevuNo);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public static int doktorGirisKontrol(String doktorAdi, String doktorSifre)
        {
            string baglantiYolu = ConfigurationManager.ConnectionStrings["Hastane"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select * from Doktorlar where DoktorAdi='" + doktorAdi + "' and DoktorSifre='" + doktorSifre + "'";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            int periyotId = 0;
            while (reader.Read())
            {
                periyotId = Convert.ToInt32(reader["periyotId"]);
            }

            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            return periyotId;
        }
    }
}