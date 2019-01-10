<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StylepopupNew.aspx.vb" Inherits="Integra.StylepopupNew" %>

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
    
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
    <div >
    <table  width="100%">
    <tr align="center">
    <td>
     <asp:Label ID="Label1"  CssClass="labelNew" Text="Style" runat="server" ></asp:Label>  
    </td> 
    <td>
         <telerik:RadTextBox ID="txtStyleNo" Runat="server" Skin="WebBlue">
                </telerik:RadTextBox>
    
    </td>
    <td>
    
     <asp:Label ID="Label2"  CssClass="labelNew" Text="Article" runat="server" Visible="false"  ></asp:Label>  
    </td>
    <td>
         <telerik:RadTextBox ID="txtArticle" Runat="server" Skin="WebBlue" Visible="false">
                </telerik:RadTextBox>
    </td>
    <td>
     <telerik:RadButton  ID="btnSearch" runat="server" Text="Search Style" skin="WebBlue" >            </telerik:RadButton>
    </td>
    </tr>
    </table>
    </div>
    <div>
    <table width="100%">
    <tr>
 <td align="right">
     <asp:button id="cmdClose"    OnClientClick="window.close();" runat="server"
  CssClass="button" Text="Close"   ></asp:button>
  <asp:button id="btnSelectAll"      runat="server"
  CssClass="button" Text="Select ALL"   ></asp:button>
 
  <telerik:RadButton id="cmdSelect" runat="server" text="Select" skin="WebBlue">
  </telerik:RadButton>
 </td>
    </tr>
    <tr>
    <td>
    
     <telerik:RadGrid ID="dgSelecttion" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50">
            <MasterTableView>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="PODetailID" DataField="PurchaseOrderDetailID" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="Style" DataField="StyleNo">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Style Description" DataField="StyleDescription" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="ColorRefNo" DataField="ColorRefNo">
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>           
            <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Size Range" DataField="SizeRange">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
              <telerik:GridBoundColumn HeaderText="Size" DataField="Sizes">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Price" DataField="Price">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
              <telerik:GridBoundColumn HeaderText="StyleDetailID" DataField="StyleDetailID" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>      
             <telerik:GridTemplateColumn HeaderText="Select">
           <ItemTemplate>
                 <asp:CheckBox id="chkSelected" AutoPostBack="false" OnCheckedChanged="UpdateCertificate"  runat="server" checked='<%# DataBinder.Eval(Container.DataItem,"Status")%>' />							
         </ItemTemplate>
             </telerik:GridTemplateColumn>
                 <telerik:GridTemplateColumn HeaderText="ID" Visible="false">
            <ItemTemplate>
                 <asp:Label id="lblID" runat="server"   CssClass="label" Text='<%# DataBinder.Eval(Container.DataItem,"StyleID")%>'></asp:Label>						
            </ItemTemplate>
             </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
               </td>
    </tr>
    	
    </table>
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>
