<%@ Page Title="" Language="C#" MasterPageFile="~/Sablon.master" AutoEventWireup="true" CodeFile="Ara.aspx.cs" Inherits="Ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Arama Sonuçları</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aktifalan" Runat="Server">

<asp:Repeater ID="kitaplarr" runat="server">
<ItemTemplate>
<table cellpadding="0" cellspacing="0" style="width:740px;border-collapse:collapse;">
<tr align="center" style="background-color:#EFF3FB;font-size:11px;height:25px;">
<td style="width:50px;"><%# Eval("KitapID") %></td><td style="width:120px;"><%# Eval("Adi") %></td><td style="width:120px;"><%# KategoriAdi(Eval("KategoriID").ToString()) %></td><td style="width:120px;"><%# Eval("Yazar") %></td><td style="width:120px;"><%# Eval("YayinEvi") %></td><td style="width:100px;"><%# Raf(Eval("Rafta").ToString()) %></td><td style="width:50px;"><%# Eval("Sayfa") %></td><td style="width:50px;"><%# Odunc(Eval("KitapID").ToString(),Eval("Rafta").ToString()) %></td>
</tr>
</table>
</ItemTemplate>
<HeaderTemplate>
<table cellspacing="0" cellpadding="4" border="0" id="ctl00_aktifalan_kitaplar" style="color:#333333;width:740px;border-collapse:collapse;">
<tr style="color:White;background-color:#507CD1;font-size:12px;font-weight:bold;height:30px;">

			<th style="width:50px;">Kitap NO</th><th style="width:120px;">Kitap Adı</th><th style="width:120px;">Kitap Kategorisi</th><th style="width:120px;">Yazar Adı</th><th style="width:120px;">Yayın Evi</th><th style="width:100px;">Durumu</th><th style="width:50px;">Sayfa</th><th style="width:60px;">Ödünç Al</th>

		</tr>
</table>
</HeaderTemplate>
</asp:Repeater>

<asp:Label ID="sonucyok" runat="server" Font-Bold="True" ForeColor="DarkRed"></asp:Label>
</asp:Content>

