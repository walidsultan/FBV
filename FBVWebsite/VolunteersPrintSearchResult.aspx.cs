using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FBV.DataAccessLayer;
using FBV.DataMapping;
using System.Data;
public partial class VolunteerPrintSearchResult :PageThatRequiresLogin 
{
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();
    EduFacultiesManager _AssociatedFacultiesManager = new EduFacultiesManager();
    JobPlacesManager _AssociatedJobPlacesManager = new JobPlacesManager();
    FacUniversitiesManager _AssociatedUniversitiesmanager = new FacUniversitiesManager();
    AreasManager _AssociatedAreasManager = new AreasManager();
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    PlacesManager _AssociatedPlacesManger = new PlacesManager();

    int _VolunteerSerial = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadSearchResult(0);
    }
    private void LoadSearchResult(int PageIndex)
    {
        VolunteerSearchRecord searchRecord = (VolunteerSearchRecord)Session["VolunteerSearchRecord"];

        DataSet searchResultDataSet = _AssociatedVolunteersManager.Search(searchRecord, PageIndex,Int16 .MaxValue );

        //get search result data table
        DataTable searchResultTable = searchResultDataSet.Tables[1];
        int allRowsCount = int.Parse(searchResultDataSet.Tables[0].Rows[0]["AllRowsCount"].ToString());

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
            Label lblBirthDate = (Label)e.Row.FindControl("lblBirthDate");
            Label lblUniversity = (Label)e.Row.FindControl("lblUniversity");
            Label lblSerial = (Label)e.Row.FindControl("lblSerial");
            Label lblArea = (Label)e.Row.FindControl("lblArea");
            Label lblCity = (Label)e.Row.FindControl("lblCity");
            Label lblMeetingDate = (Label)e.Row.FindControl("lblMeetingDate");
            Label lblFirstContactPlace = (Label)e.Row.FindControl("lblFirstContactPlace");

            ImageButton imgBtnDeleteVolunteer = (ImageButton)e.Row.FindControl("imgBtnDeleteVolunteer");

            if (lblBirthDate.Text != string.Empty)
            {
                lblBirthDate.Text = DateTime.Parse(lblBirthDate.Text).ToShortDateString();
            }
            if (lblUniversity.Text != string.Empty)
            {
                lblUniversity.Text = _AssociatedUniversitiesmanager.GetFacUniversityByUniversityId(_AssociatedFacultiesManager.GetFacultyById(int.Parse(lblUniversity.Text)).FUniversityID).UniversityName;
            }
            if (lblArea.Text != string.Empty)
            {
                Area areaInstance = _AssociatedAreasManager.GetAreaByAreaId(int.Parse(lblArea.Text));
                lblArea.Text = areaInstance.AreaName;
                lblCity.Text = _AssociatedCitiesManager.GetCityByCityId(areaInstance.CityID).CityName;
            }
            if (lblMeetingDate.Text != string.Empty)
            {
                lblMeetingDate.Text = DateTime.Parse(lblMeetingDate.Text).ToShortDateString();
            }
            if (lblFirstContactPlace.Text != string.Empty)
            {
                lblFirstContactPlace.Text = _AssociatedPlacesManger.GetPlaceByPlaceId(int.Parse(lblFirstContactPlace.Text)).PlaceName;
            }

            //add pageindex offset to activity serial 
            lblSerial.Text = _VolunteerSerial .ToString();

            _VolunteerSerial++;
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
}
