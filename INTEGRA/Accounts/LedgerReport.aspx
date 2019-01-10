<%@ Page Title="Ledger Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="LedgerReport.aspx.vb" Inherits="Integra.LedgerReport" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="main_container">
        <div style="margin-left: 20px; margin-left: -2px;">
            <br />
            <div class="heading" style="width: 898px">
                LEDGER PRINT</div>
            <br />
            <div class="heading" style="width: 898px">
                <div class="txt" style="width: 150px;margin-top: 35px; margin-left: -6px;">  Account Code</div>
              
                   
                     <%-- <div class="text_box" style="margin-left: 10px; margin-top: 35px;">
                    <asp:UpdatePanel id="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                        <contenttemplate>
</contenttemplate>
                        <triggers>
<asp:AsyncPostBackTrigger ControlID="txtAccountName" EventName="TextChanged"></asp:AsyncPostBackTrigger>
 
</triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="text_box" style="margin-left: 190px; margin-top: 35px;">
                    <asp:UpdatePanel ID="udpGrid" runat="server">
                        <contenttemplate>
                <asp:TextBox ID="txtAccountCode"  Enabled="false" CssClass="textbox" Width="100" runat="server"></asp:TextBox>
                    </contenttemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="text_box" style="margin-left: 30px; margin-top: 35px;">
                    <asp:UpdatePanel ID="udpGrid1" runat="server">
                        <contenttemplate>
                <asp:TextBox ID="txtAccountLevel"  Enabled="false" CssClass="textbox" Width="130" runat="server"></asp:TextBox>
                    </contenttemplate>
                    </asp:UpdatePanel>
                </div>--%>
                <div class="text_box" style="margin-left: 30px; margin-top: 35px;">
                <asp:DropDownList ID="CmbAccountCode" Width="360px" Visible ="false" runat="server" AutoPostBack="false"
                        CssClass="combo">
                    </asp:DropDownList>
                     <asp:TextBox ID="txtAccountName" CssClass="textbox" runat="server" AutoPostBack="true"
                        autocomplete="off" Width="260px"> </asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccountName"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="AccountNameCode" />
                    <asp:Label ID ="lblAccountCode" runat ="server"  Visible ="true" ></asp:Label>
                </div> 
            </div>
            <div class="raw_2" style="">
                <div class="txt" style="width: 150px; margin-top: 40px; margin-left: -227px;">
                    Start Date :</div>
                <div class="text_box" style="margin-left: -45px; margin-top: 35px;">
                    <telerik:RadDatePicker ID="txtStartDate" runat="server" Culture="en-US">
                        <Calendar ID="Calendar3" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput3" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </div>
            <div class="raw_2" style="margin-top: -25px;">
                <div class="txt" style="width: 150px; margin-top: 75px; margin-left: -227px;">
                    End Date :</div>
                <div class="text_box" style="margin-left: -45px; margin-top: 75px;">
                    <telerik:RadDatePicker ID="txtEndDate" runat="server" Culture="en-US">
                        <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </div>
            <div class="login-box-row">
                <%--<div class="txt" style="width: 150px;margin-top: 79px;margin-left: -227px;">
                    FINANCIAL YEAR</div>--%>
                <div class="text_box" style="margin-left: -102px;margin-top: 79px;">
                    <asp:DropDownList ID="cmbSession" runat="server" Width="144px" Visible ="false"   CssClass="combo" Style="margin-left: 56px;height: 25px;">
                        <asp:ListItem Value="1">2012-13</asp:ListItem>
                        <asp:ListItem Value="2">2013-14</asp:ListItem>
                        <asp:ListItem Value="3">2014-15</asp:ListItem>
                        <asp:ListItem Value="4">2015-16</asp:ListItem>
                        <asp:ListItem Value="5">2016-17</asp:ListItem>
                        <asp:ListItem Value="6">2017-18</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="raw_2">
                <div class="raw_btn_new_2">
                    <asp:ImageButton ID="lnkprint"  style="border-width:0px;margin-left: 159px; margin-top: 150px;" ToolTip="Click here to Print." ImageUrl="~/Images/printer_icon.png"
                        runat="server"></asp:ImageButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

