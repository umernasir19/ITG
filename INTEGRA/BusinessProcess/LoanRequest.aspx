<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="LoanRequest.aspx.vb" Inherits="Integra.LoanRequest" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <telerik:RadAjaxManager ID="Radajax" runat ="server" >
 <AjaxSettings >
 <telerik:AjaxSetting AjaxControlID ="txtInstallmentMonthPeriod">
 <UpdatedControls >
 <telerik:AjaxUpdatedControl ControlID ="txtMonthlyInstallment" />

 </UpdatedControls> 
 </telerik:AjaxSetting>
 </AjaxSettings>
 
 </telerik:RadAjaxManager>
 <asp:Panel ID="pnlinfo" runat ="server" >
<table>
               <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
                   <th colspan ="6" align="center"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080; width:600px;">EURO CENTRA COMPANY LIMITED</th>
                               
                    </tr>
                     <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
                   <th colspan ="6" align="center"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080; width:600px;">LOAN FORM</th>
                               
                    </tr>

             <tr>
      <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblHRCode" runat="server" Text="I Mr./Miss/Mrs."></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtUserName" Runat="server" Skin="WebBlue" TabIndex="1" ReadOnly ="true" >
                </telerik:RadTextBox>

            </td>
                <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblCnic" runat="server" Text="C.N.I.C.#"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
             <%-- <telerik:RadTextBox ID="txtCnicNo" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>--%>
                <telerik:RadMaskedTextBox ID="txtCnicNo" runat="server" Mask="#####-#######-#" ReadOnly ="true"  >
                </telerik:RadMaskedTextBox>

            </td>
                        <td style="height: 30px; width: 85px;"> </td>
                            <td style="height: 30px; width: 55px;"> </td>
      </tr>
            <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblFullName" runat="server" Text="Principal Amount"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtPrincipalAmount" Runat="server" Skin="WebBlue" TabIndex="1">
                </telerik:RadTextBox>

            </td>
           
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="for the period of"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
              <telerik:RadTextBox ID="txtInstallmentMonthPeriod" Runat="server" Skin="WebBlue" TabIndex="2" AutoPostBack ="true" >
                </telerik:RadTextBox>

            </td>
                    <td style="height: 30px; width: 85px;"> </td>
                        <td style="height: 30px; width: 55px;"> </td>
            
        </tr>
       <tr>
        <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblSurname" runat="server" Text="Monthly installment of Rs."></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
               <%-- <telerik:RadTextBox ID="txtMonthlyInstallment" Runat="server" Skin="WebBlue" TabIndex="3" ReadOnly ="true"  DataFormatString="{0:#,##0;(#,##0);0}" >
                </telerik:RadTextBox>--%>
                <telerik:RadNumericTextBox ID="txtMonthlyInstallment" Runat="server" Skin="WebBlue" TabIndex="3" ReadOnly ="true" DecimalDigits="2"></telerik:RadNumericTextBox>
                       
            </td>
                <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Starting from month of"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                                    <telerik:RadComboBox ID="cmbMonth" Runat="server" AutoPostBack="false" 
                    Skin="WebBlue" TabIndex="4" Width="80px">
                    <Items>   
               <telerik:RadComboBoxItem Value="1" Text="January"/>
                <telerik:RadComboBoxItem Value="2" Text="February"/>            
                  <telerik:RadComboBoxItem Value="3" Text="March"/>
                  <telerik:RadComboBoxItem Value="4" Text="April"/>
                <telerik:RadComboBoxItem Value="5" Text="May"/>            
                  <telerik:RadComboBoxItem Value="6" Text="June"/>
                  <telerik:RadComboBoxItem Value="7" Text="July"/>
                <telerik:RadComboBoxItem Value="8" Text="August"/>            
                  <telerik:RadComboBoxItem Value="9" Text="September"/>
                  <telerik:RadComboBoxItem Value="10" Text="October"/>
                <telerik:RadComboBoxItem Value="11" Text="November"/>            
                  <telerik:RadComboBoxItem Value="12" Text="December"/>
                 </Items>
                </telerik:RadComboBox>
                          
                       
                    &nbsp;
                          
                       
                    <telerik:RadComboBox ID="cmbYear" Runat="server" AutoPostBack="false" 
                    Skin="WebBlue" TabIndex="5" Width="70px">
                    <Items>   
               <telerik:RadComboBoxItem Value="0" Text="2013"/>
                <telerik:RadComboBoxItem Value="1" Text="2014"/>            
                  <telerik:RadComboBoxItem Value="2" Text="2015"/>
                 </Items>
                </telerik:RadComboBox>
               </td>
                            <td style="height: 30px; width: 55px;"> </td>
       </tr>
       <tr>
       <td style="width: 128px; height: 30px;">
               
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
               <telerik:RadButton ID="btnGenerate" runat="server" Text="GenerateLoan" 
                    Skin="WebBlue" TabIndex="6">
                </telerik:RadButton>
            </td>
       </tr>
         </table>
         </asp:Panel>
        <table width="100%">
<tr>
 <td align="right">
 </td>
 </tr>
 <tr>
<td align ="right" > </td>
</tr>
<tr><td>
	    <telerik:RadGrid ID="dgLoan" runat="server" CellSpacing="0"  AutoGenerateColumns="false"  Skin="WebBlue"  Visible="true" PageSize="50">
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="LoanDetailID" DataField="LoanDetailID" Display ="false"  >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="15%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn>   
            <telerik:GridBoundColumn HeaderText="Month" DataField="InstallmentMonthYear" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>              
             <telerik:GridBoundColumn HeaderText="Installment Amount" DataField="InstallmentAmount" DataFormatString="{0:#,##0;(#,##0);0}">
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>   
               <telerik:GridBoundColumn HeaderText="Loan Out Statnding" DataField="LoanOutStatnding" DataFormatString="{0:#,##0;(#,##0);0}" >
           <ItemStyle HorizontalAlign="Left" Width ="50px" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>   
               <telerik:GridBoundColumn HeaderText="InstallmentMonth" DataField="InstallmentMonth" Display ="false">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="InstallmentYear" DataField="InstallmentYear" Display ="false">
            <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="10%" HorizontalAlign="Left"  />
            </telerik:GridBoundColumn> 
            </Columns>
            </MasterTableView>
          <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
<Selecting AllowRowSelect="false" EnableDragToSelectRows="false" />
 <Selecting AllowRowSelect="True" />
 </ClientSettings>
    <HeaderStyle Font-Names="Microsoft Sans Serif" />
             </telerik:RadGrid>
                        
 
  </td>			
</tr> 
<tr>
 <td align="center">
    <telerik:RadButton ID="btnSave" runat="server" Text="Save"   Skin="WebBlue">
                </telerik:RadButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <telerik:RadButton ID="btncancel" runat="server" Text="Cancel"   Skin="WebBlue">
                </telerik:RadButton>
     
 </td>
 </tr>
</table>

 </asp:Content> 
