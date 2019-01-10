<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QualityDepartmentPopup.aspx.vb"
    Inherits="Integra.QualityDepartmentPopup" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quality Department Page</title>
    <link href="../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" CssClass="labelNew" Text="PO No." runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPONO" CssClass="labelNew" runat="server"></asp:Label>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="Label2" CssClass="labelNew" Text="Supplier:" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSupplier" CssClass="labelNew" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" CssClass="labelNew" Text="Customer:" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblCustomer" CssClass="labelNew" runat="server"></asp:Label>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="Label4" CssClass="labelNew" Text="Shipment:" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblShipment" CssClass="labelNew" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" CssClass="labelNew" Text="Dept:" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblEknumber" CssClass="labelNew" runat="server"></asp:Label>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="Label6" CssClass="labelNew" Text="Season:" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSeason" CssClass="labelNew" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save My Selection(s)"
                    Width="134px" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMsg" runat="server" CssClass="ErrorMsg"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgPurchaseOrder" runat="server" Width="105%" OnSortCommand="SortByColumn"
                            OnPageIndexChanged="PageChanged" OnItemDataBound="DataBound" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="50" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="POID" DataField="POID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="PoDetailID" DataField="PoDetailID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Style" DataField="StyleNo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="ColorRefNo" DataField="ColorRefNo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="HS Code" DataField="StyleDescription">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Size" DataField="SizeRange">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Color" DataField="Colorway">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Order Qty" DataField="OrderQty">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="4%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Shipped Qty" DataField="InspectedQty">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="4%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Today Insp. Qty">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtInsQty" runat="server" TabIndex ="1" Width="37px" Text="0" CssClass="textbox" AutoPostBack="false" OnTextChanged="txtInsQty_TextChanged"></asp:TextBox>
                                        <asp:ImageButton id="imgcalculate"   runat="server" visible="true"  tooltip="Click here to calculate" CommandName="Calculate"  ImageUrl="~/Images/redCal.jpg"  />
                                    </ItemTemplate>
                                    <HeaderStyle Width="13%" />
                                </asp:TemplateColumn>
                                  <asp:TemplateColumn HeaderText="+/- Qty">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtASubQty" runat="server" Width="35px" Text="0" CssClass="textbox" ReadOnly ="true" TabIndex ="2"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="8%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="QA Name">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbQDName" Width="110" CssClass="textbox" AutoPostBack="false"
                                            runat="server" OnSelectedIndexChanged="cmbQDName_SelectedIndexChanged" TabIndex ="3">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="8%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Ins. Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadDatePicker ID="txtInspDate" runat="server" Width="100" Culture="en-US">
                                            <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" TabIndex ="4">
                                            </Calendar>
                                            <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy"
                                                LabelWidth="40%">
                                            </DateInput>
                                            <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex ="4"></DatePopupButton>
                                        </telerik:RadDatePicker>
                                    </ItemTemplate>
                                    <HeaderStyle Width="12%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Insp. Type">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbStatus" Width="75" AutoPostBack="false" CssClass="textbox"
                                            runat="server" OnSelectedIndexChanged="cmbStatus_SelectedIndexChanged" TabIndex ="5">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Insp. Status">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:DropDownList ID="cmbInspStatus" Width="60" AutoPostBack="false" CssClass="textbox"
                                            runat="server" OnSelectedIndexChanged="cmbInspStatus_SelectedIndexChanged" TabIndex ="6">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Major Error Code">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="cmbErrorCode" Width="80" runat="server" CheckBoxes="true" AutoPostBack ="false" 
                                            Skin="WebBlue" onselectedindexchanged="cmbErrorCode_SelectedIndexChanged"  >
                                        </telerik:RadComboBox>
                                        
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="Minor Error Code">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="cmbMinorErrorCode" Width="80" runat="server" CheckBoxes="true" AutoPostBack ="false" 
                                            Skin="WebBlue" onselectedindexchanged="cmbMinorErrorCode_SelectedIndexChanged"  >
                                        </telerik:RadComboBox>
                                        
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                 <asp:TemplateColumn HeaderText="">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                       <asp:ImageButton id="imgAutoFill" runat="server" visible="true"  tooltip="Click here to auto fill" CommandName="AutoFill"  ImageUrl="~/Images/redCal.jpg"  />
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="QA Remarks">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemarks" runat="server" Width="80" CssClass="textbox" TabIndex ="8"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText=" ">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkStatus" runat="server"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" />
                                </asp:TemplateColumn>




                                    <asp:BoundColumn HeaderText="Shipment Date" DataField="Detailshipmentdatee">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="10%" HorizontalAlign="Left" />
                                </asp:BoundColumn>



                                <asp:TemplateColumn HeaderText="View">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdiut" ToolTip="To View QD Inspection History for this Article."
                                            Enabled="true" NavigateUrl='<%# "QualityDepartmentHistory.aspx?lPOID="& DataBinder.Eval(Container.DataItem,"POID")&"&lPODetailID="& DataBinder.Eval(Container.DataItem,"PoDetailID")%>'
                                            runat="server">History</asp:HyperLink>
                                    </ItemTemplate>
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
    <%--<table width="100%">
 <tr>
 <td>
  <asp:Label ID="Label7" CssClass="labelNew"  Text="Images/PDF uploading section:" runat="server" ></asp:Label> 
   
 </td>
 </tr>
  <tr>
 <td>
  <asp:Label ID="lblErrorMsg" CssClass="ErrorMsg" runat="server" ></asp:Label> 
   
 </td>
 </tr>
 <tr>
 <td>
     <asp:FileUpload ID="FileUpload1" runat="server" />
  
     &nbsp;
  
     <asp:Button ID="btnUpload" CssClass="button" runat="server" Text="Upload" />
 </td>
 </tr>
  </table>--%>
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <Smart:SmartDataGrid ID="dgFileInfo" runat="server" Width="100%" AllowPaging="True"
                            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                            PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                            ShowFooter="True" SortedAscending="yes" ForeColor="White">
                            <Columns>
                                <asp:BoundColumn HeaderText="ID" DataField="ID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="POID" DataField="POID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Creation Date" DataField="CreationDate">
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
                                <asp:TemplateColumn HeaderText="Remove">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
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
    </form>
</body>
</html>
