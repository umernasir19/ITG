<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ArticlePopupNew.aspx.vb"
    Inherits="Integra.ArticlePopupNew" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Article Popup</title>
    <link href="../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
    <table align="center">
        <tr>
            <td class="NormalBoldText">
                <asp:Label ID="lblUserName" runat="server" CssClass="Label" Text="User Name:"></asp:Label>
            </td>
            <td class="NormalBoldText">
                <asp:DropDownList ID="cmbUserName" Width="155" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                <asp:Button ID="BtnData" runat="server" CssClass="button" Text="Get Data"></asp:Button>
            </td>
        </tr>
        <tr>
            <td class="NormalBoldText">
                <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Search Type:" Visible ="false" ></asp:Label>
            </td>
            <td class="NormalBoldText">
                <asp:DropDownList ID="cmbECPDivision" runat="server" Width="130" AutoPostBack="True" Visible ="false" >
                    <asp:ListItem>Select Type</asp:ListItem>
                    <asp:ListItem Selected ="True" >By PO NO.</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td class="NormalBoldText" align="center">
            </td>
        </tr>

        <tr align="center">
            <td class="NormalBoldText" align="center">
                <asp:Label ID="Label3" runat="server" CssClass="Label" Text="Season:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbSeason" runat="server" Width="203px" style="margin-left: -96px;" AutoPostBack="True" Visible ="true" >
                    
                </asp:DropDownList>
              
            </td>
        </tr>


        <tr align="center">
            <td class="NormalBoldText" align="center">
                <asp:Label ID="Label1" runat="server" CssClass="Label" Text="SR NO.:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSeach" runat="server" Width="200" CssClass="textBox" ></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Get Data"></asp:Button>
            </td>
        </tr>

       


        <tr align="center">
            <td class="NormalBoldText" align="center">
                <asp:Label ID="lblStyle" runat="server" CssClass="Label" Text="Style NO:"></asp:Label>
            </td>
            <td class="NormalBoldText" align="center">
               
            </td>
            <td>
                <asp:TextBox ID="style" runat="server" Width="200" CssClass="textBox"></asp:TextBox>
                <asp:Button ID="btnStyle" runat="server" CssClass="button" Text="Get Data"></asp:Button>

            </td>
            <td>
             <asp:button id="btnSelectAll"      runat="server"
  CssClass="button" Text="Select ALL"   ></asp:button>
            </td>
        </tr>
    </table>
    <div>
        <table>
            <tr>
                <td align="center">
                    <asp:Label ID="Errormgs" CssClass="ErrorMsg" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <Smart:SmartDataGrid ID="dgArticle" runat="server" Width="100%" OnPageIndexChanged="PageChanged"
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="2" CssClass="table"
                        PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="50" RecordCount="0"
                        ShowFooter="True" SortedAscending="yes">
                        <Columns>

                          <asp:BoundColumn HeaderText="SeasonDatabaseID" DataField="SeasonDatabaseID" Visible ="false" >
                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:BoundColumn>



                              <asp:TemplateColumn HeaderText="Style/Model Ref">
                            <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:TextBox ID="TXTStyle" runat="server" Width="120" CssClass="textbox" OnTextChanged="TXTCommodity_TextChanged"
                                    AutoPostBack="false"></asp:TextBox>
                              
                            </ItemTemplate>
                            <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>



                          <asp:TemplateColumn HeaderText="Hs Code">
                            <ItemStyle Width="5%" HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:TextBox ID="txtHsCode" runat="server" Width="120" CssClass="textbox" 
                                    AutoPostBack="FALSE" ReadOnly ="false" ></asp:TextBox>
                               
                                   </ItemTemplate>
                            <HeaderStyle Width="6%" HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>



                         <asp:TemplateColumn HeaderText="Commodity">
                            <ItemStyle Width="9%" HorizontalAlign="Left"></ItemStyle>
                            <ItemTemplate>
                                <asp:TextBox ID="TXTCommodity" runat="server" Width="90" CssClass="textbox" OnTextChanged="TXTCommodity_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="SearchCommodity" EnableCaching="true"
                                    MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                                    TargetControlID="TXTCommodity" />
                                   
                                   
                  <asp:ImageButton ID="imgSyleAdd" runat="server" ToolTip="Click here to Add Style."
                                    CommandName="AddCommdity" ImageUrl="~/Images/AddButton.jpg" style=" margin-top: -24px; margin-left: 95px;" Visible="true"/>
               

                               <asp:Label ID="LBLCommodityID" runat="server" Visible ="false"  CssClass="Label" Text ="0" ></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle Width="9%" HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>

                        






                              <asp:BoundColumn HeaderText="Season" DataField="SeasonName">
                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:BoundColumn>


                            <asp:BoundColumn HeaderText="SR NO." DataField="PONO">
                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="POID" DataField="POID" Visible="False" />
                            <asp:BoundColumn HeaderText="Customer" DataField="CustomerName">
                                <ItemStyle HorizontalAlign="left" Width="60%" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Supplier" DataField="SupplierName">
                                <ItemStyle HorizontalAlign="Center" Width="60%" />
                                <HeaderStyle HorizontalAlign="left" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Style ID" DataField="StyleID" Visible="false" />
                            <asp:BoundColumn HeaderText="Style" DataField="StyleNo">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>
                        
                          
                            <asp:BoundColumn HeaderText="Size" DataField="SizeRange" Visible="true">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>

                                <asp:BoundColumn HeaderText="Constr" DataField="Constr">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>

                                <asp:BoundColumn HeaderText="Composition" DataField="Composition">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>



                            <asp:BoundColumn HeaderText="Rate" DataField="ShippedRate" Visible="False">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>

                            <asp:BoundColumn HeaderText="PO Quantity" DataField="Quantity">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Shipped Quantity" DataField="ReleaseQuantity">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                            </asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="PCS">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <%--<asp:textbox id="txtReleaseQuantity" runat="server" width="60" CssClass="textbox" text='<%#Eval("RemainQTY") %>' ></asp:textbox>--%>
                                    <asp:TextBox ID="txtReleaseQuantity" runat="server" Width="60" CssClass="textbox" Text='<%#Eval("Quantity") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <%--  <ASP:BOUNDCOLUMN HeaderText="Cartons" DataField="Cartons"  >
															    <itemstyle horizontalalign="Center" width="10%" />
															</ASP:BOUNDCOLUMN> --%>
                            <asp:TemplateColumn HeaderText="CTNS">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="Cartons" runat="server" ReadOnly ="false"  Width="60" CssClass="textbox" Text='<%#Eval("Cartons") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="Shipped Rate">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="ShippedRate" runat="server" Width="60" ReadOnly="true" CssClass="textbox"
                                        Text='<%#Eval("ShippedRate") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>


<asp:TemplateColumn HeaderText="Weight Per PCS">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="TXTWeightPCS" runat="server" Width="60" ReadOnly="false" CssClass="textbox"
                                        ></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                              
                              <asp:TemplateColumn HeaderText="White PCS">
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWhitePCS" runat="server" Width="60" ReadOnly="false" CssClass="textbox"
                                       ></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Packing PCS Per Carton" Visible ="false" >
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPackingPCS" OnTextChanged="txtPackingPCS_TextChanged" AutoPostBack="true"  runat="server" Width="60" ReadOnly="false" CssClass="textbox"
                                       ></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>


                           
                             <asp:TemplateColumn HeaderText="White Carton" Visible ="true" >
                                <ItemStyle HorizontalAlign="Center" Width="40%" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtWhiteCarton" AutoPostBack="false" runat="server" Width="60" ReadOnly="false" CssClass="textbox"
                                       ></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="Select">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" runat="server" OnCheckedChanged="UpdateArticle" AutoPostBack="true" />
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ID" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" CssClass="label" Text='<%#Eval("POID")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="10%" />
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText="CustomerID" Visible="false" DataField="CustomerID" />
                            <asp:BoundColumn HeaderText="SupplierID" Visible="false" DataField="VendorID" />
                            <asp:BoundColumn HeaderText="POPOID" DataField="POPOID" Visible="False" />
                            <asp:BoundColumn HeaderText="Currency" DataField="Currency" Visible="false" />
                         
                        





                               <asp:BoundColumn HeaderText="Shipment Date" DataField="DetailShipDate" Visible="true" />



                        </Columns>
                        <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" />
                        <AlternatingItemStyle CssClass="GridAlternativeRow" />
                        <ItemStyle CssClass="GridRow" />
                        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                    </Smart:SmartDataGrid>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSelect" runat="server" CssClass="button" Text="Save" OnClientClick="window.close();" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
