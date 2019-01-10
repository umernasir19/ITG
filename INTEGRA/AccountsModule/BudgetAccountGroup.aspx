<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BudgetAccountGroup.aspx.vb" Inherits="Integra.BudgetAccountGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<telerik:RadAjaxManager ID="radajaxmanager" runat ="server" >
<AjaxSettings >
<telerik:AjaxSetting AjaxControlID ="txtAccountGroupAllocation">
<UpdatedControls >
<telerik:AjaxUpdatedControl ControlID ="txtAccountGroupAllocation" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
<div> 
 
   <table width="100%">
    <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Budget Account Group</th>
         </tr>

  
          <tr>
          <td>
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
          <telerik:RadGrid ID="dgBudgetAccountGroupSetting" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true" PageSize="50" Width="930px">
             
             <MasterTableView>
                 <Columns>
                     <telerik:GridBoundColumn HeaderText="BudgetAccountGroupSettingID" DataField="BudgetAccountGroupSettingID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="AccountGroupID" DataField="AccountGroupID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>            
            <telerik:GridBoundColumn HeaderText="Account Group" DataField="AccountGroup">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn HeaderText="% Allocation" >
            <ItemTemplate>
         <telerik:RadTextBox ID="txtAccountGroupAllocation"  Text='<% #Eval("PercentageAllocationAccountGroup") %>'   width="60"  Runat="server" Skin="WebBlue">
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
                    Skin="WebBlue"/>
 
                    </td>
   </tr>
        </table>

 
      </div> 
</asp:Content>
