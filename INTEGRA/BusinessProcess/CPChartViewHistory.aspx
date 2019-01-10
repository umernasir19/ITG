<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CPChartViewHistory.aspx.vb" Inherits="Integra.CPChartViewHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <telerik:GridBoundColumn HeaderText="Status" DataField="Status" Visible ="false" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="Expected Date" DataField="ExpectedDate">
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
           
            <telerik:GridBoundColumn HeaderText="Actual Date" DataField="ActualDate">
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
