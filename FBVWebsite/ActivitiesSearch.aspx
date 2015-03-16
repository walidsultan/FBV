<%@ Page Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true"
    CodeFile="ActivitiesSearch.aspx.cs" Inherits="ActivitiesSearch" Title="بنك الطعام المصرى - بحث النشاط" %>

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
            <asp:ScriptReference Path="Scripts\PagesBehaviour\BehaviourActivitiesSearch.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style1" align="left">
                <tr>
                    <td align="right" class="DGHeader" colspan="4">
                        أولا : بيانات طلب الاستعانة
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        رقم تعريف النشاط
                    </td>
                    <td align="right">
                        <asp:TextBox ID="txtActivityCodeNo" runat="server" CssClass="TextBlack"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        إسم الإدارة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpDepartment" runat="server" CssClass="TextBlack"
                            Height="25px" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        مجال التطوع
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpActivityField" runat="server" CssClass="TextBlack"
                            Height="25px"
                            Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        اسم النشاط
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpActivityName" runat="server" CssClass="TextBlack" Height="25px"
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
                    <td align="left" class="MainText">
                        المحافظة
                    </td>
                    <td align="right">
                        <asp:DropDownList ID="drpActivityCity" runat="server" AutoPostBack="True" CssClass="TextBlack"
                            Height="25px" OnSelectedIndexChanged="drpActivityCity_SelectedIndexChanged" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
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
                        نوع المهام
                    </td>
                    <td align="right" colspan="3">
                        <asp:CheckBoxList ID="chkTypeOfMissions" runat="server" CssClass="TextBlack" 
                            RepeatDirection="Horizontal" RepeatColumns="4">
                        </asp:CheckBoxList>
                    </td>
                </tr>
               
            
                <tr>
                    <td align="left" class="MainText">
                        تاريخ ورود الطلب من الإدارة
                    </td>
                    <td colspan="3" align="right" class="MainText">
                        &nbsp&nbsp من :
                        <asp:TextBox ID="txtRequestDateFrom" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                        &nbsp&nbsp&nbsp&nbsp إلى :
                        <asp:TextBox ID="txtRequestDateTo" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        الفترة الفعلية للنشاط
                    </td>
                    <td align="right" colspan="3" class="MainText">
                        &nbsp&nbsp من :
                        <asp:TextBox ID="txtActivityFrom" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                        &nbsp&nbsp&nbsp&nbsp إلى :
                        <asp:TextBox ID="txtActivityTo" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                    </td>
                </tr>
             
                <tr>
                    <td align="left" class="MainText">
                        نتيجة النشاط ( عدد ايام )</td>
                    <td align="right" class="MainText" colspan="3">
                      &nbsp&nbsp من :
                        <asp:TextBox ID="txtActivityDaysCountFrom" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                        &nbsp&nbsp&nbsp&nbsp إلى :
                        <asp:TextBox ID="txtActivityDaysCountTo" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox></td>
                </tr>
                   <tr>
                    <td align="left" class="MainText">
                        نتيجة النشاط ( عدد المتطوعين )</td>
                    <td align="right" class="MainText" colspan="3">
                      &nbsp&nbsp من :
                        <asp:TextBox ID="txtVolunteersCountFrom" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                        &nbsp&nbsp&nbsp&nbsp إلى :
                        <asp:TextBox ID="txtVolunteersCountTo" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        نتيجة النشاط ( عدد ساعات )</td>
                    <td align="right" class="MainText" colspan="3">
                      &nbsp&nbsp من :
                        <asp:TextBox ID="txtActivityHoursFrom" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox>
                        &nbsp&nbsp&nbsp&nbsp إلى :
                        <asp:TextBox ID="txtActivityHoursTo" runat="server" Width="100px" CssClass="TextBlack"
                            Height="20px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" class="MainText">
                        ممثل ادارة المتطوعين</td>
                    <td align="right" class="MainText" colspan="3">
                        <asp:DropDownList ID="drpVolunteerDepartmentRep" runat="server" 
                            CssClass="TextBlack" Height="25px" Width="200px">
                            <asp:ListItem Value="Select">إختار</asp:ListItem>
                        </asp:DropDownList>
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
                    <td align="left" class="MainText" colspan="4">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
