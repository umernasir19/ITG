<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="IssueProcessView.aspx.vb" Inherits="Integra.IssueProcessView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<table width="100%">
        <tr>
            <td style="width: 100%">
            </td>
            <td style="height: 35px">
                <div class="txt_newwww" style="width: 140px; margin-left: -830px;">
                    <%--margin-left: -435px;
                    Style
                </div>
            </td>
            <td style="height: 35px;">
                <asp:DropDownList ID="cmbStyle" Width="120" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: -675px;">
                </asp:DropDownList>
            </td>
            <td style="height: 35px">
                <div class="txt_newwww" style="width: 140px; margin-left: -495px;">
                    <asp:Label ID="lblItemFab" runat="server" Visible="true" Text=""></asp:Label>
                </div>
            </td>
            <td style="height: 35px; margin-left: 10px;">
                <asp:DropDownList ID="cmbItem" Width="120px" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: -345px;">
                </asp:DropDownList>
            </td>
            <td style="height: 35px">
                <div class="txt_newwww" style="width: 140px; margin-left: -170px;">
                    Department
                </div>
            </td>
            <td style="height: 35px; margin-left: 10px;">
                <asp:DropDownList ID="cmbDepartment" Width="120px" CssClass="combo" AutoPostBack="true"
                    runat="server" Style="margin-left: -23px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>--%>
    <table>
        <tr>
            <td style="width: 15%">
         <%--       Enter Item Name:--%>
            </td>
            <td style="width: 20%">
                <asp:TextBox ID="txtShowMe" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px" ToolTip="Item Name" Visible ="false" > </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="Accessories" />
            </td>
            <td style="width: 10%">
                <asp:UpdatePanel id="btnSearchUPdate" UpdateMode="Conditional" runat="server">
                    <contenttemplate>
<asp:button id="btnSearch"  runat="server" CssClass="button" Text="Filter" width="80" visible="false"></asp:button>
 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
 
</triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:Button ID="btnAll" runat="server" CssClass="button" Text="Show All" Width="80" Visible ="false" >
                </asp:Button>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 35px;">
            <td style="width: 50%" align="right">
                <asp:Button ID="cmdAdd" runat="server" CssClass="button" Text="ADD ISSUE" Width="150">
                </asp:Button>
            </td>
        </tr>
        <tr style="height: 5px">
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="1000"
                    ShowFooter="True" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueProcessID"
                            DataField="IssueProcessID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="IssueProcessDtlID"
                            DataField="IssueProcessDtlID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Date"
                            DataField="Date" visible="true" />
                              <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Item Name"
                            DataField="ItemName" visible="true" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Item Code"
                            DataField="ItemCodee" visible="true" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Department"
                            DataField="DeptDatabaseNamee" visible="true" />
                              <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Manual Challan No"
                            DataField="ManualChallanNo" visible="true" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="PO NO" DataField="PONoo">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Recv Qty" DataField="RecvQty">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Issue Qty" DataField="IssueQty">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Balance" DataField="Balance" Visible ="false" >
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Remarks" DataField="Remarks">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                       <%-- <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Style" DataField="Style">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>--%>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" visible="false" HeaderStyle-Width="02%"
                            HeaderText="EDIT">
                            <itemtemplate>																	
						<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
						</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            visible="FALSE">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            visible="true">
                            <itemtemplate>								
	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return"
                            Visible="true">
                            <ItemTemplate>
                             <asp:LinkButton id="lnkReturn" tooltip="Click here to Go Return" text="Return" CommandName="Return"  runat="server"></asp:LinkButton>
                              
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

