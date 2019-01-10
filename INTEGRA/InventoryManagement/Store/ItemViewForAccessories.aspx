<%@ Page Title="Accessories Item View" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ItemViewForAccessories.aspx.vb" Inherits="Integra.ItemViewForAccessories" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <telerik:RadAjaxManager ID="RadAjaxManager1" EnableAJAX="true" runat="server">
        <ClientEvents OnRequestStart="onRequestStart" OnResponseEnd="onResponseEnd" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="dgECPSampling">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="dgECPSampling" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" BackgroundPosition="Bottom"
        Width="80%">
        <asp:Image ID="Image1" runat="server" AlternateText="Loading..." ImageUrl="~/Images/loading12.gif" />
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server" ID="radCodeBlock">
        <script type="text/javascript">
            function showFilterItem() {
                $find('<%=dgItemView.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgItemView.ClientID %>').get_masterTableView().hideFilterItem();
            }        
        </script>
    </telerik:RadCodeBlock>
    <div>
        <label for="RadioButtonList1">
            Show filtering item</label>
        <asp:RadioButtonList runat="server" ID="RadioButtonList1" RepeatDirection="Horizontal">
            <asp:ListItem Text="Yes" Selected="True" onclick="showFilterItem()"></asp:ListItem>
            <asp:ListItem Text="No" onclick="hideFilterItem()"></asp:ListItem>
        </asp:RadioButtonList>
    </div>


    <div>

    <table>
    <tr>
          <td>
  <asp:LinkButton ID="LinkButtoniTEMlIST" runat="server" style=" height: 17px; margin-left: 0px; color :Blue ;" Visible="true">Download Item List PDF</asp:LinkButton>
 </td>
          </tr>
    </table>
    <br />
        <table width="90%">
          
            <tr>
                <td>
           <div style="width :930PX;  overflow: scroll; ">

                    <telerik:RadGrid ID="dgItemView" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue"  AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                        ShowGroupPanel="True" PageSize="50" OnSortCommand="dgItemView_SortCommand" OnPageIndexChanged="dgItemView_PageIndexChanged" 
                        ShowStatusBar="True" StatusBarSettings-ReadyText="Loading">
                    
                        <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                        </ClientSettings>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="IMSItemID" GroupLoadMode="Client">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="IMSItemID" DataField="IMSItemID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="0%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                             

                                 <telerik:GridTemplateColumn ShowFilterIcon="false" HeaderText="S.No" AllowFiltering="false" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="0%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Container.DataSetIndex+1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>


                                <telerik:GridBoundColumn HeaderText="Chart Of Account" DataField="ItemCodee" UniqueName="ItemCodee" AllowFiltering="true"
                                    FilterControlWidth="30px"      AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="400" ShowFilterIcon="false" >
                                    <ItemStyle HorizontalAlign="Left" Width ="0px" />
                                    <HeaderStyle Width="1px" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn HeaderText="Item Name" UniqueName="ItemName" DataField="ItemName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="400" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                              

                                    <telerik:GridBoundColumn HeaderText="Dal No" DataField="DalNo" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="true" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn HeaderText="Dal Ref No" DataField="DalRefNo" AllowFiltering="true"
                                    FilterControlWidth="20px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             
                                <telerik:GridBoundColumn HeaderText="Item Quality" DataField="ItemQuality" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Item Class Name" DataField="ItemClassName" AllowFiltering="true"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="50%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="Item Category Name" DataField="ItemCategoryName"
                                    AllowFiltering="true" FilterControlWidth="50px" AutoPostBackOnFilter="false"
                                    CurrentFilterFunction="StartsWith" FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

 <telerik:GridBoundColumn HeaderText="Shade" DataField="Shade" AllowFiltering="true" HeaderStyle-Width ="10px"
                                    FilterControlWidth="40px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="400" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5px" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="Color" DataField="Color" AllowFiltering="true"
                                    FilterControlWidth="40px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="400" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5px" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="Unit Rate" DataField="UnitRate" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="20%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn HeaderText="Quantity" DataField="OpeningQuantity" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="5%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="Unit" DataField="Symbol" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="500" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                <telerik:GridBoundColumn HeaderText="Curr" DataField="CurrencyName" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="400" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="Opening Value" DataField="OpeningValue" AllowFiltering="false"
                                    FilterControlWidth="50px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="400" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>



                                  <telerik:GridTemplateColumn ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="01%"
                                    AllowFiltering="false" HeaderText="PDF" Visible="true">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="lnkPDF" ToolTip="Click here to download PDF" ImageUrl="~/Images/pdfIcon.png"
                                            CommandName="PDF" runat="server"></asp:ImageButton>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>



                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <ClientSettings EnableRowHoverStyle="false" EnablePostBackOnRowClick="false">
                            <Selecting AllowRowSelect="true" EnableDragToSelectRows="true" />
                        </ClientSettings>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                        <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        
                        <PagerStyle PageSizeControlType="RadComboBox" Position ="TopAndBottom"  ></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid></div> 
                </td>
            </tr>
        </table>
    </div>
    <%-- Script For Loading Panel  --%>
    <script language="javascript" type="text/javascript">
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



































 


 
 
 


               
       


					
							
                            
                           
								 
                                 

                                             
                                  


                                                        						 	
						
							



                               
								
                          
                               
								
							
					


