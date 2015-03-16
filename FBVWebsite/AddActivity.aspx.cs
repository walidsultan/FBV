using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using FBV.DataAccessLayer;
using FBV.DataMapping;
using System.IO;
using System.Drawing;
public partial class AddActivity : PageThatRequiresLogin
{
    #region DataAccessLayer declarations
    ActivitiesManager _AssociatedActivitiesManager = new ActivitiesManager();
    FieldsManager _AssociatedFieldsManager = new FieldsManager();
    DepartmentsManager _AssociatedDepartmentsManager = new DepartmentsManager();
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();
    PlacesManager _AssociatedPlacesManager = new PlacesManager();
    UsersManager _AssociatedUsersManager = new UsersManager();
    MissionsManager _AssociatedMissionsManager = new MissionsManager();
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    SkillsManager _AssociatedSkillsManager = new SkillsManager();
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDepartmentsDropDown();
            BindFieldsDropDown();
            BindDepartmentEvaluatorUsers();
            BindPlacesDropDown();
            BindAttendanceStateDropDown();
            lblTitle.Text = "قاعدة بيانات الأنشطة – صفحة الإضافة";
            if (Request.QueryString["Edit"] == "true")
            {
                BindActivityData(int.Parse(Session["ActivityId"].ToString()));
            }
        }
        Control postBackControl = GetPostBackControl(this.Page);
        if (postBackControl != null)
        {
            if (postBackControl.ID == "lnkVolunteerDepartmentEvaluation" || postBackControl.ID == "lnkActivityDepartmentEvaluation" || postBackControl.ID == "btnFinishEvaluation")
            {
                int volunteerId = 0;
                if (ViewState["EvaluationVolunteerId"] != null)
                {
                    volunteerId = int.Parse(ViewState["EvaluationVolunteerId"].ToString());
                }
                if (postBackControl.GetType() == typeof(LinkButton))
                {
                    LinkButton lnkEvaluation = (LinkButton)postBackControl;
                    volunteerId = int.Parse(lnkEvaluation.CommandArgument);
                }
                GenerateVolunteerMissionsAndSkills(volunteerId);
            }
        }

        btnAddActivity.OnClientClick = "$.blockUI({ message: '<h2>... جارى التحميل</h2>'  ,  css: {border: 'none',padding: '15px',backgroundColor: '#000',opacity: '.5',color: '#fff','-webkit-border-radius': '10px','-moz-border-radius': '10px', filter: 'alpha(opacity=70)' }  });";
    }

    private void BindAttendanceStateDropDown()
    {
        drpAttendanceState.Items.Clear();
        drpAttendanceState.Items.Add(new ListItem("إختار", "Select"));
        foreach (AttendanceState state in Enum.GetValues(typeof(AttendanceState)))
        {
            drpAttendanceState.Items.Add(new ListItem(Enum.GetName(typeof(AttendanceState), (int)state).Replace("_", " "), ((int)state).ToString()));
        }
    }

    /// <summary>
    /// Customized to work with link buttons only
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public static Control GetPostBackControl(Page page)
    {
        Control control = null;

        string ctrlname = page.Request.Params.Get("__EVENTTARGET");
        if (ctrlname != null && ctrlname != string.Empty)
        {
            control = page.FindControl(ctrlname);
        }
        else
        {
            foreach (string ctl in page.Request.Form)
            {
                Control c = page.FindControl(ctl);
                if (c is System.Web.UI.WebControls.Button)
                {
                    control = c;
                    break;
                }
            }
        }
        return control;
    }

    #region Activity Binding Methods
    private void BindActivityData(int ActivityId)
    {
        Activity activityInstance = _AssociatedActivitiesManager.GetActivitiesByActivityID(ActivityId);

        #region Bind activity text boxes
        if (activityInstance.ActivityCodeNo != null)
            txtActivityCodeNo.Text = activityInstance.ActivityCodeNo.Value.ToString();

        if (activityInstance.ActivityCost != null)
            txtActivityCost.Text = activityInstance.ActivityCost.Value.ToString();

        txtActivityDateFrom.Text = activityInstance.ActivityDateFrom.ToShortDateString();
        txtActivityDateTo.Text = activityInstance.ActivityDateTo.ToShortDateString();
        txtActivityDateTo_TextChanged(this, new EventArgs());
        txtActivityDetails.Text = activityInstance.ActivityDetails;

        if (!string.IsNullOrEmpty(activityInstance.ActivityDocument))
        {
            hlnkActivityDocument.NavigateUrl = activityInstance.ActivityDocument;
            hlnkActivityDocument.Text = Path.GetFileName(activityInstance.ActivityDocument);
            hlnkActivityDocument.Visible = true;
            fuActivityDocument.Visible = false;
            btnUploadActivityDocument.Visible = false;
            imgBtnRemoveActivityDocument.Visible = true;
        }

        txtActivityName.Text = activityInstance.ActivityName;

        if (activityInstance.ActivityRequestDate.HasValue)
            txtActivityRequestDate.Text = activityInstance.ActivityRequestDate.Value.ToShortDateString();

        if (!string.IsNullOrEmpty(activityInstance.ActivityDepartmentOpinion))
        {
            ViewState["ActivityRequirements"] = activityInstance.ActivityRequirments;
            imgActivityRequirments.Visible = true;
        }
       

        if (activityInstance.ActivityRevenue != null)
            txtActivityRevenue.Text = activityInstance.ActivityRevenue.Value.ToString();
        if (activityInstance.ActivityRequiredVolunteers.HasValue)
            txtActivityRequiredVolunteers.Text = activityInstance.ActivityRequiredVolunteers.Value.ToString();
        if (activityInstance.ActivityComments != null)
            txtActivityComments.Text = activityInstance.ActivityComments;
        if (!string.IsNullOrEmpty( activityInstance.ActivityDepartmentOpinion))
        {
            ViewState["ActivityDepartmentOpinion"] = activityInstance.ActivityDepartmentOpinion;
            imgActivityDepartmentOpinion.Visible = true;
        }
        if (!string.IsNullOrEmpty(activityInstance.ActivityVolunteerDepartmentOpinion))
        {
            ViewState["ActivityVolunteerDepartmentOpinion"] = activityInstance.ActivityVolunteerDepartmentOpinion;
            imgActivityVolunteerDepartmentOpinion.Visible = true;
        }
        #endregion

        #region Bind activity drop downs
        drpActivityField.SelectedValue = activityInstance.ActivityFieldID.ToString();
        drpActivityField.Enabled = false;
        chkVolunteerMissions.Enabled = false;
        BindVolunteersDropDown(activityInstance.ActivityFieldID);
        BindActivityMissionsCheckList(activityInstance.ActivityFieldID);
        //bind the places for the selected city
        BindPlacesDropDown();
        drpActivityPlace.SelectedValue = activityInstance.ActivityPlaceID.ToString();
        #endregion

        #region Bind activity missions check list

        DataTable activityMissions = _AssociatedActivitiesManager.GetActivityMissionsByActivityId(ActivityId);
        foreach (DataRow dr in activityMissions.Rows)
        {
            ListItem missionListItem = chkVolunteerMissions.Items.FindByValue(dr["MissionId"].ToString());
            missionListItem.Selected = true;
        }

        #endregion

        #region Bind activity result table
        DataTable activityResult = _AssociatedActivitiesManager.GetActivityResultsByActivityId(ActivityId);
        //create the schema of the activity days table, the grid view schema is different
        //from the table retrieved from the database
        CreateActivityResultDatatable();
        DataTable gvActivityResult = (DataTable)ViewState["ActivityResultTable"];
        int resultIndex = 1;
        foreach (DataRow dr in activityResult.Rows)
        {
            DataRow newRow = gvActivityResult.NewRow();
            newRow["ActivityDay"] = DateTime.Parse(dr["RDay"].ToString()).ToShortDateString();
            newRow["Volunteer"] = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(dr["RVolunteerID"].ToString())).vName;
            DataTable resultMissionsTable = _AssociatedMissionsManager.GetResultMissionsByResultId(int.Parse(dr["ResultID"].ToString()));
            string resultMissions = string.Empty;
            string resultMissionIds = string.Empty;
            foreach (DataRow drMissions in resultMissionsTable.Rows)
            {
                Mission missionInstance = _AssociatedMissionsManager.GetMissionByMissionId(int.Parse(drMissions["RMissionID"].ToString()));
                if (resultMissions == string.Empty)
                {
                    resultMissions = missionInstance.MissionName;
                    resultMissionIds = missionInstance.MissionID.ToString();
                }
                else
                {
                    resultMissions += "," + missionInstance.MissionName;
                    resultMissionIds += "," + missionInstance.MissionID.ToString();
                }
            }
            newRow["VolunteerMissions"] = resultMissions;
            newRow["VolunteerMissionsId"] = resultMissionIds;
            newRow["WorkingTimeFrom"] = dr["RVolTimeFrom"].ToString();
            newRow["WorkingTimeTo"] = dr["RVolTimeTo"].ToString();
            //newRow["VolunteerWorkingHours"] = Math.Round(decimal.Parse(dr["RVolTimeTo"].ToString()) - decimal.Parse(dr["RVolTimeFrom"].ToString()), 2).ToString();
            newRow["VolunteerId"] = dr["RVolunteerID"].ToString();
            newRow["VolunteerWorkDetails"] = dr["RVolWorkDetails"].ToString();
            newRow["ResultIndex"] = resultIndex;
            newRow["ResultId"] = dr["ResultID"].ToString();

            gvActivityResult.Rows.Add(newRow);

            resultIndex++;
        }

        ViewState["ActivityResultTableAll"] = gvActivityResult;

        if (gvActivityResult.Rows.Count > 0)
        {
            grdActivityDays.DataSource = gvActivityResult;
            grdActivityDays.DataBind();
        }
        else
        {
            grdActivityDays.DataBind();
        }
        if (grdActivityDays.Rows.Count > 0)
        {
            lnkAddDayDetailsReal.Visible = true;
        }
        else
        {
            lnkAddDayDetailsReal.Visible = false;
        }
        #endregion

        #region Bind activity result Real table
        DataTable activityResultReal = _AssociatedActivitiesManager.GetActivityResultsRealByActivityId(ActivityId);
        //create the schema of the activity days table, the grid view schema is different
        //from the table retrieved from the database
        CreateActivityResultRealDatatable();
        DataTable gvActivityResultReal = (DataTable)ViewState["ActivityResultRealTable"];
        int resultRealIndex = 1;
        foreach (DataRow dr in activityResultReal.Rows)
        {
            DataRow newRow = gvActivityResultReal.NewRow();
            newRow["ActivityDay"] = DateTime.Parse(dr["RDay"].ToString()).ToShortDateString();
            newRow["Volunteer"] = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(dr["RVolunteerID"].ToString())).vName;
            DataTable resultMissionsTable = _AssociatedMissionsManager.GetResultRealMissionsByResultId(int.Parse(dr["ResultID"].ToString()));
            string resultMissions = string.Empty;
            string resultMissionIds = string.Empty;
            foreach (DataRow drMissions in resultMissionsTable.Rows)
            {
                Mission missionInstance = _AssociatedMissionsManager.GetMissionByMissionId(int.Parse(drMissions["RMissionID"].ToString()));
                if (resultMissions == string.Empty)
                {
                    resultMissions = missionInstance.MissionName;
                    resultMissionIds = missionInstance.MissionID.ToString();
                }
                else
                {
                    resultMissions += "," + missionInstance.MissionName;
                    resultMissionIds += "," + missionInstance.MissionID.ToString();
                }
            }
            newRow["VolunteerMissions"] = resultMissions;
            newRow["VolunteerMissionsId"] = resultMissionIds;
            newRow["WorkingTimeFrom"] = dr["RVolTimeFrom"].ToString();
            newRow["WorkingTimeTo"] = dr["RVolTimeTo"].ToString();
            //newRow["VolunteerWorkingHours"] = Math.Round(decimal.Parse(dr["RVolTimeTo"].ToString()) - decimal.Parse(dr["RVolTimeFrom"].ToString()), 2).ToString();
            newRow["VolunteerId"] = dr["RVolunteerID"].ToString();
            newRow["VolunteerWorkDetails"] = dr["RVolWorkDetails"].ToString();
            newRow["ResultIndex"] = resultRealIndex;
            newRow["ResultId"] = dr["ResultID"].ToString();
            newRow["VolunteerAttendanceStateId"] = dr["RAttendanceState"].ToString();
            if (dr["RAttendanceState"].ToString() != string.Empty)
            {
                newRow["VolunteerAttendanceState"] = Enum.GetName(typeof(AttendanceState), int.Parse(dr["RAttendanceState"].ToString()));
            }

            gvActivityResultReal.Rows.Add(newRow);

            resultRealIndex++;
        }

        ViewState["ActivityResultRealTableAll"] = gvActivityResultReal;

        if (gvActivityResultReal.Rows.Count > 0)
        {
            grdActivityDaysReal.DataSource = gvActivityResultReal;
            grdActivityDaysReal.DataBind();
        }
        else
        {
            grdActivityDaysReal.DataBind();
        }

        #endregion

        #region Bind departments table
        DataTable activityDepartments = _AssociatedActivitiesManager.GetActivityDepartmentsByActivityId(ActivityId);
        CreateDepartmentsDatatable();
        DataTable gvActivityDepartments = (DataTable)ViewState["DepartmentsTable"];
        int departmentIndex = 1;
        foreach (DataRow dr in activityDepartments.Rows)
        {
            DataRow newRow = gvActivityDepartments.NewRow();
            newRow["Department"] = _AssociatedDepartmentsManager.GetDepartmentById(int.Parse(dr["DepartmentID"].ToString())).DepartmentName;
            newRow["DepartmentId"] = dr["DepartmentID"].ToString();
            newRow["DepartmentResponsibleUser"] = _AssociatedUsersManager.GetUserByUserId(int.Parse(dr["UserID"].ToString())).UserFullname;
            newRow["DepartmentResponsibleUserId"] = dr["UserID"].ToString();
            newRow["DepartmentIndex"] = departmentIndex.ToString();

            gvActivityDepartments.Rows.Add(newRow);

            departmentIndex++;
        }
        if (gvActivityDepartments.Rows.Count > 0)
        {
            grdDepartments.DataSource = gvActivityDepartments;
            grdDepartments.DataBind();
        }
        else
        {
            grdDepartments.DataBind();
        }

        BindDepartmentEvaluatorUsers();
        drpVolunteerDepartmentResponsibleUser.SelectedValue = activityInstance.ActivityEvaluatorID.ToString();
        #endregion

        #region Bind activity evaluation skills table
        DataTable evaluationSkillsTable = _AssociatedActivitiesManager.ActivityEvaluationSkillsGetByActivityId(ActivityId);
        CreateSkillsEvaluationDatatable();
        DataTable gvActivityEvaluationSkills = (DataTable)ViewState["SkillsEvaluationTable"];
        foreach (DataRow dr in evaluationSkillsTable.Rows)
        {
            DataRow newEvaluationSkillRow = gvActivityEvaluationSkills.NewRow();
            newEvaluationSkillRow["ESkillId"] = dr["ESkillID"].ToString();
            newEvaluationSkillRow["ESkillLevelId"] = dr["ESkillLevel"].ToString();
            if (dr["EDepartmentID"].ToString() == string.Empty)
                newEvaluationSkillRow["EDepartmentId"] = "ActivityDepartment";
            else
                newEvaluationSkillRow["EDepartmentId"] = dr["EDepartmentId"].ToString();
            newEvaluationSkillRow["ESkillComments"] = dr["ESkillComments"].ToString();
            newEvaluationSkillRow["EVolunteerId"] = _AssociatedActivitiesManager.GetActivityEvaluationByEvaluationId(int.Parse(dr["EvaluationID"].ToString())).EVolunteerID;

            gvActivityEvaluationSkills.Rows.Add(newEvaluationSkillRow);
        }

        if (gvActivityEvaluationSkills.Rows.Count > 0)
        {
            ViewState["SkillsEvaluationTable"] = gvActivityEvaluationSkills;
        }

        #endregion

        #region Bind activity evaluation missions table
        DataTable evaluationMissionsTable = _AssociatedActivitiesManager.ActivityEvaluationMissionsGetByActivityId(ActivityId);
        CreateMissionsEvaluationDatatable();
        DataTable gvActivityEvaluationMissions = (DataTable)ViewState["MissionsEvaluationTable"];
        foreach (DataRow dr in evaluationMissionsTable.Rows)
        {
            DataRow newEvaluationMissionRow = gvActivityEvaluationMissions.NewRow();
            newEvaluationMissionRow["EMissionId"] = dr["EMissionID"].ToString();
            newEvaluationMissionRow["EMissionLevelId"] = dr["EMissionLevel"].ToString();
            if (dr["EDepartmentID"].ToString() == string.Empty)
                newEvaluationMissionRow["EDepartmentId"] = "ActivityDepartment";
            else
                newEvaluationMissionRow["EDepartmentId"] = dr["EDepartmentID"].ToString();
            newEvaluationMissionRow["EMissionComments"] = dr["EMissionComments"].ToString();
            newEvaluationMissionRow["EVolunteerId"] = _AssociatedActivitiesManager.GetActivityEvaluationByEvaluationId(int.Parse(dr["EvaluationID"].ToString())).EVolunteerID;

            gvActivityEvaluationMissions.Rows.Add(newEvaluationMissionRow);
        }

        if (gvActivityEvaluationMissions.Rows.Count > 0)
        {
            ViewState["MissionsEvaluationTable"] = gvActivityEvaluationMissions;
        }

        #endregion

        #region Bind activity evaluation table
        DataTable evaluationTable = _AssociatedActivitiesManager.GetActivityEvaluationByActivityId(ActivityId);
        CreateEvaluationDatatable();
        DataTable gvActivityEvaluation = (DataTable)ViewState["EvaluationTable"];
        foreach (DataRow dr in evaluationTable.Rows)
        {
            DataRow newEvaluationRow = gvActivityEvaluation.NewRow();
            newEvaluationRow["VolunteerId"] = dr["EVolunteerID"].ToString();
            newEvaluationRow["Volunteer"] = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(dr["EVolunteerID"].ToString())).vName;
            newEvaluationRow["VolunteerDays"] = dr["EVolunteersWorkingDays"].ToString();
            newEvaluationRow["VolunteerHours"] = dr["EVolunteerWorkingHours"].ToString();
            if (dr["EVolunteerIsRecommended"].ToString() == "True")
                newEvaluationRow["IsRecommended"] = "نعم";
            else if (dr["EVolunteerIsRecommended"].ToString() == "False")
                newEvaluationRow["IsRecommended"] = "لا";
            newEvaluationRow["RecommendedComments"] = dr["EVolunteerRecommendedComments"].ToString();
            newEvaluationRow["ActivityDepartmentEvaluation"] = dr["EActivityDepartmentEvaluation"].ToString();
            newEvaluationRow["VolunteerDepartmentEvaluation"] = dr["EVolunteerDepartmentEvaluation"].ToString();


            gvActivityEvaluation.Rows.Add(newEvaluationRow);
        }

        ViewState["EvaluationTable"] = gvActivityEvaluation;
        if (gvActivityEvaluation.Rows.Count > 0)
        {
            grdActivityEvaluation.DataSource = gvActivityEvaluation;
            grdActivityEvaluation.DataBind();
        }
        else
        {
            grdActivityEvaluation.DataBind();
        }
        GenerateSummary();
        #endregion

        lblTitle.Text = "قاعدة بيانات الأنشطة – صفحة التعديل";

        btnAddActivity.Text = "تعديل بيانات النشاط";
    }
    private void BindDepartmentRepresentativeUsers(int departmentId)
    {
        drpDepartmentResponsibleUser.Items.Clear();
        drpDepartmentResponsibleUser.Items.Add(new ListItem("إختار", "Select"));
        DataTable allDepartmentUsers = _AssociatedUsersManager.GetUsersByDepartmentId(departmentId);
        foreach (DataRow dr in allDepartmentUsers.Rows)
        {
            drpDepartmentResponsibleUser.Items.Add(new ListItem(dr["UserFullname"].ToString(), dr["UserID"].ToString()));
        }
    }
    private void BindDepartmentEvaluatorUsers()
    {
        drpVolunteerDepartmentResponsibleUser.Items.Clear();
        drpVolunteerDepartmentResponsibleUser.Items.Add(new ListItem("إختار", "Select"));

        Department volunteersDepartment = _AssociatedDepartmentsManager.GetDepartmentByName("إدارة المتطوعين");
        if (volunteersDepartment != null)
        {
            int departmentId = volunteersDepartment.DepartmentID;
            DataTable allEvaluatorDepartmentUsers = _AssociatedUsersManager.GetUsersByDepartmentIdAndEvaluation(departmentId, true);
            foreach (DataRow dr in allEvaluatorDepartmentUsers.Rows)
            {
                drpVolunteerDepartmentResponsibleUser.Items.Add(new ListItem(dr["UserFullname"].ToString(), dr["UserID"].ToString()));
            }
        }
    }
    private void BindPlacesDropDown()
    {
        drpActivityPlace.Items.Clear();
        drpActivityPlace.Items.Add(new ListItem("إختار", "Select"));
        DataTable cityPlaces = _AssociatedPlacesManager.GetAllPlaces();
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
    private void BindActivityMissionsCheckList(int FieldId)
    {
        chkVolunteerMissions.Items.Clear();

        DataTable MissionsTable = _AssociatedMissionsManager.GetMissionsByFieldId(FieldId);
        foreach (DataRow dr in MissionsTable.Rows)
        {
            chkVolunteerMissions.Items.Add(new ListItem(dr["MissionName"].ToString(), dr["MissionID"].ToString()));
            //  chkTypeOfMissions.Items.Add(new ListItem(dr["MissionName"].ToString(), dr["MissionID"].ToString()));
        }
    }
    private void BindVolunteerMissions(bool Selected)
    {
        chkTypeOfMissions.Items.Clear();
        foreach (ListItem item in chkVolunteerMissions.Items)
        {
            if (item.Selected)
            {
                ListItem volunteerMission = new ListItem(item.Text, item.Value);
                volunteerMission.Selected = Selected;
                chkTypeOfMissions.Items.Add(volunteerMission);
            }
        }
    }
    private void BindVolunteerMissionsReal(bool Selected)
    {
        chkTypeOfMissionsReal.Items.Clear();
        foreach (ListItem item in chkVolunteerMissions.Items)
        {
            if (item.Selected)
            {
                ListItem volunteerMission = new ListItem(item.Text, item.Value);
                volunteerMission.Selected = Selected;
                chkTypeOfMissionsReal.Items.Add(volunteerMission);
            }
        }
    }
    private void BindVolunteersDropDown(int fieldId)
    {
        drpVolunteerName.Items.Clear();
        drpVolunteerName.Items.Add(new ListItem("إختار", "Select"));
        DataTable volunteersTable = _AssociatedVolunteersManager.GetVolunteersByFieldId(fieldId);
        foreach (DataRow dr in volunteersTable.Rows)
        {
            drpVolunteerName.Items.Add(new ListItem(dr["vName"].ToString(), dr["VolunteerID"].ToString()));
        }
    }
    private void BindActivtyResultDataGrid(DataTable ActivityResultTable)
    {
        if (ActivityResultTable.Rows.Count > 0)
        {
            grdActivityDaysOnDiv.DataSource = ActivityResultTable;
            grdActivityDaysOnDiv.DataBind();
            btnFinishActivityVolunteers.Visible = true;
        }
        else
        {
            grdActivityDaysOnDiv.DataBind();
            btnFinishActivityVolunteers.Visible = false;
        }
    }
    private void BindActivtyResultRealDataGrid(DataTable ActivityResultRealTable)
    {
        if (ActivityResultRealTable.Rows.Count > 0)
        {
            grdActivityDaysRealOnDiv.DataSource = ActivityResultRealTable;
            grdActivityDaysRealOnDiv.DataBind();
            btnFinishActivityVolunteersReal.Visible = true;
        }
        else
        {
            grdActivityDaysRealOnDiv.DataBind();
            btnFinishActivityVolunteersReal.Visible = false;
        }
    }
    private void BindDepartmentsDataGrid(DataTable DapartmentsTable)
    {
        if (DapartmentsTable.Rows.Count > 0)
        {
            grdDepartments.DataSource = DapartmentsTable;
            grdDepartments.DataBind();
        }
        else
        {
            grdDepartments.DataBind();
        }
    }
    private void BindEvaluationData()
    {
        if (ViewState["MissionsEvaluationTable"] != null)
        {
            DataTable MissionsEvaluationTable = (DataTable)ViewState["MissionsEvaluationTable"];
            foreach (DataRow dr in MissionsEvaluationTable.Rows)
            {
                if (ViewState["EvaluationDepartmentId"].ToString() == dr["EDepartmentId"].ToString() && ViewState["EvaluationVolunteerId"].ToString() == dr["EVolunteerId"].ToString())
                {
                    DropDownList drpMissionLevel = (DropDownList)phVolunteerMissions.FindControl("drpMissionLevel" + dr["EMissionId"].ToString());
                    if (dr["EMissionLevelId"] != null)
                    {
                        drpMissionLevel.SelectedValue = dr["EMissionLevelId"].ToString();
                    }

                    TextBox txtMissionComments = (TextBox)phVolunteerMissions.FindControl("txtMissionComments" + dr["EMissionId"].ToString());
                    if (dr["EMissionComments"] != null)
                    {
                        txtMissionComments.Text = dr["EMissionComments"].ToString();
                    }
                }

            }
        }

        if (ViewState["SkillsEvaluationTable"] != null)
        {
            DataTable SkillsEvaluationTable = (DataTable)ViewState["SkillsEvaluationTable"];
            foreach (DataRow dr in SkillsEvaluationTable.Rows)
            {
                if (ViewState["EvaluationDepartmentId"].ToString() == dr["EDepartmentId"].ToString() && ViewState["EvaluationVolunteerId"].ToString() == dr["EVolunteerId"].ToString())
                {
                    DropDownList drpSkillLevel = (DropDownList)phVolunteerSkills.FindControl("drpSkillLevel" + dr["ESkillId"].ToString());
                    if (dr["ESkillLevelId"] != null)
                    {
                        drpSkillLevel.SelectedValue = dr["ESkillLevelId"].ToString();
                    }

                    TextBox txtSkillComments = (TextBox)phVolunteerSkills.FindControl("txtSkillComments" + dr["ESkillId"].ToString());
                    if (dr["ESkillComments"] != null)
                    {
                        txtSkillComments.Text = dr["ESkillComments"].ToString();
                    }
                }
            }
        }
    }
    private void BindRealActivityData()
    {
        drpVolunteerNameReal.Items.Clear();
        drpVolunteerNameReal.Items.Add(new ListItem("إختار", "Select"));
        drpActivityDayReal.Items.Clear();
        drpActivityDayReal.Items.Add(new ListItem("إختار", "Select"));
        if (ViewState["ActivityResultTableAll"] != null)
        {
            DataTable originalActivityResultTable = (DataTable)ViewState["ActivityResultTableAll"];
            foreach (DataRow dr in originalActivityResultTable.Rows)
            {
                ListItem existingVolunteer = drpVolunteerNameReal.Items.FindByValue(dr["VolunteerId"].ToString());
                if (existingVolunteer == null)
                {
                    drpVolunteerNameReal.Items.Add(new ListItem(dr["Volunteer"].ToString(), dr["VolunteerId"].ToString()));
                }

                ListItem existingDay = drpActivityDayReal.Items.FindByValue(dr["ActivityDay"].ToString());
                if (existingDay == null)
                {
                    existingDay = drpActivityDay.Items.FindByValue(dr["ActivityDay"].ToString());
                    drpActivityDayReal.Items.Add(new ListItem(existingDay.Text, existingDay.Value));
                }
            }

        }
    }
    #endregion

    #region DropDown Event Handlers
    protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        mpeDepartment.Show();
        if (drpDepartment.SelectedValue != "Select")
        {
            BindDepartmentRepresentativeUsers(int.Parse(drpDepartment.SelectedValue));
        }
        else
        {
            drpDepartmentResponsibleUser.Items.Clear();
            drpDepartmentResponsibleUser.Items.Add(new ListItem("إختار", "Select"));
        }
    }
    protected void drpActivityField_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpActivityField.SelectedValue != "Select")
        {
            BindVolunteersDropDown(int.Parse(drpActivityField.SelectedValue));
            BindActivityMissionsCheckList(int.Parse(drpActivityField.SelectedValue));
        }
        else
        {
            drpVolunteerName.Items.Clear();
            drpVolunteerName.Items.Add(new ListItem("إختار", "Select"));
            chkVolunteerMissions.Items.Clear();
        }
    }
    protected void drpAttendanceState_SelectedIndexChanged(object sender, EventArgs e)
    {
        mpeActivityResultReal.Show();
        AttendanceStateSetUI();
    }

    private void AttendanceStateSetUI()
    {
        if (drpAttendanceState.SelectedValue != "Select")
        {
            txtWorkTimeFromReal.Enabled = false;
            txtWorkTimeToReal.Enabled = false;
            drpAmPmToReal.Enabled = false;
            drpAmPmFromReal.Enabled = false;
            txtWorkTimeFromReal.Text = string.Empty;
            txtWorkTimeToReal.Text = string.Empty;
            chkTypeOfMissionsReal.Enabled = false;

            foreach (ListItem item in chkTypeOfMissionsReal.Items)
            {
                item.Selected = false;
            }
        }
        else
        {
            txtWorkTimeFromReal.Enabled = true;
            txtWorkTimeToReal.Enabled = true;
            drpAmPmToReal.Enabled = true;
            drpAmPmFromReal.Enabled = true;
            chkTypeOfMissionsReal.Enabled = true;
        }
    }
    #endregion

    #region Text Boxes Event Handlers
    protected void txtActivityDateTo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtActivityDateFrom.Text != string.Empty && txtActivityDateTo.Text != string.Empty)
            {
                TimeSpan activityTimeSpan = DateTime.Parse(txtActivityDateTo.Text) - DateTime.Parse(txtActivityDateFrom.Text);
                drpActivityDay.Items.Clear();
                drpActivityDay.Items.Add(new ListItem("إختار", "Select"));
                for (int actvityDay = 0; actvityDay < activityTimeSpan.Days + 1; actvityDay++)
                {
                    DateTime ActivityDayDate = DateTime.Parse(txtActivityDateFrom.Text).AddDays(actvityDay);
                    drpActivityDay.Items.Add(new ListItem(ActivityDayDate.ToShortDateString() + "  (" + (actvityDay + 1).ToString() + ")", ActivityDayDate.ToShortDateString()));
                }
            }
            if (drpActivityDay.Items.Count > 1)
                lnkAddDayDetails.Visible = true;
            else
                lnkAddDayDetails.Visible = false;
        }
        catch
        {
            //do nothing
        }
    }
    protected void txtActivityDateFrom_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtActivityDateFrom.Text != string.Empty && txtActivityDateTo.Text != string.Empty)
            {
                TimeSpan activityTimeSpan = DateTime.Parse(txtActivityDateTo.Text) - DateTime.Parse(txtActivityDateFrom.Text);
                drpActivityDay.Items.Clear();
                drpActivityDay.Items.Add(new ListItem("إختار", "Select"));
                for (int actvityDay = 0; actvityDay < activityTimeSpan.Days + 1; actvityDay++)
                {
                    DateTime ActivityDayDate = DateTime.Parse(txtActivityDateFrom.Text).AddDays(actvityDay);
                    drpActivityDay.Items.Add(new ListItem(ActivityDayDate.ToShortDateString() + "  (" + (actvityDay + 1).ToString() + ")", ActivityDayDate.ToShortDateString()));
                }
            }
            if (drpActivityDay.Items.Count > 1)
                lnkAddDayDetails.Visible = true;
            else
                lnkAddDayDetails.Visible = false;
        }
        catch
        {
            //do nothing
        }
    }
    #endregion

    #region Validation Methods
    private bool ValidateActivityDay()
    {
        bool valid = true;
        ResetValiadationImagesToDefaultValue(DivActivityResult);

        if (drpVolunteerName.SelectedValue == "Select")
        {
            imgActivityVolunteerV.Visible = true;
            valid = false;
        }


        //bool volunteerMissionsSelected = false;
        //foreach (ListItem item in chkTypeOfMissions.Items)
        //{
        //    if (item.Selected == true)
        //    {
        //        volunteerMissionsSelected = true;
        //        break;
        //    }
        //}
        //if (volunteerMissionsSelected == false)
        //{
        //    imgActivityVolunteerMissionsV.Visible = true;
        //    valid = false;
        //}

        if (txtWorkTimeFrom.Text != string.Empty && !Validation.ValidateDayTime(txtWorkTimeFrom.Text))
        {
            imgActivityWorkStartV.Visible = true;
            valid = false;
        }
        if (txtWorkTimeTo.Text != string.Empty && !Validation.ValidateDayTime(txtWorkTimeTo.Text))
        {
            imgActivityWorkEndV.Visible = true;
            valid = false;
        }

        if (drpActivityDay.SelectedValue == "Select")
        {
            imgActivityDayV.Visible = true;
            valid = false;
        }

        return valid;
    }
    private bool ValidateActivityDayReal()
    {
        bool valid = true;
        ResetValiadationImagesToDefaultValue(DivActivityResultReal);

        if (drpVolunteerNameReal.SelectedValue == "Select")
        {
            imgActivityVolunteerRealV.Visible = true;
            valid = false;
        }
        //if (!Validation.ValidateRequiredTextField(txtWorkTimeFromReal.Text))
        //{
        //    imgActivityWorkStartRealV.Visible = true;
        //    valid = false;
        //}
        //if (!Validation.ValidateRequiredTextField(txtWorkTimeToReal.Text))
        //{
        //    imgActivityWorkEndRealV.Visible = true;
        //    valid = false;
        //}

        //bool volunteerMissionsSelected = false;
        //foreach (ListItem item in chkTypeOfMissionsReal.Items)
        //{
        //    if (item.Selected == true)
        //    {
        //        volunteerMissionsSelected = true;
        //        break;
        //    }
        //}
        //if (volunteerMissionsSelected == false)
        //{
        //    imgActivityVolunteerMissionsRealV.Visible = true;
        //    valid = false;
        //}

        if (txtWorkTimeFromReal.Text != string.Empty && !Validation.ValidateDayTime(txtWorkTimeFromReal.Text))
        {
            imgActivityWorkStartRealV.Visible = true;
            valid = false;
        }
        if (txtWorkTimeToReal.Text != string.Empty && !Validation.ValidateDayTime(txtWorkTimeToReal.Text))
        {
            imgActivityWorkEndRealV.Visible = true;
            valid = false;
        }

        if (drpActivityDayReal.SelectedValue == "Select")
        {
            imgActivityDayRealV.Visible = true;
            valid = false;
        }

        return valid;
    }
    private bool ValidateActivity()
    {
        bool valid = true;
        ResetValiadationImagesToDefaultValue(Page);

        #region ValidateRequiredFields
        if (!Validation.ValidateRequiredTextField(txtActivityCodeNo.Text))
        {
            imgActivityCodeNoV.Visible = true;
            valid = false;
        }

        //if (!Validation.ValidateRequiredTextField(txtActivityRequestDate.Text))
        //{
        //    imgActivityRequestDateV.Visible = true;
        //    valid = false;
        //}
        if (!Validation.ValidateRequiredTextField(txtActivityDateFrom.Text))
        {
            imgActivityStartV.Visible = true;
            valid = false;
        }
        if (!Validation.ValidateRequiredTextField(txtActivityDateTo.Text))
        {
            imgActivityEndV.Visible = true;
            valid = false;
        }
        if (drpActivityField.SelectedValue == "Select")
        {
            imgActivityFieldV.Visible = true;
            valid = false;
        }
        //if (drpActivityPlace.SelectedValue == "Select")
        //{
        //    imgActivityPlaceV.Visible = true;
        //    valid = false;
        //}
        if (grdDepartments.Rows.Count == 0)
        {
            imgActivityDepartments.Visible = true;
            valid = false;
        }

        //bool ActivityMissionSelected = false;
        //foreach (ListItem item in chkVolunteerMissions.Items)
        //{
        //    if (item.Selected == true)
        //    {
        //        ActivityMissionSelected = true;
        //        break;
        //    }
        //}
        //if (ActivityMissionSelected == false)
        //{
        //    imgActivityRequiredFields.Visible = true;
        //    valid = false;
        //}

        if (drpVolunteerDepartmentResponsibleUser.SelectedValue == "Select")
        {
            imgActivityEvaluatorV.Visible = true;
            valid = false;
        }

        #endregion

        #region ValidateFieldsFormat
        if (!Validation.ValidateInt(txtActivityCodeNo.Text))
        {
            imgActivityCodeNoV.Visible = true;
            valid = false;
        }
        if (!Validation.ValidateDate(txtActivityDateFrom.Text))
        {
            imgActivityStartV.Visible = true;
            valid = false;
        }
        if (!Validation.ValidateDate(txtActivityDateTo.Text))
        {
            imgActivityEndV.Visible = true;
            valid = false;
        }
        if (!Validation.ValidateDate(txtActivityRequestDate.Text))
        {
            imgActivityRequestDateV.Visible = true;
            valid = false;
        }
        if (!Validation.ValidateInt(txtActivityCost.Text))
        {
            imgActivityCostV.Visible = true;
            valid = false;
        }
        if (!Validation.ValidateInt(txtActivityRevenue.Text))
        {
            imgActivityRevenueV.Visible = true;
            valid = false;
        }

        if (!Validation.ValidateInt(txtActivityRequiredVolunteers.Text))
        {
            imgActivityRequiredVolunteersV.Visible = true;
            valid = false;
        }

        //validate the order of activity start and end dates
        if (txtActivityDateFrom.Text != string.Empty && txtActivityDateTo.Text != string.Empty)
        {
            if (DateTime.Parse(txtActivityDateTo.Text) < DateTime.Parse(txtActivityDateFrom.Text))
            {
                imgActivityEndV.Visible = true;
                imgActivityStartV.Visible = true;
                valid = false;
            }
        }
        #endregion

        return valid;
    }
    private bool ValidateDepartment()
    {
        bool valid = true;
        ResetValiadationImagesToDefaultValue(divDepartment);

        if (drpDepartment.SelectedValue == "Select")
        {
            imgActivityDepartmentV.Visible = true;
            valid = false;
        }
        if (drpDepartmentResponsibleUser.SelectedValue == "Select")
        {
            imgActivityDepartmentResponsibleUserV.Visible = true;
            valid = false;
        }

        return valid;
    }
    #endregion

    #region Create Virtual Tables
    private void CreateDepartmentsDatatable()
    {
        DataTable DepartmentsTable = new DataTable();

        DataColumn newDataColumn;

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "Department";
        DepartmentsTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "DepartmentId";
        DepartmentsTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "DepartmentResponsibleUser";
        DepartmentsTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "DepartmentResponsibleUserId";
        DepartmentsTable.Columns.Add(newDataColumn);

        //newDataColumn = new DataColumn();
        //newDataColumn.DataType = Type.GetType("System.String");
        //newDataColumn.ColumnName = "DepartmentEvaluator";
        //DepartmentsTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "DepartmentIndex";
        DepartmentsTable.Columns.Add(newDataColumn);

        ViewState["DepartmentsTable"] = DepartmentsTable;

    }
    private void CreateEvaluationDatatable()
    {
        DataTable EvaluationTable = new DataTable();

        DataColumn newDataColumn;

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EvaluationId";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerId";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "Volunteer";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerDays";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerHours";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "IsRecommended";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "RecommendedComments";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ActivityDepartmentEvaluation";
        EvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerDepartmentEvaluation";
        EvaluationTable.Columns.Add(newDataColumn);

        ViewState["EvaluationTable"] = EvaluationTable;

    }
    private void CreateSkillsEvaluationDatatable()
    {
        DataTable SkillsEvaluationTable = new DataTable();

        DataColumn newDataColumn;

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EVolunteerId";
        SkillsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ESkillId";
        SkillsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ESkillLevelId";
        SkillsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EDepartmentId";
        SkillsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ESkillComments";
        SkillsEvaluationTable.Columns.Add(newDataColumn);

        ViewState["SkillsEvaluationTable"] = SkillsEvaluationTable;
    }
    private void CreateMissionsEvaluationDatatable()
    {
        DataTable MissionsEvaluationTable = new DataTable();

        DataColumn newDataColumn;

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EVolunteerId";
        MissionsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EMissionId";
        MissionsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EMissionLevelId";
        MissionsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EDepartmentId";
        MissionsEvaluationTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "EMissionComments";
        MissionsEvaluationTable.Columns.Add(newDataColumn);

        ViewState["MissionsEvaluationTable"] = MissionsEvaluationTable;
    }
    private void CreateActivityResultDatatable()
    {
        DataTable ActivityResultdataTable = new DataTable();

        DataColumn newDataColumn;

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ActivityDay";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "Volunteer";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerMissions";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerMissionsId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "WorkingTimeFrom";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "WorkingTimeTo";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerWorkDetails";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        //virtual index to store the activities without storing them in the database
        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ResultIndex";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        //real index of the activity results
        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ResultId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        ViewState["ActivityResultTable"] = ActivityResultdataTable;

    }
    private void CreateActivityResultRealDatatable()
    {
        DataTable ActivityResultdataTable = new DataTable();

        DataColumn newDataColumn;

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ActivityDay";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "Volunteer";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerMissions";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerMissionsId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "WorkingTimeFrom";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "WorkingTimeTo";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerWorkDetails";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerAttendanceState";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "VolunteerAttendanceStateId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        //virtual index to store the activities without storing them in the database
        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ResultIndex";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        //real index of the activity results
        newDataColumn = new DataColumn();
        newDataColumn.DataType = Type.GetType("System.String");
        newDataColumn.ColumnName = "ResultId";
        ActivityResultdataTable.Columns.Add(newDataColumn);

        ViewState["ActivityResultRealTable"] = ActivityResultdataTable;

    }
    #endregion

    #region GridView RowDataBound Methods
    protected void grdDepartments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton imgBtnActivityDepartmentDelete = (ImageButton)e.Row.FindControl("imgBtnActivityDepartmentDelete");
            imgBtnActivityDepartmentDelete.Attributes.Add("onclick", "javascript:return " +
               "confirm('هل انت متأكد من مسح هذة الإدارة؟')");
        }
    }
    protected void grdActivityDays_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVolunteerWorkingStart = (Label)e.Row.FindControl("lblVolunteerWorkingStart");
            Label lblVolunteerWorkingEnd = (Label)e.Row.FindControl("lblVolunteerWorkingEnd");
            Label lblVolunteerId = (Label)e.Row.FindControl("lblVolunteerId");
            Label lblVolunteerMobile = (Label)e.Row.FindControl("lblVolunteerMobile");
            Label lblActivtyDaySerial = (Label)e.Row.FindControl("lblActivtyDaySerial");

            ImageButton imgBtnActivityDayDelete = (ImageButton)e.Row.FindControl("imgBtnActivityDayDelete");
            if (imgBtnActivityDayDelete != null)
            {
                imgBtnActivityDayDelete.Attributes.Add("onclick", "javascript:return " +
                   "confirm('هل انت متأكد من مسح هذة النتيجة؟')");
            }

            //change the format of working time from decimal to clock format
            if (lblVolunteerWorkingStart.Text != string.Empty && lblVolunteerWorkingEnd.Text != string.Empty)
            {
                string AmPmTo = "am";
                string AmPmFrom = "am";
                string workingFrom = lblVolunteerWorkingStart.Text;
                if (decimal.Parse(workingFrom) > 13 || decimal.Parse(workingFrom) == 13)
                {
                    workingFrom = (decimal.Parse(workingFrom) - 12).ToString();
                    AmPmFrom = "pm";
                }
                int dotIndex = workingFrom.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = workingFrom.Length;
                    workingFrom += ".0";
                }
                lblVolunteerWorkingStart.Text = workingFrom.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingFrom.Substring(dotIndex))) * 60).ToString() + AmPmFrom;

                string workingTo = lblVolunteerWorkingEnd.Text;
                if (decimal.Parse(workingTo) > 13 || decimal.Parse(workingTo) == 13)
                {
                    workingTo = (decimal.Parse(workingTo) - 12).ToString();
                    AmPmTo = "pm";
                }
                dotIndex = workingTo.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = workingTo.Length;
                    workingTo += ".0";
                }
                lblVolunteerWorkingEnd.Text = workingTo.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingTo.Substring(dotIndex))) * 60).ToString() + AmPmTo;
            }

            if (lblVolunteerId != null)
            {
                Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(lblVolunteerId.Text));
                lblVolunteerId.Text = volunteerInstance.VolunteerManID.ToString();
                lblVolunteerMobile.Text = (string.IsNullOrEmpty(volunteerInstance.vMobile)) ? volunteerInstance.vTelephone : volunteerInstance.vMobile;
                lblActivtyDaySerial.Text = (grdActivityDays.Rows.Count + 1).ToString();
            }


        }
    }
    protected void grdActivityDaysRealOnDiv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVolunteerWorkingStart = (Label)e.Row.FindControl("lblVolunteerWorkingStart");
            Label lblVolunteerWorkingEnd = (Label)e.Row.FindControl("lblVolunteerWorkingEnd");
            Label lblVolunteerMissions = (Label)e.Row.FindControl("lblVolunteerMissions");
            Label lblVolunteerAttendanceState = (Label)e.Row.FindControl("lblVolunteerAttendanceState");

            if (lblVolunteerMissions.Text == string.Empty)
            {
                lblVolunteerAttendanceState.Visible = true;
            }

            ImageButton imgBtnActivityDayDelete = (ImageButton)e.Row.FindControl("imgBtnActivityDayDelete");
            if (imgBtnActivityDayDelete != null)
            {
                imgBtnActivityDayDelete.Attributes.Add("onclick", "javascript:return " +
                   "confirm('هل انت متأكد من مسح هذة النتيجة؟')");
            }

            //change the format of working time from decimal to clock format
            string AmPmTo = "am";
            string AmPmFrom = "am";
            string workingFrom = lblVolunteerWorkingStart.Text;
            if (workingFrom != string.Empty)
            {
                if (decimal.Parse(workingFrom) > 13 || decimal.Parse(workingFrom) == 13)
                {
                    workingFrom = (decimal.Parse(workingFrom) - 12).ToString();
                    AmPmFrom = "pm";
                }
                int dotIndex = workingFrom.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = workingFrom.Length;
                    workingFrom += ".0";
                }
                lblVolunteerWorkingStart.Text = workingFrom.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingFrom.Substring(dotIndex))) * 60).ToString() + AmPmFrom;
            }

            string workingTo = lblVolunteerWorkingEnd.Text;
            if (workingTo != string.Empty)
            {
                if (decimal.Parse(workingTo) > 13 || decimal.Parse(workingTo) == 13)
                {
                    workingTo = (decimal.Parse(workingTo) - 12).ToString();
                    AmPmTo = "pm";
                }
                int dotIndex = workingTo.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = workingTo.Length;
                    workingTo += ".0";
                }
                lblVolunteerWorkingEnd.Text = workingTo.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingTo.Substring(dotIndex))) * 60).ToString() + AmPmTo;
            }
        }
    }
    protected void grdActivityDaysReal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVolunteerWorkingStart = (Label)e.Row.FindControl("lblVolunteerWorkingStart");
            Label lblVolunteerWorkingEnd = (Label)e.Row.FindControl("lblVolunteerWorkingEnd");
            Label lblVolunteerId = (Label)e.Row.FindControl("lblVolunteerId");
            Label lblActivtyDayRealSerial = (Label)e.Row.FindControl("lblActivtyDayRealSerial");
            Label lblVolunteerMissions = (Label)e.Row.FindControl("lblVolunteerMissions");
            Label lblVolunteerAttendanceState = (Label)e.Row.FindControl("lblVolunteerAttendanceState");

            if (lblVolunteerMissions.Text == string.Empty)
            {
                lblVolunteerAttendanceState.Visible = true;
            }
            else
            {
                lblVolunteerMissions.Visible = false;
            }

            ImageButton imgBtnActivityDayDelete = (ImageButton)e.Row.FindControl("imgBtnActivityDayDelete");
            if (imgBtnActivityDayDelete != null)
            {
                imgBtnActivityDayDelete.Attributes.Add("onclick", "javascript:return " +
                   "confirm('هل انت متأكد من مسح هذة النتيجة؟')");
            }

            //change the format of working time from decimal to clock format
            string AmPmTo = "am";
            string AmPmFrom = "am";
            string workingFrom = lblVolunteerWorkingStart.Text;
            if (workingFrom != string.Empty)
            {
                if (decimal.Parse(workingFrom) > 13 || decimal.Parse(workingFrom) == 13)
                {
                    workingFrom = (decimal.Parse(workingFrom) - 12).ToString();
                    AmPmFrom = "pm";
                }
                int dotIndex = workingFrom.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = workingFrom.Length;
                    workingFrom += ".0";
                }
                lblVolunteerWorkingStart.Text = workingFrom.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingFrom.Substring(dotIndex))) * 60).ToString() + AmPmFrom;
            }


            string workingTo = lblVolunteerWorkingEnd.Text;
            if (workingTo != string.Empty)
            {
                if (decimal.Parse(workingTo) > 13 || decimal.Parse(workingTo) == 13)
                {
                    workingTo = (decimal.Parse(workingTo) - 12).ToString();
                    AmPmTo = "pm";
                }
                int dotIndex = workingTo.IndexOf(".");
                if (dotIndex == -1)
                {
                    dotIndex = workingTo.Length;
                    workingTo += ".0";
                }
                lblVolunteerWorkingEnd.Text = workingTo.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingTo.Substring(dotIndex))) * 60).ToString() + AmPmTo;
            }
            Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(lblVolunteerId.Text));
            lblVolunteerId.Text = volunteerInstance.VolunteerManID.ToString();

            lblActivtyDayRealSerial.Text = (grdActivityDaysReal.Rows.Count + 1).ToString();

        }
    }
    protected void grdActivityEvaluation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVolunteerHours = (Label)e.Row.FindControl("lblVolunteerHours");
            LinkButton lnkActivityDepartmentEvaluation = (LinkButton)e.Row.FindControl("lnkActivityDepartmentEvaluation");
            LinkButton lnkVolunteerDepartmentEvaluation = (LinkButton)e.Row.FindControl("lnkVolunteerDepartmentEvaluation");
            Label lblVolunteerId = (Label)e.Row.FindControl("lblVolunteerId");
            Label lblActivtyEvaluationSerial = (Label)e.Row.FindControl("lblActivtyEvaluationSerial");
            string volunteerId = lnkActivityDepartmentEvaluation.CommandArgument;

            if (lblVolunteerHours.Text != string.Empty)
            {
                decimal volunteerHours = Math.Round(decimal.Parse(lblVolunteerHours.Text), 0);
                lblVolunteerHours.Text = volunteerHours.ToString();
            }

            if (lnkActivityDepartmentEvaluation.Text != string.Empty)
            {
                lnkActivityDepartmentEvaluation.Text = Enum.GetName(typeof(EvaluationLevel), int.Parse(lnkActivityDepartmentEvaluation.Text));
                lnkActivityDepartmentEvaluation.ForeColor = Color.Green;
            }
            else
            {
                lnkActivityDepartmentEvaluation.Text = "تقييم";
            }

            if (lnkVolunteerDepartmentEvaluation.Text != string.Empty)
            {
                lnkVolunteerDepartmentEvaluation.Text = Enum.GetName(typeof(EvaluationLevel), int.Parse(lnkVolunteerDepartmentEvaluation.Text));
                lnkVolunteerDepartmentEvaluation.ForeColor = Color.Green;
            }
            else
            {
                lnkVolunteerDepartmentEvaluation.Text = "تقييم";
            }


            Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(lblVolunteerId.Text));
            lblVolunteerId.Text = volunteerInstance.VolunteerManID.ToString();

            lblActivtyEvaluationSerial.Text = (grdActivityEvaluation.Rows.Count + 1).ToString();
        }
    }
    #endregion

    #region Reset Methods
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
                if (ctrl.GetType() == typeof(System.Web.UI.WebControls.Image))
                {
                    if (ctrl.ID.Contains("imgActivity"))
                    {
                        ctrl.Visible = false;
                    }
                }
            }
        }

    }
    private void ResetActivityControlsToDefaultValue(Control parentControl)
    {
        foreach (Control ctrl in parentControl.Controls)
        {
            if (ctrl.HasControls())
            {
                ResetActivityControlsToDefaultValue(ctrl);
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
                    if (drpInstance.Items.FindByValue("Select") != null)
                    {
                        drpInstance.SelectedValue = "Select";
                    }
                }

            }
        }

        if (parentControl == (Control)Page)
        {
            //clear all grid items
            grdDepartments.DataBind();
            grdActivityDays.DataBind();
            grdActivityDaysReal.DataBind();

            //clear all checkbox's items
            chkTypeOfMissions.Items.Clear();
            chkVolunteerMissions.Items.Clear();

            //reset add days row to default value
            drpActivityDay.Items.Clear();
            drpActivityDay.Items.Add(new ListItem("إختار", "Select"));

        }
    }
    #endregion

    #region Authentication Methods
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
    #endregion

    #region Button Event Handlers
    protected void btnFinishActivityVolunteers_Click(object sender, EventArgs e)
    {
        if (ViewState["ActivityResultTable"] != null)
        {
            if (ViewState["ActivityResultTableAll"] == null)
            {
                //Fill the gridview for step 2 (providing volunteers)
                ViewState["ActivityResultTableAll"] = ViewState["ActivityResultTable"];
                grdActivityDays.DataSource = (DataTable)ViewState["ActivityResultTableAll"];
                grdActivityDays.DataBind();
            }
            else
            {
                //Fill the gridview for step 2 (providing volunteers)
                DataTable originalActivityResultTable = (DataTable)ViewState["ActivityResultTableAll"];
                originalActivityResultTable.Merge((DataTable)ViewState["ActivityResultTable"]);
                ViewState["ActivityResultTableAll"] = originalActivityResultTable;
                grdActivityDays.DataSource = originalActivityResultTable;
                grdActivityDays.DataBind();
            }
        }
        ViewState["ActivityResultTable"] = null;

        //show the attendance link for the evaluation step in case the result grid has any rows
        if (grdActivityDays.Rows.Count > 0)
            lnkAddDayDetailsReal.Visible = true;
        else
            lnkAddDayDetailsReal.Visible = false;
    }
    protected void btnAddActivityDayResultReal_Click(object sender, EventArgs e)
    {
        mpeActivityResultReal.Show();
        if (ValidateActivityDayReal())
        {
            if (ViewState["ActivityResultRealTable"] == null)
            {
                CreateActivityResultRealDatatable();
            }

            DataTable ActivityResultRealTable = (DataTable)ViewState["ActivityResultRealTable"];

            DataRow row = ActivityResultRealTable.NewRow();


            row["ActivityDay"] = drpActivityDayReal.SelectedValue;
            row["Volunteer"] = drpVolunteerNameReal.SelectedItem.Text;
            row["VolunteerId"] = drpVolunteerNameReal.SelectedValue;

            string volunteerMissions = string.Empty;
            string volunteerMissionsId = string.Empty;
            foreach (ListItem item in chkTypeOfMissionsReal.Items)
            {
                if (item.Selected)
                {
                    if (volunteerMissions == string.Empty)
                    {
                        volunteerMissions = item.Text;
                        volunteerMissionsId = item.Value;
                    }
                    else
                    {
                        volunteerMissions += ", " + item.Text;
                        volunteerMissionsId += "," + item.Value;
                    }
                }
            }

            row["VolunteerMissions"] = volunteerMissions;
            row["VolunteerMissionsId"] = volunteerMissionsId;

            //calaculate volunteer working hours
            if (txtWorkTimeFromReal.Text != string.Empty && txtWorkTimeToReal.Text != string.Empty)
            {
                decimal workingHours = 0;
                int fromSeparator = txtWorkTimeFromReal.Text.IndexOf(":");
                int toSeparator = txtWorkTimeToReal.Text.IndexOf(":");
                decimal WorkingFrom = decimal.Parse(txtWorkTimeFromReal.Text.Substring(0, fromSeparator));
                WorkingFrom += decimal.Parse(txtWorkTimeFromReal.Text.Substring(fromSeparator + 1)) / 60;
                decimal WorkingTo = decimal.Parse(txtWorkTimeToReal.Text.Substring(0, toSeparator));
                WorkingTo += decimal.Parse(txtWorkTimeToReal.Text.Substring(toSeparator + 1)) / 60;
                if (drpAmPmFromReal.SelectedValue == "am" && drpAmPmToReal.SelectedValue == "am")
                {
                    workingHours = WorkingTo - WorkingFrom;
                }
                else if (drpAmPmFromReal.SelectedValue == "pm" && drpAmPmToReal.SelectedValue == "pm")
                {
                    workingHours = WorkingTo - WorkingFrom;
                    WorkingFrom += 12;
                    WorkingTo += 12;
                }
                else if (drpAmPmFromReal.SelectedValue == "am" && drpAmPmToReal.SelectedValue == "pm")
                {
                    workingHours = WorkingTo - WorkingFrom + 12;
                    WorkingTo += 12;
                }
                else if (drpAmPmFromReal.SelectedValue == "pm" && drpAmPmToReal.SelectedValue == "am")
                {
                    workingHours = WorkingTo - WorkingFrom + 12;
                    WorkingFrom += 12;
                }
                row["WorkingTimeFrom"] = WorkingFrom.ToString();
                row["WorkingTimeTo"] = WorkingTo.ToString();
            }

            if (drpAttendanceState.SelectedValue != "Select")
            {
                row["VolunteerAttendanceState"] = drpAttendanceState.SelectedItem.Text;
                row["VolunteerAttendanceStateId"] = drpAttendanceState.SelectedValue;
            }

            row["VolunteerWorkDetails"] = txtVolunteerWorkDetailsReal.Text;

            if (btnAddActivityDayResultReal.Text == "إضافة")
            {
                //validate that the activity wasn't added before
                if (ViewState["ActivityResultRealTable"] != null)
                {
                    DataTable activtyResultRealTable = (DataTable)ViewState["ActivityResultRealTable"];
                    DataTable validationTable = activtyResultRealTable.Copy();
                    if (ViewState["ActivityResultRealTableAll"] != null)
                    {
                        validationTable.Merge((DataTable)ViewState["ActivityResultRealTableAll"]);
                    }
                    foreach (DataRow dr in validationTable.Rows)
                    {
                        if (drpVolunteerNameReal.SelectedValue == dr["VolunteerId"].ToString() && drpActivityDayReal.SelectedValue == dr["ActivityDay"].ToString())
                        {
                            imgActivityVolunteerRealV.Visible = true;
                            return;
                        }
                    }
                }

                int rowsCountOffset = 0;
                int resultIndex = 0;
                if (ViewState["ActivityResultRealTableAll"] != null && ((DataTable)ViewState["ActivityResultRealTableAll"]).Rows.Count > 0)
                {
                    DataTable ActivityResultRealAll = (DataTable)ViewState["ActivityResultRealTableAll"];
                    rowsCountOffset = ActivityResultRealAll.Rows.Count;
                    resultIndex += int.Parse(ActivityResultRealAll.Rows[rowsCountOffset - 1]["ResultIndex"].ToString()) + 1;
                }
                int rowsCount = ActivityResultRealTable.Rows.Count;
                if (rowsCount > 0)
                {
                    resultIndex += int.Parse(ActivityResultRealTable.Rows[rowsCount - 1]["ResultIndex"].ToString()) + 1;
                }
                row["ResultIndex"] = resultIndex;
                ActivityResultRealTable.Rows.Add(row);
            }
            else if (btnAddActivityDayResultReal.Text == "تعديل")
            {
                int resultIndex = int.Parse(ViewState["ResultIndex"].ToString());
                row["ResultIndex"] = resultIndex;
                DataTable ActivityResultRealTableAll = (DataTable)ViewState["ActivityResultRealTableAll"];
                foreach (DataRow dr in ActivityResultRealTableAll.Rows)
                {
                    if (dr["ResultIndex"].ToString() == resultIndex.ToString())
                    {
                        int rowOrdinal = 0;
                        foreach (object rowColumn in row.ItemArray)
                        {
                            dr[rowOrdinal] = rowColumn.ToString();
                            rowOrdinal++;
                        }

                        //dr["ActivityDay"] = row["ActivityDay"];
                        //dr["Volunteer"] = row["Volunteer"];
                        //dr["VolunteerId"] = row["VolunteerId"];
                        //dr["VolunteerMissions"] = row["VolunteerMissions"];
                        //dr["VolunteerMissionsId"] = row["VolunteerMissionsId"];
                        //dr["WorkingTimeFrom"] = row["WorkingTimeFrom"];
                        //dr["WorkingTimeTo"] = row["WorkingTimeTo"];
                        //dr["VolunteerWorkDetails"] = row["VolunteerWorkDetails"];

                        break;
                    }
                }
                ViewState["ActivityResultRealTable"] = ActivityResultRealTableAll;
                grdActivityDaysReal.DataSource = ActivityResultRealTableAll;
                grdActivityDaysReal.DataBind();
                mpeActivityResultReal.Hide();
            }

            ViewState["ActivityResultRealTable"] = ActivityResultRealTable;

            BindActivtyResultRealDataGrid(ActivityResultRealTable);

            txtWorkTimeFromReal.Enabled = true;
            txtWorkTimeToReal.Enabled = true;
            drpAmPmToReal.Enabled = true;
            drpAmPmFromReal.Enabled = true;
        }
    }
    protected void btnFinishEvaluation_Click(object sender, EventArgs e)
    {
        int VolunteerId = int.Parse(ViewState["EvaluationVolunteerId"].ToString());
        string departmentId = null;
        if (ViewState["EvaluationDepartmentId"] != null)
        {
            departmentId = ViewState["EvaluationDepartmentId"].ToString();
        }

        decimal avrVDE = 0;  // average  evaluation
        int vdeCount = 0;
        #region  Update Missions table
        if (ViewState["MissionsEvaluationTable"] == null)
        {
            CreateMissionsEvaluationDatatable();
        }

        DataTable MissionsEvaluationTable = (DataTable)ViewState["MissionsEvaluationTable"];

         //Delete existing mission for the selected volunteer
    LoopStart: foreach (DataRow dr in MissionsEvaluationTable.Rows)
        {
            if (dr["EVolunteerId"].ToString() == VolunteerId.ToString() && dr["EDepartmentId"].ToString() == departmentId)
            {
                MissionsEvaluationTable.Rows.Remove(dr);
                goto LoopStart;
            }
        }

        if (ViewState["ActivityResultRealTableAll"] != null)
        {
            DataTable ActivityResultRealTableAll = (DataTable)ViewState["ActivityResultRealTableAll"];

            //Get Volunteer's missions across all the activity days
            List<string> resultMissionIdsList = new List<string>();
            foreach (DataRow dr in ActivityResultRealTableAll.Rows)
            {
                if (dr["VolunteerId"].ToString() == VolunteerId.ToString())
                {
                    string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                    string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                    foreach (string missionId in resultMissionIdsArray)
                    {
                        string existingMissionId = resultMissionIdsList.Find(delegate(string _MissionId) { return _MissionId == missionId; });
                        if (existingMissionId == null)
                        {
                            resultMissionIdsList.Add(missionId);
                        }
                    }
                }
            }

            foreach (string missionId in resultMissionIdsList)
            {
                DataRow EvaluationVolunteerMissionRow = MissionsEvaluationTable.NewRow();

                EvaluationVolunteerMissionRow["EMissionId"] = missionId;
                EvaluationVolunteerMissionRow["EVolunteerId"] = VolunteerId;
                if (departmentId != null)
                {
                    EvaluationVolunteerMissionRow["EDepartmentId"] = departmentId;
                }
                else
                {
                    EvaluationVolunteerMissionRow["EDepartmentId"] = null;
                }

                DropDownList drpMissionLevel = (DropDownList)phVolunteerMissions.FindControl("drpMissionLevel" + missionId);
                if (drpMissionLevel.SelectedValue != "Select")
                {
                    EvaluationVolunteerMissionRow["EMissionLevelId"] = drpMissionLevel.SelectedValue;
                    avrVDE += int.Parse(drpMissionLevel.SelectedValue);
                    vdeCount++;
                }

                TextBox txtMissionComments = (TextBox)phVolunteerMissions.FindControl("txtMissionComments" + missionId);
                if (txtMissionComments.ID == "txtMissionComments" + missionId.ToString())
                {
                    if (txtMissionComments.Text != string.Empty)
                    {
                        EvaluationVolunteerMissionRow["EMissionComments"] = txtMissionComments.Text;
                    }
                }
                MissionsEvaluationTable.Rows.Add(EvaluationVolunteerMissionRow);
            }
        }
        #endregion

        #region  Update Skills table
        if (ViewState["SkillsEvaluationTable"] == null)
        {
            CreateSkillsEvaluationDatatable();
        }

        DataTable SkillsEvaluationTable = (DataTable)ViewState["SkillsEvaluationTable"];

         //Delete existing mission for the selected volunteer
    LoopSkillStart: foreach (DataRow dr in SkillsEvaluationTable.Rows)
        {
            if (dr["EVolunteerId"].ToString() == VolunteerId.ToString() && dr["EDepartmentId"].ToString() == departmentId)
            {
                SkillsEvaluationTable.Rows.Remove(dr);
                goto LoopSkillStart;
            }
        }

        DataTable volunteerSkills = _AssociatedSkillsManager.GetVolunteerSkillsByVolunteerId(VolunteerId);

        foreach (DataRow dr in volunteerSkills.Rows)
        {
            DataRow EvaluationVolunteerSkillRow = SkillsEvaluationTable.NewRow();

            EvaluationVolunteerSkillRow["ESkillId"] = dr["SkillID"].ToString();
            EvaluationVolunteerSkillRow["EVolunteerId"] = VolunteerId;
            if (departmentId != null)
            {
                EvaluationVolunteerSkillRow["EDepartmentId"] = departmentId;
            }
            else
            {
                EvaluationVolunteerSkillRow["EDepartmentId"] = null;
            }

            DropDownList drpSkillLevel = (DropDownList)phVolunteerSkills.FindControl("drpSkillLevel" + dr["SkillID"].ToString());
            if (drpSkillLevel.SelectedValue != "Select")
            {
                EvaluationVolunteerSkillRow["ESkillLevelId"] = drpSkillLevel.SelectedValue;
                avrVDE += int.Parse(drpSkillLevel.SelectedValue);
                vdeCount++;
            }

            TextBox txtSkillComments = (TextBox)phVolunteerSkills.FindControl("txtSkillComments" + dr["SkillID"].ToString());
            if (txtSkillComments.ID == "txtSkillComments" + dr["SkillID"].ToString())
            {
                if (txtSkillComments.Text != string.Empty)
                {
                    EvaluationVolunteerSkillRow["ESkillComments"] = txtSkillComments.Text;
                }
            }
            SkillsEvaluationTable.Rows.Add(EvaluationVolunteerSkillRow);
        }
        #endregion

        #region Update Evaluation Table

        {
            DataTable evaluationTable = (DataTable)ViewState["EvaluationTable"];
            foreach (DataRow dr in evaluationTable.Rows)
            {
                if (dr["VolunteerId"].ToString() == VolunteerId.ToString())
                {
                    if (rdbRecommended.SelectedItem != null)
                    {
                        dr["IsRecommended"] = rdbRecommended.SelectedItem.Text;
                    }

                    if (departmentId == "ActivityDepartment")
                    {
                        if (avrVDE > 0)
                        {
                            avrVDE /= vdeCount;
                            dr["ActivityDepartmentEvaluation"] = Math.Round(avrVDE);
                        }
                        else
                        {
                            dr["ActivityDepartmentEvaluation"] = null;
                        }
                    }
                    else
                    {
                        if (avrVDE > 0)
                        {
                            avrVDE /= vdeCount;
                            dr["VolunteerDepartmentEvaluation"] = Math.Round(avrVDE);
                        }
                        else
                        {
                            dr["VolunteerDepartmentEvaluation"] = null;
                        }
                    }
                }
            }
        }
        #endregion

        GenerateEvaluationTable();
    }
    protected void btnAddActivity_Click(object sender, EventArgs e)
    {
        if (ValidateActivity())
        {
            SqlTransaction transactionInstance = _AssociatedActivitiesManager.BeginTransaction();
            try
            {
                #region Initiate activity instance
                Activity activityInstance = new Activity();

                if (txtActivityCodeNo.Text == string.Empty)
                    activityInstance.ActivityCodeNo = null;
                else
                    activityInstance.ActivityCodeNo = int.Parse(txtActivityCodeNo.Text);

                if (txtActivityCost.Text == string.Empty)
                    activityInstance.ActivityCost = null;
                else
                    activityInstance.ActivityCost = int.Parse(txtActivityCost.Text);

                activityInstance.ActivityDateFrom = DateTime.Parse(txtActivityDateFrom.Text);
                activityInstance.ActivityDateTo = DateTime.Parse(txtActivityDateTo.Text);
                activityInstance.ActivityDetails = txtActivityDetails.Text;
                activityInstance.ActivityDocument = hlnkActivityDocument.NavigateUrl;
                activityInstance.ActivityEntryDate = DateTime.Now;
                activityInstance.ActivityEntryUserID = CurrentUser.UserID;
                activityInstance.ActivityEvaluatorID = int.Parse(drpVolunteerDepartmentResponsibleUser.SelectedValue);
                activityInstance.ActivityFieldID = int.Parse(drpActivityField.SelectedValue);
                activityInstance.ActivityName = txtActivityName.Text;

                if (drpActivityPlace.SelectedValue == "Select")
                    activityInstance.ActivityPlaceID = null;
                else
                    activityInstance.ActivityPlaceID = int.Parse(drpActivityPlace.SelectedValue);

                if (txtActivityRequestDate.Text == string.Empty)
                    activityInstance.ActivityRequestDate = null;
                else
                    activityInstance.ActivityRequestDate = DateTime.Parse(txtActivityRequestDate.Text);

                activityInstance.ActivityRequirments = (ViewState["ActivityRequirements"] != null) ? ViewState["ActivityRequirements"].ToString() : string.Empty;
                 
                if (txtActivityRevenue.Text == string.Empty)
                    activityInstance.ActivityRevenue = null;
                else
                    activityInstance.ActivityRevenue = int.Parse(txtActivityRevenue.Text);

                if (txtActivityRequiredVolunteers.Text == string.Empty)
                    activityInstance.ActivityRequiredVolunteers = null;
                else
                    activityInstance.ActivityRequiredVolunteers = int.Parse(txtActivityRequiredVolunteers.Text);

                activityInstance.ActivityComments = txtActivityComments.Text;
                activityInstance.ActivityDepartmentOpinion = (ViewState["ActivityDepartmentOpinion"] != null) ? ViewState["ActivityDepartmentOpinion"].ToString() : string.Empty;
                activityInstance.ActivityVolunteerDepartmentOpinion =(ViewState["ActivityVolunteerDepartmentOpinion"] != null) ? ViewState["ActivityVolunteerDepartmentOpinion"].ToString() : string.Empty;

                #endregion
                if (btnAddActivity.Text == "أدخل بيانات النشاط")
                {
                    #region Insert Activity in the database
                    int activityId = _AssociatedActivitiesManager.InsertActivity(activityInstance, transactionInstance);

                    InsertActivityRelatedFields(activityId, transactionInstance);

                    _AssociatedActivitiesManager.CommitTransaction();

                    lblActivityResult.Text = "تم إدخال النشاط بنجاح";
                    lblActivityError.Text = string.Empty;
                    //ResetActivityControlsToDefaultValue(Page);
                    Response.Redirect("ActivitiesSearchResult.aspx");
                    #endregion
                }
                else if (btnAddActivity.Text == "تعديل بيانات النشاط")
                {
                    #region Update existing Activity
                    int activityId = int.Parse(Session["ActivityId"].ToString());
                    activityInstance.ActivityID = activityId;
                    _AssociatedActivitiesManager.UpdateActivity(activityInstance, transactionInstance);

                    //delete any existing data for the updated activity in all intermediate tables
                    //then reinsert the updated data
                    _AssociatedActivitiesManager.DeleteActivityRelatedTablesByActivityId(activityId, transactionInstance);

                    InsertActivityRelatedFields(activityId, transactionInstance);

                    _AssociatedActivitiesManager.CommitTransaction();

                    lblActivityResult.Text = "تم تعديل النشاط بنجاح";
                    lblActivityError.Text = string.Empty;
                  //  Response.Redirect("ActivitiesSearchResult.aspx?Update=true");
                    Response.Redirect("ActivitiesSearchResult.aspx");
                    #endregion
                }
            }
            catch (Exception ex)
            {
                lblActivityResult.Text = string.Empty;
                lblActivityError.Text = ex.Message;
                _AssociatedActivitiesManager.RollBackTransaction();
            }

        }
    }
    protected void btnFinishActivityVolunteersReal_Click(object sender, EventArgs e)
    {
        if (ViewState["ActivityResultRealTable"] != null)
        {
            if (ViewState["ActivityResultRealTableAll"] == null)
            {
                //Fill the gridview for step 3 (attendance phase)
                ViewState["ActivityResultRealTableAll"] = ViewState["ActivityResultRealTable"];
                grdActivityDaysReal.DataSource = (DataTable)ViewState["ActivityResultRealTableAll"];
                grdActivityDaysReal.DataBind();
            }
            else
            {
                //Fill the gridview for step 3 (attendance phase)
                DataTable originalActivityResultTable = (DataTable)ViewState["ActivityResultRealTableAll"];
                originalActivityResultTable.Merge((DataTable)ViewState["ActivityResultRealTable"]);
                ViewState["ActivityResultRealTableAll"] = originalActivityResultTable;
                grdActivityDaysReal.DataSource = originalActivityResultTable;
                grdActivityDaysReal.DataBind();
            }
        }
        ViewState["ActivityResultRealTable"] = null;
        GenerateEvaluationTable();
        GenerateSummary();
    }
    protected void btnAddActivityDayResult_Click(object sender, EventArgs e)
    {

        //System.Threading.Thread.Sleep(3000);
        mpeActivityResult.Show();
        if (ValidateActivityDay())
        {
            if (ViewState["ActivityResultTable"] == null)
            {
                CreateActivityResultDatatable();
            }

            DataTable ActivityResultTable = (DataTable)ViewState["ActivityResultTable"];

            DataRow row = ActivityResultTable.NewRow();

            row["ActivityDay"] = drpActivityDay.SelectedValue;
            row["Volunteer"] = drpVolunteerName.SelectedItem.Text;
            row["VolunteerId"] = drpVolunteerName.SelectedValue;

            string volunteerMissions = string.Empty;
            string volunteerMissionsId = string.Empty;
            foreach (ListItem item in chkTypeOfMissions.Items)
            {
                if (item.Selected)
                {
                    if (volunteerMissions == string.Empty)
                    {
                        volunteerMissions = item.Text;
                        volunteerMissionsId = item.Value;
                    }
                    else
                    {
                        volunteerMissions += ", " + item.Text;
                        volunteerMissionsId += "," + item.Value;
                    }
                }
            }

            row["VolunteerMissions"] = volunteerMissions;
            row["VolunteerMissionsId"] = volunteerMissionsId;

            //calaculate volunteer working hours
            if (txtWorkTimeFrom.Text != string.Empty && txtWorkTimeTo.Text != string.Empty)
            {
                decimal workingHours = 0;
                int fromSeparator = txtWorkTimeFrom.Text.IndexOf(":");
                int toSeparator = txtWorkTimeTo.Text.IndexOf(":");
                decimal WorkingFrom = decimal.Parse(txtWorkTimeFrom.Text.Substring(0, fromSeparator));
                WorkingFrom += decimal.Parse(txtWorkTimeFrom.Text.Substring(fromSeparator + 1)) / 60;
                decimal WorkingTo = decimal.Parse(txtWorkTimeTo.Text.Substring(0, toSeparator));
                WorkingTo += decimal.Parse(txtWorkTimeTo.Text.Substring(toSeparator + 1)) / 60;
                if (drpAmPmFrom.SelectedValue == "am" && drpAmPmTo.SelectedValue == "am")
                {
                    workingHours = WorkingTo - WorkingFrom;
                }
                else if (drpAmPmFrom.SelectedValue == "pm" && drpAmPmTo.SelectedValue == "pm")
                {
                    workingHours = WorkingTo - WorkingFrom;
                    WorkingFrom += 12;
                    WorkingTo += 12;
                }
                else if (drpAmPmFrom.SelectedValue == "am" && drpAmPmTo.SelectedValue == "pm")
                {
                    workingHours = WorkingTo - WorkingFrom + 12;
                    WorkingTo += 12;
                }
                else if (drpAmPmFrom.SelectedValue == "pm" && drpAmPmTo.SelectedValue == "am")
                {
                    workingHours = WorkingTo - WorkingFrom + 12;
                    WorkingFrom += 12;
                }
                row["WorkingTimeFrom"] = WorkingFrom.ToString();
                row["WorkingTimeTo"] = WorkingTo.ToString();
            }



            row["VolunteerWorkDetails"] = txtVolunteerWorkDetails.Text;

            if (btnAddActivityDayResult.Text == "إضافة")
            {
                //validate that the activity wasn't added before
                if (ViewState["ActivityResultTable"] != null)
                {
                    DataTable activtyResultTable = (DataTable)ViewState["ActivityResultTable"];
                    DataTable validationTable = ActivityResultTable.Copy();
                    if (ViewState["ActivityResultTableAll"] != null)
                    {
                        validationTable.Merge((DataTable)ViewState["ActivityResultTableAll"]);
                    }
                    foreach (DataRow dr in validationTable.Rows)
                    {
                        if (drpVolunteerName.SelectedValue == dr["VolunteerId"].ToString() && drpActivityDay.SelectedValue == dr["ActivityDay"].ToString())
                        {
                            imgActivityVolunteerV.Visible = true;
                            return;
                        }
                    }
                }

                int rowsCountOffset = 0;
                int resultIndex = 0;
                if (ViewState["ActivityResultTableAll"] != null)
                {
                    DataTable ActivityResultAll = (DataTable)ViewState["ActivityResultTableAll"];
                    if (ActivityResultAll.Rows.Count > 0)
                    {
                        rowsCountOffset = ActivityResultAll.Rows.Count;
                        resultIndex += int.Parse(ActivityResultAll.Rows[rowsCountOffset - 1]["ResultIndex"].ToString()) + 1;
                    }
                }
                int rowsCount = ActivityResultTable.Rows.Count;
                if (rowsCount > 0)
                {
                    resultIndex += int.Parse(ActivityResultTable.Rows[rowsCount - 1]["ResultIndex"].ToString()) + 1;
                }
                row["ResultIndex"] = resultIndex;
                ActivityResultTable.Rows.Add(row);
            }
            else if (btnAddActivityDayResult.Text == "تعديل")
            {
                int resultIndex = int.Parse(ViewState["ResultIndex"].ToString());
                row["ResultIndex"] = resultIndex;
                DataTable ActivityResultTableAll = (DataTable)ViewState["ActivityResultTableAll"];
                foreach (DataRow dr in ActivityResultTableAll.Rows)
                {
                    if (dr["ResultIndex"].ToString() == resultIndex.ToString())
                    {
                        int rowOrdinal = 0;
                        foreach (object rowColumn in row.ItemArray)
                        {
                            dr[rowOrdinal] = rowColumn.ToString();
                            rowOrdinal++;
                        }

                        //dr["ActivityDay"] = row["ActivityDay"];
                        //dr["Volunteer"] = row["Volunteer"];
                        //dr["VolunteerId"] = row["VolunteerId"];
                        //dr["VolunteerMissions"] = row["VolunteerMissions"];
                        //dr["VolunteerMissionsId"] = row["VolunteerMissionsId"];
                        //dr["WorkingTimeFrom"] = row["WorkingTimeFrom"];
                        //dr["WorkingTimeTo"] = row["WorkingTimeTo"];
                        //dr["VolunteerWorkDetails"] = row["VolunteerWorkDetails"];

                        break;
                    }
                }
                ViewState["ActivityResultTable"] = ActivityResultTableAll;
                grdActivityDays.DataSource = ActivityResultTableAll;
                grdActivityDays.DataBind();
                mpeActivityResult.Hide();
            }

            ViewState["ActivityResultTable"] = ActivityResultTable;

            BindActivtyResultDataGrid(ActivityResultTable);


        }
    }
    protected void btnAddDepartment_Click(object sender, EventArgs e)
    {
        mpeDepartment.Show();
        if (ValidateDepartment())
        {
            if (ViewState["DepartmentsTable"] == null)
            {
                CreateDepartmentsDatatable();
            }

            DataTable DepartmentsTable = (DataTable)ViewState["DepartmentsTable"];

            DataRow row = DepartmentsTable.NewRow();

            row["Department"] = drpDepartment.SelectedItem.Text;
            row["DepartmentResponsibleUser"] = drpDepartmentResponsibleUser.SelectedItem.Text;
            row["DepartmentId"] = drpDepartment.SelectedValue;
            row["DepartmentResponsibleUserId"] = drpDepartmentResponsibleUser.SelectedValue;
            row["DepartmentIndex"] = DepartmentsTable.Rows.Count + 1;

            if (btnAddDepartment.Text == "إضافة")
            {
                //validate that the department wasn't added before
                if (ViewState["DepartmentsTable"] != null)
                {
                    DataTable departmentsTable = (DataTable)ViewState["DepartmentsTable"];
                    foreach (DataRow dr in departmentsTable.Rows)
                    {
                        if (dr["Department"].ToString() == drpDepartment.SelectedItem.Text)
                        {
                            imgActivityDepartmentV.Visible = true;
                            return;
                        }
                    }
                }

                row["DepartmentIndex"] = DepartmentsTable.Rows.Count + 1;
                DepartmentsTable.Rows.Add(row);
            }
            else if (btnAddDepartment.Text == "تعديل")
            {
                int departmentIndex = int.Parse(ViewState["DepartmentIndex"].ToString()) - 1;
                row["DepartmentIndex"] = departmentIndex + 1;
                DepartmentsTable.Rows.RemoveAt(departmentIndex);
                DepartmentsTable.Rows.InsertAt(row, departmentIndex);
            }

            ViewState["DepartmentsTable"] = DepartmentsTable;

            BindDepartmentsDataGrid(DepartmentsTable);
            BindDepartmentEvaluatorUsers();
            mpeDepartment.Hide();
        }
    }
    protected void btnUploadActivityDocument_Click(object sender, EventArgs e)
    {
        if (fuActivityDocument.HasFile)
        {
            fuActivityDocument.SaveAs(Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuActivityDocument.FileName);
            hlnkActivityDocument.Text = fuActivityDocument.FileName;
            hlnkActivityDocument.Visible = true;
            hlnkActivityDocument.NavigateUrl = Request.PhysicalApplicationPath + @"\UploadedFiles\" + fuActivityDocument.FileName;
            imgBtnRemoveActivityDocument.Visible = true;
            fuActivityDocument.Visible = false;
            btnUploadActivityDocument.Visible = false;
        }
    }

    #endregion

    #region Link Buttons Event Handlers
    protected void lnkAddDayDetailsReal_Click(object sender, EventArgs e)
    {
        ResetActivityControlsToDefaultValue(DivActivityResultReal);
        grdActivityDaysRealOnDiv.DataBind();
        ViewState["ActivityResultRealTable"] = null;
        //reset all validation fields
        ResetValiadationImagesToDefaultValue(DivActivityResultReal);

        //file work time text fields with example data
        txtWorkTimeFromReal.Text = "";
        txtWorkTimeToReal.Text = "";

        txtWorkTimeFromReal.Enabled = true;
        txtWorkTimeToReal.Enabled = true;
        drpAmPmToReal.Enabled = true;
        drpAmPmFromReal.Enabled = true;

        btnAddActivityDayResultReal.Text = "إضافة";
        btnFinishActivityVolunteersReal.Visible = false;
        mpeActivityResultReal.Show();
        BindVolunteerMissionsReal(false);
        BindRealActivityData();

    }
    protected void lnkVolunteerDepartmentEvaluation_Command(object sender, CommandEventArgs e)
    {
        ResetActivityControlsToDefaultValue(divEvaluation);
        int volunteerId = int.Parse(e.CommandArgument.ToString());
        ViewState["EvaluationVolunteerId"] = volunteerId;
        ViewState["EvaluationDepartmentId"] = _AssociatedDepartmentsManager.GetDepartmentByName("إدارة المتطوعين").DepartmentID;
        BindEvaluationData();
        mpeEvaluation.Show();
        rdbRecommended.Visible = true;
        lblRecommended.Visible = true;
    }
    protected void lnkActivityDepartmentEvaluation_Command(object sender, CommandEventArgs e)
    {
        rdbRecommended.Visible = false;
        rdbRecommended.SelectedIndex = -1;
        lblRecommended.Visible = false;
        ResetActivityControlsToDefaultValue(divEvaluation);
        int volunteerId = int.Parse(e.CommandArgument.ToString());
        ViewState["EvaluationVolunteerId"] = volunteerId;
        ViewState["EvaluationDepartmentId"] = "ActivityDepartment";
        BindEvaluationData();
        mpeEvaluation.Show();
    }
    protected void lnkAddDepartment_Click(object sender, EventArgs e)
    {
        //show the department div
        mpeDepartment.Show();

        //reset all validation images on the div
        ResetValiadationImagesToDefaultValue(divDepartment);

        //reset all controls to default value
        ResetActivityControlsToDefaultValue(divDepartment);

        btnAddDepartment.Text = "إضافة";

        drpDepartmentResponsibleUser.Items.Clear();

        drpDepartmentResponsibleUser.Items.Add(new ListItem("إختار", "Select"));
    }
    protected void lnkAddDayDetails_Click(object sender, EventArgs e)
    {

        //make the update progress on the page invisible
        //upAddActivity.Visible = false;
        //reset the add acticity result div to  its default value
        ResetActivityControlsToDefaultValue(DivActivityResult);
        grdActivityDaysOnDiv.DataBind();
        ViewState["ActivityResultTable"] = null;
        //reset all validation fields
        ResetValiadationImagesToDefaultValue(DivActivityResult);

        //file work time text fields with example data
        txtWorkTimeFrom.Text = "";
        txtWorkTimeTo.Text = "";

        btnAddActivityDayResult.Text = "إضافة";
        btnFinishActivityVolunteers.Visible = false;
        mpeActivityResult.Show();
        BindVolunteerMissions(true);

    }
    protected void lnkVolunteer_Command(object sender, CommandEventArgs e)
    {
        int VolunteerId = int.Parse(e.CommandArgument.ToString());
        Session["VolunteerProfileId"] = VolunteerId;
        Response.Redirect("VolunteerProfile.aspx");
    }
    #endregion

    #region Image Buttons Event Handlers
    protected void imgBtnActivityDayDelete_Command(object sender, CommandEventArgs e)
    {
        string resultIndex = e.CommandArgument.ToString();
        if (ViewState["ActivityResultTableAll"] != null)
        {
            DataTable activityResultTable = (DataTable)ViewState["ActivityResultTableAll"];
            foreach (DataRow dr in activityResultTable.Rows)
            {
                string dd = dr["ResultIndex"].ToString();
                if (resultIndex == dr["ResultIndex"].ToString())
                {
                    dr.Delete();
                    break;
                }

            }
            grdActivityDays.DataSource = activityResultTable;
            grdActivityDays.DataBind();
        }


    }
    protected void imgBtnEditActivityDay_Command(object sender, CommandEventArgs e)
    {
        string resultIndex = e.CommandArgument.ToString();
        ViewState["ResultIndex"] = resultIndex;
        if (ViewState["ActivityResultTableAll"] != null)
        {
            DataTable activityResultTableAll = (DataTable)ViewState["ActivityResultTableAll"];
            foreach (DataRow dr in activityResultTableAll.Rows)
            {
                if (resultIndex == dr["ResultIndex"].ToString())
                {
                    //bind this row to the activity result div then show it
                    drpVolunteerName.SelectedValue = dr["VolunteerId"].ToString();
                    drpActivityDay.SelectedValue = dr["ActivityDay"].ToString();
                    //change the format of working time from decimal to clock format
                    string workingFrom = dr["WorkingTimeFrom"].ToString();
                    if (workingFrom != string.Empty)
                    {
                        if (decimal.Parse(workingFrom) > 13 || decimal.Parse(workingFrom) == 13)
                        {
                            workingFrom = (decimal.Parse(workingFrom) - 12).ToString();
                            drpAmPmFrom.SelectedValue = "pm";
                        }
                        int dotIndex = workingFrom.IndexOf(".");
                        if (dotIndex == -1)
                        {
                            dotIndex = workingFrom.Length;
                            workingFrom += ".0";
                        }
                        txtWorkTimeFrom.Text = workingFrom.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingFrom.Substring(dotIndex))) * 60).ToString();
                    }

                    string workingTo = dr["WorkingTimeTo"].ToString();
                    if (workingTo != string.Empty)
                    {
                        if (decimal.Parse(workingTo) > 13 || decimal.Parse(workingTo) == 13)
                        {
                            workingTo = (decimal.Parse(workingTo) - 12).ToString();
                            drpAmPmTo.SelectedValue = "pm";
                        }
                        int dotIndex = workingTo.IndexOf(".");
                        if (dotIndex == -1)
                        {
                            dotIndex = workingTo.Length;
                            workingTo += ".0";
                        }
                        txtWorkTimeTo.Text = workingTo.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingTo.Substring(dotIndex))) * 60).ToString();
                    }

                    BindVolunteerMissions(false);

                    string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                    string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                    List<string> resultMissionIds = new List<string>(resultMissionIdsArray.Length);
                    resultMissionIds.AddRange(resultMissionIdsArray);
                    foreach (string volunteerMissionId in resultMissionIds)
                    {
                        ListItem volunteerMission = chkTypeOfMissions.Items.FindByValue(volunteerMissionId);
                        if (volunteerMission != null)
                            volunteerMission.Selected = true;
                    }

                    txtVolunteerWorkDetails.Text = dr["VolunteerWorkDetails"].ToString();

                    btnAddActivityDayResult.Text = "تعديل";
                    btnFinishActivityVolunteers.Visible = false;
                    grdActivityDaysOnDiv.DataBind();

                    mpeActivityResult.Show();
                    break;
                }

            }

        }

    }
    protected void imgBtnActivityDepartmentDelete_Command(object sender, CommandEventArgs e)
    {
        string departmentIndex = e.CommandArgument.ToString();
        if (ViewState["DepartmentsTable"] != null)
        {
            DataTable departmentsTable = (DataTable)ViewState["DepartmentsTable"];
            foreach (DataRow dr in departmentsTable.Rows)
            {
                if (departmentIndex == dr["DepartmentIndex"].ToString())
                {
                    dr.Delete();
                    break;
                }

            }
            BindDepartmentsDataGrid(departmentsTable);
        }
    }
    protected void imgBtnEditActivityDepartment_Command(object sender, CommandEventArgs e)
    {
        string departmentIndex = e.CommandArgument.ToString();
        ViewState["DepartmentIndex"] = departmentIndex;
        if (ViewState["DepartmentsTable"] != null)
        {
            DataTable activityResultTable = (DataTable)ViewState["DepartmentsTable"];
            foreach (DataRow dr in activityResultTable.Rows)
            {
                if (departmentIndex == dr["DepartmentIndex"].ToString())
                {
                    //bind this row to the activity result div then show it
                    drpDepartment.SelectedValue = dr["DepartmentId"].ToString();
                    drpDepartment_SelectedIndexChanged(this, new EventArgs());
                    drpDepartmentResponsibleUser.SelectedValue = dr["DepartmentResponsibleUserId"].ToString();
                    btnAddDepartment.Text = "تعديل";

                    mpeDepartment.Show();
                    break;
                }

            }

        }
    }
    protected void imgBtnActivityDayDeleteOnDiv_Command1(object sender, CommandEventArgs e)
    {
        string resultIndex = e.CommandArgument.ToString();
        if (ViewState["ActivityResultRealTable"] != null)
        {
            DataTable activityResultRealTable = (DataTable)ViewState["ActivityResultRealTable"];
            foreach (DataRow dr in activityResultRealTable.Rows)
            {
                if (resultIndex == dr["ResultIndex"].ToString())
                {
                    dr.Delete();
                    break;
                }

            }
            BindActivtyResultRealDataGrid(activityResultRealTable);
        }
        mpeActivityResultReal.Show();
    }
    protected void imgBtnActivityDayDelete_Command1(object sender, CommandEventArgs e)
    {
        string resultIndex = e.CommandArgument.ToString();
        if (ViewState["ActivityResultRealTableAll"] != null)
        {
            DataTable activityResultRealTable = (DataTable)ViewState["ActivityResultRealTableAll"];
            foreach (DataRow dr in activityResultRealTable.Rows)
            {
                string dd = dr["ResultIndex"].ToString();
                if (resultIndex == dr["ResultIndex"].ToString())
                {
                    dr.Delete();
                    break;
                }

            }
            grdActivityDaysReal.DataSource = activityResultRealTable;
            grdActivityDaysReal.DataBind();
        }

    }
    protected void imgBtnEditActivityDay_Command2(object sender, CommandEventArgs e)
    {
        string resultIndex = e.CommandArgument.ToString();
        ViewState["ResultIndex"] = resultIndex;
        if (ViewState["ActivityResultRealTableAll"] != null)
        {
            DataTable activityResultRealTableAll = (DataTable)ViewState["ActivityResultRealTableAll"];
            BindRealActivityData();
            foreach (DataRow dr in activityResultRealTableAll.Rows)
            {
                if (resultIndex == dr["ResultIndex"].ToString())
                {
                    //bind this row to the activity result div then show it
                    drpVolunteerNameReal.SelectedValue = dr["VolunteerId"].ToString();
                    drpActivityDayReal.SelectedValue = dr["ActivityDay"].ToString();
                    //change the format of working time from decimal to clock format
                    if (dr["WorkingTimeFrom"].ToString() != string.Empty && dr["WorkingTimeTo"].ToString() != string.Empty)
                    {
                        string workingFrom = dr["WorkingTimeFrom"].ToString();
                        if (decimal.Parse(workingFrom) > 13 || decimal.Parse(workingFrom) == 13)
                        {
                            workingFrom = (decimal.Parse(workingFrom) - 12).ToString();
                            drpAmPmFromReal.SelectedValue = "pm";
                        }
                        int dotIndex = workingFrom.IndexOf(".");
                        if (dotIndex == -1)
                        {
                            dotIndex = workingFrom.Length;
                            workingFrom += ".0";
                        }
                        txtWorkTimeFromReal.Text = workingFrom.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingFrom.Substring(dotIndex))) * 60).ToString();

                        string workingTo = dr["WorkingTimeTo"].ToString();
                        if (decimal.Parse(workingTo) > 13 || decimal.Parse(workingTo) == 13)
                        {
                            workingTo = (decimal.Parse(workingTo) - 12).ToString();
                            drpAmPmToReal.SelectedValue = "pm";
                        }
                        dotIndex = workingTo.IndexOf(".");
                        if (dotIndex == -1)
                        {
                            dotIndex = workingTo.Length;
                            workingTo += ".0";
                        }
                        txtWorkTimeToReal.Text = workingTo.Substring(0, dotIndex) + ":" + Math.Round((decimal.Parse(workingTo.Substring(dotIndex))) * 60).ToString();
                    }
                    BindVolunteerMissionsReal(false);

                    string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                    string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                    List<string> resultMissionIds = new List<string>(resultMissionIdsArray.Length);
                    resultMissionIds.AddRange(resultMissionIdsArray);
                    foreach (string volunteerMissionId in resultMissionIds)
                    {
                        ListItem volunteerMission = chkTypeOfMissionsReal.Items.FindByValue(volunteerMissionId);
                        if (volunteerMission != null)
                            volunteerMission.Selected = true;
                    }

                    txtVolunteerWorkDetailsReal.Text = dr["VolunteerWorkDetails"].ToString();

                    btnAddActivityDayResultReal.Text = "تعديل";
                    btnFinishActivityVolunteersReal.Visible = false;
                    grdActivityDaysRealOnDiv.DataBind();

                    mpeActivityResultReal.Show();
                    break;
                }

            }

        }
        AttendanceStateSetUI();
    }
    protected void imgBtnActivityDayDeleteOnDiv_Command(object sender, CommandEventArgs e)
    {
        string resultIndex = e.CommandArgument.ToString();
        if (ViewState["ActivityResultTable"] != null)
        {
            DataTable activityResultTable = (DataTable)ViewState["ActivityResultTable"];
            foreach (DataRow dr in activityResultTable.Rows)
            {
                if (resultIndex == dr["ResultIndex"].ToString())
                {
                    dr.Delete();
                    break;
                }

            }
            BindActivtyResultDataGrid(activityResultTable);
        }
        mpeActivityResult.Show();
    }
    protected void imgBtnRemoveActivityDocument_Click(object sender, ImageClickEventArgs e)
    {
        if (File.Exists(hlnkActivityDocument.NavigateUrl))
        {
            File.Delete(hlnkActivityDocument.NavigateUrl);
        }
        fuActivityDocument.Visible = true;
        imgBtnRemoveActivityDocument.Visible = false;
        hlnkActivityDocument.Visible = false;
        hlnkActivityDocument.NavigateUrl = string.Empty;
        btnUploadActivityDocument.Visible = true;
    }
    #endregion


    private void GenerateSummary()
    {
        int volunteerCount = 0;
        int activityDaysCount = 0;
        decimal activityHours = 0;

        int activityCost = 0;
        int activtyRevenue = 0;
        string activityMissions = string.Empty;
        string activityStart = string.Empty;
        string activityEnd = string.Empty;
        int newVolunteersCount = 0;
        string recommendedVolunteers = string.Empty;
        int recommendedVolunteersCount = 0;

        string activityField = drpActivityField.SelectedValue;

        if (txtActivityCost.Text != string.Empty)
            activityCost = int.Parse(txtActivityCost.Text);

        if (txtActivityRevenue.Text != string.Empty)
            activtyRevenue = int.Parse(txtActivityRevenue.Text);

        List<string> volunteersList = new List<string>();
        List<string> activityDays = new List<string>();
        List<string> activityMissionsIds = new List<string>();
        DataTable activityResultRealTable = (DataTable)ViewState["ActivityResultRealTableAll"];
        foreach (DataRow dr in activityResultRealTable.Rows)
        {
            string existingVolunteer = volunteersList.Find(delegate(string _volunteerId) { return _volunteerId == dr["VolunteerId"].ToString(); });
            if (existingVolunteer == null)
            {
                volunteersList.Add(dr["VolunteerId"].ToString());

                //check if the current volunteer is new to this activity field
                VolunteerSearchRecord searchRecord = new VolunteerSearchRecord();
                searchRecord.vName = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(dr["VolunteerId"].ToString())).vName;
                searchRecord.NvFields = "<Root><Fields fieldid=\"" + activityField + "\"/></Root>";
                bool isNewVolunteer = (int.Parse(_AssociatedVolunteersManager.Search(searchRecord, 0, 1).Tables[0].Rows[0]["AllRowsCount"].ToString()) > 0);
                if (isNewVolunteer)
                {
                    newVolunteersCount++;
                }

            }

            if (activityStart == string.Empty || DateTime.Parse(activityStart) > DateTime.Parse(dr["ActivityDay"].ToString()))
            {
                activityStart = dr["ActivityDay"].ToString();
            }

            if (activityEnd == string.Empty || DateTime.Parse(activityEnd) < DateTime.Parse(dr["ActivityDay"].ToString()))
            {
                activityEnd = dr["ActivityDay"].ToString();
            }

            string existingDay = activityDays.Find(delegate(string _activtyDay) { return _activtyDay == dr["ActivityDay"].ToString(); });
            if (existingDay == null)
            {
                activityDays.Add(dr["ActivityDay"].ToString());
            }

            if (dr["WorkingTimeTo"].ToString() != string.Empty && dr["WorkingTimeFrom"].ToString() != string.Empty)
            {
                activityHours += decimal.Parse(dr["WorkingTimeTo"].ToString()) - decimal.Parse(dr["WorkingTimeFrom"].ToString());
            }

            if (dr["VolunteerMissionsId"] != null && dr["VolunteerMissionsId"].ToString() != string.Empty)
            {
                string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                List<string> resultMissionIds = new List<string>(resultMissionIdsArray.Length);
                resultMissionIds.AddRange(resultMissionIdsArray);
                foreach (string missionId in resultMissionIds)
                {
                    string existingMissionId = activityMissionsIds.Find(delegate(string _MissionId) { return _MissionId == missionId; });
                    if (existingMissionId == null)
                    {
                        activityMissionsIds.Add(missionId);
                        if (activityMissions == string.Empty)
                        {
                            activityMissions = _AssociatedMissionsManager.GetMissionByMissionId(int.Parse(missionId)).MissionName;
                        }
                        else
                        {
                            activityMissions += ", " + _AssociatedMissionsManager.GetMissionByMissionId(int.Parse(missionId)).MissionName;
                        }
                    }
                }
            }
        }
        volunteerCount = volunteersList.Count;
        activityDaysCount = activityDays.Count;

        if (ViewState["EvaluationTable"] != null)
        {
            DataTable evaluationTable = (DataTable)ViewState["EvaluationTable"];
            foreach (DataRow dr in evaluationTable.Rows)
            {
                if (dr["IsRecommended"] != null && dr["IsRecommended"].ToString() == "نعم")
                {
                    string volunteerName = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(dr["VolunteerId"].ToString())).vName;
                    recommendedVolunteers += (recommendedVolunteers == string.Empty) ? volunteerName : ", " + volunteerName;
                    recommendedVolunteersCount++;
                }
            }
        }

        lblActivitySummary.Text = "تم الإستعانة بعدد " + volunteerCount + " متطوع " + Environment.NewLine;

        if (newVolunteersCount > 0)
        {
            lblActivitySummary.Text += " منهم " + newVolunteersCount.ToString() + " جديد " + Environment.NewLine;
        }
        if (recommendedVolunteersCount > 0)
        {
            lblActivitySummary.Text += "و يوصى بالإستعانة ب " + recommendedVolunteersCount.ToString() + Environment.NewLine +
                                                                 " و هم " + recommendedVolunteers.ToString() + Environment.NewLine;
        }

        lblActivitySummary.Text += "على مدار " + activityDaysCount + " يوم " + Environment.NewLine +
                                                              "فى الفترة من " + activityStart + " إلى " + activityEnd + Environment.NewLine +
                                                              " بإجمالى " + Math.Round(activityHours) + " ساعة " + Environment.NewLine;

        if (activityCost > 0)
        {
            lblActivitySummary.Text += "و تكلفة " + activityCost;
        }
        if (activtyRevenue > 0)
        {
            lblActivitySummary.Text += " جنيه و إيراد " + activtyRevenue;
        }
        if (activityMissions != string.Empty)
        {
            lblActivitySummary.Text += " و تم القيام ب  " + activityMissions;
        }
    }
    private void GenerateEvaluationTable()
    {
        if (ViewState["ActivityResultRealTableAll"] != null)
        {
            if (ViewState["EvaluationTable"] == null)
            {
                CreateEvaluationDatatable();
            }

            DataTable EvaluationTable = (DataTable)ViewState["EvaluationTable"];

            DataTable ActivityResultRealTable = (DataTable)ViewState["ActivityResultRealTableAll"];

            //Get distinct volunteers
            List<int?> VolunteersId = new List<int?>();
            foreach (DataRow dr in ActivityResultRealTable.Rows)
            {
                int? VolunteerId = VolunteersId.Find(delegate(int? _VolunteerId) { return _VolunteerId == int.Parse(dr["VolunteerId"].ToString()); });
                if (!VolunteerId.HasValue)
                {
                    VolunteersId.Add(int.Parse(dr["VolunteerId"].ToString()));
                }
            }

            foreach (int VolunteerId in VolunteersId)
            {
                bool IsEvaluationRowUpdated = false;
                foreach (DataRow EvaluationRow in EvaluationTable.Rows)
                {
                    if (EvaluationRow["VolunteerId"].ToString() == VolunteerId.ToString())
                    {
                        //Edit existing Evaluation Row
                        UpdateEvaluationRow(EvaluationRow, ActivityResultRealTable);
                        IsEvaluationRowUpdated = true;
                        break;
                    }
                }
                if (IsEvaluationRowUpdated == false)
                {
                    //Add new evaluation Row
                    DataRow newEvaluationRow = EvaluationTable.NewRow();
                    newEvaluationRow["VolunteerId"] = VolunteerId;
                    UpdateEvaluationRow(newEvaluationRow, ActivityResultRealTable);
                    EvaluationTable.Rows.Add(newEvaluationRow);
                }
            }
            ViewState["EvaluationTable"] = EvaluationTable;
            grdActivityEvaluation.DataSource = EvaluationTable;
            grdActivityEvaluation.DataBind();
        }
    }
    private void GenerateVolunteerMissionsAndSkills(int VolunteerId)
    {
        phVolunteerSkills.Controls.Clear();
        phVolunteerMissions.Controls.Clear();

        //Generate Volunteer Skills from the Volunteer's profile
        DataTable volunteerSkills = _AssociatedSkillsManager.GetVolunteerSkillsByVolunteerId(VolunteerId);
        foreach (DataRow dr in volunteerSkills.Rows)
        {
            Skill volunteerSkill = _AssociatedSkillsManager.GetSkillById(int.Parse(dr["SkillId"].ToString()));

            Label lblSkillName = new Label();
            lblSkillName.ID = "lblSkill" + volunteerSkill.SkillID.ToString();
            lblSkillName.Text = volunteerSkill.SkillName + " : ";

            DropDownList drpEvaluationLevel = new DropDownList();
            drpEvaluationLevel.ID = "drpSkillLevel" + volunteerSkill.SkillID.ToString();
            drpEvaluationLevel.Items.Add(new ListItem("إختار", "Select"));
            foreach (EvaluationLevel level in Enum.GetValues(typeof(EvaluationLevel)))
            {
                drpEvaluationLevel.Items.Add(new ListItem(level.ToString(), ((int)level).ToString()));
            }

            TextBox txtVolunteerSkillComments = new TextBox();
            txtVolunteerSkillComments.ID = "txtSkillComments" + volunteerSkill.SkillID.ToString();

            Label lblSeparator = new Label();
            lblSeparator.Text = "<br/><br/>";
            Label lblSpace = new Label();
            lblSpace.Text = "  ";

            phVolunteerSkills.Controls.Add(lblSkillName);
            phVolunteerSkills.Controls.Add(drpEvaluationLevel);
            phVolunteerSkills.Controls.Add(lblSpace);
            phVolunteerSkills.Controls.Add(txtVolunteerSkillComments);
            phVolunteerSkills.Controls.Add(lblSeparator);
        }

        //Generate Volunteer missions from the "ActivityResultRealTable" (The data submitted in step 3 phase B)
        if (ViewState["ActivityResultRealTableAll"] != null)
        {
            DataTable ActivityResultRealTableAll = (DataTable)ViewState["ActivityResultRealTableAll"];

            //Get Volunteer's missions across all the activity days
            List<string> resultMissionIdsList = new List<string>();
            foreach (DataRow dr in ActivityResultRealTableAll.Rows)
            {
                if (dr["VolunteerId"].ToString() == VolunteerId.ToString())
                {
                    string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                    string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                    foreach (string missionId in resultMissionIdsArray)
                    {
                        string existingMissionId = resultMissionIdsList.Find(delegate(string _MissionId) { return _MissionId == missionId; });
                        if (existingMissionId == null)
                        {
                            resultMissionIdsList.Add(missionId);
                        }
                    }
                }
            }

            //generate evaluation items for the volunteer's missions

            foreach (string missionId in resultMissionIdsList)
            {
                if (!string.IsNullOrEmpty(missionId))
                {
                    Mission volunteerMission = _AssociatedMissionsManager.GetMissionByMissionId(int.Parse(missionId));

                    Label lblMissionName = new Label();
                    lblMissionName.ID = "lblMission" + volunteerMission.MissionID.ToString();
                    lblMissionName.Text = volunteerMission.MissionName + " : ";

                    DropDownList drpEvaluationLevel = new DropDownList();
                    drpEvaluationLevel.ID = "drpMissionLevel" + volunteerMission.MissionID.ToString();
                    drpEvaluationLevel.Items.Add(new ListItem("إختار", "Select"));
                    foreach (EvaluationLevel level in Enum.GetValues(typeof(EvaluationLevel)))
                    {
                        drpEvaluationLevel.Items.Add(new ListItem(level.ToString(), ((int)level).ToString()));
                    }

                    TextBox txtVolunteerMissionComments = new TextBox();
                    txtVolunteerMissionComments.ID = "txtMissionComments" + volunteerMission.MissionID.ToString();

                    Label lblSeparator = new Label();
                    lblSeparator.Text = "<br/><br/>";
                    Label lblSpace = new Label();
                    lblSpace.Text = "  ";

                    phVolunteerMissions.Controls.Add(lblMissionName);
                    phVolunteerMissions.Controls.Add(drpEvaluationLevel);
                    phVolunteerMissions.Controls.Add(lblSpace);
                    phVolunteerMissions.Controls.Add(txtVolunteerMissionComments);
                    phVolunteerMissions.Controls.Add(lblSeparator);
                }
            }
        }
    }
    private void UpdateEvaluationRow(DataRow EvaluationRow, DataTable ActivityResultRealTable)
    {
        int workingDays = 0;
        decimal workingHours = 0;
        string VolunteerName = string.Empty;
        foreach (DataRow ActivtyResultRow in ActivityResultRealTable.Rows)
        {
            if (EvaluationRow["VolunteerId"].ToString() == ActivtyResultRow["VolunteerId"].ToString())
            {
                workingDays++;
                if (ActivtyResultRow["WorkingTimeTo"].ToString() != string.Empty && ActivtyResultRow["WorkingTimeFrom"].ToString() != string.Empty)
                {
                    workingHours += decimal.Parse(ActivtyResultRow["WorkingTimeTo"].ToString()) - decimal.Parse(ActivtyResultRow["WorkingTimeFrom"].ToString());
                }
                VolunteerName = ActivtyResultRow["Volunteer"].ToString();
            }
        }
        EvaluationRow["VolunteerDays"] = workingDays;
        EvaluationRow["VolunteerHours"] = workingHours;
        EvaluationRow["Volunteer"] = VolunteerName;
    }

    private void InsertActivityRelatedFields(int activityId, SqlTransaction transactionInstance)
    {
        #region Insert Activity Result including volunteer missions
        //code to add activity result within the transaction of adding new activity
        if (ViewState["ActivityResultTableAll"] != null)
        {

            DataTable ActivityResultTable = (DataTable)ViewState["ActivityResultTableAll"];
            foreach (DataRow dr in ActivityResultTable.Rows)
            {

                ActivityResult activityResultInstance = new ActivityResult();
                activityResultInstance.RActivityID = activityId;
                activityResultInstance.RDay = DateTime.Parse(dr["ActivityDay"].ToString());
                string s = dr["WorkingTimeFrom"].ToString();
                activityResultInstance.RVolTimeFrom = (dr["WorkingTimeFrom"].ToString() == string.Empty) ? (float?)null : float.Parse(dr["WorkingTimeFrom"].ToString());
                activityResultInstance.RVolTimeTo = (dr["WorkingTimeTo"].ToString() == string.Empty) ? (float?)null : float.Parse(dr["WorkingTimeTo"].ToString());
                activityResultInstance.RVolunteerID = int.Parse(dr["VolunteerId"].ToString());
                if (dr["VolunteerWorkDetails"] == null)
                    activityResultInstance.RVolWorkDetails = null;
                else
                    activityResultInstance.RVolWorkDetails = dr["VolunteerWorkDetails"].ToString();

                int resultId = _AssociatedActivitiesManager.InsertActivityResult(activityResultInstance, transactionInstance);

                //Add volunteer missions  to "FBV_Tbl_Result_Mission" table within the transaction of adding new activity
                if (dr["VolunteerMissionsId"] != null && dr["VolunteerMissionsId"].ToString() != string.Empty)
                {
                    string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                    string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                    List<string> resultMissionIds = new List<string>(resultMissionIdsArray.Length);
                    resultMissionIds.AddRange(resultMissionIdsArray);
                    foreach (string resultMissionId in resultMissionIds)
                    {
                        ResultMission resultMissionInstance = new ResultMission();
                        resultMissionInstance.ResultID = resultId;
                        resultMissionInstance.RMissionID = int.Parse(resultMissionId);
                        _AssociatedActivitiesManager.InsertActivityResultMission(resultMissionInstance, transactionInstance);
                    }
                }
            }
        }
        #endregion

        #region Insert Activity Real Result including volunteer missions
        //code to add activity result within the transaction of adding new activity
        if (ViewState["ActivityResultRealTableAll"] != null)
        {

            DataTable ActivityResultRealTable = (DataTable)ViewState["ActivityResultRealTableAll"];
            foreach (DataRow dr in ActivityResultRealTable.Rows)
            {

                ActivityResult activityResultRealInstance = new ActivityResult();
                activityResultRealInstance.RActivityID = activityId;
                activityResultRealInstance.RDay = DateTime.Parse(dr["ActivityDay"].ToString());
                activityResultRealInstance.RVolTimeFrom = (dr["WorkingTimeFrom"].ToString() == string.Empty) ? (float?)null : float.Parse(dr["WorkingTimeFrom"].ToString());
                activityResultRealInstance.RVolTimeTo = (dr["WorkingTimeTo"].ToString() == string.Empty) ? (float?)null : float.Parse(dr["WorkingTimeTo"].ToString());
                activityResultRealInstance.RVolunteerID = int.Parse(dr["VolunteerId"].ToString());

                if (dr["VolunteerAttendanceStateId"].ToString() == string.Empty)
                    activityResultRealInstance.RAttendanceState = null;
                else
                    activityResultRealInstance.RAttendanceState = int.Parse(dr["VolunteerAttendanceStateId"].ToString());

                if (dr["VolunteerWorkDetails"] == null)
                    activityResultRealInstance.RVolWorkDetails = null;
                else
                    activityResultRealInstance.RVolWorkDetails = dr["VolunteerWorkDetails"].ToString();

                int resultId = _AssociatedActivitiesManager.InsertActivityResultReal(activityResultRealInstance, transactionInstance);

                //Add volunteer missions  to "FBV_Tbl_Result_Mission" table within the transaction of adding new activity
                if (dr["VolunteerMissionsId"] != null && dr["VolunteerMissionsId"].ToString() != string.Empty)
                {
                    string resultMissionIdsString = dr["VolunteerMissionsId"].ToString();
                    string[] resultMissionIdsArray = resultMissionIdsString.Split(',');
                    List<string> resultMissionIds = new List<string>(resultMissionIdsArray.Length);
                    resultMissionIds.AddRange(resultMissionIdsArray);
                    foreach (string resultMissionId in resultMissionIds)
                    {
                        ResultMission resultMissionInstance = new ResultMission();
                        resultMissionInstance.ResultID = resultId;
                        resultMissionInstance.RMissionID = int.Parse(resultMissionId);
                        _AssociatedActivitiesManager.InsertActivityResultRealMission(resultMissionInstance, transactionInstance);
                    }
                }
            }
        }
        #endregion

        #region Insert activity departments
        //code to add department within the the transaction of adding new activity
        if (ViewState["DepartmentsTable"] != null)
        {
            DataTable DepartmentsTable = (DataTable)ViewState["DepartmentsTable"];
            foreach (DataRow dr in DepartmentsTable.Rows)
            {
                ActivityDepartment activityDepartmentInstance = new ActivityDepartment();
                activityDepartmentInstance.ActivityID = activityId;
                activityDepartmentInstance.DepartmentID = int.Parse(dr["DepartmentId"].ToString());
                activityDepartmentInstance.UserID = int.Parse(dr["DepartmentResponsibleUserId"].ToString());
                _AssociatedActivitiesManager.InsertActivityDeopartment(activityDepartmentInstance, transactionInstance);
            }
        }
        #endregion

        #region Insert activity missions
        //code to add activity missions within the add acitivity tranasaction
        foreach (ListItem item in chkVolunteerMissions.Items)
        {
            if (item.Selected == true)
            {
                ActivityMission activityMissionInstance = new ActivityMission();
                activityMissionInstance.ActivityID = activityId;
                activityMissionInstance.MissionId = int.Parse(item.Value);
                _AssociatedActivitiesManager.InsertActivityMission(activityMissionInstance, transactionInstance);
            }
        }
        #endregion

        #region Insert activity Evaluation tables
        if (ViewState["EvaluationTable"] != null)
        {
            DataTable evaluationTable = (DataTable)ViewState["EvaluationTable"];
            DataTable evaluationSkillsTable = (DataTable)ViewState["SkillsEvaluationTable"];
            DataTable evaluationMissionsTable = (DataTable)ViewState["MissionsEvaluationTable"];
            foreach (DataRow dr in evaluationTable.Rows)
            {
                ActivityEvaluation activityEvaluationInstance = new ActivityEvaluation();
                activityEvaluationInstance.EActivityID = activityId;
                activityEvaluationInstance.EVolunteerID = int.Parse(dr["VolunteerId"].ToString());
                if (dr["IsRecommended"] != null && dr["IsRecommended"].ToString() != string.Empty)
                {
                    if (dr["IsRecommended"].ToString() == "نعم")
                    {
                        activityEvaluationInstance.EVolunteerIsRecommended = true;
                    }
                    else if (dr["IsRecommended"].ToString() == "لا")
                    {
                        activityEvaluationInstance.EVolunteerIsRecommended = false;
                    }
                }
                if (dr["RecommendedComments"] != null)
                    activityEvaluationInstance.EVolunteerRecommendedComments = dr["RecommendedComments"].ToString();
                activityEvaluationInstance.EVolunteersWorkingDays = int.Parse(dr["VolunteerDays"].ToString());
                activityEvaluationInstance.EVolunteerWorkingHours = decimal.Parse(dr["VolunteerHours"].ToString());
                if (dr["ActivityDepartmentEvaluation"] != null)
                    activityEvaluationInstance.EActivityDepartmentEvaluation = dr["ActivityDepartmentEvaluation"].ToString();
                if (dr["VolunteerDepartmentEvaluation"] != null)
                    activityEvaluationInstance.EVolunteerDepartmentEvaluation = dr["VolunteerDepartmentEvaluation"].ToString();

                int evaluationId = _AssociatedActivitiesManager.InsertActivityEvaluation(activityEvaluationInstance, transactionInstance);

                if (evaluationSkillsTable != null)
                {
                    foreach (DataRow drES in evaluationSkillsTable.Rows)
                    {
                        if (drES["EVolunteerId"].ToString() == dr["VolunteerId"].ToString())
                        {
                            string d = drES["EDepartmentId"].ToString();
                            ActivityEvaluationSkill evaluationSkillInstance = new ActivityEvaluationSkill();
                            if (drES["EDepartmentId"] != null && drES["EDepartmentId"].ToString() != "ActivityDepartment")
                                evaluationSkillInstance.EdepartmentID = int.Parse(drES["EDepartmentId"].ToString());
                            evaluationSkillInstance.ESkillComments = drES["ESkillComments"].ToString();
                            evaluationSkillInstance.ESkillID = int.Parse(drES["ESkillId"].ToString());

                            if (!string.IsNullOrEmpty(drES["ESkillLevelId"].ToString()))
                                evaluationSkillInstance.ESkillLevel = int.Parse(drES["ESkillLevelId"].ToString());

                            evaluationSkillInstance.EvaluationID = evaluationId;
                            _AssociatedActivitiesManager.InsertActivityEvaluationSkills(evaluationSkillInstance, transactionInstance);
                        }
                    }
                }

                if (evaluationMissionsTable != null)
                {
                    foreach (DataRow drEM in evaluationMissionsTable.Rows)
                    {
                        if (drEM["EVolunteerId"].ToString() == dr["VolunteerId"].ToString())
                        {
                            ActivityEvaluationMission evaluationMissionInstance = new ActivityEvaluationMission();
                            if (drEM["EDepartmentId"] != null && drEM["EDepartmentId"].ToString() != "ActivityDepartment")
                                evaluationMissionInstance.EDepartmentID = int.Parse(drEM["EDepartmentId"].ToString());
                            evaluationMissionInstance.EMissionComments = drEM["EMissionComments"].ToString();
                            evaluationMissionInstance.EMissionID = int.Parse(drEM["EMissionId"].ToString());

                            if (!string.IsNullOrEmpty(drEM["EMissionLevelId"].ToString()))
                                evaluationMissionInstance.EMissionLevel = int.Parse(drEM["EMissionLevelId"].ToString());

                            evaluationMissionInstance.EvaluationID = evaluationId;
                            _AssociatedActivitiesManager.InsertActivityEvaluationMissions(evaluationMissionInstance, transactionInstance);
                        }
                    }
                }
            }
        }
        #endregion
    }


    protected void lnkActivityDepartmentOpinion_Click(object sender, EventArgs e)
    {
        ViewState["fckEditorField"] = "ActivityDepartmentOpinion";
        fckEditor.Value = (ViewState["ActivityDepartmentOpinion"] != null) ? ViewState["ActivityDepartmentOpinion"].ToString() : string.Empty;
        mpeFckEditor.Show();
    }
    protected void btnFinishFckEditor_Click(object sender, EventArgs e)
    {
        string fckEditorField = ViewState["fckEditorField"].ToString();
        switch (fckEditorField)
        { 
            case "ActivityDepartmentOpinion":
                ViewState["ActivityDepartmentOpinion"] = fckEditor.Value;
                imgActivityDepartmentOpinion .Visible=(string.IsNullOrEmpty(ViewState["ActivityDepartmentOpinion"].ToString()))? false:true;
                break;
            case "ActivityVolunteerDepartmentOpinion":
                ViewState["ActivityVolunteerDepartmentOpinion"] = fckEditor.Value;
                imgActivityVolunteerDepartmentOpinion .Visible = (string.IsNullOrEmpty(ViewState["ActivityVolunteerDepartmentOpinion"].ToString())) ? false : true;
                break;
            case "ActivityRequirements":
                ViewState["ActivityRequirements"] = fckEditor.Value;
                imgActivityRequirments.Visible = (string.IsNullOrEmpty(ViewState["ActivityRequirements"].ToString())) ? false : true;
                break;
            default :
                throw new Exception("Not Supported FCK Editor Field");
        }
    }
    protected void lnkActivityVolunteerDepartmentOpinion_Click(object sender, EventArgs e)
    {
        ViewState["fckEditorField"] = "ActivityVolunteerDepartmentOpinion";
        fckEditor.Value = (ViewState["ActivityVolunteerDepartmentOpinion"] != null) ? ViewState["ActivityVolunteerDepartmentOpinion"].ToString() : string.Empty;
        mpeFckEditor.Show();
    }
    protected void lnkActivityRequirments_Click(object sender, EventArgs e)
    {
        ViewState["fckEditorField"] = "ActivityRequirements";
        fckEditor.Value = (ViewState["ActivityRequirements"] != null) ? ViewState["ActivityRequirements"].ToString() : string.Empty;
        mpeFckEditor.Show();
    }
}
