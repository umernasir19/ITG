<%@ Page Title="Job Order Database View All" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/MasterPage.master" CodeBehind="JobOrderDatabaseAllView.aspx.vb"
    Inherits="Integra.JobOrderDatabaseAllView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr class="heading">
            <td>
                &nbsp; <b>Master Section </b>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Season
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" Width="160" CssClass="combo" AutoPostBack="TRUE"
                    runat="server" Style="margin-left: 9px; height: 28px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                Search
            </td>
            <td align="right">
                <asp:TextBox CssClass="textbox" ID="txtSearch" AutoPostBack="true" Style="height: 20px;
                    margin-left: 10px;" runat="server" ReadOnly="false"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                    CompletionSetCount="12" ContextKey="Searching" EnableCaching="true" MinimumPrefixLength="1"
                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtSearch" />
            </td>
            <td align="right">
                <asp:Button ID="btnDetailSection" runat="server" Visible="false" CssClass="button" Text="Detail Section"
                    Width="106" Style="margin-left: 500px;"></asp:Button>
                <asp:Button ID="btndAdd" runat="server" CssClass="button" Visible="false" Text="ADD JOB ORDER" Width="120">
                </asp:Button>
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <div style="overflow: scroll; width: 930px;">
                    <Smart:SmartDataGrid ID="dgViewMaster" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <%--	<ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleID"
								  DataField="StyleID" visible="false" />--%>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Joborderid"
                                DataField="Joborderid" Visible="False" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="JOB ORDER #" DataField="JoborderNo"
                                Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SR NO#" DataField="SRNO"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Model/Ref No" DataField="Model"
                                Visible="FALSE">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CUSTOMER" DataField="CustomerName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Style/Article No"
                                DataField="Style" Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ORDER DATE" DataField="OrderRecvDatee">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="STYLE SHIP DATE"
                                DataField="StyleShipmentDatee">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="QUANTITY" DataField="Quantity">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Merchandiser" DataField="UserName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Season" DataField="SeasonName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Customer Order" DataField="CustomerOrder">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="01%" HeaderText="EDIT">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="Edit" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="01%" HeaderText="COPY">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkCopy" ToolTip="Click here to Copy" ImageUrl="~/Images/Copyimage.png"
                                        CommandName="Copy" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="FABRIC" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkFabric" ToolTip="Click here to Fabric" ImageUrl="~/Images/fabric.png"
                                        CommandName="Fabric" runat="server"></asp:ImageButton>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="lnkFabricPDF" Visible="true" ImageUrl="~/Images/pdf_icon_small.gif"
                                        CommandName="FabricPDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ACCESS.." Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkAccessoriese" ToolTip="Click here to Accessoriese" ImageUrl="~/Images/fabric.png"
                                        CommandName="Accessoriese" runat="server"></asp:ImageButton>
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="lnkAccessoriesePDF" Visible="true" ImageUrl="~/Images/pdf_icon_small.gif"
                                        CommandName="AccessoriesePDF" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Cut To Pack" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPRODUCTION" ToolTip="Click here to Production" ImageUrl="~/Images/green.png"
                                        CommandName="PRODUCTION" runat="server"></asp:ImageButton>
                                    <asp:ImageButton ID="lnkPRODUCTIONPDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PRODUCTIONPDF"
                                        runat="server" Visible="false"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Other Head" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkOtherHead" ToolTip="Click here to Production" ImageUrl="~/Images/green.png"
                                        CommandName="OtherHead" runat="server"></asp:ImageButton>
                                    <asp:ImageButton ID="lnkOtherHeadPDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="OtherHeadPDF"
                                        runat="server" Visible="false"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Cost PDF" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkCostPDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="CostPDF"
                                        runat="server" Visible="true"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="PRO.." Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPRODUCTIONN" ToolTip="Click here to Production" ImageUrl="~/Images/green.png"
                                        CommandName="PRODUCTIONN" runat="server"></asp:ImageButton>
                                    <%-- <asp:ImageButton id="lnkPRODUCTIONPDF"  ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PRODUCTIONPDF" runat="server" visible="false"></asp:ImageButton>--%>
                                </ItemTemplate>
                                <HeaderStyle Width="2%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="02%" HeaderText="T.N.A">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkTNA" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="MILESTONE" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn ItemStyle-HorizontalAlign="Center" Visible="false" HeaderStyle-Width="02%" HeaderText="ASSORT"
                                >
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkAssort" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                        CommandName="ASSORT" runat="server"></asp:ImageButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="P.I" Visible="false">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkPIPDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PIPDF"
                                        runat="server" Visible="true"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="4%" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="FALSE" HeaderText="CustomerDatabaseID"
                                DataField="CustomerDatabaseID">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                        </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlDetail" runat="server" Visible="false">
        <table width="100%">
            <tr style="height: 15px;">
                <td>
                </td>
            </tr>
            <tr class="heading">
                <td>
                    &nbsp; <b>Detail Section </b>
                </td>
            </tr>
            <tr style="height: 15px;">
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="True" ForeColor="white"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="StyleID"
                                DataField="StyleID" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="Joborderid"
                                DataField="Joborderid" Visible="false" />
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="JOB ORDER #" DataField="JoborderNo"
                                Visible="false">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="SR No#" DataField="SRNO">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="CUSTOMER" DataField="CustomerName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="STYLE" DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ITEM CODE" DataField="Itemcode">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="ORDER DATE" DataField="OrderRecvDatee">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="STYLE SHIP DATE"
                                DataField="StyleShipmentDatee">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Color Code" DataField="ColorCode">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="Buyer Color" DataField="BuyerColor">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderText="QUANTITY" DataField="Quantity">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <%--<ASP:TEMPLATECOLUMN   ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%" HeaderText="EDIT">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>
								<ASP:TEMPLATECOLUMN   ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="MILESTONE">
									<ITEMTEMPLATE>																	
										<asp:ImageButton id="lnkTNA" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="MILESTONE" runat="server"></asp:ImageButton>
									</ITEMTEMPLATE>
								</ASP:TEMPLATECOLUMN>--%>
                        </Columns>
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
