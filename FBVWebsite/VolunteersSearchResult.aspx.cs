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
public partial class VolunteerSearchResult : PageThatRequiresLogin
{
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();
    EduFacultiesManager _AssociatedFacultiesManager = new EduFacultiesManager();
    JobPlacesManager _AssociatedJobPlacesManager = new JobPlacesManager();
    FacUniversitiesManager _AssociatedUniversitiesmanager = new FacUniversitiesManager();
    AreasManager _AssociatedAreasManager = new AreasManager();
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    PlacesManager _AssociatedPlacesManger = new PlacesManager();
    EducationManager _AssociatedEducationManager = new EducationManager();
    MarketingManager _AssociatedMarketingManager = new MarketingManager();
    SchoolsManager _AssociatedSchoolsManager = new SchoolsManager();
    ActivitiesManager _AssociatedActivityManager = new ActivitiesManager();
    FieldsManager _AssociatedFieldsManager=new FieldsManager();
    int _VolunteerSerial = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PageIndex"] = 0;
            LoadSearchResult(0);

            //update the title of the page in case of updating the volunteer
            if (Request.QueryString["Update"] != null)
            {
                if (Request.QueryString["Update"].ToString() == "true")
                {
                    lblResult.Text = "تم تعديل بيانات المتطوع";
                }
            }
        }
    }

    private void LoadSearchResult(int PageIndex)
    {
        VolunteerSearchRecord searchRecord = (VolunteerSearchRecord)Session["VolunteerSearchRecord"];

        GenerateSearchFilterLabel(searchRecord);

        DataSet searchResultDataSet = _AssociatedVolunteersManager.Search(searchRecord, PageIndex, mgrdSearchResult.PageSize);

        //get search result data table
        DataTable searchResultTable = searchResultDataSet.Tables[1];
        int allRowsCount = int.Parse(searchResultDataSet.Tables[0].Rows[0]["AllRowsCount"].ToString());
        lblVolunteersCount.Text = "عدد المتطوعين " + "<a style =\"color:Red\">" + allRowsCount.ToString() + "</a> ";

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
            imgPrint.Visible = false;
            lblResult.Text = "لا يوجد نتائج  للبحث";
        }


    }

    private void GenerateSearchFilterLabel(VolunteerSearchRecord SearchRecord)
    {
        string searchFilter = string.Empty;

        if (SearchRecord.vAreaID.HasValue)
        {
            searchFilter += "المنطقة = " + "<a style =\"color:Red\">" + _AssociatedAreasManager.GetAreaByAreaId(SearchRecord.vAreaID.Value).AreaName + "</a> ";
        }

        if (SearchRecord.vBirthDateFrom.HasValue)
        {
            searchFilter += "بداية تاريخ الميلاد = " + "<a style =\"color:Red\">" + SearchRecord.vBirthDateFrom.Value.ToShortDateString() + "</a> ";
        }

        if (SearchRecord.vBirthDateTo.HasValue)
        {
            searchFilter += "نهاية تاريخ الميلاد = " + "<a style =\"color:Red\">" + SearchRecord.vBirthDateTo.Value.ToShortDateString() + "</a> ";
        }

        if (SearchRecord.vCityID.HasValue)
        {
            searchFilter += "المدينة = " + "<a style =\"color:Red\">" + _AssociatedCitiesManager.GetCityByCityId(SearchRecord.vCityID.Value).CityName + "</a> ";
        }

        if (SearchRecord.vDesiredFields != null)
        {
            //code to extract desired fields from the xml value
        }

        if (SearchRecord.vEducationID.HasValue)
        {
            searchFilter += "المؤهل = " + "<a style =\"color:Red\">" + _AssociatedEducationManager.GetEducationByEducationId(SearchRecord.vEducationID.Value).EducationName + "</a> ";
        }

        if (SearchRecord.VFacultyID.HasValue)
        {
            searchFilter += "الكلية = " + "<a style =\"color:Red\">" + _AssociatedFacultiesManager.GetFacultyById(SearchRecord.VFacultyID.Value).FacultyName + "</a> ";
        }

        if (SearchRecord.vFirstContactDate.HasValue)
        {
            searchFilter += "تاريخ اول إتصال للمتطوع بالبنك = " + "<a style =\"color:Red\">" + SearchRecord.vFirstContactDate.Value.ToShortDateString() + "</a> ";
        }

        if (SearchRecord.vFirstContactPlaceID.HasValue)
        {
            searchFilter += "مكان اول إتصال للمتطوع بالبنك = " + "<a style =\"color:Red\">" + _AssociatedPlacesManger.GetPlaceByPlaceId(SearchRecord.vFirstContactPlaceID.Value).PlaceName + "</a> ";
        }

        if (SearchRecord.vJobPlaceID.HasValue)
        {
            searchFilter += "المؤسسة = " + "<a style =\"color:Red\">" + _AssociatedJobPlacesManager.GetJobPlaceByJobPlaceId(SearchRecord.vJobPlaceID.Value).JobPlaceName + "</a> ";
        }

        if (SearchRecord.vKnow.HasValue)
        {
            searchFilter += "كيف علمت عن بنك الطعام = " + "<a style =\"color:Red\">" + _AssociatedMarketingManager.GetMarketingByMarketId(SearchRecord.vKnow.Value).MarketName + "</a> ";
        }

        if (SearchRecord.vMeetingDate.HasValue)
        {
            searchFilter += "تاريخ لقاء تعارف" + "<a style =\"color:Red\">" + SearchRecord.vMeetingDate.Value.ToShortDateString() + "</a> ";
        }

        if (SearchRecord.vMeetingPlaceID.HasValue)
        {
            searchFilter += "مكان لقاء تعارف" + "<a style =\"color:Red\">" + _AssociatedPlacesManger.GetPlaceByPlaceId(SearchRecord.vMeetingPlaceID.Value).PlaceName + "</a> ";
        }

        if (SearchRecord.vName != null)
        {
            searchFilter += "الإسم = " + "<a style =\"color:Red\">" + SearchRecord.vName + "</a> ";
        }

        if (SearchRecord.VolunteerManIdStart.HasValue)
        {
            searchFilter += "بداية رقم التعريف = " + "<a style =\"color:Red\">" + SearchRecord.VolunteerManIdStart.Value.ToString() + "</a> ";
        }

        if (SearchRecord.VolunteerManIdEnd.HasValue)
        {
            searchFilter += "نهاية رقم التعريف = " + "<a style =\"color:Red\">" + SearchRecord.VolunteerManIdEnd.Value.ToString() + "</a> ";
        }

        if (SearchRecord.vRegisterDate.HasValue)
        {
            searchFilter += "تاريخ إستيفاء الإستمارة" + "<a style =\"color:Red\">" + SearchRecord.vRegisterDate.Value.ToShortDateString() + "</a> ";
        }

        if (SearchRecord.vRegistrationPlaceID.HasValue)
        {
            searchFilter += "مكان إستيفاء الإستمارة" + "<a style =\"color:Red\">" + _AssociatedPlacesManger.GetPlaceByPlaceId(SearchRecord.vRegistrationPlaceID.Value).PlaceName + "</a> ";
        }

        if (SearchRecord.VUniversityID.HasValue)
        {
            searchFilter += "الجامعة " + "<a style =\"color:Red\">" + _AssociatedUniversitiesmanager.GetFacUniversityByUniversityId(SearchRecord.VUniversityID.Value).UniversityName + "</a> ";
        }

        if (!string.IsNullOrEmpty(searchFilter))
        {
            lblSearchFilter.Text = "معيار البحث : " + searchFilter;
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
            Label lblSchool = (Label)e.Row.FindControl("lblSchool");
            Label lblJobPlace = (Label)e.Row.FindControl("lblJobPlace");
            Label lblFirstContactDate=(Label)e.Row.FindControl("lblFirstContactDate");
            Label lblRegisterDate = (Label)e.Row.FindControl("lblRegisterDate");
            Label lblFirstActivityDate = (Label)e.Row.FindControl("lblFirstActivityDate");
            Label lblFirstActivityType = (Label)e.Row.FindControl("lblFirstActivityType");
            Label lblApologyDate = (Label)e.Row.FindControl("lblApologyDate");
            Label lblMeetingStatus = (Label)e.Row.FindControl("lblMeetingStatus");
            
            ImageButton imgBtnDeleteVolunteer = (ImageButton)e.Row.FindControl("imgBtnDeleteVolunteer");

            if (lblBirthDate.Text != string.Empty)
            {
                lblBirthDate.Text = string.Format("{0:d/M </br> yyyy}", DateTime.Parse(lblBirthDate.Text));
            }
            if (lblUniversity.Text != string.Empty)
            {
                lblUniversity.Text = _AssociatedUniversitiesmanager.GetFacUniversityByUniversityId(_AssociatedFacultiesManager.GetFacultyById(int.Parse(lblUniversity.Text)).FUniversityID).UniversityName;
                lblSchool.Visible = false;
            }
            if (lblArea.Text != string.Empty)
            {
                Area areaInstance = _AssociatedAreasManager.GetAreaByAreaId(int.Parse(lblArea.Text));
                lblArea.Text = areaInstance.AreaName;
                lblCity.Text = _AssociatedCitiesManager.GetCityByCityId(areaInstance.CityID).CityName;
            }
            if (lblMeetingDate.Text != string.Empty)
            {
                lblMeetingDate.Text = string.Format("{0:d/M </br> yyyy}", DateTime.Parse(lblMeetingDate.Text));
            }
            if (lblApologyDate.Text != string.Empty)
            {
                lblApologyDate.Text = string.Format("{0:d/M </br> yyyy}", DateTime.Parse(lblApologyDate.Text));
                //hide the original meeting date
                lblMeetingDate.Text = string.Empty;
            }
            if (lblFirstContactPlace.Text != string.Empty)
            {
                lblFirstContactPlace.Text = _AssociatedPlacesManger.GetPlaceByPlaceId(int.Parse(lblFirstContactPlace.Text)).PlaceName;
            }
            if (lblUniversity.Text == string.Empty && lblSchool.Text != string.Empty)
            {
                lblSchool.Text = _AssociatedSchoolsManager.GetSchoolBySchoolID(int.Parse(lblSchool.Text)).SchoolName;
            }
            if ( lblJobPlace.Text != string.Empty)
            {
                lblJobPlace.Text = _AssociatedJobPlacesManager.GetJobPlaceByJobPlaceId(int.Parse(lblJobPlace.Text)).JobPlaceName;
            }
            if (lblFirstContactDate.Text != string.Empty)
            {
                lblFirstContactDate.Text = string.Format("{0:d/M </br> yyyy}", DateTime.Parse(lblFirstContactDate.Text));
            }
            if (lblRegisterDate.Text != string.Empty)
            {
                lblRegisterDate.Text = string.Format("{0:d/M </br> yyyy}",  DateTime.Parse(lblRegisterDate.Text));
            }
            if (lblMeetingStatus.Text != string.Empty)
            {
                lblMeetingStatus.Text = (lblMeetingStatus.Text.ToLower() == "true") ? "تم الحضور" : "لم يحضر"; 
            }

            int volunteerId=int.Parse( lblFirstActivityType.Text );

            Activity volunteerFirstActivity = _AssociatedActivityManager.GetFirstActivityByVolunteerId(volunteerId);
            if (volunteerFirstActivity != null)
            {
                lblFirstActivityDate.Text = string.Format("{0:d/M </br> yyyy}", volunteerFirstActivity.ActivityDateFrom);
                lblFirstActivityType.Text = _AssociatedFieldsManager.GetFieldByFieldId(volunteerFirstActivity.ActivityFieldID).FieldName;
            }
            else
            {
                lblFirstActivityType.Visible = false;
            }
            

            //add pageindex offset to activity serial 
            lblSerial.Text = (_VolunteerSerial + int.Parse(ViewState["PageIndex"].ToString()) * mgrdSearchResult.PageSize).ToString();

            imgBtnDeleteVolunteer.Attributes.Add("onclick", "javascript:return " +
              "confirm('هل انت متأكد من مسح هذا المتطوع؟')");

            _VolunteerSerial++;
        }
    }
    protected void mgrdSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int currentPageIndex = e.NewPageIndex;
        ViewState["PageIndex"] = currentPageIndex;
        mgrdSearchResult.MockPageIndex = currentPageIndex;
        LoadSearchResult(currentPageIndex);
    }

    protected void imgBtnEditVolunteer_Command(object sender, CommandEventArgs e)
    {
        int volunteerId = int.Parse(e.CommandArgument.ToString());
        Session["VolunteerId"] = volunteerId;
        Response.Redirect("AddVolunteer.aspx?Edit=true");
    }
    protected void imgBtnDeleteVolunteer_Command(object sender, CommandEventArgs e)
    {
        int volunteerId = int.Parse(e.CommandArgument.ToString());
        try
        {
            _AssociatedVolunteersManager.DeleteVolunteer(volunteerId);
            LoadSearchResult(int.Parse(ViewState["PageIndex"].ToString()));
        }
        catch (Exception ex)
        {
            throw ex;
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
    protected void imgPrint_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("VolunteersPrintSearchResult.aspx");
    }
    protected void lnkVolunteerName_Command(object sender, CommandEventArgs e)
    {
        Session["VolunteerProfileId"] = int.Parse(e.CommandArgument.ToString());
        Response.Redirect("VolunteerProfile.aspx");
    }
}
