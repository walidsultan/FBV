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

public partial class Manage_Education_Job : System.Web.UI.Page
{
    JobPlacesManager _AssociatedJobPlacesManager = new JobPlacesManager();
    FacUniversitiesManager _AssociatedUniversitiesManager = new FacUniversitiesManager();
    EducationManager _AssociatedEducationsManager = new EducationManager();
    EduFacultiesManager _AssociatedEduFacultiesManager = new EduFacultiesManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Display a confirmation Message before Deleting
            btnDeleteJobPlace.Attributes.Add("onclick", "javascript:return " +
            "confirm('هل أنت متأكد من إجراء عملية الحذف ؟ ')");

            BindJobPlacesList();
            BindEducationsList();
            BindUniversitiesDataGrid();
        }
    }

    private void BindJobPlacesList()
    {
        //clear the bulleted list before adding any new entries
        bltstJobPlaces.Items.Clear();

        DataTable JobPlacesTable = _AssociatedJobPlacesManager.GetAllJobPlaces();
        if (JobPlacesTable.Rows.Count > 0)
        {
            foreach (DataRow dr in JobPlacesTable.Rows)
            {
                bltstJobPlaces.Items.Add(new ListItem(dr["JobPlaceName"].ToString(), dr["JobPlaceID"].ToString()));
            }
        }


    }

    private void BindEducationsList()
    {
        //clear the bulleted list before adding any new entries
        bltstEducations.Items.Clear();

        DataTable EducationsTable = _AssociatedEducationsManager.GetAllEducations();
        if (EducationsTable.Rows.Count > 0)
        {
            foreach (DataRow dr in EducationsTable.Rows)
            {
                bltstEducations.Items.Add(new ListItem(dr["EducationName"].ToString(), dr["EducationID"].ToString()));
            }
        }


    }

    private void BindUniversitiesDataGrid()
    {
        DataTable AllUniversities = _AssociatedUniversitiesManager.GetAllFacUniversities();
        if (AllUniversities.Rows.Count > 0)
        {
            grdUniversities.DataSource = AllUniversities;
            grdUniversities.DataBind();
        }
        else
        {
            grdUniversities.DataBind();
        }

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //make sure the validation image are not shown when opening the DIV
        vimgJobPlaceName.Visible = false;

        DivFaculty.Visible = false;
        btnAddJobPlace.Text = "إضافة";
        LblMaster.Text = "المؤسسة :";
        txtMasterName.Visible = true;
        pnlJobPlaces.Visible = true;
        btnDeleteJobPlace.Visible = false;
        txtMasterName.Text = string.Empty;
        lblError.Text = string.Empty;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        lblResultFaculties.Text = string.Empty;
        mpeJobPlaces.Show();
    }

    private bool ValidateJobPlaceDiv()
    {
        bool Valid = true;
        if (!Validation.ValidateRequiredTextField(txtMasterName.Text))
        {
            vimgJobPlaceName.Visible = true;
            Valid = false;
        }
        return Valid;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        mpeJobPlaces.Show();

        if (ValidateJobPlaceDiv())
        {
            JobPlace JobPlaceInstance = new JobPlace();
            JobPlaceInstance.JobPlaceName = txtMasterName.Text;

            Education EducationInstance = new Education();
            EducationInstance.EducationName = txtMasterName.Text;

            FacUniversity FacUniversityInstance = new FacUniversity();
            FacUniversityInstance.UniversityName = txtMasterName.Text;

            EduFaculty EduFacultyIntance = new EduFaculty();
            EduFacultyIntance.FacultyName = txtMasterName.Text;
            if (ViewState["SelectedUniversity"] != null)
            {
                EduFacultyIntance.FUniversityID = int.Parse(ViewState["SelectedUniversity"].ToString());
            }

            if (btnAddJobPlace.Text == "إضافة")
            {
                if (LblMaster.Text == "المؤسسة :")
                {
                    try
                    {
                        _AssociatedJobPlacesManager.InsertJobPlace(JobPlaceInstance);
                        lblError.Text = string.Empty;
                        lblResultJobPlace.Text = "تم إضافة المؤسسة";
                        BindJobPlacesList();
                        mpeJobPlaces.Hide();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        lblResultJobPlace.Text = string.Empty;
                    }
                }


                if (LblMaster.Text == "الجامعة :")
                {
                    try
                    {
                        _AssociatedUniversitiesManager.InsertFacUniversity(FacUniversityInstance);
                        lblError.Text = string.Empty;
                        lblResultUniversities.Text = "تم إضافة الجامعة";
                        BindUniversitiesDataGrid();
                        mpeJobPlaces.Hide();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        lblResultUniversities.Text = string.Empty;
                    }
                }


                if (LblMaster.Text == "المؤهل :")
                {
                    try
                    {
                        _AssociatedEducationsManager.InsertEducation(EducationInstance);
                        lblError.Text = string.Empty;
                        lblResultEducation.Text = "تم إضافة المؤهل";
                        BindEducationsList();
                        mpeJobPlaces.Hide();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        lblResultEducation.Text = string.Empty;
                    }
                }


                if (LblMaster.Text == "الكلية :")
                {
                    try
                    {
                        //_AssociatedEducationsManager.InsertEducation(EducationInstance);
                        _AssociatedEduFacultiesManager.InsertFaculty(EduFacultyIntance);
                        lblError.Text = string.Empty;
                        lblResultFaculties.Text = "تم إضافة الكلية";
                        DivFaculty.Visible = true;
                        bltstFaculties.Items.Clear();
                        int universityId = int.Parse(ViewState["SelectedUniversity"].ToString());
                        DataTable facaultiesTable = _AssociatedEduFacultiesManager.GetFacultiesByUniversityId(universityId);
                        if (facaultiesTable.Rows.Count > 0)
                        {
                            foreach (DataRow dr in facaultiesTable.Rows)
                            {
                                bltstFaculties.Items.Add(new ListItem(dr["FacultyName"].ToString(), dr["FacultyID"].ToString()));
                            }
                        }
                        mpeJobPlaces.Hide();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        lblResultEducation.Text = string.Empty;
                    }
                }

            }
            else if (btnAddJobPlace.Text == "تعديل")
            {
                if (LblMaster.Text == "المؤسسة :")
                {
                    try
                    {
                        JobPlaceInstance.JobPlaceID = int.Parse(ViewState["SelectedJobPlace"].ToString());
                        _AssociatedJobPlacesManager.UpdateJobPlace(JobPlaceInstance);
                        lblError.Text = string.Empty;
                        lblResultJobPlace.Text = "تم تعديل المؤسسة";
                        BindJobPlacesList();
                        mpeJobPlaces.Hide();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        lblResultJobPlace.Text = string.Empty;
                    }
                }


                if (LblMaster.Text == "المؤهل :")
                {
                    try
                    {
                        EducationInstance.EducationID = int.Parse(ViewState["SelectedEducation"].ToString());
                        _AssociatedEducationsManager.UpdateEducation(EducationInstance);
                        lblError.Text = string.Empty;
                        lblResultEducation.Text = "تم تعديل المؤهل";
                        BindEducationsList();
                        mpeJobPlaces.Hide();
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = ex.Message;
                        lblResultEducation.Text = string.Empty;
                    }
                }
            }
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (LblMaster.Text == "المؤسسة :")
        {
            try
            {
                _AssociatedJobPlacesManager.DeleteJobPlace(int.Parse(ViewState["SelectedJobPlace"].ToString()));
                BindJobPlacesList();
                lblError.Text = string.Empty;
                lblResultJobPlace.Text = "تم حذف المؤسسة";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblResultJobPlace.Text = string.Empty;
            }
        }

        if (LblMaster.Text == "المؤهل :")
        {
            try
            {
                _AssociatedEducationsManager.DeleteEducation(int.Parse(ViewState["SelectedEducation"].ToString()));
                BindEducationsList();
                lblError.Text = string.Empty;
                lblResultEducation.Text = "تم حذف المؤهل";
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblResultEducation.Text = string.Empty;
            }
        }

    }

    protected void bltstJobPlaces_Click(object sender, BulletedListEventArgs e)
    {
        DivFaculty.Visible = false;
        mpeJobPlaces.Show();
        txtMasterName.Text = bltstJobPlaces.Items[e.Index].Text;
        ViewState["SelectedJobPlace"] = bltstJobPlaces.Items[e.Index].Value;
        lblError.Text = string.Empty;
        vimgJobPlaceName.Visible = false;
        btnDeleteJobPlace.Visible = true;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        lblResultFaculties.Text = string.Empty;
        LblMaster.Text = "المؤسسة :";
        btnAddJobPlace.Text = "تعديل";
    }

    protected void bltstEducations_Click(object sender, BulletedListEventArgs e)
    {
        DivFaculty.Visible = false;
        mpeJobPlaces.Show();
        txtMasterName.Text = bltstEducations.Items[e.Index].Text;
        ViewState["SelectedEducation"] = bltstEducations.Items[e.Index].Value;
        lblError.Text = string.Empty;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        vimgJobPlaceName.Visible = false;
        btnDeleteJobPlace.Visible = true;
        lblResultFaculties.Text = string.Empty;
        LblMaster.Text = "المؤهل :";
        btnAddJobPlace.Text = "تعديل";
    }

    protected void LnkAddNewEducation_Click(object sender, EventArgs e)
    {
        //make sure the validation image are not shown when opening the DIV
        DivFaculty.Visible = false;
        vimgJobPlaceName.Visible = false;
        btnAddJobPlace.Text = "إضافة";
        LblMaster.Text = "المؤهل :";
        txtMasterName.Visible = true;
        pnlJobPlaces.Visible = true;
        btnDeleteJobPlace.Visible = false;
        txtMasterName.Text = string.Empty;
        lblError.Text = string.Empty;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        lblResultFaculties.Text = string.Empty;
        mpeJobPlaces.Show();
    }

    protected void btnDeleteEducation_Click(object sender, EventArgs e)
    {
        try
        {
            //_AssociatedJobPlacesManager.DeleteJobPlace(int.Parse(ViewState["SelectedJobPlace"].ToString()));
            BindJobPlacesList();
            lblError.Text = string.Empty;
            lblResultJobPlace.Text = "تم حذف المؤهل بنجاح";
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblResultJobPlace.Text = string.Empty;
        }
    }

    protected void LnkAddNewUniversity_Click(object sender, EventArgs e)
    {
        //make sure the validation image are not shown when opening the DIV
        vimgJobPlaceName.Visible = false;
        DivFaculty.Visible = false;
        btnAddJobPlace.Text = "إضافة";
        LblMaster.Text = "الجامعة :";
        txtMasterName.Visible = true;
        pnlJobPlaces.Visible = true;
        btnDeleteJobPlace.Visible = false;
        txtMasterName.Text = string.Empty;
        lblError.Text = string.Empty;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        lblResultFaculties.Text = string.Empty;
        mpeJobPlaces.Show();
    }

    protected void lnkUniveristiesname_Click(object sender, CommandEventArgs e)
    {
        ViewState["SelectedUniversity"] = int.Parse(e.CommandArgument.ToString());
        DivFaculty.Visible = true;
        bltstFaculties.Items.Clear();

        txtMasterName.Text = string.Empty;
        lblError.Text = string.Empty;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        lblResultFaculties.Text = string.Empty;
        int universityId = int.Parse(e.CommandArgument.ToString());
        DataTable facaultiesTable = _AssociatedEduFacultiesManager.GetFacultiesByUniversityId(universityId);
        if (facaultiesTable.Rows.Count > 0)
        {
            foreach (DataRow dr in facaultiesTable.Rows)
            {
                bltstFaculties.Items.Add(new ListItem(dr["FacultyName"].ToString(), dr["FacultyID"].ToString()));
            }
        }
    }

    protected void LnkAddNewFaculty_Click(object sender, EventArgs e)
    {
        //make sure the validation image are not shown when opening the DIV
        vimgJobPlaceName.Visible = false;
        btnAddJobPlace.Text = "إضافة";
        LblMaster.Text = "الكلية :";
        txtMasterName.Visible = true;
        pnlJobPlaces.Visible = true;
        btnDeleteJobPlace.Visible = false;
        txtMasterName.Text = string.Empty;
        lblError.Text = string.Empty;
        lblResultJobPlace.Text = string.Empty;
        lblResultUniversities.Text = string.Empty;
        lblResultEducation.Text = string.Empty;
        lblResultFaculties.Text = string.Empty;
        mpeJobPlaces.Show();
    }
}

