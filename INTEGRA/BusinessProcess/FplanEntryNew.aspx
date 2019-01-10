<%@ Page Title="Fabric Planing" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="FplanEntryNew.aspx.vb" Inherits="Integra.FplanEntryNew" %>
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
                Fabric Planning Sheet (Job Order vise)
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
                        ReadOnly="true" Width="130px" Font-Size="8pt" Visible ="false" ></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
               
                  <asp:TextBox ID="txtItem" Style="text-align: center; margin-left: 2px;" runat="server"
                        ReadOnly="true" Width="174px" Font-Size="8pt" Visible ="false"></asp:TextBox>
              
            </td>
            <td>
                
                <asp:DropDownList ID="ddlFabricCode" Width="130px" CssClass="combo" runat="server"
                    AutoPostBack="false" Visible="false">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    
    <table width="100%">
        <tr style="height: 30pX;" class="heading">
            <td>
                Additing Fabric For This Order Quantity
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <%-- <td style="width: 110px;">
                <div class="txt">
                    Fabric Code
                </div>
            </td>--%>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 1px;">
                    Consumption
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 38px;">
                    <asp:TextBox ID="txtConsumption" Style="text-align: center; margin-left: -36px;"
                        runat="server" onkeypress="return isNumericKeyy(event);" Width="50px" Font-Size="8pt"
                        AutoPostBack="true"></asp:TextBox>
                    <asp:TextBox ID="txtConsumptionQty" ReadOnly="true" Style="text-align: center; margin-left: -2px;"
                        runat="server" onkeypress="return isNumericKeyy(event);" Width="50px" Font-Size="8pt"
                        AutoPostBack="False"></asp:TextBox>
                    <asp:TextBox ID="txtPrecentage" Style="text-align: center; margin-left: -2px;" runat="server"
                        placeholder="%" onkeypress="return isNumericKeyy(event);" Width="20px" Font-Size="8pt"
                        AutoPostBack="true"></asp:TextBox>
                </div>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 33px;">
                    Total Fabric
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 38px;">
                    <asp:TextBox ID="txtTotalFabric" Style="text-align: center; margin-left: -22px;"
                        ReadOnly="true" runat="server" onkeypress="return isNumericKeyy(event);" Width="90px"
                        Font-Size="8pt"></asp:TextBox>
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtPieceQty" Style="text-align: center; margin-left: -52px;" ReadOnly="FALSE"
                    Visible="false" runat="server" onkeypress="return isNumericKeyy(event);" Width="90px"
                    Font-Size="8pt"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="In Meter" Style="margin-left: -54px;"></asp:Label>
            </td>
            <td style="width: 110px;">
                <div class="txt" style="margin-left: 9px;">
                    Required Date
                </div>
            </td>
            <td>
                <div class="text_box" style="width: 130px; margin-left: 17px;">
                    <asp:TextBox ID="txtReqDate" Style="text-align: center; margin-left: -6px; margin-top: 2px;"
                        runat="server" Width="109" Font-Size="8pt"></asp:TextBox>
                </div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReqDate"
                        PopupButtonID="ImageButton3" />
                    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" Style="margin-left: -62px;
                        margin-top: 2px;" ImageUrl="~/Images/calendar.JPG" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtReqDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        <tr style="height: 44px;">
            <td style="width: 110px;">
                <asp:Label ID="lblFPlanMst" runat="server" Text="" Visible="false">
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
                    <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Add Fabric" Style="width: 117px;
                        margin-left: -93px;" />
                </td>
        </tr>
    </table>
       <table width="100%" >
      <tr>
            <td style="height: 13px; width :15px;">
                <asp:LinkButton ID="LinkFabricPopup" runat="server" Visible ="true" >If Fabric not found Click here to create</asp:LinkButton>
                     <asp:ImageButton ID="btnShow" runat="server"   BackColor="transparent"
                    ToolTip="Click here to show data." ImageUrl="~/Images/redCal.jpg" />
            </td>
        </tr>
    </table>
    <br />    
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgFPlanView" runat="server" Width="100%" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass=""
                    PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white" GridLines="None">
                    <Columns>
                        <asp:BOUNDCOLUMN HeaderText="FPlanID" DataField="FPlanDtlID" visible="False">
                            <headerstyle width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="FabricdataBaseId" DataField="FabricdataBaseId" visible="False">
                            <headerstyle width="1%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Fabric Code" DataField="FabricCode">
                            <headerstyle horizontalalign="Center" width="5%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Weave" DataField="Weave">
                            <headerstyle horizontalalign="Center" width="5%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="GSM" DataField="GSM">
                            <headerstyle horizontalalign="Center" width="4%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Width" DataField="Width">
                            <headerstyle horizontalalign="Center" width="4%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Composition" DataField="Composition">
                            <headerstyle horizontalalign="Center" width="8%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="ReqMeter" DataField="ReqMeter">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="ReqDate" DataField="ReqDatee">
                            <headerstyle horizontalalign="Center" width="3%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
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
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgFPlan" runat="server" Width="100%" ForeColor="white" CssClass="table"
                    GridLines="None" ShowFooter="True" RecordCount="0" PageSize="1000" PagerOtherPageCssClass=""
                    PagerCurrentPageCssClass="" CellPadding="4" AutoGenerateColumns="False">
                    <PagerStyle Mode="NumericPages" HorizontalAlign="Right" CssClass="GridPagerStyle"></PagerStyle>
                    <AlternatingItemStyle CssClass="GridAlternativeRow"></AlternatingItemStyle>
                    <ItemStyle CssClass="GridRow"></ItemStyle>
                    <Columns>
                        <asp:BoundColumn DataField="FPlanDtlID" HeaderText="FPlanID" Visible="false">
                            <headerstyle width="1%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Style">
                            <itemtemplate>
<asp:DropDownList id="cmbstyle" runat="server" AutoPostBack="false" Font-Size="8pt"   Cssclass="textbox" width="120px"> </asp:DropDownList> 
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="1%"></headerstyle>
                            <itemstyle horizontalalign="Left"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Fabric">
                            <itemtemplate>
<asp:DropDownList id="cmbFabric" runat="server" AutoPostBack="true" Font-Size="8pt" OnSelectedIndexChanged="cmbFabric_SelectedIndexChanged" Cssclass="textbox" width="120px"> </asp:DropDownList> 
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="1%"></headerstyle>
                            <itemstyle horizontalalign="Left"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Width">
                            <itemtemplate>
	                           <asp:textbox id="txtWidth"  readonly="true" onkeypress="return isNumericKey(event);" runat="server" width="55px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Consumption" HeaderText="Cons.">
                            <headerstyle horizontalalign="Center" width="5%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Piece Qty.">
                            <itemtemplate>
<asp:textbox id="txtPieceQtyy" onkeypress="return isNumericKey(event);" runat="server" CssClass="textbox" width="55px" readonly="false"  AutoPostBack="true" OnTextChanged="txtPieceQtyy_TextChanged"></asp:textbox> 
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="5%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Req Meter">
                            <itemtemplate>
	                           <asp:textbox id="txtReqMeter"  readonly="true" onkeypress="return isNumericKey(event);" runat="server" width="55px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="5%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="ReqDatee" HeaderText="ReqDate">
                            <headerstyle horizontalalign="Center" width="5%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>
                        <%--     <asp:BoundColumn DataField="OpeningBal" HeaderText="Opening Bal.">
                            <headerstyle horizontalalign="Center" width="3%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>--%>
                        <asp:TemplateColumn HeaderText="REMOVE" Visible="False">
                            <itemtemplate>
									 								
										<asp:ImageButton id="lnkRemove2" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									
</itemtemplate>
                            <headerstyle width="2%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <%--   <asp:TemplateColumn HeaderText="In House">
                            <itemtemplate>
	                           <asp:textbox id="txtInHouse"   onkeypress="return isNumericKey(event);" runat="server" width="55px" CssClass="textbox"></asp:textbox>                             
	                             <asp:ImageButton id="imgcalculate" runat="server" tooltip="Click here to calculate quantity & value." CommandName="Calculate"  ImageUrl="~/Images/redCal.jpg"  />
                                                            
                          
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="7%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>--%>
                        <%--   <asp:TemplateColumn HeaderText="Balance Qty">
                            <itemtemplate>
	                           <asp:textbox id="txtBalanceQty"  readonly="true" onkeypress="return isNumericKey(event);" runat="server" width="55px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>--%>
                        <%--       <asp:TemplateColumn HeaderText="Issue Qty">
                            <itemtemplate>
	                           <asp:textbox id="txtIssueQty"   onkeypress="return isNumericKey(event);" runat="server" width="55px" CssClass="textbox"></asp:textbox>                             
                                <asp:ImageButton id="imgcalculatestock" runat="server" tooltip="Click here to calculate quantity & value." CommandName="CalculateStock"  ImageUrl="~/Images/redCal.jpg"  />
	                         </itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>--%>
                        <%--  <asp:TemplateColumn HeaderText="Stock Qty">
                            <itemtemplate>
	                           <asp:textbox id="txtStockQty"   onkeypress="return isNumericKey(event);" runat="server" width="55px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle horizontalalign="Center" width="4%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>--%>
                        <asp:TemplateColumn HeaderText="IMSItemID" Visible="false">
                            <itemtemplate>
									 								
										<asp:label id="lblIMSItemID" Visible="false"  runat="server"></asp:label>
									
                            </itemtemplate>
                            <headerstyle width="2%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <%--<asp:BoundColumn DataField="IMSItemID" HeaderText="IMSItemID" Visible="true">
                            <headerstyle width="1%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>--%>
                        <asp:BoundColumn DataField="ReqStatus" HeaderText="Req.Status" Visible="false">
                            <headerstyle horizontalalign="Center" width="5%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Requisition" Visible="false">
                            <itemtemplate>
									 								
										<asp:ImageButton id="lnkRequisition" tooltip="open PopUp" ImageUrl="~/Images/editIcon.jpg" CommandName="Requisition" runat="server"></asp:ImageButton>
									
</itemtemplate>
                            <headerstyle width="2%"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Fabric Issue "
                            visible="true">
                            <itemtemplate>									 								
										<asp:ImageButton id="Issue" tooltip="Click Here To Issue" ImageUrl="~/Images/green.png" CommandName="Issue" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        
                        
                        	<asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Fabric PO"
                            visible="true">
                            <itemtemplate>        
          <asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
         </itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        
                        
                        
                        
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
            <td width="150px">
                <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" Style="font-weight: bold;"
                    Visible="false">
                </asp:Label></td>
            <td width="150px">
                <asp:Label ID="lblPieaceQty" runat="server" Text="" Style="font-weight: bold;" Visible="True">
                </asp:Label>
            </td>
            <td width="150px">
                <asp:Label ID="lblReqMeter" runat="server" Text="" Style="font-weight: bold;" Visible="True">
                </asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td style="margin-left: 500px; height: 24px;">
                <asp:Button ID="btnAddmore" runat="server" CssClass="button" Text="Add More" Style="width: 117px;
                    margin-left: 0px;" Visible ="false" />
            </td>
        </tr>
        <tr>
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
        </tr>
    </table>
</asp:Content>
