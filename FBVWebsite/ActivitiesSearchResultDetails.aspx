<%@ Page Title="" Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="ActivitiesSearchResultDetails.aspx.cs" Inherits="ActivitiesSearchResultDetails" %>

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
                        <asp:Label ID="lblTitle" runat="server" CssClass="PageTitle" Text="قاعدة بيانات الأنشطة – صفحة بيانات النشاط"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td id="tdRequest" align="right" class="TextWhite" colspan="4" style="background-image: url(images/Menu_bg2.gif);
                        color: #FFFFFF;">
                        أولاً : بيانات طلب الإستعانة
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align ="right">
                        <div id="divRequest" style="overflow: hidden">
                            <table>
                           
                                <tr>
                                    <td align="left" class="MainText">
                                        رقم تعريف النشاط :
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:Label ID="lblActivityCodeNo" runat="server" CssClass="TextBlack"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        الإدارات :
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:GridView ID="grdDepartments" runat="server" AutoGenerateColumns="False" 
                                            Width="400px">
                                            <Columns>
                                                <asp:BoundField DataField="Department" HeaderText="إسم الإدارة">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DepartmentResponsibleUser" HeaderText="ممثل الإدارة">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="DGBody" />
                                            <HeaderStyle CssClass="DGHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        مجال التطوع : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityField" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        اسم النشاط : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityName" runat="server" CssClass="TextBlack"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        تفاصيل النشاط : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityDetails" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        المهام المطلوبة من المتطوع :
                                    </td>
                                    <td align="right" colspan="3">
                                        <table>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblVolunteerMissions" runat="server" CssClass="TextBlack"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        الفترة المقررة للنشاط : 
                                    </td>
                                    <td align="right" colspan="3">
                                        &nbsp&nbsp من :
                                        <asp:Label ID="lblActivityDateFrom" runat="server" AutoPostBack="True" CssClass="TextBlack"
                                            OnTextChanged="lblActivityDateFrom_TextChanged"></asp:Label>
                                        &nbsp&nbsp&nbsp&nbsp إلى :
                                        <asp:Label ID="lblActivityDateTo" runat="server" AutoPostBack="True" CssClass="TextBlack"
                                            OnTextChanged="lblActivityDateTo_TextChanged"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        المكان :
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityPlace" runat="server" CssClass="TextBlack">
                                        </asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        عدد المتطوعين المطلوبين : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityRequiredVolunteers" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        تاريخ إستلام الطلب بالإدارة : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityRequestDate" runat="server" CssClass="TextBlack"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        ملاحظات : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityComments" runat="server" CssClass="TextBlack" TextMode="MultiLine"></asp:Label>
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
                    <td colspan="4">
                        <div id="divVolunteers" style="overflow: hidden">
                            <table>
                                <tr>
                                    <td align="left" class="MainText">
                                        متطلبات النشاط : 
                                    </td>
                                    <td align="right" width="600px">
                                        <asp:Label ID="lblActivityRequirements" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        ممثل ادارة المتطوعين : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblVolunteerDepartmentResponsibleUser" runat="server" CssClass="TextBlack">
                                        </asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
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
                    <td colspan="4">
                        <div id="divVolunteersEvaluation" style="overflow: hidden">
                            <table>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        1- تفاصيل و تقييم النشاط
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        رأى الإدارة المعنية : 
                                    </td>
                                    <td align="right" width="600px">
                                        <asp:Label ID="lblActivityDepartmentOpinion" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        رأى إدارة المتطوعين : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityVolunteerDepartmentOpinion" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        المستندات الخاصة بالنشاط : 
                                    </td>
                                    <td align="right" colspan="3">
                                        <asp:HyperLink ID="hlnkActivityDocument" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="MainText">
                                        التكاليف الفعلية : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityCost" runat="server" CssClass="TextBlack"></asp:Label>
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
                                        الإيرادات الفعلية : 
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblActivityRevenue" runat="server" CssClass="TextBlack"></asp:Label>
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
                                    <td align="right" class="MainText" colspan="4" >
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
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteer" runat="server" Text='<%#Bind("Volunteer") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="رقم ID  المتطوع">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerId" runat="server" Text='<%#Bind("VolunteerId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="المهام">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerMissions" runat="server" Text='<%#Bind("VolunteerMissions") %>'></asp:Label>
                                                        <asp:Label ID="lblVolunteerAttendanceState" runat="server" Text='<%#Bind("VolunteerAttendanceState") %>'
                                                            Visible="false"></asp:Label></ItemTemplate>
                                                    <ControlStyle Width="200px" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="من">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerWorkingStart" runat="server" Text='<%# Bind("WorkingTimeFrom") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="إلى">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblVolunteerWorkingEnd" runat="server" Text='<%# Bind("WorkingTimeTo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="DGBody" />
                                            <HeaderStyle CssClass="DGHeader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
                                        3- تقييم المتطوعين
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="MainText" colspan="4">
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
                                                        <asp:LinkButton ID="lnkActivityDepartmentEvaluation" runat="server"  Text='<%# Bind("ActivityDepartmentEvaluation") %>'  CommandArgument='<%# Bind("VolunteerId") %>' style="cursor:text;text-decoration:none" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="تقييم إدارة المتطوعين">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkVolunteerDepartmentEvaluation" runat="server" Text='<%# Bind("VolunteerDepartmentEvaluation") %>' CommandArgument='<%# Bind("VolunteerId") %>' style="cursor:text;text-decoration:none"></asp:LinkButton>
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
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                         <asp:HyperLink ID="hlnkBack" runat="server" NavigateUrl="~/ActivitiesSearchResult.aspx">الصفحة السابقة</asp:HyperLink>
         
                    </td>
                </tr>
            </table>
        </ContentTemplate>

    </asp:UpdatePanel>
</asp:Content>
