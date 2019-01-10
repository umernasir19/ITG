<%@ Page Title="Store Receipt Voucher Entry" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master" CodeBehind="StoreReceiptVoucherEntry.aspx.vb"
    Inherits="Integra.StoreReceiptVoucherEntry" %>

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
        function TABLE1_onclick() {

        }




    </script>
    <table width="100%">
        <tr>
            <td>
                GRN No.
            </td>
            <td>
                <asp:TextBox ID="txtGRNNo" CssClass="textbox" runat="server" Visible="true"></asp:TextBox>
            </td>
            <td>
                Voucher Date :
            </td>
            <td>
                <asp:TextBox ID="txtVoucherDate" runat="server" CssClass="textbox" AutoPostBack="true"> </asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtVoucherDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVoucherDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
            <td>
                Roll No. :
            </td>
            <td>
                <asp:TextBox ID="txtRollNo" CssClass="textbox" runat="server">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblClassName" runat="server" Text="Item Class Name."></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbItemClassName" Width="139px" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: 0px;">
                </asp:DropDownList>
            </td>
            <td>
                Item Name. :
            </td>
            <td>
                <asp:DropDownList ID="cmbitemCode" Width="139px" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: 0px;">
                </asp:DropDownList>
            </td>
            <td>
                Item Code
            </td>
            <td>
                <asp:TextBox ID="txtItemName" CssClass="textbox" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Color :
            </td>
            <td>
                <asp:TextBox ID="txtColor" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                D.C. No. :
            </td>
            <td>
                <asp:TextBox ID="txtDCNo" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                Order No. :
            </td>
            <td>
                <asp:TextBox ID="txtOrderNo" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Mills/Suppliers :
            </td>
            <td>
                <asp:DropDownList ID="CmbSuppliers" Width="139px" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: 0px;">
                </asp:DropDownList>
            </td>
            <%--<td> Particulars : </td>
<td><ASP:TextBox ID="txtParticulars" CssClass="textbox" runat="server" Visible ="false"  >  </ASP:TextBox></td>
            --%>
            <td>
                Qty. Received :
            </td>
            <td>
                <asp:TextBox ID="txtFabricRcv" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);"
                    AutoPostBack="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Buyers :
            </td>
            <td>
                <asp:TextBox ID="txtCustomer" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                Unit. :
            </td>
            <td>
                <asp:DropDownList ID="cmbUnit" Width="139px" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: 0px;">
                </asp:DropDownList>
            </td>
            <%--<td>  Cartage :  </td>
<td><ASP:TextBox  ID="txtCartage" CssClass="textbox" runat="server" ></ASP:TextBox ></td>--%>
        </tr>
        <tr>
            <td>
                Status :
            </td>
            <td>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="textbox"> </asp:TextBox>
            </td>
            <td>
                Sales Tax :
            </td>
            <td>
                <asp:TextBox ID="txtSalesTax" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);">  </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Vehicle No. :
            </td>
            <td>
                <asp:TextBox ID="txtVehicleNo" CssClass="textbox" runat="server"></asp:TextBox>
            </td>
            <td>
                Rate. :
            </td>
            <td>
                <asp:TextBox ID="txtRate" CssClass="textbox" runat="server" AutoPostBack="true"></asp:TextBox>
            </td>
            <td>
                Amount :
            </td>
            <td>
                <asp:TextBox ReadOnly="true" ID="txtAmount" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <br />
                <div>
                    <asp:Button ID="btnAddDetail" runat="server" Text="Add Detail" CssClass="button" />
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgVoucherViewAdd" runat="server" Width="100%" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="1000" RecordCount="0"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="StoreReceiptVoucherDtlID"
                            DataField="StoreReceiptVoucherDtlID" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="IMSItemID" DataField="IMSItemID"
                            Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Voucher Date" DataField="ReceiptDate"
                            Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Roll Number"
                            DataField="RollNumber">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Item Name"
                            DataField="ItemCode">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Item Code"
                            DataField="ItemName">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Color"
                            DataField="Color" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="DC No."
                            DataField="DCNo" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Order No."
                            DataField="OrderNo" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Mills"
                            DataField="Mills" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Particulars"
                            DataField="Particulars" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Fabric Received"
                            DataField="FabricReceived" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Customers"
                            DataField="Buyers" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="GRN No."
                            DataField="GRNNo" Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Cartage"
                            DataField="Cartage" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Status"
                            DataField="Status">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Sales Tax"
                            DataField="SalesTax">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Amount"
                            DataField="Amount">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Vehicle No."
                            DataField="VehicleNo">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="IMSItemClassID" DataField="IMSItemClassID"
                            Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Rate" DataField="Rate"
                            Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Symbol" DataField="Symbol"
                            Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="ItemUnitId" DataField="ItemUnitId"
                            Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <%--   <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="Left"   
								HeaderText="AccountCode" DataField="AccountCode"  visible="false" >
								  <itemstyle horizontalalign="Center" />
								 <headerstyle width="2%" horizontalalign="Center"  />
								 </ASP:BOUNDCOLUMN> --%>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="SupplierDatabaseId"
                            DataField="SupplierDatabaseId" Visible="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderText="Edit"
                            Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit Currency" ImageUrl="~/Images/editIcon.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderText="Remove"
                            Visible="false">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                    CommandName="Remove" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" CausesValidation="true">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
