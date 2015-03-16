<%@ Page Title="" Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true" CodeFile="VolunteersPrintSearchResult.aspx.cs" Inherits="VolunteerPrintSearchResult" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CustomControls" Namespace="System.Web.UI.WebControls" TagPrefix="cc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
<table>
<tr>
                    <td align="center">
                        <asp:Label ID="lblVolunteersCount" runat="server" CssClass="TextBlack"></asp:Label>
                    </td>
                </tr>
<tr>
                    <td align="center">
                        <asp:Label ID="lblResult" runat="server" CssClass="TextBlack"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <cc2:MockPagerGrid ID="mgrdSearchResult" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#009933" BorderStyle="None" BorderWidth="1px"
                            CellPadding="1" ForeColor="Black" 
                            OnRowDataBound="mgrdSearchResult_RowDataBound" MockItemCount="0" 
                            MockPageIndex="0" PageSize="20" Width="780px">
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="lightyellow" />
                            <Columns>
                                <asp:TemplateField HeaderText="م">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VolunteerManID" HeaderText="رقم  تعريف المتطوع" />
                                <asp:BoundField DataField="vName" HeaderText="الأسم الثلاثي" />
                                <asp:TemplateField HeaderText="تاريخ الميلاد">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Bind("vBirthDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="vTelephone" HeaderText="التليفون" />
                                <asp:BoundField DataField="vMobile" HeaderText="المحمول" />
                                <asp:TemplateField HeaderText="الجامعة">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUniversity" runat="server" Text='<%# Bind("VFacultyID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VCurrentJob" HeaderText="الوظيفة" />
                                <asp:TemplateField HeaderText="المحافظة">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المنطقة">
                                    <ItemTemplate>
                                        <asp:Label ID="lblArea" runat="server" Text='<%# Bind("vAreaID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="vEmail" HeaderText="البريد الإلكتروني" />
                                    <asp:TemplateField HeaderText="أول إتصال بالمتطوع">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstContactPlace" runat="server" Text='<%# Bind("vFirstContactPlaceId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="لقاء التعريف">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMeetingDate" runat="server" Text='<%# Bind("vMeetingDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#009933" ForeColor="#FFFFFF" />
                            <AlternatingRowStyle BackColor="#cdea78" />
                        </cc2:MockPagerGrid>
                    </td>
                </tr>
</table>
</asp:Content>

