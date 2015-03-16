using System;
using System.Collections.Generic;
using System.Text;

namespace FBV.DataMapping
{
    [Serializable]
   public  class ActivitySearchRecord
    {
        public int? ActivityCodeNo;
        public int? ActivityDepartmentId;
       public int? ActivityFieldID;
       public int? ActivityCityID;
       public int? ActivityPlaceID;
       public string ActivityName;
       public string  ActivityMissionsIDs;
       public DateTime? ActivityRequestDateFrom;
       public DateTime? ActivityRequestDateTo;
       public DateTime? ActivityDateFrom;
       public DateTime? ActivityDateTo;
       public int? ActivityDaysCountFrom;
       public int? ActivityDaysCountTo;
       public int? VolunteersCountFrom;
       public int? VolunteersCountTo;
       public int? ActivityHoursFrom;
       public int? ActivityHoursTo;
    }
}
