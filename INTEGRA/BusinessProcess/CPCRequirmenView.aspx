﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CPCRequirmenView.aspx.vb" Inherits="Integra.CPCRequirmenView" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
        <tr style ="height :34px;">
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add Requirment" Width="180">
                </asp:Button>
            </td>
        </tr>
          <tr >
            <td>
                <Smart:SmartDataGrid ID="dgCPCRequirment" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                    AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                    PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                    ShowFooter="True" sortedascending="yes" ForeColor="white" GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="5%" HeaderText="CPRequirmentBID"
                            DataField="CPRequirmentBID" Visible="false">
                            <HeaderStyle Width="10%" HorizontalAlign="Left" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Requirment"
                            DataField="CPRequirementB">
                            <HeaderStyle Width="10%" HorizontalAlign="center" />
                        </asp:BoundColumn>
                       

                       <ASP:TEMPLATECOLUMN HeaderText="Edit" Visible ="true" >
                                    <itemstyle horizontalalign="Center" />
									<ITEMTEMPLATE>
<asp:HyperLink id="lnkEdit" Runat="server" NavigateUrl='<%# "CPCRequirmenEntry.aspx?lCPRequirmentBID=" &amp; DataBinder.Eval(Container.DataItem,"CPRequirmentBID")%>' Enabled="true">
											Edit
										</asp:HyperLink> 
</ITEMTEMPLATE>
                                    <headerstyle width="10%" />
								</ASP:TEMPLATECOLUMN>
                                 <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"  visible="true">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" OnClientClick="return confirm('OK to Delete?');" CommandName="Remove" runat="server"  ></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>

                    </Columns>
                    <PagerStyle HorizontalAlign="NotSet" />
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
