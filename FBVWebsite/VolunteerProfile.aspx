<%@ Page Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="VolunteerProfile.aspx.cs" Inherits="VolunteerProfile" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 780px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="Server">
    <table class="style1" align="left">
        <tr>
            <td align="center" class="TextBlack" colspan="2" style="height: 20px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="TextBlack" colspan="2">
                &nbsp;<asp:Label ID="lblTitle" runat="server" CssClass="PageTitle"></asp:Label>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                بيانات التعريف:
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                رقم التعريف
            </td>
            <td align="Right">
                <asp:Label ID="lblVolunteerId" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                الأسم الثلاثي&nbsp;
            </td>
            <td align="right">
                <asp:Label ID="lblVolunteerName" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                تاريخ الميلاد&nbsp;
            </td>
            <td align="right" style="vertical-align: middle">
                <asp:Label ID="lblBirthDate" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                النوع
            </td>
            <td align="right" style="vertical-align: middle">
                <asp:Label ID="lblGender" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                نبذة عن المؤهلات الدراسية:
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المدرسة
            </td>
            <td align="right">
                <asp:Label ID="lblSchool" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                الجامعة
            </td>
            <td align="right">
                <asp:Label ID="lblUniversity" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                الكلية
            </td>
            <td align="right">
                <asp:Label ID="lblFaculty" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المؤهل
            </td>
            <td align="right">
                <asp:Label ID="lblEducation" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                الوظيفة و الخبرات :
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                الوظيفة الحالية
            </td>
            <td align="right">
                <asp:Label ID="lblCurrentJob" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المؤسسة
            </td>
            <td align="right">
                <asp:Label ID="lblJobPlace" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                العنوان و المنطقة :
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                العنوان
            </td>
            <td align="right">
                <asp:Label ID="lblAddress" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المحافظة
            </td>
            <td align="right">
                <asp:Label ID="lblCity" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المنطقة
            </td>
            <td align="right">
                <asp:Label ID="lblArea" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                بيانات الإتصال :
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                رقم المحمول
            </td>
            <td align="Right">
                <asp:Label ID="lblMobile" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                رقم المنزل
            </td>
            <td align="Right">
                <asp:Label ID="lblTelephone" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                البريد الإلكتروني
            </td>
            <td align="Right">
                <asp:Label ID="lblEmail" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" colspan="2">
                مجالات التطوع او النشاط الذى يرغب فى المشاركة به
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label ID="lblDesiredFields" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Right" class="DGHeader" width="150px" colspan="2">
                خبرات\مهارات\دورات
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                خبرات سابقة فى العمل الخيرى
            </td>
            <td align="right">
                <asp:Label ID="lblExperience" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                اللغات\الحاسب الألى
            </td>
            <td align="Right">
                <asp:Label ID="lblLangVolunteer" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                دورات
            </td>
            <td align="Right">
                <asp:Label ID="lblSkills" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                كيف علمت عن بنك الطعام
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2" style="padding-right: 20px">
                <asp:Label ID="lblKnow" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" colspan="2">
                اول إتصال للمتطوع بالبنك (خاص بإدارة المتطوعين)
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                التاريخ
            </td>
            <td align="right">
                <asp:Label ID="lblFirstContactDate" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المكان
            </td>
            <td align="right">
                <asp:Label ID="lblFirstContactPlace" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" width="150px" colspan="2">
                إستيفاء الإستمارة
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                التاريخ
            </td>
            <td align="right">
                <asp:Label ID="lblRegisterDate" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                المكان
            </td>
            <td align="right">
                <asp:Label ID="lblRegisterationPlace" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" colspan="2">
                لقاء التعارف (خاص بإدارة المتطوعين)
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                التاريخ
            </td>
            <td align="Right">
                <asp:Label ID="lblMeetingDate" runat="server" CssClass="TextBlack"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                المكان
            </td>
            <td align="Right">
                <asp:Label ID="lblMeetingPlace" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                تم الحضور
            </td>
            <td align="Right">
                <asp:Label ID="lblMeetingDone" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="Left" class="TextBlack" width="150px">
                <asp:Label ID="lblMeetingApologyTitle" runat="server" Text="تم الإعتزار" Visible="False"
                    CssClass="Textromadi"></asp:Label>
            </td>
            <td align="Right">
                <asp:Label ID="lblMeetingApology" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                <asp:Label ID="lblMeetingApologyDateTitle" runat="server" Text="التاريخ" Visible="False"
                    CssClass="Textromadi"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblMeetingApologyDate" runat="server" CssClass="TextBlack"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                <asp:Label ID="lblMeetingApologyPlaceTitle" runat="server" Text="المكان" Visible="False"
                    CssClass="Textromadi"></asp:Label>
            </td>
            <td align="right">
                <asp:Label ID="lblMeetingApologyPlace" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" colspan="2">
                مجالات التطوع أو النشاط المرشح للمشاركة به (خاص بإدارة المتطوعين)
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label ID="lblRecommendedFields" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="DGHeader" colspan="2">
                مهارات (خاص بإدارة المتطوعين)
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Label ID="lblSkillsVolunteer" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                ملاحظات عامة
            </td>
            <td align="right">
                <asp:Label ID="lblGeneralComments" runat="server" CssClass="Textromadi"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                صورة شخصية
            </td>
            <td align="right">
                <asp:HyperLink ID="hlnkPhoto" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                السيرة الذاتية
            </td>
            <td align="right">
                <asp:HyperLink ID="hlnkCv" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                ملفات أخرى
            </td>
            <td align="right">
                <asp:HyperLink ID="hlnkOtherFiles" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" class="TextBlack" width="150px">
                وسيلة إدخال البيانات
            </td>
            <td align="right">
                <asp:Label ID="lblEntryWay" runat="server" CssClass="TextBlack"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="TextBlack" colspan="2">
                <asp:GridView ID="grdVolunteerActivities" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#009933" BorderStyle="None" BorderWidth="1px"
                    CellPadding="1" ForeColor="Black" OnRowDataBound="grdVolunteerActivities_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="م">
                            <ItemTemplate>
                                <asp:Label ID="lblSerial" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="رقم  تعريف النشاط">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkActivityCodeNo" runat="server" Text='<%#Bind("ActivityCodeNo")%>'
                                    CommandArgument='<%#Bind("RActivityId") %>' OnCommand="lnkActivityCodeNo_Command"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مجال التطوع">
                            <ItemTemplate>
                                <asp:Label ID="lblActivityField" runat="server" Text='<%#bind("FieldName") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="تاريخ بدء النشاط">
                            <ItemTemplate>
                                <asp:Label ID="lblActivityStartDate" runat="server" Text='<%#bind("ActivityDateFrom") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إجمالى عدد أيام مشاركته">
                            <ItemTemplate>
                                <asp:Label ID="lblVolunteerDays" runat="server" Text='<%#bind("NDay") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="إجمالى عدد ساعات مشاركته">
                            <ItemTemplate>
                                <asp:Label ID="lblVolunteerHours" runat="server" Text='<%#bind("TotalTime") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="درجة تقييم من الإدارة المعنية">
                            <ItemTemplate>
                                <asp:Label ID="lblActivityDepartmentEvaluation" runat="server" Text ='<%#Bind("EActivityDepartmentEvaluation") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="درجة التقييم من إدارة المتطوعين">
                            <ItemTemplate>
                                <asp:Label ID="lblVolunteerDepartmentEvaluation" runat="server" Text ='<%#Bind("EVolunteerDepartmentEvaluation") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="التوصية بالإستعانة">
                            <ItemTemplate>
                                <asp:Label ID="lblRecommended" runat="server" Text ='<%#bind("EVolunteerIsRecommended") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ملاحظات">
                            <ItemTemplate>
                                <asp:Label ID="lblComments" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="DGBody" />
                    <HeaderStyle CssClass="DGHeader" />
                    <FooterStyle BackColor="#CCCC99" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right" class="TextBlack" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" class="TextBlack" colspan="2">
                <asp:HyperLink ID="hlnkBack" runat="server" NavigateUrl="~/VolunteersSearchResult.aspx">الصفحة السابقة</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center" class="TextBlack" colspan="2">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
