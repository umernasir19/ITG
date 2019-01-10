<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeBehind="CashTransactionSheet.aspx.vb" Inherits="Integra.CashTransactionSheet" %>
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
           Cash Transaction</th>
         </tr>
           <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label8" runat="server" Text="Vochar No." 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td  style="width: 166px; height: 30px;">
           <telerik:RadTextBox ID="txtVocharNo" Runat="server" Skin="WebBlue" ReadOnly="True"  >
                </telerik:RadTextBox>
                   </td>
            
           
          
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
                            <asp:ListItem Selected="True">CPV</asp:ListItem><asp:ListItem>CRV</asp:ListItem></asp:RadioButtonList>
                </ContentTemplate>
                 </asp:UpdatePanel>   
            </td>
              <td class="style2">
            
            </td>
          
         </tr>
         </table>

   <table  >
   <tr>
     <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label3" runat="server" Text="Account Head" 
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
    <asp:Label ID="Label4" runat="server" Text="Payee Name" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td>
     <telerik:RadTextBox ID="txtNameOfPayee" Runat="server" Skin="WebBlue" Width="400" >
                </telerik:RadTextBox>
   </td>
   <td>
    
               <asp:UpdatePanel ID="upcmbHKCode" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                  <telerik:RadComboBox ID="cmbHKCode" Runat="server" AutoPostBack="True" Skin="WebBlue">
               <%-- <DefaultItem Value="0" Text="HK Code"  />--%>
                 
                </telerik:RadComboBox>
                      </ContentTemplate>
                 </asp:UpdatePanel>
                 </td>
                 <td>
               
   <asp:UpdatePanel ID="upcmbECPCode" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                  <telerik:RadComboBox ID="cmbECPCode" Runat="server" AutoPostBack="True"  Skin="WebBlue">
                 <%--    <DefaultItem Value="0" Text="ECP Code"  />--%>
                   
                </telerik:RadComboBox>
                      </ContentTemplate>
                 </asp:UpdatePanel>
   </td>
   </tr>
   <tr>
      <td style="width: 268px; height: 30px;">
    <asp:Label ID="Label5" runat="server" Text="Narration" 
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
    <asp:Label ID="Label6" runat="server" Text="Amount" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
   </td>
   <td></td>
   <td>
   <telerik:RadNumericTextBox  ID="txtTotalAmount" Runat="server" Font-Bold="true" Skin="WebBlue" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>

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
   <td></td>
   <td>
    <telerik:RadButton ID="btnAddDetail" runat="server" Text="Add Detail" Skin="WebBlue">
                    </telerik:RadButton>

   </td>
   </tr>
             </table>
<table width="100%">
<tr>
<td>
    <telerik:RadGrid ID="dgCashDetail" runat="server" CellSpacing="0" 
                AutoGenerateColumns="false"  Skin="WebBlue"  
                Visible="False" PageSize="50" >
            <MasterTableView>
            <Columns>
            
            <telerik:GridBoundColumn HeaderText="CashTransactionDetailID" DataField="CashTransactionDetailID" Display="false" >
           <ItemStyle HorizontalAlign="Left"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="ChartofAccountID" DataField="ChartofAccountID" Display="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Account Head" DataField="AccountHead" >
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Payee" DataField="NameOfPayee">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>           
            <telerik:GridBoundColumn HeaderText="HK Code" DataField="HKCode">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="ECP Code" DataField="ECPCode">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Narration" DataField="Narration">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderText="Amount" DataField="Amount">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Notes" DataField="Notes">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
              <telerik:GridButtonColumn UniqueName="DeleteColumn" Display="false"  Text="" CommandName="Delete" ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="35px" ButtonType="ImageButton"></telerik:GridButtonColumn>
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
                       <telerik:RadButton ID="btnPostPrintthisvoucher" Visible="false" runat="server" Text="Post & Print this voucher" Skin="WebBlue">
                    </telerik:RadButton>
  &nbsp;&nbsp;
     <telerik:RadButton ID="btnPostAddmore" runat="server" Text="Post & Add more" Skin="WebBlue">
                    </telerik:RadButton>
     &nbsp;&nbsp;
       <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
  </td>
  </tr>
          </table>
       </div> 

</asp:Content> 