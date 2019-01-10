<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ActiveSupplier.aspx.vb" Inherits="Integra.ActiveSupplier" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
   <link href="StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
  <script language="javascript" type="text/javascript" src="JavaScript/Maskdiv.js"></script>
  <script type="text/javascript"  language="JavaScript" src="../scripts/Calender.js"></script>
  <script type="text/javascript" src="scripts/thickbox.js"></script>
  <script type="text/javascript" src="scripts/jquery.js"></script>
  <script type="text/javascript"  language="JavaScript" src="scripts/pupdate.js"></script>
  <link rel="stylesheet" href="scripts/ThickBox.css" type="text/css" media="screen" />
  <link type="text/css" rel="stylesheet" href="App_Themes/Blue/MenuCSS.css" />  
  <link type="text/css" rel="stylesheet" href="StyleSheet/NewLayout.css" />
  <link rel="stylesheet" type="text/css" href="styles.css" /> 
</head>
<body>
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
         <telerik:RadGrid ID="dgSupplier" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                  PageSize="150">
                   <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <Columns>
             <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%"
                HeaderText="ID" SortExpression="VenderLibraryID" DataField="VenderLibraryID" Display="false">
                  <HeaderStyle Width="5%"></HeaderStyle>
                      <ItemStyle HorizontalAlign="Left"></ItemStyle>
                   </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%"
                HeaderText="Supplier" SortExpression="VenderName" DataField="VenderName" >
                  <HeaderStyle Width="25%"></HeaderStyle>
                      <ItemStyle HorizontalAlign="Left"></ItemStyle>
                   </telerik:GridBoundColumn>
              <telerik:GridTemplateColumn HeaderText="Certificate">
              <ItemTemplate>
                <asp:DropDownList ID="cmbCertificate" runat="server" Width="190">
             </asp:DropDownList>
               <asp:Label ID="lblCertificate" runat="server" ></asp:Label>
               </ItemTemplate>
                  <HeaderStyle Width="25%"></HeaderStyle>
                      <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
             <HeaderStyle Font-Names="Microsoft Sans Serif" />
                <ItemStyle Font-Names="Microsoft Sans Serif" Font-Size="X-Small" Wrap="False" />
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
    </div>
    </form>
</body>
</html>
