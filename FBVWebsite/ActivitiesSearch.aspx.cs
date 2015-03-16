using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FBV.DataAccessLayer;
using FBV.DataMapping;
using System.Data;
using System.Xml;
public partial class ActivitiesSearch : PageThatRequiresLogin 
{
    ActivitiesManager _AssociatedActivitiesManager = new ActivitiesManager();
    FieldsManager _AssociatedFieldsManager = new FieldsManager();
    DepartmentsManager _AssociatedDepartmentsManager = new DepartmentsManager();
    PlacesManager _AssociatedPlacesManager = new PlacesManager();
    MissionsManager _AssociatedMissionsManager = new MissionsManager();
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    UsersManager _AssociatedUsersManager = new UsersManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartmentsDropDown();
            BindFieldsDropDown();
            BindCitiesDropDown();
            BindActivityNames();
            BindDepartmentEvaluatorUsers();
            BindActivityMissionsCheckList();
        }
    }

    private void BindDepartmentEvaluatorUsers()
    {
        drpVolunteerDepartmentRep.Items.Clear();
        drpVolunteerDepartmentRep.Items.Add(new ListItem("إختار", "Select"));

        Department volunteersDepartment = _AssociatedDepartmentsManager.GetDepartmentByName("إدارة المتطوعين");
        if (volunteersDepartment != null)
        {
            int departmentId = volunteersDepartment.DepartmentID;
            DataTable allEvaluatorDepartmentUsers = _AssociatedUsersManager.GetUsersByDepartmentIdAndEvaluation(departmentId, true);
            foreach (DataRow dr in allEvaluatorDepartmentUsers.Rows)
            {
                drpVolunteerDepartmentRep.Items.Add(new ListItem(dr["UserFullname"].ToString(), dr["UserID"].ToString()));
            }
        }
    }
    private void BindActivityNames()
    {
        drpActivityName.Items.Clear();
        drpActivityName.Items.Add(new ListItem("إختار", "Select"));
        List <string > activityNames = _AssociatedActivitiesManager.GetActivityNames();
        if (activityNames != null)
        {
            foreach (string activityName in activityNames)
            {
                drpActivityName.Items.Add(new ListItem(activityName, activityName));
            }
        }
    }

    private void BindPlacesDropDown(int CityId)
    {
        drpActivityPlace.Items.Clear();
        drpActivityPlace.Items.Add(new ListItem("إختار", "Select"));
        DataTable cityPlaces = _AssociatedPlacesManager.GetPlacesByCityId(CityId);
        foreach (DataRow dr in cityPlaces.Rows)
        {
            drpActivityPlace.Items.Add(new ListItem(dr["PlaceName"].ToString(), dr["PlaceID"].ToString()));
        }
    }
    private void BindFieldsDropDown()
    {
        drpActivityField.Items.Clear();
        drpActivityField.Items.Add(new ListItem("إختار", "Select"));
        DataTable allFields = _AssociatedFieldsManager.GetAllFields();
        foreach (DataRow dr in allFields.Rows)
        {
            drpActivityField.Items.Add(new ListItem(dr["FieldName"].ToString(), dr["FieldID"].ToString()));
        }
    }
    private void BindDepartmentsDropDown()
    {
        drpDepartment.Items.Clear();
        drpDepartment.Items.Add(new ListItem("إختار", "Select"));
        DataTable allDepartments = _AssociatedDepartmentsManager.GetAllDepartments();
        foreach (DataRow dr in allDepartments.Rows)
        {
            drpDepartment.Items.Add(new ListItem(dr["DepartmentName"].ToString(), dr["DepartmentID"].ToString()));
        }
    }
    private void BindActivityMissionsCheckList()
    {
        chkTypeOfMissions.Items.Clear();
        DataTable MissionsTable = _AssociatedMissionsManager.GetAllMissions ();
        foreach (DataRow dr in MissionsTable.Rows)
        {
            chkTypeOfMissions.Items.Add(new ListItem(dr["MissionName"].ToString(), dr["MissionID"].ToString()));
        }
    }
    private void BindCitiesDropDown()
    {
        drpActivityCity.Items.Clear();
        drpActivityCity.Items.Add(new ListItem("إختار", "Select"));
        DataTable allCities = _AssociatedCitiesManager.GetAllCities();
        foreach (DataRow dr in allCities.Rows)
        {
            drpActivityCity.Items.Add(new ListItem(dr["CityName"].ToString(), dr["CityID"].ToString()));
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //load a session variable with the user's search criteria
        ActivitySearchRecord searchRecord = new ActivitySearchRecord();
        if (drpActivityCity.SelectedValue == "Select")
            searchRecord.ActivityCityID = null;
        else
            searchRecord.ActivityCityID =int.Parse( drpActivityCity.SelectedValue );

        if (txtActivityCodeNo.Text == string.Empty)
            searchRecord.ActivityCodeNo = null;
        else
            searchRecord.ActivityCodeNo = int.Parse(txtActivityCodeNo.Text);

        if (txtActivityFrom.Text == string.Empty)
            searchRecord.ActivityDateFrom = null;
        else
        searchRecord.ActivityDateFrom =DateTime.Parse( txtActivityFrom.Text);

        if (txtActivityTo.Text == string.Empty)
            searchRecord.ActivityDateTo = null;
        else
        searchRecord.ActivityDateTo =DateTime.Parse( txtActivityTo.Text);

    


        if (drpDepartment.SelectedValue == "Select")
            searchRecord.ActivityDepartmentId = null;
        else
        searchRecord.ActivityDepartmentId = int .Parse( drpDepartment.SelectedValue);

        if (drpActivityField.SelectedValue == "Select")
            searchRecord.ActivityFieldID = null;
        else
        searchRecord.ActivityFieldID = int.Parse(drpActivityField.SelectedValue);

        #region Add Activity's mission IDs
        //Add the the desired fiels in the following form ('<Root><Missions missionid="ALFKI"/>
        //                                                                            <Missions missionid="BONAP"/>
        //                                                                            <Missions missionid="CACTU"/>
        //                                                                             <Missions missionid="FRANK"/>
        //                                                                              </Root>'
        XmlDocument xmlDoc = new XmlDocument();
        XmlElement xmlRoot = xmlDoc.CreateElement("Root");
        xmlDoc.AppendChild(xmlRoot);
        bool hasValue = false;
        foreach (ListItem item in chkTypeOfMissions.Items)
        {
            if (item.Selected)
            {
                XmlNode xmlFields = xmlDoc.CreateElement("Missions");
                XmlAttribute xmlField = xmlDoc.CreateAttribute("missionid");
                xmlField.Value = item.Value;
                xmlFields.Attributes.Append(xmlField);
                xmlRoot.AppendChild(xmlFields);
                hasValue = true;
            }
        }
        if (hasValue == true)
        {
            searchRecord.ActivityMissionsIDs  = xmlDoc.InnerXml;
        }
        else
        {
            searchRecord.ActivityMissionsIDs = null;
        }
        #endregion

        if (drpActivityPlace.SelectedValue == "Select")
            searchRecord.ActivityPlaceID = null;
        else
        searchRecord.ActivityPlaceID =int.Parse( drpActivityPlace.SelectedValue);

        if (txtRequestDateFrom.Text == string.Empty)
            searchRecord.ActivityRequestDateFrom = null;
        else
        searchRecord.ActivityRequestDateFrom = DateTime.Parse( txtRequestDateFrom.Text);

        if (txtRequestDateTo.Text == string.Empty)
            searchRecord.ActivityRequestDateTo = null;
        else
        searchRecord.ActivityRequestDateTo = DateTime.Parse( txtRequestDateTo.Text);

        if (drpActivityName.SelectedValue == "Select")
            searchRecord.ActivityName  = null;
        else
            searchRecord.ActivityName = drpActivityName.SelectedValue;

        if (txtActivityDaysCountFrom .Text == string.Empty)
            searchRecord.ActivityDaysCountFrom  = null;
        else
            searchRecord.ActivityDaysCountFrom = int.Parse(txtActivityDaysCountFrom.Text);

        if (txtActivityDaysCountTo.Text == string.Empty)
            searchRecord.ActivityDaysCountTo = null;
        else
            searchRecord.ActivityDaysCountTo = int.Parse(txtActivityDaysCountTo.Text);

        if (txtVolunteersCountFrom .Text == string.Empty)
            searchRecord.VolunteersCountFrom = null;
        else
            searchRecord.VolunteersCountFrom  = int.Parse(txtVolunteersCountFrom.Text);

        if (txtVolunteersCountTo.Text == string.Empty)
            searchRecord.VolunteersCountTo= null;
        else
            searchRecord.VolunteersCountTo = int.Parse(txtVolunteersCountTo.Text);

        if (txtActivityHoursFrom.Text == string.Empty)
            searchRecord.ActivityHoursFrom = null;
        else
            searchRecord.ActivityHoursFrom = int.Parse(txtActivityHoursFrom.Text);

        if (txtActivityHoursTo.Text == string.Empty)
            searchRecord.ActivityHoursTo= null;
        else
            searchRecord.ActivityHoursTo = int.Parse(txtActivityHoursTo.Text);

        Session["SearchRecord"] = searchRecord;

        Response.Redirect("ActivitiesSearchResult.aspx");
    }

    protected void drpActivityCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpActivityCity.SelectedValue != "Select")
        {
            BindPlacesDropDown(int.Parse(drpActivityCity.SelectedValue));
        }
        else
        {
            drpActivityPlace.Items.Clear();
            drpActivityPlace.Items.Add(new ListItem("إختار", "Select"));
        }
    }

    public override bool CheckPermission()
    {
        if (CurrentUser.UAccessLevel == (int) UserAccessLevel.Administrator)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
