using System;
using System.Collections.Generic;
using System.Text;

namespace FBV.DataMapping
{
    [Serializable]
    public class VolunteerSearchRecord
    {
        public string vName;
        public int? VolunteerManIdStart;
        public int? VolunteerManIdEnd;
        public DateTime? vBirthDateFrom;
        public DateTime? vBirthDateTo;
        public int? VUniversityID;
        public int? VFacultyID;
        public int? vEducationID;
        public int? vCityID;
        public int? vAreaID;
        public int? vJobPlaceID;
        public string vDesiredFields;
        public string vRecommendedFields;
        public string vSkills;
        public int? vKnow;
        public DateTime? vRegisterDate;
        public int? vRegistrationPlaceID;
        public DateTime? vFirstContactDate;
        public int? vFirstContactPlaceID;
        public DateTime? vMeetingDate;
        public int? vMeetingPlaceID;
        public int? vSchool;

        public DateTime? AvActivityStartDate;
        public DateTime? AvActivityEndDate;
        public int? AvActivityCodeNoStart;
        public int? AvActivityCodeNoEnd;
        public string AvFields;

        public DateTime? NvActivityStartDate;
        public DateTime? NvActivityEndDate;
        public int? NvActivityCodeNoStart;
        public int? NvActivityCodeNoEnd;
        public string NvFields;

        public string vRecommendedVolunteerFields;
    }
}
