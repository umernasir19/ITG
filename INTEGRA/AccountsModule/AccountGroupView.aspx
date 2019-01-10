﻿<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="AccountGroupView.aspx.vb" Inherits="Integra.AccountGroupView" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
 <tr>
 <td align="right">
      <telerik:RadButton ID="btnAddAccountGroup" runat="server" Text="Add Account Group" Skin="WebBlue">
                    </telerik:RadButton> 
 </td>
 </tr>
 <tr>
 <td>
    <asp:UpdatePanel ID="updgAccountGroup" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadGrid ID="dgAccountGroup" runat="server" CellSpacing="0"  AutoGenerateColumns="false" 
         Skin="WebBlue"  Visible="true" PageSize="50">
            <AlternatingItemStyle Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
             <Columns>
              <telerik:GridBoundColumn HeaderText="AccountGroupID" DataField="AccountGroupID" Display="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
         
               <telerik:GridBoundColumn HeaderText="Code" DataField="AccountGroupCode">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Account Group" DataField="AccountGroup">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
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
