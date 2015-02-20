<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KleckOplatiReport.aspx.cs" Inherits="Sbyt.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TP details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
<br />
<br />
<br />
<asp:Label runat="server" ID="lblTPDetails"></asp:Label>
<div>  
        <h2 style="color:Navy">TP Details</h2>  
        <asp:ObjectDataSource   
            ID="ObjectDataSource1"  
            runat="server"
            TypeName="Sbyt.Balance_Po_TP.KleckBLLTPs" 
                      SelectMethod="GetTPDetails">  
            <selectparameters>
            <asp:querystringparameter name="DOC_NAME" 
                                      querystringfield="DOC_NAME" 
                                      defaultvalue="1"/>
          </selectparameters>
        </asp:ObjectDataSource>  
        <asp:GridView   
            ID="GridView1"  
            runat="server"  
            DataSourceID="ObjectDataSource1"  
            AllowPaging="true"  
            ForeColor="AliceBlue"  
            BackColor="DodgerBlue"  
            BorderColor="LightSkyBlue"  
            HeaderStyle-BackColor="DarkBlue"  
            >  
        </asp:GridView>          
    </div>  
<br />
<br />
<br />
<br />

<br />
<br />
<br />

    </div>
    </form>
</body>
</html>
