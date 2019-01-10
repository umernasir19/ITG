<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="BankTransactionSheet.aspx.vb" Inherits="Integra.BankTransactionSheet" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>
   <table  width="100%" >
    <tr>
<td>
</td>
<td class="ErrorMsg">
    <asp:Label ID="lblMSG" Visible="false" runat="server" ></asp:Label>
</td>
</tr>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >
           Bank Transaction</th>
         </tr>
         <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Transaction Date" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
                    <telerik:RadDatePicker ID="txtTransactionDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
 <DateInput ID="DateInput1"  runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>
 <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                   </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Transcation Type" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td class="style2">
              <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
              <asp:RadioButtonList ID="rblTranscationType" runat="server" AutoPostBack="True"
                            RepeatDirection="Horizontal" RepeatLayout="Flow" Font-Names="verdana" Font-Size="X-Small" Font-Bold="true"   ForeColor="darkRed" TabIndex="18">
                            <asp:ListItem Selected="True">BPV</asp:ListItem><asp:ListItem>BRV</asp:ListItem></asp:RadioButtonList>
                </ContentTemplate>
                 </asp:UpdatePanel>   
            </td>
              <td class="style2">
              <asp:Label ID="Label9" runat="server" Text="Currency" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                   <asp:UpdatePanel ID="upCmbCurrency" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <telerik:RadComboBox ID="CmbCurrency" Runat="server" AutoPostBack="True"  
                    Skin="WebBlue">
                    <Items>
                    <telerik:RadComboBoxItem Value="0" Text="PKR" />
                      <telerik:RadComboBoxItem Value="1" Text="USD" />
                    </Items>
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>   
            </td>
          
         </tr>
         </table>

   <table  >
   <tr>
     <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label3" runat="server" Text="Please select account head" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
       <asp:UpdatePanel ID="upcmbAccountHead" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <telerik:RadComboBox ID="cmbAccountHead" Runat="server" AutoPostBack="True"   Width="400"
                    Skin="WebBlue">
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>   
   </td>
   </tr>
    <tr>
       <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label4" runat="server" Text="Please write name of payee" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
     <telerik:RadTextBox ID="txtNameOfPayee" Runat="server" Skin="WebBlue" Width="400" >
                </telerik:RadTextBox>
   </td>
  
                 <td>
               
   <asp:UpdatePanel ID="upcmbECPCode" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                  <telerik:RadComboBox ID="cmbECPCode" Runat="server" AutoPostBack="True"  Skin="WebBlue">
             
                  <%--<DefaultItem Value="0" Text="ECP Code" />--%>
                  
                </telerik:RadComboBox>
                      </ContentTemplate>
                 </asp:UpdatePanel>
   </td>
    <td>
    
               <asp:UpdatePanel ID="upcmbHKCode" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                  <telerik:RadComboBox ID="cmbHKCode" Runat="server" AutoPostBack="True" Skin="WebBlue">
                 <%-- <DefaultItem  Value="0" Text="HK Code" />--%>
                      </telerik:RadComboBox>
                      </ContentTemplate>
                 </asp:UpdatePanel>
                 </td>
   </tr>
   <tr>
      <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label5" runat="server" Text="Please write narration" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
 
   <td>
  <telerik:RadTextBox ID="txtNarration" Runat="server" Skin="WebBlue"  Width="400px" 
           Height="48px" TextMode="MultiLine" >
                </telerik:RadTextBox>
   </td>
   </tr>
   <tr>
   <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label8" runat="server" Text="Cheque No." 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
     <telerik:RadTextBox ID="txtChequeNo" Runat="server" Skin="WebBlue" >
                </telerik:RadTextBox>
   </td>
   </tr>
     <tr>
     <td style="width: 268px; height: 30px;">
   
   </td>
   <td align="right">
    <asp:Label ID="Label6" runat="server" Text="Please write amount" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
         <asp:UpdatePanel ID="uptxtTotalAmount" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
   <telerik:RadNumericTextBox  ID="txtTotalAmount" Runat="server" AutoPostBack="true"  Font-Bold="true" Skin="WebBlue" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel> 
   </td>
   </tr>
 
    <tr>
    <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label7" runat="server" Text="Notes" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
             <telerik:RadTextBox ID="txtNotes" Runat="server" Skin="WebBlue"  Width="400px" 
           Height="48px" TextMode="MultiLine" >
                </telerik:RadTextBox>
   </td>
   </tr>
    <tr>
         <td style="width: 268px; height: 30px;">

   </td>
   <td align="right">
       <asp:Label ID="Label12" runat="server" Text="Total Sum" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
     <asp:UpdatePanel ID="uptxtTotalSum" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
   <telerik:RadNumericTextBox  ID="txtTotalSum" Runat="server" ReadOnly="true" Font-Bold="true" Skin="WebBlue" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel>  

   </td>
    <td>
    <telerik:RadButton ID="btnAddDetail" runat="server" Text="Add Detail" Skin="WebBlue">
                    </telerik:RadButton>

   </td>
   </tr>
     <tr>
       <td style="width: 268px; height: 30px;">
   <asp:UpdatePanel ID="upchkIsTax" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
        <asp:CheckBox ID="chkIsTax" Text="Is Taxable" Checked="true"   AutoPostBack="true" runat="server"  Font-Names="Calibri" Font-Size="Medium" />
   </ContentTemplate>
 </asp:UpdatePanel>  
   </td>
   </tr>
   <tr>
      <td style="width: 268px; height: 30px;">
    <asp:UpdatePanel ID="uplblDeduction" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
       <asp:Label ID="lblDeduction" runat="server" Text="Deduction (%)" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                            </ContentTemplate>
                 </asp:UpdatePanel>  
   </td>
   <td>
      <asp:UpdatePanel ID="uptxtIsTaxableDeduction" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <telerik:RadNumericTextBox  ID="txtIsTaxableDeduction" Type="Number" AutoPostBack="true" Runat="server" Font-Bold="true"
                       Skin="WebBlue" BackColor="#80BFFF"  Width="80">
                </telerik:RadNumericTextBox>              
                  <asp:Label ID="lblbank" runat="server" Text="State Bank of Pakistan" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>    
                   </ContentTemplate>
                 </asp:UpdatePanel>   
   <asp:RangeValidator ID="rgvField" runat="server" ControlToValidate="txtIsTaxableDeduction"
        Display="Dynamic" Type="Double" MaximumValue ="100" CssClass ="ErrorMsg" ErrorMessage="error!" Text="Deduction Less or Equal 100.">
    </asp:RangeValidator>
             
   </td>
   <td>
      <asp:UpdatePanel ID="uptxtTexTotalAmount" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
       <telerik:RadNumericTextBox  ID="txtTexTotalAmount"  Runat="server" Font-Bold="true" Skin="WebBlue" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel>  
   </td>

   </tr>
   <tr>
   <td style="width: 268px; height: 30px;">
     <asp:UpdatePanel ID="uplblTaxChequeNo" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
    <asp:Label ID="lblTaxChequeNo" runat="server" Text="Tax Cheque No." 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
                       </ContentTemplate>
                 </asp:UpdatePanel>  
   </td>
   <td>
     <asp:UpdatePanel ID="uptxtTexableChequeNo" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
   <telerik:RadTextBox ID="txtTexableChequeNo" Runat="server" Skin="WebBlue" >
                </telerik:RadTextBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>  
   </td>
   </tr>
             </table>
             <table width="100%">
<tr>
<td>
    <telerik:RadGrid ID="dgBankTransactionDetail" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50" >
            <MasterTableView>
            <Columns>            
            <telerik:GridBoundColumn HeaderText="BankTransactionDetailID" DataField="BankTransactionDetailID" Display="false" >
           <ItemStyle HorizontalAlign="Left"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="ChartofAccountID" DataField="ChartofAccountID" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Account Head" DataField="AccountHead">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>  
            <telerik:GridBoundColumn HeaderText="Payee" Display="false" DataField="NameOfPayee">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>  
           <telerik:GridBoundColumn HeaderText="Narration" DataField="Narration">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="20%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="Amount" DataField="Amount">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>  
              <telerik:GridBoundColumn HeaderText="ECP Code" DataField="ECPCode">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>     
            <telerik:GridBoundColumn HeaderText="HK Code" DataField="HKCode">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Notes" DataField="Notes" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Cheque No" Display="false" DataField="ChequeNo">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" 
            CommandName="Delete" ConfirmTextFormatString="Are You Sure You want to Delete Record" 
            HeaderStyle-Width="4%" ButtonType="ImageButton"></telerik:GridButtonColumn>
            </Columns>
            </MasterTableView>
              </telerik:RadGrid>
</td>
</tr>
</table>
          <table>
    <tr>
      <td style="width: 210px; height: 30px;"></td>
  <td align="center">
     <telerik:RadButton ID="btnPostthisvoucher" runat="server" Text="Post this voucher" Skin="WebBlue">
                    </telerik:RadButton>
 
     &nbsp;&nbsp;
       <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
  </td>
  </tr>
          </table>
       </div> 
</asp:Content> 