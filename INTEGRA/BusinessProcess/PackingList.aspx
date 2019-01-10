<%@ Page Title="Packing List" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="PackingList.aspx.vb" Inherits="Integra.PackingList" %>

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
        function TABLE1_onclick() {

        }
    </script>
    <table>
        <tr>
            <td style="height: 35px">
                <b>Packing List</b>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Packing No:
            </td>
            <td>
                <asp:TextBox ID="txtPackingNO" runat="server" CssClass="forcapital" ReadOnly="true"
                    AutoPostBack="false" Width="150px" Style="margin-left: 16px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                Driver Name:
            </td>
            <td>
                <asp:TextBox ID="txtDriverName" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 8px; margin-top: 4px;
                    margin-right: 52px; text-transform: uppercase;"></asp:TextBox>
            </td>
            <td>
                Vehicle No:
            </td>
            <td>
                <asp:TextBox ID="txtVehicleNO" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 6px; text-transform: uppercase;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Time Out:
            </td>
            <td>
                <asp:TextBox ID="txtTimeOut" runat="server" CssClass="forcapital" ReadOnly="false"
                    AutoPostBack="false" Width="150px" Style="margin-left: 8px; margin-top: 4px;
                    text-transform: uppercase;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Customer:
            </td>
            <td>
                <div style="margin-left: 24px;">
                    <asp:DropDownList ID="cmbCustomer" Width="150" AutoPostBack="true" runat="server"
                        Style="margin-left: 24px; margin-right: 52px;">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <div style="margin-left: 23px;">
                    Customer PO No:</div>
            </td>
            <td align="left">
                <div>
                    <asp:DropDownList ID="cmbCustomerPONo" Width="150" AutoPostBack="true" runat="server"
                        Style="margin-left: 6px; margin-right: 0px;">
                    </asp:DropDownList>
                </div>
            </td>
            <td>
                <div style="margin-left: 23px;">
                    Receiving No:</div>
            </td>
            <td align="left">
                <div>
                    <asp:DropDownList ID="cmbReceivingNo" Width="150" AutoPostBack="true" runat="server"
                        Style="margin-left: 6px; margin-right: 0px;">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <div style="margin-left: 394px;">
                <asp:Button ID="btnAdd" runat="server" Visible="false" Text="Add" CssClass="button"
                    Width="120px" /></div>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <table>
        <tr>
            <td>
                <div style="width: 930px;">
                    <asp:UpdatePanel ID="uddgStyleAssortment" style="z-index: 100; overflow: scroll;
                        left: 4px; width: 920px; position: relative; top: 7px; height: 350px" Width="920px"
                        runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgCargonEW" runat="server" Width="100%" AllowSorting="True"
                                AutoGenerateColumns="False" CellPadding="2" CssClass="table" PagerCurrentPageCssClass=""
                                PagerOtherPageCssClass="" PageSize="1000" RecordCount="0" ShowFooter="True" SortedAscending="yes">
                                <Columns>
                                    <asp:BoundColumn HeaderText="PackingDtlID" DataField="PackingDtlID" Visible="false" />
                                    <asp:BoundColumn HeaderText="CustomerID" DataField="CustomerID" Visible="false" />
                                    <asp:BoundColumn HeaderText="NumberingFinalID" DataField="NumberingFinalID" Visible="false" />
                                    <asp:BoundColumn HeaderText="NumberingFinalDtlID" DataField="NumberingFinalDtlID"
                                        Visible="false" />
                                    <asp:BoundColumn HeaderText="NumberingDtlID" DataField="NumberingDtlID" Visible="false" />
                                    <asp:BoundColumn HeaderText="NumberingID" DataField="NumberingID" Visible="false" />
                                    <asp:BoundColumn HeaderText="SizeRangeId" DataField="SizeRangeId" Visible="false" />
                                    <asp:BoundColumn HeaderText="SizeDatabaseId" DataField="SizeDatabaseId" Visible="false" />
                                    <asp:BoundColumn HeaderText="StyleAssortmentDetailID" DataField="StyleAssortmentDetailID"
                                        Visible="false" />
                                    <asp:BoundColumn HeaderText="StyleAssortmentMasterID" DataField="StyleAssortmentMasterID"
                                        Visible="false" />
                                    <asp:BoundColumn HeaderText="CuttingProDetailID" DataField="CuttingProDetailID" Visible="false" />
                                    <asp:BoundColumn HeaderText="CuttingProMasterID" DataField="CuttingProMasterID" Visible="false" />
                                    <asp:BoundColumn HeaderText="Joborderid" DataField="Joborderid" Visible="false" />
                                    <asp:BoundColumn HeaderText="JoborderDetailid" DataField="JoborderDetailid" Visible="false" />
                                    <asp:BoundColumn HeaderText="Customer" DataField="Customer" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Customer Po No" DataField="CustomerPoNo" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Receiving No" DataField="ReceivingNo" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Color" DataField="BuyerColor" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Style" DataField="Style" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Qty" DataField="Qty" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="No Of Carton" DataField="NoOfCarton" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Weight" DataField="Weight" Visible="true">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Select" Visible="true">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkSelect" AutoPostBack="false" Checked="true" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="2%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table>
        <tr>
            <td>
                <div style="margin-left: 334px;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Visible="false"
                        Width="120px" /></div>
            </td>
            <td>
                <div style="margin-left: 17px;">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Visible="true"
                        Width="120px" /></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblIssueDtlID" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
