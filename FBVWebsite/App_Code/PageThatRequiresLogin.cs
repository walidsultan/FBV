using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FBV.DataMapping;
/// <summary>
/// Summary description for PageThatRequiresLogin
/// </summary>
public abstract class PageThatRequiresLogin:System.Web.UI.Page 
{
    public User CurrentUser
    {
        get
        {
            return (User)Session["CurrentUser"];
        }
        set
        {
            Session["CurrentUser"] = value;
        }
    }

    public PageThatRequiresLogin()
    {
        this.Load += new EventHandler(PageThatRequiresLogin_Load);
         this.Error += new EventHandler(PageThatRequiresLogin_Error);
    }
   
    private void PageThatRequiresLogin_Error(object sender, EventArgs e)
    {
        Exception lastException = Server.GetLastError();

        if (lastException is UserNotLoggedException )
        {
            Server.ClearError();
            Response.Redirect("Index.aspx");
        }
        else
        {
            Server.ClearError();
            Response.Redirect("Error.aspx?Error=" + lastException.Message.Replace("<", "").Replace(">", ""));
        }
    }

    private void PageThatRequiresLogin_Load(object sender, EventArgs e)
    {
        try
        {
            if (!CheckPermission())
            {
                throw new UserNotLoggedException("Login failed for current user");
            }
        }
        catch 
        {
            throw new UserNotLoggedException("User not authorised to view this page.");
        }
    }  

    public abstract bool CheckPermission();
 
}
