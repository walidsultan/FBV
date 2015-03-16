using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using FBV.DataAccessLayer;
using FBV.DataMapping;
public partial class ProcessExcelSheet : PageThatRequiresLogin
{
    ActivitiesExcelSheetManager _ExcelSheetManager = new ActivitiesExcelSheetManager();
    EduFacultiesManager _AssociatedfacultiesManager = new EduFacultiesManager();
    VolunteersManager _AssociatedVolunteersManager = new VolunteersManager();
    FacUniversitiesManager _AssociatedUniversitiesManager = new FacUniversitiesManager();
    EducationManager _AssociatedEducationManager = new EducationManager();
    FieldsManager _AssociatedFieldsManager = new FieldsManager();
    JobPlacesManager _AssociatedJobPlacesManager = new JobPlacesManager();
    AreasManager _AssociatedAreasManager = new AreasManager();
    CitiesManager _AssociatedCitiesManager = new CitiesManager();
    PlacesManager _AssociatedPlacesManager = new PlacesManager();
    MarketingManager _AssociatedMarketingManager = new MarketingManager();
    SchoolsManager _AssociatedSchoolsManager = new SchoolsManager();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnUpload.OnClientClick = "$.blockUI({ message: '<h2>جارى معالجة ملف الإكسل</h2>'  ,  css: {border: 'none',padding: '15px',backgroundColor: '#000',opacity: '.5',color: '#fff','-webkit-border-radius': '10px','-moz-border-radius': '10px', filter: 'alpha(opacity=70)' }  });";
    }
    /// <summary>
    /// Processes the excel records.
    /// </summary>
    /// <param name="AllExcelRecords">All excel records.</param>
    private void ProcessExcelRecords(List<ExcelRecord> AllExcelRecords)
    {
        //Initiate a transaction that will be used with all excel volunteers
        SqlTransaction transactionInstance = _AssociatedVolunteersManager.BeginTransaction();
        string errorLog = string.Empty;

        int rowCount = 2;
        try
        {

            foreach (ExcelRecord record in AllExcelRecords)
            {
                Volunteer volunteerInstance = new Volunteer();

                if (record.Address == null)
                    volunteerInstance.VAddress = null;
                else
                    volunteerInstance.VAddress = record.Address;

                string birthDay = string.Empty, birthMonth = "1/", birthYear = string.Empty;
                if (record.BirthDay.HasValue) birthDay = record.BirthDay.Value.ToString() + "/";
                if (record.BirthMonth.HasValue) birthMonth = record.BirthMonth.Value.ToString() + "/";
                if (record.BirthYear.HasValue) birthYear = record.BirthYear.Value.ToString();
                if (record.BirthYear == null)
                    volunteerInstance.vBirthDate = null;
                else
                    volunteerInstance.vBirthDate = DateTime.Parse(birthDay + birthMonth + birthYear);

                if (record.CurrentJob == null)
                    volunteerInstance.VCurrentJob = null;
                else
                    volunteerInstance.VCurrentJob = record.CurrentJob;

                if (record.Email == null)
                    volunteerInstance.vEmail = null;
                else
                    volunteerInstance.vEmail = record.Email;

                if (record.Mobile == null)
                    volunteerInstance.vMobile = null;
                else
                    volunteerInstance.vMobile = record.Mobile;

                if (record.Experience == null)
                    volunteerInstance.vXexperience = null;
                else
                    volunteerInstance.vXexperience = record.Experience;

                if (record.Comments == null)
                    volunteerInstance.vComments = null;
                else
                    volunteerInstance.vComments = record.Comments;

                volunteerInstance.vName = record.Name;
                volunteerInstance.VGender = record.Gender;
                volunteerInstance.VolunteerManID = record.VolunteerManID;

                if (record.RegisterDate == null)
                    volunteerInstance.vRegisterDate = null;
                else
                    volunteerInstance.vRegisterDate = DateTime.Parse(record.RegisterDate.ToString());

                if (record.KnowWay == null)
                    volunteerInstance.vKnowWay = null;
                else
                    volunteerInstance.vKnowWay = record.KnowWay;

                if (record.FirstContactDate == null)
                    volunteerInstance.vFirstContactDate = null;
                else
                    volunteerInstance.vFirstContactDate = DateTime.Parse(record.FirstContactDate.ToString());

                if (record.MeetingDate == null)
                    volunteerInstance.vMeetingDate = null;
                else
                    volunteerInstance.vMeetingDate = DateTime.Parse(record.MeetingDate.ToString());

                volunteerInstance.vTelephone = record.Telephone;

                //get school by school name from excel sheet
                if (record.School != null)
                {
                    School schoolInstance = _AssociatedSchoolsManager.GetSchoolBySchoolName(record.School,transactionInstance );
                    int? schoolId = (schoolInstance == null) ? (int?)null : schoolInstance.SchoolId ;
                    if (schoolInstance == null)
                    {
                        schoolInstance = new School();
                        schoolInstance.SchoolName = record.School;
                        schoolId = _AssociatedSchoolsManager.InsertSchool(schoolInstance,transactionInstance );
                    }
                    volunteerInstance.VSchool = schoolId;
                }


                //get University by UniversityName from the excel sheet
                if (record.University != null)
                {
                    FacUniversity universityInstance = _AssociatedUniversitiesManager.GetFacUniversityByUniversityName(record.University,transactionInstance );
                    int? universityId = (universityInstance == null) ? (int?)null : universityInstance.UniversityID ;
                    if (universityInstance == null)
                    {
                        universityInstance = new FacUniversity();
                        universityInstance.UniversityName = record.University;
                        universityId = _AssociatedUniversitiesManager.InsertFacUniversity(universityInstance,transactionInstance );
                    }

                    if (string.IsNullOrEmpty( record.Education)) record.Education = "أخرى";

                    EduFaculty facultyInstance = _AssociatedfacultiesManager.GetFacultyByFacultyNameAndUniversityId(record.Education, universityId.Value,transactionInstance  );
                    int? facultyId = (facultyInstance == null) ? (int?)null : facultyInstance. FacultyID ;
                    if (facultyInstance == null)
                    {
                        facultyInstance = new EduFaculty();
                        facultyInstance.FacultyName = record.Education;
                        facultyInstance.FUniversityID = universityId.Value;
                       facultyId= _AssociatedfacultiesManager.InsertFaculty(facultyInstance,transactionInstance );
                    }
                    volunteerInstance.VFacultyID = facultyId.Value ;
                }


                //get jobPlace from the the database
                if (record.JobPlace != null)
                {
                    JobPlace jobPlaceInstance = _AssociatedJobPlacesManager.GetJobPlaceByJobPlaceName(record.JobPlace);
                    if (jobPlaceInstance == null)
                    {
                        if (!errorLog.Contains(record.JobPlace))
                            errorLog += ", JobPlace " + record.JobPlace + "</br>";
                        goto ContinueJobPlace;
                        // throw new Exception("المؤسسة \"" + record.JobPlace + "\" غير موجود فى قاعدة البيانات.");
                    }
                    volunteerInstance.vJobPlaceID = jobPlaceInstance.JobPlaceID;
                }
            ContinueJobPlace:

                //Get City By City Name from the database
                if (record.City != null)
                {
                    City cityInstance = _AssociatedCitiesManager.GetCityByCityName(record.City,transactionInstance );
                    int? cityId=(cityInstance ==null)? (int?)null : cityInstance.CityID   ; 
                    if (cityInstance == null)
                    {
                        cityInstance = new City();
                        cityInstance.CityName = record.City;
                       cityId= _AssociatedCitiesManager.InsertCity(cityInstance,transactionInstance );
                    }

                    if (string.IsNullOrEmpty(record.Area)) record.Area = "أخرى";

                    Area areaInstance = _AssociatedAreasManager.GetAreaByAreaNameAndCityId(record.Area, cityId.Value ,transactionInstance );
                    int? areaId = (areaInstance == null) ? (int?)null : areaInstance.AreaID ;
                    if (areaInstance == null)
                    {
                        areaInstance = new Area();
                        areaInstance.AreaName = record.Area;
                        areaInstance.CityID = cityId.Value ;
                        areaId=_AssociatedAreasManager.InsertArea(areaInstance, transactionInstance);
                    }
                    volunteerInstance.vAreaID = areaId.Value ;
                }

                //Get registeration place from database
                if (record.RegistrationPlace != null)
                {
                    Place registerationPlaceInstance = _AssociatedPlacesManager.GetPlaceByPlaceName(record.RegistrationPlace);
                    if (registerationPlaceInstance == null)
                    {
                        if (!errorLog.Contains(record.RegistrationPlace))
                            errorLog += ", RegisterPlace " + record.RegistrationPlace + "</br>";
                        goto ContinueRegisterationPlace;
                        //throw new Exception("مكان التسجيل \"" + record.RegistrationPlace + "\" غير موجود فى قاعدة البيانات.");
                    }
                    volunteerInstance.vRegistrationPlaceID = registerationPlaceInstance.PlaceID;
                }
            ContinueRegisterationPlace:

                //get Meeting Place from database
                if (record.MeetingPlace != null)
                {
                    Place meetinPlaceInstance = _AssociatedPlacesManager.GetPlaceByPlaceName(record.MeetingPlace);
                    if (meetinPlaceInstance == null)
                    {
                        if (!errorLog.Contains(record.MeetingPlace))
                            errorLog += ", MeetingPlace " + record.MeetingPlace + "</br>";
                        goto ContinueMeetingPlace;
                        // throw new Exception("مكان لقاء التعريف \"" + record.MeetingPlace + "\" غير موجود فى قاعدة البيانات.");
                    }
                    volunteerInstance.vMeetingPlaceID = meetinPlaceInstance.PlaceID;
                }
            ContinueMeetingPlace:

                //get first contact Place from database
                if (record.FirstContactPlace != null)
                {
                    Place firstContactPlaceInstance = _AssociatedPlacesManager.GetPlaceByPlaceName(record.FirstContactPlace);
                    if (firstContactPlaceInstance == null)
                    {
                        if (!errorLog.Contains(record.FirstContactPlace))
                            errorLog += ", firstContactPlace " + record.FirstContactPlace + "</br>";
                        goto ContinueFirstContactPlace;
                        // throw new Exception("مكان لقاء التعريف \"" + record.MeetingPlace + "\" غير موجود فى قاعدة البيانات.");
                    }
                    volunteerInstance.vFirstContactPlaceID = firstContactPlaceInstance.PlaceID;
                }
            ContinueFirstContactPlace:

                if (record.Know != null)
                {
                    Marketing marketingInstance = _AssociatedMarketingManager.GetMarketingByMarketName(record.Know);
                    if (marketingInstance == null)
                    {
                        if (!errorLog.Contains(record.Know))
                            errorLog += ", marketing " + record.Know + "</br>";
                        goto ContinueMarketing;
                        //throw new Exception("مكان كيف علمت عن بنك الطعام \"" + record.Know + "\" غير موجود فى قاعدة البيانات.");
                    }
                    volunteerInstance.vKnow = marketingInstance.MarketingID;
                }
            ContinueMarketing:


                //if the volunteer already exist in the database then update his data
                int volunteerId = 0;
                Volunteer existingVolunteer = _AssociatedVolunteersManager.GetVolunteerByManIdAndName(volunteerInstance.VolunteerManID, volunteerInstance.vName, transactionInstance);
                if (existingVolunteer == null)
                {
                    volunteerId = _AssociatedVolunteersManager.InsertVolunteer(volunteerInstance, transactionInstance);
                }
                else
                {
                    volunteerInstance.VolunteerID = existingVolunteer.VolunteerID;
                    volunteerId = volunteerInstance.VolunteerID;
                    _AssociatedVolunteersManager.UpdateVolunteer(volunteerInstance, transactionInstance);
                }

                //insert first field activity work 
                //get activity field from database
                if (record.FirstFieldWork != null)
                {
                    Field activityFieldinstance = _AssociatedFieldsManager.GetFieldByFieldName(record.FirstFieldWork, transactionInstance);
                    if (activityFieldinstance == null)
                    {
                        if (!errorLog.Contains(record.FirstFieldWork))
                            errorLog += ", FieldWork " + record.FirstFieldWork + "</br>";
                        goto ContinueFirstField;
                        //throw new Exception("مجال النشاط \"" + record.FieldWork + "\" غير موجود فى قاعدة البيانات.");
                    }

                    //make sure the (VolunteerId,FieldId) pair doesn't exist in the database
                    FieldVolunteerWork existingFieldVolunteer = _AssociatedFieldsManager.GetFieldVolunteerWorkByVolunteerIdAndFieldId(volunteerId, activityFieldinstance.FieldID, transactionInstance);
                    if (existingFieldVolunteer == null)
                    {
                        _AssociatedFieldsManager.InsertFieldVolunteerWork(activityFieldinstance.FieldID, volunteerId, transactionInstance);
                    }
                }
            ContinueFirstField:


                //insert field activity work 
                //get activity field from database
                if (record.FieldWork != null)
                {
                    Field activityFieldinstance = _AssociatedFieldsManager.GetFieldByFieldName(record.FieldWork, transactionInstance);
                    if (activityFieldinstance == null)
                    {
                        if (!errorLog.Contains(record.FieldWork))
                            errorLog += ", FieldWork " + record.FieldWork + "</br>";
                        goto ContinueField;
                        //throw new Exception("مجال النشاط \"" + record.FieldWork + "\" غير موجود فى قاعدة البيانات.");
                    }

                    //make sure the (VolunteerId,FieldId) pair doesn't exist in the database
                    FieldVolunteerWork existingFieldVolunteer = _AssociatedFieldsManager.GetFieldVolunteerWorkByVolunteerIdAndFieldId(volunteerId, activityFieldinstance.FieldID, transactionInstance);
                    if (existingFieldVolunteer == null)
                    {
                        _AssociatedFieldsManager.InsertFieldVolunteerWork(activityFieldinstance.FieldID, volunteerId, transactionInstance);
                    }
                }
            ContinueField:

                //get additional activity field from database
                if (record.AdditionalFieldWork != null)
                {

                    Field additionalActivityFieldinstance = _AssociatedFieldsManager.GetFieldByFieldName(record.AdditionalFieldWork, transactionInstance);
                    if (additionalActivityFieldinstance == null)
                    {
                        if (!errorLog.Contains(record.AdditionalFieldWork))
                            errorLog += ", additionalFieldWork " + record.AdditionalFieldWork + "</br>";
                        goto ContinueAdditionalField;
                        // throw new Exception("مجال النشاط الإضافى \"" + record.AdditionalFieldWork + "\" غير موجود فى قاعدة البيانات.");
                    }
                    //make sure the (VolunteerId,FieldId) pair doesn't exist in the database
                    FieldVolunteerWork existingFieldVolunteer = _AssociatedFieldsManager.GetFieldVolunteerWorkByVolunteerIdAndFieldId(volunteerId, additionalActivityFieldinstance.FieldID, transactionInstance);
                    if (existingFieldVolunteer == null)
                    {
                        _AssociatedFieldsManager.InsertFieldVolunteerWork(additionalActivityFieldinstance.FieldID, volunteerId, transactionInstance);
                    }
                }
            ContinueAdditionalField:

                rowCount++;
            }

                _AssociatedVolunteersManager.CommitTransaction();
         

            lblErrorLog.Text = errorLog;

        }
        catch (Exception ex)
        {
            _AssociatedVolunteersManager.RollBackTransaction();
            throw new Exception("لا يمكن ادخال بيانات فى قاعدة البيانات نتيجة لخطأ فى بنية ملف الإكسل فى سطر  " + rowCount + ", " + ex.Message);
        }

    }

    /// <summary>
    /// Handles the Click event of the btnUpload control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (fuExcelSheet.FileName == string.Empty)
        {
            lblResult.Text = string.Empty;
            lblError.Text = "من فضلك حدد ملف إكسل ليتم إدخاله فى قاعدة البيانات";
            return;
        }

        string FilePath = Request.PhysicalApplicationPath + "UploadedFiles\\" + fuExcelSheet.FileName;

        if (fuExcelSheet.HasFile)
        {
            try
            {
                if (File.Exists(FilePath)) File.Delete(FilePath);
                fuExcelSheet.SaveAs(FilePath);
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblResult.Text = string.Empty;
                return;
            }
        }

        try
        {
            //code to process excel records here
            List<ExcelRecord> ExcelVolunteers = _ExcelSheetManager.GetActivitiesExcelSheetRecords(FilePath);
            ProcessExcelRecords(ExcelVolunteers);

            lblError.Text = string.Empty;
            lblResult.Text = "تم إدخال ملف الإكسل فى قاعدة البيانات.";
        }

        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblResult.Text = string.Empty;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //add 4 seconds delay for testing
        System.Threading.Thread.Sleep(4000);
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
