<%@ Page Title="Product Ledger" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ProductLedger.aspx.vb" Inherits="Integra.ProductLedger" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
        <tr>
            <td style="width: 150px; height: 20px;">
                <div class="txt_newwww" style="width: 140px;">
                   Ledger Account
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtProductSearch" Style="margin-left: 0px;"
                        runat="server" AutoPostBack="true" Font-Size="8pt" Text="All"></asp:TextBox>
                     <cc1:AutoCompleteExtender runat="server" 
                                 ID="autoComplete1" 
                                 TargetControlID="txtProductSearch"
                                 ServicePath="../AutoComplete.asmx"
                                 ServiceMethod="GetCompletionList"
                                 MinimumPrefixLength="1" 
                                 CompletionInterval="10"
                                 EnableCaching="true"
                                 CompletionSetCount="12" 
                                 ContextKey="ProductSearch" /> 
                                 
                </div>
            </td>
        </tr>
        <asp:Panel runat ="server" ID="PnlFalseDate" Visible ="false"  >
        <tr>
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    Start Date
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 39px; margin-top: 6px;">
                    <asp:TextBox ID="txtStartDate" Style="text-align: center; width: 100px; margin-left: -39px;"
                        runat="server" Font-Size="8pt"></asp:TextBox></div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtStartDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                        AlternateText="Click here to display calendar" Style="margin-left: 60px; margin-left: 11px;
                        margin-top: 5px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtStartDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    End Date
                </div>
            </td>
            <td>
                <div class="text_box" style="margin-left: 39px; margin-top: 6px;">
                    <asp:TextBox ID="txtEndDate" Style="text-align: center; width: 100px; margin-left: -39px;"
                        runat="server" Font-Size="8pt"></asp:TextBox></div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                        PopupButtonID="ImageButton2" />
                    <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                        AlternateText="Click here to display calendar" Style="margin-left: 60px; margin-left: 11px;
                        margin-top: 5px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtEndDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        </asp:Panel>
    </table>
    <table>
        <tr>
            <td>
                <div class="raw_2">
                    <div class="raw_btn_new_2">
                        <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="Print Report" Style="width: 150px;
                            margin-left: 94px; height: 31px; margin-top: 56px;" />
                    </div>
                      <div class="raw_btn_new_2">
                    <asp:Button ID="Button1" CssClass="btn" runat="server" Text="GETLEDGERDATA" Visible ="false" 
                        Style="width: 150px; margin-left: 94px; height: 31px; margin-top: 56px;" />
                        <asp:TextBox ID="txtAccountCode" runat ="server"  Visible ="false" ></asp:TextBox>
                         <asp:Label ID="lblID" runat ="server"  Visible ="false" ></asp:Label>
                        
                                            
                </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>



