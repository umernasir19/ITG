<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="ExportLCView.aspx.vb" Inherits="Integra.ExportLCView" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
                $find('<%=dgView.ClientID %>').get_masterTableView().showFilterItem();
            }
            function hideFilterItem() {
                $find('<%=dgView.ClientID %>').get_masterTableView().hideFilterItem();
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
 <table width ="100%">
            <tr>
                <td align="right">
                    <telerik:RadButton ID="btnAdd" runat="server" Text="Add Export LC" Skin="WebBlue">
                    </telerik:RadButton>
                </td>
            </tr>

            </table>
            <br />
            <table>
            <tr>

                <td>
                <div style ="overflow :scroll ; width :930px;">

                    <telerik:RadGrid ID="dgView" runat="server" CellSpacing="0" AutoGenerateColumns="False"
                        Skin="WebBlue"  AllowFilteringByColumn="True" AllowPaging="True" GridLines="None"
                        ShowGroupPanel="True" PageSize="50" OnSortCommand="dgView_SortCommand" OnPageIndexChanged="dgView_PageIndexChanged"
                        ShowStatusBar="True" StatusBarSettings-ReadyText="Loading">
                   <%--      <EditFormSettings>
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
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>--%>
                        <ClientSettings AllowDragToGroup="True">
                        </ClientSettings>
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <GroupingSettings CaseSensitive="false"></GroupingSettings>
                        <MasterTableView AutoGenerateColumns="false" AllowFilteringByColumn="True" ShowFooter="True"
                            TableLayout="Auto" DataKeyNames="LCExportMstID" GroupLoadMode="Client">
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="LCExportMstID" DataField="LCExportMstID" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                  <telerik:GridBoundColumn HeaderText="PIID" DataField="PIID" Display="false" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>

                                     <telerik:GridTemplateColumn ShowFilterIcon="false" HeaderText="S.No" FilterControlWidth="50px" AllowFiltering="true" >
                                        <ItemStyle HorizontalAlign="Left" />
                                        <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# Container.DataSetIndex+1 %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>



                                      <telerik:GridBoundColumn HeaderText="LC NO" DataField="LCNo" AllowFiltering="true"
                                    FilterControlWidth="100px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="CENTER" Width="2%"/>
                                    <HeaderStyle Width="8%" HorizontalAlign="CENTER" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                 

                                <telerik:GridBoundColumn HeaderText="Season" DataField="SeasonName"  AllowFiltering="true"
                                    FilterControlWidth="100px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="CENTER" />
                                    <HeaderStyle Width="8%" HorizontalAlign="CENTER" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="SR NO" DataField="SRNO"  AllowFiltering="true"
                                    FilterControlWidth="100px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="CENTER" />
                                    <HeaderStyle Width="8%" HorizontalAlign="CENTER" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                
                              

                               <telerik:GridBoundColumn HeaderText="Buyer" DataField="CustomerName"  AllowFiltering="true"
                                    FilterControlWidth="100px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="CENTER" />
                                    <HeaderStyle Width="8%" HorizontalAlign="CENTER" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                               <telerik:GridBoundColumn HeaderText="Sales Contract No" DataField="salescontract"  AllowFiltering="true"
                                    FilterControlWidth="100px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="CENTER" />
                                    <HeaderStyle Width="8%" HorizontalAlign="CENTER" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                <%-- <telerik:GridBoundColumn HeaderText="Order No" DataField="OrderNo"  AllowFiltering="true"
                                    FilterControlWidth="40px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="4%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                 <telerik:GridBoundColumn HeaderText="Description" DataField="Descriptionn"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                 <telerik:GridBoundColumn HeaderText="Ship Date" DataField="ShipmentDatee"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn HeaderText="Order Qty" DataField="OrderQty"  AllowFiltering="true"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                 <telerik:GridBoundColumn HeaderText="Ship Qty" DataField="ShipmentQty"  AllowFiltering="true"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             

                              <telerik:GridBoundColumn HeaderText="Balance Qty" DataField="BalanceQty"  AllowFiltering="true"
                                    FilterControlWidth="30px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             

                              <telerik:GridBoundColumn HeaderText="Remarks" DataField="Remarks"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="S Contract No" DataField="salescontractno"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="S.C Qty" DataField="salesContractQty"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="S.C Amount" DataField="SalesContractAmount"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                  <telerik:GridBoundColumn HeaderText="Payment Term" DataField="Paymentterm"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                   <telerik:GridBoundColumn HeaderText="Payment Term" DataField="Paymentterm"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                   <telerik:GridBoundColumn HeaderText="Currency" DataField="CurrencyName"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                
                             
                              <telerik:GridBoundColumn HeaderText="LC Amount" DataField="LCAmount"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn HeaderText="PI Send Date" DataField="PISendDatee"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn HeaderText="LC Recv Date" DataField="LCRecvDatee"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                                 <telerik:GridBoundColumn HeaderText="LC Ship Date" DataField="LCShipDatee"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                 <telerik:GridBoundColumn HeaderText="LC AMD Datee" DataField="LCAMDDatee"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>


                             

                                <telerik:GridBoundColumn HeaderText="Negotiate Bank" DataField="NegotiateBank"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn HeaderText="Issue Bank" DataField="IssueBank"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>
                             
                               <telerik:GridBoundColumn HeaderText="Issue Remarks" DataField="IssueRemarks"  AllowFiltering="true"
                                    FilterControlWidth="70px" AutoPostBackOnFilter="false" CurrentFilterFunction="StartsWith"
                                    FilterDelay="3000" ShowFilterIcon="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="7%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridBoundColumn>--%>
                             <telerik:GridTemplateColumn HeaderText="Edit" UniqueName="Edit" AllowFiltering="false"
                                    Display="true">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEdit" Font-Underline="false" Text="Update" Enabled="true" NavigateUrl='<%# "ExportLCEntry.aspx?LCExportMstID=" &amp; DataBinder.Eval(Container.DataItem,"LCExportMstID")%>'
                                            runat="server"></asp:HyperLink>
                                    </ItemTemplate>

                                   <headerstyle width="10%" />

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
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
          </div>      </td>
            </tr>
        </table>


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


