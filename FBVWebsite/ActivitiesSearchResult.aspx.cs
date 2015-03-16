using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FBV.DataAccessLayer;
using FBV.DataMapping;

public partial class ActivitiesSearchResult :PageThatRequiresLogin 
{
    ActivitiesManager _AssociatedActivitiesManager = new ActivitiesManager();
    DepartmentsManager _AssociatedDepartmentsManager = new DepartmentsManager();
    FieldsManager _AssociatedFieldsManager = new FieldsManager();
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    PlacesManager _AssociatedPlacesManager = new PlacesManager();
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();
    MissionsManager _AssociatedMissionsManager = new MissionsManager();
    UsersManager _AssociatedUsersManager = new UsersManager();
    int _ActivitySerial = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PageIndex"] = 0;
            LoadSearchResult(0);

            //update the title of the page in case od updating the activity
            if (Request.QueryString["Update"] != null)
            {
                if (Request.QueryString["Update"].ToString() == "true")
                {
                    lblResult.Text = "تم تعديل النشاط";
                }
            }
        }
    }

    private void LoadSearchResult(int PageIndex)
    {
        ActivitySearchRecord searchRecord = (ActivitySearchRecord)Session["SearchRecord"];

        DataSet searchResultDataSet = _AssociatedActivitiesManager.Search(searchRecord, PageIndex , mgrdSearchResult.PageSize);

        //get search result data table
        DataTable searchResultTable = searchResultDataSet.Tables[1];
        int allRowsCount=int.Parse( searchResultDataSet.Tables[0].Rows[0]["AllRowsCount"].ToString());
        lblActivitiesCount.Text = "عدد الأنشطة " + "<a style =\"color:Red\">" + allRowsCount.ToString() + "</a> ";
        //set the correct pageindex count
        mgrdSearchResult.MockItemCount = allRowsCount;

        if (searchResultTable.Rows.Count > 0)
        {
            mgrdSearchResult.DataSource = searchResultTable;
            mgrdSearchResult.DataBind();
            lblResult.Text = string.Empty;
        }
        else
        {
            mgrdSearchResult.DataBind();
            lblResult.Text = "لا يوجد نتائج  للبحث";
        }

   
    }
    protected void mgrdSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
            Label lblActivityId = (Label)e.Row.FindControl("lblActivityId");
            Label lblActivityField = (Label)e.Row.FindControl("lblActivityField");
            Label lblActivityInterval = (Label)e.Row.FindControl("lblActivityInterval");
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            Label lblPlace = (Label)e.Row.FindControl("lblPlace");
            Label lblVolunteers = (Label)e.Row.FindControl("lblVolunteers");
            Label lblRequestDate = (Label)e.Row.FindControl("lblRequestDate");
            Label lblEntryUser = (Label)e.Row.FindControl("lblEntryUser");
            Label lblActivityStartDate = (Label)e.Row.FindControl("lblActivityStartDate");
            Label lblActivityEndDate = (Label)e.Row.FindControl("lblActivityEndDate");
            Label lblActivityPlace = (Label)e.Row.FindControl("lblActivityPlace");
            Label lblVolunteersCount = (Label)e.Row.FindControl("lblVolunteersCount");
            Label lblDaysCount = (Label)e.Row.FindControl("lblDaysCount");
            Label lblActivityHours = (Label)e.Row.FindControl("lblActivityHours");
            
            int activityId = int.Parse(lblActivityId.Text);

             lblVolunteersCount.Text = _AssociatedActivitiesManager.GetActivityVolunteersCount(activityId).ToString();
             lblDaysCount.Text = _AssociatedActivitiesManager.GetActivityDaysCount(activityId).ToString();
             lblActivityHours.Text = _AssociatedActivitiesManager.GetActivityHours(activityId).ToString();

            if (lblActivityPlace.Text != string.Empty)
                lblActivityPlace.Text = _AssociatedPlacesManager.GetPlaceByPlaceId(int.Parse(lblActivityPlace.Text)).PlaceName ;

            if (lblActivityStartDate.Text != string.Empty)
                lblActivityStartDate.Text = DateTime.Parse(lblActivityStartDate.Text).ToShortDateString();

            if (lblActivityEndDate.Text != string.Empty)
                lblActivityEndDate.Text = DateTime.Parse(lblActivityEndDate.Text).ToShortDateString();

            ImageButton imgBtnDeleteActivity = (ImageButton)e.Row.FindControl("imgBtnDeleteActivity");

     
            Activity activityInstance = _AssociatedActivitiesManager.GetActivitiesByActivityID(activityId);

            //get activity departments
            DataTable activityDepartments = _AssociatedActivitiesManager.GetActivityDepartmentsByActivityId(activityId);
            foreach (DataRow dr in activityDepartments.Rows)
            {
                Department departmentInstance = _AssociatedDepartmentsManager.GetDepartmentById(int.Parse(dr["DepartmentID"].ToString()));
                if (lblDepartment.Text == string.Empty)
                {
                    lblDepartment.Text = departmentInstance.DepartmentName;
                }
                else
                {
                    lblDepartment.Text += "," + departmentInstance.DepartmentName;
                }
            }
                                                                                                                                                                                                                                                         
            lblActivityField.Text = _AssociatedFieldsManager.GetFieldByFieldId(activityInstance.ActivityFieldID).FieldName;

            //TimeSpan activityIntervalSpan = activityInstance.ActivityDateTo.Subtract(activityInstance.ActivityDateFrom);
            //lblActivityInterval.Text = activityIntervalSpan.Days.ToString() + " يوم";
            //if (activityInstance.ActivityPlaceID.HasValue)
            //{
            //    Place placeInstance = _AssociatedPlacesManager.GetPlaceByPlaceId(activityInstance.ActivityPlaceID.Value);
            //    City cityInstance = _AssociatedCitiesManager.GetCityByCityId(placeInstance.CityID);

            //    lblPlace.Text = cityInstance.CityName + " - " + placeInstance.PlaceName;
            //}

            //DataTable activityResult = _AssociatedActivitiesManager.GetActivityResultGroupedByVolunteerId (activityId);
            //foreach (DataRow dr in activityResult.Rows)
            //{
            //    Volunteer volunteerInstance = _AssociatedVolunteersManager.GetVolunteerByVolunteerId(int.Parse(dr["RVolunteerID"].ToString()));
            //    if (lblVolunteers.Text == string.Empty)
            //    {
            //        lblVolunteers.Text = "(" + volunteerInstance.vName + ")";
            //    }
            //    else
            //    {
            //        lblVolunteers.Text += ", (" + volunteerInstance.vName + ")";
            //    }
            //}

            if(lblRequestDate.Text !=string.Empty)
            lblRequestDate.Text = DateTime.Parse(lblRequestDate.Text).ToShortDateString();

            //lblEntryUser.Text = _AssociatedUsersManager.GetUserByUserId(int.Parse(lblEntryUser.Text)).UserFullname  ;

            //add pageindex offset to activity serial 
            lblSerial.Text = (_ActivitySerial+ int.Parse(ViewState["PageIndex"].ToString()) * mgrdSearchResult.PageSize  ).ToString();

            imgBtnDeleteActivity.Attributes.Add("onclick", "javascript:return " +
               "confirm('هل انت متأكد من مسح هذا النشاط؟')");

            _ActivitySerial++;
        }
    }
    
    protected void imgBtnEditActivity_Command(object sender, CommandEventArgs e)
    {
        int activityId = int.Parse(e.CommandArgument.ToString());
        Session["ActivityId"] = activityId;
        Response.Redirect("AddActivity.aspx?Edit=true");
    }


    protected void imgBtnActivityDelete_Command(object sender, CommandEventArgs e)
    {
        int activityId = int.Parse(e.CommandArgument.ToString());
        try
        {
            _AssociatedActivitiesManager.DeleteActivity(activityId);
            LoadSearchResult(int.Parse( ViewState["PageIndex"].ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public override bool CheckPermission()
    {
        if (CurrentUser.UAccessLevel ==(int) UserAccessLevel.Administrator)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void mgrdSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int currentPageIndex = e.NewPageIndex;
        ViewState["PageIndex"] = currentPageIndex;
        mgrdSearchResult.MockPageIndex = currentPageIndex;
        LoadSearchResult(currentPageIndex);
    }

    protected void lnkActivityCodeNo_Command(object sender, CommandEventArgs e)
    {
        int activityId = int.Parse(e.CommandArgument.ToString());
        Session["DetailsActivityId"] = activityId;
        Response.Redirect("ActivitiesSearchResultDetails.aspx");
    }
}
