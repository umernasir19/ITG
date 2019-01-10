<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="BudgetAccountGroupView.aspx.vb" Inherits="Integra.BudgetAccountGroupView" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
   <table width="100%">
    <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Budget Account Group</th>
         </tr>
         <tr>
         <td align="right">
                <telerik:RadButton ID="btnEdit" runat="server" Text="Edit Account Group Setting" 
                    Skin="WebBlue"/>
         </td>
         </tr>
  
          <tr>
          <td>
 
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
      <telerik:GridBoundColumn HeaderText="% Allocation" DataField="PercentageAllocationAccountGroup" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
                           
                        </Columns>
                         </MasterTableView>
                    <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
                                <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
                            </ClientSettings>
            </telerik:RadGrid>
          
          </td>
          </tr>
 
        </table>

 
  
</asp:Content>