<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RequisitionerRequestApprovalPopUp.aspx.vb" Inherits="Integra.RequisitionerRequestApprovalPopUp" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%">
<tr>
<td style="height: 25px">
Date :
</td>
<td style="height: 25px">
<telerik:RadDatePicker ID="txtDate" runat="server" Skin="WebBlue">

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" 
            TabIndex="2"></DateInput>
</telerik:RadDatePicker>
</td>
<td style="height: 25px"></td>
<td style="left: 10px; height: 25px;">
Approval Date:
</td>
<td style="height: 25px">
<telerik:RadDatePicker ID="txtApprovalDate" runat="server" Skin="WebBlue">
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" 
            TabIndex="2"></DateInput>

</telerik:RadDatePicker>
</td>
</tr>
<tr>
<td style="height: 25px">
Name :
</td>
<td style="height: 25px">
<telerik:RadTextBox ID="txtRequisitionerName" runat="server" Skin="WebBlue"></telerik:RadTextBox>
</td>
<td style="height: 25px">
 
</td>
<td>
    Approved By :</td>
<td>
    <telerik:RadTextBox ID="txtApprovedBy" runat="server" Skin="WebBlue"></telerik:RadTextBox></td>
</tr>
<tr>
<td style="height: 25px">
    Department :
</td>
<td>
<telerik:RadTextBox ID="txtDepartment" runat="server"  Skin="WebBlue"></telerik:RadTextBox>
</td>
<td></td>
<td>
    Priority: 
</td>
<td>

    <asp:RadioButtonList ID="rdPriorityUrgentNormal" runat="server" align="left" 
        Height= "16px"  Width="100px" Font-Size="Small" Font-Names="arial" Visible= "true"
        AutoPostBack="false" RepeatDirection="Horizontal">
        <asp:ListItem Value="Urgent" >Urgent</asp:ListItem>
        <asp:ListItem Value="Normal" Selected="True">Normal</asp:ListItem>
    </asp:RadioButtonList>
</td>
</tr>
<tr>
<td style="height: 25px">
   
</td>
<td></td>
<td></td>
<td></td>
<td></td>
</tr>


</table>
   <table width="100%">
    <tr>
    <td align="right">
      <telerik:RadButton ID="btnApproval" runat="server" Text="Approved" Skin="WebBlue">
        </telerik:RadButton>
       
       <asp:button id="cmdClose"    OnClientClick="window.close();" runat="server"
  CssClass="button" Text="Close"   ></asp:button>

    </td>
    </tr>
    <tr>
    <td>
      <telerik:RadGrid ID="dgApprovalPopup" runat="server" AutoGenerateColumns="false"
       AllowFilteringByColumn="false" Width="100%" Skin="WebBlue">
          <MasterTableView>
            <Columns>
             <telerik:GridBoundColumn HeaderText="InventoryRequestMasterID" DataField="InventoryRequestMasterID" Display="false" >
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                    
                     <telerik:GridBoundColumn HeaderText="InventoryDatabaseID" DataField="InventoryDatabaseID" Display="false" >
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                    
                    <telerik:GridBoundColumn HeaderText="InventoryRequestDetailID" DataField="InventoryRequestDetailID" Display="false" >
                        <HeaderStyle Width="5px" />
                    </telerik:GridBoundColumn>
                     <telerik:GridBoundColumn HeaderText="ItemDescription" Display="true" DataField="ItemDescription" ShowFilterIcon="false" FilterControlWidth="60px">
                       
                    </telerik:GridBoundColumn>
                     
                    <telerik:GridTemplateColumn HeaderText="Requisition"><itemstyle horizontalalign="Center" /> <ITEMTEMPLATE>
  
             <asp:CheckBox ID="chkStatus" runat="server" AutoPostBack="true"></asp:CheckBox>
   </ITEMTEMPLATE>  <headerstyle horizontalalign="Center" width="7px" /> <ItemStyle horizontalalign="Center" />
     </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
                     <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
    <HeaderStyle Font-Names="Microsoft Sans Serif" />
 <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
        </telerik:RadGrid>
          </td>
    </tr>
         </table>
    </div>
    </form>
</body>
</html>
