<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="ECPSamplingEntry.aspx.vb" Inherits="Integra.ECPSamplingEntry" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Sampling Entry Sheet
            </th>
        </tr>
        <tr>
            <td align="right">
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
                <telerik:RadButton ID="btnAddMore" runat="server" Text="Add More" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblEntryDate" runat="server" Text="Sample Recv. Date" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtEntryDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblCustomer" runat="server" Text="Customer" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbCustomer" runat="server" AutoPostBack="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label1" runat="server" Text="Buying Dept." Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtBuyingDept" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblSupplier" runat="server" Text="Supplier" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblStyleNo" runat="server" Text="Style No" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtStyleNo" runat="server" Width="100px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblUser" runat="server" Text="Merchandiser" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbUser" runat="server" AutoPostBack="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="SUBMISSIONS" Font-Names="Calibri" Font-Bold="true"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="/COMMENTS:" Font-Names="Calibri" Font-Bold="true"
                    Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label5" runat="server" Text="Date" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td>
                <telerik:RadDatePicker ID="txtDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label2" runat="server" Text="Sumbission" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbSumbission" runat="server" Height="" AutoPostBack="True"
                            MarkFirstMatch="true" EnableLoadOnDemand="true" Skin="WebBlue" TabIndex="6">
                            <Items>
                                <telerik:RadComboBoxItem Text="1st Submission" Value="0" />
                                <telerik:RadComboBoxItem Text="2nd Submission" Value="1" />
                                <telerik:RadComboBoxItem Text="3rd Submission" Value="2" />
                                <telerik:RadComboBoxItem Text="4th Submission" Value="3" />
                                <telerik:RadComboBoxItem Text="5th Submission" Value="4" />
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblNoOfPeices" runat="server" Text="Pcs" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadNumericTextBox ID="txtNoOfPeices" Value="1" Width="60px" runat="server"
                    Font-Bold="true" Skin="WebBlue" BackColor="#80BFFF">
                    <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblTypeofSampling" runat="server" Text="Type of Sampling" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbTypeofSampling" runat="server" AutoPostBack="True" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="Label6" runat="server" Text="Sample Location" Font-Names="Calibri"
                    Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtSampleLocation2" runat="server" Width="200px" Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblStatus" runat="server" Text="Status" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbStatus" runat="server" Height="" AutoPostBack="True"
                            MarkFirstMatch="true" EnableLoadOnDemand="true" Skin="WebBlue" TabIndex="6">
                            <Items>
                                <telerik:RadComboBoxItem Value="0" Text="Pass" />
                                <telerik:RadComboBoxItem Value="1" Text="Fail" />
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblProgress" runat="server" Text="Progress" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 166px; height: 30px;">
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbProgress" runat="server" Height="" AutoPostBack="True"
                            MarkFirstMatch="true" EnableLoadOnDemand="true" Skin="WebBlue" TabIndex="6">
                            <Items>
                                <telerik:RadComboBoxItem Text="--" Value="0" />
                                <telerik:RadComboBoxItem Text="Recieved from Supplier" Value="1" />
                                <telerik:RadComboBoxItem Text="Sent to Buyer" Value="2" />
                                <telerik:RadComboBoxItem Text="Buyer Accept" Value="3" />
                                <telerik:RadComboBoxItem Text="Buyer Reject" Value="4" />
                            </Items>
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="center" style="width: 128px; height: 30px;">
                <asp:Label ID="lblRemarks" runat="server" Text="Remarks" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="width: 666px; height: 30px;">
                <telerik:RadTextBox ID="txtRemarks" Width="600px" TextMode="MultiLine" runat="server"
                    Skin="WebBlue">
                </telerik:RadTextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
                    PagerOtherPageCssClass="" PageSize="50" RecordCount="0" ShowFooter="False" SortedAscending="yes"
                    ForeColor="white" GridLines="Both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ECPSamplingDetailID"
                            DataField="ECPSamplingDetailID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="TypeOfSamplingID"
                            DataField="TypeOfSamplingID" Visible="False" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Date" DataField="DateeN"
                            DataFormatString="{0:MM/dd/yy}">
                            <HeaderStyle Width="08%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Pcs" DataField="NoOfPieces">
                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Type of Sampling" DataField="TypeName">
                            <HeaderStyle Width="8%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Sample Location" DataField="SampleLocation">
                            <HeaderStyle Width="8%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Status" DataField="Status">
                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Progress" DataField="Progress">
                            <HeaderStyle Width="8%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderText="Submission" DataField="Submission">
                            <HeaderStyle Width="8%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Remarks"
                            DataField="Remarks">
                            <HeaderStyle Width="25%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
