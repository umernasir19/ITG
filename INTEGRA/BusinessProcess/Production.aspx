<%@ Page Title="Production" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Production.aspx.vb" Inherits="Integra.Production" %>
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

    <table width="100%" id="TABLE1" onclick="return TABLE1_onclick()">
        <tr>
            <asp:Label ID="lblmsgemail" runat="server"></asp:Label></tr>
        <tr>
            <td style="width: 110px;">
                <div class="txt">
                    Production
                </div>
            </td>
            <td style="width: 250px;">
                <asp:DropDownList ID="ddlproduction" Width="150" CssClass="combo" runat="server"
                    AutoPostBack="true">
                </asp:DropDownList>
            </td>
            <td style="width: 98px; height: 40px;">
                <div class="txt">
                    Date
                </div>
            </td>
            <td>
                <%-- <div class="text_box" style="width: 130px;">
                <asp:TextBox ID="txtdDate" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtdDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" /></div> --%>
                <div class="text_box" style="width: 130px;">
                    <asp:TextBox ID="txtdDate" Style="text-align: center; margin-left: 2px;" runat="server"
                        Width="80" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtdDate"
                        PopupButtonID="ImageButton2" />
                    <asp:ImageButton runat="Server" ID="ImageButton2" CausesValidation="false" Style="margin-left: -385px;"
                        ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtdDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        <tr>
            <td style="height: 24px">
                <%--<div class="txt">
                    Job Order
                </div>--%>
            </td>
            <td style="height: 24px">
                <asp:DropDownList ID="ddljoborder" Width="150" CssClass="combo" runat="server" AutoPostBack="True"
                    Visible="false">
                </asp:DropDownList>
            </td>
            <td style="height: 24px">
            </td>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" Width="100px" />
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel" Width="100px" />
            </td>
        </tr>
    </table>
    <br />
    <div>
        <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AutoGenerateColumns="False"
            CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
            PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white" GridLines="None">
            <Columns>
                <asp:BOUNDCOLUMN HeaderText="JobOrderDetailID" DataField="JobOrderDetailID" visible="False">
                    <headerstyle width="1%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:BOUNDCOLUMN HeaderText="SR NO" DataField="SRNO">
                    <headerstyle horizontalalign="Center" width="5%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:BOUNDCOLUMN HeaderText="ITEM" DataField="Content">
                    <headerstyle horizontalalign="Center" width="10%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:BOUNDCOLUMN HeaderText="STYLE" DataField="Style">
                    <headerstyle horizontalalign="Center" width="4%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:BOUNDCOLUMN HeaderText="COLOR" DataField="BuyerColor">
                    <headerstyle horizontalalign="Center" width="4%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:BOUNDCOLUMN HeaderText="QTY" DataField="Quantity">
                    <headerstyle horizontalalign="Center" width="3%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:TEMPLATECOLUMN HeaderText="Qty%">
                    <itemtemplate>
<asp:textbox style="WIDTH: 40px" id="txtPercent" onkeypress="return isNumericKeyy(event);" runat="server"></asp:textbox>
 <asp:ImageButton id="lnkRemove" runat="server" ImageUrl="~/Images/redCal.jpg" CommandName="Calculation" tooltip="Click here to Calculate Total Qty" 
  CommandArgument='<%#Eval("JobOrderDetailID")%>'   ></asp:ImageButton> 
</itemtemplate>
                    <headerstyle width="3%" />
                    <itemstyle horizontalalign="Center" />
                </asp:TEMPLATECOLUMN>
                <asp:TEMPLATECOLUMN HeaderText="Total Qty">
                    <itemtemplate>
									 	    <asp:textbox id="txtQTYwithPer"   runat="server" Style="width: 50px;" readonly="true"></asp:textbox>
										
</itemtemplate>
                    <headerstyle width="5%" />
                    <itemstyle horizontalalign="Center" />
                </asp:TEMPLATECOLUMN>
                <asp:BOUNDCOLUMN HeaderText="PREVIOUS PRODUCED" DataField="ProductedTodayIndivisiual">
                    <headerstyle horizontalalign="Center" width="3%" />
                    <itemstyle horizontalalign="Center" />
                </asp:BOUNDCOLUMN>
                <asp:TEMPLATECOLUMN HeaderText="Rejection">
                    <itemtemplate>
									 	    <asp:textbox id="txtRejection"   runat="server" Style="width: 50px;" readonly="true"></asp:textbox>
										
</itemtemplate>
                    <headerstyle width="5%" />
                    <itemstyle horizontalalign="Center" />
                </asp:TEMPLATECOLUMN>
                <asp:TEMPLATECOLUMN HeaderText="EDIT QTY.">
                    <itemtemplate>
<asp:textbox style="WIDTH: 50px" id="txtMinimizeQty" onkeypress="return isNumericKeyy(event);" runat="server"></asp:textbox>
 <asp:ImageButton id="btnMinimizeQty" runat="server" ImageUrl="~/Images/redCal.jpg" CommandName="CalculationMinimize" tooltip="Click here to Calculate Total Qty" 
  CommandArgument='<%#Eval("JobOrderDetailID")%>'   ></asp:ImageButton> 
</itemtemplate>
                    <headerstyle width="3%" />
                    <itemstyle horizontalalign="Center" />
                </asp:TEMPLATECOLUMN>
                <asp:TEMPLATECOLUMN HeaderText="PRODUCED TODAY">
                    <itemtemplate>
									 	    <asp:textbox id="txtProduced"   runat="server" Style="width: 70px; "></asp:textbox>
										
</itemtemplate>
                    <headerstyle width="5%" />
                    <itemstyle horizontalalign="Center" />
                </asp:TEMPLATECOLUMN>
                <asp:TEMPLATECOLUMN>
                    <headerstyle width="2%" />
                    <itemstyle horizontalalign="Center" />
                    <itemtemplate>
									        <asp:checkbox id="ChkStatus"   runat="server" Style="width: 20px; " ></asp:checkbox>
							              
</itemtemplate>
                </asp:TEMPLATECOLUMN>
              
            </Columns>
            <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
            <AlternatingItemStyle CssClass="GridAlternativeRow" />
            <ItemStyle CssClass="GridRow" />
            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
        </Smart:SmartDataGrid>
    </div>
    <br />
    <table>
        <tr>
            <td>
                <div>
                    <Smart:SmartDataGrid ID="dgMail" runat="server" Font-Size="10px" Width="80%" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" ShowFooter="false" PagerCurrentPageCssClass=""
                        PagerOtherPageCssClass="" PageSize="1000" RecordCount="0" ForeColor="white" GridLines="None">
                        <PagerStyle Visible="false" CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <Columns>
                            <asp:BOUNDCOLUMN HeaderText="JobOrderDetailID" DataField="JobOrderDetailID" visible="False">
                                <headerstyle width="1%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="JOB" DataField="JobOrderNo">
                                <headerstyle horizontalalign="Center" width="5%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="ITEM" DataField="ItemDiscription">
                                <headerstyle horizontalalign="Center" width="10%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="STYLE" DataField="StyleNo">
                                <headerstyle horizontalalign="Center" width="10%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="COLOR" DataField="CodeName">
                                <headerstyle horizontalalign="Center" width="10%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="QTY" DataField="Qty">
                                <headerstyle horizontalalign="Center" width="3%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Qty%" DataField="QtyPercent">
                                <headerstyle horizontalalign="Center" width="10%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Total Qty" DataField="TotalQty">
                                <headerstyle horizontalalign="Center" width="10%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="Total PRODUCED" DataField="ProductedTodayIndivisiual">
                                <headerstyle horizontalalign="Center" width="10%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                            <asp:BOUNDCOLUMN HeaderText="StyleSubStyleID" DataField="Style_SubStyleID" visible="False">
                                <headerstyle width="2%" />
                                <itemstyle horizontalalign="Center" />
                            </asp:BOUNDCOLUMN>
                        </Columns>
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>



