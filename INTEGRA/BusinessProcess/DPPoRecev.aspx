<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPPoRecev.aspx.vb" Inherits="Integra.DPPoRecev" %>

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
                Fabric Receive
            </th>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Receive Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtReceiveDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 110px;">
                Receive Time
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtReceiveTime" runat="server" Skin="WebBlue" Width="105px"
                    Visible="true" ReadOnly="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                GRN No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtGRNNO" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="true">
                </telerik:RadTextBox>
            </td>
            <td style="width: 110px;">
                Supplier.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="true" Skin="WebBlue"
                    OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
           <td style="width: 110px;">
                DC No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtDCNo" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="false" style=" text-transform :uppercase ;">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                PO No.
            </td>
            <td style="width: 110px;">
                <telerik:RadComboBox ID="CmbPONO" runat="server" AutoPostBack="TRUE" Skin="WebBlue"
                    OnSelectedIndexChanged="CmbPONO_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td style="width: 110px;">
                DAL No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtDalNo" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="">
                <asp:Label ID="LBLDalNo" runat="server" Text="DalNo" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Item
            </td>
            <td style="width: 110px;">
                <telerik:RadComboBox ID="CmbItem" runat="server" AutoPostBack="true" Skin="WebBlue"
                    OnSelectedIndexChanged="CmbItem_SelectedIndexChanged">
                </telerik:RadComboBox>
            </td>
            <td style="width: 110px;">
                Style.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtStyle" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Unit
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtUnit" runat="server" autocomplete="off" AutoPostBack="true" Style="margin-left: 0px;
                    width: 150px;" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 110px;">
                PO Qty.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtPoQty" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                PO Received Qty
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtPOReceivedQty" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="width: 110px;">
                Receive Qty.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtReceivQty" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;"></asp:TextBox>
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
            <asp:Label ID ="lblDetailID" runat ="server"  Text ="0" Visible ="false" ></asp:Label>
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
                            <telerik:GridBoundColumn HeaderText="POReceiveDtlID" DataField="POReceiveDtlID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DPPOMstID" DataField="DPPOMstID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="PO NO" DataField="PONO" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Dal No" DataField="Dal" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="FabricMstID" DataField="FabricMstID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Item Name" DataField="ItemName">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DPPODtlID" DataField="DPPODtlID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="PO Qty" DataField="POQty" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="PO Received Qty" DataField="POReceivedQty" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Received Qty" DataField="ReceivedQty" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                             <telerik:GridButtonColumn UniqueName="Edit" Text="Edit" CommandName="Edit"
                                ConfirmTextFormatString="Are You Sure You want to Edit Record" HeaderStyle-Width="2%"
                                ButtonType="ImageButton">
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
    </table><br />
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
