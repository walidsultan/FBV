using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FBV.DataAccessLayer;
using FBV.DataMapping;
using System.IO;
using System.Data.SqlClient;
public partial class AddVolunteer : PageThatRequiresLogin
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCitiesDropDown();
            BindDepartmentsDropDown();
            BindEducationDropDown();
            BindUniversitiesDropDown();
            BindFieldsChkLists();
            BindVolunteerLanguagesChkList();
            BindSkillsChkList();
            BindMarketingDropDown();
            BindPlacesDropDowns();
            BindRegisterViaRdb();
            BindSchoolsDropDwon();
            btnAddVolunteer.OnClientClick = "$.blockUI({ message: '<h2>... جارى التحميل</h2>'  ,  css: {border: 'none',padding: '15px',backgroundColor: '#000',opacity: '.5',color: '#fff','-webkit-border-radius': '10px','-moz-border-radius': '10px', filter: 'alpha(opacity=70)' }  });";
            btnUploadCv.OnClientClick = "$.blockUI({ message: '<h2>... جارى التحميل</h2>'  ,  css: {border: 'none',padding: '15px',backgroundColor: '#000',opacity: '.5',color: '#fff','-webkit-border-radius': '10px','-moz-border-radius': '10px', filter: 'alpha(opacity=70)' }  });";
            btnUploadPhoto.OnClientClick = "$.blockUI({ message: '<h2>... جارى التحميل</h2>'  ,  css: {border: 'none',padding: '15px',backgroundColor: '#000',opacity: '.5',color: '#fff','-webkit-border-radius': '10px','-moz-border-radius': '10px', filter: 'alpha(opacity=70)' }  });";
            btnUploadOtherFiles.OnClientClick = "$.blockUI({ message: '<h2>... جارى التحميل</h2>'  ,  css: {border: 'none',padding: '15px',backgroundColor: '#000',opacity: '.5',color: '#fff','-webkit-border-radius': '10px','-moz-border-radius': '10px', filter: 'alpha(opacity=70)' }  });";
            lblTitle.Text = "قاعدة بيانات المتطوعين – صفحة الاضافة";
            if (Request.QueryString["Edit"] == "true")
            {
                BindVolunteerData(int.Parse(Session["VolunteerId"].ToString()));
            }
        }

    }

    private void BindSchoolsDropDwon()
    {
        drpSchool.Items.Clear();
        drpSchool.Items.Add(new ListItem("إختار", "Select"));
        DataTable allSchools = _AssociatedSchoolsManager.GetAllSchools();
        foreach (DataRow dr in allSchools.Rows)
        {
            drpSchool.Items.Add(new ListItem(dr["SchoolName"].ToString(), dr["SchoolId"].ToString()));
        }

    }
    private void BindVolunteerData(int VolunteerId)
    {
        Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(VolunteerId);

        #region Bind Volunteer TextBoxes
        txtAddress.Text = volunteerInstance.VAddress;
        if (volunteerInstance.vBirthDate.HasValue)
            txtBirthDate.Text = volunteerInstance.vBirthDate.Value.ToShortDateString();
        txtCurrentJob.Text = volunteerInstance.VCurrentJob;
        txtEmail.Text = volunteerInstance.vEmail;
        txtExperience.Text = volunteerInstance.vXexperience;
        if (volunteerInstance.vFirstContactDate.HasValue)
            txtFirstContactDate.Text = volunteerInstance.vFirstContactDate.Value.ToShortDateString();
        txtGeneralComments.Text = volunteerInstance.vComments;
        if (volunteerInstance.vMeetingDate.HasValue)
            txtMeetingDate.Text = volunteerInstance.vMeetingDate.Value.ToShortDateString();
        txtMobile.Text = volunteerInstance.vMobile;
        if (volunteerInstance.vRegisterDate.HasValue)
            txtRegisterDate.Text = volunteerInstance.vRegisterDate.Value.ToShortDateString();
        txtTelephone.Text = volunteerInstance.vTelephone;
        txtVolunteerId.Text = volunteerInstance.VolunteerManID.ToString();
        txtVolunteerName.Text = volunteerInstance.vName;
        if (volunteerInstance.vSkills != null)
            txtSkills.Text = volunteerInstance.vSkills;
        #endregion
        #region Bind Volunteer Radio Buttons
        if (volunteerInstance.RegisterVia.HasValue)
            rdbEntryWay.SelectedValue = Enum.GetName(typeof(RegisterVia), volunteerInstance.RegisterVia.Value);
        if (volunteerInstance.VGender != null)
            rdbGender.SelectedValue = volunteerInstance.VGender.ToString();
        if (volunteerInstance.vMeetingDone != null)
        {
            if (volunteerInstance.vMeetingDone == true)
                rdbMeetingDone.SelectedValue = "نعم";
            else
            {
                rdbMeetingDone.SelectedValue = "لا";
                rdbMeetingApology.Visible = true;
                lblMeetingApology.Visible = true;
                if (volunteerInstance.vMeetingApology.HasValue)
                {
                    if (volunteerInstance.vMeetingApology == true)
                    {
                        rdbMeetingApology.SelectedValue = "نعم";
                        lblMeetingApologyDate.Visible = true;
                        lblMeetingApologyPlace.Visible = true;
                        txtMeetingApologyDate.Visible = true;
                        drpMeetingApologyPlace.Visible = true;
                    }
                    else
                        drpMeetingApologyPlace.SelectedValue = "لا";
                }
                if (volunteerInstance.vMeetingApologyDate.HasValue)
                    txtMeetingApologyDate.Text = volunteerInstance.vMeetingApologyDate.Value.ToShortDateString();
                if (volunteerInstance.vMeetingApologyPlace.HasValue)
                    drpMeetingApologyPlace.SelectedValue = volunteerInstance.vMeetingApologyPlace.Value.ToString();
            }
        }

        #endregion
        #region Bind Volunteer DropDowns
        if (volunteerInstance.vMeetingPlaceID != null)
            drpMeetingPlace.SelectedValue = volunteerInstance.vMeetingPlaceID.Value.ToString();
        if (volunteerInstance.vRegistrationPlaceID != null)
            drpRegisterationPlace.SelectedValue = volunteerInstance.vRegistrationPlaceID.Value.ToString();
        if (volunteerInstance.vFirstContactPlaceID != null)
            drpFirstContactPlace.SelectedValue = volunteerInstance.vFirstContactPlaceID.Value.ToString();

        if (volunteerInstance.vAreaID.HasValue)
        {
            Area areaInstance = _AssociatedAreasManager.GetAreaByAreaId(volunteerInstance.vAreaID.Value);
            BindAreasDropDown(areaInstance.CityID);
            drpArea.SelectedValue = areaInstance.AreaID.ToString();
            drpCity.SelectedValue = areaInstance.CityID.ToString();
        }

        if (volunteerInstance.vEducationID.HasValue)
            drpEducation.SelectedValue = volunteerInstance.vEducationID.Value.ToString();
        if (volunteerInstance.VFacultyID.HasValue)
        {
            EduFaculty facultyInstance = _AssociatedFacultiesManager.GetFacultyById(volunteerInstance.VFacultyID.Value);
            BindFacultiesDropDown(facultyInstance.FUniversityID);
            drpUniversity.SelectedValue = facultyInstance.FUniversityID.ToString();
            drpFaculty.SelectedValue = volunteerInstance.VFacultyID.Value.ToString();
        }
        if (volunteerInstance.vJobPlaceID.HasValue)
            drpJobPlace.SelectedValue = volunteerInstance.vJobPlaceID.Value.ToString();
        if (volunteerInstance.vKnow.HasValue)
            drpKnow.SelectedValue = volunteerInstance.vKnow.Value.ToString();
        if (volunteerInstance.VSchool.HasValue)
            drpSchool.SelectedValue = volunteerInstance.VSchool.Value.ToString();

        #endregion
        #region Bind Volunteer Check Boxes
        DataTable volunteerFieldWorkTable = _AssociatedFieldsManager.GetAllFieldVolunteerWorkByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerFieldWorkTable.Rows)
        {
            chkRecommendedFields.Items.FindByValue(dr["FieldWorkID"].ToString()).Selected = true;
        }

        DataTable volunteerFieldDesiredTable = _AssociatedFieldsManager.GetAllFieldVolunteerDesiredByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerFieldDesiredTable.Rows)
        {
            chkDesiredFields.Items.FindByValue(dr["FieldDesiredID"].ToString()).Selected = true;
        }

        DataTable volunteerSkillsTable = _AssociatedSkillsManager.GetVolunteerSkillsByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerSkillsTable.Rows)
        {
            chkSkillsVolunteer.Items.FindByValue(dr["SkillID"].ToString()).Selected = true;
        }

        DataTable volunteerLanguagesTable = _AssociatedLanguagesManager.GetVolunteerLanguagesByVolunteerId(volunteerInstance.VolunteerID);
        foreach (DataRow dr in volunteerLanguagesTable.Rows)
        {
            chkLangVolunteer.Items.FindByValue(dr["LanguageID"].ToString()).Selected = true;
        }
        #endregion
        #region Bind Volunteer Uploaded Files
        if (volunteerInstance.vImage != string.Empty && volunteerInstance.vImage != null)
        {
            hlnkPhoto.NavigateUrl = volunteerInstance.vImage;
            hlnkPhoto.Text = Path.GetFileName(volunteerInstance.vImage);
            hlnkPhoto.Visible = true;
            fuPhoto.Visible = false;
            btnUploadPhoto.Visible = false;
            imgBtnRemovePhoto.Visible = true;
        }
        if (volunteerInstance.vCV != string.Empty && volunteerInstance.vCV != null)
        {
            hlnkCv.NavigateUrl = volunteerInstance.vCV;
            hlnkCv.Text = Path.GetFileName(volunteerInstance.vCV);
            hlnkCv.Visible = true;
            fuCv.Visible = false;
            btnUploadCv.Visible = false;
            imgBtnRemoveCv.Visible = true;
        }
        if (volunteerInstance.vOtherFile != string.Empty && volunteerInstance.vOtherFile != null)
        {
            hlnkOtherFiles.NavigateUrl = volunteerInstance.vOtherFile;
            hlnkOtherFiles.Text = Path.GetFileName(volunteerInstance.vOtherFile);
            hlnkOtherFiles.Visible = true;
            fuOtherFiles.Visible = false;
            btnUploadOtherFiles.Visible = false;
            imgBtnOtherFiles.Visible = true;
        }
        #endregion

        lblTitle.Text = "قاعدة بيانات المتطوعين – صفحة التعديل";

        btnAddVolunteer.Text = "تعديل بيانات المتطوع";
    }
    private void BindRegisterViaRdb()
    {
        rdbEntryWay.Items.Add(new ListItem(RegisterVia.إنترنت.ToString(), (RegisterVia.إنترنت).ToString()));
        rdbEntryWay.Items.Add(new ListItem(RegisterVia.يدوى.ToString(), (RegisterVia.يدوى).ToString()));

    }
    private void BindUniversitiesDropDown()
    {
        drpUniversity.Items.Clear();
        drpUniversity.Items.Add(new ListItem("إختار", "Select"));
        DataTable allUniveristies = _AssociatedUniversitiesManager.GetAllFacUniversities();
        foreach (DataRow dr in allUniveristies.Rows)
        {
            drpUniversity.Items.Add(new ListItem(dr["UniversityName"].ToString(), dr["UniversityID"].ToString()));
        }
    }
    private void BindFacultiesDropDown(int UniversityId)
    {
        drpFaculty.Items.Clear();
        drpFaculty.Items.Add(new ListItem("إختار", "Select"));
        DataTable universityFaculties = _AssociatedFacultiesManager.GetFacultiesByUniversityId(UniversityId);
        foreach (DataRow dr in universityFaculties.Rows)
        {
            drpFaculty.Items.Add(new ListItem(dr["FacultyName"].ToString(), dr["FacultyID"].ToString()));
        }
    }
    private void BindFieldsChkLists()
    {
        chkDesiredFields.Items.Clear();
        chkRecommendedFields.Items.Clear();
        DataTable desiredFields = _AssociatedFieldsManager.GetAllFields();
        foreach (DataRow dr in desiredFields.Rows)
        {
            chkDesiredFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
            chkRecommendedFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
        }

    }
    private void BindCitiesDropDown()
    {
        drpCity.Items.Clear();
        drpCity.Items.Add(new ListItem("إختار", "Select"));
        DataTable allCities = _AssociatedCitiesManager.GetAllCities();
        foreach (DataRow dr in allCities.Rows)
        {
            drpCity.Items.Add(new ListItem(dr["CityName"].ToString(), dr["CityID"].ToString()));
        }
    }
    private void BindEducationDropDown()
    {
        drpEducation.Items.Clear();
        drpEducation.Items.Add(new ListItem("إختار", "Select"));
        DataTable educationTable = _AssociatedEducationManager.GetAllEducations();
        foreach (DataRow dr in educationTable.Rows)
        {
            drpEducation.Items.Add(new ListItem(dr["EducationName"].ToString(), dr["EducationID"].ToString()));
        }
    }
    private void BindAreasDropDown(int CityId)
    {
        drpArea.Items.Clear();
        drpArea.Items.Add(new ListItem("إختار", "Select"));
        DataTable cityAreas = _AssociatedAreasManager.GetAreasByCityId(CityId);
        foreach (DataRow dr in cityAreas.Rows)
        {
            drpArea.Items.Add(new ListItem(dr["AreaName"].ToString(), dr["AreaID"].ToString()));
        }
    }
    private void BindDepartmentsDropDown()
    {
        drpJobPlace.Items.Clear();
        drpJobPlace.Items.Add(new ListItem("إختار", "Select"));
        DataTable allJobPlaces = _AssociatedJobPlacesManager.GetAllJobPlaces();
        foreach (DataRow dr in allJobPlaces.Rows)
        {
            drpJobPlace.Items.Add(new ListItem(dr["JobPlaceName"].ToString(), dr["JobPlaceID"].ToString()));
        }
    }
    private void BindMarketingDropDown()
    {
        drpKnow.Items.Clear();
        drpKnow.Items.Add(new ListItem("إختار", "Select"));
        DataTable allMarketing = _AssociatedMarketingManager.GetAllMarketing();
        foreach (DataRow dr in allMarketing.Rows)
        {
            drpKnow.Items.Add(new ListItem(dr["MarketName"].ToString(), dr["MarketingID"].ToString()));
        }
    }
    public void BindVolunteerLanguagesChkList()
    {
        chkLangVolunteer.Items.Clear();
        DataTable allLanguages = _AssociatedLanguagesManager.GetAllLanguages();
        foreach (DataRow dr in allLanguages.Rows)
        {
            chkLangVolunteer.Items.Add(new ListItem(dr["LanguageName"].ToString(), dr["LanguageID"].ToString()));
        }
    }
    public void BindSkillsChkList()
    {
        chkSkillsVolunteer.Items.Clear();
        DataTable allSkills = _AssociatedSkillsManager.GetAllSkills();
        foreach (DataRow dr in allSkills.Rows)
        {
            chkSkillsVolunteer.Items.Add(new ListItem(dr["SkillName"].ToString(), dr["SkillID"].ToString()));
        }
    }
    public void BindPlacesDropDowns()
    {
        drpMeetingPlace.Items.Clear();
        drpRegisterationPlace.Items.Clear();
        drpFirstContactPlace.Items.Clear();
        drpMeetingApologyPlace.Items.Clear();
        drpMeetingPlace.Items.Add(new ListItem("إختار", "Select"));
        drpRegisterationPlace.Items.Add(new ListItem("إختار", "Select"));
        drpFirstContactPlace.Items.Add(new ListItem("إختار", "Select"));
        drpMeetingApologyPlace.Items.Add(new ListItem("إختار", "Select"));

        DataTable allPlaces = _AssociatedPlacesManager.GetAllPlaces();
        foreach (DataRow dr in allPlaces.Rows)
        {
            drpMeetingPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
            drpRegisterationPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
            drpFirstContactPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
            drpMeetingApologyPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
        }
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

    protected void drpCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpCity.SelectedValue != "Select")
        {
            BindAreasDropDown(int.Parse(drpCity.SelectedValue));
        }
        else
        {
            drpArea.Items.Clear();
            drpArea.Items.Add(new ListItem("إختار", "Select"));
        }
    }
    protected void drpUniversity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUniversity.SelectedValue != "Select")
        {
            BindFacultiesDropDown(int.Parse(drpUniversity.SelectedValue));
        }
        else
        {
            drpFaculty.Items.Clear();
            drpFaculty.Items.Add(new ListItem("إختار", "Select"));
        }
    }

    private bool ValidatePage()
    {
        ResetValiadationImagesToDefaultValue(Page);
        lblVolunteerError.Text = string.Empty;
        bool valid = true;

        #region ValidateRequiredTextBoxes
        if (!Validation.ValidateRequiredTextField(txtVolunteerId.Text))
        {
            valid = false;
            imgVolunteerManIdV.Visible = true;
        }

        if (!Validation.ValidateRequiredTextField(txtVolunteerName.Text))
        {
            valid = false;
            imgVolunteerNameV.Visible = true;
        }

        //if (!Validation.ValidateRequiredTextField(txtBirthDate.Text))
        //{
        //    valid = false;
        //    imgVolunteerBirthDateV.Visible = true;
        //}

        //if (!Validation.ValidateRequiredTextField(txtRegisterDate.Text))
        //{
        //    valid = false;
        //    imgVolunteerRegisterDate.Visible = true;
        //}

        //if (!Validation.ValidateRequiredTextField(txtFirstContactDate.Text))
        //{
        //    valid = false;
        //    imgVolunteerFirstContactDateV.Visible = true;
        //}

        //if (!Validation.ValidateRequiredTextField(txtMeetingDate.Text))
        //{
        //    valid = false;
        //    imgVolunteerMeetingDateV.Visible = true;
        //}
        #endregion

        #region ValidateRequiredDropDowns
        //if (drpEducation.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerEducationV.Visible = true;
        //}

        //if (drpUniversity.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerUniversityV.Visible = true;
        //}

        //if (drpFaculty.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerFacultyV.Visible = true;
        //}

        //if (drpJobPlace.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerJobPlaceV.Visible = true;
        //}

        //if (drpCity.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerCityV.Visible = true;
        //}

        //if (drpArea.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerAreaV.Visible = true;
        //}

        //if (drpKnow.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerKnowV.Visible = true;
        //}
        #endregion

        #region ValidateRequiredCheckBoxes

        //bool DesiredFieldsSelected = false;
        //foreach (ListItem item in chkDesiredFields.Items)
        //{
        //    if (item.Selected == true)
        //    {
        //        DesiredFieldsSelected = true;
        //        break;
        //    }
        //}
        //if (DesiredFieldsSelected == false)
        //{
        //    imgVolunteerActivityFieldsV.Visible = true;
        //    valid = false;
        //}

        //bool RecommendedFieldsSelected = false;
        //foreach (ListItem item in chkRecommendedFields.Items)
        //{
        //    if (item.Selected == true)
        //    {
        //        RecommendedFieldsSelected = true;
        //        break;
        //    }
        //}
        //if (RecommendedFieldsSelected == false)
        //{
        //    imgVolunteerRecommendedActivityFieldsV.Visible = true;
        //    valid = false;
        //}
        #endregion

        #region ValidateRequiredRadioBoxes
        //if (rdbGender.SelectedIndex < 0)
        //{
        //    valid = false;
        //    imgVolunteerGenderV.Visible = true;
        //}

        //if (drpRegisterationPlace.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerRegisterationPlace.Visible = true;
        //}

        //if (drpMeetingPlace.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerMeetingPlaceV.Visible = true;
        //}

        //if (drpFirstContactPlace.SelectedValue == "Select")
        //{
        //    valid = false;
        //    imgVolunteerFirstContactPlaceV.Visible = true;
        //}

        if (rdbEntryWay.SelectedIndex < 0)
        {
            valid = false;
            imgVolunteerRegisterViaV.Visible = true;
        }
        #endregion

        #region ValidateRequiredUploadedFiles
        //if (btnUploadCv.Visible == true)
        //{
        //    valid = false;
        //    imgVolunteerCvV.Visible = true;
        //}

        //if (btnUploadPhoto .Visible == true)
        //{
        //    valid = false;
        //    imgVolunteerPhotoV .Visible = true;
        //}

        //if (btnUploadOtherFiles .Visible == true)
        //{
        //    valid = false;
        //    imgVolunteerOtherFilesV.Visible = true;
        //}
        #endregion

        #region ValidateFieldFormats
        if (!Validation.ValidateDate(txtBirthDate.Text))
        {
            valid = false;
            imgVolunteerBirthDateV.Visible = true;
        }
        if (!Validation.ValidateDate(txtMeetingApologyDate.Text))
        {
            valid = false;
            imgVolunteerMeetingApologyDateV.Visible = true;
        }
        if (!Validation.ValidateInt(txtVolunteerId.Text))
        {
            valid = false;
            imgVolunteerManIdV.Visible = true;
        }
        if (!Validation.ValidateDate(txtRegisterDate.Text))
        {
            valid = false;
            imgVolunteerRegisterDate.Visible = true;
        }
        if (!Validation.ValidateDate(txtFirstContactDate.Text))
        {
            valid = false;
            imgVolunteerFirstContactDateV.Visible = true;
        }
        if (!Validation.ValidateDate(txtMeetingDate.Text))
        {
            valid = false;
            imgVolunteerMeetingDateV.Visible = true;
        }
        if (txtMobile.Text != string.Empty && !Validation.ValidateMobileNumber(txtMobile.Text))
        {
            valid = false;
            imgVolunteerMobileV.Visible = true;
        }

        if (txtEmail.Text != string.Empty && !Validation.ValidateEmail(txtEmail.Text))
        {
            valid = false;
            imgVolunteerEmailV.Visible = true;
        }

        //if name field has more than 4 words check that's not repeated
        string[] words = txtVolunteerName.Text.Split(' ');
        if (Request.QueryString ["Edit"]==null && words.Length  > 3 && _AssociatedVolunteersManager.GetVolunteersByName (txtVolunteerName.Text).Rows.Count >0 )
        {
            valid = false;
            imgVolunteerNameV .Visible = true;
            imgVolunteerNameV.ToolTip = "إسم المتطوع مكرر فى قاعدة البيانات برجاء إدخال إسم أخر";
        }

        #endregion

        if (valid == false)
        {
            lblVolunteerError.Text = "خطأ فى البيانات";
            lblVolunteerResult.Text = string.Empty;
        }

        return valid;

    }

    protected void btnAddVolunteer_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            #region Initiate Volunteer Instance
            Volunteer volunteerInstance = new Volunteer();
            volunteerInstance.EntryDate = DateTime.Now;
            volunteerInstance.EntryUserID = CurrentUser.UserID;
            volunteerInstance.RegisterVia = (int)RegisterVia.إنترنت;
            volunteerInstance.VAddress = txtAddress.Text;
            if (drpArea.SelectedValue == "Select")
                volunteerInstance.vAreaID = null;
            else
                volunteerInstance.vAreaID = int.Parse(drpArea.SelectedValue.ToString());
            if (txtBirthDate.Text == string.Empty)
                volunteerInstance.vBirthDate = null;
            else
                volunteerInstance.vBirthDate = DateTime.Parse(txtBirthDate.Text);
            if (rdbGender.SelectedIndex < 0)
                volunteerInstance.VGender = null;
            else
                volunteerInstance.VGender = rdbGender.SelectedValue;
            //volunteerInstance.vComingDate 
            volunteerInstance.vComments = txtGeneralComments.Text;
            //volunteerInstance .vComputer =
            //volunteerInstance.vComputerSkills 
            volunteerInstance.VCurrentJob = txtCurrentJob.Text;
            volunteerInstance.vCV = hlnkCv.NavigateUrl;
            if (drpEducation.SelectedValue == "Select")
                volunteerInstance.vEducationID = null;
            else
                volunteerInstance.vEducationID = int.Parse(drpEducation.SelectedValue);
            volunteerInstance.vEmail = txtEmail.Text;
            if (drpFaculty.SelectedValue == "Select")
                volunteerInstance.VFacultyID = null;
            else
                volunteerInstance.VFacultyID = int.Parse(drpFaculty.SelectedValue);
            if (txtFirstContactDate.Text == string.Empty)
                volunteerInstance.vFirstContactDate = null;
            else
                volunteerInstance.vFirstContactDate = DateTime.Parse(txtFirstContactDate.Text);
            if (drpFirstContactPlace.SelectedValue == "Select")
                volunteerInstance.vFirstContactPlaceID = null;
            else
                volunteerInstance.vFirstContactPlaceID = int.Parse(drpFirstContactPlace.SelectedValue);
            volunteerInstance.vImage = hlnkPhoto.NavigateUrl;
            if (drpJobPlace.SelectedValue == "Select")
                volunteerInstance.vJobPlaceID = null;
            else
                volunteerInstance.vJobPlaceID = int.Parse(drpJobPlace.SelectedValue);
            if (drpKnow.SelectedValue == "Select")
                volunteerInstance.vKnow = null;
            else
                volunteerInstance.vKnow = int.Parse(drpKnow.SelectedValue);
            if (txtMeetingDate.Text == string.Empty)
                volunteerInstance.vMeetingDate = null;
            else
                volunteerInstance.vMeetingDate = DateTime.Parse(txtMeetingDate.Text);
            if (drpMeetingPlace.SelectedValue == "Select")
                volunteerInstance.vMeetingPlaceID = null;
            else
                volunteerInstance.vMeetingPlaceID = int.Parse(drpMeetingPlace.SelectedValue);
            volunteerInstance.vMobile = txtMobile.Text;
            volunteerInstance.vName = txtVolunteerName.Text;
            volunteerInstance.VolunteerManID = int.Parse(txtVolunteerId.Text);
            volunteerInstance.vOtherFile = hlnkOtherFiles.NavigateUrl;
            //volunteerInstance.vPassword 
            //volunteerInstance.vReceiveMail 
            if (txtRegisterDate.Text == string.Empty)
                volunteerInstance.vRegisterDate = null;
            else
                volunteerInstance.vRegisterDate = DateTime.Parse(txtRegisterDate.Text);
            if (drpRegisterationPlace.SelectedValue == "Select")
                volunteerInstance.vRegistrationPlaceID = null;
            else
                volunteerInstance.vRegistrationPlaceID = int.Parse(drpRegisterationPlace.SelectedValue);

            if (drpSchool.SelectedValue == "Select")
                volunteerInstance.VSchool = null;
            else
                volunteerInstance.VSchool = int.Parse(drpSchool.SelectedValue);

            volunteerInstance.vTelephone = txtTelephone.Text;
            volunteerInstance.vSkills = txtSkills.Text;
            volunteerInstance.vXexperience = txtExperience.Text;

            if (rdbMeetingDone.SelectedValue == string.Empty)
                volunteerInstance.vMeetingDone = null;
            else if (rdbMeetingDone.SelectedValue == "نعم")
                volunteerInstance.vMeetingDone = true;
            else if (rdbMeetingDone.SelectedValue == "لا")
                volunteerInstance.vMeetingDone = false;

            if (rdbMeetingApology.SelectedValue == string.Empty)
                volunteerInstance.vMeetingApology = null;
            else if (rdbMeetingApology.SelectedValue == "نعم")
                volunteerInstance.vMeetingApology = true;
            else if (rdbMeetingApology.SelectedValue == "لا")
                volunteerInstance.vMeetingApology = false;

            if (txtMeetingApologyDate.Text == string.Empty)
                volunteerInstance.vMeetingApologyDate = null;
            else
                volunteerInstance.vMeetingApologyDate = DateTime.Parse(txtMeetingApologyDate.Text);

            if (drpMeetingApologyPlace.SelectedValue == "Select")
                volunteerInstance.vMeetingApologyPlace = null;
            else
                volunteerInstance.vMeetingApologyPlace = int.Parse(drpMeetingApologyPlace.SelectedValue);

            //volunteerInstance.vUsername 
            //volunteerInstance.vXexperience 

            //other undecided Fields
            volunteerInstance.vComingDate = null;
            #endregion
            SqlTransaction transactionInstance = _AssociatedVolunteersManager.BeginTransaction();
            try
            {
                if (btnAddVolunteer.Text == "أدخل بيانات المتطوع")
                {
                    #region Insert new volunteer
                    int volunteerId = _AssociatedVolunteersManager.InsertVolunteer(volunteerInstance, transactionInstance);
                    //insert desired volunteer fields
                    foreach (ListItem desiredFieldItem in chkDesiredFields.Items)
                    {
                        if (desiredFieldItem.Selected)
                        {
                            _AssociatedFieldsManager.InsertFieldVolunteerDesired(int.Parse(desiredFieldItem.Value), volunteerId, transactionInstance);
                        }
                    }
                    //insert recommended volunteer fields
                    foreach (ListItem workFieldItem in chkRecommendedFields.Items)
                    {
                        if (workFieldItem.Selected)
                        {
                            _AssociatedFieldsManager.InsertFieldVolunteerWork(int.Parse(workFieldItem.Value), volunteerId, transactionInstance);
                        }
                    }
                    //insert Volunteer Languages fields
                    foreach (ListItem languageItem in chkLangVolunteer.Items)
                    {
                        if (languageItem.Selected)
                        {
                            _AssociatedLanguagesManager.InsertLanguageVolunteer(int.Parse(languageItem.Value), volunteerId, transactionInstance);
                        }
                    }
                    //insert Volunteer Skills fields
                    foreach (ListItem skillItem in chkSkillsVolunteer.Items)
                    {
                        if (skillItem.Selected)
                        {
                            _AssociatedSkillsManager.InsertSkillVolunteer(int.Parse(skillItem.Value), volunteerId, transactionInstance);
                        }
                    }

                    _AssociatedVolunteersManager.CommitTransaction();
                    lblVolunteerResult.Text = "تم إدخال بيانات المتطوع بنجاح";
                    lblVolunteerError.Text = string.Empty;
                    ResetVolunteerControlsToDefaultValue(Page);
                    #endregion
                }
                else if (btnAddVolunteer.Text == "تعديل بيانات المتطوع")
                {
                    #region Update existing volunteer
                    int volunteerId = int.Parse(Session["VolunteerId"].ToString());
                    volunteerInstance.VolunteerID = volunteerId;
                    _AssociatedVolunteersManager.UpdateVolunteer(volunteerInstance, transactionInstance);
                    //insert desired volunteer fields after deleting existing fields
                    _AssociatedFieldsManager.DeleteFieldVolunteerDesiredByVolunteerId(volunteerId);
                    foreach (ListItem desiredFieldItem in chkDesiredFields.Items)
                    {
                        if (desiredFieldItem.Selected)
                        {
                            _AssociatedFieldsManager.InsertFieldVolunteerDesired(int.Parse(desiredFieldItem.Value), volunteerId, transactionInstance);
                        }
                    }
                    //insert recommended volunteer fields after deleting exisiting fields
                    _AssociatedFieldsManager.DeleteFieldVolunteerWorkByVolunteerId(volunteerId);
                    foreach (ListItem workFieldItem in chkRecommendedFields.Items)
                    {
                        if (workFieldItem.Selected)
                        {
                            _AssociatedFieldsManager.InsertFieldVolunteerWork(int.Parse(workFieldItem.Value), volunteerId, transactionInstance);
                        }
                    }
                    //insert Volunteer Languages fields
                    _AssociatedLanguagesManager.DeleteVolunteerLanguagesByVolunteerId(volunteerId, transactionInstance);
                    foreach (ListItem languageItem in chkLangVolunteer.Items)
                    {
                        if (languageItem.Selected)
                        {
                            _AssociatedLanguagesManager.InsertLanguageVolunteer(int.Parse(languageItem.Value), volunteerId, transactionInstance);
                        }
                    }
                    //insert Volunteer Skills fields
                    _AssociatedSkillsManager.DeleteVolunteerSkillsByVolunteerId(volunteerId, transactionInstance);
                    foreach (ListItem skillItem in chkSkillsVolunteer.Items)
                    {
                        if (skillItem.Selected)
                        {
                            _AssociatedSkillsManager.InsertSkillVolunteer(int.Parse(skillItem.Value), volunteerId, transactionInstance);
                        }
                    }

                    _AssociatedVolunteersManager.CommitTransaction();
                    lblVolunteerResult.Text = "تم تعديل بيانات المتطوع بنجاح";
                    lblVolunteerError.Text = string.Empty;
                    Response.Redirect("VolunteersSearchResult.aspx?Update=true");
                    #endregion
                }

            }
            catch (Exception ex)
            {
                lblVolunteerResult.Text = string.Empty;
                lblVolunteerError.Text = ex.Message;
                _AssociatedVolunteersManager.RollBackTransaction();
            }
        }
    }
    protected void btnUploadPhoto_Click(object sender, EventArgs e)
    {
        if (fuPhoto.HasFile)
        {
            fuPhoto.SaveAs(Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuPhoto.FileName);
            hlnkPhoto.Text = fuPhoto.FileName;
            hlnkPhoto.Visible = true;
            hlnkPhoto.NavigateUrl = Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuPhoto.FileName;
            imgBtnRemovePhoto.Visible = true;
            fuPhoto.Visible = false;
            btnUploadPhoto.Visible = false;
        }
    }
    protected void btnUploadCv_Click(object sender, EventArgs e)
    {
        if (fuCv.HasFile)
        {
            fuCv.SaveAs(Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuCv.FileName);
            hlnkCv.Text = fuCv.FileName;
            hlnkCv.Visible = true;
            hlnkCv.NavigateUrl = Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuCv.FileName;
            imgBtnRemoveCv.Visible = true;
            fuCv.Visible = false;
            btnUploadCv.Visible = false;
        }
    }
    protected void btnUploadOtherFiles_Click(object sender, EventArgs e)
    {
        if (fuOtherFiles.HasFile)
        {
            fuOtherFiles.SaveAs(Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuOtherFiles.FileName);
            hlnkOtherFiles.Text = fuOtherFiles.FileName;
            hlnkOtherFiles.Visible = true;
            hlnkOtherFiles.NavigateUrl = Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuOtherFiles.FileName;
            imgBtnOtherFiles.Visible = true;
            fuOtherFiles.Visible = false;
            btnUploadOtherFiles.Visible = false;
        }
    }

    protected void imgBtnRemovePhoto_Click(object sender, ImageClickEventArgs e)
    {
        if (File.Exists(hlnkPhoto.NavigateUrl))
        {
            File.Delete(hlnkPhoto.NavigateUrl);
        }
        fuPhoto.Visible = true;
        imgBtnRemovePhoto.Visible = false;
        hlnkPhoto.Visible = false;
        hlnkPhoto.NavigateUrl = string.Empty;
        btnUploadPhoto.Visible = true;
    }
    protected void imgBtnRemoveCv_Click(object sender, ImageClickEventArgs e)
    {
        if (File.Exists(hlnkCv.NavigateUrl))
        {
            File.Delete(hlnkCv.NavigateUrl);
        }
        fuCv.Visible = true;
        imgBtnRemoveCv.Visible = false;
        hlnkCv.Visible = false;
        hlnkCv.NavigateUrl = string.Empty;
        btnUploadCv.Visible = true;
    }
    protected void imgBtnOtherFiles_Click(object sender, ImageClickEventArgs e)
    {
        if (File.Exists(hlnkOtherFiles.NavigateUrl))
        {
            File.Delete(hlnkOtherFiles.NavigateUrl);
        }
        fuOtherFiles.Visible = true;
        imgBtnOtherFiles.Visible = false;
        hlnkOtherFiles.Visible = false;
        hlnkOtherFiles.NavigateUrl = string.Empty;
        btnUploadOtherFiles.Visible = true;
    }

    private void ResetValiadationImagesToDefaultValue(Control BaseCtrl)
    {
        foreach (Control ctrl in BaseCtrl.Controls)
        {
            if (ctrl.HasControls())
            {
                ResetValiadationImagesToDefaultValue(ctrl);
            }
            else
            {
                if (ctrl.GetType() == typeof(Image))
                {
                    if (ctrl.ID.Contains("imgVolunteer"))
                    {
                        ctrl.Visible = false;
                    }
                }
            }
        }
    }
    private void ResetVolunteerControlsToDefaultValue(Control parentControl)
    {
        foreach (Control ctrl in parentControl.Controls)
        {
            if (ctrl.HasControls() && ctrl.GetType() != typeof(CheckBoxList))
            {
                ResetVolunteerControlsToDefaultValue(ctrl);
            }
            else
            {
                Type ctrlType = ctrl.GetType();
                if (ctrlType == typeof(TextBox))
                {
                    TextBox txtInstance = (TextBox)ctrl;
                    txtInstance.Text = string.Empty;
                }
                else if (ctrlType == typeof(DropDownList))
                {
                    DropDownList drpInstance = (DropDownList)ctrl;
                    drpInstance.SelectedValue = "Select";
                }
                else if (ctrlType == typeof(CheckBoxList))
                {
                    CheckBoxList chkInstance = (CheckBoxList)ctrl;
                    foreach (ListItem chkItem in chkInstance.Items)
                    {
                        chkItem.Selected = false;
                    }
                }
                else if (ctrlType == typeof(RadioButtonList))
                {
                    RadioButtonList rdbInstance = (RadioButtonList)ctrl;
                    rdbInstance.SelectedIndex = -1;
                }

            }
        }
    }

    protected void rdbMeetingDone_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbMeetingDone.SelectedValue == "لا")
        {
            lblMeetingApology.Visible = true;
            rdbMeetingApology.Visible = true;
            lblMeetingApologyDate.Visible = true;
            txtMeetingApologyDate.Visible = true;
            lblMeetingApologyPlace.Visible = true;
            drpMeetingApologyPlace.Visible = true;
            rdbMeetingApology.SelectedIndex = -1;
        }
        else if (rdbMeetingDone.SelectedValue == "نعم")
        {
            lblMeetingApology.Visible = false;
            rdbMeetingApology.Visible = false;
            lblMeetingApologyDate.Visible = false;
            txtMeetingApologyDate.Visible = false;
            lblMeetingApologyPlace.Visible = false;
            drpMeetingApologyPlace.Visible = false;
            drpMeetingApologyPlace.SelectedValue = "Select";
            txtMeetingApologyDate.Text = string.Empty;
        }
    }
}
