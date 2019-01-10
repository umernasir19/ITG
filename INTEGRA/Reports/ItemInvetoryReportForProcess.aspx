<%@ Page Title="Process Item Invetory Report" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master" CodeBehind="ItemInvetoryReportForProcess.aspx.vb"
    Inherits="Integra.ItemInvetoryReportForProcess" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Item Inventory Report
            </th>
        </tr>
    </table>
    <table>
        <tr style="height: 34px;">
            <td style="width: 110px;">
                Item Category
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox CssClass="textbox" ID="txtFabricCode" AutoPostBack="true" Style="margin-left: 0px;"
                    runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender9" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="ItemCategoryForItemInventoryReportForProcess"
                    EnableCaching="true" MinimumPrefixLength="1" ServiceMethod="GetCompletionList"
                    ServicePath="~/AutoComplete.asmx" TargetControlID="txtFabricCode" />
                <td style="width: 110px;">
                    Location.
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadComboBox ID="cmbGodown" runat="server" DropDownAutoWidth="Enabled" AutoPostBack="false" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div style="margin-left: 22px;">
                    <asp:Label ID="lblTo" runat="server" Text="As On:"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 50px;">
                    <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                        <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                            runat="server">
                        </Calendar>
                        <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%" runat="server">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </div>
            </td>
            <td>
                <div style="margin-left: 128px;">
                    <asp:Label ID="Label21" runat="server" Text="Without Zero Qty" Font-Bold="True" ForeColor="#336699"></asp:Label></div>
            </td>
            <td>
                <asp:CheckBox ID="ckhWithoutZeroQty" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <td>
            </td>
            <td>
                <div style="margin-left: 406px;">
                    <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblID" runat="server" Visible="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
