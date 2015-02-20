<%@ Page Title="Сравнение привязки результаты" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="Sbyt.Reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="ReportButtons">
                <br />
<asp:Button ID="StolbRes" Text="Столбцовский РЭС" PostBackUrl="~/Reports.aspx" runat="server" onclick="Stolbbtn_Click" 
                        Width="158px"/>
                 <br />
                 <br />
                 <br />
<asp:Button ID="DergRes" Text="Дзержинский РЭС"  PostBackUrl="~/Reports.aspx" runat="server" onclick="Dergbtn_Click"
                        Width="158px" />
                 <br />
                 <br />
                 <br />

    <asp:Button ID="NesvRes"  PostBackUrl="~/Reports.aspx" Text="Несвижский РЭС" runat="server" onclick="Nesvbtn_Click" 
                    Width="158px" />
                    <br />
                   <br />
                   <br />

   <asp:Button ID="UzdaRes" PostBackUrl="~/Reports.aspx"  Text="Узденский РЭС" runat="server" onclick="Uzdabtn_Click" 
                    Width="158px" />
 
                 <br />
                 <br />
                 <br />


   <asp:Button ID="KleckRes" PostBackUrl="~/Reports.aspx" Text="Клецкий РЭС" runat="server" onclick="Kleckbtn_Click" 
                        Width="158px"/>
   
                 <br />
                   <br />
                   
                 <br />
                   <br />
                   
                 <br />
                   <br />
    </div>
    <div id="MyLab1">
    <asp:Label runat="server" ID="MyLabel" BackColor="AliceBlue" BorderColor="Desktop"
     BorderStyle="Solid" Font-Bold="true" ForeColor="Red"></asp:Label>
</div>

      
<div id = "LinkBtn">
 <br />
    <asp:LinkButton ID="StolbResultLinkButton" Text="StolbResult.xml"  OnClick="StolbHyper" runat="server"></asp:LinkButton>
    <br />
                 <br />
                 <br />
               
  
    <asp:LinkButton ID="DergResultLinkButton" Text="DergResult.xml"  OnClick="DergHyper" runat="server"></asp:LinkButton>
                 <br />
                 <br />
                
    <br />
                 
   <asp:LinkButton ID="NesvResultLinkButton" Text="NesvResult.xml"  OnClick="NesvHyper" runat="server"></asp:LinkButton>
                 <br />
                 <br />
                
       <br />
            
    <asp:LinkButton ID="UzdaResultLinkButton" Text="UzdaResult.xml"  OnClick="UzdaHyper" runat="server"></asp:LinkButton>
                 <br />
                 <br />
                 <br />
                 
    
                 
    <asp:LinkButton ID="KleckResultLinkButton" Text="KleckResult.xml"  OnClick="KleckHyper" runat="server"></asp:LinkButton>
</div>



    <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />



     <div id="ResultReportText1">
     Страница для формирования результатов.<br /> 
     После нажатия на кнопку необходимо дождаться завершения формирования отчета(сообщение красным шрифтом).<br /> 
     Результат в формате xml можно забрать по ссылке слева.<br /> 
     Xml открывать с помощью Microsoft Excel.<br /> 
     
     
     
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
       

</asp:Content>


