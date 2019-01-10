<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="AccountSubGroupView.aspx.vb" Inherits="Integra.AccountSubGroupView" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
 <tr>
 <td align="right">
      <telerik:RadButton ID="btnAccountSubGroup" runat="server" Text="Add Account Sub Group" Skin="WebBlue">
                    </telerik:RadButton> 
 </td>
 </tr>
 <tr>
 <td>
    <asp:UpdatePanel ID="updgAccountSubGroup" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadGrid ID="dgAccountSubGroup" runat="server" CellSpacing="0"  AutoGenerateColumns="false" 
         Skin="WebBlue"  Visible="true" PageSize="50">
            <AlternatingItemStyle Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
             <Columns>
              <telerik:GridBoundColumn HeaderText="AccountSubGroupID" DataField="AccountSubGroupID" Display="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
           <telerik:GridBoundColumn HeaderText="Account Group" DataField="AccountGroup">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>   
                            
               <telerik:GridBoundColumn HeaderText="Account Sub Group" DataField="AccountSubGroup">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>

               <telerik:GridBoundColumn HeaderText="Sub Group Code" DataField="AccountSubGroupCode">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
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
   </ContentTemplate>
 </asp:UpdatePanel>  
 </td>
 </tr>
  </table>
</asp:Content> 
