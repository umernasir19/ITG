<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master"
    CodeBehind="OpeningBalance.aspx.vb" Inherits="Integra.OpeningBalance" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



<asp:GridView runat="server" ID="GridView1" CssClass="alt" AutoGenerateColumns="False" Width="100%" Visible="true"
BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" >
<AlternatingRowStyle BackColor="White" />
    <Columns>
       
          <asp:BoundField DataField="ChartOFAccountID" HeaderText="Chart OF Account ID">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="AccountCode" HeaderText="AccountCode">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
       <%-- <asp:BoundField DataField="AccountName" HeaderText="AccountName">
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>--%>


        <asp:TemplateField HeaderText="AccountName" InsertVisible="false" ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:TextBox ID="txtaccountname" runat="server" Visible="true" Text='<%# Eval("AccountName") %>' ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>


         <asp:TemplateField HeaderText="Opening Credit" InsertVisible="false" ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:TextBox ID="txtcredit" runat="server" Visible="true" Text='<%# Eval("Opening_Credit") %>' ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Opening Debit" InsertVisible="false" ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:TextBox ID="txtdebit" runat="server" Visible="true" Text='<%# Eval("Opening_Debit") %>' ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>


         <asp:TemplateField HeaderText="Opening Update" InsertVisible="false" ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:Button ID="btnupdate" Text="Update" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>" runat="server"  />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Update Account"  ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:Button ID="btnEdit" CssClass="btn-success" Text="Edit" CommandName="Edit" CommandArgument="<%# Container.DataItemIndex %>" runat="server"  />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete Account" InsertVisible="false" ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:Button CssClass="btn-danger" ID="btnDelete" Text="Delete" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>" runat="server"  />
            </ItemTemplate>
        </asp:TemplateField>

         <%--<asp:TemplateField HeaderText="Select" InsertVisible="false" ItemStyle-BorderStyle="Double">
            <ItemTemplate>
                <asp:CheckBox ID="CheckBox1" runat="server" Visible="true" Checked='<%# Eval("ChartOFAccountID") %>' />
            </ItemTemplate>
        </asp:TemplateField>--%>
    </Columns>
</asp:GridView>


</asp:Content>
