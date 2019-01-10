<%@ Page Title="Numbering Weight Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="NumberingWeightEntry.aspx.vb" Inherits="Integra.NumberingWeightEntry" %>

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
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 20px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Weight Entry
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="margin-left: 297px;">
                    <asp:Label ID="Label2" runat="server" Text="Receiving No:" Font-Bold="true" Style="color: Maroon;
                        font-size: large;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 27px;">
                    <asp:Label ID="lblReceivingNo" runat="server" Font-Bold="true" Style="color: Green;
                        font-size: large;"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="uddgStyleAssortment" style="z-index: 100; overflow: scroll;
                    left: 4px; width: 920px; position: relative; top: 7px; height: 300px" Width="920px"
                    runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgStyleAssortment" Height="300px" runat="server" Width="100%"
                            AllowPaging="True" AllowSorting="True" CaptionAlign="Bottom" AutoGenerateColumns="False"
                            CellPadding="4" CssClass="table Freezing" PageSize="1000" MaintainScrollPositionOnPostback="false"
                            ShowFooter="True" ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="NumberingDtlID"
                                    DataField="NumberingFinalDtlID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="NumberingID"
                                    DataField="NumberingFinalID" Visible="false" />
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
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Style" DataField="Style">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Carton No"
                                    DataField="CartonNo">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Code" DataField="Code">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" Visible="false" HeaderStyle-Width="12%" HeaderText="Bar Code No"
                                    DataField="SerialNo">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" Visible="true" HeaderStyle-Width="12%" HeaderText="Size"
                                    DataField="Sizee">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" Visible="true" HeaderStyle-Width="12%" HeaderText="Qty"
                                    DataField="PcsPerCartonn">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Weight" HeaderStyle-BackColor="#F294A0" HeaderStyle-ForeColor="Black">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtWeight" AutoPostBack="true" OnTextChanged="txtWeight_TextChanged"
                                            Style="text-align: center; width: 100px;" CssClass="textbox" runat="server" ReadOnly="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="4%" HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SelectPacking"
                                    DataField="SelectPacking" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="DonePacking"
                                    DataField="DonePacking" Visible="false" />
                                <asp:TemplateColumn HeaderText="Select To Packing" Visible="true" HeaderStyle-BackColor="#F294A0"
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
                </div>
            </td>
            <td>
                <div style="margin-left: 97px;">
                </div>
            </td>
            <td>
                <div style="margin-left: 238px;">
                    <asp:Label ID="ff" runat="server" Text="Total Weight" Font-Bold="true" Style="color: Blue;
                        font-size: large;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 105px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblTotalWeight" runat="server" Font-Bold="true" Style="color: Red;
                                font-size: 14px; text-align: center;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 20px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Summary
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" style="z-index: 100; overflow :scroll ; left: 4px; width: 920px;
                    position: relative; top: 7px; height: 200px" Width="920px" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgViewNew" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" CaptionAlign="Bottom" AutoGenerateColumns="False" CellPadding="4"
                            CssClass="table Freezing" PageSize="1000" MaintainScrollPositionOnPostback="false"
                            ShowFooter="True" ForeColor="white" GridLines="both">
                            <Columns>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentDetailID"
                                    DataField="StyleAssortmentDetailID" Visible="false" />
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="true" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Size" DataField="Sizee">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Carton No"
                                    DataField="CartonNo">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="true" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderStyle-Width="12%" HeaderText="Qty" DataField="PcsPerCartonn">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                                <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="12%" HeaderStyle-BackColor="#F294A0"
                                    HeaderStyle-ForeColor="Black" HeaderText="Weight" DataField="Weight">
                                    <HeaderStyle Width="10%" HorizontalAlign="center" />
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="NotSet" />
                        </Smart:SmartDataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <div style="margin-left: 0px; margin-top: 23px;">
                    <asp:Label ID="Label1" runat="server" Text="Total Carton:" Font-Bold="true" Style="color: Blue;
                        font-size: medium;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 0px; margin-top: 23px;">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblTotalCarton" runat="server" Font-Bold="true" Style="color: Red;
                                font-size: 14px; text-align: center;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="margin-left: 0px;">
                    <asp:Label ID="Label3" runat="server" Text="Total Qty:" Font-Bold="true" Style="color: Blue;
                        font-size: medium;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 0px;">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblTotalQty" runat="server" Font-Bold="true" Style="color: Red; font-size: 14px;
                                text-align: center;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="margin-left: 0px;">
                    <asp:Label ID="Label4" runat="server" Text="Total Weight:" Font-Bold="true" Style="color: Blue;
                        font-size: medium;"></asp:Label></div>
            </td>
            <td>
                <div style="margin-left: 0px;">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:Label ID="lblTotalWeightnew" runat="server" Font-Bold="true" Style="color: Red;
                                font-size: 14px; text-align: center;"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
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
