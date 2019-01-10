<%@ Page Title="Group Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="GroupSummary.aspx.vb" Inherits="Integra.GroupSummary" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="100%">
        <tr>
            <td style="width: 150px; height: 20px;">
                <div class="txt_newwww" style="width: 140px;">
                    Group
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:DropDownList ID="CmbAccountCode" Width="360px" runat="server" AutoPostBack="false"
                        CssClass="combo">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
       <%-- <tr>
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
        </tr>--%>
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
                        <asp:Button ID="Button1" CssClass="btn" runat="server" Text="GETLEDGERDATA" Visible="false"
                            Style="width: 150px; margin-left: 94px; height: 31px; margin-top: 56px;" />
                        <asp:TextBox ID="txtAccountCode" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

