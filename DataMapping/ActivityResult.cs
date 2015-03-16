using System;
using System.Collections.Generic;
using System.Text;

namespace FBV.DataMapping
{
    
    public class ActivityResult
    {
        public int ResultID;
        public int RActivityID;
        public DateTime RDay;
        public int RVolunteerID;
        public float? RVolTimeFrom;
        public float? RVolTimeTo;
        public string RVolWorkDetails;
        public int? RAttendanceState;
    }
}
