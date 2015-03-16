using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class FBVMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // this must be done in Page_Init or the controls
        // will still use “ctl00_xxx“, instead of “MasterPageID_xxx”
        this.ID = "FBV";
    }
}
