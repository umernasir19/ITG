<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="DPPurchaseOrder.aspx.vb" Inherits="Integra.DPPurchaseOrder" %>

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
            <th colspan="4" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Purchase Order
            </th>
        </tr>

        <tr>
            <td style="width: 110px;">
                PO Type
            </td>
            <td style="width: 110px;">
                <telerik:RadComboBox ID="cmbPoType" runat="server" AutoPostBack="true" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
          
        </tr>



        <tr>
            <td style="width: 110px;">
                PO Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtInvoiceDatee" runat="server" Culture="en-US" Width="100px" style="    margin-top: 4px;">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 110px;">
                Inditex P.O No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="TXTInditexPONo" runat="server" Skin="WebBlue" Width="159px"
                    Visible="true" Style="text-transform: uppercase;">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                PO No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtGRNNO" runat="server" Skin="WebBlue" Width="105px" Visible="true">
                </telerik:RadTextBox>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Supplier"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                DAL No.
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtDalNoO" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Style" Visible="true" ></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpcmbStyle" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="true" Skin="WebBlue"
                            OnSelectedIndexChanged="cmbStyle_SelectedIndexChanged" Visible="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                <%--      DC No.--%>
            </td>
            <td style="width: 110px;">
                <asp:TextBox ID="txtDCNO" runat="server" autocomplete="off" Text="N/A" AutoPostBack="FALSE"
                    Visible="false" Style="margin-left: 0px; width: 150px;"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                Item
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UpcmbItem" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtItemName" runat="server" Skin="WebBlue" Width="275px"
                            ReadOnly="true" style="" Visible="true" TextMode ="MultiLine" >
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <asp:UpdatePanel ID="pnlUnit1" UpdateMode="Conditional" runat="server" Visible="true">
                <ContentTemplate>
                    <td style="width: 128px; height: 30px;">
                        <asp:Label ID="Label3" runat="server" Text="Unit"></asp:Label>
                    </td>
                    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                        <telerik:RadComboBox ID="cmbUnit" runat="server" AutoPostBack="false" Skin="WebBlue">
                        </telerik:RadComboBox>
                        <asp:ImageButton ID="btnAddUnit" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                            margin-bottom: -9px;"></asp:ImageButton>
                    </td>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="pnlUnit2" UpdateMode="Conditional" runat="server" Visible="false">
                <ContentTemplate>
                    <td style="width: 128px; height: 30px;">
                        <asp:Label ID="Label6" runat="server" Text="Unit"></asp:Label>
                    </td>
                    <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                        <telerik:RadTextBox ID="txtAddUnit" runat="server" Style="text-transform: uppercase;"
                            Visible="true" Skin="WebBlue" Width="159px">
                        </telerik:RadTextBox>
                        <asp:ImageButton ID="btnSaveUnit" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="height: 25px; margin-bottom: -9px;"></asp:ImageButton>
                    </td>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%-- <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label3" runat="server" Text="Unit"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbUnit" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>--%>
        </tr>
        <tr>
            <td style="width: 110px;">
                Quantity
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UptxtQuantity" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtQuantity" runat="server" Skin="WebBlue" AutoPostBack="true"
                            Width="105px" Visible="true" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label4" runat="server" Text="Rate"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UptxtRate" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtRate" runat="server" Skin="WebBlue" Width="105px"
                            Visible="true" Type="Number" NumberFormat-DecimalDigits="2" AutoPostBack="true">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                Amount
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UptxtAmount" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtAmount" runat="server" Skin="WebBlue" Width="105px"
                            Visible="true" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="Label5" runat="server" Text="Del. Date"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtDelDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr>
            <td style="width: 128px; height: 30px;">
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadButton ID="btnAddAccessories" runat="server" Width="50px" Text="Add"
                    Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <asp:Label ID="lblDetailID" runat="server" Visible="false" Text="0"></asp:Label>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="dgPODETAIL" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="true" PageSize="50" AllowAutomaticDeletes="false"  OnItemCommand="dgPODETAIL_ItemCommand">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="DPPODetailID" DataField="DPPODetailID" Display="FALSE">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DPRNDID" DataField="DPRNDID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Style" DataField="Style" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Item Name" DataField="ItemName" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="12%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Unit" DataField="UnitID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="1%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="2%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Rate" DataField="Rate">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="3%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Amount" DataField="Amount" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="2%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Del.Date" DataField="DelDate" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="6%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DC NO" DataField="DCNO" Display="FALSE">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="8%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="Edit" Text="Edit" CommandName="Edit" ConfirmTextFormatString="Are You Sure You want to Edit Record"
                                HeaderStyle-Width="2%" ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                         
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
            <td>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:CheckBox ID="ChkIsActive" runat="server" Font-Bold="True" Visible="false" Text="Is Active" />
            </td>
            <td>
            </td>
            <td colspan="2" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <td>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
         <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
