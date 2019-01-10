<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="HRPayRollGeneration.aspx.vb" Inherits="Integra.HRPayRollGeneration" %>

 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <telerik:RadAjaxManager ID="Radajax" runat="server">
 <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="btnBonus">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="dgPayroll" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="CmbMonth">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="dgPayroll" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
  <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="CmbMonth">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="lblTransactiondate" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
  <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="CmbMonth">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="txtTransactiondate" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
  <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="CmbMonth">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="btnBonus" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
  <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="CmbMonth">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="btnGenerate" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
  <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="CmbMonth">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="btnCalculate" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="btnCalculate">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="btnGenerate" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
  <AjaxSettings>
 <telerik:AjaxSetting AjaxControlID="txtTransactiondate">
 <UpdatedControls>
 <telerik:AjaxUpdatedControl ControlID="btnCalculate" />
 </UpdatedControls>
 </telerik:AjaxSetting>
 </AjaxSettings>
 </telerik:RadAjaxManager>
 <table>
 <tr>
<td style="width: 101px">Fiscal Year</td>
 <td align="left" class="TopHeaderTable3" style="width: 123px">    
             		     <%--<asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
               <ContentTemplate>--%>
                      <telerik:RadComboBox ID="cmbFiscalYear" Runat="server" AutoPostBack="True"  
                    Skin="WebBlue" Width="70px" Font-Size="Smaller">
                    <Items>
                    <telerik:RadComboBoxItem Value="0" Text="2013" />
                      <telerik:RadComboBoxItem Value="1" Text="2014" />
                      <telerik:RadComboBoxItem Value="2" Text="2015" />
                               </Items>
                </telerik:RadComboBox>
                  <%-- </ContentTemplate>
                 </asp:UpdatePanel>                
                        --%>
                 	 
 </td>
 <td></td>
            <td></td>
 </tr>
  
<tr>
<td style="width: 101px">For the Month</td>
 <td align="left" class="TopHeaderTable3" style="width: 123px">    
             		                        <telerik:RadComboBox ID="CmbMonth" Runat="server" AutoPostBack="True"  
                    Skin="WebBlue" Width="70px" Font-Size="Smaller">
                    <Items>
                    <telerik:RadComboBoxItem Value="0" Text="Select Month" />
                    <telerik:RadComboBoxItem Value="1" Text="January" />
                      <telerik:RadComboBoxItem Value="2" Text="February" />
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
 <td></td>
            <td></td>
 </tr>
 <tr>
 <td valign ="middle"  style="width: 101px" > <asp:Label ID="lblTransactiondate" runat="server" Text="Transaction date" Visible ="false" ></asp:Label></td>
 <td align="left" class="TopHeaderTable3" style="width: 123px" >  
            
                 <telerik:RadDatePicker ID="txtTransactiondate" runat="server" Culture="en-US" 
                      TabIndex="55" MinDate="1111-01-01"  Width="90px"  Font-Size="Smaller" Visible ="false" AutoPostBack ="true" >
<Calendar ID="Calendar7" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="55"  Font-Size="Smaller"></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="55"></DatePopupButton>
                </telerik:RadDatePicker>
     
             </td>
          <td></td>
            <td></td>
         </tr>
 </table>
 <table width="99%">
 <tr> 
<td align ="right" style="width:925px"><telerik:RadButton ID="btnBonus" runat="server"  Text="Bonus" Skin="WebBlue" Visible ="false" > </telerik:RadButton><telerik:RadButton ID="btnCalculate" runat="server" Enabled ="false"  Text="Calculate" Skin="WebBlue" Visible ="false" > </telerik:RadButton> <telerik:RadButton ID="btnGenerate" runat="server" Text="Generate" Skin="WebBlue" Enabled ="false" Visible ="false"> </telerik:RadButton></td>
</tr>
 </table>
  <table width="100%">

 
<tr><td colspan ="5">
	    <telerik:RadGrid ID="dgPayroll" Width ="930px" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="HRID" DataField="HRID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="HRpayrollID" DataField="HRpayrollID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>    
             <telerik:GridBoundColumn HeaderText="Name" DataField="EmployeeAlias" Display ="true"  >
           <ItemStyle HorizontalAlign="Left"  Font-Size="Smaller"  Width="100px" Wrap="false"/>
            <HeaderStyle Width="15%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>                
             <telerik:GridBoundColumn HeaderText="Designation" DataField="Designation" >
           <ItemStyle HorizontalAlign="Left" Font-Size="Smaller"  Width="120px" Wrap="false" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="DOJ" DataField="DateOfJoining">
            <ItemStyle HorizontalAlign="Left" Width="30px"  Font-Size="Smaller" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn>
            
            <telerik:GridTemplateColumn  HeaderText="Voucher">
               <itemstyle horizontalalign="Left" />
              <ITEMTEMPLATE>
                <%--<asp:UpdatePanel ID="UpdatePanel" UpdateMode="Conditional" runat="server">
               <ContentTemplate>--%>
                <telerik:RadComboBox ID="CMBVoucher" Runat="server" AutoPostBack="True" Skin="WebBlue"  Width="45px" Font-Size="Smaller">
                <Items>
              <telerik:RadComboBoxItem Value="0" Text="BPV" />
              <telerik:RadComboBoxItem Value="1" Text="CPV" />
                </Items>
                </telerik:RadComboBox>
                <%--</ContentTemplate>
                 </asp:UpdatePanel>--%>
                  </ITEMTEMPLATE>
                     <ItemStyle HorizontalAlign="Left" Width="30px"  Font-Size="Smaller" />
                <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
				 </telerik:GridTemplateColumn>
           

            <telerik:GridTemplateColumn HeaderText="Chq.No." >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtCheckno" width="42px"  Runat="server" Skin="WebBlue"  Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>
                
                
           

                 <telerik:GridBoundColumn HeaderText="HK" DataField="HKCode" >
            <ItemStyle HorizontalAlign="Left"  Width="100px" Font-Size="Smaller" Wrap="false"/>
            <HeaderStyle Width="15%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
            </telerik:GridBoundColumn> 

             <telerik:GridBoundColumn HeaderText="Dept" DataField="ECPCode" >
             <ItemStyle HorizontalAlign="Left"  Font-Size="Smaller" Wrap="false" />
            <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
            </telerik:GridBoundColumn> 

          <%--  <telerik:GridBoundColumn HeaderText="Basic" DataField="Basic" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> --%>

            <telerik:GridTemplateColumn HeaderText="Basic" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtBasic" width="50px"  Runat="server" Skin="WebBlue" Font-Size="Smaller" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  DataType="System.Decimal" >
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn> 

          <%--  <telerik:GridBoundColumn HeaderText="Conveyance Allowance" DataField="ConveyanceAllowance" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>--%> 

             <telerik:GridTemplateColumn HeaderText="Conveyance Allowance" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtConveyanceAllowance" width="50px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn> 
<%--
            <telerik:GridBoundColumn HeaderText="Mobile Allowance" DataField="MobileAllowance" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> --%>

             <telerik:GridTemplateColumn HeaderText="Mobile Allow." >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtMobileAllowance" width="40px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>

            <%--<telerik:GridBoundColumn HeaderText="Misc Allowance" DataField="MiscAllowance" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>--%>

              <telerik:GridTemplateColumn HeaderText="Misc Allow." >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtMiscAllowance" width="40px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>

           <%-- <telerik:GridBoundColumn HeaderText="Other Allowance" DataField="OtherAllow" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> --%>

              <telerik:GridTemplateColumn HeaderText="Other Allow." >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtOtherAllow" width="30px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>

              <telerik:GridTemplateColumn HeaderText="Bonus">
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtBonus" width="50px"  Runat="server" Skin="WebBlue" ReadOnly ="true" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>

             <telerik:GridBoundColumn HeaderText="Gross Salary" DataField="GrossSalary" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"   DataType="System.Decimal" >
            <ItemStyle HorizontalAlign="Left"  Width="30px" Font-Size="Smaller"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>

         <%--    <telerik:GridBoundColumn HeaderText="EOBI" DataField="DeductionEOBI" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 

            </telerik:GridBoundColumn>--%>

            <telerik:GridTemplateColumn HeaderText="EOBI" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtDeductionEOBI" width="30px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>

            

          <%--   <telerik:GridBoundColumn HeaderText="Tax" DataField="DeductionTax" >
            <ItemStyle HorizontalAlign="Left"  Width="30px"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>--%>

             <telerik:GridTemplateColumn HeaderText="Tax" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtDeductionTax" width="50px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn>

              <telerik:GridTemplateColumn HeaderText="Deduction" >
            <ItemTemplate>
                  <telerik:RadTextBox ID="txtDeduction" width="40px"  Runat="server" Skin="WebBlue" Font-Size="Smaller">
                </telerik:RadTextBox>
            </ItemTemplate>
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  Font-Size="Smaller"/> 
             </telerik:GridTemplateColumn> 

               

           <telerik:GridBoundColumn HeaderText="Net Salary" DataField="NetSalary" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  DataType="System.Decimal" >
            <ItemStyle HorizontalAlign="Left"  Width="30px" Font-Size="Smaller"/>
            <HeaderStyle Width="10%" HorizontalAlign="Left" Font-Size="Smaller" /> 
            </telerik:GridBoundColumn>

              <telerik:GridTemplateColumn HeaderText="Select" UniqueName="Select" AllowFiltering ="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" ></asp:CheckBox>
                        </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            </MasterTableView>
          <ClientSettings  EnableRowHoverStyle="true" Scrolling-AllowScroll="True">
                            <Scrolling AllowScroll="true" EnableVirtualScrollPaging="false" />
                            <Selecting AllowRowSelect="True" />
                        </ClientSettings>
            </telerik:RadGrid>
                        
 
  </td>			
</tr> 

</table>
 </asp:Content> 
 
