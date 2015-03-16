<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index"  Title ="بنك الطعام المصرى"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <LINK href="FBstyle.css" type="text/css" rel="stylesheet" />
    <link rel="shortcut icon" href="Images/favicon.ico" />
</head>
<body leftMargin="0" background="images/Back.gif" topMargin="0">
<form id="form1" runat="server">
<TABLE id="Table1" dir="rtl" width="780" align="center" bgColor="#ffffff" border="0">
<TR>
	<TD align="center">
	<!--begin of header-->
	
	<TABLE dir="rtl" cellPadding="0" width="778" align="center" border="0">
	<TBODY>
		<TR>
			<TD><MAP name="FPMap7"><AREA shape="RECT" coords="0,10,12,30" href="http://www.egyptianfoodbank.com/default.asp"><AREA shape="RECT" coords="0,81,13,99" href="http://egyptianfoodbank.com/subject_gr.asp?lang=ar&amp;parent_id=4&amp;folder_id=0&amp;sub_id=6"><AREA shape="RECT" coords="0,35,13,56" href="http://www.egyptianfoodbank.com/subject_en.asp?sub_id=11&amp;parent_id=2&amp;lang=ar"></MAP><IMG src="images/bar_up1.gif" useMap="#FPMap7" border="0"></TD>
		</TR>
		<TR>
			<TD>
			
<STYLE type="text/css">
#dropmenudiv 
{ 
BORDER-RIGHT: green 2px solid; 
BORDER-TOP: green 2px solid; 
Z-INDEX: 23; 
FONT: 14px/18px arial; 
BORDER-LEFT: green 2px solid; 
BORDER-BOTTOM: green 0px solid; 
POSITION: absolute 
}

#dropmenudiv A 
{ 
PADDING-RIGHT: 0px; 
DISPLAY: block; 
PADDING-LEFT: 0px; 
PADDING-BOTTOM: 3px; 
WIDTH: 100%; 
TEXT-INDENT: 2px; 
PADDING-TOP: 3px; 
BORDER-BOTTOM: green 2px solid; 
TEXT-ALIGN: center; 
TEXT-DECORATION: none 
}

#dropmenudiv A:hover 
{ 
BACKGROUND-COLOR: #cdea78 
}

    .style1
    {
        width: 100%;
    }

</STYLE>
	</TD>
</TR>
</TBODY></TABLE>

<!--End of Header -->
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" height="400" cellSpacing="0" cellPadding="0" width="780" background="images\slide01.gif"
							border="0">
							<TR>
								<TD vAlign="top" align="center" height="50"> <div>

                                    <table class="style1">
                                        <tr>
                                            <td align="left" class="MainText">
                                                &nbsp;</td>
                                            <td align="right" height="150px">
                                                &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="MainText" colspan="2">
                                                        <asp:Label ID="lblResult" runat="server" CssClass="MainText"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="MainText">
                                                        اسم المستخدم:</td>
                                            <td align="right" width="450px">
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="MainText">admin</asp:TextBox>
                                        <asp:Image ID="imgUserName" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" class="MainText">
                                                كلمة السر:</td>
                                            <td align="right">
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="MainText" 
                                                    TextMode="Password"></asp:TextBox>
                                        <asp:Image ID="imgPassword" runat="server" Height="20px" ImageAlign="Middle"
                                            ImageUrl="~/Images/exclamation.gif" Width="20px" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button ID="btnLogin" runat="server" CssClass="Button" 
                                                    onclick="btnLogin_Click" Text="تسجيل الدخول" Width="100px" />
                                            </td>
                                        </tr>
                                    </table>

    </div></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
					<TABLE width=780 align=center border=0>
  <TBODY>
  <TR>
    <TD align=middle colSpan=7><IMG src="images/divider.gif"></TD></TR>
  <TR>
    <TD align=middle colSpan=7><FONT size=2>بنك الطعام المصري _ جميع الحقوق 
      محفوظة2>بنك الطعام المصري _ جميع الحقوق 
      محفوظة</FONT></TD></TR></TBODY></TABLE>
					</TD>
				</TR>
			</TABLE>
   
    </form>
</body>
</html>
