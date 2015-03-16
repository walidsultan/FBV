using System;
using System.Collections.Generic;
using System.Text;

namespace FBV.DataMapping
{
    
    public class Activity
    {
        public int ActivityID;
        public int? ActivityCodeNo;
        public string ActivityName;
        public DateTime? ActivityRequestDate;
        public int ActivityFieldID;
        public DateTime ActivityDateFrom;
        public DateTime ActivityDateTo;
        public string ActivityDetails;
        public string ActivityRequirments;
        public int? ActivityPlaceID;
        public string ActivityDocument;
        public int? ActivityCost;
        public int? ActivityRevenue;
        public DateTime  ActivityEntryDate;
        public int ActivityEntryUserID;
        public int ActivityEvaluatorID;
        public int? ActivityRequiredVolunteers;
        public string ActivityComments;
        public string ActivityDepartmentOpinion;
        public string ActivityVolunteerDepartmentOpinion;
    }
}
