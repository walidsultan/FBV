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
using System.Drawing;
using System.IO;
public partial class ActivitiesSearchResultDetails : PageThatRequiresLogin
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
            lblTitle.Text = "قاعدة بيانات الأنشطة – صفحة تفاصيل النشاط";
            if (Session["DetailsActivityId"] != null)
            {
                BindActivityData(int.Parse(Session["DetailsActivityId"].ToString()));
            }
            
        }
    
        
     }

    #region Activity Binding Methods
    private void BindActivityData(int ActivityId)
    {
        Activity activityInstance = _AssociatedActivitiesManager.GetActivitiesByActivityID(ActivityId);

        #region Bind activity text boxes
        if (activityInstance.ActivityCodeNo != null)
            lblActivityCodeNo.Text = activityInstance.ActivityCodeNo.Value.ToString();

        if (activityInstance.ActivityCost != null)
            lblActivityCost.Text = activityInstance.ActivityCost.Value.ToString();

        lblActivityDateFrom.Text = activityInstance.ActivityDateFrom.ToShortDateString();
        lblActivityDateTo.Text = activityInstance.ActivityDateTo.ToShortDateString();
        lblActivityDetails.Text = activityInstance.ActivityDetails;

        if (!string.IsNullOrEmpty(activityInstance.ActivityDocument))
        {
            hlnkActivityDocument.NavigateUrl = activityInstance.ActivityDocument;
            hlnkActivityDocument.Text = Path.GetFileName(activityInstance.ActivityDocument);
            hlnkActivityDocument.Visible = true;
        }

        lblActivityName.Text = activityInstance.ActivityName;

        if (activityInstance.ActivityRequestDate.HasValue)
            lblActivityRequestDate.Text = activityInstance.ActivityRequestDate.Value.ToShortDateString();

        if (!string.IsNullOrEmpty(activityInstance.ActivityDepartmentOpinion))
        {
             lblActivityRequirements.Text  = activityInstance.ActivityRequirments;
        }
       

        if (activityInstance.ActivityRevenue != null)
            lblActivityRevenue.Text = activityInstance.ActivityRevenue.Value.ToString();
        if (activityInstance.ActivityRequiredVolunteers.HasValue)
            lblActivityRequiredVolunteers.Text = activityInstance.ActivityRequiredVolunteers.Value.ToString();
        if (activityInstance.ActivityComments != null)
            lblActivityComments.Text = activityInstance.ActivityComments;
        if (!string.IsNullOrEmpty( activityInstance.ActivityDepartmentOpinion))
        {
            lblActivityDepartmentOpinion .Text  = activityInstance.ActivityDepartmentOpinion;
        }
        if (!string.IsNullOrEmpty(activityInstance.ActivityVolunteerDepartmentOpinion))
        {
            lblActivityVolunteerDepartmentOpinion.Text = activityInstance.ActivityVolunteerDepartmentOpinion;

        }
        #endregion

        #region Bind activity drop downs
        lblActivityField.Text = _AssociatedFieldsManager.GetFieldByFieldId( activityInstance.ActivityFieldID).FieldName ;
        lblActivityField.Attributes.Add("ActivityFieldId", activityInstance.ActivityFieldID.ToString());
        //bind the places for the selected city
        if (activityInstance.ActivityPlaceID.HasValue)
        lblActivityPlace.Text = _AssociatedPlacesManager.GetPlaceByPlaceId(activityInstance.ActivityPlaceID.Value ).PlaceName ;
        #endregion

        #region Bind activity missions check list

        DataTable activityMissions = _AssociatedActivitiesManager.GetActivityMissionsByActivityId(ActivityId);
        foreach (DataRow dr in activityMissions.Rows)
        {
            string missionName=_AssociatedMissionsManager.GetMissionByMissionId(int.Parse(dr["MissionId"].ToString())).MissionName ;
            lblVolunteerMissions.Text += (lblVolunteerMissions.Text ==string.Empty)?missionName : ", "+missionName   ;
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

        lblVolunteerDepartmentResponsibleUser.Text = _AssociatedUsersManager.GetUserByUserId( activityInstance.ActivityEvaluatorID).UserFullname ;
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
    protected void grdActivityDays_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVolunteerWorkingStart = (Label)e.Row.FindControl("lblVolunteerWorkingStart");
            Label lblVolunteerWorkingEnd = (Label)e.Row.FindControl("lblVolunteerWorkingEnd");
            Label lblVolunteerId = (Label)e.Row.FindControl("lblVolunteerId");
            Label lblVolunteerMobile = (Label)e.Row.FindControl("lblVolunteerMobile");
            Label lblActivtyDaySerial = (Label)e.Row.FindControl("lblActivtyDaySerial");

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
                lnkActivityDepartmentEvaluation.Visible =false ;
            }

            if (lnkVolunteerDepartmentEvaluation.Text != string.Empty)
            {
                lnkVolunteerDepartmentEvaluation.Text = Enum.GetName(typeof(EvaluationLevel), int.Parse(lnkVolunteerDepartmentEvaluation.Text));
                lnkVolunteerDepartmentEvaluation.ForeColor = Color.Green;
            }
            else
            {
                lnkVolunteerDepartmentEvaluation.Visible = false;
            }


            Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(lblVolunteerId.Text));
            lblVolunteerId.Text = volunteerInstance.VolunteerManID.ToString();

            lblActivtyEvaluationSerial.Text = (grdActivityEvaluation.Rows.Count + 1).ToString();
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

    protected void lnkVolunteer_Command(object sender, CommandEventArgs e)
    {
        int VolunteerId = int.Parse(e.CommandArgument.ToString());
        Session["VolunteerProfileId"] = VolunteerId;
        Response.Redirect("VolunteerProfile.aspx");
    }

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

        string activityField = lblActivityField.Attributes["ActivityFieldId"];

        if (lblActivityCost.Text != string.Empty)
            activityCost = int.Parse(lblActivityCost.Text);

        if (lblActivityRevenue.Text != string.Empty)
            activtyRevenue = int.Parse(lblActivityRevenue.Text);

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


}
