<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="NumberingEntry.aspx.vb" Inherits="Integra.NumberingEntry" MaintainScrollPositionOnPostback="true" %>

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


        function myFunction() {
            // Declare variables 
            var input, filter, table, tr, td, i, td2;
            input = document.getElementById("ContentPlaceHolder1_txtMarchand");
            filter = input.value.toUpperCase();
            table = document.getElementById("ContentPlaceHolder1_dgStyleAssortment");
            tr = table.getElementsByTagName("tr");

            // Loop through all table rows, and hide those who don't match the search query

            var totalCotton = 0
            var totalQty = 0
            for (i = 0; i < tr.length; i++) {

                td = tr[i].getElementsByTagName("td")[2];
                td2 = tr[i].getElementsByTagName("td")[5];
                var innerInput = td2.getElementsByTagName("input");
                console.log("data is :" + innerInput.value);
                if (td) {
                    if (td.innerHTML.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                        totalCotton = totalCotton + parseInt(td.innerHTML);
                        var qty = innerInput.value;
                        totalQty = totalQty + parseInt(qty);

                        // console.log("data is :" + td.innerHTML);
                        document.getElementById("ContentPlaceHolder1_LBLNoOfCarton").innerHTML = totalCotton;
                        document.getElementById("ContentPlaceHolder1_lblTotal").innerHTML = totalQty;
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }

   
    </script>
    <table width="100%">
        <tr>
            <td>
                <b>Basic Information </b>
            </td>
        </tr>
        <tr>
            <td>
                Merchandiser
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtMarchand" onkeyup="myFunction()" runat="server"
                    ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                Date
            </td>
            <td>
                <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="120" runat="server"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                    PopupButtonID="ImageButton1" />
                <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                    AlternateText="Click here to display calendar" />
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                    Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                    CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                    Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                </cc1:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td>
                Style
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtStyle" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Sr No
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtJobNo" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtSeason" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Customer
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtCustomer" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Brand
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtBrand" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Cust. PO
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtCustPo" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Item Desc.
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtItem" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                GSM
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtGSM" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fabric Quality
            </td>
            <td>
                <asp:TextBox CssClass="textbox" ID="txtContent" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <td>
                Quantity
            </td>
            <td>
                <asp:TextBox ID="txtQuantity" CssClass="textbox" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <b>Statistics </b>
            </td>
        </tr>
        <tr>
            <td>
                Price
            </td>
            <td>
                <asp:TextBox ID="txtPrice" CssClass="textbox" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
            <tr>
                <td>
                    Cust. Color
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtCustColor" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
    </table>
    <table>
        <tr>
            <td align="left">
                <asp:Button ID="btnDeleteAssortment" Visible="false" Style="margin-left: 666px; width: 108px"
                    runat="server" CssClass="button" Text="Delete All Size"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="margin-left: 297px;">
                    <asp:Label ID="Label2" runat="server" Text="Shipment No:" Font-Bold="true" Style="color: Maroon;
                        font-size: large;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 27px;">
                    <asp:Label ID="lblNumberingNo" runat="server" Font-Bold="true" Style="color: Green;
                        font-size: large;"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <div style="">
                    <b>Receive Date</b></div>
            </td>
            <td>
                <div style="margin-left: 131px;">
                    <asp:TextBox ID="txtReceiveDate" CssClass="textbox" Width="120" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" runat="server" TargetControlID="txtReceiveDate"
                        PopupButtonID="ImageButton3" />
                    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtReceiveDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                </div>
            </td>
            <td>
                <div style="margin-left: 170px;">
                    <b>Receive No</b></div>
            </td>
            <td>
                <div style="margin-left: 32px;">
                    <asp:TextBox ID="txtReceiveNo" runat="server" Visible="true" ReadOnly="true"></asp:TextBox></div>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="AddPnl" runat="server" Visible="false">
        <table>
            <tr>
                <td>
                    <div style="margin-left: 0px;">
                        <asp:Label ID="Label3" runat="server" Text="Add New:" Font-Bold="true" Style="color: Blue;
                            font-size: large;"></asp:Label></div>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <div style="margin-left: 0px;">
                        <b>Size</b></div>
                </td>
                <td>
                    <div style="margin-left: 187px;">
                        <asp:DropDownList ID="cmbSize" Width="150" AutoPostBack="false" runat="server" Style="margin-left: 24px;
                            margin-right: 52px;">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    <div style="margin-left: 157px;">
                        <b>Qty</b></div>
                </td>
                <td>
                    <div style="margin-left: 78px;">
                        <asp:TextBox onkeypress="return isNumericKeyy(event);" ID="txtAddQty" runat="server"
                            ReadOnly="false"></asp:TextBox></div>
                </td>
            </tr>
        </table>
        <br />
        <table>
            <tr>
                <td>
                    <div style="margin-left: 658px;">
                        <asp:Button ID="btnAddQty" runat="server" CssClass="button" Visible="true" Text="Add">
                        </asp:Button>
                    </div>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="uddgStyleAssortment" style="z-index: 100; overflow: scroll;
                    left: 4px; width: 920px; position: relative; top: 7px; height: 350px" Width="920px"
                    runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgStyleAssortment" Height="500px" runat="server" Width="100%"
                            AllowPaging="True" AllowSorting="True" CaptionAlign="Bottom" AutoGenerateColumns="False"
                            CellPadding="4" CssClass="table Freezing" PageSize="10000" MaintainScrollPositionOnPostback="false"
                            ShowFooter="True" ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="NumberingDtlID"
                                    DataField="NumberingDtlID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="NumberingID"
                                    DataField="NumberingID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeRangeId"
                                    DataField="SizeRangeId" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeDatabaseId"
                                    DataField="SizeDatabaseId" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentDetailID"
                                    DataField="StyleAssortmentDetailID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentMasterID"
                                    DataField="StyleAssortmentMasterID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="CuttingProDetailID"
                                    DataField="CuttingProDetailID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="CuttingProMasterID"
                                    DataField="CuttingProMasterID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Joborderid"
                                    DataField="Joborderid" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JoborderDetailid"
                                    DataField="JoborderDetailid" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Color" DataField="BuyerColor">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderText="Style"
                                    HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor="Black" DataField="Style">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Carton No"
                                    DataField="CartonNo">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Carton No" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor="Black">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCartonNo" AutoPostBack="false" Style="text-align: center; width: 100px;"
                                            CssClass="textbox" runat="server" ReadOnly="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="4%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Code" DataField="Code">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderStyle-Width="12%"
                                    HeaderText="Bar Code No" DataField="SerialNo">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderStyle-Width="12%"
                                    HeaderText="Size" DataField="Sizee">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Size" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor="Black">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSize" AutoPostBack="false" Style="text-align: center; width: 100px;"
                                            CssClass="textbox" runat="server" ReadOnly="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="4%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Qty" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor="Black">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtQty" AutoPostBack="true" OnTextChanged="txtQty_TextChanged" Style="text-align: center;
                                            width: 100px;" CssClass="textbox" runat="server" ReadOnly="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="4%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SelectNumbering"
                                    DataField="SelectNumbering" Visible="false" />
                                <asp:TemplateColumn HeaderText="Select" Visible="true" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkSelect" OnCheckedChanged="Status" AutoPostBack="true" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="NotSet" />
                        </Smart:SmartDataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="margin-left: 196px;">
                    <asp:Label ID="Label1" runat="server" Text="Total" Font-Bold="true" Style="color: Blue;
                        font-size: large;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 114px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="LBLNoOfCarton" runat="server" Font-Bold="true" Style="color: Red;
                                font-size: large;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td>
                <div style="margin-left: 261px;">
                    <asp:Label ID="ff" runat="server" Text="Total" Font-Bold="true" Style="color: Blue;
                        font-size: large;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 103px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblTotal" runat="server" Font-Bold="true" Style="color: Red; font-size: large;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnsave" runat="server" CssClass="button" Visible="false" Text="Save">
                </asp:Button>
                <asp:Button ID="btnCancel" runat="server" CssClass="button" Text="Cancel"></asp:Button>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblid" runat="server" Visible="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
