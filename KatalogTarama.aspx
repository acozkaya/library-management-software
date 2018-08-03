<%@ Page Title="" Language="C#" MasterPageFile="~/Sablon.master" AutoEventWireup="true" CodeFile="KatalogTarama.aspx.cs" Inherits="KatalogTarama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Katalog Tarama</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aktifalan" Runat="Server">
    <div class="panel">
            <table cellpadding="0" cellspacing="0" style="width: 750px; margin: 10px;">
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                        Kitap Türü</td>
                    <td style="width: 20px; font-weight: bold;">
                        :</td>
                    <td>
                        <asp:DropDownList ID="KitapTurleri" runat="server" CssClass="TextBox" 
                            Width="311px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                        Kitap Adı</td>
                    <td style="width: 20px; font-weight: bold;">
                        :</td>
                    <td>
                        <asp:TextBox ID="KitapAdi" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                        Yazar</td>
                    <td style="width: 20px; font-weight: bold;">
                        :</td>
                    <td>
                        <asp:TextBox ID="Yazar" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                        Yayın Evi
                    </td>
                    <td style="width: 20px; font-weight: bold;">
                        :</td>
                    <td>
                        <asp:TextBox ID="YayinEvi" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                        Rafta</td>
                    <td style="width: 20px; font-weight: bold;">
                        :</td>
                    <td>
                        <asp:DropDownList ID="Raf" runat="server" CssClass="TextBox">
                            <asp:ListItem Value="-1">Raftaki durumu</asp:ListItem>
                            <asp:ListItem Value="1">Rafta Var</asp:ListItem>
                            <asp:ListItem Value="0">Rafta Yok</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                        Sayfa Sayısı</td>
                    <td style="width: 20px; font-weight: bold;">
                        :</td>
                    <td>
                        <asp:TextBox ID="Sayfa" runat="server" CssClass="TextBox" Width="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                    <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                    <td>
                        <asp:Label ID="Sonuc" runat="server" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                    <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                    <td class="dipnot">
                            Not: Tüm alanların doldurulması zorunludur!</td>
                </tr>
                <tr style="height: 25px; line-height: 25px;">
                    <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                    <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                    <td>
                        <asp:Button ID="ara" runat="server" CssClass="Buton" onclick="ara_Click" 
                                Text="Aramayı Başlat" ValidationGroup="Kaydet" />
                    </td>
                </tr>
            </table>
</div>
</asp:Content>

