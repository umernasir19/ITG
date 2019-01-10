<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="BackUpDatabase.aspx.vb" Inherits="Integra.BackUpDatabase" %>
   <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table  >
						    <tr>
						        <td class="NormalBoldText" align="center">
                                        <span style="color: #ff0000"></span>Date:
						        </td>
						        <td  align="center">
						            
                                     <asp:Label ID="lblDate" runat="server" ForeColor="Navy"  Font-Bold="true" Font-Size="11px"></asp:Label>
						        </td>
						    </tr>
						    <tr>
						        <td></td>
						        <td>
						            <asp:Label ID="lblError" runat="server" ForeColor="red" Font-Bold="true" Font-Size="11px"></asp:Label>
						        </td>
						    </tr>
						</table>
						<br />
							
	<table>
						    <tr>
						        
						        <td style="width: 110px">
						            <asp:Button runat="server" id="btnDownload" CausesValidation="false" CssClass="Button" Text="Download Database Backup" />
						        </td>
						    </tr>
						    
						    
						</table>
</asp:Content>
