<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CostControlac.aspx.vb" Inherits="Integra.CostControlac" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        function mathRoundForTaxes(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (!isNaN(txt) && isFinite(txt) && txt.length != 0) {
                var rounded = Math.round(txt * 100) / 100;
                txtBox.value = rounded.toFixed(2);
            }
        }

        function NotZero(source) {
            var txtBox = document.getElementById(source);
            var txt = txtBox.value;
            if (txt == 0) {
                txtBox.value = 1;
            }
        }  
    </script>
    <table width="100%">
        <tr style="height: 30px;" class="heading">
            <td>
                Cost Control System
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    Sr.#
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtJobOrder" Style="text-align: center; margin-left: 2px; height: 22px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                    Ship Date
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtShipDate" Style="text-align: center; margin-left: 2px; height: 22px;" runat="server"
                        ReadOnly="true" Width="109px" Font-Size="8pt"></asp:TextBox>
                </div>
                <%--   <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtRecvDate"
                    PopupButtonID="ImageButton2" />
                    <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" Style="margin-left: -47px;"  Visible="false"
                        ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtRecvDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>--%>
            </td>
            <%--  <td style="width: 110px;">
                <div class="txt">
                    Style
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtstyle" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>--%>
            <td style="width: 110px;">
                <div class="txt">
                    Customer
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtBuyer" Style="text-align: center; margin-left: 2px; height: 22px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <div class="txt">
                    Total Qty :
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtQty" Style="text-align: center; margin-left: 2px; height: 22px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <%--   <div class="txt">
                 Item Desc.
                </div>--%>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtItem" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="174px" Font-Size="8pt" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 30px;" class="heading">
            <td>
                Accessories Details
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="height: 13px; width: 15px;">
                <asp:LinkButton ID="LinkAccessoriesePopup" runat="server" Visible="false">If Accessoriese not found Click here to create</asp:LinkButton>
                <asp:ImageButton ID="btnShow" runat="server" BackColor="transparent" ToolTip="Click here to show data."
                    ImageUrl="~/Images/redCal.jpg" Visible ="false"  />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div class="txt">
                    Style
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbStyle" Width="140px" CssClass="combo" runat="server" AutoPostBack="true" height="26px"
                        Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <div class="txt">
                    Color
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 3px; margin-top: -3px;">
                    <asp:DropDownList ID="cmbColor" Width="118px" CssClass="combo" runat="server" AutoPostBack="true" Height ="26px"
                        Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <div class="txt">
                    Qty Color Wise
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtQtyColorWise" Style="text-align: center; margin-left: 7px; height: 22px;" runat="server"
                        ReadOnly="true" Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 26px;">
                <div class="txt" style="margin-top: 5px;">
                    Accessories type
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbAccessoriesType" Style="margin-left: 0px; margin-top: 2px; height: 26px;
                        margin-top: 2px;" CssClass="combo" runat="server" AutoPostBack="true" Visible="true"  >
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="width: 111px; margin-left: 0px; margin-top: 5px;">
                    Accessories
                </div>
            </td>
            <td style="width: 144px;">
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtAccessories" Style="text-align: left; margin-left: 8px;" runat="server"
                        AutoPostBack="true" ReadOnly="false" Width="120px" Font-Size="8pt" Visible="false"></asp:TextBox>
                    <asp:DropDownList ID="cmbitem" runat="server" Width="120px" AutoPostBack="true" Style="margin-top: 0PX; height: 26px;
                        margin-left: 3PX;" CssClass="combo">
                    </asp:DropDownList>
                    <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtAccessories"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="IMSItemClass" />
                    <asp:LinkButton ID="btnAccPOPUP" runat="server" Visible="false" Style="margin-left: 10px;"  >Click here to create</asp:LinkButton>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                    Consumption
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtxconsumption" Style="text-align: center; margin-left: 8px; height: 22px;" runat="server"
                        AutoPostBack="false" ReadOnly="false" Width="100px" Font-Size="8pt" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                </div>
                <div class="text_box" style="width: 50px;">
                    <asp:DropDownList ID="cmbUnit" CssClass="combo" runat="server" AutoPostBack="false"
                        Style="width: 42px; margin-left: -14px; margin-top: 1px; height: 26px;" Visible="true"
                        Enabled="true">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 40px;">
                <div class="txt">
                    Rate
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtUnitCost" Style="text-align: center; margin-left: 2px; height: 22px;" runat="server"
                        onkeypress="return isNumericKeyy(event);" ReadOnly="false" Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <asp:Label ID="AccessoriesId" runat="server" Text=" " Visible="false"></asp:Label>
                <asp:Label ID="lblAccessoriesCostMstid" runat="server" Text=" " Visible="false"></asp:Label>
            </td>
            <td>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                    Process Loss/Ex.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtExtra" Style="text-align: center; margin-left: 8px; height: 22px;" runat="server"
                        onkeypress="return isNumericKeyy(event);" AutoPostBack="false" ReadOnly="false"
                        Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="text_box" style="width: 38px; margin-left: -13px; margin-top: -3px;">
                    <asp:DropDownList ID="DropDownList1" Width="42px" CssClass="combo" runat="server"
                        AutoPostBack="false" Style="height: 26px;" Visible="true" Enabled="false">
                        <asp:ListItem Value="0">%</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 44px;">
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 328px;">
            </td>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add " Style="width: 117px;
                    margin-left: -93px;" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgAccessoriesCost" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
                    PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn HeaderText="AccessoriesCostDtlID" DataField="AccessoriesCostDtlID"
                            Visible="False">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="StyleId" DataField="StyleId" Visible="false">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Style" DataField="Style">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="AccessoriesId" DataField="AccessoriesId" Visible="False">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Accessories Type" DataField="AccessoriesType" Visible="true">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Accessories" DataField="AccessoriesName" Visible="true">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Consumption" DataField="Consumption">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cons. Unit" DataField="Symbol" Visible="true">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Unitid" DataField="ItemUnitid" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Rate" DataField="UnitCost">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Extra" DataField="Extra" Visible="true">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="O.Quantity" DataField="ConQuantity">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Gross Qty" DataField="Gross">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Gross Cost" DataField="GrossCost">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cost Per Unit" DataField="CostPerUnit">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Color" DataField="Color">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Color Wise Quantity" DataField="QtyColorWise">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Accessories Type Id" DataField="AccessoriesTypeId">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                    CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <%--<td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>--%>
            <td style="width: 120px; height: 40px;">
                <div class="txt">
                    Miscellaneous
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtMisc" Style="text-align: center; margin-left: -31px; height: 22px;" runat="server"
                        ReadOnly="false" Width="155px" Text="N/A" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 120px; height: 40px;">
                <div class="txt">
                    Rate
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtRatee" Style="text-align: center; margin-left: -32px; height: 22px;" runat="server"
                        onkeypress="return isNumericKeyy(event);" AutoPostBack="true" Text="0" ReadOnly="false"
                        Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 145px; height: 29px;">
                <asp:Label ID="lblgross" runat="server" Text="0.00" Style="color: red;" Visible="false"></asp:Label>
                <asp:Label ID="lblheading" runat="server" Text="Total Accessories Cost:" Visible="false"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="lblAccessoriesTotalCost" runat="server" Text="0.00" Style="color: red;"
                    Visible="false"></asp:Label>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" Style="width: 117px;
                    margin-left: -93px;" Visible="false" /><asp:Label ID="lblFabricCostMstid" runat="server"
                        Text=" " Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
