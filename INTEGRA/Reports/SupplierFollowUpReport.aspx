<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SupplierFollowUpReport.aspx.vb" Inherits="Integra.SupplierFollowUpReport" %>

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
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Supplier Followup Status
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="width: 110px;">
                Supplier :
            </td>
            <td>
                <telerik:RadComboBox ID="cmbSupplierr" DropDownAutoWidth="Enabled" runat="server"
                    Width="228" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
            </td>
            <td valign="top">
                <div style="margin-left: 72px;">
                    <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
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
            <td>
            </td>
            <td>
                <div style="margin-left: 16px;">
                    <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label></div>
            </td>
            <td valign="top">
                <div style="margin-left: 30px;">
                    <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
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
            <td>
                <asp:Label ID="lblID" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="height: 35px">
                Season :
            </td>
            <td valign="top" style="padding: 8px 5px;">
                <div style="margin-left: 56px;">
                    <asp:DropDownList runat="server" ID="cmbSeason" Style="width: 135px" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="height: 35px">
                <div style="margin-left: 16px;">
                    Sr No :</div>
            </td>
            <td valign="top" style="padding: 8px 5px;">
                <div style="margin-left: 26px;">
                    <telerik:RadComboBox ID="cmbSrNoo" runat="server" CheckBoxes="True" Width="135" Skin="WebBlue">
                    </telerik:RadComboBox>
                    &nbsp;
                    <asp:Label ID="lblSrNo" runat="server"></asp:Label></div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="height: 35px">
                Type :
            </td>
            <td>
                <div style="margin-left: 74px;">
                    <asp:DropDownList ID="CMBType" runat="server" AutoPostBack="false" Width="135PX">
                        <asp:ListItem Value="0" Text="Select" />
                        <asp:ListItem Value="1" Text="Late" />
                        <asp:ListItem Value="2" Text="On Time" />
                        <asp:ListItem Value="3" Text="Early" />
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
            </td>
            <td>
                <div style="margin-left: 121px;">
                    <telerik:RadButton ID="btnReport" runat="server" Text="Download Report" Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
            <td>
                <div style="margin-left: 119px;">
                    <telerik:RadButton ID="btnExcel" Visible ="false"  runat="server" Text="Download Excel" Skin="WebBlue">
                    </telerik:RadButton>
                </div>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
