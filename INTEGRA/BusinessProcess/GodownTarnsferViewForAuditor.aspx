<%@ Page Title="Godown Tarnsfer" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="GodownTarnsferViewForAuditor.aspx.vb" Inherits="Integra.GodownTarnsferViewForAuditor" %>
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
                <marquee>Searching Criteria For Voucher No,Fabric Code,From Location,TO Location</marquee>
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
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GodownViewSearch" />
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
                    <Smart:SmartDataGrid ID="dgStoreIssue" runat="server" Width="100%" 
                                 AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                                ShowFooter="False" ForeColor="white" GridLines="both">
                                <Columns>
                                    <asp:BoundColumn HeaderText="ID" DataField="GodownIssueID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Date" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="EntryDatee">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Voucher No." HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="SIVNo">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>

                                     <asp:BoundColumn HeaderText="Challan No." HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="ChallanNo">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>

                                    <asp:BoundColumn HeaderText="From Location" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="Fromlocation">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="TO Location" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="TOLocation">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Code" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="ItemCodee">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Name" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="ItemName">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn> 

                                        <asp:BoundColumn HeaderText="Remarks" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="Remarks">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn> 

                                    <asp:BoundColumn HeaderText="Issue Qty" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="QtyIssue">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                  
                                      <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="false" HeaderText="AuditorStatus"
                            DataField="AuditorStatus">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Auditor Check" Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                            <ItemTemplate>
                                <asp:CheckBox ID="ChkAuditorStatus" OnCheckedChanged="AuditorStatus" AutoPostBack="true"
                                    runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                       
                                </Columns>
                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
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
                    <Smart:SmartDataGrid ID="DgAuthorised" runat="server" Width="100%" 
                                 AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="100" RecordCount="0"
                                ShowFooter="False" ForeColor="white" GridLines="both">
                                <Columns>
                                    <asp:BoundColumn HeaderText="ID" DataField="GodownIssueID" Visible="False">
                                        <HeaderStyle Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Date" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="EntryDatee">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Voucher No." HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="SIVNo">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>

                                     <asp:BoundColumn HeaderText="Challan No." HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="ChallanNo">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>

                                    <asp:BoundColumn HeaderText="From Location" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="Fromlocation">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="TO Location" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="TOLocation">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Code" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="ItemCodee">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Item Name" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="ItemName">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn> 

                                        <asp:BoundColumn HeaderText="Remarks" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="Remarks">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundColumn> 

                                    <asp:BoundColumn HeaderText="Issue Qty" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" DataField="QtyIssue">
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
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
                                <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>



