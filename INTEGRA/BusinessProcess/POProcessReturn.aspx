<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POProcessReturn.aspx.vb" Inherits="Integra.POProcessReturn" %>

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
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Process Return
            </th>
        </tr>
        <tr style="height: 30px;">
            <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Process No.
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:Label ID="LBLPONO" runat="server" Width="160" Visible="true" Text="" Style="margin-left: -154px;
                        margin-top: 5px;"></asp:Label>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -220px;">
                    SupplierName:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:Label ID="LBLSupplierName" runat="server" Width="160" Visible="true" Text=""
                        Style="margin-left: -82px; margin-top: 5px;"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    Item Name.
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:Label ID="LBLItemName" runat="server" Width="200" Visible="true" Text="" Style="margin-left: -154px;
                        margin-top: 0px;"></asp:Label>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -220px;">
                    Style:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:Label ID="LBLStyle" runat="server" Width="160" Visible="true" Text="" Style="margin-left: -82px;
                        margin-top: 5px;"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                    Pro QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="TXTPOqty" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="margin-left: -153px;"></asp:TextBox>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -219px;">
                    Pro Recv QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtPORecvQTY" CssClass="textbox" ReadOnly="true" Width="120" runat="server"
                        Style="margin-left: -87px;"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                    Returned QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtReturnedQTY" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="margin-left: -153px;"></asp:TextBox>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -219px;">
                    Godown :
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtlocation" CssClass="textbox" ReadOnly="true" Width="120" runat="server"
                        Style="margin-left: -87px;"></asp:TextBox>
                    <asp:Label ID="lbllocationid" runat="server" Text="0" Visible="false"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                    Return Date:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtReturnDate" CssClass="textbox" Width="120" runat="server" Style="text-transform: uppercase;
                        margin-left: -151px;"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReturnDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                    AlternateText="Click here to display calendar" Style="margin-left: -154px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtReturnDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -219px;">
                    Return QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtReturnQTY" CssClass="textbox" AutoPostBack="true" ReadOnly="false"
                        Width="120" runat="server" Style="margin-left: -87px;"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 150px;">
            </td>
            <td style="width: 150px;">
            </td>
            <td align="center" style="width: 150px; height: 30px;">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue" style="margin-left: 3px;">
                </telerik:RadButton>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
