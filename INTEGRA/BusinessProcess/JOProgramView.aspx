<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="JOProgramView.aspx.vb" Inherits="Integra.JOProgramView" %>

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
                                        CompletionSetCount="12" ContextKey="SearchingFromStyleAssormentForCheckList" EnableCaching="true" MinimumPrefixLength="1"
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
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleAssortmentMasterID"
                            DataField="StyleAssortmentMasterID" Visible="false" />
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
                        <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="10%" HeaderText="PO No"
                            DataField="PONo">
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
                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="CUTTING PRO.">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkEdit" ToolTip="Click here to create Assortment" ImageUrl="~/Images/dashicon.png"
                                    CommandName="StyleAssortmanr" runat="server"></asp:ImageButton>
                                <asp:ImageButton ID="lnkOk" ToolTip="Click here to Edit Assortment" ImageUrl="~/Images/Ok.jpg"
                                    CommandName="CuttingProgram" runat="server"></asp:ImageButton>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="lnkCuttingProgramPDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="CuttingProgramPDF" runat="server" Visible="true"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="ACC. CHECKLIST">
                            <ItemTemplate>
                            
                                <asp:ImageButton ID="lnkAccChecklist" ToolTip="Click here to Acc" ImageUrl="~/Images/Ok.jpg"
                                    CommandName="AccCheckList" runat="server"></asp:ImageButton>
                                &nbsp;&nbsp;
                                <asp:ImageButton ID="lnkAccChecklistPDF" ImageUrl="~/Images/pdf_icon_small.gif"
                                    CommandName="AccChecklistPDF" runat="server" Visible="true"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                             <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="COPY">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkCopy" ToolTip="Click here to Copy" ImageUrl="~/Images/Copyimage.png"
                                        CommandName="Copy"  runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                        <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="05%" HeaderText="FAB."
                            Visible="false">
                            <ItemTemplate>
                                <asp:ImageButton ID="lnkCreateFab" ToolTip="Click here to create Fabrication" ImageUrl="~/Images/dashicon.png"
                                    CommandName="FABRICATION" runat="server"></asp:ImageButton>
                                <asp:ImageButton ID="lnkEditFab" ToolTip="Click here to Edit Fabrication" ImageUrl="~/Images/Ok.png"
                                    CommandName="FABRICATIONEdit" runat="server"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                         <asp:TEMPLATECOLUMN HeaderText="Copy Check List" Visible="false">
                            <itemtemplate>
																	<asp:CheckBox id="ChkMove" OnCheckedChanged="UpdateStatus"   AutoPostBack="true" runat="server"/>
</itemtemplate>
                            <headerstyle width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                </Smart:SmartDataGrid>
            </td>
        </tr>
    </table>
</asp:Content>
