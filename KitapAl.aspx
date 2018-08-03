<%@ Page Title="" Language="C#" MasterPageFile="~/Sablon.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="KitapAl.aspx.cs" Inherits="KitapAl" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Kitap Al</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aktifalan" Runat="Server">

    <div class="panel">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" style="width: 750px; margin: 10px;">
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            Kitap No</td>
                        <td style="width: 20px; font-weight: bold;">
                            :</td>
                        <td>
                            <asp:TextBox ID="KitapNo" runat="server" CssClass="TextBox" Width="300px" 
                                ValidationGroup="Kaydet"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="KitapNo_Filter" runat="server" Enabled="True" 
                                FilterType="Numbers" TargetControlID="KitapNo">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            Teslik Etme Tarihi</td>
                        <td style="width: 20px; font-weight: bold;">
                            :</td>
                        <td>
                            <asp:TextBox ID="Tarih" runat="server" CssClass="TextBox" 
                                ValidationGroup="Kaydet" Width="300px"></asp:TextBox>
                            <cc1:CalendarExtender ID="Tarih_Takvim" runat="server" Enabled="True" 
                                TargetControlID="Tarih" Format="dd.MM.yyyy">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                        <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="Sonuc" runat="server" Font-Bold="True"></asp:Label>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img alt="" class="style1" src="images/bekle.gif" />
                                    <br />
                                    Lütfen bekleyiniz ...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                    </tr>
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                        <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                        <td class="dipnot">
                            Not: Kitap No suna Katalog Tarama sayfasından bakabilirsiniz...</td>
                    </tr>
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                        <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="Al" runat="server" CssClass="Buton" onclick="Al_Click" 
                                Text="Kitabı al" ValidationGroup="Kaydet" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <div id="Girisyok" runat="server" 
            style="padding-left:10px; color: #990000; font-weight: bold;">
            Kitap alabilmeniz için üye girişi yapmış olmanız gerekiyor.
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="Giris.aspx?return=KitapAl.aspx">GİRİŞ İÇİN TIKLAYINIZ</asp:HyperLink>
        </div>
    </div>

</asp:Content>

