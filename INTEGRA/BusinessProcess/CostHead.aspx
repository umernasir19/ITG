<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CostHead.aspx.vb" Inherits="Integra.CostHead" %>

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
                    SR. #
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtJobOrder" Style="text-align: center; margin-left: 2px; height: 22PX;"
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
                    <asp:TextBox ID="txtShipDate" Style="text-align: center; margin-left: 2px; height: 22PX;"
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
                <%-- <div class="txt">
                     Style
                </div>--%>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtstyle" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <div class="txt">
                    Customer
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtBuyer" Style="text-align: center; margin-left: 2px;  height: 22PX;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                        Qty :  
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                 <asp:TextBox ID="txtQty" Style="text-align: center; margin-left: 2px;  height: 22PX;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt" ></asp:TextBox>
                  
                </div>
            </td>
            <td style="width: 110px;">
              <%--  <div class="txt">
              Item Desc.
                </div>--%>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                     <asp:TextBox ID="txtItem" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="174px" Font-Size="8pt" Visible ="false" ></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 30px;" class="heading">
            <td>
                Other Financial Charges
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>




          <asp:Panel ID="PnlOperationtype1" runat="server" Visible="true">
                    <td>
                        <div class="txt_newwww" style="width: 110px; margin-left: 0px; margin-top: 7px;">
                              Cost Head
                        </div>
                    </td>
                    <td>
                     <div class="text_box" style="width: 130px;">
                  <asp:DropDownList ID="cmbCostHead" Width="100px" Style="margin-left: 3px; margin-top: 5px;  height: 26PX;"
                        CssClass="combo" runat="server" AutoPostBack="false" Visible="true">
                    </asp:DropDownList>
                </div>
                    </td>
                    <td>
                        <asp:ImageButton ID="btnAddCostHead" runat="server" ImageUrl="~/Images/AddButton.jpg" Style=" margin-top: 6px; margin-left: -33px;
                            width: 19px;" />
                    </td>
                </asp:Panel>
                <asp:Panel ID="PnlOperationtype2" runat="server" Visible="false">
                    <td >
                        <div class="txt_newwww" style="width: 110px; margin-left:0px; margin-top: 7px;">
                                Cost Head
                        </div>
                    </td>
                    <td>
                        <div class="text_box" style=" width: 130px;">
                            <asp:TextBox ID="txtCostHead" runat="server" Width="100px" CssClass="textbox" Style=" margin-left: 3px; margin-top: 5px; height :22PX;"></asp:TextBox>
                        </div>
                        <asp:ImageButton ID="BtnSaveCostHead" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="margin-left:-20px; width: 19px;  margin-top: 6px;" />
                    </td>
                </asp:Panel>












      
            <td>
                <div class="text_box" style="width: 130px;">
                    
                </div>
            </td>
            <td style="width: 120px; height: 26px;     ">
                <div class="txt" style ="margin-left: -93px;">
                    Choose Fraction
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbChooseFraction" Width="100px" Style="margin-left: -96px; margin-top: 1px;  height: 26PX;"
                        CssClass="combo" runat="server" AutoPostBack="false" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td style="width: 120px; height: 26px;">
                <div class="txt">
                    Cost(to be)
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtCost" Style="text-align: center; margin-left: 2px;  height: 22PX;" runat="server"
                        onkeypress="return isNumericKeyy(event);" ReadOnly="false" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 120px; height: 40px;">
                <div class="txt">
                    Amount
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtAmount" Style="text-align: left; margin-left: 2px;  height: 22PX;" runat="server"
                        onkeypress="return isNumericKeyy(event);" ReadOnly="false" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
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
                <Smart:SmartDataGrid ID="dgCosthead" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
                    PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white" GridLines="None">
                    <Columns>
                        <asp:BoundColumn HeaderText="CostOtherHeadDtlID" DataField="CostOtherHeadDtlID" Visible="False">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="CostAHeadId" DataField="CostAHeadId" Visible="false">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Cost Head" DataField="CostAHead" Visible="true">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="CostFracId" DataField="CostFracId" Visible="false">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="CostFrac" DataField="CostFrac" Visible="true">
                            <HeaderStyle Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="@" DataField="Cost">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Amount" DataField="Amount" Visible="true">
                            <HeaderStyle Width="1%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            Visible="false">
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
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="lblCostOtherHeadMstID" runat="server" Text=" " Visible="false"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 110px; height: 29px;">
            </td>
            <td style="width: 145px; height: 29px;">
                <asp:Label ID="lblgross" runat="server" Text="0.00" Style="color: red;" Visible="false"></asp:Label>
                <asp:Label ID="lblheading" runat="server" Text="Total Cost Head:" Visible="false"></asp:Label>
            </td>
            <td style="width: 110px; height: 29px;">
                <asp:Label ID="lblAccessoriesTotalCost" runat="server" Text="0.00" Style="color: red;"
                    Visible="false"></asp:Label>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <asp:Label ID="lblCostAHeadMstID" runat="server" Text=" " Visible="false"></asp:Label>
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" Style="width: 117px;
                    margin-left: 54px;" Visible="false" /><asp:Label ID="lblFabricCostMstid" runat="server"
                        Text=" " Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
