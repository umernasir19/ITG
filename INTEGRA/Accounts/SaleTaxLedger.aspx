﻿<%@ Page Title="Sale Tax Ledger" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SaleTaxLedger.aspx.vb" Inherits="Integra.SaleTaxLedger" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table width="100%">
        <tr>
            <td style="width: 150px; height: 20px;">
                <div class="txt_newwww" style="width: 140px;">
                   SALES TAX
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtSALESTAX" Width="150" Style="margin-left: 0px;" CssClass="combo"
                        AutoPostBack="true" runat="server" Text="SALES TAX" Enabled ="false" >
                    </asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    Start Date
                </div>
            </td>
            <td>
               <div style="margin-left: 16px;">
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
            </td>
        </tr>
        <tr>
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    End Date
                </div>
            </td>
            <td>
                <div style="margin-left: 16px;">
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
            </td>
        </tr>
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
                    
                </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


