<%@ Page Title="Sample Programme Sheet" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="SampleProgrammeSheet.aspx.vb" Inherits="Integra.SampleProgrammeSheet" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr style="border-bottom-style: solid; height: 20px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Sample Programme Sheet
            </th>
        </tr>
        <tr>
            <td style="width: 110px;">
                Customer.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbSupplier" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            <%--   <td style="width: 110px;">
                Item.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbItem" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>--%>
        </tr>
        <tr>
            <td style="width: 110px;">
                Dal No.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbDalNO" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
            <td style="width: 110px;">
                Style.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbStyle" runat="server" AutoPostBack="false" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblForm" runat="server" Text="From :"></asp:Label>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="txtDateFrom" runat="server" Culture="en-US">
                    <Calendar ID="Calendar1" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput1" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
            </td>
            <td>
                <asp:Label ID="lblTo" runat="server" Text="To :"></asp:Label>
            </td>
            <td valign="top">
                <telerik:RadDatePicker ID="txtDateTo" runat="server" Culture="en-US">
                    <Calendar ID="Calendar2" UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False"
                        runat="server">
                    </Calendar>
                    <DateInput ID="DateInput2" DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy"
                        LabelWidth="40%" runat="server">
                    </DateInput>
                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                </telerik:RadDatePicker>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
           
            <td  style=" width :50px;">
           
                <telerik:RadButton ID="btnGetReport" runat="server" style=" " Text="Show Data" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
    <br>
    <table>
        <tr>
            <td>
                <div style="width: 920PX; overflow: scroll; HEIGHT: 350PX;" >
                    <Smart:SmartDataGrid ID="dgViewMaster"  runat="server" Width="100%" OnSortCommand="SortByColumn"
                        OnPageIndexChanged="PageChanged" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        CellPadding="4" CssClass="tableNew" PageSize="50000" ShowFooter="True" ForeColor="black" height ="400PX"
                        GridLines="both">
                        <Columns>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black"   HeaderStyle-Width="5%" HeaderText="DPRNDid"
                                DataField="DPRNDid" Visible="FALSE" />  
                                
                                
                                
                                   <asp:TEMPLATECOLUMN HeaderText="To PDF" Visible="true" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black">
                            <itemtemplate>
																	

									<asp:CheckBox id="ChkDownLoad" OnCheckedChanged="UpdateStatus" AutoPostBack="true" runat="server"/>
</itemtemplate>
                            <headerstyle width="2%" />
                            <itemstyle horizontalalign="Center" />
                        </asp:TEMPLATECOLUMN>
                               
                        

                              <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Dal No" DataField="DalNo"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Buyer" DataField="Buyer"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Style" DataField="Style">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Item" DataField="Descriptionn"
                                Visible="true">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Size" DataField="Size">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Qty" DataField="Quantity">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Composition" DataField="CompositionName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Fabric Detail" DataField="FabricName">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Pocket Lining" DataField="PocketLining">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Washing Detail" DataField="WashingDetail">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Remarks" DataField="Remarks">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Thread" DataField="ThreadsNew">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" HeaderText="Width Cutable" DataField="WidthCutable">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
                            <asp:BoundColumn ItemStyle-HorizontalAlign="center" Visible="FALSE" HeaderText="SampleStatus"
                                DataField="SampleStatus">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>

<asp:BoundColumn ItemStyle-HorizontalAlign="center" HeaderStyle-BackColor="#04A4BD" HeaderStyle-ForeColor ="Black" Visible ="false"  HeaderText="Date" DataField="CreatDatee">
                                <HeaderStyle HorizontalAlign="center" Width="5%" />
                            </asp:BoundColumn>
          </Columns>
                    </Smart:SmartDataGrid>
                </div>
            </td>
        </tr>
    </table>

    <br />

    <table >
    <tr>
    <td>
      <telerik:RadButton ID="btnSave" runat="server" Text="Report Download" Skin="WebBlue">
                </telerik:RadButton></td>
                 <td>
      <telerik:RadButton ID="btnExcel" runat="server" Text="Excel Download" Skin="WebBlue">
                </telerik:RadButton></td>
    </tr>
    </table>

</asp:Content>
