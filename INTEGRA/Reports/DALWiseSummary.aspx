<%@ Page Title="DAL Wise Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DALWiseSummary.aspx.vb" Inherits="Integra.DALWiseSummary" %>
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
    <table width="100%">
        <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblDal" runat="server" Text="DAL"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtDal" runat="server" Skin="WebBlue" Width="105px" Visible="false">
                </telerik:RadTextBox>
                <telerik:RadComboBox ID="cmbDal" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblStyle" runat="server" Text="Style"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtStyle" runat="server" Skin="WebBlue" Width="105px" Visible="false">
                </telerik:RadTextBox>
                <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="Left">
                <telerik:RadButton ID="btnReport" runat="server" Text="Report" Skin="WebBlue" width="65px">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>

