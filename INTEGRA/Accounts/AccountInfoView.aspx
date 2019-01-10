<%@ Page Title="Account Info View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="AccountInfoView.aspx.vb" Inherits="Integra.AccountInfoView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <table width="100%">
        <tr>
            <td style="height: 13px">
                <asp:LinkButton ID="LnkbBack" runat="server">Back</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <div class="heading">
                Accounts Info View</div>
            <br />
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="false" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <asp:BOUNDCOLUMN HeaderText="ChartOfAccountID" DataField="ChartOfAccountID" visible="False">
                            <headerstyle width="5%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Account Code" DataField="Accountcode" SortExpression="Accountcode">
                            <headerstyle horizontalalign="Center" width="5%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Account Name" DataField="AccountName" SortExpression="AccountName">
                            <headerstyle horizontalalign="Center" width="5%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN HeaderText="Account Type" DataField="AccountTypee" SortExpression="AccountTypee">
                            <headerstyle horizontalalign="Center" width="5%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:BOUNDCOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="EDIT" visible="False">
                            <itemtemplate>
<asp:ImageButton id="lnkEdit" runat="server" ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" tooltip="Click here to edit"></asp:ImageButton> 
</itemtemplate>
                            <headerstyle width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="REMOVE" visible="False">
                            <itemtemplate>
									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									
</itemtemplate>
                            <headerstyle width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="PDF" visible="false">
                            <itemtemplate>
								
	                    <asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
					 	
</itemtemplate>
                            <headerstyle width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                    <PagerStyle CssClass="GridPagerStyle" HorizontalAlign="Right" Mode="NumericPages" />
                    <AlternatingItemStyle CssClass="GridAlternativeRow" />
                    <ItemStyle CssClass="GridRow" />
                    <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

