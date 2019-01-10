<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DPIAdd.aspx.vb" Inherits="Integra.DPIAdd" %>
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
    <table>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                PERFORMA INVOICE
            </th>
        </tr>
        <tr>
        </table><br /><table>
         <td style="width: 110px;">
                Report Type
            </td>
            <td style="width: 110px;">
                  <telerik:RadComboBox ID="cmbReportType" style="    width: 243px;" runat="server" AutoPostBack="true" Skin="WebBlue" >
                </telerik:RadComboBox> <%--OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged"--%>
            </td>
        </tr>
        <tr>
        <td>
          <telerik:RadTextBox ID="txtSeason" runat="server" Skin="WebBlue" Width="105px" Visible="false"
                    ReadOnly="false" style=" text-transform :uppercase ;">
                </telerik:RadTextBox></td>
        </tr>
        <tr style="height: 34PX;">
          <td style="width: 110px;">
                Sales Contract
            </td>
            <td style="width: 110px;">
                                <telerik:RadTextBox ID="txtSalesContract"   runat="server" Skin="WebBlue" Width="160px" Visible="true"
                    ReadOnly="true" style=" text-transform :uppercase ;">
                </telerik:RadTextBox>
            </td>
          <td style="width: 110px;">
          </td>
             <td style="width: 110px;">
                P.I Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtPIDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
           </tr>


         </table>   
         
            <table>



        <tr style="height: 34PX;">
         <td style="width: 110px;">
                Season
            </td>
            <td style="width: 110px;">
                  <telerik:RadComboBox ID="cmbSeason" runat="server" AutoPostBack="true" Skin="WebBlue" >
                </telerik:RadComboBox> <%--OnSelectedIndexChanged="cmbSupplier_SelectedIndexChanged"--%>
            </td>
               <td style="width: 110px;">
          </td>
            
            <td style="width: 110px;">
                Customer
            </td>
            <td style="width: 110px;">
                                <telerik:RadComboBox ID="cmbCustomer" runat="server" AutoPostBack="true" Skin="WebBlue" >
                </telerik:RadComboBox>
            </td>
       </tr>
          <tr style="height: 34PX;">
            <td style="width: 110px;">
               SR NO.
            </td>
            <td style="width: 110px;">
                <telerik:RadComboBox ID="cmbSrno" runat="server" AutoPostBack="true" Skin="WebBlue" >
                </telerik:RadComboBox>
            </td>
      
        </tr>
      
    </table>
         
          <asp:Panel ID ="pnlnew" runat ="server" Visible ="false" >
         <table>
         
          <tr>
           <td style="width: 110px;">
                For account & risk 
            </td>
            <td style="width: 110px;">
                                <telerik:RadTextBox ID="txtForaccountAndRisk" runat="server" Skin="WebBlue" Width="245px" Visible="true"
                    ReadOnly="false" style=" text-transform :uppercase ;" TextMode ="MultiLine" >
                </telerik:RadTextBox>
            </td>
              <td style="width: 110px;">
          </td>
             <td style="width: 110px;">
               Notify party
            </td>
            <td style="width: 110px;">
                                <telerik:RadTextBox ID="txtNotifyparty" runat="server" Skin="WebBlue" Width="245px" Visible="true"
                    ReadOnly="false" style=" text-transform :uppercase ;  margin-top: 7px;" TextMode ="MultiLine" >
                </telerik:RadTextBox>
            </td>
          </tr>

          <tr>
           <td style="width: 110px;">
                Payment To 
            </td>
            <td style="width: 110px;">
                                <telerik:RadTextBox ID="txtPaymentTo" runat="server" Skin="WebBlue" Width="245px" Visible="true"
                    ReadOnly="false" style=" text-transform :uppercase ; margin-top: 7px;" TextMode ="MultiLine"  >
                </telerik:RadTextBox>
            </td>
              <td style="width: 110px;">
          </td>
             <td style="width: 110px;">
               Consignee
            </td>
            <td style="width: 110px;">
                                <telerik:RadTextBox ID="txtConsignee" runat="server" Skin="WebBlue" Width="245px" Visible="true"
                    ReadOnly="false" style=" text-transform :uppercase ;     margin-top: 9px;" TextMode ="MultiLine" >
                </telerik:RadTextBox>
            </td>
          </tr>


          <tr style="height: 34PX;">
          <td style="width: 110px;">
                Brand and section
            </td>
            <td style="width: 110px;">
                                <telerik:RadTextBox ID="txtBrandandsection" runat="server" Skin="WebBlue" Width="160px" Visible="true"
                    ReadOnly="false" style=" text-transform :uppercase ;">
                </telerik:RadTextBox>
            </td>
          <td style="width: 110px;">
          </td>
             <td style="width: 110px;">
                Revised Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtRevisedDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
           </tr>

            <tr>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label22" runat="server" Text="Payment Term."></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPaymentTerm" runat="server" Skin="WebBlue">
                        <ClientEvents OnButtonClick="ClearRadControls" />
                    </telerik:RadTextBox>
                 
                </td>
                <td>
                    <asp:Label ID="Label24" runat="server" Text="Port Of Loading"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtPortOfLoading" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                   
                         
                </td>
                <td style="height: 30px; width: 128px;">
                    <asp:Label ID="Label26" runat="server" Text="Final Destination"></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox ID="txtFinalDestination" runat="server" Skin="WebBlue">
                    </telerik:RadTextBox>
                  
                </td>
            </tr>

           
           </table>  
           
            </asp:Panel>
           





       <table>
        <tr>
            
            <td>
               <%-- <telerik:RadButton ID="btnAdd" runat="server" Text="Add" Width="50px" Skin="WebBlue">
                </telerik:RadButton>--%>
                <telerik:RadButton ID="btnAdd" runat="server" Text="Add" Skin="WebBlue" Width="50px">
                </telerik:RadButton>
            </td>
            
        </tr>
    </table>
    <br />
    <table width="30%">
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="dgPI" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                    Skin="WebBlue" Visible="true" PageSize="50" OnDeleteCommand="dgPI_DeleteCommand" AllowAutomaticDeletes="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="DPIDtlID" DataField="DPIDtlID" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                         
                       <telerik:GridBoundColumn HeaderText="Joborderid" DataField="Joborderid" Display="false">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="SRNO" DataField="SRNO" Display="true">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle Width="5%" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                 
                             <telerik:GridButtonColumn UniqueName="Edit" Text="Edit" CommandName="Edit" Visible ="false" 
                                ConfirmTextFormatString="Are You Sure You want to Edit Record" HeaderStyle-Width="2%"
                                ButtonType="ImageButton">
                            </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn UniqueName="DeleteColumn" Display="true" HeaderText="Delete" Text="Delete" CommandName="Delete"  Visible ="true" 
                                ConfirmTextFormatString="Are You Sure You want to Delete Record" HeaderStyle-Width="7%"
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
    <table width="100%">
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td colspan="1" align="right">
                <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                </telerik:RadButton>
            </td>
            <td>
            </td>
               <td>
            </td>
               <td>
            </td>
            <td>
                <telerik:RadButton ID="btnCancel" runat="server" Text="Cancel" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
        
    </table>
</asp:Content>
