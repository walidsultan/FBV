using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using FBV.DataMapping;
using FBV.DataAccessLayer;
public partial class Index : System.Web.UI.Page
{
    UsersManager _AssociatedUsersManager =new UsersManager();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lblResult.Text = string.Empty;
        if (ValidatePage())
        {
            try
            {
                User loggingUser = _AssociatedUsersManager.GetUserByUserName(txtUserName.Text);
                if (loggingUser == null)
                {
                    lblResult.Text = "لقد أدخلت كلمة مرور خاطئة. فضلاً تحقق من كلمة المرور وعاود المحاولة مرة أخرى.";
                    return;
                }

                if (txtPassword.Text == loggingUser.UserPassword)
                {
                    Session["CurrentUser"] = loggingUser;
                    Response.Redirect("AddActivity.aspx");
                }
                else
                {
                    lblResult.Text = "لقد أدخلت كلمة مرور خاطئة. فضلاً تحقق من كلمة المرور وعاود المحاولة مرة أخرى.";
                }

            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

        }
    }

    private bool ValidatePage()
    {
        bool valid = true;
        imgPassword.Visible = false;
        imgUserName.Visible = false;
        if (!Validation.ValidateRequiredTextField(txtUserName.Text))
        {
            imgUserName.ToolTip = "لا يمكنك تسجيل الدخول بدون إسم مستخدم.";
            imgUserName.Visible = true;
            valid = false;
        }

        if (!Validation.ValidateRequiredTextField(txtPassword.Text))
        {
            imgPassword.ToolTip = "لا يمكنك تسجيل الدخول بدون كلمة سر.";
            imgPassword.Visible = true;
            valid = false;
        }
        return valid;
    }
}
