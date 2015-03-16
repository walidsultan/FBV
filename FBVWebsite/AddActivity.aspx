<%@ Page Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="AddActivity.aspx.cs" Inherits="AddActivity" Title="بنك الطعام المصرى - أضف نشاط" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
            <asp:ScriptReference Path="Scripts\PagesBehaviour\BehaviourAddActivity.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td colspan="4" align="center">
                        <asp:UpdateProgress ID="upAddActivity" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="imgProgress" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                    Width="25px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblTitle" runat="server" CssClass="PageTitle" Text="قاعدة بيانات الأنشطة – صفحة الإضافة"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="tdRequest" align="right" class="TextWhite" colspan="4" style="background-image: url(images/Menu_bg2.gif);
                        color: #FFFFFF;">
                        أولاً : بيانات طلب الإستعانة
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <div id="divRequest" style="overflow: hidden">
                            <table>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        <div id="divDepartment" runat="server" style="background-color: #E2E2E2; width: 450px;
                                            display: none">
                                            <table cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right" colspan="4">
                                                        <asp:Panel ID="Panel1" runat="server" BackImageUrl="images/Menu_bg2.gif" BorderColor="#E2E2E2"
                                                            BorderWidth="1" Height="23" HorizontalAlign="Left">
                                                            <asp:ImageButton ID="imgCloseDepartment" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                                                Width="21px" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="height: 25px">
                                                        <asp:UpdateProgress ID="UpdateProgress12" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgProgress01" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                                                    Width="25px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" colspan="2">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText" colspan="2">
                                                        إسم الإدارة
                                                    </td>
                                                    <td align="right" colspan="2">
                                                        <asp:DropDownList ID="drpDepartment" runat="server" AutoPostBack="True" CssClass="TextBlack"
                                                            OnSelectedIndexChanged="drpDepartment_SelectedIndexChanged" Height="25px">
                                                        </asp:DropDownList>
                                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                        <asp:Image ID="imgActivityDepartmentV" runat="server" Height="20px" ImageAlign="Middle"
                                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText" colspan="2">
                                                        ممثل الإدارة
                                                    </td>
                                                    <td align="right" colspan="2">
                                                        <asp:DropDownList ID="drpDepartmentResponsibleUser" runat="server" CssClass="TextBlack"
                                                            Height="25px" Width="200px">
                                                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                        <asp:Image ID="imgActivityDepartmentResponsibleUserV" runat="server" Height="20px"
                                                            ImageAlign="Middle" ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 10px">
                                                        <asp:Button ID="btnAddDepartment" runat="server" CssClass="Button" OnClick="btnAddDepartment_Click"
                                                            Text="إضافة" />
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
                                        <asp:LinkButton ID="lnkBtnDummyDepartment" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="mpeDepartment" runat="server" BackgroundCssClass="modalBackground"
                                            CancelControlID="imgCloseDepartment" PopupControlID="divDepartment" TargetControlID="lnkBtnDummyDepartment">
                                        </cc1:ModalPopupExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        رقم تعريف النشاط
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:TextBox ID="txtActivityCodeNo" runat="server" CssClass="TextBlack" Height="20px"
                                            Width="200px"></asp:TextBox>
                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                        <asp:Image ID="imgActivityCodeNoV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        الإدارات
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:LinkButton ID="lnkAddDepartment" runat="server" OnClick="lnkAddDepartment_Click">أضف إدارة </asp:LinkButton>
                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                        <asp:Image ID="imgActivityDepartments" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                        <asp:GridView ID="grdDepartments" runat="server" AutoGenerateColumns="False" Width="400px"
                                            OnRowDataBound="grdDepartments_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Department" HeaderText="إسم الإدارة">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DepartmentResponsibleUser" HeaderText="ممثل الإدارة">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="تغير">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnEditActivityDepartment" runat="server" Height="14px" ImageUrl="~/Images/icon_Edit.gif"
                                                            Width="14px" CommandArgument='<%# Bind("DepartmentIndex") %>' OnCommand="imgBtnEditActivityDepartment_Command" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلغاء">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnActivityDepartmentDelete" runat="server" Height="14px"
                                                            ImageUrl="~/Images/icon_Delete.gif" Width="14px" CommandArgument='<%# Bind("DepartmentIndex") %>'
                                                            OnCommand="imgBtnActivityDepartmentDelete_Command" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="DGBody" />
                                            <HeaderStyle CssClass="DGHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        مجال التطوع
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="drpActivityField" runat="server" AutoPostBack="True" CssClass="TextBlack"
                                            Height="25px" OnSelectedIndexChanged="drpActivityField_SelectedIndexChanged"
                                            Width="200px">
                                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                        <asp:Image ID="imgActivityFieldV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        اسم النشاط
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityName" runat="server" CssClass="TextBlack" Height="20px"
                                            Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        تفاصيل النشاط
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityDetails" runat="server" CssClass="TextBlack" Height="20px"
                                            Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        المهام المطلوبة من المتطوع
                                    </td>
                                    <td align="right" colspan="3">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:CheckBoxList ID="chkVolunteerMissions" runat="server" RepeatDirection="Horizontal"
                                                        CssClass="MainText">
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td>
                                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                                    <asp:Image ID="imgActivityRequiredFields" runat="server" Height="20px" ImageAlign="Middle"
                                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        الفترة المقررة للنشاط
                                    </td>
                                    <td align="right" colspan="3">
                                        &nbsp&nbsp من :
                                        <asp:TextBox ID="txtActivityDateFrom" runat="server" AutoPostBack="True" CssClass="TextBlack"
                                            OnTextChanged="txtActivityDateFrom_TextChanged" Height="20px" Width="100px"></asp:TextBox>
                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                        <asp:Image ID="imgActivityStartV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                        &nbsp&nbsp&nbsp&nbsp إلى :
                                        <asp:TextBox ID="txtActivityDateTo" runat="server" AutoPostBack="True" CssClass="TextBlack"
                                            OnTextChanged="txtActivityDateTo_TextChanged" Height="20px" Width="100px"></asp:TextBox>
                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                        <asp:Image ID="imgActivityEndV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        المكان
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="drpActivityPlace" runat="server" CssClass="TextBlack" Height="25px"
                                            Width="200px">
                                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                                        </asp:DropDownList>
                                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                        <asp:Image ID="imgActivityPlaceV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        عدد المتطوعين المطلوبين
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityRequiredVolunteers" runat="server" CssClass="TextBlack"
                                            Height="20px" Width="200px"></asp:TextBox>
                                        <asp:Image ID="imgActivityRequiredVolunteersV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                    </td>
                                    <td align="left" class="MainText">
                                        &nbsp;
                                    </td>
                                    <td align="right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        تاريخ إستلام الطلب بالإدارة
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityRequestDate" runat="server" CssClass="TextBlack" Height="20px"
                                            Width="200px"></asp:TextBox>
                                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                        <asp:Image ID="imgActivityRequestDateV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        ملاحظات
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityComments" runat="server" CssClass="TextBlack" Height="60px"
                                            Width="200px" TextMode="MultiLine"></asp:TextBox>
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
                    </td>
                </tr>
                <tr>
                    <td id="tdVolunteers" align="right" class="TextWhite" colspan="4" style="background-image: url(images/Menu_bg2.gif);
                        color: #FFFFFF;">
                        ثانياً : بيانات توفير المتطوعين
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right" >
                        <div id="divVolunteers" style="overflow: hidden">
                            <table>
                                <tr>
                                    <td align="left" class="MainText">
                                        <asp:LinkButton ID="lnkActivityRequirments" runat="server" OnClick="lnkActivityRequirments_Click">متطلبات النشاط</asp:LinkButton>
                                    </td>
                                    <td align="right">
                                        <asp:Image ID="imgActivityRequirments" runat="server" ImageUrl="~/Images/Evaluation.gif"
                                            Visible="False" Width="20px" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        ممثل ادارة المتطوعين
                                    </td>
                                    <td align="right">
                                        <asp:DropDownList ID="drpVolunteerDepartmentResponsibleUser" runat="server" CssClass="TextBlack"
                                            Height="25px" Width="200px">
                                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                                        </asp:DropDownList>
                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                        <asp:Image ID="imgActivityEvaluatorV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="2">
                                        &nbsp;
                                        <asp:LinkButton ID="lnkAddDayDetails" runat="server" OnClick="lnkAddDayDetails_Click"
                                            Visible="False">أضف بيانات المتطوعين</asp:LinkButton>
                                    </td>
                                    <td align="right" colspan="2">
                                        <asp:LinkButton ID="lnkDummyActivityResult" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="mpeActivityResult" runat="server" BackgroundCssClass="modalBackground"
                                            CancelControlID="imgDeleteJobPlaces" PopupControlID="DivActivityResult" PopupDragHandleControlID="pnlDraghandler"
                                            TargetControlID="lnkDummyActivityResult">
                                        </cc1:ModalPopupExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                    </td>
                                    <td align="center" class="MainText" colspan="2">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="DivActivityResult" runat="server" style="background-color: #E2E2E2; width: 600px;">
                                            <table cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right" colspan="4">
                                                        <asp:Panel ID="pnlDraghandler" runat="server" BackImageUrl="images/Menu_bg2.gif"
                                                            BorderColor="#E2E2E2" BorderWidth="1" Height="23" HorizontalAlign="Left">
                                                            <asp:ImageButton ID="imgDeleteJobPlaces" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                                                Width="21px" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="height: 25px">
                                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgProgress0" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                                                    Width="25px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" style="width: 250px">
                                                        &nbsp;
                                                    </td>
                                                    <td class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        إسم المتطوع :
                                                    </td>
                                                    <td align="right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="drpVolunteerName" runat="server" CssClass="MainText" Height="25px">
                                                                        <asp:ListItem Value="Select">إختار</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                                    <asp:Image ID="imgActivityVolunteerV" runat="server" Height="20px" ImageAlign="Middle"
                                                                        ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="MainText">
                                                        اليوم :
                                                    </td>
                                                    <td align="right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="drpActivityDay" runat="server" CssClass="MainText" Height="25px">
                                                                        <asp:ListItem Value="Select">إختار</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                                    <asp:Image ID="imgActivityDayV" runat="server" Height="20px" ImageAlign="Middle"
                                                                        ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="MainText" colspan="4">
                                                        الساعات الفعلية لعمل المتطوع
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        من :&nbsp;
                                                    </td>
                                                    <td align="right" width="150px">
                                                        <asp:TextBox ID="txtWorkTimeFrom" runat="server" CssClass="TextBlack" Height="20px"
                                                            Width="60px"></asp:TextBox>
                                                        <asp:DropDownList ID="drpAmPmFrom" runat="server" CssClass="MainText" Height="25px">
                                                            <asp:ListItem Value="am">صباحاً</asp:ListItem>
                                                            <asp:ListItem Value="pm">مساءاً</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                        <asp:Image ID="imgActivityWorkStartV" runat="server" Height="20px" ImageAlign="Middle"
                                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                    </td>
                                                    <td class="MainText">
                                                        إلى :
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtWorkTimeTo" runat="server" CssClass="TextBlack" Height="20px"
                                                            Width="60px"></asp:TextBox>
                                                        <asp:DropDownList ID="drpAmPmTo" runat="server" CssClass="MainText" Height="25px">
                                                            <asp:ListItem Value="am">صباحاً</asp:ListItem>
                                                            <asp:ListItem Value="pm" Selected="True">مساءاً</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                        <asp:Image ID="imgActivityWorkEndV" runat="server" Height="20px" ImageAlign="Middle"
                                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        نوع المهام :
                                                    </td>
                                                    <td align="right" colspan="3">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBoxList ID="chkTypeOfMissions" runat="server" CssClass="MainText" RepeatDirection="Horizontal">
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                                <td>
                                                                    <%-- <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                    <asp:Image ID="imgActivityVolunteerMissionsV" runat="server" Height="20px" ImageAlign="Middle"
                                                        ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        ملاحظات عامة :
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtVolunteerWorkDetails" runat="server" CssClass="TextBlack" Height="20px"
                                                            Width="200px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 10px">
                                                        <asp:Button ID="btnAddActivityDayResult" runat="server" CssClass="Button" OnClick="btnAddActivityDayResult_Click"
                                                            Text="إضافة" />
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
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:GridView ID="grdActivityDaysOnDiv" runat="server" AutoGenerateColumns="False"
                                                            OnRowDataBound="grdActivityDays_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="اليوم">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblActivtyDay" runat="server" Text='<%#Bind("ActivityDay") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="المتطوع">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteer" runat="server" Text='<%#Bind("Volunteer") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="المهام">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteerMissions" runat="server" Text='<%#Bind("VolunteerMissions") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="من">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteerWorkingStart" runat="server" Text='<%# Bind("WorkingTimeFrom") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="إلى">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteerWorkingEnd" runat="server" Text='<%# Bind("WorkingTimeTo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="إلغاء">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBtnActivityDayDeleteOnDiv" runat="server" Height="14px" ImageUrl="~/Images/icon_Delete.gif"
                                                                            Width="14px" CommandArgument='<%# Bind("ResultIndex") %>' OnCommand="imgBtnActivityDayDeleteOnDiv_Command" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="DGBody" />
                                                            <HeaderStyle CssClass="DGHeader" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 10px">
                                                        <asp:Button ID="btnFinishActivityVolunteers" runat="server" CssClass="Button" OnClick="btnFinishActivityVolunteers_Click"
                                                            Text="إنهاء" />
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
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="grdActivityDays" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdActivityDays_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="م">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActivtyDaySerial" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="اليوم">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActivtyDay" runat="server" Text='<%#Bind("ActivityDay") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteer" runat="server" Text='<%#Bind("Volunteer") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="رقم ID  المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerId" runat="server" Text='<%#Bind("VolunteerId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="التليفون">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerMobile" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المهام">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerMissions" runat="server" Text='<%#Bind("VolunteerMissions") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="من">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerWorkingStart" runat="server" Text='<%# Bind("WorkingTimeFrom") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلى">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerWorkingEnd" runat="server" Text='<%# Bind("WorkingTimeTo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="تغير">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnEditActivityDay" runat="server" Height="14px" ImageUrl="~/Images/icon_Edit.gif"
                                                            Width="14px" CommandArgument='<%# Bind("ResultIndex") %>' OnCommand="imgBtnEditActivityDay_Command" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلغاء">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnActivityDayDelete" runat="server" Height="14px" ImageUrl="~/Images/icon_Delete.gif"
                                                            Width="14px" CommandArgument='<%# Bind("ResultIndex") %>' OnCommand="imgBtnActivityDayDelete_Command" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="DGBody" />
                                            <HeaderStyle CssClass="DGHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td id="tdEvaluation" align="right" class="TextWhite" colspan="4" style="background-image: url(images/Menu_bg2.gif);
                        color: #FFFFFF;">
                        ثالثاً : بيانات تقييم النشاط
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <div id="divVolunteersEvaluation" style="overflow: hidden">
                            <table>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        1- تفاصيل و تقييم النشاط
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        <asp:LinkButton ID="lnkActivityDepartmentOpinion" runat="server" OnClick="lnkActivityDepartmentOpinion_Click">رأى الإدارة المعنية</asp:LinkButton>
                                    </td>
                                    <td align="right">
                                        <asp:Image ID="imgActivityDepartmentOpinion" runat="server" ImageUrl="~/Images/Evaluation.gif"
                                            Visible="False" Width="20px" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        <asp:LinkButton ID="lnkActivityVolunteerDepartmentOpinion" runat="server" OnClick="lnkActivityVolunteerDepartmentOpinion_Click">رأى إدارة المتطوعين</asp:LinkButton>
                                    </td>
                                    <td align="right">
                                        <asp:Image ID="imgActivityVolunteerDepartmentOpinion" runat="server" ImageUrl="~/Images/Evaluation.gif"
                                            Visible="False" Width="20px" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        المستندات الخاصة بالنشاط
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:FileUpload ID="fuActivityDocument" runat="server" CssClass="MainText" Height="20px" />
                                        <asp:Button ID="btnUploadActivityDocument" runat="server" CssClass="Button" OnClick="btnUploadActivityDocument_Click"
                                            Text="تحميل" UseSubmitBehavior="False" />
                                        <asp:HyperLink ID="hlnkActivityDocument" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
                                        <asp:ImageButton ID="imgBtnRemoveActivityDocument" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                            OnClick="imgBtnRemoveActivityDocument_Click" Visible="False" Width="21px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        التكاليف الفعلية
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityCost" runat="server" CssClass="TextBlack" Height="20px"
                                            Width="200px"></asp:TextBox>
                                        <asp:Image ID="imgActivityCostV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        الإيرادات الفعلية
                                    </td>
                                    <td align="right">
                                        <asp:TextBox ID="txtActivityRevenue" runat="server" CssClass="TextBlack" Height="20px"
                                            Width="200px"></asp:TextBox>
                                        <asp:Image ID="imgActivityRevenueV" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        2- إنصراف و حضور المتطوعين
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        <asp:LinkButton ID="lnkAddDayDetailsReal" runat="server" OnClick="lnkAddDayDetailsReal_Click"
                                            Visible="False">أضف بيانات الحضور</asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="DivActivityResultReal" runat="server" style="background-color: #E2E2E2;
                                            width: 600px;">
                                            <table cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right" colspan="4">
                                                        <asp:Panel ID="pnlDraghandlerReal" runat="server" BackImageUrl="images/Menu_bg2.gif"
                                                            BorderColor="#E2E2E2" BorderWidth="1" Height="23" HorizontalAlign="Left">
                                                            <asp:ImageButton ID="imgDeleteJobPlacesReal" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                                                Width="21px" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="height: 25px">
                                                        <asp:UpdateProgress ID="UpdateProgress22" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgProgress02" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                                                    Width="25px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" style="width: 250px">
                                                        &nbsp;
                                                    </td>
                                                    <td class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        إسم المتطوع :
                                                    </td>
                                                    <td align="right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="drpVolunteerNameReal" runat="server" CssClass="MainText" Height="25px">
                                                                        <asp:ListItem Value="Select">إختار</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                                    <asp:Image ID="imgActivityVolunteerRealV" runat="server" Height="20px" ImageAlign="Middle"
                                                                        ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="MainText">
                                                        اليوم :
                                                    </td>
                                                    <td align="right">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="drpActivityDayReal" runat="server" CssClass="MainText" Height="25px">
                                                                        <asp:ListItem Value="Select">إختار</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                                    <asp:Image ID="imgActivityDayRealV" runat="server" Height="20px" ImageAlign="Middle"
                                                                        ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="MainText" colspan="4">
                                                        الساعات الفعلية لعمل المتطوع
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        الموقف :
                                                    </td>
                                                    <td align="right" width="150px">
                                                        <asp:DropDownList ID="drpAttendanceState" runat="server" CssClass="TextBlack" Height="25px"
                                                            Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpAttendanceState_SelectedIndexChanged">
                                                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        من :&nbsp;
                                                    </td>
                                                    <td align="right" width="150px">
                                                        <asp:TextBox ID="txtWorkTimeFromReal" runat="server" CssClass="TextBlack" Height="20px"
                                                            Width="60px"></asp:TextBox>
                                                        <asp:DropDownList ID="drpAmPmFromReal" runat="server" CssClass="MainText" Height="25px">
                                                            <asp:ListItem Value="am">صباحاً</asp:ListItem>
                                                            <asp:ListItem Value="pm">مساءاً</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                                        <asp:Image ID="imgActivityWorkStartRealV" runat="server" Height="20px" ImageAlign="Middle"
                                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                                    </td>
                                                    <td class="MainText">
                                                        إلى :
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtWorkTimeToReal" runat="server" CssClass="TextBlack" Height="20px"
                                                            Width="60px"></asp:TextBox>
                                                        <asp:DropDownList ID="drpAmPmToReal" runat="server" CssClass="MainText" Height="25px">
                                                            <asp:ListItem Value="am">صباحاً</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="pm">مساءاً</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                                        <asp:Image ID="imgActivityWorkEndRealV" runat="server" Height="20px" ImageAlign="Middle"
                                                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        نوع المهام :
                                                    </td>
                                                    <td align="right" colspan="3">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBoxList ID="chkTypeOfMissionsReal" runat="server" CssClass="MainText" RepeatDirection="Horizontal">
                                                                    </asp:CheckBoxList>
                                                                </td>
                                                                <td>
                                                                    <%-- <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                                    <asp:Image ID="imgActivityVolunteerMissionsRealV" runat="server" Height="20px" ImageAlign="Middle"
                                                        ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        ملاحظات عامة :
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtVolunteerWorkDetailsReal" runat="server" CssClass="TextBlack"
                                                            Height="20px" Width="200px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 10px">
                                                        <asp:Button ID="btnAddActivityDayResultReal" runat="server" CssClass="Button" Text="إضافة"
                                                            OnClick="btnAddActivityDayResultReal_Click" />
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
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:GridView ID="grdActivityDaysRealOnDiv" runat="server" AutoGenerateColumns="False"
                                                            OnRowDataBound="grdActivityDaysRealOnDiv_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="اليوم">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblActivtyDay" runat="server" Text='<%#Bind("ActivityDay") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="المتطوع">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteer" runat="server" Text='<%#Bind("Volunteer") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="المهام">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteerMissions" runat="server" Text='<%#Bind("VolunteerMissions") %>'></asp:Label>
                                                                        <asp:Label ID="lblVolunteerAttendanceState" runat="server" Text='<%#Bind("VolunteerAttendanceState") %>'
                                                                            Visible="false"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="من">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteerWorkingStart" runat="server" Text='<%# Bind("WorkingTimeFrom") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="إلى">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblVolunteerWorkingEnd" runat="server" Text='<%# Bind("WorkingTimeTo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="إلغاء">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBtnActivityDayDeleteOnDiv" runat="server" Height="14px" ImageUrl="~/Images/icon_Delete.gif"
                                                                            Width="14px" CommandArgument='<%# Bind("ResultIndex") %>' OnCommand="imgBtnActivityDayDeleteOnDiv_Command1" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle CssClass="DGBody" />
                                                            <HeaderStyle CssClass="DGHeader" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 10px">
                                                        <asp:Button ID="btnFinishActivityVolunteersReal" runat="server" CssClass="Button"
                                                            Text="إنهاء" OnClick="btnFinishActivityVolunteersReal_Click" />
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
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="grdActivityDaysReal" runat="server" AutoGenerateColumns="False"
                                            OnRowDataBound="grdActivityDaysReal_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="م">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActivtyDayRealSerial" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="اليوم">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActivtyDay" runat="server" Text='<%#Bind("ActivityDay") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="100px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteer" runat="server" Text='<%#Bind("Volunteer") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="رقم ID  المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerId" runat="server" Text='<%#Bind("VolunteerId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المهام">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerMissions" runat="server" Text='<%#Bind("VolunteerMissions") %>'></asp:Label>
                                                        <asp:Label ID="lblVolunteerAttendanceState" runat="server" Text='<%#Bind("VolunteerAttendanceState") %>'
                                                            Visible="false"></asp:Label></ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="من">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerWorkingStart" runat="server" Text='<%# Bind("WorkingTimeFrom") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلى">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerWorkingEnd" runat="server" Text='<%# Bind("WorkingTimeTo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="تغير">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnEditActivityDay" runat="server" Height="14px" ImageUrl="~/Images/icon_Edit.gif"
                                                            Width="14px" CommandArgument='<%# Bind("ResultIndex") %>' OnCommand="imgBtnEditActivityDay_Command2" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلغاء">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgBtnActivityDayDelete" runat="server" Height="14px" ImageUrl="~/Images/icon_Delete.gif"
                                                            Width="14px" CommandArgument='<%# Bind("ResultIndex") %>' OnCommand="imgBtnActivityDayDelete_Command1" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="DGBody" />
                                            <HeaderStyle CssClass="DGHeader" />
                                        </asp:GridView>
                                        <asp:LinkButton ID="lnkDummyActivityResultReal" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="mpeActivityResultReal" runat="server" BackgroundCssClass="modalBackground"
                                            CancelControlID="imgDeleteJobPlacesReal" PopupControlID="DivActivityResultReal"
                                            PopupDragHandleControlID="pnlDraghandlerReal" TargetControlID="lnkDummyActivityResultReal">
                                        </cc1:ModalPopupExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        3- تقييم المتطوعين
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        <div id="divEvaluation" runat="server" style="background-color: #E2E2E2; width: 600px;">
                                            <table cellspacing="0" width="100%">
                                                <tr>
                                                    <td align="right" colspan="4">
                                                        <asp:Panel ID="pnlDragEvaluation" runat="server" BackImageUrl="images/Menu_bg2.gif"
                                                            BorderColor="#E2E2E2" BorderWidth="1" Height="23" HorizontalAlign="Left">
                                                            <asp:ImageButton ID="imgCloseEvaluation" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                                                Width="21px" />
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="height: 25px">
                                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="imgProgress03" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                                                    Width="25px" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        تقييم مهارات المتطوع
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:PlaceHolder ID="phVolunteerSkills" runat="server"></asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="MainText" colspan="4">
                                                        تقييم مهام المتطوع
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" align="center">
                                                        <asp:PlaceHolder ID="phVolunteerMissions" runat="server"></asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:Label ID="lblRecommended" runat="server" Text="يوصى بالإستعانة به"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4">
                                                        <asp:RadioButtonList ID="rdbRecommended" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem>نعم</asp:ListItem>
                                                            <asp:ListItem>لا</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 10px">
                                                        <asp:Button ID="btnFinishEvaluation" runat="server" CssClass="Button" Text="إنهاء"
                                                            OnClick="btnFinishEvaluation_Click" />
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
                                        <asp:GridView ID="grdActivityEvaluation" runat="server" AutoGenerateColumns="False"
                                            OnRowDataBound="grdActivityEvaluation_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="م">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblActivtyEvaluationSerial" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المتطوع">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkVolunteer" runat="server" Text='<%#Bind("Volunteer") %>' CommandArgument='<%#Bind("VolunteerId") %>'
                                                            OnCommand="lnkVolunteer_Command"></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="رقم ID  المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerId" runat="server" Text='<%#Bind("VolunteerId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="VolunteerDays" HeaderText="عدد أيام المشاركة">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="عدد ساعات المشاركة">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerHours" runat="server" Text='<%#Bind("VolunteerHours") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="تقييم الإدارة المعنية">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkActivityDepartmentEvaluation" runat="server" CommandArgument='<%# Bind("VolunteerId") %>'
                                                            OnCommand="lnkActivityDepartmentEvaluation_Command" Text='<%# Bind("ActivityDepartmentEvaluation") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="تقييم إدارة المتطوعين">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkVolunteerDepartmentEvaluation" runat="server" CommandArgument='<%# Bind("VolunteerId") %>'
                                                            OnCommand="lnkVolunteerDepartmentEvaluation_Command" Text='<%# Bind("VolunteerDepartmentEvaluation") %>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="IsRecommended" HeaderText="يوصى بالإستعانة به">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="DGBody" />
                                            <HeaderStyle CssClass="DGHeader" />
                                        </asp:GridView>
                                        <asp:LinkButton ID="lnkDummyEvaluation" runat="server"></asp:LinkButton>
                                        <cc1:ModalPopupExtender ID="mpeEvaluation" runat="server" BackgroundCssClass="modalBackground"
                                            CancelControlID="imgCloseEvaluation" PopupControlID="divEvaluation" PopupDragHandleControlID="pnlDragEvaluation"
                                            TargetControlID="lnkDummyEvaluation">
                                        </cc1:ModalPopupExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        4- ملخص النشاط
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        <asp:Label ID="lblActivitySummary" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4" class="MainText">
                        <asp:Label ID="lblActivityError" runat="server" CssClass="RedError" Text=""></asp:Label>
                        <asp:Label ID="lblActivityResult" runat="server" CssClass="MainText" ForeColor="#33CC33"
                            Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px">
                        <asp:LinkButton ID="lnkDummyFckEditor" runat="server"></asp:LinkButton>
                        <cc1:ModalPopupExtender ID="mpeFckEditor" runat="server" BackgroundCssClass="modalBackground"
                            CancelControlID="imgCloseFckEditor" PopupControlID="divFckEditor" TargetControlID="lnkDummyFckEditor">
                        </cc1:ModalPopupExtender>
                        <div id="divFckEditor" runat="server" style="background-color: #E2E2E2; width: 600px;">
                            <table cellspacing="0" width="100%">
                                <tr>
                                    <td align="right" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4">
                                        <asp:Panel ID="Panel2" runat="server" BackImageUrl="images/Menu_bg2.gif" BorderColor="#E2E2E2"
                                            BorderWidth="1" Height="23" HorizontalAlign="Left">
                                            <asp:ImageButton ID="imgCloseFckEditor" runat="server" Height="23px" ImageUrl="~/Images/Delete.png"
                                                Width="21px" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4">
                                        <FCKeditorV2:FCKeditor ID="fckEditor" runat="server" BasePath="~/fckeditor/">
                                        </FCKeditorV2:FCKeditor>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4" style="padding: 10px">
                                        <asp:Button ID="btnFinishFckEditor" runat="server" CssClass="Button" Text="إنهاء"
                                            OnClick="btnFinishFckEditor_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnAddActivity" runat="server" CssClass="Button" OnClick="btnAddActivity_Click"
                            Text="أدخل بيانات النشاط" Width="100px" UseSubmitBehavior="False" />
                    </td>
                </tr>
            </table>
            </div> </td> </tr> </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadActivityDocument" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
