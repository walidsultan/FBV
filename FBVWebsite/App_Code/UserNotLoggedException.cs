using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// Summary description for UserNotLoggedException
/// </summary>
public class UserNotLoggedException:Exception 
{
    public UserNotLoggedException(string message):base(message )
    {

    }
}
