<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPWashReceive.aspx.vb" Inherits="Integra.DPWashReceive" %>

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
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Wash Receive
            </th>
        </tr>
        <tr>
            <td style="width: 110px;">
                Wash Recv.Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtWashRecvDatee" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblBuyer" runat="server" Text="Wash Recv.No."></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtWashRecvNo" runat="server" Skin="WebBlue" Width="105px"
                    Visible="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                Wash No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtWashNo" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="SearchWashNo" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtWashNo" />
                <asp:Label ID="lblWashMstId" runat="server" Visible="false"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                DAL No.
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UpDAl" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbDalNo" runat="server" AutoPostBack="true" Skin="WebBlue"
                            OnSelectedIndexChanged="cmbDalNo_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Style"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpcmbStyle" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="true" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                Wash Type
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UpcmbWashType" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbWashType" runat="server" AutoPostBack="true" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Qty"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UptxtQty" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtQty" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                            ReadOnly="true">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <asp:Label ID="Label3" runat="server" Text="Received Qty"></asp:Label>
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UptxtReceivedQty" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtReceivedQty" runat="server" Skin="WebBlue" Width="105px"
                            Visible="true" ReadOnly="true">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
                Receive Qty
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UptxtReceiveQuantity" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtReceiveQuantity" AutoPostBack="true" runat="server"
                            Skin="WebBlue" Width="105px" Visible="true" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <asp:Label ID="Label4" runat="server" Text="Reject Qty"></asp:Label>
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UptxtRejectQty" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtRejectQty" runat="server" Skin="WebBlue" Width="105px"
                            Visible="true" ReadOnly="false">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
            </td>
            <td style="width: 110px;">
            </td>
            <td style="width: 128px; height: 30px;">
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadButton ID="btnAddRecv" runat="server" Text="Add" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="dgWashRecv" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="WashRecvDtlID" DataField="WashRecvDtlID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="WashTypeID" DataField="WashTypeID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DalID" DataField="DalID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="StyleID" DataField="StyleID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Wash Type" DataField="WashType">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Dal No" DataField="DalNo">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Qty" DataField="Qty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Received Qty" DataField="ReceivedQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Receive Quantity" DataField="ReceiveQuantity">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Reject Quantity" DataField="RejectQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
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
        </tr>
    </table>
    <table>
        <tr>
            <td>
            </td>
            <td colspan="2" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
