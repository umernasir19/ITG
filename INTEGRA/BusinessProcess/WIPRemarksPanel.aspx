<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WIPRemarksPanel.aspx.vb" Inherits="Integra.WIPRemarksPanel" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WIP Comments Page</title>
 <link href= "../App_Themes/Blue/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
     <div style="vertical-align:top;   overflow:auto;width:700px; border-style:groove; border-color:Navy;">
	

<table width="650px"  >
<tr>
<td>
<h3> 
  <asp:Label ID="lblHeading" runat="server"  ></asp:Label>
</h3>
  
</td>
</tr>
<tr>
<td> 
    <asp:DataList ID="dlWIPRemarks"   runat="server">
     <ItemTemplate>
        
        
       <table border="1" cellpadding="5" cellspacing="0"  >

            <tr>
                <td bgcolor="#dcdcdc" width="150">Date of Activity:</td>
                <td >
                  <%#Eval("CreationDate")%></td>
            </tr>
            <tr>
                <td bgcolor="#dcdcdc" width="150">Activity By:</td>
                <td >
                  <%#Eval("UserNameF")%></td>
            </tr>
            <tr>
                <td bgcolor="#dcdcdc" width="150">Comments:</td>
                <td>
                  <%#Eval("Remarks")%></td>
            </tr>
           </table>
         
    </ItemTemplate>
    
    </asp:DataList>
</td>
   
</tr>
 
<tr>
<td>
  <%-- <asp:FormView ID="ddlWIPRemarks" runat="server" PageSize="25" EnableViewState="False">
    <ItemTemplate>
        
        <h3>WIP Remarks »(<%#Eval("WIPChartId")%>)</h3>
       <table border="1" cellpadding="5" cellspacing="0" >

            <tr>
                <td bgcolor="#dcdcdc" width="200">Date of Activity:</td>
                <td >
                  <%#Eval("CreationDate")%></td>
            </tr>
            <tr>
                <td bgcolor="#dcdcdc" width="200">Activity By:</td>
                <td >
                  <%#Eval("Username")%></td>
            </tr>
            <tr>
                <td bgcolor="#dcdcdc" width="200">Remarks:</td>
                <td>
                  <%#Eval("Remarks")%></td>
            </tr>
           </table>
        <hr />
    </ItemTemplate>
</asp:FormView>--%>
</td>
</tr>
<tr>
<td>


		<%--	<SMART:SMARTDATAGRID id="dgWIPRemarks" runat="server" width="100%"  OnSortCommand="SortByColumn" OnPageIndexChanged="PageChanged"
							 OnItemDataBound="DataBound" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" PagerCurrentPageCssClass="" PagerOtherPageCssClass="" PageSize="25" RecordCount="0" ShowFooter="True" SortedAscending="yes" ForeColor="white" GridLines="None">
							<COLUMNS>
							<ASP:BOUNDCOLUMN HeaderText="WIPChartId" visible="false" SortExpression="WIPChartId" DataField="WIPChartId" ><itemstyle horizontalalign="Left" /><headerstyle width="05%" /> </ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="User Name" 
								  DataField="Username" >
								<itemstyle horizontalalign="Left" /><headerstyle width="15%" />
								 <headerstyle   horizontalalign="Left"  />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Activity On"	
								 DataField="CreationDate" > 
								<itemstyle horizontalalign="Left" /><headerstyle width="15%" /> 
								 <headerstyle   horizontalalign="Left"  />
								</ASP:BOUNDCOLUMN>
								<ASP:BOUNDCOLUMN HeaderText="Remarks"	
								SortExpression="Remarks" DataField="Remarks" > 
								<itemstyle horizontalalign="Left" /><headerstyle width="70%" /> 
								 <headerstyle   horizontalalign="Left"  />
								 </ASP:BOUNDCOLUMN>
								
							</COLUMNS>
               			</SMART:SMARTDATAGRID>--%>
						</td></tr>
			</table>
			



<div id="Div1" style="text-align:left; ">
        <div   style="width:650px; height:250px; left: 0px; top: 0px; background-color: #dcdcdc"" >
            
         
          <table style="width: 535px ">
		  
					<tr>
					<td  class="NormalBoldText" >WIP Comments: </td>
					<td></td>
					</tr>
				<tr>
					<td align="left">
						<asp:TextBox ID="txtWIPRemarks" Runat="server" CssClass="forcapital" Height="87px" TextMode="MultiLine" Width="484px" ></asp:TextBox>
						
					</td>
				</tr>
				<tr>
					
					<td align="left">
                        <asp:CheckBox ID="chkApplyInAll"   AutoPostBack="true" CssClass="label"  Text="Apply This Comment To All My Selection" runat="server" />
						
						</td>
				</tr>
				<tr>
					 
					<td align="center">
                        <asp:Button ID="btnsaveSave" Visible="false"  CssClass="button" runat="server" Text="Go To Main Page" Width="114px" />
						<asp:Button ID="btnclose"  OnClientClick="window.close();" Visible="false" CssClass="button" runat="server" Text="Close Window" Width="98px" />
						
						</td>
				</tr>
				
				
			</table>
          
            <div class="box-contents" id="box-contents">
            </div>
        </div>
    </div>

</div> 
    </form>
</body>
</html>
