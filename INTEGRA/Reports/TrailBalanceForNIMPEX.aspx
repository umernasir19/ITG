<%@ Page Title="Trail Balance Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="TrailBalanceForNIMPEX.aspx.vb" Inherits="Integra.TrailBalanceForNIMPEX" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="main_container" style ="width: 930px;">
        <div style="margin-left: 20px; margin-left: -2px;">
            <br />
            <div class="heading" style="width: 922px; margin-left: 2px; margin-top: -20px;">
                TRAIL BALANCE REPORT</div>
            <br />
            <div class="login-box-row">
<%--                <div class="txt" style="width: 150px; margin-top: 35px; margin-left: -6px; margin-top: 1px;">
                  <%--  FINANCIAL YEAR--%></div>
                 <asp:DropDownList ID="cmbSession" CssClass="combo" runat="server" Width="144px" Style="margin-left: 12px;" Visible ="false" >
                    <asp:ListItem Value="1">2012-13</asp:ListItem>
                    <asp:ListItem Value="2">2013-14</asp:ListItem>
                    <asp:ListItem Value="3">2014-15</asp:ListItem>
                    <asp:ListItem Value="4" Selected="True">2015-16</asp:ListItem>
                    <asp:ListItem Value="5">2016-17</asp:ListItem>
                    <asp:ListItem Value="6">2017-18</asp:ListItem>
                    <asp:ListItem Value="7">2018-19</asp:ListItem>
                    <asp:ListItem Value="8">2019-20</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="login-box-row">
                <div class="txt" style="width: 150px; margin-left: 0px;    margin-top: 5px;">
                    Start Date</div>
                <div class="text_box" style="margin-left: 11px; margin-top: 6px;">
                    <asp:TextBox ID="txtstartdate" CssClass="textbox" Width="120" runat="server" AutoPostBack="false"
                        Style="text-transform: uppercase;"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtstartdate"
                        PopupButtonID="ImageButton2" />
                    <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                        AlternateText="Click here to display calendar" Style="width: 22px; margin-top: -23px;
                        margin-left: 130px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtstartdate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </div>
            <div class="login-box-row">
                <div class="txt" style="width: 150px;     margin-top: 25px; margin-left: -207px;">
                    End Date
                </div>
                <div class="text_box" style="margin-left: -45px;    margin-top: 28px;">
                    <asp:TextBox ID="txtEndDate" CssClass="textbox" Width="120" runat="server" AutoPostBack="false"
                        Style="text-transform: uppercase;"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtEndDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                        AlternateText="Click here to display calendar" Style="width: 22px; margin-top: -23px;
                        margin-left: 130px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtEndDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
                <div class="raw_2">
                    <div class="raw_btn_new_2">
                        <asp:Button ID="btnReport" CssClass="btn" runat="server" Text="Print Report" Style="width: 145px;
                            margin-left: -45px; margin-top :65px; height: 31px; float: left" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
