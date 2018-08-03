using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class KatalogTarama : System.Web.UI.Page
{
    Fonksiyonlar fonksiyon = new Fonksiyonlar();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) KitapTurual();
    }

    void KitapTurual()
    {
        KitapTurleri.DataSource = fonksiyon.TabloAl2("Select * From KitapKategorileri Order by Ad");
        KitapTurleri.DataTextField = "AD";
        KitapTurleri.DataValueField = "ID";
        KitapTurleri.DataBind();

        KitapTurleri.Items.Insert(0, new ListItem("Lütfen bir kategori seçiniz...", "-1"));
    }

    protected void ara_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Ara.aspx?KategoriID=" + KitapTurleri.SelectedValue + "&Adi=" + KitapAdi.Text + "&Yazar=" + Yazar.Text + "&YayinEvi=" + YayinEvi.Text + "&Rafta=" + Raf.SelectedValue + "&Sayfa=" + Sayfa.Text);
        }
        catch
        { }
    }
}