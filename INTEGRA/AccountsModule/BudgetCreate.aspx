<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BudgetCreate.aspx.vb" Inherits="Integra.BudgetCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
 
 <table width="100%">
    
 
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >Create Budget</th>
         </tr>

           <tr>
            <td style="width: 70px; height: 30px;">
                <asp:Label ID="lblMonth" runat="server" Text="Month" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
              <telerik:RadComboBox ID="cmbMonth" Runat="server" AutoPostBack="True" Skin="WebBlue">
              <Items >
              <telerik:RadComboBoxItem Value="1" Text="January" />
                 <telerik:RadComboBoxItem Value="2" Text="Febuary" />
                    <telerik:RadComboBoxItem Value="3" Text="March" />
                       <telerik:RadComboBoxItem Value="4" Text="April" />
                          <telerik:RadComboBoxItem Value="5" Text="May" />
                             <telerik:RadComboBoxItem Value="6" Text="June" />
                                <telerik:RadComboBoxItem Value="7" Text="July" />
   <telerik:RadComboBoxItem Value="8" Text="August" />
      <telerik:RadComboBoxItem Value="9" Text="September" />
         <telerik:RadComboBoxItem Value="10" Text="October" />
            <telerik:RadComboBoxItem Value="11" Text="November" />
               <telerik:RadComboBoxItem Value="12" Text="December" />
                                  
              </Items>
              </telerik:RadComboBox>
                </td>
                  <td style="width: 70px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Year" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
              <telerik:RadComboBox ID="cmbYear" Runat="server" AutoPostBack="True" Skin="WebBlue">
              <Items >
              <telerik:RadComboBoxItem Value="0" Text="2013" />
                 <telerik:RadComboBoxItem Value="1" Text="2014" />
                    <telerik:RadComboBoxItem Value="2" Text="2015" />
                       <telerik:RadComboBoxItem Value="3" Text="2016" />
               </Items>
              </telerik:RadComboBox>
                </td>


          
          
         </tr>
         <tr>
         <td style="width: 70px; height: 30px;">
                <asp:Label ID="lblRemittance" runat="server" Text="Remittance($)" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
            <telerik:RadTextBox ID="txtRemittance" runat ="server"  Skin ="WebBlue" ></telerik:RadTextBox>
            </td> 
         </tr>
         <tr>
          <td style="width: 60px; height: 30px;"> </td>
            <td  style="width: 50px; height: 30px;">
           <telerik:RadButton ID="btnCreateRemittance" runat ="server" Text="Create Budget"  Skin ="WebBlue"></telerik:RadButton>
            </td> 
            <td></td>
        <td align ="right"  style="width:600px; height: 30px;"> 
         <telerik:RadButton ID="btnSave" runat ="server" Text="Save Budget" Visible ="false"   Skin ="WebBlue"></telerik:RadButton></td>
             </tr> </table  >
   <table width="100%">
          <tr>
          <td>
          <telerik:RadGrid ID="dgBudgetPlain" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="true" PageSize="50" Width="930px">
             
                    <MasterTableView>
                           <Columns>
           <telerik:GridBoundColumn HeaderText="BudgetSettingId" DataField="BudgetSettingId" Display="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="ChartofAccountID" DataField="ChartofAccountID" Display="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn> 
              <telerik:GridBoundColumn HeaderText="AccountGroupID" DataField="AccountGroupID" Display="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
              <telerik:GridBoundColumn HeaderText="AccountSubGroupID" DataField="AccountSubGroupID" Display="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
             <telerik:GridBoundColumn HeaderText="Account Group" DataField="AccountGroup">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>         
            <telerik:GridBoundColumn HeaderText="Account Sub Group" DataField="AccountSubGroup">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Account Type" DataField="AccountType" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="% Allocation(CCH)" DataField="PercentageAllocationAccountGroup" >
            <ItemStyle HorizontalAlign="center" />
            <HeaderStyle Width="15%" HorizontalAlign="center" /> 
            </telerik:GridBoundColumn>
   
            <telerik:GridTemplateColumn HeaderText="CCH Amount"  AllowFiltering ="false">
                <ItemTemplate>
                         <asp:Label   id="lblCCHAmount" runat="server" width="40" ></asp:Label> 
                 </ItemTemplate>
                 <HeaderStyle Width="10%" HorizontalAlign="center"  /> 
                <ItemStyle HorizontalAlign="Left" />
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="% Allocation (SCH)" DataField="PercentageAllocationAccountSubGroup" >
            <ItemStyle HorizontalAlign="center" />
            <HeaderStyle Width="15%" HorizontalAlign="center" /> 
            </telerik:GridBoundColumn>
    
            <telerik:GridTemplateColumn HeaderText="SCH Amount"  AllowFiltering ="false">
                <ItemTemplate>
                     <asp:Label   id="lblSCHAmount" runat="server" width="40" ></asp:Label> 
                 </ItemTemplate>
                 <HeaderStyle Width="10%" HorizontalAlign="center"  /> 
                <ItemStyle HorizontalAlign="Left" />
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="% Allocation (CHB)" DataField="PercentageAllocationChartOfAccount" >
            <ItemStyle HorizontalAlign="center" />
            <HeaderStyle Width="15%" HorizontalAlign="center" /> 
            </telerik:GridBoundColumn>
     
            <telerik:GridTemplateColumn HeaderText="CHB Amount"  AllowFiltering ="false">
                <ItemTemplate>
                   <asp:Label   id="lblCHBAmount" runat="server" width="40" ></asp:Label> 
                          </ItemTemplate>
                    <HeaderStyle Width="10%" HorizontalAlign="center"  /> 
                <ItemStyle HorizontalAlign="Left" />
            </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
            <ClientSettings EnableRowHoverStyle="true" EnablePostBackOnRowClick="false">
            <Selecting AllowRowSelect="true" EnableDragToSelectRows="false" />
             </ClientSettings>
            </telerik:RadGrid>
          </td>
          </tr>
  
 
        </table>

 
      </div> 
</asp:Content>
