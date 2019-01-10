<%@ Page Title="Wash Issue Add" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="WashIssueAdd.aspx.vb" Inherits="Integra.WashIssueAdd" %>

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
                Wash Issue
            </th>
        </tr>
        <tr>
            <td style="width: 110px;">
                Wash Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtWashDatee" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 128px; height: 30px;">
                <asp:Label ID="lblBuyer" runat="server" Text="Wash No."></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtWashNo" runat="server" Skin="WebBlue" Width="105px" Visible="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                Wash Type
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UpType" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbType" runat="server" AutoPostBack="false" Skin="WebBlue">
                        </telerik:RadComboBox>
                        <telerik:RadTextBox ID="txtType" runat="server" Width="100px" Skin="WebBlue" Visible="false">
                        </telerik:RadTextBox>
                        <%--      <telerik:RadButton ID="btnAddCom" runat="server" Text="Save" Skin="WebBlue">
                                <image imageurl="~/Images/Add.png"></image>
                            </telerik:RadButton>--%>
                        <asp:ImageButton ID="btnAddType" runat="server" ImageUrl="~/Images/Add.png" Style="height: 25px;
                            margin-bottom: -9px;"></asp:ImageButton>
                        <asp:ImageButton ID="BtnSaveType" runat="server" ImageUrl="~/Images/SaveButton.jpg"
                            Style="height: 25px; margin-bottom: -9px;" Visible="false"></asp:ImageButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                DSR No.
            </td>
            <td style="height: 30px">
                <asp:TextBox ID="txtDSRNo" runat="server" autocomplete="off" AutoPostBack="true"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="autoComplete2" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="SearchDSRNo" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDSRNo" />
                <asp:Label ID="LBLSampleReceiveID" runat="server" Text="FabricIssueID" Visible="false"></asp:Label>
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
                <asp:Label ID="Label2" runat="server" Text="Style"></asp:Label>
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpcmbStyle" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="true" Skin="WebBlue"
                            OnSelectedIndexChanged="cmbStyle_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <%--<td style="width: 110px;">
                Fabric Recv. No
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UpcmbFRecvNo" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbFRecvNo" runat="server" AutoPostBack="true" Skin="WebBlue"  OnSelectedIndexChanged="cmbFRecvNo_SelectedIndexChanged">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>--%>
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
                <asp:Label ID="Label3" runat="server" Text="Issued Qty"></asp:Label>
            </td>
            <td style="width: 110px;">
                <asp:UpdatePanel ID="UptxtIssuedQty" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtIssuedQty" runat="server" Skin="WebBlue" Width="105px"
                            Visible="true" ReadOnly="true">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 128px; height: 30px;">
                Issue Qty
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UptxtIssueQuantity" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtIssueQuantity" AutoPostBack="true" runat="server"
                            Skin="WebBlue" Width="105px" Visible="true" Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
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
                <telerik:RadButton ID="btnAddAccessories" runat="server" Text="Add" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="dgWashIssue" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" OnDeleteCommand="dgWashIssue_DeleteCommand">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="WashDtlID" DataField="WashDtlID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="WashTypeID" DataField="WashTypeID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Wash Type" DataField="WashType">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="FabricDBMstID" DataField="FabricDBMstID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Dal No" DataField="DalNo">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="TblRNDID" DataField="TblRNDID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DPSampleReceiveID" DataField="DPSampleReceiveID"
                                Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Sample Recv Qty" DataField="SampleRecvQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Issued Qty" DataField="IssuedQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Issue Qty" DataField="IssueQty">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="DSR NO" DataField="DSRNO">
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
