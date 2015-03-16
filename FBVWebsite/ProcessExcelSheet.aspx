<%@ Page Language="C#" MasterPageFile="~/FBVMasterPage.master" AutoEventWireup="true" CodeFile="ProcessExcelSheet.aspx.cs" Inherits="ProcessExcelSheet" Title="بنك الطعام المصرى - إدخال ملف إكسل" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" Runat="Server">
<script  type ="text/javascript" src ="Scripts/jquery-1.3.1.js"   ></script>
<script type ="text/javascript" src ="Scripts/jquery.blockUI.js" ></script>
    <img  id="displayBox" src="Images/ajax-loader.gif"  style="display:none" />
    <table width="780">
        <tr>
            <td align="left" >
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblError" runat="server" ForeColor="#FF3300" CssClass="RedError"></asp:Label>
                <asp:Label ID="lblResult" runat="server" ForeColor="#33CC33" 
                    CssClass="MainText"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
    <asp:FileUpload ID="fuExcelSheet" runat="server" CssClass="TextWhite" Height="25px" />
            </td>
        </tr>
        <tr>
            <td align="right" >
                <asp:Label ID="lblErrorLog" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" >
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnUpload" runat="server" onclick="btnUpload_Click" 
                    Text="إدخال" CssClass="Button" 
                    UseSubmitBehavior="False" />
            </td>
        </tr>
    </table>
 
</asp:Content>
