<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LedgerPrint.aspx.vb" Inherits="Integra.LedgerPrint" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>LEDGER PRINT</title>
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="../css/style.css" />
    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/StyleSheet.css" />
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../JavaScript/Maskdiv.js" />

    <script type="text/javascript" language="JavaScript" src="../scripts/Calender.js"></script>

    <script type="text/javascript" src="../scripts/ThickBox.css"></script>

    <script type="text/javascript" src="../scripts/jquery.js"></script>

    <script type="text/javascript" language="JavaScript" src="../scripts/pupdate.js"></script>

    <link type="text/css" rel="stylesheet" href="../App_Themes/Blue/MenuCSS.css" />
    <link type="text/css" rel="stylesheet" href="../NewLayout.css" />
    <link rel="stylesheet" type="text/css" href="../Styles/sooperfish.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="../Styles/sooperfish-theme-large.css"
        media="screen" />

    <script type="text/javascript" src="../Jquery/jquery-1.4.2.min.js"></script>

    <script type="text/javascript" src="../Jquery/jquery.easing-sooper.js"></script>

    <script type="text/javascript" src="../Jquery/jquery.sooperfish.js"></script>

    <script type="text/javascript">


        function Print() {
            //var btn=document.getElementById('Print1').id
            //btn.style.Display="none";

            document.getElementById("Print1").style.visibility = "hidden";
            window.print();
            alert('btn')
        }


    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="raw_btn" style ="text-align:right ;">
                <input id="Print1" type="button" value=" Print this page " onclick="Print();" />
            </div>
        <div>
            <table width="100%">
            <tr align ="center" > <td style ="font-size: 23px; font-weight: bold;">Digital Apparel</td></tr>
             <tr align ="center" > <td style ="font-size: 23px; font-weight: bold;"> LEDGER FROM:.<asp:Label ID="lblFrom" runat ="server" Visible="true"  >  TO:.</asp:Label> <asp:Label ID="lblTo" runat ="server"  Visible="true" ></asp:Label></td></tr>
             <tr>
            
            <td>
              <hr style="color: DarkGray; height: 0px; background-color: DarkGray;" />
            <table>
            <tr>
            <td><b>Account:</b></td> 
            <td><asp:Label ID="lblAccountName" runat ="server"  style="font-weight :bold;" ></asp:Label></td> 
            </tr>
            </table>
              <hr style="color: DarkGray; height: 0px; background-color: DarkGray;" />
            </td>
            </tr>
         
               <tr>
           
            <td align ="right" >
            <table>
            
            <tr style=" background-color: lightgrey;">
            <td> <asp:Label ID="lblOpeningBalancee" runat="server" Visible="True"   Text="Opening Balance :"
                    Style="color: Navy; font-weight: bold; margin-right: 20px;"></asp:Label></td>
            <td> <asp:Label ID="lblOpeningBalance" runat="server" Visible="TRUE" style="margin-right: 25px;"></asp:Label></td>
            </tr></table>
               
               
             
            </td>
        </tr>
         
        <tr><td></td></tr>      
                <tr>
                    <td>
                    <Smart:SmartDataGrid ID="dgView" runat="server" Width="100%" OnSortCommand="SortByColumn"
                    OnPageIndexChanged="PageChanged" AllowPaging="false" AllowSorting="True" AutoGenerateColumns="False"
                    CellPadding="4" CssClass="table" PageSize="1000" ShowFooter="false" ForeColor="white"
                    GridLines="both">
                    <Columns>
                  
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderStyle-Width="5%" HeaderText="TempID"
                            DataField="TempID" visible="false" />
                            <asp:TemplateColumn HeaderText="Voucher No & Date">
<ItemStyle Width="8%" HorizontalAlign="center"></ItemStyle>
<ItemTemplate>
<asp:HyperLink id="lnkVoucherNo" tooltip="To Link Voucher, Click Here" Runat="server" Text='<%#Bind("VoucherNo") %>'  NavigateUrl='<%# "BankandJournalVoucherViewForLedger.aspx?lVoucherNo=" &amp; DataBinder.Eval(Container.DataItem,"VoucherNo")%>' Enabled="true">
							        </asp:HyperLink> 
<%-- <asp:label id="lblVoucherNo" runat="server" width="100"  CssClass="textbox"  ></asp:label>--%>
 <asp:label id="lblVoucherDate" runat="server" width="100"  CssClass="textbox"  ></asp:label>
</ItemTemplate>
<HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Chq./Inv.No & Date">
<ItemStyle Width="8%" HorizontalAlign="center"></ItemStyle>
<ItemTemplate>
  <asp:label id="lblChecqNo" runat="server" width="100"  CssClass="textbox"  ></asp:label>
 <asp:label id="lblCheqDate" runat="server" width="100"  CssClass="textbox"  ></asp:label>
</ItemTemplate>
<HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Description">
<ItemStyle Width="15%" HorizontalAlign="center"></ItemStyle>
<ItemTemplate>
 <asp:label id="lblbb" runat="server" width="240"  CssClass="textbox"  ></asp:label>
  <asp:label id="lblDescription" runat="server" width="240"  CssClass="textbox"  ></asp:label>
</ItemTemplate>
<HeaderStyle Width="7%" HorizontalAlign="Center"></HeaderStyle>
</asp:TemplateColumn>
                        <%--<asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher  Date" DataField="VoucherDate">
                            <headerstyle horizontalalign="center" width="5%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Voucher  No" DataField="VoucherNo">
                            <headerstyle horizontalalign="center" width="7%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Description" DataField="Description">
                            <headerstyle horizontalalign="center" width="25%" />
                        </asp:BOUNDCOLUMN>--%>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="DB" DataField="Debit">
                            <headerstyle horizontalalign="center" width="6%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="CR" DataField="Credit">
                            <headerstyle horizontalalign="center" width="6%" />
                        </asp:BOUNDCOLUMN>
                        <asp:BOUNDCOLUMN ItemStyle-HorizontalAlign="center" HeaderText="Balance" DataField="Balance">
                         <headerstyle horizontalalign="center" width="6%" />
                        </asp:BOUNDCOLUMN>
                        <asp:TemplateColumn HeaderText="">
                       <ItemStyle Width="3%" HorizontalAlign="center"></ItemStyle>
                          <ItemTemplate>
                         <asp:label id="lblCd" runat="server" width="2"  CssClass="textbox"  ></asp:label>
                       
                             </ItemTemplate>
                          <HeaderStyle Width="2%" HorizontalAlign="Center"></HeaderStyle>
                          </asp:TemplateColumn>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="EDIT"
                            visible="false">
                            <itemtemplate>																	
										<asp:ImageButton id="lnkEdit" tooltip="Click here to edit"  ImageUrl="~/Images/editIcon.jpg" CommandName="Edit" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="REMOVE"
                            visible="false">
                            <itemtemplate>									 								
										<asp:ImageButton id="lnkRemove" tooltip="Be sure, it will delete from database" ImageUrl="~/Images/RemoveIcon.png" CommandName="Remove" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                        <asp:TEMPLATECOLUMN ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="02%" HeaderText="PDF"
                            visible="false">
                            <itemtemplate>								
										<asp:ImageButton id="lnkPDF" tooltip="Click here to download PDF" ImageUrl="~/Images/pdf_icon_small.gif" CommandName="PDF" runat="server"></asp:ImageButton>
									</itemtemplate>
                        </asp:TEMPLATECOLUMN>
                    </Columns>
                </Smart:SmartDataGrid>
                    </td>
                </tr>
                <tr>
                <td align ="right" >
           
                 <table>
            
            <tr style=" background-color: Gray;">
            <td> <asp:Label ID="Label1" runat="server" Visible="True" Width ="180px"   Text="Total Amount:"
                    Style="color: Navy; font-weight: bold; margin-right: 525px;"></asp:Label></td>
            <td>  <asp:Label ID="lblTotalDebit" runat="server" Visible="TRUE" style="margin-right: 86px;"></asp:Label></td>
            <td><asp:Label ID="lblTotalCredit" runat="server" Visible="TRUE" style="margin-right: 65px;"></asp:Label></td>
           <td> <asp:Label ID="lbltotal" runat="server" Visible="TRUE" style="margin-right: 76px;"></asp:Label>  </td>
            </tr></table>
                </td>
                </tr>
                
           
            </table>
        </div>
    </form>
</body>
</html>
