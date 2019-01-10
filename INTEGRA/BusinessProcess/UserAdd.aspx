<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="UserAdd.aspx.vb" Inherits="Integra.UserAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                User Name:
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="169px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName"
                    CssClass="ErrorMsg" runat="server" ErrorMessage="Required!!!" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Designation:
            </td>
            <td>
                <asp:TextBox ID="txtDesignation" runat="server" CssClass="textbox" Width="169px"></asp:TextBox>&nbsp;
                <asp:RequiredFieldValidator ID="Rfvpo" ControlToValidate="txtDesignation" CssClass="ErrorMsg"
                    runat="server" ErrorMessage="Required!!!" Font-Bold="True"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Question:
            </td>
            <td>
                <asp:TextBox ID="txtQuestion" runat="server" CssClass="textbox" ReadOnly="True" Width="169px">What is Your Security Code?</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Answer:
            </td>
            <td>
                <asp:TextBox ID="txtAnswer" runat="server" CssClass="textbox" Width="169px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <font color="red">*</font>Login ID:
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtUMUserCodee" runat="server" Width="169px"></asp:TextBox>
                <%--  <asp:RequiredFieldValidator ID="rfvUserCode" runat="server" CssClass="ErrorMsg" ControlToValidate="txtUserCode"
                    ErrorMessage="Required!!!"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                <font color="red">*</font>Password:
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtUMPasswordd" runat="server" Width="169px"
                    TextMode="Password"></asp:TextBox>
                <%--  <asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="ErrorMsg" ControlToValidate="txtPassword"
                    ErrorMessage="Required!!!"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td>
                Department:
            </td>
            <td>
                <asp:DropDownList ID="cmbDepartment" runat="server" AutoPostBack="false" CssClass="combo"
                    Width="170px" Style="margin-left: 0px;">
                    <asp:ListItem Value="1" Text="Select"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Merchandising"></asp:ListItem>
                    <asp:ListItem Value="3" Text="Fabric Store"></asp:ListItem>
                    <asp:ListItem Value="4" Text="R.N.D"></asp:ListItem>
                    <asp:ListItem Value="5" Text="G.G.T"></asp:ListItem>
                    <asp:ListItem Value="6" Text="Production"></asp:ListItem>
                    <asp:ListItem Value="7" Text="Acc Store"></asp:ListItem>
                    <asp:ListItem Value="8" Text="Export"></asp:ListItem>
                    <asp:ListItem Value="9" Text="Accounts"></asp:ListItem>
                    <asp:ListItem Value="10" Text="Internal Auditor"></asp:ListItem>
                    <asp:ListItem Value="11" Text="Higher Management"></asp:ListItem>
                    <asp:ListItem Value="12" Text="General Store."></asp:ListItem>
                     <asp:ListItem Value="13" Text="Dead Store"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Is Active:
            </td>
            <td>
                <asp:CheckBox ID="chkIsActive" runat="server" Height="32px" Width="48px" TextAlign="Left"
                    TabIndex="2" Checked="true"></asp:CheckBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:TextBox ID="txtDivision" runat="server" Visible="false" ReadOnly="false" CssClass="textbox"
                    Width="169px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="cmdSubmit" runat="server" CssClass="button" Text="Save" TabIndex="3">
                </asp:Button>
                &nbsp;&nbsp;
                <asp:Button ID="cmdCancel" runat="server" CssClass="button" Text="Cancel" CausesValidation="False"
                    TabIndex="4"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
