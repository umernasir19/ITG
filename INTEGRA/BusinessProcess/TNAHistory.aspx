<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="TNAHistory.aspx.vb" Inherits="Integra.TNAHistory" %>
  <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table><tr style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #00509F;" visible="true"; ><td valign ="middle"  style="height:40px;">
            <asp:Label ID="lblPONo" runat="server" Text=""></asp:Label>:<asp:Label ID="lblProcessName" runat="server" Text=""></asp:Label>
            </td></tr></table>
         <table width="100%">
            <tr>
            <td>
           <telerik:RadGrid ID="dgprocessHistory" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true">
            <MasterTableView>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="Activity Date" DataField="CreationDate">
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Color" DataField="Color">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
            <telerik:GridBoundColumn HeaderText="Status" DataField="Status">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="Estimate Date" DataField="DateEstemated">
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
           
            <telerik:GridBoundColumn HeaderText="Actual Date" DataField="ActualDate">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Quantity Completed" DataField="QtyCompleted">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Remarks" DataField="Remarks">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
                       
            </Columns>
            </MasterTableView>
            
            </telerik:RadGrid>
            </td>
            
            </tr>
           
            </table>
</asp:Content>
