<%@ Page Title="BIInstView" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="BIInstView.aspx.vb" Inherits="Integra.BIInstView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="left">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="ADD B/L INST." Width="110"
                    Visible="true"></asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                    ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="Both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="BIInstMstID"
                            SortExpression="BIInstMstID" DataField="BIInstMstID" Visible="False">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="InvoiceID"
                            SortExpression="InvoiceID" DataField="InvoiceID" Visible="False">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                     

                         <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="7%" HeaderText="BL No."
                            DataField="BLNO">
                            <HeaderStyle Width="7%" HorizontalAlign="center" />
                        </asp:BoundColumn>


                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="7%" HeaderText="Form E.No."
                            DataField="FormENo">
                            <HeaderStyle Width="7%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Form E.Date"
                            DataField="Datee">
                            <HeaderStyle Width="15%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="7%" HeaderText="From"
                            DataField="From">
                            <HeaderStyle Width="7%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="To"
                            DataField="Too">
                            <HeaderStyle Width="5%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="15%" HeaderText="Qty Pcs."
                            SortExpression="QtyPcs" DataField="QtyPcs">
                            <HeaderStyle Width="5%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Edit">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl='<%# "BLInstructionAdd.aspx?BIInstMstID=" &amp; DataBinder.Eval(Container.DataItem,"BIInstMstID")%>'
                                    Enabled="true">
											Edit
                                </asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Width="5%" />
                        </asp:TemplateColumn>
                        <%--   <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="16%" HeaderText="Sales Voucher"
                            Visible="true">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkSV" runat="server" CommandName="SVOUCHER"  NavigateUrl='<%# "~/Accounts/SVEntry.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")%>'>
											Sales Voucher
                                </asp:HyperLink>
                                <asp:ImageButton ID="lnkPDFSales" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="SVPDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <%--   <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="Inspection Certificate"
                            Visible="true">
                            <ItemTemplate>
                                <%--	<asp:HyperLink id="lnkDirectRelease"  NavigateUrl='<%# "..\Reports/Report.aspx?lcargorId=" &amp; DataBinder.Eval(Container.DataItem,"CargoID")&"&ReportName=DirectRelease"%>' Runat="server">
											Inspection Certificate
										</asp:HyperLink>--%>
                        <%--     <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <%-- <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="Custom Invoice"
                            Visible="true">
                            <ItemTemplate>
               
                                <asp:ImageButton ID="lnkPDFF" ToolTip="Click here to download Custom Invoice" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDFF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="7%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDFFF" ToolTip="Click here to download Report" ImageUrl="~/Images/pdfIcon.png"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <%--   <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderText="Cargo Release"
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
                        </asp:TemplateColumn>--%>
                        <%--      <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="2%" HeaderText="tblJVMstId"
                            DataField="tblJVMstId" Visible ="false" >
                            <HeaderStyle Width="2%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        --%>
                        <%--     <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Consumption" Visible ="false" >
                            <ItemTemplate>
                            
                                <asp:ImageButton ID="lnkCon" ToolTip="Click here to Acc" ImageUrl="~/Images/green.png"
                                    CommandName="Con" runat="server"></asp:ImageButton>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="lnkConPDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="ConPDF" runat="server" Visible="true"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>--%>
                        <%--
                         <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="joborderid"
                            SortExpression="joborderid" DataField="joborderid" Visible="False">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>--%>
                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
