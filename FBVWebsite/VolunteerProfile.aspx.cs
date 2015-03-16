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
using System.IO;
public partial class VolunteerProfile : PageThatRequiresLogin
{
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    AreasManager _AssociatedAreasManager = new AreasManager();
    EducationManager _AssociatedEducationManager = new EducationManager();
    FacUniversitiesManager _AssociatedUniversitiesManager = new FacUniversitiesManager();
    EduFacultiesManager _AssociatedFacultiesManager = new EduFacultiesManager();
    DepartmentsManager _AssociatedDepartmentsManager = new DepartmentsManager();
    FieldsManager _AssociatedFieldsManager = new FieldsManager();
    LanguagesManager _AssociatedLanguagesManager = new LanguagesManager();
    SkillsManager _AssociatedSkillsManager = new SkillsManager();
    MarketingManager _AssociatedMarketingManager = new MarketingManager();
    PlacesManager _AssociatedPlacesManager = new PlacesManager();
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();
    JobPlacesManager _AssociatedJobPlacesManager = new JobPlacesManager();
    SchoolsManager _AssociatedSchoolsManager = new SchoolsManager();
    ActivitiesManager _AssociatedActivitiesManager = new ActivitiesManager();
    int _ActivitySerial = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["VolunteerProfileId"] != null)
        {
            BindVolunteerData(int.Parse(Session["VolunteerProfileId"].ToString()));

        }
    }


    private void BindVolunteerData(int VolunteerId)
    {
        Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(VolunteerId);

        #region Bind Volunteer TextBoxes
        lblAddress.Text = volunteerInstance.VAddress;
        if (volunteerInstance.vBirthDate.HasValue)
            lblBirthDate.Text = volunteerInstance.vBirthDate.Value.ToShortDateString();
        lblCurrentJob.Text = volunteerInstance.VCurrentJob;
        lblEmail.Text = volunteerInstance.vEmail;
        lblExperience.Text = volunteerInstance.vXexperience;
        if (volunteerInstance.vFirstContactDate.HasValue)
            lblFirstContactDate.Text = volunteerInstance.vFirstContactDate.Value.ToShortDateString();
        lblGeneralComments.Text = volunteerInstance.vComments;
        if (volunteerInstance.vMeetingDate.HasValue)
            lblMeetingDate.Text = volunteerInstance.vMeetingDate.Value.ToShortDateString();
        lblMobile.Text = volunteerInstance.vMobile;
        if (volunteerInstance.vRegisterDate.HasValue)
            lblRegisterDate.Text = volunteerInstance.vRegisterDate.Value.ToShortDateString();
        if (volunteerInstance.VSchool.HasValue)
            lblSchool.Text = _AssociatedSchoolsManager.GetSchoolBySchoolID(volunteerInstance.VSchool.Value).SchoolName;

        lblTelephone.Text = volunteerInstance.vTelephone;
        lblVolunteerId.Text = volunteerInstance.VolunteerManID.ToString();
        lblVolunteerName.Text = volunteerInstance.vName;
        if (volunteerInstance.vSkills != null)
            lblSkills.Text = volunteerInstance.vSkills;
        #endregion
        #region Bind Volunteer Radio Buttons
        if (volunteerInstance.RegisterVia.HasValue)
            lblEntryWay.Text = Enum.GetName(typeof(RegisterVia), volunteerInstance.RegisterVia.Value);
        if (volunteerInstance.VGender != null)
            lblGender.Text = volunteerInstance.VGender.ToString();
        if (volunteerInstance.vMeetingDone != null)
        {
            if (volunteerInstance.vMeetingDone == true)
                lblMeetingDone.Text = "نعم";
            else
            {
                lblMeetingDone.Text = "لا";
                lblMeetingApologyTitle.Visible = true;
                lblMeetingApology.Visible = true;
                if (volunteerInstance.vMeetingApology.HasValue)
                {
                    if (volunteerInstance.vMeetingApology == true)
                    {
                        lblMeetingApology.Text = "نعم";
                        lblMeetingApologyDate.Visible = true;
                        lblMeetingApologyPlaceTitle.Visible = true;
                        lblMeetingApologyDateTitle.Visible = true;
                        lblMeetingApologyPlace.Visible = true;
                    }
                    else
                        lblMeetingApologyPlace.Text = "لا";
                }
                if (volunteerInstance.vMeetingApologyDate.HasValue)
                    lblMeetingApologyDate.Text = volunteerInstance.vMeetingApologyDate.Value.ToShortDateString();
                if (volunteerInstance.vMeetingApologyPlace.HasValue)
                    lblMeetingApologyPlace.Text = volunteerInstance.vMeetingApologyPlace.Value.ToString();
            }
        }

        #endregion
        #region Bind Volunteer DropDowns
        if (volunteerInstance.vMeetingPlaceID != null)
            lblMeetingPlace.Text = _AssociatedPlacesManager.GetPlaceByPlaceId(volunteerInstance.vMeetingPlaceID.Value).PlaceName;
        if (volunteerInstance.vRegistrationPlaceID != null)
            lblRegisterationPlace.Text = _AssociatedPlacesManager.GetPlaceByPlaceId(volunteerInstance.vRegistrationPlaceID.Value).PlaceName;
        if (volunteerInstance.vFirstContactPlaceID != null)
            lblFirstContactPlace.Text = _AssociatedPlacesManager.GetPlaceByPlaceId(volunteerInstance.vFirstContactPlaceID.Value).PlaceName;

        if (volunteerInstance.vAreaID.HasValue)
        {
            Area areaInstance = _AssociatedAreasManager.GetAreaByAreaId(volunteerInstance.vAreaID.Value);
            lblArea.Text = areaInstance.AreaName;
            lblCity.Text = _AssociatedCitiesManager.GetCityByCityId(areaInstance.CityID).CityName;
        }

        if (volunteerInstance.vEducationID.HasValue)
            lblEducation.Text = _AssociatedEducationManager.GetEducationByEducationId(volunteerInstance.vEducationID.Value).EducationName;
        if (volunteerInstance.VFacultyID.HasValue)
        {
            EduFaculty facultyInstance = _AssociatedFacultiesManager.GetFacultyById(volunteerInstance.VFacultyID.Value);
            lblUniversity.Text = _AssociatedUniversitiesManager.GetFacUniversityByUniversityId(facultyInstance.FUniversityID).UniversityName;
            lblFaculty.Text = facultyInstance.FacultyName;
        }
        if (volunteerInstance.vJobPlaceID.HasValue)
            lblJobPlace.Text = _AssociatedJobPlacesManager.GetJobPlaceByJobPlaceId(volunteerInstance.vJobPlaceID.Value).JobPlaceName;
        if (volunteerInstance.vKnow.HasValue)
            lblKnow.Text = _AssociatedMarketingManager.GetMarketingByMarketId(volunteerInstance.vKnow.Value).MarketName;
        #endregion
        #region Bind Volunteer Check Boxes
        DataTable volunteerFieldWorkTable = _AssociatedFieldsManager.GetAllFieldVolunteerWorkByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerFieldWorkTable.Rows)
        {
            if (lblRecommendedFields.Text == string.Empty)
            {
                Field fieldInstance = _AssociatedFieldsManager.GetFieldByFieldId(int.Parse(dr["FieldWorkID"].ToString()));
                if (fieldInstance != null)
                {
                    lblRecommendedFields.Text = fieldInstance.FieldName;
                }
            }
            else
            {
                Field fieldInstance = _AssociatedFieldsManager.GetFieldByFieldId(int.Parse(dr["FieldWorkID"].ToString()));
                if (fieldInstance != null)
                {
                    lblRecommendedFields.Text += ", " + fieldInstance.FieldName ;
                }
            }
        }

        DataTable volunteerFieldDesiredTable = _AssociatedFieldsManager.GetAllFieldVolunteerDesiredByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerFieldDesiredTable.Rows)
        {
            if (lblDesiredFields.Text == string.Empty)
            {
                lblDesiredFields.Text = _AssociatedFieldsManager.GetFieldByFieldId(int.Parse(dr["FieldDesiredID"].ToString())).FieldName;
            }
            else
            {
                lblDesiredFields.Text += ", " + _AssociatedFieldsManager.GetFieldByFieldId(int.Parse(dr["FieldDesiredID"].ToString())).FieldName;
            }
        }

        DataTable volunteerSkillsTable = _AssociatedSkillsManager.GetVolunteerSkillsByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerSkillsTable.Rows)
        {
            if (lblSkillsVolunteer.Text == string.Empty)
            {
                lblSkillsVolunteer.Text = _AssociatedSkillsManager.GetSkillById(int.Parse(dr["SkillID"].ToString())).SkillName;
            }
            else
            {
                lblSkillsVolunteer.Text += ", " + _AssociatedSkillsManager.GetSkillById(int.Parse(dr["SkillID"].ToString())).SkillName;
            }
        }

        DataTable volunteerLanguagesTable = _AssociatedLanguagesManager.GetVolunteerLanguagesByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerLanguagesTable.Rows)
        {
            if (lblLangVolunteer.Text == string.Empty)
            {
                lblLangVolunteer.Text = _AssociatedLanguagesManager.GetLanguageByLanguageId(int.Parse(dr["LanguageID"].ToString())).LanguageName;
            }
            else
            {
                lblLangVolunteer.Text += ", " + _AssociatedLanguagesManager.GetLanguageByLanguageId(int.Parse(dr["LanguageID"].ToString())).LanguageName;
            }
        }
        #endregion
        #region Bind Volunteer Uploaded Files
        if (volunteerInstance.vImage != string.Empty && volunteerInstance.vImage != null)
        {
            hlnkPhoto.NavigateUrl = volunteerInstance.vImage;
            hlnkPhoto.Text = Path.GetFileName(volunteerInstance.vImage);
            hlnkPhoto.Visible = true;
        }
        if (volunteerInstance.vCV != string.Empty && volunteerInstance.vCV != null)
        {
            hlnkCv.NavigateUrl = volunteerInstance.vCV;
            hlnkCv.Text = Path.GetFileName(volunteerInstance.vCV);
            hlnkCv.Visible = true;
        }
        if (volunteerInstance.vOtherFile != string.Empty && volunteerInstance.vOtherFile != null)
        {
            hlnkOtherFiles.NavigateUrl = volunteerInstance.vOtherFile;
            hlnkOtherFiles.Text = Path.GetFileName(volunteerInstance.vOtherFile);
            hlnkOtherFiles.Visible = true;
        }
        #endregion
        BindVolunteerActivities(VolunteerId);
        lblTitle.Text = "قاعدة بيانات المتطوعين – بيانات المتطوع";
    }
    public override bool CheckPermission()
    {
        if (CurrentUser.UAccessLevel == (int)UserAccessLevel.Administrator)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void BindVolunteerActivities(int VolunteerId)
    {
        DataTable volunteerActivities = _AssociatedActivitiesManager.GetActivityResultByVolunteerId(VolunteerId);
        if (volunteerActivities.Rows.Count > 0)
        {
            grdVolunteerActivities.DataSource = volunteerActivities;
            grdVolunteerActivities.DataBind();
        }
        else
        {
            grdVolunteerActivities.DataBind();
        }
    }

    protected void grdVolunteerActivities_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            Label lblActivityStartDate = (Label)e.Row.FindControl("lblActivityStartDate");
            Label lblRecommended = (Label)e.Row.FindControl("lblRecommended");
            Label lblVolunteerDepartmentEvaluation = (Label)e.Row.FindControl("lblVolunteerDepartmentEvaluation");
            Label lblActivityDepartmentEvaluation = (Label)e.Row.FindControl("lblActivityDepartmentEvaluation");

            //add pageindex offset to activity serial 
            lblSerial.Text = _ActivitySerial.ToString();
            if (!string.IsNullOrEmpty(lblActivityStartDate.Text))
                lblActivityStartDate.Text = DateTime.Parse(lblActivityStartDate.Text).ToShortDateString();
            if (lblRecommended.Text == "True")
            {
                lblRecommended.Text = "نعم";
            }
            else if (lblRecommended.Text == "False")
            {
                lblRecommended.Text = "لا";
            }
            else
                _ActivitySerial++;

            if (lblActivityDepartmentEvaluation.Text != string.Empty)
            {
                lblActivityDepartmentEvaluation.Text = Enum.GetName(typeof(EvaluationLevel), int.Parse(lblActivityDepartmentEvaluation.Text));
            }
            if (lblVolunteerDepartmentEvaluation.Text != string.Empty)
            {
                lblVolunteerDepartmentEvaluation.Text = Enum.GetName(typeof(EvaluationLevel), int.Parse(lblVolunteerDepartmentEvaluation.Text));
            }
        }
    }
    protected void lnkActivityCodeNo_Command(object sender, CommandEventArgs e)
    {
        Session["ActivityId"] = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("AddActivity.aspx?Edit=true");
    }
}
