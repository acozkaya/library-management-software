/*
 ALİ CAN ÖZKAYA 11.12.2016 SON GÜNCEL VERSİYON
 VTYS ÖDEV
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Giris : System.Web.UI.Page
{
    Fonksiyonlar fonksiyon = new Fonksiyonlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        Kontrol();
        Doldur(); // Aldığı kitaplar var ise listele
    }

    void Doldur()
    {
        if (Session["UyeID"] != null)
        {
            rp.DataSource = fonksiyon.TabloAl2("Select KitapID,(Select Adi From Kitaplar Where Kitaplar.KitapID=OduncKitaplar.KitapID) as KitapAdi, VerisTarih From OduncKitaplar Where UyeID=" + int.Parse(Session["UyeID"].ToString()) + "");
            rp.DataBind();
        }
    }

    void Kontrol()
    {
        if (Session["UyeID"] != null)
        {
            UpdatePanel1.Visible = false;
            Girisvar.Visible = true;
            DataTable dt = new DataTable();
            dt = fonksiyon.TabloAl2("Select * From Uyeler Where UyeID=" + int.Parse(Session["UyeID"].ToString()) + "");
            hosgeldin.Text = "Hoşgeldiniz Sn. " + dt.Rows[0]["Ad"].ToString() + " " + dt.Rows[0]["Soyad"].ToString(); 
        
        }
        else
        {
            UpdatePanel1.Visible = true ;
            Girisvar.Visible = false;
        }
    }

    protected void Gir_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            object[] kontrol = { eposta.Text, sifre.Text }; // Giriş bilgilerini al
            dt = fonksiyon.TabloAl("Select * From Uyeler Where Eposta=@p0 and Sifre=@p1", kontrol); // fonksiyon nesnesini kullarak veritabanında sorgulama yaptır
            if (dt.Rows.Count > 0) // girilen bilgilere uygun kayıt var mı?
            {
                Session["UyeID"] = dt.Rows[0]["UyeID"].ToString(); // giriş yapıldıysa üyenin ID bilgisini al
                if (Request.QueryString["return"] != null) // giriş sayfasına başka bir sayfadan gönderildiyse return querystrin değerine geri gönder
                {
                    Response.Redirect(Request.QueryString["return"]);
                }
                else
                    Response.Redirect(Request.RawUrl); // değilse olduğu sayfaya yönlendir
            }
            else
            {
                Sonuc.Text = "Kullanıcı adı veya şifreyi yanlış girdiniz";
                Sonuc.ForeColor = System.Drawing.Color.DarkRed;
            }
        }
        catch
        {
            Sonuc.Text = "Hata oluştu, tekrar deneyiniz";
            Sonuc.ForeColor = System.Drawing.Color.DarkRed;        
        }
    }

    // Kalan gün sayısını hesapla
    public string KalanGun(string tarih) 
    {
        TimeSpan ts = Convert.ToDateTime(tarih) - DateTime.Now; // İki tarih arasındaki farkı al
        if (DateTime.Now.Date <= Convert.ToDateTime(tarih)) // şimdiki zaman kitap verme tarihinden önceyse ise kalan gün sayısını gönder 
            return "<span style='color:DarkGreen; font-weight:bold;'> " + ts.Days.ToString() + " Gün</span>";
        else // değilse kitap süresi dolduğuna dair mesaj verdirt
            return "<span style='color:DarkRed; font-weight:bold;'>Süreniz dolmuştur, kitabı iade etmeniz gerekmektedir</span>" + ts.ToString();
    }

    protected void cikis_Click(object sender, EventArgs e)
    {
        Session.Abandon(); // Tüm session bilgileri sonlandırılır
        Response.Redirect("Giris.aspx"); // Giriş sayfasına yönlendirilir
    }

    protected void rp_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "iadeet")
        {
            fonksiyon.Guncelle2("Update Kitaplar set Rafta=1 Where KitapID=" + int.Parse(e.CommandArgument.ToString()) + "");
            fonksiyon.KayitSil("Delete From OduncKitaplar Where KitapID=" + int.Parse(e.CommandArgument.ToString()) + "");
            Doldur();
        }
    }
}