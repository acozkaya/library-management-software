using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    Fonksiyonlar fonksiyon = new Fonksiyonlar();
    protected void Page_Load(object sender, EventArgs e)
    {

        kategoriler.DataSource = fonksiyon.TabloAl2("SELECT ID,AD,(SELECT COUNT(*) FROM Kitaplar K WHERE K.KategoriID =ID)AS ADET FROM KitapKategorileri Order By AD");
            kategoriler.DataBind();
        
    }
}