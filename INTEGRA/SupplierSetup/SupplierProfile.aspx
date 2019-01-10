<%@ Page Language="vb" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeBehind="SupplierProfile.aspx.vb" Inherits="Integra.SupplierProfile" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
      function mathRoundForTaxes(source) {
          var txtBox = document.getElementById(source);
          var txt = txtBox.value;
          if (!isNaN(txt) && isFinite(txt) && txt.length != 0) {
              var rounded = Math.round(txt * 100) / 100;
              txtBox.value = rounded.toFixed(2);
          }
      }
      function NotZero(source) {
          var txtBox = document.getElementById(source);
          var txt = txtBox.value;
          if (txt == 0) {
              txtBox.value = 1;
          }
      }

      function selectOneside(val) { //here val is my dropdown ID
          var Dval = val.selectedIndex;
          if (Dval == "2") {
              val.selectedIndex = 0;
          }
      }
    </script>
    <div>
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Supplier Information
                </th>
            </tr>
            <tr>
                <td style="width: 88px; height: 30px;">
                    <asp:Label ID="lblSupplierType" runat="server" Text="Supplier Type" Visible="false"></asp:Label>
                    <asp:Label ID="lblSupplierCat" runat="server" Text="Supplier Category"></asp:Label>
                </td>
                <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                    <telerik:RadComboBox ID="cmbSupCat" runat="server" Skin="WebBlue"   >
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="cmbSupplierType" runat="server" Skin="WebBlue" Visible="false">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Active" />
                            <telerik:RadComboBoxItem Value="1" Text="Potential" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
                <td style="width: 85px; height: 30px;" align="left">
                    <asp:Label ID="lblSupplierCode" runat="server" Text="Supplier Code"></asp:Label>
                </td>
                <td style="width: 165px; height: 30px;">
                    <telerik:RadTextBox ID="txtSupplierCode" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 87px; height: 30px;">
                   
                </td>
                <td style="height: 30px">
               
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblSupplierName" runat="server" Text="Supplier Name"></asp:Label>
                </td>
                <td colspan="5">
                    <telerik:RadTextBox ID="txtSupplierName" runat="server" Height="20px" Width="210px"
                        Skin="WebBlue">
                    </telerik:RadTextBox>
                    &nbsp;&nbsp;
                     <asp:Label ID="lblShortName" runat="server" Text="Short Name"></asp:Label>
                      &nbsp;&nbsp;
                           <telerik:RadTextBox ID="txtShortName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                        &nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="Year Started"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtYearStarted" CssClass="textbox" runat="server"></asp:TextBox>
                    &nbsp;&nbsp; &nbsp;&nbsp;
                
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblAddressLine1" runat="server" Text="Head Office Add."></asp:Label>
                </td>
                <td colspan="5">
                    <telerik:RadTextBox ID="txtAddress1" runat="server" Height="20px" Width="410px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblAddressLine2" runat="server" Text="Address Line 2"></asp:Label>
                </td>
                <td colspan="5">
                    <telerik:RadTextBox ID="txtAddress2" runat="server" Width="410px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbCountry" runat="server" AutoPostBack="True" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
                <td>
                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <telerik:RadComboBox ID="cmbCity" runat="server" Skin="WebBlue">
                    </telerik:RadComboBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="lblZIP" runat="server" Text="ZIP Code"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtZIPCode" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblWebAddress" runat="server" Text="Web Address"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtWebsite" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="lblContactNo" runat="server" Text="Phone"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtContactNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="lbFaxNo" runat="server" Text="Fax"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtFaxNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
            <td>
                Location
                </td>

                <td>
                
                 <telerik:RadTextBox ID="txtLocation" runat="server" Width="120px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Demographics
                </th>
            </tr>
            <tr>
                <td>
                    Factory (Unit)
                </td>
                <td>
                    <asp:TextBox ID="txtFactory" CssClass="textbox" runat="server"></asp:TextBox>
                </td>
                <td>
                    Covered Area
                </td>
                <td>
                    <asp:TextBox ID="txtCoveredArea" CssClass="textbox"  onkeypress="return isNumericKeyy(event);" runat="server"></asp:TextBox>
                </td>
                <td>
                    Town
                </td>
                <td>
                    <asp:DropDownList ID="cmbTown" AutoPostBack="false" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                    <asp:Button ID="btnAddDetail" runat="server" Text="Add More" />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgDemographics" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" OnDeleteCommand="dgDemographics_DeleteCommand">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="VDID" DataField="VDID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="TownID" DataField="TownID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Factory" DataField="Factory">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Covered Area" DataField="CoveredArea">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Town" DataField="Town">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Personnel Information
                </th>
            </tr>
            <tr>
                <td style="width: 85px">
                    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPersonName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="lblDesignation" runat="server" Text="Designation"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtDesignation" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblCellNo" runat="server" Text="Cell No"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtCellNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtEmail" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    &nbsp;
                </td>
                <td colspan="2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    <telerik:RadButton ID="txtAddMore" runat="server" Text="Add More" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgVenderPersonnel" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" OnDeleteCommand="dgVenderPersonnel_DeleteCommand">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="VenderPersonnelID" DataField="VenderPersonnelID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Contact Type" Visible="False" DataField="ContactType">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Name" DataField="PersonName">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Designation" DataField="Designation">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Cell No" DataField="CellNo">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Email" DataField="EmailAddress">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td style="width: 88px">
                    <asp:Label ID="lblVerticalIntegration" runat="server" Text="Vertical Integration"></asp:Label>
                </td>
                <td  style="height: 60px" valign="middle">
                    <asp:UpdatePanel ID="UpcmbVerticalIntegration" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadComboBox ID="cmbVerticalIntegration" runat="server" CheckBoxes="false"
                                Skin="WebBlue">
                            </telerik:RadComboBox>
                            <asp:ImageButton ID="btnaddverticalintegration" runat="server" ToolTip="click to add in dropdown"
                                ImageUrl="~/images/plus.jpg" Visible="false" />
                            <asp:TextBox ID="txtverticalintegration" ToolTip="click to add new item" Width="80"
                                runat="server"></asp:TextBox>
                            <asp:Button ID="btnsaveverticalintegration" runat="server" Width="61" CssClass="btn btn-outline btn-success"
                                Text="save" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpbtnAddVerticalIntegration" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UptxtVerticalIntegration" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <%-- <asp:TextBox ID="txtVerticalIntegration" ToolTip="Click to add New Item" Width="80"
                                runat="server"></asp:TextBox>
                            <asp:Button ID="btnSaveVerticalIntegration" runat="server" Style="margin-left: 6px;"
                                Width="61" CssClass="btn btn-outline btn-success" Text="Save" />--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpbtnSaveVerticalIntegration" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td>
                      <telerik:RadComboBox ID="cmbInHOutS" runat="server" Skin="WebBlue" Visible="true" SortCaseSensitive="True" Width="80">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="In House" />
                            <telerik:RadComboBoxItem Value="1" Text="Out Source" />
                        </Items>
                    </telerik:RadComboBox>
                    </td>
                    <td>
                <ASP:Button ID="btnVerticalIntegration" runat="server" Text="Add More" >
                    </ASP:Button></td>
            </tr>
                    <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgVerticalIntegration" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" >
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="VenderDetailID" DataField="VenderDetailID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="VenderID" Display ="false" DataField="VenderID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="ID" Display ="false"  DataField="ID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Vertical Integration" DataField="VerticalIntegration">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="In House/Out Source" DataField="InhouseOutSource">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                               
                                <telerik:GridBoundColumn HeaderText="Type" DataField="Type" Display ="false"> 
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                           <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td style="height: 88px">
                    <asp:Label ID="lblProductPortfolio" runat="server" Text="Product Portfolio"></asp:Label>
                </td>
                <td  style="height: 60px" valign="middle">
                    <asp:UpdatePanel ID="UpcmbProductPortfolio" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <telerik:RadComboBox ID="cmbProductGroup" runat="server" CheckBoxes="True" Skin="WebBlue">
                            </telerik:RadComboBox>
                            <asp:ImageButton ID="btnAddProductPortfolio" runat="server" ToolTip="Click to add in Dropdown"
                                ImageUrl="~/Images/plus.jpg" Visible="false" />
                            <asp:TextBox ID="txtProductPortfolio" ToolTip="Click to add New Item" Width="80"
                                runat="server"></asp:TextBox>
                            <asp:Button ID="btnSaveProductPortfolio" runat="server" Style="margin-left: 6px;"
                                Width="61" CssClass="btn btn-outline btn-success" Text="Save" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpbtnAddProductPortfolio" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UptxtProductPortfolio" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <%--<asp:TextBox ID="txtProductPortfolio" ToolTip="Click to add New Item" Width="80" runat="server"></asp:TextBox>
                            <asp:Button ID="btnSaveProductPortfolio" runat="server" Style="margin-left: 6px;" Width="61"
                                CssClass="btn btn-outline btn-success" Text="Save" />--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpbtnSaveProductPortfolio" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                <ASP:Button ID="btnProductPortFolio" runat="server" Text="Add More" >
                    </ASP:Button></td>
            </tr>
                    <tr>
                <td colspan="6">
                    <telerik:RadGrid ID="dgProductPortFolio" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="False" PageSize="50" AllowAutomaticDeletes="false" >
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="VenderDetailID" DataField="VenderDetailID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="VenderID" Visible="False" DataField="VenderID">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="ID" DataField="ID" Visible="False">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="Product Portfolio" DataField="ProductPortfolio">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Type" DataField="Type">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                               
                              <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete"
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
                <td style="width: 88px">
                    <asp:Label ID="lblIntroduction" runat="server" Text="Introduction"></asp:Label>
                </td>
                <td colspan="5" style="height: 80px">
                    <telerik:RadTextBox ID="txtAboutSupplier" runat="server" Height="64px" TextMode="MultiLine"
                        Width="500px" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblCapacity" runat="server" Text="Production Capacity"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtCapacity" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td colspan="4">
                    <telerik:RadComboBox ID="cmbCapacityUnit" runat="server" Skin="WebBlue">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="PCs" />
                            <telerik:RadComboBoxItem Value="1" Text="Dozen" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="Label2" runat="server" Text="Minimum Quantity"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtMinQty" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="Label3" runat="server" Text="Lead Time"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtLeadTime" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="lblturnover" runat="server" Text="Turnover In Value"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtTurnOver" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td colspan="4">
                    <telerik:RadComboBox ID="cmdTurnOverUnit" runat="server" Skin="WebBlue">
                        <Items>
                            <telerik:RadComboBoxItem Value="0" Text="Dollar" />
                            <telerik:RadComboBoxItem Value="1" Text="PKR" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Turn Over In Pcs
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="Label4" runat="server" Text="1 Year"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtoneyear" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="2 Years"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txttwoyear" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="Label6" runat="server" Text="3 Years"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtthreeyear" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            </table>
            <table width ="100%">
            <tr>
                <th colspan="8" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Social Compliance
                </th>
            </tr>
            <tr style="height: 35px;">
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="txtSocialComplianceName" ToolTip="Click to add New Item" Width="80"
                        runat="server"></asp:TextBox>
                </td>
                <td>
                    Certification Date
                </td>
                <td>
                   
                    <asp:TextBox ID="SCCreationDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" runat="server" TargetControlID="SCCreationDate"
                        PopupButtonID="ImageButton3" />
                    <asp:ImageButton runat="Server" ID="ImageButton3" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="SCCreationDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                      
                </td>
                 <td>
                    Expiry Date
                </td>
                <td>
                 
                    <asp:TextBox ID="txtExpiryDate" Width="100" runat="server" CssClass="textbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtExpiryDate"
                        PopupButtonID="ImageButton4" />
                    <asp:ImageButton runat="Server" ID="ImageButton4" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                        AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtExpiryDate"
                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                    </cc1:MaskedEditExtender>
                    
                </td>
                <td>
                    Social Compliance Certificate:
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="select jpg file to attach and press upload" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                </td>
                <td>
                    <asp:Button ID="btnUpload1" CssClass="button" runat="server" Text="Upload" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Label ID="lblErrorMsg" runat="server" CssClass="ErrorMsg"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:UpdatePanel ID="UpdgSocialCompliance" runat="server">
                        <ContentTemplate>
                            <Smart:SmartDataGrid ID="dgSocialCompliance" runat="server" Width="100%" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table"
                                PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="15" RecordCount="0"
                                ShowFooter="True" SortedAscending="yes" ForeColor="White">
                                <Columns>
                                    <asp:BoundColumn HeaderText="VenderSocialComplianceID" DataField="VenderSocialComplianceID"
                                        Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="VenderID" DataField="VenderID" Visible="false">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    
                                    <asp:BoundColumn HeaderText="Name" DataField="CertificateName">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Certification Date" DataField="Creationdatee">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                      <asp:BoundColumn HeaderText="Expiry Date" DataField="Expirydatee">
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                    </asp:BoundColumn>
                                    <asp:TemplateColumn HeaderText=" " Visible="true">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkFIle" Visible="true" CommandName="DownloadFile" Text="Show Certificate"
                                                runat="server"> </asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText=""  Visible="False">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Image1" Visible="true" CommandName="ShowFileOrImage" runat="server"
                                                Height="100" Width="80" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="7%" />
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="Remove">
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
            <table width ="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Financial Handling
                </th>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="Label7" runat="server" Text="Bank Name"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBankName" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Bank Code"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBankCode" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="Label9" runat="server" Text="Bank Address"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBankAddress" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 88px;">
                    <asp:Label ID="Label10" runat="server" Text="Fax"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBankFax" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="A/C No."></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBankACNo" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
                <td style="width: 85px">
                    <asp:Label ID="Label12" runat="server" Text="Swift Code"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtBankSwiftCode" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    Remarks
                </th>
            </tr>
            <tr style="height: 38px;">
                <td colspan="8">
                    <asp:TextBox ID="txtRemarks" Width="924" CssClass="textbox" runat="server" Visible="true"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="100%">
            <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    VAF
                </th>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Label ID="lblvafmsg" runat="server" CssClass="ErrorMsg"></asp:Label>
                </td>
            </tr>
            <tr style="height: 35px;">
                <td>
                    VAF Name
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" ToolTip="Click to add New Item" Width="80" runat="server"></asp:TextBox>
                </td>
                <td>
                    VAF:
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" ToolTip="select jpg file to attach and press upload" />
                </td>
                <td>
                    <asp:Button ID="btnVAF" CssClass="button" runat="server" Text="Upload VAF" />
                </td>
                <td>
                          <asp:UpdatePanel ID="UpPic" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkFIlePicture" Text="Show VAF" Style="margin-left: 8px;"
                                runat="server" Visible="false"> </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            <%--        <asp:Image ID="ImageVAF" Visible="true" CommandName="ShowFileOrImage" runat="server"
                        Height="100" Width="80" />--%>
                </td>
            </tr>
        </table>
       <table width="100%">
        <tr>
        <td>LAST UPDATE BY </td>
        <td> <asp:TextBox ID="txtLastupdatedBy" ToolTip="Click to add New Item" Width="180" runat="server"></asp:TextBox></td>
        <td>LAST UPDATE ON</td>
        <td> <asp:TextBox ID="txtLastUpdatedon" ToolTip="Click to add New Item" Width="100" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>CLAIM RECORD</td>
        <td><asp:LinkButton ID="lnkCLAIMRECORD" runat="server">CLAIM RECORD     
                            </asp:LinkButton></td>
        </tr>
        </table>

        <table width="100%">
            <tr>
                <td>
                </td>
                <td colspan="5">
                    <asp:UpdatePanel ID="upCertificate" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkCertificate" runat="server">
              Check all quality certifications that you possess, upload a scanned image or PDF of your certificate, and enter an expiry 
                            </asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td style="height: 30px; width: 128px;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                </td>
                <td colspan="2" align="right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
                <td>
                    &nbsp;
                    <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                    </telerik:RadButton>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
