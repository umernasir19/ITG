<%@ Page Title="Cargo Style Description" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="CargoStyleDescription.aspx.vb" Inherits="Integra.CargoStyleDescription" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
    function TABLE1_onclick() {

    }

    </script>
      <table width="100%">
        <tr>
            <th colspan="16" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Style Description 
            </th>
        </tr>
    
        </table><br />
<table>
 <tr>

           <td>
               Invoice NO#:
            </td>

            <td>
             <asp:TextBox ID="txtInvoiceNO" runat="server" CssClass="forcapital" ReadOnly ="true"  AutoPostBack="false" Width="150px" style=" margin-left: 0px;"></asp:TextBox>
                       </td>



            </tr> 
            </table> 
            <br />
            <br />
             <table>
            <tr>
            <td>
             <div style ="width :930px;" >
           
                        <Smart:SmartDataGrid ID="dgDetail"  runat="server"
                            Width="100%" AllowSorting="True" AutoGenerateColumns="False" CellPadding="2"
                            CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="300"
                            RecordCount="0" ShowFooter="True" SortedAscending="yes">
                            <Columns>

                              <asp:BoundColumn HeaderText="CargoStyleDtlID" DataField="CargoStyleDtlID" Visible="false" />
                                        <asp:BoundColumn HeaderText="STYLE" DataField="Styles" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundColumn>                         
                                  <asp:TemplateColumn HeaderText="DESCRIPTION">
                            <ItemStyle Width="5%" HorizontalAlign="center"></ItemStyle>
                            <ItemTemplate>
                                <asp:TextBox ID="txtDesc" runat="server" ReadOnly ="false"  Width="300px" CssClass="textbox" style="text-transform :uppercase ;"  ></asp:TextBox>
                            </ItemTemplate>
                            <HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
                        </asp:TemplateColumn>
                           <asp:BoundColumn HeaderText="PCS" DataField="qtyy" Visible="true">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:BoundColumn>
                        
                         
                             
                            </Columns>
                            <PagerStyle Visible="False" CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right" />
                            <AlternatingItemStyle CssClass="GridAlternativeRow" />
                            <ItemStyle CssClass="GridRow" />
                            <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
                        </Smart:SmartDataGrid>
                               </div>
            </td>
            </tr>
            </table>
            <br />
    <table>
            <tr>
            <td>
                 <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Visible ="true" 
                            Width="120px" /></td>

                              <td>
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" Visible ="true" 
                            Width="120px" /></td>
            </tr>
            </table>
</asp:Content>
