using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FBV.DataAccessLayer;
using FBV.DataMapping;
using System.Xml;
public partial class VolunteersSearch : PageThatRequiresLogin
{
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    AreasManager _AssociatedAreasManager = new AreasManager();
    EducationManager _AssociatedEducationManager = new EducationManager();
    FacUniversitiesManager _AssociatedUniversitiesManager = new FacUniversitiesManager();
    EduFacultiesManager _AssociatedFacultiesManager = new EduFacultiesManager();
    JobPlacesManager _AssociatedJobPlacesManager = new JobPlacesManager();
    FieldsManager _AssociatedFieldsManager = new FieldsManager();
    PlacesManager _AssociatedPlacesManager = new PlacesManager();
    MarketingManager _AssociatedMarketingManager = new MarketingManager();
    SchoolsManager _AssociatedSchoolsManager = new SchoolsManager();
    SkillsManager _AssociatedSkillsManager = new SkillsManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindCitiesDropDown();
            BindJobPlacesDropDown();
            BindEducationDropDown();
            BindUniversitiesDropDown();
            BindFieldsChkLists();
            BindPlacesDropDowns();
            BindKnowDropDwon();
            BindSchoolsDropDwon();

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
    private void BindKnowDropDwon()
    {
        drpKnow.Items.Clear();
        drpKnow.Items.Add(new ListItem("إختار", "Select"));
        DataTable allMarketing = _AssociatedMarketingManager.GetAllMarketing();
        foreach (DataRow dr in allMarketing.Rows)
        {
            drpKnow.Items.Add(new ListItem(dr["MarketName"].ToString(), dr["MarketingID"].ToString()));
        }
    }
    public void   BindPlacesDropDowns()
    {
        drpMeetingPlace.Items.Clear();
        drpRegisterationPlace.Items.Clear();
        drpFirstContactPlace.Items.Clear();
        drpMeetingPlace.Items.Add(new ListItem("إختار", "Select"));
        drpRegisterationPlace.Items.Add(new ListItem("إختار", "Select"));
        drpFirstContactPlace.Items.Add(new ListItem("إختار", "Select"));

        DataTable allPlaces = _AssociatedPlacesManager.GetAllPlaces();
        foreach (DataRow dr in allPlaces.Rows)
        {
            drpMeetingPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
            drpRegisterationPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
            drpFirstContactPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
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
    private void BindJobPlacesDropDown()
    {
        drpJobPlace.Items.Clear();
        drpJobPlace.Items.Add(new ListItem("إختار", "Select"));
        DataTable allJobPlaces = _AssociatedJobPlacesManager.GetAllJobPlaces();
        foreach (DataRow dr in allJobPlaces.Rows)
        {
            drpJobPlace.Items.Add(new ListItem(dr["JobPlaceName"].ToString(), dr["JobPlaceID"].ToString()));
        }
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
        chkAvFields.Items.Clear();
        chkNvFields.Items.Clear();
        chkRecommendedVolunteerFields.Items.Clear();
        DataTable desiredFields = _AssociatedFieldsManager.GetAllFields();
        foreach (DataRow dr in desiredFields.Rows)
        {
            chkDesiredFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
            chkRecommendedFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
            chkAvFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
            chkNvFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
            chkRecommendedVolunteerFields.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //load a session variable with the user's search criteria
        VolunteerSearchRecord searchRecord = new VolunteerSearchRecord();

        if (txtBirthDateFrom.Text == string.Empty)
            searchRecord.vBirthDateFrom = null;
        else
            searchRecord.vBirthDateFrom = DateTime.Parse(txtBirthDateFrom.Text);

        if (txtBirthDateTo.Text == string.Empty)
            searchRecord.vBirthDateTo = null;
        else
            searchRecord.vBirthDateTo = DateTime.Parse(txtBirthDateTo.Text);

        if (txtRegisterDate.Text == string.Empty)
            searchRecord.vRegisterDate = null;
        else
            searchRecord.vRegisterDate = DateTime.Parse(txtRegisterDate.Text);

        if (txtVolunteerName.Text == string.Empty)
            searchRecord.vName = null;
        else
            searchRecord.vName = txtVolunteerName.Text;

        if (txtVolunteerManIdStart.Text == string.Empty)
            searchRecord.VolunteerManIdStart = null;
        else
            searchRecord.VolunteerManIdStart = int.Parse(txtVolunteerManIdStart.Text);

        if (txtVolunteerManIdEnd.Text == string.Empty)
            searchRecord.VolunteerManIdEnd = null;
        else
            searchRecord.VolunteerManIdEnd = int.Parse(txtVolunteerManIdEnd.Text);

        if (drpArea.SelectedValue == "Select")
            searchRecord.vAreaID = null;
        else
            searchRecord.vAreaID = int.Parse(drpArea.SelectedValue);

        if (drpCity.SelectedValue == "Select")
            searchRecord.vCityID = null;
        else
            searchRecord.vCityID = int.Parse(drpCity.SelectedValue);

        if (drpEducation.SelectedValue == "Select")
            searchRecord.vEducationID = null;
        else
            searchRecord.vEducationID = int.Parse(drpEducation.SelectedValue);

        if (drpFaculty.SelectedValue == "Select")
            searchRecord.VFacultyID = null;
        else
            searchRecord.VFacultyID = int.Parse(drpFaculty.SelectedValue);

        if (drpJobPlace.SelectedValue == "Select")
            searchRecord.vJobPlaceID = null;
        else
            searchRecord.vJobPlaceID = int.Parse(drpJobPlace.SelectedValue);

        #region Add desired Fields
        //Add the the desired fiels in the following form ('<Root><Fields fieldid="ALFKI"/>
        //                                                                            <Fields fieldid="BONAP"/>
        //                                                                            <Fields fieldid="CACTU"/>
        //                                                                             <Fields fieldid="FRANK"/>
        //                                                                              </Root>'
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
        bool hasValue = false;
        foreach (ListItem item in chkDesiredFields.Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Fields");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("fieldid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.vDesiredFields = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.vDesiredFields = null;
        }
        #endregion

        #region Add recommended fields
        //Add the the recommended fields in the following form ('<Root><Fields fieldid="ALFKI"/>
        //                                                                            <Fields fieldid="BONAP"/>
        //                                                                            <Fields fieldid="CACTU"/>
        //                                                                             <Fields fieldid="FRANK"/>
        //                                                                              </Root>'
         xmlDoc = new XmlDocument();
         xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
         hasValue = false;
        foreach (ListItem item in chkRecommendedFields .Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Fields");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("fieldid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.vRecommendedFields  = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.vRecommendedFields = null;
        }
        #endregion

        #region Add Volunteer Skills
        //Add the volunteer skills  in the following form ('<Root><Skills skillid="ALFKI"/>
        //                                                                            <Skills skillid="BONAP"/>
        //                                                                            <Skills skillid="CACTU"/>
        //                                                                             <Skills skillid="FRANK"/>
        //                                                                              </Root>'
        xmlDoc = new XmlDocument();
        xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
        hasValue = false;
        foreach (ListItem item in chkSkillsVolunteer.Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Skills");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("skillid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.vSkills = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.vSkills = null;
        }
        #endregion

        #region Add Active Volunteers Fields
        xmlDoc = new XmlDocument();
        xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
        hasValue = false;
        foreach (ListItem item in chkAvFields.Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Fields");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("fieldid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.AvFields  = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.AvFields = null;
        }
        #endregion

        #region Add New Volunteers Fields
        xmlDoc = new XmlDocument();
        xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
        hasValue = false;
        foreach (ListItem item in chkNvFields.Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Fields");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("fieldid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.NvFields = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.NvFields = null;
        }
        #endregion

        #region Add Volunteer Recommended Fields
        xmlDoc = new XmlDocument();
        xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
        hasValue = false;
        foreach (ListItem item in chkRecommendedVolunteerFields .Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Fields");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("fieldid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.vRecommendedVolunteerFields = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.vRecommendedVolunteerFields = null;
        }
        #endregion

        if (txtAvActivityStartDate .Text == string.Empty)
            searchRecord.AvActivityStartDate = null;
        else
            searchRecord.AvActivityStartDate = DateTime .Parse(txtAvActivityStartDate.Text);

        if (txtAvActivityEndDate.Text == string.Empty)
            searchRecord.AvActivityEndDate = null;
        else
            searchRecord.AvActivityEndDate = DateTime.Parse(txtAvActivityEndDate.Text);

        if (txtAvActivityCodeNoStart .Text == string.Empty)
            searchRecord.AvActivityCodeNoStart  = null;
        else
            searchRecord.AvActivityCodeNoStart = int.Parse(txtAvActivityCodeNoStart.Text);

        if (txtAvActivityCodeNoEnd.Text == string.Empty)
            searchRecord.AvActivityCodeNoEnd = null;
        else
            searchRecord.AvActivityCodeNoEnd = int.Parse(txtAvActivityCodeNoEnd.Text);

        if (txtNvActivityStartDate.Text == string.Empty)
            searchRecord.NvActivityStartDate = null;
        else
            searchRecord.NvActivityStartDate = DateTime.Parse(txtNvActivityStartDate.Text);

        if (txtNvActivityEndDate.Text == string.Empty)
            searchRecord.NvActivityEndDate = null;
        else
            searchRecord.NvActivityEndDate = DateTime.Parse(txtNvActivityEndDate.Text);

        if (txtNvActivityCodeNoStart.Text == string.Empty)
            searchRecord.NvActivityCodeNoStart = null;
        else
            searchRecord.NvActivityCodeNoStart = int.Parse(txtNvActivityCodeNoStart.Text);

        if (txtNvActivityCodeNoEnd.Text == string.Empty)
            searchRecord.NvActivityCodeNoEnd = null;
        else
            searchRecord.NvActivityCodeNoEnd = int.Parse(txtNvActivityCodeNoEnd.Text);

        if (drpKnow.SelectedValue == "Select")
            searchRecord.vKnow = null;
        else
            searchRecord.vKnow = int.Parse(drpKnow.SelectedValue);

        if (drpUniversity.SelectedValue == "Select")
            searchRecord.VUniversityID = null;
        else
            searchRecord.VUniversityID = int.Parse(drpUniversity.SelectedValue);

        if (drpMeetingPlace.SelectedValue == "Select")
            searchRecord.vMeetingPlaceID = null;
        else
            searchRecord.vMeetingPlaceID = int.Parse(drpMeetingPlace.SelectedValue);

        if (txtMeetingDate.Text == string.Empty)
            searchRecord.vMeetingDate = null;
        else
            searchRecord.vMeetingDate = DateTime.Parse(txtMeetingDate.Text);

        if (drpRegisterationPlace.SelectedValue == "Select")
            searchRecord.vRegistrationPlaceID = null;
        else
            searchRecord.vRegistrationPlaceID = int.Parse(drpRegisterationPlace.SelectedValue);

        if (txtRegisterDate.Text == string.Empty)
            searchRecord.vRegisterDate = null;
        else
            searchRecord.vRegisterDate = DateTime.Parse(txtRegisterDate.Text);

        if (drpFirstContactPlace.SelectedValue == "Select")
            searchRecord.vFirstContactPlaceID = null;
        else
            searchRecord.vFirstContactPlaceID = int.Parse(drpFirstContactPlace.SelectedValue);

        if (txtFirstContactDate.Text == string.Empty)
            searchRecord.vFirstContactDate = null;
        else
            searchRecord.vFirstContactDate = DateTime.Parse(txtFirstContactDate.Text);

        if (drpSchool.SelectedValue == "Select")
            searchRecord.vSchool = null;
        else
            searchRecord.vSchool = int.Parse(drpSchool.SelectedValue);


        Session["VolunteerSearchRecord"] = searchRecord;

        Response.Redirect("VolunteersSearchResult.aspx");
    }
  
}
