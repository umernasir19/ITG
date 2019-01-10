<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="POIssueReturn.aspx.vb" Inherits="Integra.POIssueReturn" %>

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
        <tr style="border-bottom-style: solid; height: 34px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                PO Issue Return
            </th>
        </tr>
        <tr style="height: 30px;">
            <td style="height: 35px">
                <div class="txt" style="width: 125px;">
                    PO No.
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
                  Item Code
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                   <asp:Label ID="lblItemCodee" runat="server" Width="160" Visible="true" Text="" Style="margin-left: -82px;
                        margin-top: 5px;"></asp:Label>
                    <asp:Label ID="LBLSupplierName" runat="server" Width="160" Visible="false" Text=""
                        Style="margin-left: -82px; margin-top: 5px;"></asp:Label>
                    <asp:Label ID="LBLStyle" runat="server" Width="160" Visible="false" Text="" Style="margin-left: -82px;
                        margin-top: 5px;"></asp:Label>
                        

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
                    <asp:Label ID="LBLItemName" runat="server" Width="200px" Visible="true" Text="" Style="margin-left: -154px;
                        margin-top: 5px;"></asp:Label>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -220px;">
                    Department:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:Label ID="lblDpt" runat="server" Width="240px" Visible="true" Text="" Style="margin-left: -82px;
                        margin-top: 5px;"></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                    Godown :
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtlocation" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="margin-left: -153px; height: 21px;"></asp:TextBox>
                    <asp:Label ID="lblLocationid" runat="server" Text="0"></asp:Label>
                </div>
            </td>
           <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: -220px;">
                   Challan No :
                </div>   
            </td>
            <td>
          <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:Label ID="lblManualChallanNo" runat="server" Width="240px" Visible="true" Text="" Style="margin-left: -82px;
                        margin-top: 5px;"></asp:Label>
                </div></td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                    PO Issue QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtPOIssueQTY" CssClass="textbox" Width="120" ReadOnly="true" runat="server"
                        Style="margin-left: -153px; height: 21px;"></asp:TextBox>
                </div>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 150px; margin-left: -219px;">
                    Issue Returned QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtIssueReturnedQTY" CssClass="textbox" ReadOnly="true" Width="120"
                        runat="server" Style="margin-left: -72px; height: 21px;"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 35px">
                <div class="txt" style="width: 125px; margin-left: 0px;">
                    Issue Return Date:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtReturnDate" CssClass="textbox" Width="120" runat="server" Style="text-transform: uppercase;
                        margin-left: -153px; height: 21px;"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReturnDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                    AlternateText="Click here to display calendar" Style="margin-left: -160px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtReturnDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td style="height: 35px">
                <div class="txt" style="width: 150px; margin-left: -219px;">
                    Return QTY:
                </div>
            </td>
            <td style="height: 35px">
                <div class="text_box" style="width: 130px; margin-left: 10px;">
                    <asp:TextBox ID="txtReturnQTY" CssClass="textbox" AutoPostBack="true" ReadOnly="false"
                        Width="120" runat="server" Style="margin-left: -72px; height: 21px;"></asp:TextBox>
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
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
                <asp:Label ID="lblPoRecvid" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="lblPoRecvDtlid" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="lblPoId" runat="server" Text="0" Visible="false"></asp:Label>
                <asp:Label ID="lblImsItemId" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
