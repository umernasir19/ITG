<%@ Page Title="Store Issue Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="StoreIssueReport.aspx.vb" Inherits="Integra.StoreIssueReport" %>
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
     <table width ="100%">
      <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
              Store Issue Report
            </th>
        </tr>
        </table>
        <br />
        <table>
         <tr>
          <td style="height: 35px">
               
                    Manual Challan No:
               
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 2px;">
                    <asp:DropDownList ID="cmbManualChallanNo" runat="server" AutoPostBack="false" 
                        Width="135px" Style="margin-left: 0px;  margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>
             <td style="width: 110px;">
             <div style=" margin-left: 42px;">
                Season:</div>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
             <div style="     margin-left: -8px;">
             <asp:DropDownList ID="cmbSeason" runat="server" AutoPostBack="true" 
                        Width="135px" Style="margin-left: -9px;  margin-top: 6px;">
                    </asp:DropDownList></div>
            </td>


             <td style="height: 35px">
               <div style="     margin-left: 26px;">
                    Sr No:
               </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 20px;">
                    <asp:DropDownList ID="cmbSrNo" runat="server" AutoPostBack="false"
                        Width="135px" Style="margin-left: 0px;  margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>

        </tr>
        </table>
        <table>
        <tr>
                    <td style="width: 110px;">
                    <div>
                Item Code:</div>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 20px;">
            <div style="     margin-bottom: 7px;">
             <asp:TextBox ID="TXTCodeEntry" AutoPostBack ="true" style=" width: 127px;"  CssClass="textbox" runat="server"></asp:TextBox>
                                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTCodeEntry"
                            ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                            CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTCodeEntry" />
       </div>     </td>

         <td style="height: 35px">
               <div style="     margin-left: -20px;">
                    Department:
               </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 14px;     margin-top: 0px;">
                    <asp:DropDownList ID="cmbDepartment" runat="server" AutoPostBack="false" 
                        Width="250px" Style="margin-left: 0px;  margin-top: 6px;">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
            <asp:Label ID ="lblID" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
           

            

         </tr>  
         </table>
        <table >
              <tr>
            <td style=" height: 20px;">
                <asp:Label ID="lblForm" runat="server" Text="As :"></asp:Label>
            </td>
            <td valign="top">
            <div style=" margin-left: 87px;">
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker></div>
            </td>
            <td>
            </td>
            <td>
            <div style=" margin-left: 25px;"> 
                <asp:Label ID="lblTo" runat="server" Text="On :"></asp:Label></div>
            </td>
            <td valign="top">
            <div style=" margin-left: 23px;">
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker></div>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
     </table>   <table>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
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
            <div style=" margin-left: 340px;">
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton></div>
            </td>
        </tr>
    </table>
</asp:Content>

