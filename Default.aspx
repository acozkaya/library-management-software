<%@ Page Title="" Language="C#" MasterPageFile="~/Sablon.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Kütüphane Otomasyonu</title>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="aktifalan">
<div class="panel" style="overflow:hidden;">
<b style="display:block; padding:10PX 0PX 0PX 10PX;">KÜTÜPHANEMİZDE BULUNAN KİTAP KATEGORİLERİ</b><br />
<asp:Repeater ID="kategoriler" runat="server">
<ItemTemplate>
<div style="float:left; width:200px; margin-right:10px; padding:10px;">
<a href='<%# Eval("ID","Ara.aspx?KategoriID={0}&Adi=&Yazar=&YayinEvi=&Rafta=&Sayfa=") %>'> <%# Eval("AD","{0} Kategorisi") %> <%# Eval("Adet","({0})") %></a>
</div>
</ItemTemplate>
</asp:Repeater>

</div>
</asp:Content>


