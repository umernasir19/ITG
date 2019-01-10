<%@ Page Title="Planning View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Fabric.aspx.vb" Inherits="Integra.Fabric" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr class="heading">
            <td>
                &nbsp; <b><asp:Label ID="lblHeading" runat ="server" text="FABRIC/ACCESSORIESE PLANNING"></asp:Label></b></td>
        </tr>
        <tr height="34px">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgViewMaster" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <%--	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleID"
								  DataField="StyleID" visible="false" />--%>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Joborderid"
                            DataField="Joborderid" visible="False" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="SR No" DataField="SRNo">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="CUSTOMER" DataField="CustomerName">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="STYLE" DataField="Style"
                            visible="true">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="ORDER DATE" DataField="OrderRecvDatee">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="STYLE SHIP DATE"
                            DataField="StyleShipmentDatee">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="QUANTITY" DataField="Quantity">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT"
                            visible="false">
                            <itemtemplate>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="FABRIC">
                            <itemtemplate>
    							  <asp:ImageButton id="lnkFabric" tooltip="Click here to Fabric"   ImageUrl="~/Images/fabric.png" CommandName="Fabric" runat="server"></asp:ImageButton>
    							    &nbsp;&nbsp;
    							   <asp:ImageButton id="lnkFabricPDF"  ImageUrl="~/Images/pdf_icon_small.gif" CommandName="FabricPDF" runat="server" visible="false"></asp:ImageButton>
        						 </itemtemplate>
                            <headerstyle width="4%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN HeaderText="ACCESS.." visible="true">
                            <itemtemplate>
    							<asp:ImageButton id="lnkAccessoriese" tooltip="Click here to Accessoriese"  ImageUrl="~/Images/fabric.png" Enabled ="false"  CommandName="Accessoriese" runat="server"></asp:ImageButton>
    							  &nbsp;&nbsp;
    							   <asp:ImageButton id="lnkAccessoriesePDF"  ImageUrl="~/Images/pdf_icon_small.gif" CommandName="AccessoriesePDF" runat="server" visible="false"></asp:ImageButton>
        						 </itemtemplate>
                            <headerstyle width="4%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                      
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
