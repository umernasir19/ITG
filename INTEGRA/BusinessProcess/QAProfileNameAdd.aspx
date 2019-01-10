<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="QAProfileNameAdd.aspx.vb" Inherits="Integra.QAProfileNameAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="40%">
        <tr>
            <td>
   QA Name
            </td>
            <td>
                <asp:TextBox ID="txtQAName" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>
   QA Group
            </td>
            <td>
                <asp:TextBox ID="txtQAGroup" CssClass="textbox" runat="server"></asp:TextBox>
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
