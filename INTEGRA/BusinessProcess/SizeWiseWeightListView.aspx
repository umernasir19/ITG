<%@ Page Title="Size Wise Weight List View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="SizeWiseWeightListView.aspx.vb" Inherits="Integra.SizeWiseWeightListView" %>
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
             <marquee >Searching Criteria For Brand,Buyer,Style,SrNo,Season</marquee>
            </th>
        </tr>
</table>
<br />
<table>
<tr>
        <td>
        Search
        </td>
        <td align="right" >
          <asp:TextBox CssClass="textbox" ID="txtSearch" AutopostBack="true"  style="height :20px; margin-left: 10px;" runat="server" ReadOnly="false" ></asp:TextBox>
           <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchingFromSizeWeight" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtSearch" />

        </td>
            
        </tr>
</table>
<br />
    <table width="100%">
        <tr>
            <td>
                <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                    GridLines="both">
                    <Columns>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SizeWiseWeightListMstID"
                            DataField="SizeWiseWeightListMstID" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JobOrderId"
                            DataField="JobOrderId" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="JoborderDetailid"
                            DataField="JoborderDetailid" Visible="false" />
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="SEASON"
                            DataField="SeasonName">
                            <HeaderStyle HorizontalAlign="center" Width="5%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="CUSTOMER"
                            DataField="CustomerName">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="BRAND"
                            DataField="Brand">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="Sr NO."
                            DataField="SRNO">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="SHIP"
                            DataField="StyleShipmentDatee">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="STYLE"
                            DataField="Style">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="CUS.COLOR"
                            DataField="BuyerColor">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="QUANTITY"
                            DataField="Quantity">
                            <HeaderStyle HorizontalAlign="center" Width="7%" />
                        </asp:BoundColumn>
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="Weight List.">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to create Weight List" ImageUrl="~/Images/dashicon.png"
                                    CommandName="StyleAssortmanr" runat="server"></asp:ImageButton>
                                <asp:ImageButton ID="lnkOk" ToolTip="Click here to Edit Weight List" ImageUrl="~/Images/Ok.jpg"
                                    CommandName="Edit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    



                            <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="Remove" Visible ="true" >
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


