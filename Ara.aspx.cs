using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ara : System.Web.UI.Page
{
    Fonksiyonlar fonksiyon = new Fonksiyonlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.AllKeys.Length > 0)
            Sorgu();
    }

    public string Odunc(string kitapid, string rafta) 
    {
        if (rafta == "1") // Rafta var ise Ödünç al linkini çıkart
            return "<a href='KitapAl.aspx?id=" + kitapid + "'>Ödünç Al</a>";
        else
            return "";
    }

    void Sorgu()
    {
        string[] sorgu = Request.QueryString.AllKeys; // Tüm querystring değerlerini al
        string sql = "";
        int drm = 0;

        // arama kriterlerinde dolu gelen querystrinleri alıp sql cümleciği oluşturulur
        for (int i = 0; i < sorgu.Length - 1; i++)
        {
            if (Request.QueryString[sorgu[i].ToString()] != "") drm = 1;
            if (Request.QueryString[sorgu[i].ToString()] != "-1" & drm == 1)
            {
                sql += sorgu[i].ToString() + "='" + Request.QueryString[sorgu[i].ToString()] + "' and ";
                drm = 0;
            }
        }

        // en son eklenen and silinir
        if (sql.Length > 3)
            sql = sql.Substring(0, sql.Length - 4);

        kitaplarr.DataSource = fonksiyon.TabloAl2("Select * From Kitaplar Where " + sql);
        kitaplarr.DataBind();

        if (kitaplarr.Items.Count < 1)
            sonucyok.Text = "Aranan kriterlere uygun kayıt bulunamadı";

    }

    public string KategoriAdi(string id)
    {
        return fonksiyon.TabloAl2("Select Ad From KitapKategorileri Where ID=" + int.Parse(id) + "").Rows[0]["Ad"].ToString() + " Kitaplar";
    }

    public string Raf(string id)
    {
        if (id == "1")
            return "<span style='color:DarkGreen; font-weight:bold;'>Rafta Var</span>";
        else return "<span style='color:DarkRed; font-weight:bold;'>Rafta Yok</span>";
    }
}