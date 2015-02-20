<%@ Page Title="Оплаты по ТП администрирование" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="BalancePoTpAdmin.aspx.cs" Inherits="Sbyt.BalancePoTpAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       



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

    <div id="RESLISTBALANCEPOTPADMIN">

    <asp:DropDownList ID="ResList" 
                DataSourceID="RES" 
                DataTextField="ResName" 
                DataValueField="ResID"  
                runat="server"
                 />
                      
          </div>


             <asp:XmlDataSource ID="BytPromXmlSrc" runat="server">
        <Data>
            <POTREB>
                <PotrebID PotrebID="BYT" PotrebName="Бытовые потребители" />
                <PotrebID PotrebID="PROM" PotrebName="Промышленные потребители" />
                
            </POTREB>
        </Data>
    </asp:XmlDataSource>

    <div id="BytPromDropDwn">

    <asp:DropDownList ID="BytPromDropDwn1" 
                DataSourceID="BytPromXmlSrc" 
                DataTextField="PotrebName" 
                DataValueField="PotrebID"  
                runat="server"/>
                      
          </div>


          <asp:XmlDataSource ID="MonthXml" runat="server">
        <Data>
            <Month1>
                <MonthID MonthID="default" Month="Месяц" />
                <MonthID MonthID="JANUARY" Month="Январь" />
                <MonthID MonthID="FEBRUARY"  Month="Февраль" />
                <MonthID MonthID="Marth"  Month="Март" />
                <MonthID MonthID="APRIL"  Month="Апрель" />
                <MonthID MonthID="MAY" Month="Май" />
                <MonthID MonthID="JUNE" Month="Июнь" />
                <MonthID MonthID="JULY"  Month="Июль" />
                <MonthID MonthID="AUGUST"  Month="Август" />
                <MonthID MonthID="SEPTEMBER"  Month="Сентябрь" />
                <MonthID MonthID="OCTOBER" Month="Октябрь" />
                <MonthID MonthID="NOVEMBER" Month="Ноябрь" />
                <MonthID MonthID="DECEMBER" Month="Декабрь" />
            </Month1>
        </Data>
    </asp:XmlDataSource>

      <div id="MONTHBALANCEPOTPADMIN">
      <asp:DropDownList ID="MonthDropdwn" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                  />
           
      </div> 


      <asp:XmlDataSource ID="YEARXMLDATASRC" runat="server">
        <Data>
            <Year1>
                <YearID YearID="default" Year="Год" />
                <YearID YearID="2011" Year="2011" />
                <YearID YearID="2012" Year="2012" />
                <YearID YearID="2013" Year="2013" />
                <YearID YearID="2014" Year="2014" />
                <YearID YearID="2015" Year="2015" />
                <YearID YearID="2016" Year="2016" />
                <YearID YearID="2017" Year="2017" />
                <YearID YearID="2018" Year="2018" />
                <YearID YearID="2019" Year="2019" />
                <YearID YearID="2020" Year="2020" />
            </Year1>
        </Data>
    </asp:XmlDataSource>

      <div id="YEARBALANCEPOTPADMIN">
     
      <asp:DropDownList ID="YearDropDwn" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"/>
      
      
      
      </div> 

      <div id="MyLabBALANCEPOTPADMIN">
    <asp:Label runat="server" ID="MyLabel" BackColor="AliceBlue" BorderColor="Desktop"
     BorderStyle="Solid" Font-Bold="true" ForeColor="Red"></asp:Label>
</div>


<div id="ResultReportBALANCEPOTPADMIN">
     Страница для конвертации файлов оплат.<br /> 
              
     </div>


     <div id="FileUploadBALANCEPOTPADMIN">
       <asp:FileUpload id="FileUploadBalpoTp" runat="server"/> 
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
       <br />
     <asp:FileUpload id="FileUploadBalpoTpStreet" runat="server"/> 
     <br />
     <br />
     <br />
     <br />
     </div>


        <div id="ConvertBtnBALANCEPOTPADMIN">
               
        <asp:Button runat="server" ID="ConvertBtnBalpoTp" Text="Конвертация данных" 
                onclick="ConvertBtnBalpoTp_Click"/>

     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <br />
     <asp:Button runat="server" ID="ConvertBtnBalpoTpStreet" Text="Конвертация данных" 
                onclick="ConvertBtnBalpoTpStreet_Click"/>
                 </div>


  <div id="SelectFileBALANCEPOTPADMIN">
    Выберите файл "ABON_.DBF" или "PROMRES.DBF"
    <br />
    <br />
    <br />
    <br />
    Выберите файл "DERUL.DBF"
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
