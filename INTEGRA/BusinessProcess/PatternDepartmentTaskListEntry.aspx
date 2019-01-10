<%@ Page Title="Pattern Department Task List Entry" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="PatternDepartmentTaskListEntry.aspx.vb" Inherits="Integra.PatternDepartmentTaskListEntry" %>
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
    function TABLE1_onclick() {

    }

    </script>
    

    <table>
        <tr>
            <th colspan="6" align="left" style="font-family: 'Times New Roman', Times, serif;
                font-size: 17px; font-weight: bold; font-style: inherit; color: #336699; font-variant: inherit;"
                bgcolor="Silver">
                Pattern Department Task List
            </th>
        </tr>
      
          <asp:Panel ID ="pnlMian" runat ="server" Enabled ="true" >
        
       
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Type.
            </td>
            <td style="width: 110px;">
                <telerik:RadComboBox ID="cmbType" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            <td style="width: 110px;">
                Task No.
            </td>
            <td style="width: 110px;">
                <telerik:RadTextBox ID="txtTaskNo" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="true">
                </telerik:RadTextBox>
            </td>
           <%-- <td style="width: 110px;">
                Priority.
            </td>--%>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtPriority"  runat="server" onkeypress="return isNumericKeyy(event);" Skin="WebBlue" Width="105px"
                    Visible="false" ReadOnly="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Style.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
            <asp:TextBox ID="txtStylee" AutoPostBack ="true"  runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="false">
               </asp:TextBox>
            
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="10"
                                        CompletionSetCount="12" ContextKey="SearchStyleNo" EnableCaching="true" MinimumPrefixLength="1"
                                        ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx" TargetControlID="txtStylee" />
            </td>
            <td style="width: 110px;">
                SR NO.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
        

   <asp:TextBox ID="txtSrnOo" runat="server"  AutoPostBack ="true" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="false">
               </asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchSRNoForFabricConsupmtion" EnableCaching="true"
                            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                            TargetControlID="txtSrnOo" />
            </td>
            <td style="width: 110px;">
                Buyer.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
               <asp:TextBox ID="TXTBUYERr"  AutoPostBack ="true" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="false">
               </asp:TextBox>
         

                   <cc1:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="10"
                            CompletionSetCount="12" ContextKey="SearchBuyerName" EnableCaching="true"
                            MinimumPrefixLength="1" ServiceMethod="GetCompletionList" ServicePath="~/AutoComplete.asmx"
                            TargetControlID="TXTBUYERr" />
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                User.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadTextBox ID="txtUser" runat="server" Skin="WebBlue" Width="105px" Visible="true"
                    ReadOnly="true">
                </telerik:RadTextBox>
            </td>
         
            <td style="width: 110px;">
                Creation Time
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtCreationTime" runat="server" autocomplete="off" ReadOnly="true"
                    AutoPostBack="true" Style="margin-left: 0px; width: 100px;"></asp:TextBox>
            </td>
              <%-- <td style="width: 110px;">
                Time Stamp.
            </td>--%>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadDatePicker ID="txtTimeStamp" Visible ="false"  runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput1" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
        </tr>
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Enclosure.
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label21" runat="server" Text="Sample" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh1" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label1" runat="server" Text="Patten" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh2" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label2" runat="server" Text="Dossier" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh3" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label3" runat="server" Text="Size Specs" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh4" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
        </tr>
          <tr style="height: 34PX;">
            <td style="width: 110px;">
             
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label4" runat="server" Text="Printing" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh5" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label5" runat="server" Text="Dyeing" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh6" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
            <td style="height: 30px; width: 128px;">
                <asp:Label ID="Label6" runat="server" Text="Embroidery" Font-Bold="True" ForeColor="#336699"></asp:Label>
                <asp:CheckBox ID="ckh7" runat="server" Visible="true" Style="margin-left: -4px;" />
            </td>
           
        </tr>
        </asp:Panel>
        <asp:Panel ID ="pnlGGt" runat ="server" Enabled ="false" >
        <tr style="height: 34PX;">
            <td style="width: 110px;">
                Read By GGT Dept.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">

              <telerik:RadDatePicker ID="txtREADBYGGTDEPT"  AutoPostBack ="true"  runat="server" Culture="en-US" Width="100px">
                    <Calendar ID="Calendar2" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                    </Calendar>
                    <DateInput ID="DateInput2" runat="server" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>


           
              
            </td>
            <td style="width: 110px;">
                Finish Time Stamp
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtFinishTimeStamp" runat="server" autocomplete="off" ReadOnly="true"
                    AutoPostBack="false" Style="margin-left: 0px; width: 100px;"></asp:TextBox>
            </td>
              <td style="height: 30px; width: 128px;">
                <asp:CheckBox ID="chkFinishTimeStamp" AutoPostBack ="true"  runat="server" Visible="true" Style=" margin-left: -49px;" />
            </td>
          
        </tr>
        
        <tr>
          <td style="width: 110px;">
                Remarks
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <asp:TextBox ID="txtRemarks" runat="server" autocomplete="off" TextMode ="MultiLine"  ReadOnly="false" AutoPostBack="false"
                    Style="margin-left: 0px; width: 238px;"></asp:TextBox>
            </td>
        </tr>
        </asp:Panel>
         <tr style="height: 34PX;">
            <td style="width: 110px;">
                Attachment.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
               <asp:FileUpload ID="FileUpload" runat="server" />
            </td> <td>
                <asp:Button ID="btnUpload" runat="server" Style="width: 70px; margin-left: 0px;"
                    Text="Upload" />
            </td>
          
        </tr>


        <tr>
            <td align="center">
                <asp:Label ID="lblErrorMsgTechPack" runat="server" CssClass="ErrorMsg"></asp:Label>
            </td>
        </tr>
    </table>

   <br />
   <br />
    <table>
     <tr style="height: 34PX;">
          <td>
          <div style="width: 920PX;" >
                    <Smart:SmartDataGrid ID="dgViewMaster"  runat="server" Width="100%" 
                       AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="tableNew" PageSize="50000" ShowFooter="True" ForeColor="black"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black"   HeaderStyle-Width="5%" HeaderText="PATTERNDEPARTMENTTASKLISTDtlid"
                                DataField="PATTERNDEPARTMENTTASKLISTDtlid" Visible="FALSE" />  
                                 <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black"   HeaderStyle-Width="5%" HeaderText="PATTERNDEPARTMENTTASKLISTMstid"
                                DataField="PATTERNDEPARTMENTTASKLISTMstid" Visible="FALSE" />  

                                    <asp:TemplateColumn HeaderText="File Name" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFIle" CommandName="DownloadFile" Text='<% #Eval("FileNameTP") %>'
                                            runat="server"> </asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="10%" />
                                </asp:TemplateColumn>

<asp:TemplateColumn HeaderText="Remove" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkRemove" OnClientClick="return confirm('OK to Delete?');" ToolTip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png"
                                            CommandName="Remove" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                </asp:TemplateColumn>


          </Columns>
                    </Smart:SmartDataGrid>
                </div>
          </td>
         
          
        </tr>
    </table>
    <br />
    <br />
    <table >
    <tr>
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
    <table >
    <tr>
    <td>
    <asp:Label ID="lblUserId" runat="server" Text="" Visible ="false" ></asp:Label>
    <asp:Label ID="lblTypeID" runat="server" Text="" Visible ="false" ></asp:Label>
    <asp:Label ID="lblStyleID" runat="server" Text="" Visible ="false" ></asp:Label>
    <asp:Label ID="lblJobOrderId" runat="server" Text="" Visible ="false" ></asp:Label>
    <asp:Label ID="lblBuyerID" runat="server" Text="" Visible ="false" ></asp:Label>
    
    </td>
    </tr>
    </table>
</asp:Content>

