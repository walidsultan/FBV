<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Managefaculties.aspx.cs" Inherits="Managefaculties" %>

<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div>
        <asp:LinkButton ID="lnkAddUnivresities" runat="server" 
                onclick="lnkAddUnivresities_Click">Add new university</asp:LinkButton>
      
        <asp:Label ID="lblErrorUniversities" runat="server"></asp:Label>
        <asp:Label ID="lblResultUniversities" runat="server"></asp:Label>
        <asp:GridView ID="grdUniversities" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="University name">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkUniveristiesname" runat="server" 
                            Text='<%#Bind("UniversityName") %>' 
                            CommandArgument ='<%#Bind("UniversityID") %>' 
                            oncommand="lnkUniveristiesname_Command"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtnDelete" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
           <cc1:ModalPopupExtender ID="mpeUniversities" runat="server" 
                 PopupControlID="divUniversities" 
                TargetControlID="lnkDummyUniversity">
            </cc1:ModalPopupExtender>
            <asp:LinkButton ID="lnkDummyUniversity" runat="server"></asp:LinkButton>
            
        <div runat ="server" id = "divUniversities" style="background-color: #00FF00">
         
            <table class="style1">
                <tr>
                    <td>
                        university name:</td>
                    <td>
                        <asp:TextBox ID="txtUniversityname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnAddUniversity" runat="server" Text="Add" />
                    </td>
                </tr>
            </table>
    </div>
    
    
            <asp:GridView ID="grdFaculties" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="FacultyName" HeaderText="Faculty name" />
                    <asp:TemplateField HeaderText="Edit"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Delete"></asp:TemplateField>
                </Columns>
            </asp:GridView>
         </div>
         </ContentTemplate>
        </asp:UpdatePanel>
    
   
    </form>
</body>
</html>
