<%@ Page Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="VolunteersSearchResult.aspx.cs" Inherits="VolunteerSearchResult" Title="بنك الطعام المصرى -نتيجة البحث " %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CustomControls" Namespace="System.Web.UI.WebControls" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 780px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="Scripts\jquery-1.3.1.js" />
            <asp:ScriptReference Path="Scripts\jquery.blockUI.js" />
            <asp:ScriptReference Path="Scripts\GeneralJqueryHandler.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitle" runat="server" CssClass="PageTitle" Text="قاعدة بيانات المتطوعين – صفحة نتيجة البحث"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td align="center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblSearchFilter" runat="server"></asp:Label>
                    </td>
                </tr>
              
                <tr>
                    <td align="center">
                        &nbsp;
                    </td>
                </tr>
              
                <tr>
                    <td align="center">
                        <asp:Label ID="lblResult" runat="server" CssClass="TextBlack"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td align="left">
                        <asp:ImageButton ID="imgPrint" runat="server" ImageUrl="~/Images/Printer.jpg" OnClick="imgPrint_Click"
                            Width="35px" Height="35px"  />
                        <asp:Label ID="lblVolunteersCount" runat="server" style="float:right"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <cc2:MockPagerGrid ID="mgrdSearchResult" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#009933" BorderStyle="None" BorderWidth="1px"
                            CellPadding="1" ForeColor="Black" AllowPaging="True" OnRowDataBound="mgrdSearchResult_RowDataBound"
                            OnPageIndexChanging="mgrdSearchResult_PageIndexChanging" MockItemCount="0" MockPageIndex="0"
                            PageSize="20" Width="780px">
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="lightyellow" Height="50px" />
                            <Columns>
                                <asp:TemplateField HeaderText="م">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="VolunteerManID" HeaderText="رقم  تعريف المتطوع" />
                                <asp:TemplateField HeaderText="الأسم الثلاثى">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkVolunteerName" runat="server" Text='<%#Bind("vName") %>' CommandArgument='<%#Bind("VolunteerId") %>'
                                            OnCommand="lnkVolunteerName_Command"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ الميلاد">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Bind("vBirthDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="vTelephone" HeaderText="التليفون" />
                                <asp:BoundField DataField="vMobile" HeaderText="المحمول" />
                                <asp:TemplateField HeaderText="المدرسة/الجامعة">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUniversity" runat="server" Text='<%# Bind("VFacultyID") %>'></asp:Label>
                                        <asp:Label ID="lblSchool" runat="server" Text='<%# Bind("VSchool") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="الوظيفة و المؤسسة">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblCurrentJob" runat="server" Text='<%# Bind("VCurrentJob") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblJobPlace" runat="server" Text='<%# Bind("vJobPlaceID") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                                <asp:TemplateField HeaderText="أول إتصال بالمتطوع (المكان) ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstContactPlace" runat="server" Text='<%# Bind("vFirstContactPlaceId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="أول اتصال بالمتطوع (التاريخ)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstContactDate" runat="server" Text='<%# Bind("vFirstContactDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="استيفاء الاستمارة ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRegisterDate" runat="server" Text='<%# Bind("vRegisterDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="لقاء التعريف">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMeetingDate" runat="server" Text='<%# Bind("vMeetingDate") %>'></asp:Label>
                                                    <asp:Label ID="lblApologyDate" runat="server" Text='<%# Bind("vMeetingApologyDate")%>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMeetingStatus" Width="40px" runat="server" Text='<%# Bind("vMeetingDone")%>'></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اول نشاط (تاريخ) ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstActivityDate" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اول نشاط (نوع النشاط)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstActivityType" runat="server" Text='<%#Bind("VolunteerID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtnEditVolunteer" runat="server" CommandArgument='<%# Bind("VolunteerId") %>'
                                            Height="14px" ImageUrl="~/Images/icon_Edit.gif" Width="14px" OnCommand="imgBtnEditVolunteer_Command" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلغاء">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtnDeleteVolunteer" runat="server" CommandArgument='<%# Bind("VolunteerId") %>'
                                            Height="14px" ImageUrl="~/Images/icon_Delete.gif" Width="14px" OnCommand="imgBtnDeleteVolunteer_Command" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast"  FirstPageText ="الأولى" LastPageText ="الأخيرة"  />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#009933" ForeColor="#FFFFFF" />
                            <AlternatingRowStyle BackColor="#cdea78" />
                        </cc2:MockPagerGrid>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;
                        <asp:HyperLink ID="hlnkBack" runat="server" NavigateUrl="~/VolunteersSearch.aspx">الصفحة السابقة</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
