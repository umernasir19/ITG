<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="CargoReleaseView.aspx.vb" Inherits="Integra.CargoReleaseView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">




<br />
    <table>
       
        <tr>
        <%--    <td align="left">
                Invoice NO :
            </td>--%>
            <td>
                <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="textbox" Visible ="false"  AutoPostBack="true" Width="120px" style=" margin-left: 56px;" ></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtInvoiceNo"
                    ServicePath="~/AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="CargoInv" />
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Search" Width="100px"
                    Visible="false"></asp:Button>
            </td>
            <td>
            </td>
            <td>
                <asp:LinkButton ID="btnMoreSearch" CssClass="ErrorMsg" runat="server" Visible ="false" >Invoice Search,...Click here.</asp:LinkButton>
            </td>
        </tr>
    </table>

    <table width="100%">
        <tr style ="width :50px;">
            <td align="right">
                <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="Add Export" Width="110">
                </asp:Button>
            </td>
        </tr>
      </table> <br /> <table  width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgCagro" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                    ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="Both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="Shipment NO"
                            SortExpression="CargoID" DataField="CargoID" Visible="False">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="15%" HeaderText="Entry Date"
                            SortExpression="CreationDatee" DataField="CreationDatee">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="7%" HeaderText="Invoice NO"
                            SortExpression="InvoiceNo" DataField="InvoiceNo">
                            <HeaderStyle Width="7%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="15%" HeaderText="Shipment Date[ETD]"
                            SortExpression="InvoiceDateF" DataField="InvoiceDateF">
                            <HeaderStyle Width="15%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="7%" HeaderText="Invoice Value"
                            SortExpression="InvoiceValuee" DataField="InvoiceValuee">
                            <HeaderStyle Width="7%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible ="false"  HeaderStyle-Width="15%" HeaderText="Mode"
                            SortExpression="Terms" DataField="Terms">
                            <HeaderStyle Width="5%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Edit">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "CargoReleaseNew.aspx?IcargoID=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")%>'
                                    Enabled="true">
											Edit
                                </asp:HyperLink>
                                <br />
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "CargoReleaseNew.aspx?IcargoID=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&Type=Copy"%>'
                                    Enabled="true" Visible="false">
											Copy
                                </asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="16%" HeaderText="Sales Voucher"
                            Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkSV" runat="server" CommandName="SVOUCHER"  NavigateUrl='<%# "~/Accounts/SVEntry.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")%>'>
											Sales Voucher
                                </asp:HyperLink>
                                <asp:ImageButton ID="lnkPDFSales" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="SVPDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="Inspection Certificate"
                            Visible="true">
                            <ItemTemplate>
                                <%--	<asp:HyperLink id="lnkDirectRelease"  NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=DirectRelease"%>' Runat="server">
											Inspection Certificate
										</asp:HyperLink>--%>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="Custom Invoice"
                            Visible="true">
                            <ItemTemplate>
               
                                <asp:ImageButton ID="lnkPDFF" ToolTip="Click here to download Custom Invoice" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDFF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="Commercial Invoice"
                            Visible="true">
                            <ItemTemplate>
               
                                <asp:ImageButton ID="lnkPDFFF" ToolTip="Click here to download Custom Invoice" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDFFF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>


                          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="Custom Packing List"
                            Visible="true">
                            <ItemTemplate>
               
                                <asp:ImageButton ID="lnkPDFFFF" ToolTip="Click here to download Custom Packing List" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDFFFF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>


                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Cargo Release"
                            Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkCargoRelease" Enabled="False" NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=CagroRelease"%>'
                                    runat="server">
											Cargo Release
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Shipment Confirmation"
                            Visible="False">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkConfirmation" Enabled="False" NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=Confirmation"%>'
                                    runat="server">
											Shipment Confirmation
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" HeaderText="tblJVMstId"
                            DataField="tblJVMstId" Visible ="false" >
                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                        </asp:BoundColumn>


                         <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Consumption" Visible ="false" >
                            <ItemTemplate>
                            
                                <asp:ImageButton ID="lnkCon" ToolTip="Click here to Acc" ImageUrl="~/Images/green.png"
                                    CommandName="Con" runat="server"></asp:ImageButton>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="lnkConPDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="ConPDF" runat="server" Visible="true"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>


                          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Style Description" Visible ="true" >
                            <ItemTemplate>
                            <asp:ImageButton ID="lnkExportDocument" ToolTip="Click here to Export Document" ImageUrl="~/Images/green.png"
                                    CommandName="ExportDocument" runat="server"></asp:ImageButton>
                                 </ItemTemplate>
                        </asp:TemplateColumn>

                           <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Export Documents" Visible ="false" >
                            <ItemTemplate>
                            <asp:ImageButton ID="lnkCertificate" ToolTip="Click here to Export Document" ImageUrl="~/Images/green.png"
                                    CommandName="Certificate" runat="server"></asp:ImageButton>
                                 </ItemTemplate>
                        </asp:TemplateColumn>


                         <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="joborderid"
                            SortExpression="joborderid" DataField="joborderid" Visible="False">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="center" width="100%" style="height: 22px">
                <asp:Button ID="Button1" runat="server" Visible="false" CssClass="button" Text="Checking Currency"
                    Width="140px"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
