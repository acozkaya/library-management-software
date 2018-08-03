using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sablon : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Ara_Click(object sender, EventArgs e)
    {
        Response.Redirect("Ara.aspx?KategoriID=" + "&Adi=" + Aranan.Text + "&Yazar=" + "&YayinEvi=" + "&Rafta=" + "&Sayfa=");
    }
}
