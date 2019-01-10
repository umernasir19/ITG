<%@ Page Title="Monthly Production Report" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="MonthlyProductionReport.aspx.vb" Inherits="Integra.MonthlyProductionReport" %>
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
     <table>
      <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Monthly Production Report
            </th>
        </tr>
                
        <tr>


      </table><br />
      <table >
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" style=" margin-left: -13px;" Text="Select Year :"></asp:Label>
            </td>
            <td valign="top">
                <asp:DropDownList runat="server" ID="cmbYear" style="width:140px">
                    <asp:ListItem value="0">Select</asp:ListItem>
                    <asp:ListItem value="2014">2014</asp:ListItem>
                    <asp:ListItem value="2015">2015</asp:ListItem>
                    <asp:ListItem value="2016">2016</asp:ListItem>
                    <asp:ListItem value="2017">2017</asp:ListItem>
                    <asp:ListItem value="2018">2018</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td>
                <%--<asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>--%>
            </td>
            <td valign="top">
                <%--<telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar4" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput4" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>--%>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <td>
        </td>
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table><br /><br /><br />
</asp:Content>


