﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PaymentTermsEntry.aspx.vb" Inherits="Integra.PaymentTermsEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table width="40%">
        <tr>
            <td>
    Payment Term Name
            </td>
            <td>
                <asp:TextBox ID="txtPaymentTermName" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
