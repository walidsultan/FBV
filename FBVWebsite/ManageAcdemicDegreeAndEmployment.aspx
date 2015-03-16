<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManageAcdemicDegreeAndEmployment.aspx.cs" Inherits="ManageAcdemicDegreeAndEmployment" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
  <LINK href="FBstyle.css" type="text/css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
  
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 13px;
        }
    </style>
  
</head>
<body>
    <form id="form1" runat="server">
   
    
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
    <table width="620px">
        <tr>
            <td>
                <asp:LinkButton ID="lnkBtnAddUniversity" runat="server" 
                    onclick="lnkBtnAddUniversity_Click">Add University</asp:LinkButton>
                <asp:Label ID="lblResultUniversity" runat="server" ForeColor="#00CC00"></asp:Label>
                <asp:Label ID="lblErrorUniversity" runat="server" ForeColor="#FF3300"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:BulletedList ID="blUniversities" runat="server" DisplayMode="LinkButton" 
                    onclick="blUniversities_Click">
                </asp:BulletedList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <cc1:ModalPopupExtender ID="mpeUniversities" runat="server" 
                    TargetControlID="lnkDummyUniversity" PopupControlID ="DivUniversities" 
                    CancelControlID = "imgDeleteUniversity" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:LinkButton ID="lnkDummyUniversity" runat="server"></asp:LinkButton>
            
                <div id="DivUniversities" runat ="server" 
                    style="background-color: #0033CC; width: 400px;" >
                    
                    <table class="style1">
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="right">
                                <asp:ImageButton ID="imgDeleteUniversity" runat="server" Height="25px" 
                                    ImageUrl="~/Images/Delete.jpg" 
                                    Width="25px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style2">
                                <asp:Label ID="Label1" runat="server" Text="University name : "></asp:Label>
                            </td>
                            <td class="style2" width="250">
                                <asp:TextBox ID="txtUniversityName" runat="server"></asp:TextBox>
                                <span style="color:Red">&nbsp;*</span>
                                <asp:Image ID="vimgUniveristyName" runat="server" Height="20px" 
                                    ImageUrl="~/Images/450px-Exclamation_mark.png" 
                                    ToolTip="Enter valid university name" Visible="False" Width="25px" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style ="padding:10px">
                                <asp:Button ID="btnAddUniversity" runat="server" Text="Add" 
                                    onclick="btnAdd_Click" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                    onclick="btnDelete_Click" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
   
    </form>
</body>
</html>
