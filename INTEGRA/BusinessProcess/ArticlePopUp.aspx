<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ArticlePopUp.aspx.vb"
    Inherits="Integra.ArticlePopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>

<body>

    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server"/>
    <telerik:RadFormDecorator ID="RadFormDecorator1" Runat="server" DecoratedControls="All" EnableRoundedCorners="False"></telerik:RadFormDecorator>
    <telerik:RadToolTipManager runat="server" ID="ToolTipManager" AutoTooltipify="true"
        Position="TopRight" >
    </telerik:RadToolTipManager>
    <telerik:RadAjaxManager ID="ajaxMan" runat="server">
<AjaxSettings>
<telerik:AjaxSetting AjaxControlID="cmbECPDivision">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="Label1" />
<telerik:AjaxUpdatedControl ControlID="txtPONO" />
<telerik:AjaxUpdatedControl ControlID="btnSearch" />
<telerik:AjaxUpdatedControl ControlID="lblStyle" />
<telerik:AjaxUpdatedControl ControlID="txtStyle" />
<telerik:AjaxUpdatedControl ControlID="btnStyle" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="btnSearch">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgArticle" />
<telerik:AjaxUpdatedControl ControlID="Errormgs" />
<telerik:AjaxUpdatedControl ControlID="btnSelect" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="btnStyle">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="dgArticle" />
<telerik:AjaxUpdatedControl ControlID="Errormgs" />
<telerik:AjaxUpdatedControl ControlID="btnSelect" />
</UpdatedControls>
</telerik:AjaxSetting>
<telerik:AjaxSetting AjaxControlID="dgArticle">
<UpdatedControls>
<telerik:AjaxUpdatedControl ControlID="Errormgs" />
</UpdatedControls>
</telerik:AjaxSetting>
</AjaxSettings>
</telerik:RadAjaxManager>
    
    <table align="center">
   
     <tr>
    <td><asp:Label ID="Label1" runat="server"  cssclass="Label" Text="PO No.:"></asp:Label></td>
    <td><telerik:RadTextBox ID="txtPONO" runat="server" Skin="WebBlue"></telerik:RadTextBox></td>
    <td><telerik:RadButton ID="btnSearch" runat="server" Skin="WebBlue" Text="GetData"></telerik:RadButton></td>
    </tr>
 
    </table>
   
        <table width="100%">
        <tr>
        <td align="right">
        <asp:Button ID="btnSelect" runat="server" CssClass="button" Text="Select & Close" 
                OnClientClick="window.close();" />
        </td>
        </tr>
        <tr>
        <td align="center"><asp:Label ID="Errormgs" CssClass="ErrorMsg" runat="server" Visible="False" ForeColor="Red"  ></asp:Label></td>
        </tr>
             <tr>
                <td>
                    <telerik:RadGrid ID="dgArticle" runat="server" Skin="WebBlue" 
                        AutoGenerateColumns="false" Visible="true" AllowFilteringByColumn="False" 
                        AllowPaging="False" OnPageIndexChanged="dgArticle_PageIndexChanged" OnSortCommand="dgArticle_SortCommand">
                       
                           <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" /> <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="PO No." DataField="PONO" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
                                    <ItemStyle HorizontalAlign="left" Width="50%" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="POID" DataField="POID" Display="False" AllowFiltering="false" />
                                <telerik:GridBoundColumn HeaderText="Customer" DataField="CustomerName" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
                                    <ItemStyle HorizontalAlign="left" Width="60%" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Supplier" DataField="VenderName" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
                                    <ItemStyle HorizontalAlign="Center" Width="60%" />
                                    <HeaderStyle HorizontalAlign="left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Style ID" DataField="StyleID" Display="false" AllowFiltering="false" />
                                <telerik:GridBoundColumn HeaderText="Style" DataField="StyleNo" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Article" DataField="Article" Display="true" ShowFilterIcon="false" FilterControlWidth="70px" FilterDelay="2000" CurrentFilterFunction="StartsWith" >
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Color" DataField="Colorway" Display="true" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Size" DataField="SizeRange" Display="true" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Rate" DataField="Rate" Display="False" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="PO Quantity" DataField="Quantity" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Shipped Quantity" DataField="ReleaseQty" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                </telerik:GridBoundColumn>
                                <telerik:GridTemplateColumn HeaderText="Release Quantity" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtReleaseQuantity" runat="server" Width="60" CssClass="textbox"
                                            Text='<%#Eval("RemainQTY") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <%--  <telerik:GridBoundColumn HeaderText="Cartons" DataField="Cartons"  >
															    <itemstyle horizontalalign="Center" width="10%" />
															</telerik:GridBoundColumn> --%>
                                <telerik:GridTemplateColumn HeaderText="Cartons" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="Cartons" runat="server" Width="60" CssClass="textbox" Text='<%#Eval("Cartons") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Shipped Rate" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" Width="40%" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="ShippedRate" runat="server" Width="60" ReadOnly="true" CssClass="textbox"
                                            Text='<%#Eval("ShippedRate") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Select" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" runat="server" OnCheckedChanged="UpdateArticle" AutoPostBack="true" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="ID" Display="false" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" CssClass="label" Text='<%#Eval("sid")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridBoundColumn HeaderText="CustomerID" Display="false" DataField="CustomerID" AllowFiltering="false"/>
                                <telerik:GridBoundColumn HeaderText="SupplierID" Display="false" DataField="Vendorid" AllowFiltering="false" />
                                <telerik:GridBoundColumn HeaderText="POPOID" DataField="POPOID" Display="False" AllowFiltering="false" />
                                <telerik:GridBoundColumn HeaderText="Currency" DataField="Currency" Display="False" AllowFiltering="false" />
                                <telerik:GridBoundColumn HeaderText="Inspected Qty" DataField="InspectedQty" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>

                        <ClientSettings AllowGroupExpandCollapse="True" EnableRowHoverStyle="true" ReorderColumnsOnClient="True" AllowDragToGroup="True"
                AllowColumnsReorder="True">
                <Selecting AllowRowSelect="True" />
            </ClientSettings>
              <GroupingSettings ShowUnGroupButton="true" />
            <HeaderStyle Font-Names="Microsoft Sans Serif" />
            <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
               
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
<StatusBarSettings ReadyText="Loading"></StatusBarSettings>
<FilterMenu EnableImageSprites="False" Skin="WebBlue"></FilterMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
    
    </form>
</body>
</html>
