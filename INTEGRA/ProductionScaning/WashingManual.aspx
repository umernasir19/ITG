<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WashingManual.aspx.vb" Inherits="Integra.WashingManual" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Washing</title>
 <link type="text/css" rel="stylesheet" href="App_Themes/Blue/NewCSS/NewStyle.css" />
    <link type="text/css" rel="stylesheet" href="css/style.css" />
    <link type="text/css" rel="stylesheet" href="App_Themes/Blue/StyleSheet.css" />
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />


   <%-- <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            $('ul.sf-menu').sooperfish();
        });  
           </script>--%>
 <%--<script type="text/javascript" language="javascript">
$(document).ready(function() {
$('#<%=dgView.ClientID %>').Scrollable();
}
)
</script> --%>
  

 <%--<script type="text/javascript" src="scripts/jquery-2.1.1.min.js"></script>
    <script type ="text/javascript"  language="javascript">
        $(document).ready(function () {
            /*Code to copy the gridview header with style*/
            var gridHeader = $('#<%=dgView.ClientID%>').clone(true);
            /*Code to remove first ror which is header row*/
            $(gridHeader).find("tr:gt(0)").remove();
            $('#<%=dgView.ClientID%> tr th').each(function (i) {
                /* Here Set Width of each th from gridview to new table th */
                $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
            });
            $("#controlHead").append(gridHeader);
            $('#controlHead').css('position', 'absolute');
            $('#controlHead').css('top', $('#<%=dgView.ClientID%>').offset().top);

        });
    </script>
     <script type="text/javascript" src="JavaScript/sound.js">--%>
        
</script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        
         <div style="margin: 0 auto; text-align: center; width: 714px;">
            <table style="width:714px;border: 0px solid #000; font-family:Calibri; font-size:30px; font-stretch:normal; font-style:normal; font-weight:bold;">
                <tr>
                    <td>
                        <img src="../Images/dis.jpg" />
                       <%-- <asp:Label ID="Label2" runat="server" Text ="Dispatch To Washing"></asp:Label>--%></td>
                    
                </tr>
            </table>
        </div>
        <br />
        <br />
     <div style="margin: 0 auto; text-align: center; width: 714px; margin-top: -38px;">
            <table style="width:714px;border: 2px solid #000; font-family:Calibri; font-size:30px; font-stretch:normal; font-style:normal; font-weight:bold; color:#1307ED;">
                <tr>
                    <td>
                        <asp:Label ID="lblJobNo" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="LalblStyle" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblStyleQty" runat="server" style="color: red;"></asp:Label></td>
                    <td>
                        <asp:Label ID="lblScanedPcs" runat="server" style="color: green;"></asp:Label></td>
                </tr>
            </table>
        </div>
         <div style=" margin-left: 1005px;">
              <asp:Label ID="Label2" runat="server" Text ="Counter:" style="color: blue; font-weight:bold;"></asp:Label></div>
              <div  style=" margin-left: 1074px; margin-top: -24px;">
         <asp:Label ID="lblCounter" runat="server" Text ="0" style=" font-size :x-large ; font-family:Calibri; font-weight:bold; color:Red ;"></asp:Label></div>
       
          <br />
        <br />
          <br />
         <br />
        <br />
        <div style="margin: 0 auto; text-align: center; width: 714px; margin-top: 36px;">
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblmsg" runat="server" Style="font-weight: bold; color: Red; font-size: 17px;"></asp:Label></td>
                </tr>
                <tr style="height: 40px;">
                    <td>
                        <table>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="txtBarcode" Style="background-color: gainsboro;" runat="server"
                                        Width="256px" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCreationDate" runat="server" CssClass="textbox"> </asp:TextBox>
                                    
                                    <cc1:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" runat="server" TargetControlID="txtCreationDate"
                                        PopupButtonID="ImageButton1" />
                                    <asp:ImageButton runat="Server" ID="ImageButton1" CausesValidation="false" ImageUrl="~/Images/calendar.JPG"
                                        AlternateText="Click here to display calendar" />
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtCreationDate"
                                        Mask="99/99/9999" Century="2000" MaskType="Date" CultureAMPMPlaceholder="AM;PM"
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="YMD" CultureDatePlaceholder="/"
                                        CultureDecimalPlaceholder="." CultureThousandsPlaceholder="," CultureTimePlaceholder=":"
                                        Enabled="True" UserDateFormat="DayMonthYear" AutoComplete="False">
                                    </cc1:MaskedEditExtender>
                                </td>
                                <td align="right">
                                    <asp:Button ID="BtnSAVEData" runat="server" Text="Save All Pcs" Style="margin-left: 10px;
                                        width: 198px;" Visible ="false" ></asp:Button>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>
                    <div style="width:714px;">
                    <div id="controlHead" style="width:706px;">
        </div>
                   <div style="height: 180px; overflow: auto">
                        <%--<asp:GridView ID="dgView" runat="server" Width="100%"  AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" CellPadding="4" CssClass="table" PageSize="10000"
                            ShowFooter="True" ForeColor="Black"                   
                            >--%>
                             <asp:GridView ID="dgView" runat="server" Width="100%"  AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
                BorderStyle="Solid">
                            <%-- <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />--%>

                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStyleAssortmentBarCodeDetailID" runat="server" Text='<%# Bind("StyleAssortmentBarCodeDetailID") %>'></asp:Label>
                                        <asp:Label ID="lblJoborderid" runat="server" Text='<%# Bind("Joborderid") %>'></asp:Label>
                                        <asp:Label ID="lblJoborderDetailid" runat="server" Text='<%# Bind("JoborderDetailid") %>'></asp:Label>
                                        <asp:Label ID="lblStyleAssortmentMasterID" runat="server" Text='<%# Bind("StyleAssortmentMasterID") %>'></asp:Label>
                                        <asp:Label ID="lblSizeRangeID" runat="server" Text='<%# Bind("SizeRangeID") %>'></asp:Label>
                                        <asp:Label ID="lblSizeDatabaseID" runat="server" Text='<%# Bind("SizeDatabaseID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="BarCode" DataField="Code">
                                    <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Merchandiser" DataField="Merchandiser">
                                    <HeaderStyle Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="SR NO" DataField="JobNo">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                     <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Style QTY" DataField="TotalOrderQty">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Style" DataField="Style">
                                    <HeaderStyle HorizontalAlign="Center" Width="28%" />
                                    <ItemStyle HorizontalAlign="Center"   />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Item" DataField="Item">
                                    <HeaderStyle HorizontalAlign="Center" Width="22%" />
                                    <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Brand" DataField="Brand">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center"   />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Size QTY" DataField="TotalSizeQty">
                                    <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Size" DataField="Size">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>                                 
                            </Columns>
                             <HeaderStyle BackColor="#66CCFF" />
                        </asp:GridView>
                      </div> 
                              </div> 
                    </td>
                </tr>
            </table>
       
        
        
        
        <br />
        
        <br />
        
     
        <div style="margin: 0 auto; text-align: center; width: 714px;">
            <table style="width:714px;border: 2px solid #000; font-family:Calibri; font-size:30px; font-stretch:normal; font-style:normal; font-weight:bold; color:#1307ED;">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text ="Send to Wash Scanned"></asp:Label></td>
                   
                </tr>
            </table>
        </div>
        <br />
        <table>
                <tr>
                    <td>
                    
                  <div style="width:714px;">
                    <div id="Div1" style="width:706px;">
        </div>
                   <div style="height: 180px; overflow: auto">
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                 
                  <asp:GridView ID="DgStitching" runat="server" Width="100%"  AutoGenerateColumns="False" EmptyDataText="There are no data records to display."
                BorderStyle="Solid">
                          
                            <Columns>
                               
                                <asp:BoundField HeaderText="JobOrderId" DataField="JobOrderId" Visible ="false" >
                                    <HeaderStyle HorizontalAlign="Center" Width="25%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            
                                <asp:BoundField HeaderText="SR NO" DataField="SRNO">
                                    <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                     <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Quantity" DataField="TotalQuantity">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Total Stitching Qty" DataField="TotalstitchingBit">
                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemStyle HorizontalAlign="Center"   />
                                </asp:BoundField>
                                                    
                            </Columns>
                             <HeaderStyle BackColor="#66CCFF" />
                        </asp:GridView>
                 
                 
                 
                 
                 
                <%-- <SMART:SMARTDATAGRID id="DgStitching" runat="server" width="100%"  
						 AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" 
							 PageSize="1000"  ShowFooter="True"  ForeColor="white" GridLines="both">
							<COLUMNS>
							    <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  HeaderText="JobOrderId"
									 DataField="JobOrderId" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN> 
								 
						       <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  HeaderText="Job #"
									 DataField="JobNo" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN> 
								
							   <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  HeaderText="Total Quantity"
									 DataField="TotalQuantity" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN> 
							  <ASP:BOUNDCOLUMN ItemStyle-HorizontalAlign="center"  HeaderText="Total Stitching Bit"
									 DataField="TotalstitchingBit" >
							 	<headerstyle horizontalalign="center" width="5%" />
								</ASP:BOUNDCOLUMN>
							 
						
							  </COLUMNS>
						</SMART:SMARTDATAGRID>--%>
                </div> 
                              </div> 
                    </td>
                </tr>
            </table>
 </div>
        <table>
        
        
        
        
        
        
            <tr>
                <td align="LEFT">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
