<%@ Page Title="Menu Builder" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="MenuBuilder.aspx.vb" Inherits="Integra.MenuBuilder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
        <tr style="border-bottom-style: solid; height: 50px; border-bottom-color: #00509F;
            border-bottom-width: thin;" visible="true">
            <th colspan="1" align="left" style="font-family: Arial; font-size: 16PX; font-weight: bold;
                color: #808080;">
                Menu Builder
            </th>
        </tr>
        </table><table>

        <tr>
            <td style="width: 110px;">
                Designation.
            </td>
            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                <telerik:RadComboBox ID="cmbDesignation" runat="server" AutoPostBack="true" Skin="WebBlue">
                </telerik:RadComboBox>
            </td>

            <td class="TopHeaderTable3" style="width: 166px; height: 30px;">
                 <telerik:RadTextBox ID="txtDepartment" ReadOnly ="true"  style="text-transform :uppercase ;" runat="server" Skin="WebBlue" Width="160px">
                                    </telerik:RadTextBox>
            </td>
            </tr>
            </table> 

            <br />
            <table >
            <tr>
            <td>
                                    <telerik:RadButton ID="btnAdd" runat="server" Text="Generate" Skin="WebBlue"
                                        Width="100px" Visible ="true" >
                                    </telerik:RadButton>
                                </td>
            </tr>
            </table>
            <br />


            <table>
            <tr>
                <td>
                   <div style="width: 930px;">
                    <telerik:RadGrid ID="dgMenuBuilder" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                        Skin="WebBlue" Visible="true" Width="100%">
                        <AlternatingItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" />
                        <MasterTableView>
                            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            </ExpandCollapseColumn>
                            <Columns>

                                <telerik:GridBoundColumn HeaderText="FormRoleId" DataField="FormRoleId" Display="false">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <HeaderStyle Width="1%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                             
                                
                                
                                <telerik:GridBoundColumn HeaderText="Module" DataField="TextToDisplay">
                                    <ItemStyle HorizontalAlign="Left" Width="10px" />
                                    <HeaderStyle Width="25%" HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>


<telerik:GridTemplateColumn HeaderText="Module Header" AllowFiltering="false">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="cmbModuleHeader" CssClass="textbox" runat="server" Skin="WebBlue"
                                            Width="80px">
                                            
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="6%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>



                      <telerik:GridTemplateColumn HeaderText="Sequence" AllowFiltering="false">
                                    <ItemTemplate>
                                        <telerik:RadTextBox ID="txtSequence" runat="server" CssClass="textbox" Text='<% #Eval("Sequence") %>'
                                            Width="40">
                                        </telerik:RadTextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Width="3%" HorizontalAlign="Left" Font-Size="Smaller" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridTemplateColumn>


                                <telerik:GridTemplateColumn HeaderText="Select" AllowFiltering="false">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkUpdate" runat="server" Width="10"></asp:CheckBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Names="Microsoft Sans Serif" />
                                    <ItemStyle Font-Size="X-Small" Font-Names="Microsoft Sans Serif" Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" Width="5" />
                                    <HeaderStyle Width="2%" HorizontalAlign="Left" Font-Size="Smaller" />
                                </telerik:GridTemplateColumn>



                              
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        </MasterTableView>
                        <HeaderStyle Font-Names="Microsoft Sans Serif" />
                      
                        <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                  </div>
      
           
                </td>
            </tr>
        </table>

</asp:Content>
