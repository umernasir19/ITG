<%@ Page Title="Process Issue View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="POProcessIssueView.aspx.vb" Inherits="Integra.POProcessIssueView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table>
  <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;"
            visible="true">
            <th colspan="6" align="left" style="font-family:Century Gothic ; font-size: 16PX; font-weight: bold;
                color:Blue ">
             <marquee >Searching Criteria For PONO,Fabric Code,Manual Challan No,Department</marquee>
            </th>
        </tr>
</table>
<br />
    <table>
        <tr>
       
            <td style="width: 20%">
                <asp:TextBox ID="txtShowMe" runat="server" AutoPostBack="true" autocomplete="off"
                    Width="196px"  Visible ="true" > </asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="autoComplete1" TargetControlID="txtShowMe"
                    ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                    CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="GetProcessIssuedSearching" />
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
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ProcessIssueID"
                            DataField="ProcessIssueID" visible="false" />
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="ProcessIssueDtlID"
                            DataField="ProcessIssueDtlID" visible="false" />
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
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Process Order NO" DataField="PONoo">
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
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" visible="true" HeaderStyle-Width="02%"
                            HeaderText="EDIT">
                            <itemtemplate>																	
						<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
						</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                      
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            visible="TRUE">
                            <itemtemplate>								
	<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="Return"
                            Visible="false">
                            <ItemTemplate>
                             <asp:LinkButton id="lnkReturn" tooltip="Click here to Go Return" text="Return" CommandName="Return"  runat="server"></asp:LinkButton>
                              
                            </ItemTemplate>
                        </asp:TemplateColumn>

                          <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            visible="true">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

