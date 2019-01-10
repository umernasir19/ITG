<%@ Page Language="vb" MasterPageFile="~/MasterPage.master"  AutoEventWireup="false" CodeBehind="BankTransactionSheetView.aspx.vb" Inherits="Integra.BankTransactionSheetView" %>
  <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript">
        function openPopup(strOpen) {
            open(strOpen, "Info",
         "status=1, width=980, height=600, top=60, left=12");
        }
</script>
   <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
         <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd = "onResponseEnd"  /> 
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgBankTransactionSheet">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgBankTransactionSheet" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
   <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom" Width="80%">
    <asp:Image ID="Image1" runat="server" AlternateText="Loading..." 
                ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
  <table width="100%">
       <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width: thin;" 
              visible="true";>
            <th  colspan ="6" align="left"   style="font-family: Arial; font-size: 16PX; font-weight: bold; color: #808080;"  >
           Bank Transaction</th>
         </tr>
 <tr>
 <td>
        <asp:Label ID="Label5" runat="server" Text="View By:" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>
 </td>
 <td>
      <asp:UpdatePanel ID="upcmbMonthYear" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <telerik:RadComboBox ID="cmbMonthYear" Runat="server" AutoPostBack="True"  
                    Skin="WebBlue">
                    <DefaultItem Value="0" Text="Select.." />
                </telerik:RadComboBox>
                   </ContentTemplate>
                 </asp:UpdatePanel>   
 </td>

 <td align="right">
  <telerik:RadButton ID="btnAddBankTransactionN" runat="server" Text="Add Bank Transaction" Skin="WebBlue">
                    </telerik:RadButton> 
 </td>
 </tr>
  </table>
 <table width="100%">
 <tr>
 <td align="right">
             
 
           <%--      <asp:Label ID="lblBalanceCF" runat="server"   Font-Names="Calibri" Font-Size="Medium"></asp:Label>--%>
                    <asp:UpdatePanel ID="uptxtBalanceCF" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                      <asp:Label ID="lblBalanceCF"   runat="server" Text="Balance C/F" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>  &nbsp;
                   <telerik:RadNumericTextBox  ID="txtBalanceCF" Runat="server" Font-Bold="true"  NumericType="Number" DataType="System.Decimal"  DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  Skin="WebBlue" ReadOnly="true" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                    </ContentTemplate>
                 </asp:UpdatePanel>   
 </td>
 </tr>
  <tr>
 <td align="right">
            
  
             <%--    <asp:Label ID="lblPettyCash" runat="server"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>--%>
                    <asp:UpdatePanel ID="uptxtBank" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                        <asp:Label ID="lblBank"  runat="server" Text="Bank" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>  &nbsp;
                     <telerik:RadNumericTextBox  ID="txtBank" Runat="server" Font-Bold="true" Skin="WebBlue"  NumericType="Number" DataType="System.Decimal" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  ReadOnly="true" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                  </ContentTemplate>
                 </asp:UpdatePanel> 
 </td>
 </tr>
 <tr>
 <td align="right">
        
 
       <%--          <asp:Label ID="lblTotalExpense" runat="server"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>--%>
                    <asp:UpdatePanel ID="uptxtotalExpense" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                        <asp:Label ID="lblotalExpense"  runat="server" Text="Total Expense" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>  &nbsp;
                     <telerik:RadNumericTextBox  ID="txtotalExpense" Runat="server" Font-Bold="true" Skin="WebBlue"  NumericType="Number" DataType="System.Decimal" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  ReadOnly="true" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                  </ContentTemplate>
                 </asp:UpdatePanel> 
 </td>
 
 </tr>
  <tr>
 <td align="right">
     
 
               <%--  <asp:Label ID="lblClosingBalance" runat="server"  Font-Names="Calibri" Font-Size="Medium"></asp:Label>--%>
                         <asp:UpdatePanel ID="uptxttxtBankBalance" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
                           <asp:Label ID="lblBankBalance"  runat="server" Text="Bank Balance" 
                    Font-Names="Calibri" Font-Size="Medium"></asp:Label>  &nbsp;
                        <telerik:RadNumericTextBox  ID="txtBankBalance" Runat="server" Font-Bold="true" Skin="WebBlue"  NumericType="Number" DataType="System.Decimal" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  ReadOnly="true" BackColor="#80BFFF" >
                </telerik:RadNumericTextBox>
                  </ContentTemplate>
                 </asp:UpdatePanel> 
 </td>
 </tr>
 </table>
 <table width="100%">
 
 <tr>
 <td>
    <asp:UpdatePanel ID="updgBankTransactionSheet" UpdateMode="Conditional" runat="server">
               <ContentTemplate>
 <telerik:RadGrid ID="dgBankTransactionSheet" runat="server" CellSpacing="0"  AutoGenerateColumns="false" 
         Skin="WebBlue"  Visible="true" PageSize="50" AllowFilteringByColumn="true" Width="930px" OnSelectedIndexChanged="dgBankTransactionSheet_SelectedIndexChanged" OnSortCommand="dgBankTransactionSheet_SortCommand">
            <AlternatingItemStyle Font-Names="Microsoft Sans Serif" />
            <MasterTableView>
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
             <Columns>
              <telerik:GridBoundColumn HeaderText="BankTransactionID" DataField="BankTransactionID" Display="false" AllowFiltering="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
          <telerik:GridBoundColumn HeaderText="TranscationType" DataField="TranscationType" Display="false" AllowFiltering="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="IsTaxable" DataField="IsTaxable" Display="false" AllowFiltering="false" >
           <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>

               <telerik:GridBoundColumn HeaderText="Month" DataField="Month" AllowFiltering="false">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
             <telerik:GridBoundColumn HeaderText="Date" DataField="Date" AllowFiltering="false">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            <ItemStyle Wrap="false" />
            </telerik:GridBoundColumn>
               <telerik:GridBoundColumn HeaderText="Voucher No." DataField="VoucherNo" AllowFiltering="true" FilterControlWidth="70px" ShowFilterIcon="false" CurrentFilterFunction="StartsWith" FilterDelay="2000">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn>   
              <telerik:GridBoundColumn HeaderText="Cheque No." DataField="ChequeNo" AllowFiltering="true" FilterControlWidth="70px" ShowFilterIcon="false" CurrentFilterFunction="StartsWith" FilterDelay="2000">
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridBoundColumn> 
             <telerik:GridBoundColumn HeaderText="Particulars" DataField="Particulars" AllowFiltering="false">
            <ItemStyle HorizontalAlign="Left" Wrap="false" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
       
            <telerik:GridNumericColumn  HeaderText="Amount" AllowFiltering="false" DataField="Amount" DataFormatString="{0:#,##0.00;(#,##0.00);0.00}"  NumericType="Number" DataType="System.Decimal" >
            <ItemStyle HorizontalAlign="right" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" /> 
            </telerik:GridNumericColumn>
             <telerik:GridBoundColumn HeaderText="Accounts Head" DataField="AccountsHead" AllowFiltering="true" FilterControlWidth="70px" ShowFilterIcon="false" CurrentFilterFunction="StartsWith" FilterDelay="2000">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn HeaderText="Payee" DataField="Payee" AllowFiltering="true" FilterControlWidth="70px" ShowFilterIcon="false" CurrentFilterFunction="StartsWith" FilterDelay="2000">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn HeaderText="HK Analysis Code" DataField="HKAnalysisCode" AllowFiltering="true" FilterControlWidth="70px" ShowFilterIcon="false" CurrentFilterFunction="StartsWith" FilterDelay="2000">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn HeaderText="ECP Analysis Code" DataField="ECPAnalysisCode" AllowFiltering="true" FilterControlWidth="70px" ShowFilterIcon="false" CurrentFilterFunction="StartsWith" FilterDelay="2000">
            <ItemStyle HorizontalAlign="Left" />
            <HeaderStyle Width="10%" HorizontalAlign="Left" />
            </telerik:GridBoundColumn>
  <telerik:GridTemplateColumn HeaderText ="Action"  Display="true"  AllowFiltering="false">
                  <ItemStyle HorizontalAlign="Left"  Width="30px"  />
            <HeaderStyle Width="5%" HorizontalAlign="Left" />
                <ItemTemplate >
                <asp:LinkButton ID="lnView"  runat ="server" CommandName ="EDIT" HeaderText ="View" Text="Edit" ></asp:LinkButton>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
<telerik:GridTemplateColumn  HeaderText="Print"  AllowFiltering ="false">
  <itemstyle horizontalalign="Center" />
 <HeaderStyle Width="10%" HorizontalAlign="Center" Font-Size="Smaller"/>
<ITEMTEMPLATE>
<a href="javascript:openPopup('PrintVouchar.aspx?Type=Bank&Bankid=<%# Eval("BankTransactionID") %>&TranscationType=<%# Eval("TranscationType") %>&IsTaxable=<%# Eval("IsTaxable") %>')">Print Voucher</a>
</ITEMTEMPLATE>
</telerik:GridTemplateColumn >
 
            </Columns>
<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
            </MasterTableView>
             <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false" Scrolling-AllowScroll="true"
             Scrolling-UseStaticHeaders="False" Scrolling-ScrollHeight="600px">
            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true"/>
            </ClientSettings>
            <HeaderStyle Font-Names="Microsoft Sans Serif" />
            <ItemStyle Font-Names="Microsoft Sans Serif" />
            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
           <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid>
   </ContentTemplate>
 </asp:UpdatePanel>  
 </td>
 </tr>
  </table>
      <%-- Script For Loading Panel  --%>
     <script language ="javascript" type ="text/javascript" >
         function onRequestStart(sender, arguments) {

             grayOut(true, "")
         }
         function onResponseEnd(sender, arguments) {

             grayOut(false, "")
         }

         function grayOut(vis, options) {
             var optionsoptions = options || {};
             var zindex = options.zindex || 50;
             var opacity = options.opacity || 70;
             var opaque = (opacity / 100);
             //Setting the color   
             var bgcolor = options.bgcolor || 'White';
             var dark = document.getElementById('darkenScreenObject');
             if (!dark) {
                 // The dark layer doesn't exist, it's never been created.  So we'll     
                 // create it here and apply some basic styles.      
                 var tbody = document.getElementsByTagName("body")[0];
                 var tnode = document.createElement('div');
                 tnode.style.position = 'absolute';
                 tnode.style.top = '0px';
                 tnode.style.left = '0px';
                 tnode.style.overflow = 'hidden';
                 tnode.style.display = 'none';
                 tnode.id = 'darkenScreenObject';
                 tbody.appendChild(tnode);
                 dark = document.getElementById('darkenScreenObject');
             }

             if (vis) {
                 var pageWidth = '100%';
                 var pageHeight = '100%';
                 dark.style.opacity = opaque;
                 dark.style.MozOpacity = opaque;
                 dark.style.filter = 'alpha(opacity=' + opacity + ')';
                 dark.style.zIndex = zindex;
                 dark.style.backgroundColor = bgcolor;
                 dark.style.width = pageWidth;
                 dark.style.height = pageHeight;
                 dark.style.display = 'block';
             }
             else {
                 dark.style.display = 'none';
             }
         }   
    </script>  
    
    <%-- Script End --%>
 </asp:Content> 