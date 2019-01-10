<%@ Page Title="Cd Db Purchase Order" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CdDbPurchaseOrder.aspx.vb" Inherits="Integra.CdDbPurchaseOrder" %>
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
        <tr>
            <td>
                <div class="heading">
                    Credit/Debit Note Purchase Order</div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35px;">
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    C/D. Note No.
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtNoteNo" CssClass="textbox" runat="server" Style="width: 148px;"
                        ReadOnly="true"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: -428px;">
                    Date
                </div>
            </td>
            <td style="height: 30px">
                <div class="text_box">
                    <asp:TextBox ID="txtdatee" Style="text-align: center; width: 100px; margin-left: -278px;"
                        runat="server" AutoPostBack="false" Font-Size="8pt"></asp:TextBox></div>
                <div class="icon" align="center">
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtdatee"
                        PopupButtonID="ImageButton1" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.jpg"
                        AlternateText="Click here to display calendar" Style="margin-left: -447px;" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdatee"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    Note Type.
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:DropDownList ID="cmbNoteType" Width="150" CssClass="combo" AutoPostBack="false"
                        runat="server" Style="">
                        <asp:ListItem value= "0" Text="Select"></asp:ListItem>
                        <asp:ListItem value= "1" Text="Debit"></asp:ListItem>
                        <asp:ListItem value= "2" Text="Credit"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt_newwww" style="width: 140px;">
                    Supplier
                </div>
            </td>
            <td>
                <asp:DropDownList ID="cmbSupplier" Width="400" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="">
                </asp:DropDownList></td>
                <td><asp:Label ID="lblSupplierId" runat="server" Visible="false"></asp:Label></td>
        </tr>
     </table>    <table>
        <tr style="height: 35px;">
            <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                    Invoice No.
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:DropDownList ID="cmbInvoiceNo" Width="150" CssClass="combo" AutoPostBack="true"
                        runat="server" Style="">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <div class="txt_newwww" style="width: 140px; margin-left: 193px;">
                    Invoice Amount
                </div>
            </td>
            <td>
                <div class="text_box">
                    <asp:TextBox ID="txtInvoiceAmount" Style="text-align: center; width: 100px; margin-left: 6px;"
                        runat="server" ReadOnly="true" Font-Size="8pt"></asp:TextBox></div>
            </td>
        </tr>
        </table><table>
        <tr>
            <%-- <td>
                <div class="txt_newwww" style="width: 140px;">
                    Items
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:DropDownList ID="cmbItems" Width="150" CssClass="combo" AutoPostBack="true"
                        runat="server" Style="" Visible="false">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <%-- <td style="width: 150px;" >
                <div class="txt_newwww" style="width: 140px;">
                  Qty.
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtPackingQty" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Width="23px" Visible="false"></asp:TextBox>
                </div>
            </td>
            <%-- <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                  Packing.
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtPerUnitqty" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <%--  <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                 Weigth
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtQtyIssue" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
            <%--  <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                  RATE.
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtRATEE" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <%--   <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                 Exc. VALUE
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtAmountt" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
            <%--  <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                 Gst %.
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtGstPer" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <%--   <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                 GST Amount
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtGSTAmountt" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
            <%--  <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                  Cartage.
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtCartagee" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr style="height: 35px;">
            <%--  <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                Discount
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtDiscount" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
            <%--   <td style="width: 150px;">
                <div class="txt_newwww" style="width: 140px;">
                  Inc. Value.
                </div>
            </td>--%>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtNetAmountt" CssClass="textbox" runat="server" Style="width: 90px;"
                        ReadOnly="true" Visible="false"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%" style ="margin-top: -150px;">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgItemView" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="200" RecordCount="0"
                    ShowFooter="false" ForeColor="white" GridLines="both">
                    <Columns>
                      <asp:BOUNDCOLUMN HeaderText="CDNotePODtlID" DataField="CDNotePODtlID" visible="false">
                            <headerstyle horizontalalign="Center" width="16%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                      <asp:BOUNDCOLUMN HeaderText="ItemID" DataField="ItemID" visible="false">
                            <headerstyle horizontalalign="Center" width="16%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Item Name" DataField="ItemName">
                            <headerstyle horizontalalign="Center" width="10%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:TemplateColumn HeaderText="WEIGHT">
                            <itemtemplate>
<asp:textbox id="txtInvoiceQtyy" text="0" onkeypress="return isNumericKeyy(event);" style="text-align:Right" runat="server" CssClass="textbox" autopostback="false" width="60"></asp:textbox> 
</itemtemplate>
                            <headerstyle width="3%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="RATE">
                            <itemtemplate>
<asp:textbox id="txtRATE" text="0" onkeypress="return isNumericKeyy(event);"  style="text-align:Right" runat="server" CssClass="textbox" OnTextChanged="txtRATE_TextChanged"  width="60" autopostback="true"></asp:textbox> 
</itemtemplate>
                            <headerstyle width="3%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText=" Exc. VALUE">
                            <itemtemplate>
<asp:textbox id="txtAmount" text="0" ReadOnly="True"  style="text-align:Right" runat="server" width="60px" CssClass="textbox"></asp:textbox>
</itemtemplate>
                            <headerstyle width="5%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GST %">
                            <itemtemplate>
<asp:DropDownList id="cmbGstPer" runat="server" Font-Size="8pt" autopostback="true" width="45px" Cssclass="textbox" OnSelectedIndexChanged="cmbGstPer_SelectedIndexChanged" >

</asp:DropDownList> 
</itemtemplate>
                            <headerstyle width="3%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GST Amount">
                            <itemtemplate>
	                           <asp:textbox id="txtGSTAmount"  style="text-align:Right"  onkeypress="return isNumericKey(event);" runat="server" readonly="true" width="55px" CssClass="textbox" ></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle width="3%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="W.H Tax">
                            <itemtemplate>
<asp:DropDownList id="cmbWHT" runat="server" Font-Size="8pt" width="45px" autopostback="true" Cssclass="textbox" OnSelectedIndexChanged="cmbWHT_SelectedIndexChanged" >
 <asp:ListItem Value="0">0</asp:ListItem>
<asp:ListItem Value="1">1</asp:ListItem>
<asp:ListItem Value="2">2</asp:ListItem>
<asp:ListItem Value="3">3</asp:ListItem>
<asp:ListItem Value="4">4</asp:ListItem>
<asp:ListItem Value="5">5</asp:ListItem>
<asp:ListItem Value="6">6</asp:ListItem>
<asp:ListItem Value="7">7</asp:ListItem>
<asp:ListItem Value="8">8</asp:ListItem>
<asp:ListItem Value="9">9</asp:ListItem>
<asp:ListItem Value="10">10</asp:ListItem>
<asp:ListItem Value="11">11</asp:ListItem>
<asp:ListItem Value="12">12</asp:ListItem>
<asp:ListItem Value="13">13</asp:ListItem>
<asp:ListItem Value="14">14</asp:ListItem>
<asp:ListItem Value="15">15</asp:ListItem>
<asp:ListItem Value="16">16</asp:ListItem>
<asp:ListItem Value="17">17</asp:ListItem>
<asp:ListItem Value="18">18</asp:ListItem>
<asp:ListItem Value="19">19</asp:ListItem>
<asp:ListItem Value="20">20</asp:ListItem>
<asp:ListItem Value="21">21</asp:ListItem>
<asp:ListItem Value="22">22</asp:ListItem>
<asp:ListItem Value="23">23</asp:ListItem>
<asp:ListItem Value="24">24</asp:ListItem>
<asp:ListItem Value="25">25</asp:ListItem>
<asp:ListItem Value="26">26</asp:ListItem>
<asp:ListItem Value="27">27</asp:ListItem>
<asp:ListItem Value="28">28</asp:ListItem>
<asp:ListItem Value="29">29</asp:ListItem>
 <asp:ListItem Value="29">30</asp:ListItem>
  
</asp:DropDownList>   
 <asp:TextBox id="txtWHTAXAmount" text="0" runat="server" readonly="true" width="55px" onkeypress="return isNumericKeyy(event);" style="text-align:Right"  CssClass="textbox"></asp:TextBox>
  
</itemtemplate>
                            <headerstyle width="7%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Inc. Value">
                            <itemtemplate>
	                           <asp:textbox id="txtNetAmount" text="0"  onkeypress="return isNumericKey(event);" style="text-align:Right" runat="server" readonly="true" width="85px" CssClass="textbox"></asp:textbox>                             
	                         
</itemtemplate>
                            <headerstyle width="3%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <itemtemplate>
<asp:CheckBox  id="ChkInvoiceStatus"  AutoPostBack="true" runat="server" OnCheckedChanged="UpdateStatus"></asp:CheckBox> 
</itemtemplate>
                            <headerstyle width="2%" horizontalalign="Center"></headerstyle>
                            <itemstyle horizontalalign="Center"></itemstyle>
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
    <table>
        <tr style="height: 35px">
            <td style="height: 30px">
                <div class="text_box">
                    <asp:TextBox ID="txtTot" Style="text-align: right; width: 100px; margin-left: 790px;" onkeypress="return isNumericKeyy(event);"
                        runat="server" ReadOnly="true" Font-Size="8pt"></asp:TextBox></div>
            </td>
            <%--  <td align="right">
                <asp:Button ID="btnAddGrid" CssClass="btn btn-outline btn-danger" runat="server"
                    Text="ADD GRID" Width="120px" Visible="false" />
            </td>--%>
        </tr>
    </table>
    <table>
        <tr id="trtotal" runat="server">
            <td width="250px">
            </td>
            <td width="250px">
            </td>
            <td width="100px">
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 30px;">
            <td align="center">
              <asp:Button ID="btnCancel" CssClass="btn btn-outline btn-danger" runat="server" Text="Cancel"
                    Width="120px" Visible="true" />
                <asp:Button ID="btnSave" ToolTip="Click here To Save data." CssClass="btn btn-outline btn-success"
                    runat="server" Text="Save" Width="120px" Visible="false" />
              
            </td>
        </tr>
    </table>
</asp:Content>


