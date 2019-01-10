<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="InquiriesEntry.aspx.vb" Inherits="Integra.InquiriesEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
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
    <asp:Panel ID="PnInquiry" runat="server" Visible="true">
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Buying Meeting Inquiries
                </th>
            </tr>
            <tr style="height: 34px">
                <td>
                    Creation date
                </td>
                <td>
                    <telerik:RadDatePicker ID="txtTodaydate" runat="server" Culture="en-US" Width="100px"
                        Enabled="false">
                        <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                        </Calendar>
                        <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <td>
                    Inquiry purpose
                </td>
                <td>
                    <asp:DropDownList ID="cmbEnquiryPurpose" Width="139px" runat="server" AutoPostBack="false"
                        Enabled="false">
                        <asp:ListItem Value="0">Select </asp:ListItem>
                        <asp:ListItem Value="1" Selected="True">Buying Meeting</asp:ListItem>
                        <asp:ListItem Value="2">General Meeting</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    Inquiry Type
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbEnquireType" runat="server" AutoPostBack="false" Width="149px"
                                ToolTip="Select source of original sample" Enabled="true">
                                <asp:ListItem Value="0" Text="Initial" Selected="True" />
                                <asp:ListItem Value="1" Text="Repeat" />
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 34px">
                <td>
                    Inquiry Recv. Date
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadDatePicker ID="txtRecvDate" runat="server" Culture="en-US" Width="100px">
                        <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                        </Calendar>
                        <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                            LabelWidth="40%">
                        </DateInput>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>
                </td>
                <%-- <td>
                    Ex Factory Date
                </td>
                <td>
                    <asp:TextBox ID="txtExFactoryDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                    <%--   <cc1:CalendarExtender ID="CalendarExtender4" Format="dd/MM/yyyy" runat="server" TargetControlID="txtExFactoryDate"
                    PopupButtonID="ImageButton4" />
                <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtExFactoryDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
                </td>--%>
                <td>
                </td>
                <td>
                    <%--  <asp:DropDownList ID="cmbSeason" runat="server" Width="148px" ToolTip="select Season">
                </asp:DropDownList>--%>
                </td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="PictueWork" runat="server" Visible="true">
            <table width="100%">
                <tr>
                    <td style="width: 98px;">
                        Picture:
                    </td>
                    <td style="width: 150px;">
                        <asp:FileUpload ID="FileUpload2" runat="server" Style="margin-left: 93px;" ToolTip="select jpg file to attach and press upload" />
                    </td>
                    <td style="width: 98px;">
                        <asp:Button ID="btnUploadNew" CssClass="button" runat="server" Text="Upload" Visible="true"
                            Style="margin-left: 18px;" />
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpPic" runat="server" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:LinkButton ID="lnkFIlePicture" Text="Show Picture" Style="margin-left: 18px;"
                                    runat="server" Visible="false"> </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Style Information
                </th>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Customer :
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbCustomer" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbCustomer" Width="150" AutoPostBack="true" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Buying Dept
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbBuyingDept" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbBuyingDept" Width="137" AutoPostBack="true" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Buyer Name
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatecmbBuyerName" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbBuyerName" Width="150" AutoPostBack="true" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Brand
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbBrand" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbBrand" Width="150" AutoPostBack="true" CssClass="dd" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Style No
                </td>
                <td>
                    <asp:UpdatePanel ID="UpStyleNo" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtStyleNo" CssClass="textbox" Width="130" AutoPostBack="false"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Design Name
                </td>
                <td>
                    <asp:TextBox ID="txtDesignName" CssClass="textbox" Width="130" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Style Description
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtStyleDescription" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtStyleDescription" CssClass="textbox" Width="215" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Season
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbSeason" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSeason" Width="150" AutoPostBack="true" CssClass="dd" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Style Source
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbStyleSource" runat="server" AutoPostBack="true" CssClass="dd"
                                Width="150" ToolTip="Select source of original sample">
                                <asp:ListItem Value="0" Text="Technical sheet" />
                                <asp:ListItem Value="1" Text="Buyer sample" />
                                <asp:ListItem Value="2" Text="GIA Offer Sample" />
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Special Line
                </td>
                <td>
                    <asp:UpdatePanel ID="UpCoreLine" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSpecialLine" Width="144px" CssClass="dd" runat="server">
                                <asp:ListItem Value="Y">Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    High Difficulty Line
                </td>
                <td>
                    <asp:UpdatePanel ID="UpHighDifficultyLevel" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbHighDifficultyLevel" Width="144px" CssClass="dd" runat="server">
                                <asp:ListItem Value="Y">Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                    <asp:UpdatePanel ID="UpcmbProductPortfolio" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList Width="140" ID="cmbProductPortfolio" AutoPostBack="true" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Product Category
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbProductCategory" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbProductCategory" Width="140" AutoPostBack="true" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Product Consumer Grp
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbProductConsumerGrp" Width="140" runat="server" AutoPostBack="true"
                                CssClass="dd" ToolTip="Select product consumer">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Lining
                </td>
                <td>
                    <asp:UpdatePanel ID="UpLining" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbLining" Width="144px" CssClass="dd" runat="server">
                                <asp:ListItem Value="Y">Y</asp:ListItem>
                                <asp:ListItem>N</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    <asp:UpdatePanel ID="Uplblpack" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblpack" runat="server" Text="Pack"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbPack" AutoPostBack="true" CssClass="dd" Width="100" runat="server">
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
                    <asp:UpdatePanel ID="Upadd" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAddProduct" CssClass="button" Width="100" runat="server" Text="Add Product" />
                            <asp:Button ID="btnAddMoreProduct" CssClass="button" Width="100" runat="server" Visible="false"
                                Text="Add Product" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <div style="vertical-align: top; overflow: auto; width: 920px; border-style: groove;">
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpUpbtnAutoComplete" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <Smart:SmartDataGrid ID="dgProductinfo" runat="server" Width="100%" AllowPaging="False"
                                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                    ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                    <Columns>
                                        <asp:BoundColumn HeaderText="InquirySproductID" DataField="InquirySproductID" Visible="false">
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
                                                <asp:DropDownList ID="cmbFComp" Width="120" runat="server">
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
                                        <asp:TemplateColumn HeaderText="Color" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtColor" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Buyer Target Price" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtBuyerTargetPrice1" onkeypress="return isNumericKeyy(event);"
                                                    CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Buyer Target Price" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="cmbBuyerPriceUnit1" Width="70" CssClass="dd" runat="server"
                                                    ToolTip="select currency">
                                                    <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                                    <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                                    <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <HeaderStyle Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Buyer MOQ" Visible="true">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtBuyerMOQ1" onkeypress="return isNumericKeyy(event);" CssClass="textbox"
                                                    Width="60" runat="server"></asp:TextBox>
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
                                                <asp:DropDownList ID="cmbLinigComp" Width="120" runat="server">
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
                                        <asp:TemplateColumn HeaderText="Remove">
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
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td valign="top">
                        <asp:UpdatePanel ID="UpbtnAutoComplete" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnAutoComplete" CssClass="button" Width="100" runat="server" Text="Auto Comp."
                                    Visible="false" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%">
            <br />
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Accessories Detail
                </th>
            </tr>
        </table>
        <table width="100%">
            <tr style="height: 35px;">
                <td>
                    Accessories
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbAccessories" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbAccessories" Width="140" AutoPostBack="true" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Accessories Description
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtAccessoriesDescription" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtAccessoriesDescription" Width="100" CssClass="textbox" runat="server"
                                ToolTip="input accessories type"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    Source:
                </td>
                <td>
                    <asp:UpdatePanel ID="UpcmbSource" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSource" Width="80" runat="server" CssClass="dd" ToolTip="select source of accessories">
                                <asp:ListItem Value="0" Text="Local"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Import"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upbtnAddAccessories" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAddAccessories" CssClass="button" Width="130" runat="server" Text="Add Accessories" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="Updgacss" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgAccessories" runat="server" Width="100%" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                <Columns>
                                    <asp:BoundColumn HeaderText="InqSAID" DataField="InqSAID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="AccessoriesID" DataField="AccessoriesID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Accessories" DataField="AccessoriesName" Visible="true">
                                        <ItemStyle HorizontalAlign="center" />
                                        <HeaderStyle Width="2%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Accessories Description" DataField="AccessoriesDescription"
                                        Visible="true">
                                        <ItemStyle HorizontalAlign="center" />
                                        <HeaderStyle Width="2%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Source" DataField="Source" Visible="true">
                                        <ItemStyle HorizontalAlign="center" />
                                        <HeaderStyle Width="2%" HorizontalAlign="center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ConAcc" DataField="ConAcc" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Remove">
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <br />
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSave" CssClass="button" runat="server" Style="width: 105px;" Text="Save" />
                    <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Cancel" />
                </td>
            </tr>
            <tr style="height: 34px;">
                <td>
                    <asp:LinkButton ID="btnShowcomparativecosting" runat="server" Visible="false">Click here to show Comparative Costing</asp:LinkButton>
                    <asp:LinkButton ID="btnHidecomparativecosting" runat="server" Visible="false">Click here to hide Comparative Costing</asp:LinkButton>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:Panel ID="PnCosting" runat="server" Visible="true">
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Comparative Costing (Max 5 Suppliers)
                </th>
            </tr>
            <tr style="height: 35px;">
                <td>
                </td>
                <td>
                    <asp:DropDownList ID="cmbRow" Width="70" CssClass="dd" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td style="width: 100px;">
                    Buyer Target Price
                </td>
                <td style="width: 200px;">
                    <asp:UpdatePanel ID="UpBuyerTargetPrice" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBuyerTargetPrice" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                            <asp:DropDownList ID="cmbBuyerPriceUnit" Width="70" CssClass="dd" runat="server"
                                ToolTip="select currency">
                                <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:Label ID="lblfb" runat="server" Text="as per above fabrication"></asp:Label>
                </td>
                <td style="width: 126px">
                    BuyerMOQ
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtBuyerMOQ" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtBuyerMOQ" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td>
                </td>
                <td>
                    Supplier
                </td>
                <td>
                </td>
                <td>
                    F.Cons
                </td>
                <td>
                </td>
                <td>
                    F.Comp
                </td>
                <td>
                </td>
                <td>
                    F.Wt
                </td>
                <td style="width: 100px;">
                    Supplier MOQ
                </td>
                <td>
                    Quoted Price
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Supplier 1
                </td>
                <td>
                    <asp:UpdatePanel ID="UpCbmSupplier1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="CbmSupplier1" Width="150" AutoPostBack="false" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFCons1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFCons1" CssClass="textbox" Width="50px" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbFComp1" Width="120" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFWT1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFwt1" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="width: 100px;">
                    <asp:UpdatePanel ID="UpSupplierMOQ1" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtSupplierMOQ1" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuotedPrice1" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                            <asp:DropDownList ID="cmbUnitQuotedPrice1" Width="70px" CssClass="dd" runat="server"
                                ToolTip="select currency">
                                <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Supplier 2
                </td>
                <td>
                    <asp:UpdatePanel ID="UpSupplier2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSupplier2" Width="150" AutoPostBack="false" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFCons" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFCons2" CssClass="textbox" Width="50px" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFComp2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbFComp2" Width="120" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFWt" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFWt2" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtSupplierMOQ2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtSupplierMOQ2" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpQuotedPrice2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuotedPrice2" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                            <asp:DropDownList ID="cmbUnitQuotedPrice2" Width="70" CssClass="dd" runat="server"
                                ToolTip="select currency">
                                <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Supplier 3
                </td>
                <td>
                    <asp:UpdatePanel ID="UpSupplier3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSupplier3" Width="150" AutoPostBack="false" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFCons3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFCons3" CssClass="textbox" Width="50px" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFComp3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbFComp3" Width="120" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFWt3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFWt3" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtSupplierMOQ3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtSupplierMOQ3" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpQuotedPrice3" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuotedPrice3" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                            <asp:DropDownList ID="cmbUnitQuotedPrice3" Width="70" CssClass="dd" runat="server"
                                ToolTip="select currency">
                                <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Supplier 4
                </td>
                <td>
                    <asp:UpdatePanel ID="UpUpSupplier4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSupplier4" Width="150" AutoPostBack="false" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFCons4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFCons4" CssClass="textbox" Width="50px" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFComp4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbFComp4" Width="120" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFWt4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFWt4" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtSupplierMOQ4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtSupplierMOQ4" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpQuotedPrice4" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuotedPrice4" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                            <asp:DropDownList ID="cmbUnitQuotedPrice4" Width="70" CssClass="dd" runat="server"
                                ToolTip="select currency">
                                <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Supplier 5
                </td>
                <td>
                    <asp:UpdatePanel ID="UpSupplier5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSupplier5" Width="150" AutoPostBack="false" CssClass="dd"
                                runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFCons5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFCons5" CssClass="textbox" Width="50px" runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFComp5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbFComp5" Width="120" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpFWt5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtFWt5" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UptxtSupplierMOQ5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtSupplierMOQ5" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpQuotedPrice5" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuotedPrice5" CssClass="textbox" Width="50px" onkeypress="return isNumericKeyy(event);"
                                runat="server"></asp:TextBox>
                            <asp:DropDownList ID="cmbUnitQuotedPrice5" Width="70" CssClass="dd" runat="server"
                                ToolTip="select currency">
                                <asp:ListItem Value="Dollar" Text="Dollar"></asp:ListItem>
                                <asp:ListItem Value="Euro" Text="Euro"></asp:ListItem>
                                <asp:ListItem Value="Pounds" Text="Pounds"></asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    Remarks
                </td>
                <td colspan="3">
                    <asp:UpdatePanel ID="UptxtSupplierReamrks" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtQuotedRemarks" CssClass="textbox" Width="250px" TextMode="MultiLine"
                                runat="server"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
        </table>
        <table width="100%">
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                        <asp:Label ID="lblInquiryQuotationID" runat ="server" Visible ="false" text ="0" ></asp:Label>
                            <asp:Button ID="btnAddQuotation" CssClass="button" Width="115px" runat="server" Text="Add Quotation" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <div style="vertical-align: top; overflow: auto; width: 920px; border-style: groove;">
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdgQuotation" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <Smart:SmartDataGrid ID="dgQuotation" runat="server" Width="120%" AllowPaging="False"
                                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                    ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                    <Columns>
                                        <asp:BoundColumn HeaderText="InquiryQuotationID" DataField="InquiryQuotationID" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="InquirySproductID" DataField="InquirySproductID" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="RowNo" DataField="RowNo" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Buyer Target Price" DataField="BuyerTargetPrice" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Unit" DataField="BuyerPriceUnit" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Buyer MOQ" DataField="BuyerMOQ" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="SupplierID1" DataField="SupplierID1" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier 1" DataField="Supplier1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Cons." DataField="FCons1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Compid1" DataField="CompositionID1" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Comp" DataField="FComp1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.WT" DataField="FWT1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier MOQ 1" DataField="SupplierMOQ1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Quoted Price 1" DataField="QuotedPrice1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Unit" DataField="QuotedPriceUnit1" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="SupplierID2" DataField="SupplierID2" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier 2" DataField="Supplier2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Cons." DataField="FCons2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Compid1" DataField="CompositionID2" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Comp" DataField="FComp2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.WT" DataField="FWT2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier MOQ 2" DataField="SupplierMOQ2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Quoted Price 2" DataField="QuotedPrice2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Unit" DataField="QuotedPriceUnit2" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="SupplierID3" DataField="SupplierID3" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier 3" DataField="Supplier3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Cons." DataField="FCons3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Compid3" DataField="CompositionID3" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Comp" DataField="FComp3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.WT" DataField="FWT3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier MOQ 3" DataField="SupplierMOQ3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Quoted Price 3" DataField="QuotedPrice3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Unit" DataField="QuotedPriceUnit3" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="SupplierID 4" DataField="SupplierID4" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier 4" DataField="Supplier4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Cons." DataField="FCons4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Compid1" DataField="CompositionID4" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Comp" DataField="FComp4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.WT" DataField="FWT4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier MOQ 4" DataField="SupplierMOQ4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Quoted Price 4" DataField="QuotedPrice4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Unit" DataField="QuotedPriceUnit4" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="SupplierID 5" DataField="SupplierID5" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier 5" DataField="Supplier5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Cons." DataField="FCons5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Compid1" DataField="CompositionID5" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.Comp" DataField="FComp5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="F.WT" DataField="FWT5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Supplier MOQ 5" DataField="SupplierMOQ5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Quoted Price 5" DataField="QuotedPrice5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Unit" DataField="QuotedPriceUnit5" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Remarks" DataField="QuotedRemarks" Visible="true">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                                    CommandName="Edit" runat="server"></asp:ImageButton>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                    <ItemStyle CssClass="GridRow" />
                                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                </Smart:SmartDataGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Button ID="btnSAVEQuotation" CssClass="button" runat="server" Style="width: 185px;"
                        Text="Save Comparative Costing" />
                    &nbsp;
                    <asp:Button ID="btnCancelQuotation" CssClass="button" runat="server" Text="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <div style="border: 1px solid #00fff;">
        <asp:Panel ID="pnconfrom" runat="server" Visible="true">
            <table width="100%" style="border: 2px dashed red">
                <tr style="height: 34px">
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: red; font-variant: inherit;"
                        bgcolor="Silver">
                        Confirmed Order
                    </th>
                </tr>
            </table>
            <table width="100%">
                <tr style="height: 34px;">
                    <td style="width: 110px;">
                        Supplier
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpSupplier" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbSupplierConfrmd" Width="150" AutoPostBack="false" CssClass="dd"
                                    runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Inquiry Confirmation Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtEnquiryConfirmDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                        <%-- <telerik:RadDatePicker ID="txtEnquiryConfirmDate" runat="server" Culture="en-US"
                    Width="100px">
                    <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput3" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>--%>
                    </td>
                    <td>
                        Purchase Order
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpcmbPOStatus" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbPOStatus" runat="server" AutoPostBack="true" Width="150"
                                    ToolTip="Select PO Status">
                                    <asp:ListItem Value="1" Text="Pending" />
                                    <asp:ListItem Value="2" Text="Received" />
                                    <asp:ListItem Value="3" Text="Cancelled" />
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <asp:UpdatePanel ID="upCnfromOrdre" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgConfrmOrder" runat="server" Width="100%" AllowPaging="False"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="InquiryConformedID" DataField="InquiryConformedID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="InquirySproductID" DataField="InquirySproductID" Visible="false">
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
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Product Con. Group" DataField="ProductConsumerGroup"
                                    Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Item">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItem2" Text='<% #Eval("Item") %>' Width="100px" CssClass="textbox"
                                            runat="server" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Type">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFabricType2" CssClass="dd" Width="80" runat="server" Enabled="false">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText=" Fab. Finish">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFabFinish2" Enabled="false" Width="80" CssClass="dd" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Cons">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFCons2" ReadOnly="false" CssClass="textbox" Width="30" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Comp.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFComp2" Width="120" runat="server" Enabled="TRUE">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="F.Wt.">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFWt2" ReadOnly="false" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" Width="50" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Unit">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbFWtUnit2" Enabled="false" Width="60" runat="server">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Color" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtColor2" CssClass="textbox" Width="150px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Price" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPrice" ReadOnly="false" CssClass="textbox" onkeypress="return isNumericKeyy(event);"
                                            Width="40" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="8%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Quantity" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty2" ReadOnly="false" CssClass="textbox" onkeypress="return isNumericKeyy(event);"
                                            Width="40" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Remarks">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks2" CssClass="textbox" Width="115px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkUpdate" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="1%" HorizontalAlign="Center" />
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                        bgcolor="Silver">
                        Accessories Detail
                    </th>
                </tr>
            </table>
            <table width="100%">
                <tr style="height: 35px;">
                    <td>
                        Accessories
                    </td>
                    <td>
                        <asp:UpdatePanel ID="upcmbAccessoriesCon" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbAccessoriesCon" Width="140" AutoPostBack="true" CssClass="dd"
                                    runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Accessories Description
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel9" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtAccessoriesDescriptionCon" Width="100" CssClass="textbox" runat="server"
                                    ToolTip="input accessories type"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        Source:
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="CmbSourceConfirm" Width="80" runat="server" CssClass="dd" ToolTip="select source of accessories">
                                    <asp:ListItem Value="0" Text="Local"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Import"></asp:ListItem>
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpbtnConfrimAdd" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:Button ID="btnConfrimAdd" CssClass="button" Width="130" runat="server" Text="Add Accessories" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upDgAcssCon" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <Smart:SmartDataGrid ID="DgAcssCon" runat="server" Width="100%" AllowPaging="False"
                                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                    ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                    <Columns>
                                        <asp:BoundColumn HeaderText="InqSAID" DataField="InqSAID" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="AccessoriesID" DataField="AccessoriesID" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Accessories" DataField="AccessoriesName" Visible="true">
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle Width="2%" HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Accessories Description" DataField="AccessoriesDescription"
                                            Visible="true">
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle Width="2%" HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="Source" DataField="Source" Visible="true">
                                            <ItemStyle HorizontalAlign="center" />
                                            <HeaderStyle Width="2%" HorizontalAlign="center" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="ConAcc" DataField="ConAcc" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="OnlyConAcc" DataField="OnlyConAcc" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText=" ">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkAccUpdate" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Remove">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lnkRemoveee" ToolTip="Be sure, it will delete from database"
                                                    ImageUrl="~/Images/RemoveIcon.png" CommandName="RemoveProduct" runat="server">
                                                </asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                    <ItemStyle CssClass="GridRow" />
                                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                                </Smart:SmartDataGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td style="width: 150px;">
                        Styling Detail
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtStylingDetail" CssClass="textbox" Width="250px" TextMode="MultiLine"
                                    runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr style="height: 35px;">
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <asp:UpdatePanel ID="UpReasonofCancel" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <table width="100%">
                        <tr id="ReasonofCancel" visible="false" runat="server">
                            <td style="width: 150px;">
                                Reason of Cancel
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UptxtReasonofCancel" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtReasonofCancel" CssClass="textbox" Width="250px" TextMode="MultiLine"
                                            runat="server"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table width="100%">
                <tr>
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                        bgcolor="Silver">
                        Buyer Action Plan
                    </th>
                </tr>
                <tr style="height: 34px">
                    <td style="width: 75px;">
                        CAD/Artwork Recv Date
                    </td>
                    <td style="width: 75px;">
                        <telerik:RadDatePicker ID="txtCADArtworkRecvDate" runat="server" Culture="en-US"
                            Width="100px">
                            <Calendar ID="Calendar3" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                            </Calendar>
                            <DateInput ID="DateInput3" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%">
                            </DateInput>
                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
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
                <tr>
                    <td style="width: 110px;">
                        Tack Pack Date
                    </td>
                    <td style="width: 110px;">
                        <telerik:RadDatePicker ID="txtTackPackDate" runat="server" Culture="en-US" Width="100px">
                            <Calendar ID="Calendar4" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                            </Calendar>
                            <DateInput ID="DateInput4" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                                LabelWidth="40%">
                            </DateInput>
                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                        </telerik:RadDatePicker>
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
            </table>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Button ID="btnConfirmedSave" CssClass="button" Style="width: 115px;" runat="server"
                            Text="Save Confirmed" />
                        &nbsp;
                        <asp:Button ID="btnConfirmedCancel" CssClass="button" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
