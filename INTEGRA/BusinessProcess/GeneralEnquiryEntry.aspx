<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="GeneralEnquiryEntry.aspx.vb" Inherits="Integra.GeneralEnquiryEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                General Inquiry
            </th>
        </tr>
        <tr>
            <td>
                Creation Date
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtCreDate" runat="server" Culture="en-US" Enabled="false">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
                Inquiry Purpose
            </td>
            <td>
                <asp:TextBox ID="txtInqPurpose" CssClass="textbox" Text="General Inquiry" runat="server"
                    Visible="false"></asp:TextBox>
                <asp:DropDownList ID="cmbEnquiryPurpose" Width="139px" runat="server" AutoPostBack="false" Enabled ="false" >
                    <asp:ListItem Value="0">Select </asp:ListItem>
                    <asp:ListItem Value="1">Buying Meeting</asp:ListItem>
                    <asp:ListItem Value="2" Selected ="True" >General Meeting</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Inquiry Type
            </td>
            <td>
                <asp:DropDownList ID="cmbEnqType" runat="server" Width="120" Enabled="true">
                    <asp:ListItem Value="Initial" Text="Initial"></asp:ListItem>
                    <asp:ListItem Value="Repeat" Text="Repeat" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Inq.Recv. Date
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtInqRecvDate" runat="server" Culture="en-US">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
                Inq.Confirmed Date
            </td>
            <td>
                <asp:TextBox ID="txtInqConfDate" CssClass="textbox" Text="" runat="server"></asp:TextBox>
            </td>
            <td>
                Repeat Season
            </td>
            <td>
                <asp:DropDownList ID="cmbRepeatSeason" AutoPostBack="false" runat="server" Width="116px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 34px;">
            <td>
                Purchase Order
            </td>
            <td>
                <asp:DropDownList ID="cmbPO" AutoPostBack="false" runat="server" Width="116px">
                    <asp:ListItem Value="Received" Text="Received"></asp:ListItem>
                    <asp:ListItem Value="Pending" Text="Pending"></asp:ListItem>
                    <asp:ListItem Value="Cancelled" Text="Cancelled"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Confirm Status
            </td>
            <td>
                <asp:DropDownList ID="cmbConfrimStatus" AutoPostBack="false" runat="server" Width="116px">
                    <asp:ListItem Value="Waiting" Text="Waiting"></asp:ListItem>
                    <asp:ListItem Value="Approved" Text="Approved"></asp:ListItem>
                    <asp:ListItem Value="Cancelled" Text="Cancelled"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Information
            </th>
        </tr>
        <tr style="height: 35px;">
            <td>
                Style No:
            </td>
            <td>
                <asp:TextBox ID="txtStyleNo" CssClass="textbox" Width="130" AutoPostBack="true" runat="server"
                    autocomplete="off"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtStyleNo"
                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="SearchStyle" />
                <asp:Label ID="lblStyleId" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
            <td>
                Special Line
            </td>
            <td>
                <asp:TextBox ID="txtCoreLine" CssClass="textbox" Width="144" runat="server" Visible="false"></asp:TextBox>
                <asp:DropDownList ID="cmbSpecialLine" Width="144px" CssClass="dd" runat="server"
                    Enabled="true">
                    <asp:ListItem Value="Y">Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                Customer
            </td>
            <td>
                <asp:DropDownList ID="cmbCustomer" Width="150" AutoPostBack="true" CssClass="dd"
                    Enabled="false" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Style Description
            </td>
            <td>
                <asp:TextBox ID="txtStyleDescription" CssClass="textbox" Width="215" runat="server"
                    ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" Width="150" AutoPostBack="true" Enabled="false"
                    CssClass="dd" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Style Source
            </td>
            <td>
                <asp:DropDownList ID="cmbStyleSource" runat="server" AutoPostBack="true" CssClass="dd"
                    Enabled="false" Width="150" ToolTip="Select source of original sample">
                    <asp:ListItem Value="0" Text="Technical sheet" />
                    <asp:ListItem Value="1" Text="Buyer sample" />
                    <asp:ListItem Value="2" Text="GIA Offer Sample" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Buying Dept
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyingDept" Width="137" AutoPostBack="true" CssClass="dd"
                    Enabled="false" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Buyer Name
            </td>
            <td>
                <asp:DropDownList ID="cmbBuyer" Width="150" AutoPostBack="true" Enabled="false" CssClass="dd"
                    runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Brand
            </td>
            <td>
                <asp:DropDownList ID="cmbbrand" Width="150" AutoPostBack="true" Enabled="false" CssClass="dd"
                    runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="UpFabFinish" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Product Information
            </th>
        </tr>
        <tr style="height: 35px;">
            <td>
                Product Portfolio
            </td>
            <td>
                <asp:DropDownList Width="140" ID="cmbProductPortfolio" AutoPostBack="true" CssClass="dd"
                    Enabled="false" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Product Category
            </td>
            <td>
                <asp:DropDownList ID="cmbProductCategory" Width="140" AutoPostBack="true" CssClass="dd"
                    Enabled="false" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                Product Consumer Grp
            </td>
            <td>
                <asp:DropDownList ID="cmbProductConsumerGrp" Width="140" runat="server" AutoPostBack="true"
                    Enabled="false" CssClass="dd" ToolTip="Select product consumer">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                Lining
            </td>
            <td>
                <asp:DropDownList ID="cmbLining" Width="144px" CssClass="dd" runat="server" Enabled="false">
                    <asp:ListItem Value="Y">Y</asp:ListItem>
                    <asp:ListItem>N</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <asp:Label ID="lblpack" runat="server" Text="Pack"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbPack" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbPack" AutoPostBack="true" CssClass="dd" Width="100" runat="server"
                            Enabled="false">
                            <asp:ListItem Text="1 Pc Set" Value="0"></asp:ListItem>
                            <asp:ListItem Text="2 Pc Set" Value="1"></asp:ListItem>
                            <asp:ListItem Text="3 Pc Set" Value="2"></asp:ListItem>
                            <asp:ListItem Text="4 Pc Set" Value="3"></asp:ListItem>
                            <asp:ListItem Text="5 Pc Set" Value="4"></asp:ListItem>
                            <asp:ListItem Text="6 Pc Set" Value="5"></asp:ListItem>
                            <asp:ListItem Text="7 Pc Set" Value="6"></asp:ListItem>
                            <asp:ListItem Text="8 Pc Set" Value="7"></asp:ListItem>
                            <asp:ListItem Text="9 Pc Set" Value="8"></asp:ListItem>
                            <asp:ListItem Text="10 Pc Set" Value="9"></asp:ListItem>
                            <asp:ListItem Text="11 Pc Set" Value="10"></asp:ListItem>
                            <asp:ListItem Text="12 Pc Set" Value="11"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAddProduct" CssClass="button" Width="100" runat="server" Text="Add Product"
                    Visible="false" />
                <asp:Button ID="btnAddMoreProduct" CssClass="button" Width="100" runat="server" Visible="false"
                    Text="Add Product" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PanelStyle" runat="server" Enabled="true">
        <div style="vertical-align: top; overflow: auto; width: 920px; border-style: groove;">
            <table width="100%">
                <tr>
                    <td>
                        <Smart:SmartDataGrid ID="dgProductinfo" runat="server" Width="100%" AllowPaging="False"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="SproductID" DataField="SproductID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="ProductPortfolioID" DataField="ProductPortfolioID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="ProductCategoriesID" DataField="ProductCategoriesID"
                                    Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="ProductConsumerID" DataField="ProductConsumerID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Product Con. Group" DataField="ProductConsumerGroup"
                                    Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Pack" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPack" Text='<% #Eval("Pack") %>' Width="50" ReadOnly="true" CssClass="textbox"
                                            runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Base Row">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRow" Text='<% #Eval("RowNo") %>' Width="50" ReadOnly="true" CssClass="textbox"
                                            runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Item">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItem" Text='<% #Eval("Item") %>' Width="100px" CssClass="textbox"
                                            runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="HS Code">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtHSCode" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Type">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFabricType" CssClass="dd" Width="80" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText=" Fab. Finish">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFabFinish" Width="80" CssClass="dd" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Cons">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFCons" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Comp.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFComp" Width="180px" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Wt.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFWt" onkeypress="return isNumericKeyy(event);" CssClass="textbox"
                                            Width="50" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Unit">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFWtUnit" Width="80" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Garment Wt.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGarmentWt" onkeypress="return isNumericKeyy(event);" Width="50"
                                            CssClass="textbox" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Unit">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbGarmentWtUnit" Width="80" CssClass="dd" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Color" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtColor" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Lin.Type">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbLiningType" CssClass="dd" Width="80" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Lin.Cons">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtLiningCons" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Lin.Comp.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbLinigComp" Width="180px" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Lining Wt.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtLiningWt" onkeypress="return isNumericKeyy(event);" Width="50"
                                            CssClass="textbox" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:BoundColumn HeaderText="Lining" DataField="Lining" Visible="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Remarks">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Remove" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="RemoveProduct" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                            <AlternatingItemStyle CssClass="GridAlternativeRow" />
                            <ItemStyle CssClass="GridRow" />
                            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                        </Smart:SmartDataGrid>
                    </td>
                    <td valign="top">
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
      <br />

    <table width="100%">
        <tr>
            <td>
                Item
            </td>
            <td>
                <asp:TextBox ID="txtItem" runat="server"></asp:TextBox>
            </td>
            <td>
                Color
            </td>
            <td>
                <asp:TextBox ID="txtColor" runat="server"></asp:TextBox>
            </td>
            <td>
                Qty
            </td>
            <td>
                <asp:TextBox ID="txtQty" runat="server" Width="116px" onkeypress="return isNumericKeyy(event);"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <br />
                <asp:Button ID="btnAddDetail" CssClass="button" runat="server" Text="Add More" />
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                    PagerOtherPageCssClass="" PageSize="600" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                    <Columns>
                        <asp:BoundColumn HeaderText="Detail ID" DataField="GeneralInquiryDtlID" Visible="False" />
                        <asp:BoundColumn HeaderText="Item" DataField="Item">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Color" DataField="Color">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn HeaderText="Qty" DataField="QTy">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Action" Visible="true">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkRemove" runat="server" CommandName="Remove" BackColor="transparent"
                                    ImageUrl="~/Images/RemoveIcon.png" />
                            </ItemTemplate>
                            <HeaderStyle Width="3%" />
                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" Visible="false" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr style="height: 70px">
            <td>
                Remarks
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtRemarks" runat="server" Width="303px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" runat="server" Text="Save" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
            </td>
        </tr>
    </table>
</asp:Content>
