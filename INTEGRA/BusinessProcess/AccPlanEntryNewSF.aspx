<%@ Page Title="Access.. Plan Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="AccPlanEntryNewSF.aspx.vb" Inherits="Integra.AccPlanEntryNewSF" %>
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
        <tr style="height: 30px;" class="heading">
            <td>
                Accessoriese Planning Sheet (Job Order vise)
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
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
                    Recv Date
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtRecvDate" Style="text-align: center; margin-left: 2px;" runat="server"
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
                    Ship Date
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtShipDate" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="109px" Font-Size="8pt"></asp:TextBox>
                </div>
                <%--     <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtShipDate"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" Style="margin-left: -47px;"
                        Visible="false" ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtShipDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>--%>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <div class="txt">
                    Season
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtSeason" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                    Buyer
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtBuyer" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt">
                    Brand
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtBrand" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    Qty:
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtQty" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
            </td>
            <td>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtContent" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="130px" Font-Size="8pt" Visible="false"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
            </td>
            <td>
                <asp:TextBox ID="txtItem" Style="text-align: center; margin-left: 2px;" runat="server"
                    ReadOnly="true" Width="174px" Font-Size="8pt" Visible="false"></asp:TextBox>
                <asp:DropDownList ID="ddlAccessorieseCode" Width="130px" CssClass="combo" runat="server"
                    Visible="false" AutoPostBack="false">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="height: 30px;" class="heading">
            <td>
                Additing Accessoriese For This Order Quantity
            </td>
        </tr>
    </table>
    <br />
    <%--<table>
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    Required Date
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 17px;">
                    <asp:TextBox ID="txtReqDate" Style="text-align: center; margin-left: -15px; margin-top: -1px;"
                        runat="server" Width="109" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReqDate"
                        PopupButtonID="ImageButton3" />
                    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" Style="margin-left: -71px;
                        margin-top: 1px;" ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtReqDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
            <td>
                <asp:Label ID="lblHDreqdate" runat="server" Text="(20 days before ship date)" Style="margin-left: 73px;"></asp:Label></td>
        </tr>
    </table>--%>
    <table width="100%">
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <asp:Label ID="lblAccessPlanMst" runat="server" Text="" Visible="false">
                </asp:Label>
                <asp:Label ID="lblJobOrderId" runat="server" Text="" Visible="false">
                </asp:Label>
            </td>
            <td style="width: 110px;">
            </td> 
                <td style="width: 110px;">
                </td>
                <td style="width: 110px;">
                </td>
                <td style="margin-left: 500px; height: 24px;">
                    <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Add Access.." Style="width: 117px;
                        margin-left: -93px;" />
                </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td style="height: 13px; width: 15px;">
                <asp:LinkButton ID="LinkAccessoriesePopup" runat="server" Visible="true">If Accessoriese not found Click here to create</asp:LinkButton>
                <asp:ImageButton ID="btnShow" runat="server" BackColor="transparent" ToolTip="Click here to show data."
                    ImageUrl="~/Images/redCal.jpg" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgACPlan" runat="server" Width="100%" ForeColor="white"
                    CssClass="table" GridLines="None" ShowFooter="True" RecordCount="0" PageSize="1000"
                    PagerOtherPageCssClass="" PagerCurrentPageCssClass="" CellPadding="4" AutoGenerateColumns="False">
                    <PagerStyle Mode="NumericPages" HorizontalAlign="Right" CssClass="GridPagerStyle"></PagerStyle>
                    <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="GridRow"></ItemStyle>
                    <Columns>
                        <asp:BoundColumn DataField="AccessoriesePlanDtlID" HeaderText="AccessoriesePlanDtlID"
                            Visible="False">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <headerstyle width="1%"></headerstyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Style">
                            <itemstyle horizontalalign="Left"></itemstyle>
                            <itemtemplate>
<asp:DropDownList id="cmbstyle" runat="server" AutoPostBack="false" Font-Size="8pt" width="120px" Cssclass="textbox"> </asp:DropDownList> 
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="1%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Accessories">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
<asp:DropDownList id="cmbAccosires" runat="server" AutoPostBack="true" Font-Size="8pt" OnSelectedIndexChanged="cmbAccosires_SelectedIndexChanged" Cssclass="textbox" width="115px"> </asp:DropDownList> 
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                        </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Image">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
                                    <asp:Image ID="Image2" Height="30px" Width="30px" runat="server"   />
                                
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="1%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ACCS NAME">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
	                           <asp:textbox id="txtAccessoriesName"  readonly="true" runat="server" style="font-size:10px" width="85px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="COLOR">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
	                           <asp:textbox id="txtColorName"  readonly="true"  style="font-size:10px"  runat="server" width="80px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText=" %">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
<asp:textbox id="txtPercentage" runat="server" CssClass="textbox" AutoPostBack="true" style="text-align:right;" onkeypress="return isNumericKeyy(event);" width="25px" readonly="false" OnTextChanged="txtPercentage_TextChanged"></asp:textbox> 
</itemtemplate>
                            <headerstyle width="5%" horizontalalign="Center"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText=" Per Piece Avg">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
<asp:textbox id="txtPerPcsAvg"  AutoPostBack="true" onkeypress="return isNumericKeyy(event);" style="text-align:right;" runat="server" CssClass="textbox" width="30px" readonly="false" OnTextChanged="txtPerPcsAvg_TextChanged"></asp:textbox> 
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="7%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText=" Quantity">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
                            <asp:textbox   id="txtQuantity" onkeypress="return isNumericKeyy(event);" runat="server" CssClass="textbox" width="65px" style="text-align:right;" readonly="true" />
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="8%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Remarks">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
	                           <asp:textbox id="txtRemarks"  readonly="false"  style="font-size:10px"  runat="server" width="50px" CssClass="textbox"/>                       
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="5%"></headerstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Uom">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
					          <asp:DropDownList ID="ddlUOM2" Width="60px" CssClass="combo" runat="server"   AutoPostBack="false">
                </asp:DropDownList>
					        
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="7%"></headerstyle>
                        </asp:TemplateColumn>
                           <asp:BoundColumn DataField="AccReqStatus" HeaderText="AccReqStatus"  Visible="false">
                            <headerstyle width="1%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="REMOVE" Visible="False">
                            <itemstyle horizontalalign="Center"></itemstyle>
                            <itemtemplate>
									 								
										<asp:ImageButton id="lnkRemove2" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									
</itemtemplate>
                            <headerstyle width="2%"></headerstyle>
                        </asp:TemplateColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" CssClass="GridHeaderStyle"></HeaderStyle>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td width="150px">
            </td>
            <td width="150px">
            </td>
            <td width="235px">
            </td>
            <td width="150px">
                <asp:Label ID="lblGrandTotal" runat="server" Text="Total" Style="font-weight: bold;"
                    Visible="false">
                </asp:Label></td>
            <td width="150px">
                <asp:Label ID="lblPieaceQty" runat="server" Text="" Style="font-weight: bold;" Visible="True">
                </asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnAddmore" runat="server" CssClass="button" Text="Add More" Style="width: 117px;
                    margin-left: 0px;" Visible="false" />
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 270px;">
            </td>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="SaveButton" runat="server" CssClass="button" Visible="false" Text="Save"
                    Style="width: 117px; margin-left: -93px;" />
            </td>
            <td>
                <asp:TextBox ID="txtConsumption" Style="text-align: center; margin-left: -18px;"
                    runat="server" onkeypress="return isNumericKeyy(event);" Width="85px" Font-Size="8pt"
                    AutoPostBack="true" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txtTotalReqQty" Style="text-align: center; margin-left: -82px;"
                    ReadOnly="true" runat="server" onkeypress="return isNumericKeyy(event);" Width="92px"
                    Font-Size="8pt" Visible="false"></asp:TextBox>
                <asp:DropDownList ID="ddlUOM" Width="90px" CssClass="combo" runat="server" Style="margin-left: -113px;"
                    Visible="false" AutoPostBack="false">
                </asp:DropDownList></td>
        </tr>
    </table>
</asp:Content>
