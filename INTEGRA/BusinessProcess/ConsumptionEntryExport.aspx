<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="ConsumptionEntryExport.aspx.vb" Inherits="Integra.ConsumptionEntryExport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
        <tr style="height: 30px;" class="heading">
            <td>
                <b>Consumption Entry</b>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div class="txt" style="width: 130px; margin-top: -4px;">
                    Season</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtSeason" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox></div>
            </td>
            <td style="width: 150px;">
                <div class="txt" style="width: 130px; margin-left: 30px; margin-top: -3px;">
                    Customer</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtCustomer" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox></div>
            </td>
        </tr>
        <tr>
        </tr>
        <tr style="height: 34px;">
            <td>
                <div class="txt" style="width: 130px;">
                    Order No</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox CssClass="textbox" ID="txtOrderNo" Style="height: 20px;" runat="server"
                        ReadOnly="True"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="width: 130px; margin-left: 30px; margin-top: -3px;">
                    Fabric Recv Date</div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtFabricRecvDate" CssClass="textbox" Style="height: 20px;" runat="server"
                        ReadOnly="false"></asp:TextBox>
                </div>
                <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtFabricRecvDate"
                    PopupButtonID="ImageButton2" />
                <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                    AlternateText="Click here to display calendar" Style="margin-left: 34px; margin-top: 4px;
                    margin-bottom: -5px;" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFabricRecvDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                <div class="txt" style="width: 130px;">
                    Supplier</div>
            </td>
            <td>
                <asp:DropDownList ID="cmbSupplier" Width="160px" CssClass="combo" runat="server"
                    AutoPostBack="false" Height="26px" Visible="true">
                </asp:DropDownList>
            </td>
        </tr>
        <table>
            <br />
            <table width="100%">
                <tr>
                    <td>
                        <div style="width: 930px;">
                            <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000"
                                ShowFooter="True" ForeColor="white" GridLines="both">
                                <PagerStyle Mode="NumericPages" CssClass="GridPagerStyle" HorizontalAlign="Right"
                                    Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                                <ItemStyle CssClass="GridRow"></ItemStyle>
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center"></HeaderStyle>
                                <Columns>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ConDtlID"
                                        DataField="ConDtlID" Visible="false" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JoborderDetailID"
                                        DataField="JoborderDetailID" Visible="false" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Sr No"
                                        DataField="SrNo" Visible="true" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Style"
                                        DataField="Style" Visible="true" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Color"
                                        DataField="Color" Visible="true" />
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Quantity"
                                        DataField="Quantity">
                                        <HeaderStyle Width="5%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Est Con">
                                        <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtEstCon" runat="server" Width="60" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Order Con">
                                        <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrderCon" runat="server" Width="60" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Act Con">
                                        <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtActCon" runat="server" Width="60" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Fabric Req Qty">
                                        <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFabricReqQty" runat="server" Width="40" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Shipped Qty"
                                        DataField="ShippedQty" Visible="false">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Balance Qty" Visible="false">
                                        <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtBalanceQty" runat="server" Width="40" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Stitch Factories"
                                        DataField="StitchFactories">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Stitch Date"
                                        DataField="StitchDate">
                                        <HeaderStyle Width="10%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Inspection Date">
                                        <ItemTemplate>
                                            <div class="icon" align="center">
                                                <asp:TextBox ID="txtInspectionDate" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtInspectionDate"
                                                    PopupButtonID="ImageButton4" />
                                                <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                                                    AlternateText="Click here to display calendar" Style="margin-left: 0px; margin-top: -1px;
                                                    margin-bottom: -5px;" />
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtInspectionDate"
                                                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                                </cc1:MaskedEditExtender>
                                            </div>
                                        </ItemTemplate>
                                        <HeaderStyle Width="20%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Packing" Visible="false">
                                        <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPacking" runat="server" Width="40" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Length" Visible="false">
                                        <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtLength" runat="server" Width="40" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Width" Visible="false">
                                        <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtWidth" runat="server" Width="40" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Height" Visible="false">
                                        <ItemStyle Width="4%" HorizontalAlign="Left"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtHeight" runat="server" Width="40" CssClass="textbox" AutoPostBack="false"
                                                Style="text-transform: uppercase;" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="4%" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:TemplateColumn>
                                </Columns>
                            </Smart:SmartDataGrid>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" Style="margin-left: 0px;" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="margin-left: 0px;" />
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblConMstID" runat="server" Text="0" Visible="false"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblUserID" runat="server" Text="0" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
</asp:Content>
