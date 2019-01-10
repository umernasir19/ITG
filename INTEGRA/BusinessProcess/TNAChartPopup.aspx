<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TNAChartPopup.aspx.vb" Inherits="Integra.TNAChartPopup" %>

<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Critical Path</title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />



<style type ="text/css" >

.line{
width:820px;
height:1px;
margin:0 10px 0 0;
padding:0;
background:#000;
}
 
 </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <table width="820px">
<tr>
<td style="width:600px;"><asp:ImageButton ID="ImageComplainceRequire" runat="server" ImageUrl ="~/Images/CriticalPath.png"  Enabled ="true" /></td>
<td style="width:75px;"><asp:ImageButton ID="imgSampleDevelpoment" runat="server" ImageUrl="~/Images/SampleDevelopment.png" Enabled ="true" /></td>
<td style="width:75px;"><asp:ImageButton ID="ImageRequuiretest" runat="server" ImageUrl ="~/Images/LabTest.png"  Enabled ="true" /></td>
<td style="width:75px;"><asp:ImageButton ID="ImageAccessories" runat="server" ImageUrl ="~/Images/AccessoriesCriticalPath.png"  Enabled ="true" /></td>

</tr>
  <tr style="border-bottom-style: solid; border-bottom-color: #00509F; border-bottom-width:thick ;" 
              visible="true";>     
                   
             </tr>
</table>
<div class="line"></div> 
     <table  >
    <tr>
    <td class="labelNew">
    PO No.
    </td>
    <td class="labelNew">
        <asp:Label ID="lblPONO" runat="server" ></asp:Label>    
    </td>
    <td> </td>
    <td> </td>
     <td class="labelNew">
Supplier:
    </td>
      <td class="labelNew">
        <asp:Label ID="lblvender" runat="server" ></asp:Label>    
    </td>
    <td  width="518px" align="right">
        <asp:LinkButton ID="LinkButton1" runat="server" 
            Text ="Download Critical Path Data" Font-Bold="True" 
            Font-Names="Calibri" Font-Size="13px" Font-Underline="True" 
            ForeColor="#008FD5"></asp:LinkButton></td>
    </tr>
    <tr>
        <td class="labelNew">
Customer:
    </td>
      <td class="labelNew">
        <asp:Label ID="lblBuyer" runat="server" ></asp:Label>    
    </td><td></td>
    <td> </td>
     <td class="labelNew">
Shipment:
    </td>
      <td class="labelNew">
        <asp:Label ID="lblShipment" runat="server" ></asp:Label>    
    </td>
    </tr>
    </table>
   
<table width="820px">
<tr style="height:15px;">
 </tr>
<tr>
<td><asp:Button ID="btnRequired" runat="server" CssClass="button" text="Required (✓)" Width="100px" /></td>
 <td width="600px" align ="center"> <asp:Label ID="lblmsg" runat="server" Text="" Visible ="false"  CssClass ="ErrorMsg " ></asp:Label></td>
<td width="110px" align="right">
<asp:Button ID="btnssave" runat="server" CssClass="button" text="Save Selection(s)" Width="110px" />
</td>
</tr>
</table>

<div style="vertical-align:top; height:300px; overflow:auto;width:850px">
<table width="820px">
<tr>
<td >
    
       	<SMART:SMARTDATAGRID id="dgTNAChart" runat="server" width="820px" AllowPaging="True" AllowSorting="True"
	  AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass=""
	   PagerOtherPageCssClass=""   ShowFooter="True" SortedAscending="yes"
	    ForeColor="White">
 					
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="Detail ID" DataField="TNAChartID" visible="False" />
                             
														<ASP:BOUNDCOLUMN HeaderText="POID" Visible="False" DataField="POID"  />
														<ASP:BOUNDCOLUMN HeaderText="ProcessID" Visible="False" DataField="ProcessID" />
														<ASP:BOUNDCOLUMN HeaderText="SelectedStatus" Visible="False" DataField="SelectedStatus" />
														<ASP:TEMPLATECOLUMN HeaderText="(✓)">
                                                        <itemstyle horizontalalign="Center" />
									                    <ITEMTEMPLATE>
										                <asp:Checkbox id="chkSelect" runat="server" checked='<% #Eval("Selected") %>' ></asp:Checkbox>
										                
</ITEMTEMPLATE>
                                                        <headerstyle width="3%" />
							    	                    </ASP:TEMPLATECOLUMN>
														<ASP:BOUNDCOLUMN HeaderText="Sample Type" DataField="Process" >
                                                          <headerstyle width="20%" />
                                                        </ASP:BOUNDCOLUMN>
                                                         <ASP:TEMPLATECOLUMN HeaderText="Status">
                                                            <itemstyle horizontalalign="left" />
									                        <ITEMTEMPLATE>
										                    <asp:DropDownList ID="cmbStatus"  cssclass="textbox" runat="server" width="100" ></asp:DropDownList>
									                        
</ITEMTEMPLATE>
                                                            <headerstyle width="15%" />
								                            </ASP:TEMPLATECOLUMN>
                                                             <ASP:TEMPLATECOLUMN HeaderText="No.of Submission">
                                                            <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
<asp:textbox id="txtQuantityCmpltd" runat="server" CssClass="textbox" text='<% #Eval("QtyCompleted") %>' width="55"></asp:textbox> 
</ITEMTEMPLATE>
                                                            <headerstyle width="7%" />
								                            </ASP:TEMPLATECOLUMN>
                                                             <ASP:TEMPLATECOLUMN HeaderText="Activity Date">
                            <itemstyle horizontalalign="Center"  />
							 <ITEMTEMPLATE>
    <telerik:RadDatePicker ID="txtActualDate" runat="server" Culture="en-US">
<Calendar ID="Calendar1" runat="server" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"></Calendar>
<DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" runat="server" DateFormat="dd/MM/yyyy" ></DateInput>
<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
                                  
							    
</ITEMTEMPLATE>
                                <headerstyle width="5%" />
							    </ASP:TEMPLATECOLUMN>				 
							    	                        	<ASP:TEMPLATECOLUMN HeaderText="Comments">
                                                            <itemstyle horizontalalign="Center" />
									                        <ITEMTEMPLATE>
										                    <asp:textbox id="txtRemarks" runat="server" width="180" CssClass="textbox" text='<% #Eval("Remarks") %>'></asp:textbox>
									                        
</ITEMTEMPLATE>
                                                            <headerstyle width="25%" />
							    	                        </ASP:TEMPLATECOLUMN>
														<ASP:BOUNDCOLUMN HeaderText="Target Date" DataField="IdealDate"  visible="False" >
                                                        <itemstyle horizontalalign="Center" />
                                                        <headerstyle width="5%" />
                                                        </ASP:BOUNDCOLUMN>
							                <ASP:BOUNDCOLUMN HeaderText="Estimated Date" DataField="EstimatedDate" visible="False" >
                                                        <itemstyle horizontalalign="Center" />
                                                        <headerstyle width="5%" />
                                                        </ASP:BOUNDCOLUMN>
                                                       
							    	                    
									                       <ASP:TEMPLATECOLUMN HeaderText="(✓)">
                                                        <itemstyle horizontalalign="Center" />
									                    <ITEMTEMPLATE>
<asp:Checkbox id="chkUpdate"  runat="server" ></asp:Checkbox> 
</ITEMTEMPLATE>
                                                        <headerstyle width="2%" />
							    	                    </ASP:TEMPLATECOLUMN>
									                       <ASP:TEMPLATECOLUMN  HeaderText="/">
									                        <ITEMTEMPLATE>
										        <asp:HyperLink id="lnkEdit" Enabled ="true" NavigateUrl='<%# "TNAHistoryPopup.aspx?lProcessID="& DataBinder.Eval(Container.DataItem,"ProcessID")&"&lPOID="& DataBinder.Eval(Container.DataItem,"POID")%>' Runat="server">History</asp:HyperLink>
									                        
</ITEMTEMPLATE>
								                            </ASP:TEMPLATECOLUMN>
									                       
							 
		                  </COLUMNS>
		 <PagerStyle CssClass="GridPagerStyle" Mode="NumericPages" HorizontalAlign="Right"    />
	        <AlternatingItemStyle CssClass="GridAlternativeRow" />
        <ItemStyle CssClass="GridRow" />
        <HeaderStyle CssClass="GridHeaderStyle" HorizontalAlign="Center" />
      </SMART:SMARTDATAGRID>
       
 </td>
 </tr> 
 </table>  
 </div> 
    </form>
</body>
</html>
