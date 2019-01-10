<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="StyleInspectionReport.aspx.vb" Inherits="Integra.StyleInspectionReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <%--'-------Heading Row--------'--%>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Inspection Report
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 34px">
            <td>
                PO. No
            </td>
            <td>
                <asp:TextBox ID="txtPONO" Style="margin-left: 0px; width: 209px;" runat="server"
                    AutoPostBack="true" autocomplete="off"></asp:TextBox>
                <asp:Label ID="lblpoid" runat="server" Text="0" Visible ="false"></asp:Label>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtPONO"
                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="INSPPO" />
            </td>
        </tr>
        <tr>
            <td>
                
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbPONo" runat="server" AutoPostBack="true" Width="192px" Visible ="false" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                Color
            </td>
            <td align="left">
                <asp:DropDownList ID="cmbColor" runat="server" AutoPostBack="true" Width="192px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStyleID" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnSreach" runat="server" Text="Inspection Form" CssClass="button"
                    Width="122px" />
                <asp:Button ID="btnFabric" runat="server" Text="Fabric-Packing Checklist" CssClass="button"
                    Width="180px" />
                <asp:Button ID="btnFabricIns" runat="server" Text="Fabric Inspection" CssClass="button"
                    Width="128px" Visible="true" />
                <asp:Button ID="btnPacking" runat="server" Text="Packing Checklist" CssClass="button"
                    Width="128px" Visible="false" />
            </td>
        </tr>
    </table>
</asp:Content>
