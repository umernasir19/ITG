<%@ Page Language="vb"  MasterPageFile="~/MasterPage.master" AutoEventWireup="false"    CodeFile="DataBaseBackup.aspx.vb" Inherits="DataBaseBackup" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 				
						
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
