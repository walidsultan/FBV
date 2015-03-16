<%@ Page Title="نك الطعام المصرى - بحث بيانات المتطوعين" Language="C#" MasterPageFile="~/FBVMasterPage.master"
    AutoEventWireup="true" CodeFile="VolunteersSearch.aspx.cs" Inherits="VolunteersSearch" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
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
            <asp:ScriptReference Path="Scripts\PagesBehaviour\BehaviourSearchVolunteer.js" />
        </Scripts>
        <Services>
        <asp:ServiceReference Path="VolunteerNames.asmx" />
        </Services>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1">
                <tr>
                    <td align="center" colspan="4">
                        <asp:Label ID="lblTitle" runat="server" CssClass="PageTitle" Text="قاعدة بيانات المتطوعين – صفحة البحث"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" colspan="4">
                        بيانات المتطوع
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        رقم التعريف
                    </td>
                    <td align="right" colspan="3">
                        من :
                        <asp:TextBox ID="txtVolunteerManIdStart" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; إلى :
                        <asp:TextBox ID="txtVolunteerManIdEnd" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        الأسم الثلاثي&nbsp;
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txtVolunteerName" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="aceVolunteerName" runat="server" 
                            TargetControlID="txtVolunteerName"
                               ServicePath="VolunteerNames.asmx" 
                ServiceMethod="GetVolunteerNamesList"
                MinimumPrefixLength="3" 
                CompletionInterval="1000"
                EnableCaching="true"
                CompletionSetCount="10"
                            >
                        </cc1:AutoCompleteExtender>
                    </td>
                    <td align="left" class="TextBlack" width="150px">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        تاريخ الميلاد
                    </td>
                    <td align="right" colspan="3">
                        &nbsp&nbsp من :
                        <asp:TextBox ID="txtBirthDateFrom" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                        &nbsp&nbsp&nbsp&nbsp إلى :
                        <asp:TextBox ID="txtBirthDateTo" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        المدرسة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpSchool" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        الجامعة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpUniversity" runat="server" AutoPostBack="True" CssClass="TextBlack"
                            Height="25px" OnSelectedIndexChanged="drpUniversity_SelectedIndexChanged" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        الكلية
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpFaculty" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        المؤهل
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpEducation" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        المحافظة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpCity" runat="server" CssClass="TextBlack" AutoPostBack="True"
                            Height="25px" OnSelectedIndexChanged="drpCity_SelectedIndexChanged" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        المنطقة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpArea" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        المؤسسة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpJobPlace" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        كيف علمت عن بنك الطعام
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpKnow" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="4">
                        مجالات التطوع او النشاط الذى يرغب فى المشاركة به
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <asp:CheckBoxList ID="chkDesiredFields" runat="server" CssClass="MainText" RepeatColumns="2">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="4">
                        مجالات التطوع أو النشاط المرشح للمشاركة به (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        <asp:CheckBoxList ID="chkRecommendedFields" runat="server" CssClass="MainText" RepeatColumns="2">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="4">
                        دورات (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="Right" colspan="4">
                        <asp:CheckBoxList ID="chkSkillsVolunteer" runat="server" CssClass="MainText" CellSpacing="5"
                            RepeatDirection="Horizontal" RepeatColumns="4">
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" colspan="4">
                        اول إتصال للمتطوع بالبنك (خاص بإدارة المتطوعين )
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        التاريخ
                    </td>
                    <td align="Right" colspan="3">
                        &nbsp;
                        <asp:TextBox ID="txtFirstContactDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المكان
                    </td>
                    <td align="Right" colspan="3">
                        &nbsp;
                        <asp:DropDownList ID="drpFirstContactPlace" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" width="150px" colspan="4">
                        إستيفاء الإستمارة
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        التاريخ
                    </td>
                    <td align="Right" colspan="3">
                        <asp:TextBox ID="txtRegisterDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المكان
                    </td>
                    <td align="Right" colspan="3">
                        &nbsp;
                        <asp:DropDownList ID="drpRegisterationPlace" runat="server" CssClass="TextBlack"
                            Height="25px" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="Right" class="DGHeader" colspan="4">
                        لقاء تعارف (خاص بإدارة المتطوعين)
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        التاريخ
                    </td>
                    <td align="Right" colspan="3">
                        &nbsp;
                        <asp:TextBox ID="txtMeetingDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        المكان
                    </td>
                    <td align="Right" colspan="3">
                        &nbsp;
                        <asp:DropDownList ID="drpMeetingPlace" runat="server" CssClass="TextBlack" Height="25px"
                            Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="DGHeader" colspan="4">
                        المتطوعين النشطين ( المشاركين بالأنشطة )
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        تاريخ النشاط
                    </td>
                    <td align="right" colspan="3">
                        من :
                        <asp:TextBox ID="txtAvActivityStartDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; إلى :
                        <asp:TextBox ID="txtAvActivityEndDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        رقم تعريف النشاط
                    </td>
                    <td align="right" colspan="3">
                        من :
                        <asp:TextBox ID="txtAvActivityCodeNoStart" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; إلى :
                        <asp:TextBox ID="txtAvActivityCodeNoEnd" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        مجال التطوع
                    </td>
                    <td align="right" colspan="3">
                           <asp:CheckBoxList ID="chkAvFields" runat="server" CssClass="MainText" RepeatColumns="2">
                        </asp:CheckBoxList>
                    </td>
                    </tr>
                 
                  <tr>
                    <td align="right" class="DGHeader" colspan="4">
                        المتطوعين الجدد ( المشاركين بالأنشطة لأول مرة )
                    </td>
                </tr>
                <tr>
                    <td align="Left" class="TextBlack" width="150px">
                        تاريخ النشاط
                    </td>
                    <td align="right" colspan="3">
                        من :
                        <asp:TextBox ID="txtNvActivityStartDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; إلى :
                        <asp:TextBox ID="txtNvActivityEndDate" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        رقم تعريف النشاط
                    </td>
                    <td align="right" colspan="3">
                        من :
                        <asp:TextBox ID="txtNvActivityCodeNoStart" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp; إلى :
                        <asp:TextBox ID="txtNvActivityCodeNoEnd" runat="server" CssClass="TextBlack" Height="20px"
                            Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        مجال التطوع
                    </td>
                    <td align="right" colspan="3">
                           <asp:CheckBoxList ID="chkNvFields" runat="server" CssClass="MainText" RepeatColumns="2">
                        </asp:CheckBoxList>
                    </td>
                    </tr>
                 
                  <tr>
                    <td align="right" class="DGHeader" colspan="4">
                       مجالات التطوع الموصى الإستمرار بها
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        مجال التطوع
                    </td>
                    <td align="right" colspan="3">
                           <asp:CheckBoxList ID="chkRecommendedVolunteerFields" runat="server" CssClass="MainText" RepeatColumns="2">
                        </asp:CheckBoxList>
                    </td>
                    </tr>
                    <tr>
                        <td align="center" class="MainText" colspan="4">
                            <asp:Button ID="btnSearch" runat="server" CssClass="Button" Text="إبحث" OnClick="btnSearch_Click" />
                        </td>
                </tr>
                <tr>
                    <td align="center" class="MainText" colspan="4">
                        <asp:UpdateProgress ID="upAddActivity" runat="server">
                            <ProgressTemplate>
                                <asp:Image ID="imgProgress" runat="server" Height="25px" ImageUrl="~/Images/ajax-loader.gif"
                                    Width="25px" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left" class="TextBlack" width="150px">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left" class="TextBlack" width="150px">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                    <td align="left" class="TextBlack" width="150px">
                        &nbsp;
                    </td>
                    <td align="right">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
