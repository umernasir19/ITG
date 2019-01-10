<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DyeWashRecipeEntry.aspx.vb" Inherits="Integra.DyeWashRecipeEntry" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
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
   
    </script>
     <table width ="100%">
                <tr>
                    <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                        font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                        bgcolor="Silver">
                        DYEING/WASHING RECIPE
                    </th>
                </tr>
                </table> 
               <table>
                <tr style="height: 30px;">
                    <td style="width: 180px;">
                        Recipe No:
                    </td>
                    <td style="width: 160px;">
                    <asp:TextBox ID="txtRecipeNo" CssClass="textbox" AutoPostBack="false" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                        
                    </td>
                    <td style="width: 180px;">
                        Composition:
                    </td>
                    <td style="width: 160px;">
                    <asp:TextBox ID="txtComp" CssClass="textbox" AutoPostBack="false" runat="server" Style="width: 150px;
                            text-transform: uppercase;"></asp:TextBox>
                        
                    </td>
                    </tr>
                    <tr>
                    <td style="width: 180px;">
                        Date:
                    </td>
                    <td style="width: 160px;">
                        <asp:TextBox ID="txtCreationDate" CssClass="textbox" Width="129" runat="server" AutoPostBack="false"
                            Style="text-transform: uppercase;  margin-top: -16px;"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                            PopupButtonID="ImageButton1" />
                        <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/callendar.JPG"
                            AlternateText="Click here to display calendar" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                            Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                            CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                            Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                        </cc1:MaskedEditExtender>
                    </td>
                      <td style="width: 180px;">
                       Color:
                    </td>
                     <td style="width: 160px;">
                        <asp:TextBox ID="txtColor" CssClass="textbox" AutoPostBack="false" runat="server" Style="width: 150px;
                            text-transform: uppercase;     margin-top: -4px;"></asp:TextBox></td> 
                </tr>
                  <tr>
                           <td style="width: 180px;">
                        Customer Name:
                    </td>
                    <td style="width: 160px;">
                     
                      <telerik:RadComboBox ID="cmbCustomer" runat="server" AutoPostBack="false" Width ="140px" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </td>     
                           
                     <td style="width: 180px;">
                        Internal Order No.:
                    </td>
                    <td style="width: 160px;">

                     <telerik:RadComboBox ID="CMBIntOrdNo" runat="server" AutoPostBack="TRUE" Width ="200px" Skin="WebBlue">
                        </telerik:RadComboBox>

                          

                      
                    </td>
                   
                     </tr>
                <tr style="height: 30px;">
                       <td style="width: 180px;">
                        Style :
                    </td>
                    <td style="width: 160px;">
                     
                      <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="true" Width ="140px" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </td>
            
                     <td style="width: 180px;">
                        Qty-Pcs
                    </td>
                   <td style="width: 160px;">
                             <asp:TextBox ID="txtQtyPcs" CssClass="textbox" runat="server" AutoPostBack="true" ReadOnly ="true"  onkeypress="return isNumericKeyy(event);"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                    </td>
                        </tr>
                          <tr style="height: 30px;">
                        <td style="width: 180px;">
                        MachineID :
                    </td>
                   <td style="width: 160px;">
                     
                    <asp:TextBox ID="txtMachine" CssClass="textbox" runat="server" AutoPostBack="false"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                    </td></tr> 
                     <tr>
                <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                    font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                    bgcolor="Silver">
                    DYEING WASHING PROCESS
                </th>
            </tr>
              <tr style="height: 30px;">
                       <td style="width: 180px;">
                        Chemical Product Lot No :
                    </td>
                    <td style="width: 160px;">
                     
                       <asp:TextBox ID="txtChPrlot" CssClass="textbox" runat="server" AutoPostBack="false"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                    </td>
            
                      <td style="width: 180px;">
                       Chemical Product Name
                    </td>
                    <td style="width: 160px;">
                             <asp:TextBox ID="txtChemName" CssClass="textbox" runat="server" AutoPostBack="true"
                            Style="width: 150px; text-transform: uppercase;"></asp:TextBox>
                               <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchChemName" EnableCaching="true" MinimumPrefixLength="1"
                            ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtChemName" />
                    </td>
                    <td>
                      <asp:Label ID="lblChemPrID" runat="server" Text="0" Visible="FALSE"></asp:Label>
                    </td>
                        </tr>
                <tr style="height: 30px;">
                    <td style="width: 180px;">
                        Unit:
                    </td>
                     <td style="width: 160px;">
                         <telerik:RadComboBox ID="cmbUnit" runat="server" AutoPostBack="false" Width ="70px" Skin="WebBlue">
                        </telerik:RadComboBox>
                    </td>
                      <td style="width: 180px;">
                        Qty:
                    </td>
                     <td style="width: 160px;">
                        <asp:TextBox ID="txtQty" CssClass="textbox" runat="server" AutoPostBack="false" onkeypress="return isNumericKeyy(event);"
                            Style="width: 150px;"></asp:TextBox>
                    </td>
                </tr>
                </table> <br />
                <table width ="100%" >
                  <tr>
                <td>
                    <telerik:RadButton ID="BtnDetail" runat="server" Width="100px" Text="Add Detail"
                        Skin="WebBlue">
                    </telerik:RadButton>
                  
                </td>
            </tr>
                   <tr>
                <td colspan="4"><br />
                    <telerik:RadGrid ID="DgDetail" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="true" PageSize="50" AllowAutomaticDeletes="false">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="DyeWashRecipeDtlId" DataField="DyeWashRecipeDtlId"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn HeaderText="ChemPrID" DataField="ChemPrID"
                                    Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Chem Product Lot No" DataField="ChemPrLotNo" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="8%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Chem Product Name" DataField="ChemPrName" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="8%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Unit" DataField="Unit" Display="true">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Qty" DataField="Qty">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />


                                </telerik:GridBoundColumn><telerik:GridBoundColumn HeaderText="ItemUnitID" DataField="ItemUnitID" Display="FALSE">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                                   
                           
                                <telerik:GridTemplateColumn HeaderText="Edit" UniqueName="Edit" AllowFiltering="false"  Visible ="false" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkEdit" ToolTip="Click here to edit" ImageUrl="~/Images/editIcon.jpg"
                                            CommandName="Edit" runat="server"   ></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn UniqueName="DeleteColumn" Text="" CommandName="Delete" Visible ="false" 
                                    ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="5%"
                                    ButtonType="ImageButton">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
                </table><br />
                  <table>
            <tr>
                <td>
                    <asp:Button ID="btnSave" runat="server" Skin="WebBlue" Text="Save" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="120px" CausesValidation="true"
                        Visible="true" Style="margin-left: 320px;"></asp:Button>
                </td>
                <td>
                    <asp:Button ID="btncancel" runat="server" Skin="WebBlue" Text="Cancel" Font-Bold="True"
                        Font-Names="Calibri" Font-Size="Medium" Height="30px" Width="110px" Visible="true"
                        Style="margin-left: 10px;"></asp:Button>
                </td>
            </tr>
</asp:Content>
