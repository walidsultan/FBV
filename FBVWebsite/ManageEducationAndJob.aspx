<%@ Page Language="C#" MasterPageFile="FBVMasterPage.master" AutoEventWireup="true" CodeFile="ManageEducationAndJob.aspx.cs" Inherits="Manage_Education_Job" Title="بنك الطعام المصرى - إدارة تصنيف  المؤهل و الوظيفة" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
  </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table width="780">
        <tr>
            <td  width="220" align="right">
                <asp:Label ID="Label3" runat="server" Text="المؤهل" CssClass="PageHeader"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblResultEducation" runat="server" CssClass="RedError"></asp:Label>
            </td>
            <td  width="340" align="right">
                
                <asp:Label ID="Label4" runat="server" Text="الجامعة" CssClass="PageHeader"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblResultUniversities" runat="server" CssClass="RedError"></asp:Label></td>
            <td  width="220" align="right">
                <asp:Label ID="Label1" runat="server" Text="المؤسسة" CssClass="PageHeader"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblResultJobPlace" runat="server" CssClass="RedError"></asp:Label></td>
        </tr>
        <tr>
            <td  align="right">
                     <asp:LinkButton ID="LnkAddNewEducation" runat="server" 
                         onclick="LnkAddNewEducation_Click">إضافة مؤهل جديد</asp:LinkButton>
            </td>
            <td align="right">
                     <asp:LinkButton ID="LnkAddNewUniversity" runat="server" 
                         onclick="LnkAddNewUniversity_Click">إضافة جامعة جديدة</asp:LinkButton>
                     </td>
            <td align="right">
                     <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">إضافة 
                     مؤسسة جديدة</asp:LinkButton>
                     </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                <asp:BulletedList ID="bltstEducations" runat="server" DisplayMode="LinkButton" 
                    onclick="bltstEducations_Click">
                </asp:BulletedList>
            </td>
            <td align="right" valign="top">
        
        
        <ContentTemplate>
        <div>
      
        <asp:Label ID="lblErrorUniversities" runat="server"></asp:Label>
        <asp:GridView ID="grdUniversities" runat="server" AutoGenerateColumns="False" 
                Width="280px" BackColor="White" BorderColor="#009933" BorderStyle="None" 
                BorderWidth="1px" CellPadding="1" CellSpacing="0" ForeColor="Black" GridLines= "Both">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="lightyellow" />
            <Columns>
                <asp:TemplateField HeaderText="الجامعة">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkUniveristiesname" runat="server" 
                            Text='<%#Bind("UniversityName") %>' 
                            CommandArgument ='<%#Bind("UniversityID")%>' 
                            oncommand="lnkUniveristiesname_Click"></asp:LinkButton>
                    </ItemTemplate>
                    <HeaderStyle CssClass="TextWhiteGV" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="تعديل">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="images/icon_Edit.gif"  Width="14" Height="14" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="TextWhiteGV" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="حذف">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="images/icon_Delete.gif" Width="14" Height="14" />
                    </ItemTemplate>
                    <HeaderStyle CssClass="TextWhiteGV" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                </asp:TemplateField>
            </Columns>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#009933"  />
            <AlternatingRowStyle BackColor="#cdea78" />
        </asp:GridView>
        
            <div id="DivFaculty" runat="server" visible="false">
                <table cellpadding="0" cellspacing="0" class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" width="340">
                            <asp:Label ID="Label6" runat="server" CssClass="PageHeader" Text="الكلية"></asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblResultFaculties" runat="server" CssClass="RedError"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LnkAddNewFaculty" runat="server" 
                                onclick="LnkAddNewFaculty_Click">إضافة كلية جديدة</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:BulletedList ID="bltstFaculties" runat="server" DisplayMode="LinkButton">
                            </asp:BulletedList>
                        </td>
                    </tr>
                </table>
            </div>
        
         </div>
         </ContentTemplate>
    
   
            </td>
            <td align="right" valign="top">
                <asp:BulletedList ID="bltstJobPlaces" runat="server" DisplayMode="LinkButton" 
                    onclick="bltstJobPlaces_Click">
                </asp:BulletedList></td>
        </tr>
        <tr>
            
            <td>
                &nbsp;</td>
                <td align="right" valign="top">
                    &nbsp;</td>
                <td>
                <cc1:ModalPopupExtender ID="mpeJobPlaces" runat="server" 
                    TargetControlID="lnkDummyJobPlace" PopupControlID ="DivJobPlaces" 
                    CancelControlID = "imgDeleteJobPlaces"  DropShadow="true" BackgroundCssClass="modalBackground" PopupDragHandleControlID="pnlJobPlaces">
                </cc1:ModalPopupExtender>
                <asp:LinkButton ID="lnkDummyJobPlace" runat="server"></asp:LinkButton>
                
                <div id="DivJobPlaces" runat ="server" 
                    style="background-color: #E2E2E2; width: 350px;" >
                    
                    <table width="100%" cellspacing="0">
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Panel HorizontalAlign="Left" Height="23" BorderWidth="1" BorderColor=#E2E2E2 ID="pnlJobPlaces" runat="server" BackImageUrl="images/Menu_bg2.gif">
                                    <asp:ImageButton ID="imgDeleteJobPlaces" runat="server" Height="23px" ImageUrl="~/Images/Delete.png" Width="21px" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="right">
                <asp:Label ID="lblError" runat="server" CssClass="RedError"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="LblMaster" runat="server" Text="المؤسسة :" CssClass="Textromadi"></asp:Label>
                            </td>
                            <td width="260" align="right" >
                                <asp:TextBox ID="txtMasterName" runat="server" CssClass="input"></asp:TextBox>
                                <span style="color:Red">&nbsp;*</span>
                                <asp:Image ID="vimgJobPlaceName" runat="server" Height="23px" 
                                    ImageUrl="Images/exclamation.gif" 
                                    ToolTip="حقل يجب إدخاله" Visible="False" Width="23px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style ="padding:10px">
                                <asp:Button ID="btnAddJobPlace" runat="server" Text="إضافة" 
                                    onclick="btnAdd_Click" CssClass="Button" />
                                <asp:Button ID="btnDeleteJobPlace" runat="server" Text="حذف" 
                                    onclick="btnDelete_Click" Visible="False" CssClass="Button" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

