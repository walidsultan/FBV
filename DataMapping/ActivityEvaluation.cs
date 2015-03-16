using System;
using System.Collections.Generic;
using System.Text;

namespace FBV.DataMapping
{
    
    public class ActivityEvaluation
    {
        public int EvaluationID;
        public int EActivityID;
        public int EVolunteerID;
        public decimal EVolunteerWorkingHours;
        public int EVolunteersWorkingDays;
        public bool? EVolunteerIsRecommended;
        public string EVolunteerRecommendedComments;
        public string EVolunteerDepartmentEvaluation;
        public string    EActivityDepartmentEvaluation;
    }
}
