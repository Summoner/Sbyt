<%@ Page Title="Оплаты по ВЛ администрирование" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="Balance.aspx.cs" Inherits="Sbyt.Balance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



<div id="BalanceFileUploadText">
Для получения информации из файла PROMRES Энергосбыта в разрезе линии 10кВ<br />
     необходимо осуществить конвертацию PROMRES.DBF в БД.
 </div>
 
 <div id="PromResFileUpload">
<asp:FileUpload ID="PromResFileUpload1" runat="server" />
</div>

<div id="PromResConvertBtn">
    <asp:Button ID="PromResButton" runat="server" onclick="PromResButton_Click" Text="Конвертация" 
        Width="165px" />
</div>
<div id="PROMRESTEXT">
Файл PROMRES:


</div>

<div id="PROMTPTEXT">
Количество ТП в линии:
</div>

<div id="ResSpisokForBal">
<asp:XmlDataSource ID="RES" runat="server">
        <Data>
            <RES>
                <ResID ResID="Stolb" ResName="Столбцовский РЭС" />
                <ResID ResID="Uzda"  ResName="Узденский РЭС" />
                <ResID ResID="Derg"  ResName="Дзержинский РЭС" />
                <ResID ResID="Nesv"  ResName="Несвижский РЭС" />
                <ResID ResID="Kleck" ResName="Клецкий РЭС" />
            </RES>
        </Data>
    </asp:XmlDataSource>
    

    <asp:DropDownList ID="ResList" 
                DataSourceID="RES" 
                DataTextField="ResName" 
                DataValueField="ResID"  
                runat="server"  />
                      
         

</div>
<br />
<br />
<br />
<br />
<br />
<div id = "TPSpisokForBal">
<asp:TextBox ID="TPTextBox" runat="server" AutoPostBack="true"  Width="55px"></asp:TextBox>
</div>

<div id = "DynamicTP">
 <br />
 <asp:PlaceHolder ID="PlaceHolder1"  runat="server">

</asp:PlaceHolder>


</div>

<div id="MyLabBal"> 
      <asp:Label runat="server" ID="MyLabel"
     ForeColor="Red" Height="51px" Width="244px"></asp:Label>  
     </div>   
     <br />


     <div id="PromResOKTP">
    <asp:Button ID="PromResOKKolvoTPBtn" runat="server" 
             onclick="PromResOKKolvoTPButton_Click" Text="OK" 
        Width="87px" />
</div>
<div id="KleckResultLinkPromRes">
<br />
               
  
    <asp:LinkButton ID="KleckPromResResultLinkButton" Text="KleckResult.xml"  OnClick="KleckPromResResultHyperLink" runat="server"></asp:LinkButton>
                 <br />

</div>
<div id="DergResultLinkPromRes">
<br />
               
  
    <asp:LinkButton ID="DergPromResResultLinkButton" Text="DergResult.xml"  OnClick="DergPromResResultHyperLink" runat="server"></asp:LinkButton>
                 <br />

</div>
<div id="UzdaResultLinkPromRes">
<br />
               
  
    <asp:LinkButton ID="UzdaPromResResultLinkButton" Text="UzdaResult.xml"  OnClick="UzdaPromResResultHyperLink" runat="server"></asp:LinkButton>
                 <br />

</div>
<div id="NesvResultLinkPromRes">
<br />
               
  
    <asp:LinkButton ID="NesvPromResResultLinkButton" Text="NesvResult.xml"  OnClick="NesvPromResResultHyperLink" runat="server"></asp:LinkButton>
                 <br />

</div>
<div id="StolbResultLinkPromRes">
<br />
               
  
    <asp:LinkButton ID="StolbPromResResultLinkButton" Text="StolbResult.xml"  OnClick="StolbPromResResultHyperLink" runat="server"></asp:LinkButton>
                 <br />

</div>

<br />
<br />
<br />
<br />

<br />
<br />
<br />

<br />
<br />
<br />

<br />
<br />
<br />

</asp:Content>
