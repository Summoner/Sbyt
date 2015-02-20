<%@ Page Title="Столбцовский РЭС оплаты" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="StolbBalancePoTp.aspx.cs" Inherits="Sbyt.StolbBalancePoTp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<br />



<div id="LABELTPLIST">

   <asp:Label ID="testLabel" Font-Bold="True" ForeColor="Blue" runat="server"></asp:Label>

   </div>

   <div id="LblMonthYearSelect">

   <asp:Label ID="testLabel1" Font-Bold="True" ForeColor="Blue" runat="server"></asp:Label>

   </div>
   <div id="mysearch">
<asp:TextBox runat="server" ID="search" Cssclass="search"/>
<asp:Button runat="server" ID="buttonsearch" Cssclass="buttonsearch"  Text="Искать ТП!" OnClick="SearchButton_Click" />
</div>
   
 <div id="TPLIST">
<table >
  <tr>
    <td>
<asp:GridView runat="server" ID="ListTPs" 
              DataSourceID="TPsObjectDatasource"
              AllowPaging="True" 
              PageSize="16" 
              AllowSorting="True"
              AutoGenerateColumns="False" 
              Width="40px" 
              CellPadding="4" 
              EnableModelValidation="True" 
              ForeColor="#333333" 
              GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="DOC_CODE" Visible="false"   HeaderText="Список кодов ТП" 
            SortExpression="DOC_CODE" >
        <ControlStyle Font-Size="Large" Font-Bold="True" />
        </asp:BoundField>
    </Columns>
    <Columns>
        <asp:hyperlinkfield DataTextField="DOC_NAME"   
        HeaderText="Список ТП" 
            SortExpression="DOC_NAME"
            DataNavigateUrlFields="DOC_CODE,DOC_NAME"
            DataNavigateUrlFormatString="~/StolbOplatiPoTp.aspx?DOC_CODE={0}&DOC_NAME={1}" 
            Target="_blank"  >
            
        <ControlStyle Font-Size="Large" Font-Bold="True" />
        </asp:hyperlinkfield>
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />




</asp:GridView>

<asp:GridView runat="server" ID="SearchTP" 
              DataSourceID="TPsSearchObjectDataSource"
              AllowPaging="True" 
              PageSize="16" 
              AllowSorting="True"
              AutoGenerateColumns="False" 
              Width="107px" 
              CellPadding="4" 
              EnableModelValidation="True" 
              ForeColor="#333333" 
              GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="DOC_CODE" Visible="false"   HeaderText="Список кодов ТП" 
            SortExpression="DOC_CODE" >
        <ControlStyle Font-Size="Large" Font-Bold="True" />
        </asp:BoundField>
    </Columns>
    <Columns>
        <asp:hyperlinkfield DataTextField="DOC_NAME"   
        HeaderText="Список ТП" 
            SortExpression="DOC_NAME"
            DataNavigateUrlFields="DOC_CODE,DOC_NAME"
            DataNavigateUrlFormatString="~/StolbOplatiPoTp.aspx?DOC_CODE={0}&DOC_NAME={1}" 
            Target="_blank"  >
            
        <ControlStyle Font-Size="Large" Font-Bold="True" />
        </asp:hyperlinkfield>
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />




</asp:GridView>
    </td>
  </tr>
</table>
</div>


<asp:ObjectDataSource runat="server" ID="TPsObjectDatasource"   
                      SortParameterName="TPsSort" 
                      TypeName="Sbyt.Balance_Po_TP.StolbBLLTPs" 
                      SelectMethod="GetTPs" 
                      SelectCountMethod="GetTPsCount"  
                      EnablePaging="true"></asp:ObjectDataSource>

                      <asp:ObjectDataSource runat="server" ID="TPsSearchObjectDataSource"   
                 
                      TypeName="Sbyt.Balance_Po_TP.StolbBLLTPs" 
                      SelectMethod="GetTPbyName" 
                    
                      OnSelecting="TPsSearchObjectDataSource_Selecting" >
                      <SelectParameters>

            <asp:Parameter Name="DOC_NAME" Type="String" />

        </SelectParameters>
</asp:ObjectDataSource>

      

  
    



    <asp:XmlDataSource ID="MonthXml" runat="server">
        <Data>
            <Month1>
                <MonthID MonthID="default" Month="Месяц" />
                <MonthID MonthID="January" Month="Январь" />
                <MonthID MonthID="February"  Month="Февраль" />
                <MonthID MonthID="Marth"  Month="Март" />
                <MonthID MonthID="April"  Month="Апрель" />
                <MonthID MonthID="May" Month="Май" />
                <MonthID MonthID="June" Month="Июнь" />
                <MonthID MonthID="July"  Month="Июль" />
                <MonthID MonthID="August"  Month="Август" />
                <MonthID MonthID="September"  Month="Сентябрь" />
                <MonthID MonthID="October" Month="Октябрь" />
                <MonthID MonthID="November" Month="Ноябрь" />
                <MonthID MonthID="December" Month="Декабрь" />
            </Month1>
        </Data>
    </asp:XmlDataSource>

      <div id="MONTH">
      <asp:DropDownList ID="MonthDropdwn" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"
                runat="server" AutoPostBack="true" 
                OnTextChanged="NextMonthSession"
                  />
           
      </div> 

      <div id="MONTH1">
      <asp:DropDownList ID="MonthDropdwn1" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server" AutoPostBack="true" 
                OnTextChanged="NextMonthSession1"
                  />
           
      </div> 

      <div id="MONTH2">
      <asp:DropDownList ID="MonthDropdwn2" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession2"
                  />
           
      </div> 

      <div id="MONTH3">
      <asp:DropDownList ID="MonthDropdwn3" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession3"
                  />
           
      </div> 

      <div id="MONTH4">
      <asp:DropDownList ID="MonthDropdwn4" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession4"
                  />
           
      </div> 

      <div id="MONTH5">
      <asp:DropDownList ID="MonthDropdwn5" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession5"
                  />
           
      </div> 
      
      <div id="MONTH6">
      <asp:DropDownList ID="MonthDropdwn6" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession6"
                  />
           
      </div> 

       <div id="MONTH7">
      <asp:DropDownList ID="MonthDropdwn7" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession7"
                  />
           
      </div> 

       <div id="MONTH8">
      <asp:DropDownList ID="MonthDropdwn8" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession8"
                  />
           
      </div> 

       <div id="MONTH9">
      <asp:DropDownList ID="MonthDropdwn9" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession9"
                  />
           
      </div> 

       <div id="MONTH10">
      <asp:DropDownList ID="MonthDropdwn10" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession10"
                  />
           
      </div> 

       <div id="MONTH11">
      <asp:DropDownList ID="MonthDropdwn11" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"  
                runat="server"
                AutoPostBack="true" 
                OnTextChanged="NextMonthSession11"
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

      <div id="YEAR">
     
      <asp:DropDownList ID="YearDropDwn" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible"  />
      
      
      
      </div> 

      <div id="YEAR1">
     
      <asp:DropDownList ID="YearDropDwn1" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible1"   />
      
      
      
      </div> 

      <div id="YEAR2">
     
      <asp:DropDownList ID="YearDropDwn2" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible2" />
      
      
      
      </div> 

      <div id="YEAR3">
     
      <asp:DropDownList ID="YearDropDwn3" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible3"  />
      
      
      
      </div> 

      <div id="YEAR4">
     
      <asp:DropDownList ID="YearDropDwn4" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible4"  />
      
      
      
      </div> 

      <div id="YEAR5">
     
      <asp:DropDownList ID="YearDropDwn5" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible5"  />
      
      
      
      </div> 

      <div id="YEAR6">
     
      <asp:DropDownList ID="YearDropDwn6" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible6"  />
      
      
      
      </div> 

      <div id="YEAR7">
     
      <asp:DropDownList ID="YearDropDwn7" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible7"  />
      
      
      
      </div> 

      <div id="YEAR8">
     
      <asp:DropDownList ID="YearDropDwn8" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible8"  />
      
      
      
      </div> 

      <div id="YEAR9">
     
      <asp:DropDownList ID="YearDropDwn9" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible9"  />
      
      
      
      </div> 

      <div id="YEAR10">
     
      <asp:DropDownList ID="YearDropDwn10" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible10"  />
      
      
      
      </div> 

      <div id="YEAR11">
     
      <asp:DropDownList ID="YearDropDwn11" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="NextYearVisible11"
                 />
      
      
      
      </div> 

       <div id="FromMonth">
      <asp:DropDownList ID="FromMonthDropDownList" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"
                runat="server" 
                AutoPostBack="true" OnTextChanged="FromMonthSessionAdd"
                  />
           
      </div> 

       <div id="FromYear">
     
      <asp:DropDownList ID="FromYearDropDownList" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="FromYearSessionAdd"
                 />      
      
      </div> 


      <div id="ToMonth">
      <asp:DropDownList ID="ToMonthDropDownList" 
                DataSourceID="MonthXml" 
                DataTextField="Month" 
                DataValueField="MonthID"
                runat="server" 
                AutoPostBack="true" OnTextChanged="ToMonthSessionAdd"
                  />
           
      </div> 

       <div id="ToYear">
     
      <asp:DropDownList ID="ToYearDropDownList" 
                DataSourceID="YEARXMLDATASRC" 
                DataTextField="Year" 
                DataValueField="YearID"  
                runat="server"
                AutoPostBack="true" OnTextChanged="ToYearSessionAdd"
                  />
      
      
      
      </div> 

      <div id="From">

   <asp:Label ID="FromLbl" Font-Bold="True" ForeColor="Blue" runat="server"></asp:Label>

   </div>

      <div id="To">

   <asp:Label ID="ToLbl" Font-Bold="True" ForeColor="Blue" runat="server"></asp:Label>

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
<br />
<br />
<br />

<br />
<br />
<br />
<br />
</asp:Content>
