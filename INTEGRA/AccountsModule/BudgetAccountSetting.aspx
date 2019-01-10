﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BudgetAccountSetting.aspx.vb" Inherits="Integra.BudgetAccountSetting" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadAjaxManager ID="radajaxmanager" runat ="server" >
<AjaxSettings >
<telerik:AjaxSetting AjaxControlID ="txtChartOAccountAllocation">
<UpdatedControls >
<telerik:AjaxUpdatedControl ControlID ="txtChartOAccountAllocation" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
 
</telerik:RadAjaxManager> 


 
<div>
 
 <table width ="100%">
    
 
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Budget Account Setting</th>
         </tr>

           <tr>
            <td style="width: 50px; height: 30px;">
                <asp:Label ID="lblAccountGroup" runat="server" Text="Account Group" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
              
                      <telerik:RadComboBox ID="cmbAccountGroup" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue"></telerik:RadComboBox>
              
                   </td>
            <td style="width: 50px; height: 30px;">
                &nbsp;</td>
            <td class="style2">
                
            </td>
          
         </tr>
          <tr>
            <td style="width: 50px; height: 30px;">
                <asp:Label ID="lblAccountSubGroup" runat="server" Text="Account Sub Group" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
                 <telerik:RadComboBox ID="cmbAccountSubGroup" Runat="server" AutoPostBack="True" 
                    Skin="WebBlue" EmptyMessage ="Select Account SubGroup"></telerik:RadComboBox>
                  </td>
                   </tr>
                   <tr>
             <td>  </td>
             <td colspan="4" align="left" class ="ErrorMsg">
                <asp:Label ID="lblChartOfAccountAllocation" runat ="server" ></asp:Label></td>
          
         </tr>
        </table  >
   <table width="100%">
          <tr>
          <td>
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
          <telerik:RadGrid ID="dgBudgetAccountSetting" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true" PageSize="50" Width="930px">
             
             <MasterTableView>
               <Columns>
            <telerik:GridBoundColumn HeaderText="BudgetSettingId" Display ="false"  DataField="BudgetSettingId" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="AccountSubGroupID" Display ="false" DataField="AccountSubGroupID">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="AccountGroupID" Display ="false" DataField="AccountGroupID" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="ChartofAccountID" Display ="false" DataField="ChartofAccountID" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Account Sub Group" Display ="true" DataField="AccountSubGroup" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Account Type" Display ="true" DataField="AccountType" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
              <telerik:GridTemplateColumn HeaderText="% Allocation" >
            <ItemTemplate>
             <telerik:RadTextBox ID="txtChartOAccountAllocation"  AutoPostBack="true"
              OnTextChanged="txtChartOAccountAllocation_TextChanged" width="60"  Runat="server" Skin="WebBlue">
               </telerik:RadTextBox>
               </ItemTemplate>
             </telerik:GridTemplateColumn>              
                        </Columns>
                         </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
                 </ContentTemplate>
                 </asp:UpdatePanel>
          </td>
          </tr>
  <tr>
   <td colspan="4" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" 
                    Skin="WebBlue" Visible ="false" /></td>
   </tr>
 
        </table>

 
      </div> 
</asp:Content>
