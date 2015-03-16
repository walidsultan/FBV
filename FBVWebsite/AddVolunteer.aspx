<%@ Page Title="" Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="AddVolunteer.aspx.cs" Inherits="AddVolunteer" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
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
            <asp:ScriptReference Path="Scripts\PagesBehaviour\BehaviourAddVolunteer.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1" align="left">
                <tr>
                    <td align="center" class="TextBlack" colspan="2" style="height: 20px">
                        <asp:UpdateProgress ID="upAddActivity" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="imgProgress" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                    Width="25px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="TextBlack" colspan="2">
                        &nbsp;<asp:Label ID="lblTitle" runat="server" CssClass="PageTitle"></asp:Label>
&nbsp;</td>
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
                        <asp:TextBox ID="txtVolunteerId" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                        <asp:Image ID="imgVolunteerManIdV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        الأسم الثلاثي&nbsp;
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtVolunteerName" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                        <asp:Image ID="imgVolunteerNameV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        تاريخ الميلاد&nbsp;
                    </td>
                    <td align="Right" style="vertical-align: middle">
                        <asp:TextBox ID="txtBirthDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerBirthDateV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        النوع
                    </td>
                    <td align="right" style="vertical-align: middle">
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rdbGender" runat="server" CssClass="MainText" RepeatDirection="Horizontal">
                                        <asp:ListItem>ذكر</asp:ListItem>
                                        <asp:ListItem>أنثى</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerGenderV" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" width="150px" colspan="2">
                        نبذة عن المؤهلات الدراسية:
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المدرسة
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpSchool" runat="server" CssClass="TextBlack" 
                            Height="25px" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        الجامعة
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpUniversity" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px" AutoPostBack="True" OnSelectedIndexChanged="drpUniversity_SelectedIndexChanged">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerUniversityV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        الكلية
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpFaculty" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerFacultyV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المؤهل
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpEducation" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerEducationV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" width="150px" colspan="2">
                        الوظيفة و الخبرات :
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        الوظيفة الحالية
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtCurrentJob" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المؤسسة
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpJobPlace" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerJobPlaceV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" width="150px" colspan="2">
                        العنوان و المنطقة :
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        العنوان
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBlack" Height="20px" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المحافظة
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpCity" runat="server" CssClass="TextBlack" AutoPostBack="True"
                            Height="25px" OnSelectedIndexChanged="drpCity_SelectedIndexChanged" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerCityV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المنطقة
                    </td>
                    <td align="Right">
                        <asp:DropDownList ID="drpArea" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerAreaV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
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
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="TextBlack" Height="20px" Width="200px"></asp:TextBox>
                        <asp:Image ID="imgVolunteerMobileV" runat="server" Height="20px" 
                            ImageAlign="Middle" ImageUrl="~/Images/exclamation.gif" Visible="false" 
                            Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        رقم المنزل
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtTelephone" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <asp:Image ID="imgVolunteerPhoneV" runat="server" Height="20px" 
                            ImageAlign="Middle" ImageUrl="~/Images/exclamation.gif" Visible="false" 
                            Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        البريد الإلكتروني
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBlack" Height="20px" Width="200px"></asp:TextBox>
                        <asp:Image ID="imgVolunteerEmailV" runat="server" Height="20px" 
                            ImageAlign="Middle" ImageUrl="~/Images/exclamation.gif" Visible="false" 
                            Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="2">
                        مجالات التطوع او النشاط الذى يرغب فى المشاركة به
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkDesiredFields" runat="server" CssClass="MainText" 
                                        RepeatColumns="2">
                                    </asp:CheckBoxList>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerActivityFieldsV" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
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
                        <asp:TextBox ID="txtExperience" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        اللغات\الحاسب الألى
                    </td>
                    <td align="Right">
                        <asp:CheckBoxList ID="chkLangVolunteer" runat="server" CssClass="MainText" CellPadding="5"
                            RepeatDirection="Horizontal" RepeatColumns="3">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        دورات
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtSkills" runat="server" CssClass="TextBlack" Height="20px" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" width="150px" colspan="2">
                        كيف علمت عن بنك الطعام
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="padding-right: 20px">
                        <asp:DropDownList ID="drpKnow" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerKnowV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" colspan="2">
                        اول إتصال للمتطوع بالبنك (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        التاريخ
                    </td>
                    <td align="Right">
                        &nbsp;
                        <asp:TextBox ID="txtFirstContactDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerFirstContactDateV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المكان
                    </td>
                    <td align="Right">
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="drpFirstContactPlace" CssClass="TextBlack" runat="server" Height="25px"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerFirstContactPlaceV" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" width="150px" colspan="2">
                        إستيفاء الإستمارة
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        التاريخ
                    </td>
                    <td align="Right">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtRegisterDate" runat="server" CssClass="TextBlack" Height="20px"
                                        Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerRegisterDate" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المكان
                    </td>
                    <td align="Right">
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="drpRegisterationPlace" CssClass="TextBlack" runat="server"
                                        Height="25px" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerRegisterationPlace" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" colspan="2">
                        لقاء التعارف (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        التاريخ
                    </td>
                    <td align="Right">
                        &nbsp;
                        <asp:TextBox ID="txtMeetingDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                        <asp:Image ID="imgVolunteerMeetingDateV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المكان
                    </td>
                    <td align="Right">
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="drpMeetingPlace" CssClass="TextBlack" runat="server" Height="25px"
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerMeetingPlaceV" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        تم الحضور
                    </td>
                    <td align="Right">
                        <asp:RadioButtonList ID="rdbMeetingDone" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="True" CssClass="MainText" OnSelectedIndexChanged="rdbMeetingDone_SelectedIndexChanged">
                            <asp:ListItem>نعم</asp:ListItem>
                            <asp:ListItem>لا</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        <asp:Label ID="lblMeetingApology" runat="server" Text="تم الإعتزار" Visible="False"></asp:Label>
                    </td>
                    <td align="Right">
                        <asp:RadioButtonList ID="rdbMeetingApology" runat="server" RepeatDirection="Horizontal"
                            AutoPostBack="True" CssClass="MainText"
                            Visible="False">
                            <asp:ListItem>نعم</asp:ListItem>
                            <asp:ListItem>لا</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        <asp:Label ID="lblMeetingApologyDate" runat="server" Text="التاريخ" Visible="False"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txtMeetingApologyDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px" Visible="False"></asp:TextBox>
                        <asp:Image ID="imgVolunteerMeetingApologyDateV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        <asp:Label ID="lblMeetingApologyPlace" runat="server" Text="المكان" Visible="False"></asp:Label>
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpMeetingApologyPlace" CssClass="TextBlack" runat="server"
                            Height="25px" Width="200px" Visible="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="2">
                        مجالات التطوع أو النشاط المرشح للمشاركة به (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="2">
                        <table>
                            <tr>
                                <td>
                                    <asp:CheckBoxList ID="chkRecommendedFields" runat="server" CssClass="MainText" 
                                        RepeatColumns="2">
                                    </asp:CheckBoxList>
                                </td>
                                <td>
                                    <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>--%>
                                    <asp:Image ID="imgVolunteerRecommendedActivityFieldsV" runat="server" Height="20px"
                                        ImageAlign="Middle" ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="2">
                        مهارات (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="Right" colspan="2">
                        <asp:CheckBoxList ID="chkSkillsVolunteer" runat="server" CssClass="MainText" CellSpacing="5"
                            RepeatDirection="Horizontal" RepeatColumns="4">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        ملاحظات عامة
                    </td>
                    <td align="Right">
                        <asp:TextBox ID="txtGeneralComments" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        صورة شخصية
                    </td>
                    <td align="Right">
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="MainText" Height="20px" />
                        <asp:Button ID="btnUploadPhoto" runat="server" Text="تحميل" CssClass="Button" OnClick="btnUploadPhoto_Click"
                            UseSubmitBehavior="False" />
                        <asp:HyperLink ID="hlnkPhoto" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
                        <asp:ImageButton ID="imgBtnRemovePhoto" runat="server" ImageUrl="~/Images/Delete.png"
                            Visible="False" Height="23px" OnClick="imgBtnRemovePhoto_Click" Width="21px" />
                        <%-- <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                        <asp:Image ID="imgVolunteerPhotoV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                   --%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        السيرة الذاتية
                    </td>
                    <td align="Right">
                        <asp:FileUpload ID="fuCv" runat="server" CssClass="MainText" Height="20px" />
                        <asp:Button ID="btnUploadCv" runat="server" Text="تحميل" CssClass="Button" OnClick="btnUploadCv_Click"
                            UseSubmitBehavior="False" />
                        <asp:HyperLink ID="hlnkCv" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
                        <asp:ImageButton ID="imgBtnRemoveCv" runat="server" ImageUrl="~/Images/Delete.png"
                            Visible="False" Height="23px" OnClick="imgBtnRemoveCv_Click" Width="21px" />
                        <%-- <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                        <asp:Image ID="imgVolunteerCvV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                  --%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        ملفات أخرى
                    </td>
                    <td align="Right">
                        <asp:FileUpload ID="fuOtherFiles" runat="server" CssClass="MainText" Height="20px" />
                        <asp:Button ID="btnUploadOtherFiles" runat="server" Text="تحميل" CssClass="Button"
                            OnClick="btnUploadOtherFiles_Click" UseSubmitBehavior="False" />
                        <asp:HyperLink ID="hlnkOtherFiles" runat="server" Visible="False">[hlnkCv]</asp:HyperLink>
                        <asp:ImageButton ID="imgBtnOtherFiles" runat="server" ImageUrl="~/Images/Delete.png"
                            Visible="False" Height="23px" OnClick="imgBtnOtherFiles_Click" Width="21px" />
                        <%--<span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                        <asp:Image ID="imgVolunteerOtherFilesV" runat="server" Height="20px" ImageAlign="Middle"
                            ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                 --%>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        وسيلة إدخال البيانات
                    </td>
                    <td align="Right">
                        <table>
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rdbEntryWay" runat="server" CssClass="MainText" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <span style="color: Red; font-size: medium; vertical-align: middle">*</span>
                                    <asp:Image ID="imgVolunteerRegisterViaV" runat="server" Height="20px" ImageAlign="Middle"
                                        ImageUrl="~/Images/exclamation.gif" Visible="false" Width="20px" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="TextBlack" colspan="2">
                        <asp:Label ID="lblVolunteerError" runat="server" CssClass="RedError" Text=""></asp:Label>
                        <asp:Label ID="lblVolunteerResult" runat="server" CssClass="MainText" ForeColor="#33CC33"
                            Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="TextBlack" colspan="2">
                        <asp:Button ID="btnAddVolunteer" runat="server" CssClass="Button" OnClick="btnAddVolunteer_Click"
                            Text="أدخل بيانات المتطوع" UseSubmitBehavior="False" Width="120px" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="TextBlack" colspan="2">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUploadPhoto" />
            <asp:PostBackTrigger ControlID="btnUploadOtherFiles" />
            <asp:PostBackTrigger ControlID="btnUploadCv" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
