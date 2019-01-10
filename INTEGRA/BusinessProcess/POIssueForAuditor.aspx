<%@ Page Title="PO Issue" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="POIssueForAuditor.aspx.vb" Inherits="Integra.POIssueForAuditor" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table>
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family: Century Gothic; font-size: 16PX;
                font-weight: bold; color: Blue">
                <marquee>Searching Criteria For PONO,Fabric Code,Manual Challan No,Department</marquee>
            </th>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Search:
            </td>
            <td style="width: 150px;">
                <asp:TextBox ID="txtSummarySearch" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px" Style="margin-left: 12px;"> </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender1" TargetControlID="txtSummarySearch"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetPoIssuedSearchingForAuditor" />
            </td>
             <td>
                <asp:Label ID="lblForm" runat="server" Text="Date Vise :"></asp:Label>
            </td>
            <td >
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
           
            <div style="     margin-left: 0px;">
                <telerik:RadButton ID="btnGetDateWise" runat="server" Text="Search" Skin="WebBlue">
                </telerik:RadButton></div>
           
            </td>
        </tr>
    </table>
    <br />
<table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Auditor Check
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 350PX;">
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueID"
                            DataField="IssueID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueDtlID"
                            DataField="IssueDtlID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Date"
                            DataField="Date" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Item Name"
                            DataField="ItemName" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Item Code"
                            DataField="ItemCodee" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="4%" HeaderText="Department"
                            DataField="DeptDatabaseNamee" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="4%" HeaderText="Manual Challan No"
                            DataField="ManualChallanNo" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO NO" DataField="PONoo">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Recv Qty" DataField="RecvQtyy">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Issue Qty" DataField="IssueQty">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Balance" DataField="Balance"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Remarks" DataField="Remarks">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                           <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                            DataField="AuditorStatus">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="02%" HeaderText="PDF"
                            Visible="true">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="PDF" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="Auditor Check" Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAuditorStatus" OnCheckedChanged="AuditorStatus" AutoPostBack="true"
                                    runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                       
                     
                    </Columns>
                </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table width="100%">
        <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="5" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Auditor Authorised
            </th>
        </tr>
    </table>
    <br />
    <table width="100%">
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; height: 350PX;">
                    <Smart:SmartDataGrid ID="DgAuthorised" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                         <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueID"
                            DataField="IssueID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueDtlID"
                            DataField="IssueDtlID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Date"
                            DataField="Date" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Item Name"
                            DataField="ItemName" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="5%" HeaderText="Item Code"
                            DataField="ItemCodee" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="4%" HeaderText="Department"
                            DataField="DeptDatabaseNamee" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderStyle-Width="4%" HeaderText="Manual Challan No"
                            DataField="ManualChallanNo" Visible="true" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="PO NO" DataField="PONoo">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Recv Qty" DataField="RecvQtyy">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Issue Qty" DataField="IssueQty">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Balance" DataField="Balance"
                            Visible="false">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Remarks" DataField="Remarks">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                          <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                            DataField="AuditorStatus">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Auditor Checked" Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAuditorStatusAuth" OnCheckedChanged="AuditorStatusAuth" AutoPostBack="true"
                                    runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>


