using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;

public class Fonksiyonlar : System.Web.UI.Page
{
    public SqlConnection bg;
    public string DosyaAdi;
	public Fonksiyonlar()
	{
		
	}

    public SqlConnection baglan()
    {
        try
        {
            bg = new SqlConnection("Data Source=GHOSTA\\SQLEXPRESS;Initial Catalog=kutuphane;Integrated Security=True");
            return bg;
        }
        catch
        {
            return bg;
        }
    }

    
 
    public DataTable TabloAl(string sql, object[] prmtr)
    {
        SqlCommand cmd = new SqlCommand(sql, baglan());
        for (int i = 0; i < prmtr.Length; i++) cmd.Parameters.Add("p" + i.ToString(), prmtr[i].ToString());
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adap.Fill(dt);
        cmd.Dispose();
        adap.Dispose();
        bg.Close();
        return dt;
    }

    public DataTable TabloAl2(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, baglan());
        SqlDataAdapter adap = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adap.Fill(dt);
        adap.Dispose();
        bg.Close();
        cmd.Dispose();
        return dt;
    }

    public void Guncelle(string sql, object[] dizi)
    {
        SqlCommand cmd = new SqlCommand(sql, baglan());
        for (int i = 0; i < dizi.Length; i++) cmd.Parameters.Add("p" + i.ToString(), dizi[i].ToString());
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        bg.Close();
    }
    
    public void Guncelle2(string sql)
    {
        SqlCommand cmd = new SqlCommand(sql, baglan());
        bg.Open();
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        bg.Close();
    }

    public string Temizle(string isim)
    {
        string Temp = "";
        Temp = isim.ToLower();
        Temp = Temp.Replace("*", "x");
        Temp = Temp.Replace("-", ""); Temp = Temp.Replace(" ", "-");
        Temp = Temp.Replace("ç", "c"); Temp = Temp.Replace("ğ", "g");
        Temp = Temp.Replace("ı", "i"); Temp = Temp.Replace("ö", "o");
        Temp = Temp.Replace("ş", "s"); Temp = Temp.Replace("ü", "u");
        Temp = Temp.Replace("\"", ""); Temp = Temp.Replace("/", "");
        Temp = Temp.Replace("(", ""); Temp = Temp.Replace(")", "");
        Temp = Temp.Replace("{", ""); Temp = Temp.Replace("}", "");
        Temp = Temp.Replace("%", ""); Temp = Temp.Replace("&", "");
        Temp = Temp.Replace("+", ""); Temp = Temp.Replace(",", "");
        Temp = Temp.Replace("?", ""); Temp = Temp.Replace("'", "");
        Temp = Temp.Replace("!", ""); Temp = Temp.Replace(":", "");
        Temp = Temp.Replace("İ", "i"); Temp = Temp.Replace("Ğ", "G");
        Temp = Temp.Replace("Ş", "S"); Temp = Temp.Replace("Ö", "O");
        Temp = Temp.Replace("Ç", "C"); Temp = Temp.Replace("Ü", "U");
        return Temp;
    }

    public void ResimYukle(FileUpload Yukle, int sabitt, string Klasor)
    {
        try
        {
            DosyaAdi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Millisecond + ".jpeg";
            string bresim = "", uzanti = System.IO.Path.GetExtension(Yukle.FileName).ToLower();
            Yukle.SaveAs(HttpContext.Current.Server.MapPath("~//" + Klasor + "//") + DosyaAdi);// İlk olarak fotoyu normal kayıt ediyoruz
            using (Bitmap OriginalBMb = new Bitmap(HttpContext.Current.Server.MapPath("~//" + Klasor + "//" + DosyaAdi)))//Kayıt ettğimiz fotoyu çağırıp üzerinde işlem yapıyoruz
            {
                double ResimYukseklik = OriginalBMb.Height;// yüksekliği belirtiyoruz
                double ResimUzunluk = OriginalBMb.Width;// genişliği belirtiyoruz
                int sabit = sabitt;//vermek istediğimiz oranı veriyoruz eğer foto 300 den yüksek veya geniş ise bu işlemi gerçekleştireceğiz
                double oran = 0;
                if (ResimUzunluk > ResimYukseklik && ResimUzunluk > sabit)
                {
                    oran = ResimUzunluk / ResimYukseklik;
                    ResimUzunluk = sabit;
                    ResimYukseklik = sabit / oran;
                }
                else if (ResimYukseklik > ResimUzunluk && ResimYukseklik > sabit)
                {
                    oran = ResimYukseklik / ResimUzunluk;
                    ResimYukseklik = sabit;
                    ResimUzunluk = sabit / oran;
                }
                Size newSizeb = new Size(Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));
                Bitmap Resizebmb = new Bitmap(OriginalBMb, newSizeb);
                Graphics grPhoto = Graphics.FromImage(Resizebmb);
                grPhoto.InterpolationMode = InterpolationMode.High; // resmin kalitesini ayarlıyoruz. Burada InterpolationMode özelliklerini bulabilirsini
                //grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality;
                //grPhoto.SmoothingMode = SmoothingMode.HighQuality;
                Resizebmb.Save(HttpContext.Current.Server.MapPath("~//" + Klasor + "//Y" + DosyaAdi), ImageFormat.Jpeg );
                OriginalBMb.Dispose();
            }
            File.Delete(HttpContext.Current.Server.MapPath("~//" + Klasor + "//" + DosyaAdi));//eski oluşturduğumuz resimi siliyoruz
        }
        catch
        {
            DosyaAdi = "";
        }
    }

    public void ResimYukle2(FileUpload Yukle, string Klasor)
    {
        try
        {
            DosyaAdi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Millisecond + ".jpg";
            string bresim = "", uzanti = System.IO.Path.GetExtension(Yukle.FileName).ToLower();
            Yukle.SaveAs(HttpContext.Current.Server.MapPath("~//" + Klasor + "//") + DosyaAdi);// İlk olarak fotoyu normal kayıt ediyoruz
            using (Bitmap OriginalBMb = new Bitmap(HttpContext.Current.Server.MapPath("~//" + Klasor + "//" + DosyaAdi)))//Kayıt ettğimiz fotoyu çağırıp üzerinde işlem yapıyoruz
            {
                double ResimYukseklik = OriginalBMb.Height;// yüksekliği belirtiyoruz
                double ResimUzunluk = OriginalBMb.Width;// genişliği belirtiyoruz
                
                Size newSizeb = new Size(Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));
                Bitmap Resizebmb = new Bitmap(OriginalBMb, newSizeb);
                Graphics grPhoto = Graphics.FromImage(Resizebmb);
                grPhoto.InterpolationMode = InterpolationMode.High; // resmin kalitesini ayarlıyoruz. Burada InterpolationMode özelliklerini bulabilirsini
                Resizebmb.Save(HttpContext.Current.Server.MapPath("~//" + Klasor + "//Y" + DosyaAdi), ImageFormat.Jpeg);
                OriginalBMb.Dispose();
            }
            File.Delete(HttpContext.Current.Server.MapPath("~//" + Klasor + "//" + DosyaAdi));//eski oluşturduğumuz resimi siliyoruz
        }
        catch
        {
            DosyaAdi = "";
        }
    }

    public void ResimYukleOranli(FileUpload Yukle, int genislik, int yukseklik, string Klasor)
    {
        try
        {
            DosyaAdi = DateTime.Now.Day.ToString() + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Millisecond + ".jpg";
            string bresim = "", uzanti = System.IO.Path.GetExtension(Yukle.FileName).ToLower();
            Yukle.SaveAs(HttpContext.Current.Server.MapPath("~//" + Klasor + "//") + DosyaAdi);// İlk olarak fotoyu normal kayıt ediyoruz
            using (Bitmap OriginalBMb = new Bitmap(HttpContext.Current.Server.MapPath("~//" + Klasor + "//" + DosyaAdi)))//Kayıt ettğimiz fotoyu çağırıp üzerinde işlem yapıyoruz
            {
                double ResimYukseklik = yukseklik;// yüksekliği belirtiyoruz
                double ResimUzunluk = genislik;// genişliği belirtiyoruz

                Size newSizeb = new Size(Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));
                Bitmap Resizebmb = new Bitmap(OriginalBMb, newSizeb);
                Graphics grPhoto = Graphics.FromImage(Resizebmb);
                grPhoto.InterpolationMode = InterpolationMode.High; // resmin kalitesini ayarlıyoruz. Burada InterpolationMode özelliklerini bulabilirsini
                Resizebmb.Save(HttpContext.Current.Server.MapPath("~//" + Klasor + "//Y" + DosyaAdi), ImageFormat.Jpeg);
                OriginalBMb.Dispose();
            }
            File.Delete(HttpContext.Current.Server.MapPath("~//" + Klasor + "//" + DosyaAdi));//eski oluşturduğumuz resimi siliyoruz
        }
        catch
        {
            DosyaAdi = "";
        }
    }


    
    public void KayitSil(string sql)
    {
        SqlCommand Kayitsilme = new SqlCommand(sql, baglan());
        bg.Open();
        Kayitsilme.ExecuteNonQuery();
        Kayitsilme.Dispose();
        bg.Close();
    }

    public void YeniKayit(string sql, object[] veriler)
    {
        SqlCommand Kaydet = new SqlCommand(sql, baglan());
        Kaydet.Parameters.AddWithValue("@p0",Convert.ToInt32(veriler[0]));
        Kaydet.Parameters.AddWithValue("@p1", Convert.ToDateTime(veriler[1]));
        Kaydet.Parameters.AddWithValue("@p2", Convert.ToInt32(veriler[2]));

        bg.Open();
        Kaydet.ExecuteNonQuery();
        Kaydet.Dispose();
        bg.Close();
    }

    public string FirmaLink(string firmaID, string firmad, string firmasektor)
    {
        firmad = Temizle(firmad);
        firmasektor = Temizle(firmasektor);
        return "Firma-" + firmasektor + "-" + firmad + "-" + firmaID + ".html";
    }

    public Boolean ResimFormat(FileUpload Dosya)
    {
        if (Dosya.PostedFile.ContentType.ToString() == "image/pjpeg" || Dosya.PostedFile.ContentType.ToString() == "image/gif") return true;
        else return false;
    }
    
    public void MetaEkle(string AnahtarKelimeler,string Tanim)
    {
        HtmlMeta hm;
        Page p = new Page();
        hm = new HtmlMeta();
        hm.Name = "keywords";
        hm.Content = AnahtarKelimeler;        
        p.Header.Controls.AddAt(0, hm);
        hm = new HtmlMeta();
        hm.Name = "description";
        hm.Content = Tanim;
        p.Header.Controls.AddAt(1, hm);
        hm = new HtmlMeta();
        hm.Name = "abstract";
        hm.Content = "Sancaktepe Rehberim, Firmalar";
        p.Header.Controls.AddAt(2, hm);
        hm.Name = "robots";
        hm.Content = "index,follow";
        p.Header.Controls.AddAt(3, hm);
        Page.Header.Controls.AddAt(0, hm);
    }

    public string taglari_at(string metin)
    {
        metin = Regex.Replace(metin, "<[^>]*>", string.Empty);
        metin = metin.Replace("<p>", "");
        metin = metin.Replace("</p>", "");
        return metin;
    }
}
