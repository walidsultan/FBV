<%@ Page Title="" Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="ActivitiesSearchResult.aspx.cs" Inherits="ActivitiesSearchResult" %>

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
                    <td align="center" height="15px">
                        &nbsp;
                    </td>
                </tr>
                <%--<tr>
                    <td align="center">
                        <div id="divActivityResultSummary" runat="server" style="background-color: #E2E2E2;
                            width: 750px;">
                            <table cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" colspan="4">
                                        <asp:Panel ID="pnlSummaryHandler" runat="server" BackImageUrl="images/Menu_bg2.gif"
                                            BorderColor="#E2E2E2" BorderWidth="1" Height="23" HorizontalAlign="Left">
                                            <asp:ImageButton ID="imgCloseSummary" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                                Width="21px" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="height: 25px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="center" class="MainText" colspan="2">
                                        <asp:Label ID="lblActivityResultSummary" runat="server"></asp:Label>
                                        &nbsp; &nbsp;
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="padding: 10px">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:LinkButton ID="lnkBtnDummySummary" runat="server"></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="mpeActivityResultSummary" runat="server" BackgroundCssClass="modalBackground"
                            CancelControlID="imgCloseSummary" PopupControlID="divActivityResultSummary" PopupDragHandleControlID="pnlSummaryHandler"
                            TargetControlID="lnkBtnDummySummary">
                        </cc1:ModalPopupExtender>
                    </td>
                </tr>--%>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblTitle" runat="server" CssClass="PageTitle" Text="قاعدة بيانات الانشطة صفحة نتيجة البحث"></asp:Label>
                    </td>
                </tr>
                  
                <tr>
                    <td align="center">
                        <asp:Label ID="lblResult" runat="server" CssClass="TextBlack"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <asp:Label ID="lblActivitiesCount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <cc2:MockPagerGrid ID="mgrdSearchResult" runat="server" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#009933" BorderStyle="None" BorderWidth="1px"
                            CellPadding="1" ForeColor="Black" AllowPaging="True" OnRowDataBound="mgrdSearchResult_RowDataBound"
                            OnPageIndexChanging="mgrdSearchResult_PageIndexChanging" 
                            UseAccessibleHeader="False" Width="780px">
                            <FooterStyle BackColor="#CCCC99" />
                            <RowStyle BackColor="lightyellow" />
                            <Columns>
                                <asp:TemplateField HeaderText="م">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerial" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="رقم  تعريف النشاط">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkActivityCodeNo" runat="server" Text='<%#Bind("ActivityCodeNo") %>'
                                            CommandArgument='<%#Bind("ActivityId") %>' 
                                            oncommand="lnkActivityCodeNo_Command"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إسم الإدارة">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle  Width="100px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="مجال التطوع">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityField" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="اسم النشاط">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityName" runat="server" Text='<%#Bind("ActivityName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ ورود الطلب">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRequestDate" runat="server" Text='<%# Bind("ActivityRequestDate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ بدء النشاط">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityStartDate" runat="server" Text='<%# Bind("ActivityDateFrom") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تاريخ انتهاء النشاط">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityEndDate" runat="server" Text='<%# Bind("ActivityDateTo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="المكان">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityPlace" runat="server" Text='<%# Bind("ActivityPlaceID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عدد المتطوعين">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVolunteersCount" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عدد الايام">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDaysCount" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="عدد الساعات">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityHours" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ActivityId" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblActivityId" runat="server" Text='<%# Bind("ActivityID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="تعديل">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtnEditActivity" runat="server" CommandArgument='<%# Bind("ActivityId") %>'
                                            Height="14px" ImageUrl="~/Images/icon_Edit.gif" OnCommand="imgBtnEditActivity_Command"
                                            Width="14px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="إلغاء">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBtnDeleteActivity" runat="server" CommandArgument='<%# Bind("ActivityId") %>'
                                            Height="14px" ImageUrl="~/Images/icon_Delete.gif" OnCommand="imgBtnActivityDelete_Command"
                                            Width="14px" />
                                    </ItemTemplate>
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
                        <asp:HyperLink ID="hlnkBack" runat="server" NavigateUrl="~/ActivitiesSearch.aspx">الصفحة السابقة</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
