<%@ Page Title="Monthly Comparision" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="MonthlyComparisionForFStore.aspx.vb" Inherits="Integra.MonthlyComparisionForFStore" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register TagPrefix="Smart" Namespace="SmartControls.Controls" Assembly="SmartControls" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="6" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Monthly Comparision Report
            </th>
        </tr>
        <tr>
            <td  style="padding:8px 5px;">
                Item Code
            </td>
            <td valign="top" style="padding:8px 5px;">
                <asp:TextBox ID="TXTCodeEntry" AutoPostBack ="true"  CssClass="textbox" runat="server"></asp:TextBox>
                <cc1:AutoCompleteExtender runat="server" ID="AutoCompleteExtender2" TargetControlID="TXTCodeEntry"
                ServicePath="../AutoComplete.asmx" ServiceMethod="GetCompletionList" MinimumPrefixLength="1"
                CompletionInterval="10" EnableCaching="true" CompletionSetCount="12" ContextKey="TXTCodeEntry" />
            </td>
           
        </tr>
        <tr>
            <td  style="padding:8px 5px;">
                Item Category
            </td>
            <td valign="top" style="padding:8px 5px;">
                <asp:DropDownList ID="cmbItemCategory" CssClass="combo" Width="133" runat="server" TabIndex="0"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
           
        </tr>
        <tr>
            <td  style="padding:8px 5px;">
                Year
            </td>
            <td valign="top" style="padding:8px 5px;"> 
                <asp:DropDownList ID="cmbYear" CssClass="combo" Width="133" runat="server" 
                    AutoPostBack="false">
                    <asp:ListItem Value="0">All</asp:ListItem>
                    <asp:ListItem Value="2014">2014</asp:ListItem>
                    <asp:ListItem Value="2015">2015</asp:ListItem>
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                    <asp:ListItem Value="2019">2019</asp:ListItem>
                    <asp:ListItem Value="2020">2020</asp:ListItem>
                    <asp:ListItem Value="2021">2021</asp:ListItem>
                    <asp:ListItem Value="2022">2022</asp:ListItem>
                    <asp:ListItem Value="2023">2023</asp:ListItem>
                    <asp:ListItem Value="2024">2024</asp:ListItem>
                    <asp:ListItem Value="2025">2025</asp:ListItem>
                </asp:DropDownList>
            </td>
            <th style="padding:8px 5px;">
            </th>
            <td valign="top" style="padding:8px 5px;">
                
            </td>
        </tr>
       </table><br /> <table>
        <tr>
            <td>
            </td>
            <td>
                <telerik:RadButton ID="btnGetReport" runat="server" Text="Download Report" Skin="WebBlue">
                </telerik:RadButton>
            </td>
        </tr>
    </table>
</asp:Content>
