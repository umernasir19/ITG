<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="StyleDatabaseReportView.aspx.vb"
    Inherits="Integra.StyleDatabaseReportView" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <title>GIA B2B-INTEGRA ERP</title>
    <%-- <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/NewCSS/NewStyle.css" />--%>
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/StyleSheet.css" />
    <link href="../StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="JavaScript" src="scripts/pupdate.js"></script>
    <link rel="stylesheet" href="../scripts/ThickBox.css" type="text/css" media="screen" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/MenuCSS.css" />
    <link type="text/css" rel="stylesheet" href="../StyleSheet/NewLayout.css" />
    <link type="text/css" rel="stylesheet" href="../css/VAF.css" />
    <link type="text/css" rel="stylesheet" href="../css/buttons.css" />
</head>
<script type="text/javascript">
    function isNumericKey(e) {
        var charInp = window.event.keyCode;
        if (charInp > 31 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
    function isNumericKeyy(e) {
        var charInp = window.event.keyCode;
        if (charInp != 46 && (charInp < 48 || charInp > 57)) {
            return false;
        }
        return true;
    }
   
</script>
<script type="text/javascript">




    function Print() {
        //var btn=document.getElementById('Print1').id
        //btn.style.Display="none";

        document.getElementById("Print1").style.visibility = "hidden";
        window.print();
        alert('btn')
    }


</script>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>
                <input id="Print1" type="button" width="177" value=" Print this page " style="margin-left: 888px;
                    margin-top: 32px; height: 31px;" onclick="Print();" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Database
            </th>
        </tr>
    </table>
    <table width="50%">
        <tr style="height: 35px;">
            <td width="118">
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Created by
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtCreatedBy" CssClass="textbox" Width="126" ReadOnly="true" runat="server"
                        Style="border-color: #66bd00; height: 23px; margin-left: 35px;"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 172px;">
                    Created On
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtCreatedOn" Width="136" CssClass="textbox" ReadOnly="true" runat="server"
                        Style="border-color: #66bd00; height: 23px; margin-left: 25px;"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Information
            </th>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Style No:
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:UpdatePanel ID="UpStyleNo" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtStyleNo" CssClass="textbox" Width="130" AutoPostBack="true" runat="server"
                                Style="border-color: #66bd00; height: 23px;"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Special Line
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:UpdatePanel ID="UpCoreLine" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:TextBox ID="txtCoreLine" CssClass="textbox" Width="144" runat="server" Style="border-color: #66bd00;
                                height: 23px;"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Customer
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbCustomer" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbCustomer" Width="150" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Style Description
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtStyleDescription" CssClass="textbox" Width="132" runat="server"
                        Style="border-color: #66bd00; height: 23px;"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Season
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbSeason" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSeason" Width="150" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Style Source
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbStyleSource" CssClass="combo" runat="server" Style="border-color: #66bd00;"
                            AutoPostBack="true" Width="150" ToolTip="Select source of original sample">
                            <asp:ListItem Value="0" Text="Technical sheet" />
                            <asp:ListItem Value="1" Text="Buyer sample" />
                            <asp:ListItem Value="2" Text="GIA Offer Sample" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Buying Dept
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbBuyingDept" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyingDept" Width="137" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Buyer Name
                </div>
            </td>
            <td>
                <asp:TextBox ID="txtBuyerName" CssClass="textbox" runat="server"></asp:TextBox>
                <asp:UpdatePanel ID="UpdatecmbBuyerName" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBuyerName" Width="150" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Brand
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbBrand" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBrand" Width="150" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
                <asp:UpdatePanel ID="UpFabFinish" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Product Information
            </th>
        </tr>
        <tr style="height: 35px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Product Portfolio
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbProductPortfolio" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList Width="140" ID="cmbProductPortfolio" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px; height: 37px;">
                    Product Category
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbProductCategory" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductCategory" Width="140" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00; margin-right: -9px; margin-left: 6px;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px; width: 143px; height: 37px;">
                    Product Consumer Grp
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel12" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbProductConsumerGrp" Width="140" CssClass="combo" runat="server"
                            Style="border-color: #66bd00;" AutoPostBack="true" ToolTip="Select product consumer">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr style="height: 35px;" runat="server" id="RwPack" visible ="false" >
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px;">
                    Pack
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbPack" AutoPostBack="true" CssClass="combo" runat="server"
                            Style="border-color: #66bd00;" Width="140">
                            <asp:ListItem Text="1 Pc Set" Value="0"></asp:ListItem>
                            <asp:ListItem Text="2 Pc Set" Value="1"></asp:ListItem>
                            <asp:ListItem Text="3 Pc Set" Value="2"></asp:ListItem>
                            <asp:ListItem Text="4 Pc Set" Value="3"></asp:ListItem>
                            <asp:ListItem Text="5 Pc Set" Value="4"></asp:ListItem>
                            <asp:ListItem Text="6 Pc Set" Value="5"></asp:ListItem>
                            <asp:ListItem Text="7 Pc Set" Value="6"></asp:ListItem>
                            <asp:ListItem Text="8 Pc Set" Value="7"></asp:ListItem>
                            <asp:ListItem Text="9 Pc Set" Value="8"></asp:ListItem>
                            <asp:ListItem Text="10 Pc Set" Value="9"></asp:ListItem>
                            <asp:ListItem Text="11 Pc Set" Value="10"></asp:ListItem>
                            <asp:ListItem Text="12 Pc Set" Value="11"></asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnAddProduct" CssClass="button" Width="106" runat="server" Text="Add Product"
                    Visible="false" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <div style="vertical-align: top; overflow: auto; width: 1100px; border-style: groove;">
        <table width="100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="UpUpbtnAutoComplete" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgProductinfo" runat="server" Width="100%" AllowPaging="False"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                <Columns>
                                    <asp:BoundColumn HeaderText="SproductID" DataField="SproductID" Visible="False">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ProductPortfolioID" DataField="ProductPortfolioID" Visible="False">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ProductCategoriesID" DataField="ProductCategoriesID"
                                        Visible="False">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="ProductConsumerID" DataField="ProductConsumerID" Visible="False">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                     <asp:BoundColumn HeaderText="Product Con. Group" DataField="ProductConsumerGroup"
                                        Visible="true">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText="Pack" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtPack" Text='<% #Eval("Pack") %>' Width="50" ReadOnly="true" CssClass="textbox"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Base Row">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRow" Text='<% #Eval("RowNo") %>' Width="50" ReadOnly="true" CssClass="textbox"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Item">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtItem" Text='<% #Eval("Item") %>' Width="60" CssClass="textbox"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="HS Code">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtHSCode" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Type">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFabricType" CssClass="dd" Width="80" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText=" Fab. Finish">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFabFinish" Width="80" CssClass="dd" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Cons">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFCons" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Comp.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFComp" Width="120" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="F.Wt.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFWt" onkeypress="return isNumericKeyy(event);" CssClass="textbox"
                                                Width="50" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbFWtUnit" Width="80" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Garment Wt.">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGarmentWt" onkeypress="return isNumericKeyy(event);" Width="50"
                                                CssClass="textbox" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Unit">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="cmbGarmentWtUnit" Width="80" CssClass="dd" runat="server">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Color" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtColor" CssClass="textbox" Width="60" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Remarks">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemarks" CssClass="textbox" Width="80" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Remove" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                                CommandName="RemoveProduct" runat="server" Visible="false"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                                <AlternatingItemStyle CssClass="GridAlternativeRow" />
                                <ItemStyle CssClass="GridRow" />
                                <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                            </Smart:SmartDataGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td valign="top">
                    <asp:UpdatePanel ID="UpbtnAutoComplete" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnAutoComplete" CssClass="button" Width="100" runat="server" Text="Auto Comp." />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <table width="100%">
        <br />
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Colour Information
            </th>
        </tr>
    </table>
    <%-- <table width="100%">
        <tr style="height: 0px;">
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtColorRefNo" CssClass="textbox" Width="140" runat="server" Visible="false"
                        Style="border-color: #66bd00; height: 23px; margin-left: -18px;"></asp:TextBox>
                </div>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtColorway" CssClass="textbox" Width="140" runat="server" Visible="false"
                        Style="border-color: #66bd00; height: 23px; margin-left: -40px;"></asp:TextBox>
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbSizeRange" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbSizeRange" Visible="false" Width="140" AutoPostBack="true"
                            CssClass="combo" runat="server" Style="border-color: #66bd00; margin-left: -36px;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
       
            <td>
                <asp:UpdatePanel ID="UpcmbBaseItem" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbBaseItem" Width="140" AutoPostBack="true" CssClass="combo"
                            Visible="false" runat="server" Style="border-color: #66bd00; margin-left: 21px;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtPrice" onkeypress="return isNumericKeyy(event);" CssClass="textbox"
                        Width="140" runat="server" Visible="false" Style="border-color: #66bd00; height: 23px;
                        margin-left: 53px;"></asp:TextBox>
                </div>
            </td>
            <td>
                <asp:DropDownList ID="cmbCurrency" Width="140" Visible="false" CssClass="combo" runat="server"
                    Style="border-color: #66bd00; margin-left: 181px;" ToolTip="select currency">
                    <asp:ListItem Value="0" Text="Dollar"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Euro"></asp:ListItem>
                    <asp:ListItem Value="2" Text="Pounds"></asp:ListItem>
                </asp:DropDownList>
            </td>
        
            <td>
                <asp:Button ID="btnAddColor" CssClass="button" Width="106" Visible="false" runat="server"
                    Text="Add Color" />
            </td>
            <td align="right">
                <div>
                    <asp:Button ID="btnHide" CssClass="button" runat="server" Visible="false" Text="Hide" />
                    <asp:Button ID="btnShow" CssClass="button" runat="server" Visible="false" Text="Show" />
                </div>
            </td>
        </tr>
    </table>--%>
    <table width="100%">
        <tr>
            <td align="right">
                <div>
                    <asp:Button ID="btnHide" CssClass="button" runat="server" Visible="false" Text="Hide" />
                    <asp:Button ID="btnShow" CssClass="button" runat="server" Visible="false" Text="Show" />
                </div>
            </td>
        </tr>
    </table>
    <asp:Panel ID="PnlColor" runat="server" Visible="true">
        <table width="100%">
            <tr>
                <td>
                    <telerik:RadGrid ID="dgColor" runat="server" AutoGenerateColumns="false" Skin="WebBlue"
                        CellSpacing="0">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="StyleDetailID" Display="false" DataField="StyleDetailID">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="StyleID" Display="false" DataField="StyleID">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Item Row" DataField="BaseRow">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Color Ref No." DataField="ColorRefNo">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Colorway" DataField="Colorway">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="SizeRange" DataField="SizeRange">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Size" DataField="Sizes">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Size" Display="false" DataField="SizeRange">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Price" DataField="Price">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Currency" DataField="PriceUnit">
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table width="100%">
        <br />
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Accessories Detail
            </th>
        </tr>
    </table>
    <%-- <table width="100%">
        <tr style="height: 35px;">
            <%--  <td> <div class="txt" style="margin: 6px; margin-left: 10px;">
                Accessories
          </div>  </td>
            <td>
                <asp:UpdatePanel ID="UpcmbAccessories" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbAccessories" Visible="false" Width="140" AutoPostBack="true"
                            CssClass="combo" runat="server" Style="border-color: #66bd00; margin-left: -57px;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <%--    <td> <div class="txt" style="margin: 6px; margin-left: -23px; width: 158px;">
                Accessories Description
           </div> </td> 
            <td>
                <div class="text_box" style="">
                    <asp:TextBox ID="txtAccessoriesDescription" Width="100" CssClass="textbox" Visible="false"
                        runat="server" ToolTip="input accessories type" Style="border-color: #66bd00;
                        height: 23px; margin-left: -55px;"></asp:TextBox>
                </div>
            </td>
            <%-- <td> <div class="txt" style="margin-left: 10px;">
                Source:
         </div>   </td> 
            <td>
                <asp:DropDownList ID="cmbSource" Width="80" CssClass="combo" Visible="false" runat="server"
                    Style="border-color: #66bd00;" ToolTip="select source of accessories">
                    <asp:ListItem Value="0" Text="Local"></asp:ListItem>
                    <asp:ListItem Value="1" Text="Import"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnAddAccessories" CssClass="button" Width="130" runat="server" Visible="false"
                    Text="Add Accessories" />
            </td>
        </tr>
    </table>--%>
    <table width="100%">
        <tr>
            <td>
                <telerik:RadGrid ID="dgAcces" runat="server" AutoGenerateColumns="false" Skin="WebBlue"
                    CellSpacing="0">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="SAID" Display="false" DataField="SAID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="StyleID" Display="false" DataField="StyleID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="AccessoriesID" Display="false" DataField="AccessoriesID">
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="AccessoriesName" DataField="AccessoriesName">
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="AccessoriesDescription" DataField="AccessoriesDescription">
                                <HeaderStyle Width="15%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="Source" DataField="Source">
                                <HeaderStyle Width="10%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="Delete" CommandName="Delete"
                                Display="false" ConfirmTextFormatString="Are You Sure You want to Delete Record"
                                HeaderStyle-Width="5%" ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 38px;">
            <td style="width: 90px;">
                <div class="txt" style="margin: 6px; margin-left: 10px; width: 150px;">
                    Embell.
                </div>
            </td>
            <td>
                <asp:UpdatePanel ID="UpcmbEmbell" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbEmbell" Width="140" AutoPostBack="true" CssClass="combo"
                            runat="server" Style="border-color: #66bd00; margin-left: 91px; width: 199px;">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Testing Detail
            </th>
        </tr>
        </br>
    </table>
    <table width="100%">
        <tr style="height: 28px;">
            <td>
                <div class="txt" style="margin-left: 10px; width: 150px;">
                    Dimensional Stablity
                </div>
            </td>
            <td valign="top">
                L: +/-&nbsp;&nbsp;
                <asp:TextBox ID="txtAcceptableDimensionalL" Width="50" CssClass="textbox" runat="server"
                    ToolTip="input stability test " Style="border-color: #66bd00;"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; W:+/-&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAcceptableDimensionalW" Width="50" CssClass="textbox" runat="server"
                    ToolTip="input stability test " Style="border-color: #66bd00;"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px; width: 150px;">
                    Rubbing Fastness:
                </div>
            </td>
            <td valign="top">
                Wet &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRubbingFastnessWet" onkeypress="return isNumericKeyy(event);"
                    Width="50" CssClass="textbox" runat="server" ToolTip="input rubbing fastness test "
                    Style="border-color: #66bd00;"></asp:TextBox>
                &nbsp;&nbsp;&nbsp; Dry &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtRubbingFastnessDry" onkeypress="return isNumericKeyy(event);"
                    Width="50" CssClass="textbox" runat="server" ToolTip="input rubbing fastness test "
                    Style="border-color: #66bd00;"></asp:TextBox>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px; width: 150px;">
                    Type of Dyes:
                </div>
            </td>
            <td>
                <asp:DropDownList ID="cmbTypeOfDyes" Width="200" AutoPostBack="true" CssClass="combo"
                    runat="server" Style="border-color: #66bd00; margin-left: -206px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px; width: 150px;">
                    Type of Print
                </div>
            </td>
            <td>
                <asp:DropDownList ID="cmbTypeOfPrint" Width="200" AutoPostBack="true" CssClass="combo"
                    runat="server" Style="border-color: #66bd00; margin-left: -206px;">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="height: 28px;">
            <td>
                <div class="txt" style="margin: 6px; margin-left: 10px; width: 150px;">
                    Type of Washing
                </div>
            </td>
            <td>
                <asp:DropDownList ID="cmbTypeOfWashing" Width="200" AutoPostBack="true" CssClass="combo"
                    runat="server" Style="border-color: #66bd00; margin-left: -206px;">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Packing Detail
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <table width="80%">
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Carton Type:
                            </div>
                        </td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtCartonType" Width="100" CssClass="textbox" runat="server" ToolTip="input carton type "
                                Style="border-color: #66bd00;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Carton Size :
                            </div>
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCartonSizeL" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input carton size in numbers" Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCartonSizeW" onkeypress="return isNumericKeyy(event);" Width="50"
                                            CssClass="textbox" runat="server" ToolTip="input carton size in numbers" Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        H
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCartonSizeH" onkeypress="return isNumericKeyy(event);" Width="50"
                                            CssClass="textbox" runat="server" ToolTip="input carton size in numbers" Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbCartonSizeUnitID" Width="80" CssClass="combo" runat="server"
                                                    Style="border-color: #66bd00;" AutoPostBack="True" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Approx Qty/Carton
                            </div>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="txtQtyCarton" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input quantity per carton" Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdcmbQtyCartonUnit" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbQtyCartonUnit" AutoPostBack="True" Width="80" CssClass="combo"
                                                    runat="server" Style="border-color: #66bd00;" ToolTip="input quanity per Carton and select dropdown"
                                                    Visible="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Qty/Pack
                            </div>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="txtQtyPack" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input quantity per carton" Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel7" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbQtyPackUnit" AutoPostBack="True" Width="80" CssClass="combo"
                                                    runat="server" Style="border-color: #66bd00;" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Poly Bag Size:
                            </div>
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagSizeL" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input numbers to define poly bag size and dimension"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagSizeW" Width="50" CssClass="textbox" onkeypress="return isNumericKeyy(event);"
                                            runat="server" ToolTip="input numbers to define poly bag size and dimension"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        Flap
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagSizeFlap" onkeypress="return isNumericKeyy(event);" Width="50"
                                            CssClass="textbox" runat="server" ToolTip="input numbers to define poly bag size and dimension"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbPolyBagSizeUnitID" CssClass="combo" runat="server" Style="border-color: #66bd00;"
                                                    AutoPostBack="true" Width="80" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Inlay Card Size/Folding Board:
                            </div>
                        </td>
                        <td>
                            &nbsp;
                            <asp:TextBox ID="txtInlayCardSize" Width="50" CssClass="textbox" runat="server" ToolTip="input YES in capslock if inlay card required else NO in capslock"
                                Style="border-color: #66bd00;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Packed Pc. Sz
                            </div>
                        </td>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPackedPcSzL" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input packed piece of garments dimension in numbers"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPackedPcSzW" Width="50" onkeypress="return isNumericKeyy(event);"
                                            CssClass="textbox" runat="server" ToolTip="input packed piece of garments dimension in numbers"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbPackedPcUnitID" CssClass="combo" runat="server" Style="border-color: #66bd00;"
                                                    AutoPostBack="true" Width="80" ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Approx Gross Weight of Carton:
                            </div>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        &nbsp;
                                        <asp:TextBox ID="txtGrossWeightofCarton" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input gross weight of carton"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdcmbGrossWeightCartonUnit" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbGrossWeightCartonUnit" AutoPostBack="true" CssClass="combo"
                                                    runat="server" Style="border-color: #66bd00;" Width="80" ToolTip="input Gross Weight of Carton and select dropdown"
                                                    Visible="false">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="height: 28px;">
                        <td>
                            <div class="txt" style="margin: 6px; margin-left: 10px; width: 201px;">
                                Poly Bag Sticker Size
                            </div>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        L
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagStickerSizeL" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input size of stickers"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        W
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagStickerSizeW" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input size of stickers"
                                            Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblH" runat="server" Visible="false" Text="H"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPolyBagStickerSizeH" onkeypress="return isNumericKeyy(event);"
                                            Width="50" CssClass="textbox" runat="server" ToolTip="input size of stickers"
                                            Visible="false" Text="0.00" Style="border-color: #66bd00;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblUnit" runat="server" Visible="false" Text="Unit"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel5" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="cmbPolyBagStickerSizeUnitID" CssClass="combo" runat="server"
                                                    Style="border-color: #66bd00;" AutoPostBack="true" Width="80" Visible="false"
                                                    ToolTip="input quanity per pack and select dropdown">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right">
                <table width="20%">
                    <tr>
                        <td>
                            <asp:Image ID="imgExtra" runat="server" Style="height: 250px; width: 220px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Complaint Type
            </th>
        </tr>
    </table>
    <table width="100%">
        <tr style="height: 38px;">
            <td colspan="8">
                <asp:TextBox ID="txtInsetComplainttype" Width="924" CssClass="textbox" runat="server"
                    Visible="true"></asp:TextBox>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Attachment
            </th>
        </tr>
        <tr style="height: 0px;">
            <%--     <td> <div class="txt" style="margin: 6px; margin-left: 10px;">
                File Type
       </div>     </td>--%>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="cmbFileType" CssClass="combo" runat="server" Style="border-color: #66bd00;"
                            AutoPostBack="true" Width="120" Visible="false" ToolTip="select file type you wish to upload ">
                            <asp:ListItem Value="0" Text="Picture" />
                            <asp:ListItem Value="1" Text="Size Chart" />
                            <asp:ListItem Value="2" Text="Care Label" />
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <%--   <td> <div class="txt" style="margin: 6px; margin-left: 10px;">
                Picture:
            </div></td>--%>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="select jpg file to attach and press upload"
                    Visible="false" />
            </td>
            <td>
                <asp:Button ID="btnUpload1" CssClass="button" runat="server" Text="Upload" Visible="false" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label ID="lblErrorMsg" runat="server" CssClass="ErrorMsg"></asp:Label>
            </td>
        </tr>
        <tr style="height: 35px;">
            <td>
                <asp:UpdatePanel ID="UpdgFileInfo" runat="server">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgFileInfo" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="TableID" DataField="TableID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="StyleID" DataField="StyleID" Visible="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Creation Date" DataField="Creationdatee">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Type" DataField="FileType">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="File Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFIle" CommandName="DownloadFile" Text='<% #Eval("FileName") %>'
                                            runat="server"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" Visible="true" runat="server" Height="70" Width="150" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="7%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Remove" Visible="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" OnClientClick="return confirm('OK to Delete?');"
                                            ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Remove" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                            <AlternatingItemStyle CssClass="GridAlternativeRow" />
                            <ItemStyle CssClass="GridRow" />
                            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                        </Smart:SmartDataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" CssClass="button" Width="106" runat="server" Text="Save"
                    Visible="false" />
                &nbsp;
                <asp:Button ID="btnCancel" CssClass="button" Width="106" runat="server" Text="Cancel"
                    Visible="false" />
            </td>
        </tr>
    </table>
    </form>
</body>
<script type="text/javascript" language="JavaScript" src="JavaScript/writing.js"></script>
</html>
