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
using FBV.DataAccessLayer;
using FBV.DataMapping;
public partial class ManageAcdemicDegreeAndEmployment : System.Web.UI.Page
{
    FacUniversitiesManager _AssociatedFacUniversitiesManager = new FacUniversitiesManager(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUniversitiesList();
        }
    }

    private void BindUniversitiesList()
    {
        //clear the bulleted list before adding any new entries
        blUniversities.Items.Clear();

        DataTable UniversitiesTable = _AssociatedFacUniversitiesManager.GetAllFacUniversities();
        if (UniversitiesTable.Rows.Count > 0)
        {
            foreach (DataRow dr in UniversitiesTable.Rows)
            {
                blUniversities.Items.Add(new ListItem( dr["UniversityName"].ToString(),dr["UniversityID"].ToString()));
            }
        }
      
        
    }
    protected void lnkBtnAddUniversity_Click(object sender, EventArgs e)
    {
        //make sure the validation image are not shown when opening the DIV
        vimgUniveristyName.Visible = false;

        btnAddUniversity.Text = "Add";
        btnDelete.Visible = false ;
        txtUniversityName.Text = string.Empty;

        mpeUniversities.Show();
    }
    private bool  ValidateUniversityDiv()
    {
        bool Valid = true;
        if (!Validation.ValidateRequiredTextField( txtUniversityName.Text))
        {
            vimgUniveristyName.Visible = true;
            Valid = false;
        }


        return Valid;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        mpeUniversities.Show();

        if (ValidateUniversityDiv())
        {
            FacUniversity universityInstance = new FacUniversity();
            universityInstance.UniversityName = txtUniversityName.Text;
            if (btnAddUniversity.Text == "Add")
            {
                try
                {
                    _AssociatedFacUniversitiesManager.InsertFacUniversity(universityInstance);
                    lblErrorUniversity.Text = string.Empty;
                    lblResultUniversity.Text = "University added successfully.";
                    BindUniversitiesList();
                    mpeUniversities.Hide();
                }
                catch (Exception ex)
                {
                    lblErrorUniversity.Text = ex.Message;
                    lblResultUniversity.Text = string.Empty;
                }
            }
            else if (btnAddUniversity.Text == "Update")
            {
                try
                {
                    universityInstance.UniversityID = int.Parse(ViewState["SelectedUniversity"].ToString());
                    _AssociatedFacUniversitiesManager.UpdateFacUniversity(universityInstance);
                    lblErrorUniversity.Text = string.Empty;
                    lblResultUniversity.Text = "University updated successfully.";
                    BindUniversitiesList();
                    mpeUniversities.Hide();
                }
                catch (Exception ex)
                {
                    lblErrorUniversity.Text = ex.Message;
                    lblResultUniversity.Text = string.Empty;
                }
            }
        }
    }

  
    protected void blUniversities_Click(object sender, BulletedListEventArgs e)
    {

    

        mpeUniversities.Show();
        txtUniversityName.Text = blUniversities.Items[e.Index].Text;
        ViewState["SelectedUniversity"] = blUniversities.Items[e.Index].Value;
        vimgUniveristyName.Visible = false;
        btnDelete.Visible = true;

        btnAddUniversity.Text = "Update";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            _AssociatedFacUniversitiesManager.DeleteFacUniversity(int.Parse(ViewState["SelectedUniversity"].ToString()));
            BindUniversitiesList();
            lblErrorUniversity.Text = string.Empty;
            lblResultUniversity.Text = "University deleted successfully";
        }

        catch (Exception ex)
        {
            lblErrorUniversity.Text = ex.Message;
            lblResultUniversity.Text = string.Empty ;
        }
    }
}
