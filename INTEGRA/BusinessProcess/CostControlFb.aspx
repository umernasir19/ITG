<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CostControlFb.aspx.vb" Inherits="Integra.CostControlFb" %>

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
        <tr style="height: 30p;" class="heading">
            <td>
                Cost Control System
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
      <tr>
            <td style="width: 110px;">
                <div class="txt" style=" margin-top: -11px;">
                   Season
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                  <asp:TextBox ID="txtSeason" Style="text-align: center; margin-left: 0px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
           
        </tr>


        <tr>
            <td style="width: 110px;">
                <div class="txt">
                   Sr No
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtJobOrder" Style="text-align: center; margin-left: 2px;" runat="server"
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
                    <asp:TextBox ID="txtShipDate" Style="text-align: center; margin-left: 2px;" runat="server"
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
            <td style="width: 110px;">
                <div class="txt">
                    Customer
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtBuyer" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
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
                    <asp:TextBox ID="txtQty" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 30p;" class="heading">
            <td>
                Fabric Details
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td style="height: 13px; width: 15px;" colspan="3">
                <asp:LinkButton ID="LinkFabricPopup" runat="server" Visible="false">If Fabric not found Click here to create</asp:LinkButton>
                <asp:ImageButton ID="btnShow" runat="server" BackColor="transparent" ToolTip="Click here to show data."
                    ImageUrl="~/Images/redCal.jpg" Visible="false"/>
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
        </table><table>
        <tr>
         <asp:Panel ID="PnlBrand1" runat="server" Visible="true">
                <td>
                       <div class="txt">
                         Placement
                    </div>
                </td>
                <td>
                    <div>
                        <asp:DropDownList ID="cmbFabrictype"   Width="130px" CssClass="combo" AutoPostBack="false"
                            runat="server" Style="margin-left: -2px; margin-left: 2px;">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <asp:ImageButton ID="BtnAddFabrictype" AutoPostBack ="true" runat="server" ImageUrl="~/Images/AddButton.jpg"
                        Style="margin-left: 5px; width: 19px;" />
                </td>
                <td>
                </td>
            </asp:Panel>
            <asp:Panel ID="PnlBrand2" runat="server" Visible="false">
                <td>
                       <div class="txt">
                        Placement
                    </div>
                </td>
                <td>
                     <div class="text_box" style="width: 130px;">
                        <asp:TextBox ID="txtFabrictypeSave" runat="server" AutoPostBack="true"  Width="130px" CssClass="textbox" Style="margin-right: -164px;
                            margin-left: 2px;"></asp:TextBox>
                    </div>
                </td>
                <td>
                    <asp:ImageButton ID="BtnFabrictypeSave" AutoPostBack ="true" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                        Style="margin-left: 5px; width: 19px;" />
                </td>
                <td>
                </td>
            </asp:Panel>

        </tr>
         </table><table>
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
                    <asp:TextBox ID="txtItem" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="174px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="width: 110px; margin-left: 110px;">
                    Style
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtstyle" Style="text-align: center; margin-left: 3px; margin-top: -2px;"
                        runat="server" ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
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
                    <asp:TextBox ID="txtQtyPerPiece" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            
            <td style="width: 110px;">
                <div class="txt" style="width: 110px; margin-left: 69px;">
                    Fabric
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:DropDownList ID="cmbFabric" Width="100px" Style="margin-left: 3px; margin-top: -2px;"
                        CssClass="combo" runat="server" Enabled ="false"  AutoPostBack="true" Visible="true">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        </table>
        <table>
        <tr>
          <td style="width: 110px;">
                <div class="txt">
                    Item Code
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtItemCode" Style="text-align: center; margin-left: -6px;" runat="server"
                        ReadOnly="false" Width="130px" Font-Size="8pt" AutoPostBack ="true" ></asp:TextBox>
                         <cc1:AutoCompleteExtender ID="AutoCompleteExtender56" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="ItemFromJobOrder" EnableCaching="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                                    TargetControlID="txtItemCode" />
                                     <asp:Label ID="lblItemID" runat="server" Width="10" Text ="0" Visible ="false"   ></asp:Label>
                </div>
            </td>
        </tr>
         <tr style="height: 34px;">
          
            <td style="width: 120px; height: 26px;">
                <div class="txt" style="margin-left: 0px;">
                    Fabric Quality
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                      <asp:TextBox ID="txtFABRICQUALITY" Style="text-align: center; margin-left: -5px;" runat="server"
                        ReadOnly="true" Width="200px" Font-Size="8pt" TextMode ="MultiLine" ></asp:TextBox>
                </div>
            </td>
        
     
            <td style="width: 110px;">
                <div class="txt" style="width: 110px; margin-left: 72px;" runat="server" visible ="false" >
                   Fabric Q Buyer
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                        <asp:TextBox ID="txtFABRICQUALITYBUYER" Visible ="false"  Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="200px" Font-Size="8pt" TextMode ="MultiLine"></asp:TextBox>
                </div>
            </td>
        </tr>
        </table>
        
        <table>
        <tr>
            <td style="width: 110px;">
                <div class="txt" style=" margin-top: 34px;">
                    Fabric Cons.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtxFabricCons" Style="text-align: center; margin-left: 2px; margin-top: 20px;" runat="server"
                        ReadOnly="false"  Width="420px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
           
          
        </tr>

        <tr>
         <td style="width: 110px; ">
                <div class="txt" style ="margin-top: 3px;">
                    Composition.
                </div>
            </td>
            <td>
             <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtComposition" Style="text-align: center; margin-left: 2px; " runat="server"
                        ReadOnly="false" Width="420px" Font-Size="8pt"></asp:TextBox> </div></td>
               
        </tr>

         </table><table>
        <tr>
        <td style="width: 110px;">
                <div class="txt" style ="margin-top: 3px;">
                     Width.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtWidth" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="false"  Width="120px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>

        <tr>
            <td style="width: 110px;  ">
                <div class="txt" style ="margin-top: 3px;">
                    Consumption
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtxconsumption" CssClass="combo" Style="text-align: center; margin-left: -47px;
                    margin-top: 3px;" runat="server" AutoPostBack="true" ReadOnly="false" Width="100px"
                    Font-Size="8pt" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                <div class="text_box" style="width: 50px;">
                    <asp:DropDownList ID="cmbUnit" CssClass="combo" runat="server" AutoPostBack="false"
                        Style="width: 45px; margin-left: 106px; margin-top: 6px; height: 26px;" Visible="true">
                    </asp:DropDownList></div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 70px;">
                    Process Loss/Ex.
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtExtra" Style="text-align: center; margin-left: 2px;" runat="server"
                        onkeypress="return isNumericKeyy(event);" AutoPostBack="true" ReadOnly="false"
                        Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="text_box" style="width: 38px; margin-left: 107px; margin-top: -25px;">
                    <asp:DropDownList ID="DropDownList1" Width="38px" CssClass="combo" runat="server"
                        AutoPostBack="false" Style="height: 26px;" Visible="true" Enabled="false">
                        <asp:ListItem Value="0">%</asp:ListItem>
                    </asp:DropDownList></div>
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
                    <asp:TextBox ID="txtFabricCost" Style="text-align: center; margin-left: 19px;" runat="server"
                        AutoPostBack="true" onkeypress="return isNumericKeyy(event);" ReadOnly="false"
                        Width="66px" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="text_box" style="width: 38px; margin-left: 78px; margin-top: -25px;">
                    <asp:DropDownList ID="cmbUnit2" Width="45px" CssClass="combo" runat="server" AutoPostBack="false"
                        Visible="FALSE" Enabled="TRUE">
                    </asp:DropDownList></div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 21px;">
                   Ex-Rate
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtExchangeRate" Style="text-align: center; margin-left: 8px;" runat="server"
                        AutoPostBack="true" onkeypress="return isNumericKeyy(event);" ReadOnly="false"
                        Width="100px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>

        </tr>
        <tr>
        <td style="width: 110px;">
            
            </td>
         <td>
             
            </td>
                 <td style="width: 110px;">
                
            </td>
         <td>
                
            </td>
              <td style="width: 110px;">
                <div class="txt" style="margin-left: 21px;">
                   Currency
                </div>
            </td>
         <td>
                <div class="text_box" style="width: 130px;">
                   <asp:DropDownList ID="cmbCurrencys" Width="61px" CssClass="combo" runat="server" AutoPostBack="false"
                        Visible="true" style="margin-left: 9px;" >
                        <asp:ListItem Value ="1">USD</asp:ListItem>
                         <asp:ListItem Value ="2">EUR</asp:ListItem>
                          <asp:ListItem Value ="2">PKR</asp:ListItem>

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
                <asp:Label ID="Label7" runat="server" Text="Ex-Rate:" Style="color: red; margin-left: 21PX;"></asp:Label>
                <asp:Label ID="lblusd" runat="server" Text="0.00" Style="color: red;"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr style="height: 44px;">
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
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
             <div style="overflow: scroll; width: 930px;">
                <Smart:SmartDataGrid ID="dgFabricCost" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
                    PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BOUNDCOLUMN HeaderText="FabricCostDtlId" DataField="FabricCostDtlId" visible="False">
                            <headerstyle width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="FabricdataBaseId" DataField="FabricdataBaseId" visible="False">
                            <headerstyle width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Fabric" DataField="FabricWeave">
                            <headerstyle horizontalalign="Center" width="2%" />
                            <itemstyle horizontalalign="left" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="FabricTypeId" DataField="FabricTypeId" visible="False">
                            <headerstyle width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Fabric Type" DataField="FabricType">
                            <headerstyle horizontalalign="Center" width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Fabric Cons." DataField="Construction" visible="False">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Width" DataField="Width">
                            <headerstyle horizontalalign="Center" width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Comp." DataField="Composition">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Cons" DataField="Consumption">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Fab/Req" DataField="FabricReq">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Ex.%" DataField="Extra">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Gross" DataField="Gross">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="SupplierId" DataField="IMSSupplierId" visible="false">
                            <headerstyle horizontalalign="Center" width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Source" DataField="IMSSupplierName">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Fabric Cost" DataField="FabricCost">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Amount" DataField="Amount">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Ex-Rate" DataField="ExchangeRate">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="USD" DataField="USD" visible="False">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Color" DataField="Color">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Item" DataField="Item">
                            <headerstyle horizontalalign="Center" width="4%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Style" DataField="Style">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="P/Cl.Qty" DataField="QtyColorWise">
                            <headerstyle horizontalalign="Center" width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="JobOrderDetailId" DataField="JobOrderDetailId" visible="false">
                            <headerstyle width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                          <asp:BOUNDCOLUMN HeaderText="Currency" DataField="Currency">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>

                            <asp:BOUNDCOLUMN HeaderText="IMSItemId" Visible ="false"  DataField="IMSItemId">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Item Code" DataField="ItemCode">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Fabric Quality" DataField="FabricQuality">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Fabric Quality For Buyer" Visible="false"  DataField="FabricQualityForBuyer">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="RM"
                            visible="true">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
                </div> 
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
                    margin-left: -93px;" Visible="false" /><asp:Label ID="lblFabricCostMstid" runat="server"
                        Text=" " Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
  
</asp:Content>

