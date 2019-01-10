<%@ Page Title="Fabric Planning" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FPlanEntryNew2.aspx.vb" Inherits="Integra.FPlanEntryNew2" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
        <tr style="height: 30p; background-color: burlywood" class="heading">
            <td>
                Fabric Checklist System
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    SR No
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtJobOrder" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                    Ship Date
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtShipDate" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="true" Width="109px" Font-Size="8pt"></asp:TextBox>
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
            <td style="width: 110px;">
                <div class="txt">
                    Customer
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtBuyer" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <div class="txt">
                    Qty (Pcs.):
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtQty" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 30px; background-color: burlywood" class="heading">
            <td>
                Fabric Checklist Details
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="height: 13px; width: 15px;" colspan="3">
                <asp:LinkButton ID="LinkFabricPopup" runat="server" Visible="false">If Fabric not found Click here to create</asp:LinkButton>
                <asp:ImageButton ID="btnShow" runat="server" BackColor="transparent" ToolTip="Click here to show data."
                    ImageUrl="~/Images/redCal.jpg" Visible="false" />
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 35px">
            <td style="width: 110px;">
                <div class="txt">
                    Color
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbColor" Width="130px" CssClass="combo" runat="server" Style="margin-left: 2px;
                        margin-top: -3px;" AutoPostBack="true" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 70px;">
                    Item Desc.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtItem" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="true" Width="174px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="width: 110px; margin-left: 110px;">
                    Style
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtstyle" Style="text-align: center; margin-left: 3px; height: 22px;
                        margin-top: -2px;" runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                    <asp:Label ID="lblrndid" runat="server" Text="0" Visible="false"></asp:Label>
                </div>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td style="width: 110px;">
                <div class="txt">
                    Qty Color Wise
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtQtyPerPiece" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td style="width: 110px;">
                <div class="txt" style="width: 110px; margin-left: 0px;">
                    Placement
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbFabrictype" Width="128px" Style="margin-left: 3px; margin-top: 0px;"
                        CssClass="combo" runat="server" AutoPostBack="false" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 120px; height: 26px;">
                <div class="txt" style="margin-left: 69px;">
                    Fabric
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbFabric" Width="100px" Style="margin-left: 0px; margin-top: 0px;"
                        CssClass="combo" runat="server" AutoPostBack="true" Visible="FALSE">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtfabric" runat="server" AutoPostBack="true" autocomplete="off"
                        Style="width: 130px; margin-left: 2px; height: 23px;" ToolTip="Fabric"> </asp:TextBox>
                    <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtfabric"
                        ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                        CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="FabricPlanning" />
                    <asp:Label ID="lblFabricItemId" runat="server" Text="0" Visible="false"></asp:Label>
                </div>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    Width
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtWidth" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" ReadOnly="FALSE" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 120px; height: 40px;">
                <div class="txt" style="margin-left: 70px;">
                    Composition
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtComposition" Style="text-align: center; height: 22px; margin-left: 2px;"
                        runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <%-- <div class="txt" style="width: 110px; margin-left: 110px;">
                </div>--%>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtxFabricCons" Style="text-align: center; margin-left: 8px; height: 22px;"
                        runat="server" ReadOnly="true" Width="100px" Font-Size="8pt" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    Consumption
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtxconsumption" CssClass="combo" Style="text-align: center; margin-left: 8px;
                    height: 22px; margin-top: 21px;" runat="server" AutoPostBack="true" ReadOnly="false"
                    Width="100px" Font-Size="8pt" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                <div class="text_box" style="width: 50px;">
                    <asp:DropDownList ID="cmbUnit" CssClass="combo" runat="server" AutoPostBack="false"
                        Style="width: 45px; margin-left: 112px; margin-top: -26px; height: 26px;" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 70px;">
                    Process Loss/Ex.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtExtra" Style="text-align: center; margin-left: 2px; height: 22px;"
                        runat="server" onkeypress="return isNumericKeyy(event);" AutoPostBack="true"
                        ReadOnly="false" Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="text_box" style="width: 38px; margin-left: 107px; margin-top: -25px;">
                    <asp:DropDownList ID="DropDownList1" Width="38px" CssClass="combo" runat="server"
                        AutoPostBack="false" Style="height: 26px;" Visible="true" Enabled="false">
                        <asp:ListItem Value="0">%</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="Label1" runat="server" Text="Total Fabric Req." Width="127px"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="Label2" runat="server" Text="Net :" Style="color: red;"></asp:Label>
                <asp:Label ID="lblFabricReq" runat="server" Text="0.00" Style="color: red;"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="Label3" runat="server" Text="Gross :" Style="color: red;"></asp:Label>
                <asp:Label ID="lblgross" runat="server" Text="0.00" Style="color: red;"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style="width: 120px;">
                <div class="txt">
                    Source
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbsupplier" Width="100px" CssClass="combo" runat="server"
                        Style="margin-left: 2px; margin-top: -3px;" AutoPostBack="false" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="width: 130px; margin-left: 3px;">
                    Fabric Cost (Rs)
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: -12px">
                    <asp:TextBox ID="txtFabricCost" Style="text-align: center; margin-left: 19px; height: 22px;"
                        runat="server" AutoPostBack="true" onkeypress="return isNumericKeyy(event);"
                        ReadOnly="false" Width="66px" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="text_box" style="width: 38px; margin-left: 78px; margin-top: -25px;">
                    <asp:DropDownList ID="cmbUnit2" Width="45px" CssClass="combo" runat="server" AutoPostBack="false"
                        Visible="true" Enabled="false">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 21px;">
                    USD Ex-Rate
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtExchangeRate" Style="text-align: center; margin-left: 8px; height: 22px;"
                        runat="server" AutoPostBack="true" onkeypress="return isNumericKeyy(event);"
                        ReadOnly="false" Width="100px" Font-Size="8pt"></asp:TextBox>
                    <asp:DropDownList ID="cmbCurrencys" Width="61px" CssClass="combo" runat="server"
                        AutoPostBack="false" Visible="true" Style="    margin-left: 109px;   MARGIN-TOP: -27PX; HEIGHT: 26PX;">
             
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="Label4" runat="server" Text="Total Project Amount" Width="127px"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="Label5" runat="server" Text="Rs." Style="color: red; margin-left: 7PX;"></asp:Label>
                <asp:Label ID="lblAmount" runat="server" Text="0.00" Style="color: red;"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="Label7" runat="server" Text="USD" Style="color: red; margin-left: 21PX;"></asp:Label>
                <asp:Label ID="lblusd" runat="server" Text="0.00" Style="color: red;"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 44px;">
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
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
                <Smart:SmartDataGrid ID="dgFabricCost" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
                    PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn HeaderText="FPlanDtlNewID" DataField="FPlanDtlNewID" Visible="False">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="FabricdataBaseId" DataField="FabricdataBaseId" Visible="False">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Fabric" DataField="FabricWeave">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="FabricTypeId" DataField="FabricTypeId" Visible="False">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Fabric Type" DataField="FabricType">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Fabric Cons." DataField="Construction" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Width" DataField="Width">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Comp." DataField="Composition">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cons" DataField="Consumption">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Fab/Req" DataField="FabricReq">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ex.%" DataField="Extra">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Gross" DataField="Gross">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="SupplierId" DataField="IMSSupplierId" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Source" DataField="IMSSupplierName">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Fabric Cost" DataField="FabricCost">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Amount" DataField="Amount">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Ex-Rate" DataField="ExchangeRate">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                           <asp:BoundColumn HeaderText="CurrencyId" DataField="CurrencyId" Visible="false">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                         <asp:BoundColumn HeaderText="Currency" DataField="Currency" Visible="true">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="USD" DataField="USD" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Color" DataField="Color">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Item" DataField="Item">
                            <HeaderStyle HorizontalAlign="Center" Width="4%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Style" DataField="Style">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="P/Cl.Qty" DataField="QtyColorWise">
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="JobOrderDetailId" DataField="JobOrderDetailId" Visible="false">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                      
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="RM"
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
        <tr style="height: 44px;">
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
                <asp:Label ID="lblcreationDate" runat="server" Visible="false"></asp:Label>
            </td>
            <td style="width: 110px;">
            </td>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" Style="width: 117px;
                    margin-left: -93px;" Visible="false" />
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" Style="width: 117px;
                    margin-left: 5px;" Visible="true" />
                <asp:Label ID="lblFabricCostMstid" runat="server" Text=" " Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
