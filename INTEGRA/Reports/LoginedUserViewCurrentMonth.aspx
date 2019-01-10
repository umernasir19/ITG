<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LoginedUserViewCurrentMonth.aspx.vb" Inherits="Integra.LoginedUserViewCurrentMonth" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body  >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <table align="center">
      <tr>
    
    <td class="NormalBoldText" style="height: 18px">
     <asp:Label ID="LabelHeading" CssClass="labelNoticeBoard" runat="server" Font-Underline="True"></asp:Label>
    </td>
    </tr>
    </table>
    <table><tr><td>
    <table><tr>
      <td >
                       
     <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Medium" Text="User Name" > </asp:Label>
                        </td>
                    <td align="left" >
  <asp:UpdatePanel ID="upcmbUserName" UpdateMode="Conditional" runat="server">
  <ContentTemplate>
 <telerik:RadComboBox ID="cmbUserName" Runat="server" AutoPostBack="True" Skin="WebBlue">
  </telerik:RadComboBox> 
  </ContentTemplate>
  </asp:UpdatePanel>
             </td>
                   <td align="center"  width="50">
                    <telerik:RadButton ID="btnSreach" runat="server" Text="Search" Skin="WebBlue"  >
                   </telerik:RadButton>
                   </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    <td >
                    <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Medium"  Text="Name:"></asp:Label>
                    </td>
                    <td >
                  
                    <asp:Label ID="lblUsername" runat="server" Font-Names="Calibri" Font-Size="Medium"  ></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td >
                   
                      <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Medium"  Text="Department:"></asp:Label>
                    </td>
                    <td >
                  
                    <asp:Label ID="lblDepartment" runat="server" Font-Names="Calibri" Font-Size="Medium"  ></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td >
  
                      <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Medium"  Text="Today Date:"></asp:Label>
                    </td>
                    <td >
                    <asp:Label ID="lbldate" runat="server" Font-Names="Calibri" Font-Size="Medium" ></asp:Label>
                    </td>
                    </tr><tr>
                    <td >
                     <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Medium"  Text="Message:"></asp:Label>
                    </td>
                    <td >
                     <asp:Label ID="lblMessage" runat="server" Font-Names="Calibri" Font-Size="Medium"  ></asp:Label>
                    </td>
                   </tr>
    </table> </td>
    
    <td>
  
    </td>
     </tr> 
    </table> 
    <table width="100%"  >
    <tr>
    <td align="center">

    </td>
    </tr>
<tr><td>
	    <telerik:RadGrid ID="dgLoginedUser" runat="server" CellSpacing="0"  AutoGenerateColumns="false" 
         Skin="WebBlue"  Visible="true" PageSize="50">
            <AlternatingItemStyle Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
            <Columns>            
             
             <telerik:GridBoundColumn HeaderText="User Name" DataField="UserName" Display="false" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller"  />
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Department" DataField="ECPDivistion" Display="false" >
            <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Login Time" DataField="LoginTime">
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller"  /> 
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Logined Date" DataField="LoginedDate" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>                   
          
           </Columns>
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
            </ClientSettings>
            <HeaderStyle Font-Names="Microsoft Sans Serif" />
            <ItemStyle Font-Names="Microsoft Sans Serif" />
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
           <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
  
        </td>
</tr>
    </table>
    
    </form>
</body>
</html>
