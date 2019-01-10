<%@ Page Title="Fabrication Sheet Add" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FabricationSheetAdd.aspx.vb" Inherits="Integra.FabricationSheetAdd" %>

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
    <div class="main_container">
        <div class="header_columns">
            <div class="heading">
                FABRICATION SHEET</div>
            <br />
            <table width="100%">
                <tr>
                    <td>
                        Date :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" CssClass="textbox"> </asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                    <td>
                        Reference# :
                    </td>
                    <td>
                        <asp:TextBox ID="txtReference" CssClass="textbox" runat="server">  </asp:TextBox>
                    </td>
                    <td>
                        Buyer. :
                    </td>
                    <td>
                        <asp:TextBox ID="txtBuyer" CssClass="textbox" runat="server">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <%--<td> Total Order Qty:</td>
<td><ASP:TextBox  ID="txtTotalOrderQty" CssClass="textbox" ReadOnly ="false" runat="server"></ASP:TextBox ></td>
                    --%>
                    <td>
                        PO Number :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPONumber" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Item :
                    </td>
                    <td>
                        <asp:TextBox ID="txtItem" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Style No. :
                    </td>
                    <td>
                        <asp:TextBox ID="txtStyleNo" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Fabric Name :
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbFabricName" Width="139px" CssClass="combo" AutoPostBack="true"
                            runat="server" Style="margin-left: 0px;">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Fabric Code :
                    </td>
                    <td>
                        <asp:TextBox ID="txtFabricCode" CssClass="textbox" runat="server">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Wash:
                    </td>
                    <td>
                        <asp:TextBox ID="txtWash" CssClass="textbox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Order Qty :
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderQty" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                    </td>
                    <td>
                        Consumption. :
                    </td>
                    <td>
                        <asp:TextBox ID="txtConsumption" Width="70px" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                        %.
                        <asp:TextBox ID="txtPercent" Width="50" CssClass="textbox" runat="server" AutoPostBack="true"
                            onkeypress="return isNumericKeyy(event);">  </asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Qty.In Mtr :
                    </td>
                    <td>
                        <asp:TextBox ID="txtQtyInMtr" CssClass="textbox" runat="server" ReadOnly="true" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
                    </td>
                    <td>
                        Size :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSize" runat="server" CssClass="textbox"> </asp:TextBox>
                    </td>
                    <%--<td> % : </td>
<td><ASP:TextBox ID="txtPercentt" Width ="10" CssClass="textbox" runat="server" onkeypress="return isNumericKeyy(event);" >  </ASP:TextBox></td>--%>
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
                        <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
                            PagerOtherPageCssClass="" PageSize="1000" RecordCount="0" ShowFooter="True" ForeColor="white"
                            GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="FabricationSheetDtlID"
                                    DataField="FabricationSheetDtlID" Visible="False">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="FabricIMSItemID" DataField="FabricIMSItemID"
                                    Visible="False">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Style No" DataField="StyleNo"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Fabric Name" DataField="Fabric"
                                    Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Fabric Code"
                                    DataField="FabricCode">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Wash"
                                    DataField="Wash">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Order Qty."
                                    DataField="OrderQty">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Consumption"
                                    DataField="Consumption">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Qty.In Mtrs."
                                    DataField="QtyInMtr">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Size"
                                    DataField="Size">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Percent"
                                    DataField="Percent">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
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
                                    Visible="true">
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
