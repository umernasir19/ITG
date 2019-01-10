<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="FabricIssueToDept.aspx.vb" Inherits="Integra.FabricIssueToDept" %>

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
    <table>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Fabric Issue
            </th>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Issue Voucher No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtIssueVoucherNo" runat="server" Skin="WebBlue" Width="105px"
                    Visible="true" ReadOnly="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Issue Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtIssueDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 110px;">
                Issue Time
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtIssueTime" runat="server" Skin="WebBlue" Width="105px"
                    Visible="true" ReadOnly="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                DC No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtDCNo" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="false" Style="text-transform: uppercase;">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Dept.
            </td>
            <td style="width: 250px;">
                <telerik:RadComboBox ID="CmbDept" runat="server" AutoPostBack="TRUE" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            <td style="width: 110px;">
                DAL No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtDalNo" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNo" />
            </td>
            <td style="">
                <asp:Label ID="lblFabricMstId" runat="server" Text="DalNo" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Available Fabric
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtAvailableFab" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 110px;">
                Issue Qty.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtIssueQty" runat="server" autocomplete="off" AutoPostBack="FALSE"
                    onkeypress="return isNumericKeyy(event);" Style="margin-left: 0px; width: 150px;"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <%-- <telerik:RadButton ID="btnAdd" runat="server" Text="Add" Width="50px" Skin="WebBlue">
                </telerik:RadButton>--%>
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add" Skin="WebBlue" Width="50px">
                </telerik:RadButton>
            </td>
            <asp:Label ID="lblDetailID" runat="server" Text="0" Visible="false"></asp:Label>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="dgPORecv" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="true" PageSize="50" AllowAutomaticDeletes="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="DPPOIssueDtlID" DataField="DPPOIssueDtlID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DeptDatabaseId" DataField="DeptDatabaseId" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Dept. Name" DataField="DeptDatabaseName" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Dal No" DataField="DalNo" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="FabricMstID" DataField="FabricDbMstID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Available Fab." DataField="AvailableFab">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Issue Qty." DataField="IssueQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="Edit" Text="Edit" CommandName="Edit" ConfirmTextFormatString="Are You Sure You want to Edit Record"
                                HeaderStyle-Width="2%" ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Display="true" Text="" CommandName="Delete"
                                ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
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
            <td>
            </td>
            <td>
            </td>
            <td colspan="1" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
