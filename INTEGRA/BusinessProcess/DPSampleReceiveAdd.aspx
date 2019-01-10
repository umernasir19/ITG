<%@ Page Title="Sample Receive" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="DPSampleReceiveAdd.aspx.vb" Inherits="Integra.DPSampleReceiveAdd" %>
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



    <div>
        <table width="100%">
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Sample Receive
            </th>
        </tr>



        <tr style="height :34PX;">
            <td style="width: 110px;">
                Receive Date
            </td>
            <td style="width: 110px;">
                <telerik:RadDatePicker ID="txtReceiveDate" runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td style="width: 110px;">
                Receive Time
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtReceiveTime" runat="server" Skin="WebBlue" Width="105px"
                    Visible="true" ReadOnly="true">
                </telerik:RadTextBox>
            </td>
        </tr>



        <tr>
         <td style="width: 110px;">
                DSR No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtDSRNO" runat="server" Skin="WebBlue" ReadOnly="TRUE" Width="105px" Visible="true">
                </telerik:RadTextBox>
            </td>
        </tr>


         <tr>
         <td style="width: 110px;">
                DSI No.
            </td>
        



               <td style="height: 30px">
                                <asp:TextBox ID="txtDSINo" runat="server" autocomplete="off" AutoPostBack="true"
                                    Style="margin-left: 0px; width: 150px;" ReadOnly="false"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="autoComplete2" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="SearchDSINo" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDSINo" />
                              <asp:Label ID="LBLfABRICiSSUEid" runat="server" Text="FabricIssueID" Visible ="false" ></asp:Label>
                            </td>
        </tr>







           
                        <tr>
                            <td style="height: 30px; width: 87px;">
                                <asp:Label ID="lblDalNo" runat="server" Text="DAL No."></asp:Label>
                            </td>
                            <td style="height: 30px">
                                <asp:TextBox ID="txtDalNoO" runat="server" autocomplete="off" ReadOnly ="true"  AutoPostBack="true"
                                    Style="margin-left: 0px; width: 150px;"></asp:TextBox>
                                <cc1:AutoCompleteExtender ID="autoComplete1" runat="server" CompletionInterval="10"
                                    CompletionSetCount="12" ContextKey="SearchDalNo" EnableCaching="true" MinimumPrefixLength="1"
                                    ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtDalNoO" />
                                <asp:Label ID="lblFabricMstId" runat="server" Text="0" Visible="false"></asp:Label>
                            </td>
                            <td style="height: 30px; width: 85px;">
                                <asp:Label ID="Label6" runat="server" Text="Style No."></asp:Label>
                            </td>
                            <td class="TopHeaderTd3" style="width: 165px; height: 30px;">
                                <asp:UpdatePanel ID="UpcmbStyleNo" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadComboBox ID="cmbStyleNo" runat="server" AutoPostBack="True" Skin="WebBlue" OnSelectedIndexChanged="cmbStyleNo_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>




                         <tr style="height :34PX;">
            <td style="width: 110px;">
               Issued Qty
            </td>
            <td style="width: 110px;">
              <asp:UpdatePanel ID="UptxtIssueQty" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                <asp:TextBox ID="txtIssueQty" runat="server" autocomplete="off" AutoPostBack="false" Style="margin-left: 0px;
                    width: 150px;" ReadOnly="TRUE"></asp:TextBox>
                      </ContentTemplate>
                                </asp:UpdatePanel>
            </td>
            <td style="width: 120px;">
                Sample Received Qty.
            </td>
            <td style="width: 110px;">
              <asp:UpdatePanel ID="UptxtFabricReceivedQty" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                <asp:TextBox ID="txtFabricReceivedQty" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="TRUE"></asp:TextBox>
                           </ContentTemplate>
                                </asp:UpdatePanel>
            </td>
        </tr>
         <tr style="height :34PX;">
            <td style="width: 110px;">
                Sample Receive Qty
            </td>
            <td style="width: 110px;">
             <asp:UpdatePanel ID="UptxtReceiveQty" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                <asp:TextBox ID="txtReceiveQty" runat="server" autocomplete="off" AutoPostBack="true" Style="margin-left: 0px;
                    width: 150px;" ReadOnly="false"></asp:TextBox>
                            </ContentTemplate>
                                </asp:UpdatePanel>
            </td>

             
            </tr> 

            <tr style="height :34PX;">
            <td style="width: 110px;">
              Hour Consumed
            </td>
            <td style="width: 110px;">
                   <asp:UpdatePanel ID="UptxtHourConsumed" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                <asp:TextBox ID="txtHourConsumed" runat="server" AutoPostBack="true" Style="margin-left: 0px;
                    width: 150px;" ReadOnly="false"></asp:TextBox>
                      </ContentTemplate>
                                </asp:UpdatePanel>
            </td>
            <td style="width: 110px;">
                Difference.
            </td>
            <td style="width: 110px;">
              <asp:UpdatePanel ID="UptxtDifference" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                <asp:TextBox ID="txtDifference" runat="server" autocomplete="off" AutoPostBack="false"
                    Style="margin-left: 0px; width: 150px;" ReadOnly="TRUE"></asp:TextBox>
                         </ContentTemplate>
                                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
           <td style="width: 110px;">
             Remarks
            </td>
            <td style="width: 166px; height: 30px;" colspan="2">
              <asp:UpdatePanel ID="UptxtRemarks" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                <telerik:RadTextBox ID="txtRemarks" runat="server" Skin="WebBlue" TextMode="MultiLine"
                                    Width="300px">
                                </telerik:RadTextBox>
                                 </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
        </tr>

        <tr>
           <td colspan="3" align="right">
                    <telerik:RadButton ID="btnSave" runat="server" Text="Save" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
        </tr>
                          <tr>
            <td align="center">
              <asp:Label ID ="lblUserId" runat ="server" Visible ="false" Text="0"></asp:Label>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>
