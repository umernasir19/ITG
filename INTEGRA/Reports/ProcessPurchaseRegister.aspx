<%@ Page Title="Purchase Register" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ProcessPurchaseRegister.aspx.vb" Inherits="Integra.ProcessPurchaseRegister" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript">
     function isNumericKey(e) {
         var charInp = window.event.keyCode;
         if (charInp > 31 && (charInp < 48 || charInp > 57)) {
             return false;
         }
         return true;
     }
     function isNumericKeyy(e) {
         var charInp = window.event.keyCode;
         if (charInp != 46 && (charInp < 48 || charInp > 57)) {
             return false;
         }
         return true;
     }
   
    </script>
    <table>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                PURCHASE REGISTER
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
            </td>
            <td valign="top">
            <div style=" margin-left: 16px;">
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
         </div>   </td>
            <td>
            </td>
            <td>
                <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
            </td>
            <td valign="top">
              <div style=" margin-left: 16px;">
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
       </div>        </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
     </table> <br />  <table>
        <tr>
            <td valign="top">
           
              <asp:Label ID="Label2" runat="server" Text=" GRN No :"></asp:Label>
                
            </td>
           
               <td valign="top">
                <asp:DropDownList ID="cmbGRNNo" CssClass="combo" Width="133" runat="server" TabIndex="0"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td valign="top">
        <asp:label id ="lblID" runat="Server" text="0" visible="false"></asp:label>
            </td>

             <td valign="top">
                <asp:Label ID="Label1" runat="server" Text="Item Code :"></asp:Label>
            </td>
         
            <td valign="top">
                <asp:TextBox ID="TXTCodeEntry" AutoPostBack ="true"  CssClass="textbox" runat="server"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTCodeEntry"
                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTCodeEntryForPurchase" />
            </td>
        </tr>
</table>
<table>
     <tr>
      <td style="width: 110px;">
             <div style=" margin-left: 0px;">
                Season</div>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
             <div style=" margin-left: 8px;">
             <asp:DropDownList ID="cmbSeason" runat="server" AutoPostBack="true" CssClass="combo"
                        Width="135px" Style="margin-left: -65px;  margin-top: 6px;">
                    </asp:DropDownList></div>
            </td>


             <td style="height: 35px">
               <div style="     margin-left: -73px;">
                    Sr No:
               </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: -24px;">
                    <asp:DropDownList ID="cmbSrNo" runat="server" AutoPostBack="false" CssClass="combo"
                        Width="135px" Style="margin-left: 0px;  margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>
     </tr>
     </table>
<br />
<br />
<br />
        <table>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <td>
        </td>
        <tr>
            <td>
            </td>
            <td>
            <div style=" margin-left: 252px;">
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton></div>
            </td>
        </tr>
    </table>
</asp:Content>

