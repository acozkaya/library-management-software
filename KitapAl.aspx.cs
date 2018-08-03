using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class KitapAl : System.Web.UI.Page
{
    Fonksiyonlar fonksiyon = new Fonksiyonlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        Kontrol();
    }

    void Kontrol()
    {
        if (Session["UyeID"] != null)
        {
            UpdatePanel1.Visible = true;
            if (Request.QueryString["id"] != null) KitapNo.Text = Request.QueryString["id"].ToString();
            Girisyok.Visible = false;
        }
        else
        {
            UpdatePanel1.Visible = false;
            Girisyok.Visible = true;
            if (Request.QueryString["id"] != null)
                HyperLink1.NavigateUrl = "Giris.aspx?return=KitapAl.aspx?id=" + Request.QueryString["id"].ToString();
            else
                HyperLink1.NavigateUrl = "Giris.aspx?return=KitapAl.aspx";
        }
    }
    protected void Al_Click(object sender, EventArgs e)
    {
        try
        {
            TimeSpan ts = Convert.ToDateTime(Tarih.Text) - DateTime.Now;
            if (ts.Days > 0) // Girilen tarih ileriki bir tarih mi?
            {
                DataTable dt = new DataTable();
                dt = fonksiyon.TabloAl2("Select * From Kitaplar Where KitapID=" + int.Parse(KitapNo.Text) + "");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Rafta"].ToString() == "1") // Seçilen kitap rafta var mı?
                    {
                        int kitapNo = Convert.ToInt32(KitapNo.Text);
                        fonksiyon.Guncelle2("Update kitaplar set Rafta='0' Where kitapID="+kitapNo.ToString()); // Rafta değil yap
                        object[] veri = { KitapNo.Text, Tarih.Text, Session["UyeID"].ToString() };
                        fonksiyon.YeniKayit("insert into OduncKitaplar(KitapID,VerisTarih,UyeID) Values(@p0,@p1,@p2)", veri); // Kitabı ödün al tablosuna kayıt et
                        KitapNo.Text = ""; Tarih.Text = "";
                        Sonuc.Text = "Kitap ödünç alma işleminiz gerçekleştirilmiştir";
                        Sonuc.ForeColor = System.Drawing.Color.DarkGreen;
                    }
                    else
                    {
                        Sonuc.Text = "Bu kitap şuan da rafta bulunmamaktadır";
                        Sonuc.ForeColor = System.Drawing.Color.DarkRed;
                    }
                }
                else
                {
                    Sonuc.Text = "Böyle bir kitap bulunmamaktadır";
                    Sonuc.ForeColor = System.Drawing.Color.DarkRed;
                }
            }
            else // Girilen tarih geçmiş zamana ait ise hata mesajı ver
            {
                Sonuc.Text = "Girilen tarih ileriki bir zaman olmalıdır";
                Sonuc.ForeColor = System.Drawing.Color.DarkRed;
            }
        }
        catch
        {
            Sonuc.Text = "Hata oluştu, tekrar deneyiniz - ";
            Sonuc.ForeColor = System.Drawing.Color.DarkRed;
        }
    }
}