<%@ Page Language="vb"   AutoEventWireup="false" CodeBehind="TNAHistoryPopup.aspx.vb" Inherits="Integra.TNAHistoryPopup" %>
  <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
  <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Milestone History View</title>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            
            <table  width="90%">
            <tr style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" visible="true"; >
            <td valign ="middle"  style="height:40px; width:400px;">
            <asp:Label ID="lblPONo" runat="server" Text=""></asp:Label>:<asp:Label ID="lblProcessName" runat="server" Text=""></asp:Label>
            </td>
            <td align ="left"  style="height:40px; width:350px;"><asp:Label ID="lblmsg" runat="server" Visible ="False" ForeColor="#CC3300" ></asp:Label></td>
            <td align ="right"  style="width:90px;"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/BackECPButton.jpg" /></td>
                
            </tr></table>
            
            <table width="90%">
            <tr>
            <td colspan ="3" >
           <telerik:RadGrid ID="dgprocessHistory" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true">
            <MasterTableView>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="Creation Date" DataField="CreationDate" Visible ="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Status" DataField="Status">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="No.of Submission" DataField="QtyCompleted">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>      
             <telerik:GridBoundColumn HeaderText="Activity Date" DataField="ActualDate">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>    
            <telerik:GridBoundColumn HeaderText="Estimate Date" DataField="DateEstemated" Visible ="false" >
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>      
                    
            <telerik:GridBoundColumn HeaderText="Comments" DataField="Remarks">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="20%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
                       
            </Columns>
            </MasterTableView>
            
            </telerik:RadGrid>
            </td>
            
            </tr>
           
            </table>
 </form>
</body>
</html>