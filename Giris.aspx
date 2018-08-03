<%@ Page Title="" Language="C#" MasterPageFile="~/Sablon.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Giris.aspx.cs" Inherits="Giris" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Üye Girişi ve İşlemler</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="aktifalan" Runat="Server">
    <div class="panel">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" style="width: 750px; margin: 10px;">
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            E - posta</td>
                        <td style="width: 20px; font-weight: bold;">
                            :</td>
                        <td>
                            <asp:TextBox ID="eposta" runat="server" CssClass="TextBox" Width="300px" 
                                ValidationGroup="Kaydet"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="bos2" runat="server" ControlToValidate="eposta" 
                                ErrorMessage=" *" ValidationGroup="Kaydet"></asp:RequiredFieldValidator>
                            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                                runat="server" ControlToValidate="eposta" 
                                ErrorMessage="E - posta nız isim@adres.com formatında olmalı" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                ValidationGroup="Kaydet"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            Şifre</td>
                        <td style="width: 20px; font-weight: bold;">
                            :</td>
                        <td>
                            <asp:TextBox ID="sifre" runat="server" CssClass="TextBox" TextMode="Password" 
                                Width="300px" ValidationGroup="Kaydet"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="bos3" runat="server" ControlToValidate="sifre" 
                                ErrorMessage=" *" ValidationGroup="Kaydet"></asp:RequiredFieldValidator>
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
                            Not: Tüm alanların doldurulması zorunludur!</td>
                    </tr>
                    <tr style="height: 25px; line-height: 25px;">
                        <td style="width: 120px; font-weight: bold;">
                            &nbsp;</td>
                        <td style="width: 20px; font-weight: bold;">
                            &nbsp;</td>
                        <td>
                            <asp:Button ID="Gir" runat="server" CssClass="Buton" onclick="Gir_Click" 
                                Text="Giriş Yap" ValidationGroup="Kaydet" />
                            <asp:Button ID="Git" runat="server" CssClass="Buton" 
                                PostBackUrl="~/yeniuye.aspx" Text="Yeni Üye Kaydı" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br /><br />
        <div id="Girisvar" runat="server" style="padding-left:10px;">
        <asp:Label ID="hosgeldin" runat="server"></asp:Label>
            <br />
       <asp:LinkButton ID="cikis" runat="server" Text="Çıkış" 
                OnClientClick="return confirm('Çıkış yapmayı onaylıyor musunuz?')" 
                onclick="cikis_Click"></asp:LinkButton>
            <br />
            <br />
        <asp:DataList ID="rp" runat="server" RepeatColumns="3" 
                onitemcommand="rp_ItemCommand">
        <ItemTemplate>
        <div style="width:220px; margin-right:10px; line-height:20px;">
        <b>Kitap Adı : </b><%# Eval("KitapAdi") %>
        <br />
        <b>Kalan Gün : </b> <%# KalanGun(Eval("VerisTarih").ToString()) %>
        <br />
        <asp:LinkButton ID="iade" runat="server" Text="Geri Ver" CommandName="iadeet" CommandArgument='<%# Eval("KitapID") %>'></asp:LinkButton>
        <br />
        <br />
        <br />
        </div>
        </ItemTemplate>
       <HeaderTemplate>Aldığım Kitaplar<br /></HeaderTemplate>
        </asp:DataList>
        </div>

</div>
</asp:Content>

