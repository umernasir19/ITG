<%@ Page Title="Commercial Packing List" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CommercialPackingList.aspx.vb" Inherits="Integra.CommercialPackingList" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: 'Calibri'; font-size: 17px; font-weight: bold;
                font-style: inherit; color: #336699; font-variant: inherit; height: 29px;" valign="bottom">
                Commercial Packing List
            </th>

        </tr>
        <tr>
         <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/box.jpg" Height="48px" Width="70px">
                    </asp:Image>
                </td>
        </tr>
    </table>
    <table>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label1" runat="server" Text="Invoice #" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px; width: 195px">
                <asp:UpdatePanel ID="UpcmbInvoiceNo" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbInvoiceNo" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="lblInvoiceNo" runat="server" Text="Sr No" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpcmbSrNo" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbSrNo" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label4" runat="server" Text="Color" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpcmbPONO" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbColor" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label9" runat="server" Text="Style" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UptxtStyle" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="txtStyle" runat="server" Skin="WebBlue" ReadOnly="true">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label2" runat="server" Text="Size" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px; width: 195px">
                <asp:UpdatePanel ID="UpcmbSize" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadComboBox ID="cmbSize" runat="server" Skin="WebBlue" AutoPostBack="true">
                        </telerik:RadComboBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label3" runat="server" Text="Quantity" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UptxtQuantity" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtQuantity" runat="server" Skin="WebBlue" Width="100px"
                            Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label5" runat="server" Text="PCS/CTN" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpTXTPcsCtn" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="TXTPcsCtn" runat="server" Skin="WebBlue" Width="100px"
                            Type="Number" NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label6" runat="server" Text="Carton From" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px; width: 195px">
                <asp:UpdatePanel ID="UptxtCartonFrom" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtCartonFrom" runat="server" Skin="WebBlue" Width="100px"
                            Type="Number" NumberFormat-DecimalDigits="2" AutoPostBack="true">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label7" runat="server" Text="Carton To" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UptxtCartonTo" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadNumericTextBox ID="txtCartonTo" OnTextChanged="txtCartonTo_TextChanged"
                            AutoPostBack="true" runat="server" Skin="WebBlue" Width="100px" Type="Number"
                            NumberFormat-DecimalDigits="2">
                        </telerik:RadNumericTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="width: 92px; height: 39px;">
                <asp:Label ID="Label8" runat="server" Text="CTNS" Font-Names="Calibri" Font-Size="Medium"></asp:Label>
            </td>
            <td style="height: 39px">
                <asp:UpdatePanel ID="UpTXTCTNS" runat="server" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <telerik:RadTextBox ID="TXTCTNS" runat="server" Skin="WebBlue" ReadOnly="true" Width="100px">
                        </telerik:RadTextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td >
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add" Skin="WebBlue" width="70px" >
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="width: 930px;">
                    <asp:UpdatePanel ID="UpdgPackingListDetail" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <telerik:RadGrid ID="dgPackingListDetail" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                                Skin="WebBlue" Visible="False" PageSize="50">
                                <MasterTableView>
                                    <Columns>
                                        <telerik:GridBoundColumn HeaderText="CommercialPackingListDtlid." DataField="CommercialPackingListDtlid"
                                            Display="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Carton From" DataField="CartonFrom">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                    
                                        <telerik:GridBoundColumn HeaderText="Carton To" DataField="CartonTo">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="CTNS" DataField="CTNS">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="JobOrderDetailID" HeaderText="JobOrderDetailID"
                                            Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Buyer Color" DataField="BuyerColor">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Style" DataField="Style">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StyleAssortmentDetailID" HeaderText="StyleAssortmentDetailID"
                                            Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Size" DataField="Size">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="Quantity" DataField="Quantity">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn HeaderText="PCS CTN" DataField="PCSCTN">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
        </tr>
    </table>
    <br />
       <table align="center" style="width: 100%;">
            <tr>
                <td valign="middle">
                    <br />
                </td>
                <td valign="middle" style="width: 60px; height: 70px;">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue" width="70px">
                    </telerik:RadButton>
                </td>
                <td valign="middle" style="width: 60px; height: 70px;">
                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue" width="70px">
                    </telerik:RadButton>
                </td>
                <td valign="middle" style="width: 60px; height: 70px;">
                    &nbsp;
                </td>
            </tr>
        </table>


</asp:Content>
