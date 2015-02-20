<%@ Page Title="Сравнение привязки администрирование" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="Sbyt.Administration" %>

    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div id="AdminText">
    На этой странице осуществляется создание таблиц.
    Обязательно выберите РЭС прежде чем добавлять необходимые DBF файлы.
    </div>
    <br />
        <br />
        <br />
        <br />
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

       
        
        <br />
        <br />
        <br />

    <div id="ResSpisok">

    <asp:DropDownList ID="ResList" 
                DataSourceID="RES" 
                DataTextField="ResName" 
                DataValueField="ResID"  
                runat="server"  />
                      
          </div>

          <br />
     <div id="MyLab"> 
      <asp:Label runat="server" ID="MyLabel" BackColor="AliceBlue" BorderColor="Desktop"
     BorderStyle="Solid" Font-Bold="True" ForeColor="Red" ></asp:Label>  
     </div>   


        
     
        <br />
        <br />
        <br />
        <div id="test">
        <div id="Label1">
          <asp:Label  runat="server" ID="InputFile1Label1"  Text="Файл привязки сбыта: "></asp:Label>
             </div>
            <div id="Label2">
            <asp:Label  runat="server" ID="InputFile1Label2" Text="Файл привязки из паспортизации: "></asp:Label>
             </div>

            <div id="Label3">
            <asp:Label  runat="server" ID="InputFile1Label3" Text="Файл-справочник улиц: "></asp:Label>

      </div>
      <div id="FileUpload1">
       <asp:FileUpload id="AbonentSbyt" runat="server"/> 
        </div>
       <div id="FileUpload2">
       <asp:FileUpload id="AbonentPasport" runat="server"/>
        </div>
       <div id="FileUpload3">
       <asp:FileUpload id="SprUlic" runat="server" Width="219px" />

       </div>
    
        <div id="Buttons1">
               
        <asp:Button runat="server" ID="SbytConvertBtn" Text="Конвертация данных" 
                onclick="SbytConvertBtn_Click"/>
                 </div>
        <br />
        <div id="Buttons2">
        <asp:Button 
            runat="server" ID="StreetConvertBtn" Text="Конвертация данных" 
                onclick="StreetConvertBtn_Click" />
            </div>
        <br />
       <br />
         <br />
       <div id="Buttons3">
              <asp:Button 
            runat="server" ID="PasportConvertBtn" Text="Конвертация данных" 
                onclick="PasportConvertBtn_Click" />

</div>
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
                
</asp:Content>
