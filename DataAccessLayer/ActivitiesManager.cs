using System;
using System.Collections.Generic;
using System.Text;
using FBV.DataMapping;
using System.Data.SqlClient;
using System.Data;
namespace FBV.DataAccessLayer
{
    public class ActivitiesManager : DatabaseManager
    {
        #region ActivityMainMethods
        public DataTable GetAllActivities()
        {
            return GetTable("ActivitiesGetAll");
        }

        public Activity GetActivitiesByActivityID(int ActivityID)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@ActivityID", ActivityID);
                reader = ExecuteReader("ActivitiesGetByActivityID", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int activityCodeNoOrdinal = reader.GetOrdinal("ActivityCodeNo");
                int activityNameOrdinal = reader.GetOrdinal("ActivityName");
                int activityRequestDateOrdinal = reader.GetOrdinal("ActivityRequestDate");
                int activityFieldIDOrdinal = reader.GetOrdinal("ActivityFieldID");
                int activityDateFromOrdinal = reader.GetOrdinal("ActivityDateFrom");
                int activityDateToOrdinal = reader.GetOrdinal("ActivityDateTo");
                int activityDetailsOrdinal = reader.GetOrdinal("ActivityDetails");
                int activityRequirmentsOrdinal = reader.GetOrdinal("ActivityRequirments");
                int activityPlaceIDOrdinal = reader.GetOrdinal("ActivityPlaceID");
                int activityDocumentOrdinal = reader.GetOrdinal("ActivityDocument");
                int activityCostOrdinal = reader.GetOrdinal("ActivityCost");
                int activityRevenueOrdinal = reader.GetOrdinal("ActivityRevenue");
                int activityEntryDateOrdinal = reader.GetOrdinal("ActivityEntryDate");
                int activityEntryUserIDOrdinal = reader.GetOrdinal("ActivityEntryUserID");
                int activityEvaluatorIDOrdinal = reader.GetOrdinal("ActivityEvaluatorID");
                int activityRequiredVolunteersOrdinal = reader.GetOrdinal("ActivityRequiredVolunteers");
                int activityCommentsOrdinal = reader.GetOrdinal("ActivityComments");
                int activityDepartmentOpinionOrdinal = reader.GetOrdinal("ActivityDepartmentOpinion");
                int activityVolunteerDepartmentOpinionOrdinal = reader.GetOrdinal("ActivityVolunteerDepartmentOpinion");

                reader.Read();
                Activity activityInstance = new Activity();

                if (reader.IsDBNull(activityCodeNoOrdinal))
                    activityInstance.ActivityCodeNo = null;
                else
                    activityInstance.ActivityCodeNo = reader.GetInt32(activityCodeNoOrdinal);

                activityInstance.ActivityName = reader.GetString(activityNameOrdinal);

                if (reader.IsDBNull(activityRequestDateOrdinal))
                    activityInstance.ActivityRequestDate = null;
                else
                    activityInstance.ActivityRequestDate = reader.GetDateTime(activityRequestDateOrdinal);

                if (reader.IsDBNull(activityPlaceIDOrdinal))
                    activityInstance.ActivityPlaceID = null;
                else
                    activityInstance.ActivityPlaceID = reader.GetInt32(activityPlaceIDOrdinal);

                activityInstance.ActivityFieldID = reader.GetInt32(activityFieldIDOrdinal);
                activityInstance.ActivityDateFrom = reader.GetDateTime(activityDateFromOrdinal);
                activityInstance.ActivityDateTo = reader.GetDateTime(activityDateToOrdinal);
                activityInstance.ActivityDetails = reader.GetString(activityDetailsOrdinal);
                activityInstance.ActivityRequirments = reader.GetString(activityRequirmentsOrdinal);


                if (reader.IsDBNull(activityDocumentOrdinal))
                    activityInstance.ActivityDocument = null;
                else
                    activityInstance.ActivityDocument = reader.GetString(activityDocumentOrdinal);

                if (reader.IsDBNull(activityCostOrdinal))
                    activityInstance.ActivityCost = null;
                else
                    activityInstance.ActivityCost = reader.GetInt32(activityCostOrdinal);

                if (reader.IsDBNull(activityRevenueOrdinal))
                    activityInstance.ActivityRevenue = null;
                else
                    activityInstance.ActivityRevenue = reader.GetInt32(activityRevenueOrdinal);

                activityInstance.ActivityEntryDate = reader.GetDateTime(activityEntryDateOrdinal);
                activityInstance.ActivityEntryUserID = reader.GetInt32(activityEntryUserIDOrdinal);
                activityInstance.ActivityEvaluatorID = reader.GetInt32(activityEvaluatorIDOrdinal);

                if (reader.IsDBNull(activityRequiredVolunteersOrdinal))
                    activityInstance.ActivityRequiredVolunteers = null;
                else
                    activityInstance.ActivityRequiredVolunteers = reader.GetInt32(activityRequiredVolunteersOrdinal);

                if (reader.IsDBNull(activityCommentsOrdinal))
                    activityInstance.ActivityComments = null;
                else
                    activityInstance.ActivityComments = reader.GetString(activityCommentsOrdinal);

                if (reader.IsDBNull(activityDepartmentOpinionOrdinal))
                    activityInstance.ActivityDepartmentOpinion = null;
                else
                    activityInstance.ActivityDepartmentOpinion = reader.GetString(activityDepartmentOpinionOrdinal);

                if (reader.IsDBNull(activityVolunteerDepartmentOpinionOrdinal))
                    activityInstance.ActivityVolunteerDepartmentOpinion = null;
                else
                    activityInstance.ActivityVolunteerDepartmentOpinion = reader.GetString(activityVolunteerDepartmentOpinionOrdinal);

                return activityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public int InsertActivity(Activity newActivity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (newActivity.ActivityCodeNo == null)
                parameters.Add(new SqlParameter("@ActivityCodeNo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCodeNo", newActivity.ActivityCodeNo));

            parameters.Add(new SqlParameter("@ActivityName", newActivity.ActivityName));

            if (newActivity.ActivityRequestDate == null)
                parameters.Add(new SqlParameter("@ActivityRequestDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequestDate", newActivity.ActivityRequestDate));

            if (newActivity.ActivityPlaceID == null)
                parameters.Add(new SqlParameter("@ActivityPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityPlaceID", newActivity.ActivityPlaceID));

            parameters.Add(new SqlParameter("@ActivityFieldID", newActivity.ActivityFieldID));
            parameters.Add(new SqlParameter("@ActivityDateFrom", newActivity.ActivityDateFrom));
            parameters.Add(new SqlParameter("@ActivityDateTo", newActivity.ActivityDateTo));
            parameters.Add(new SqlParameter("@ActivityDetails", newActivity.ActivityDetails));
            parameters.Add(new SqlParameter("@ActivityRequirments", newActivity.ActivityRequirments));



            if (newActivity.ActivityDocument == null)
                parameters.Add(new SqlParameter("@ActivityDocument", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDocument", newActivity.ActivityDocument));

            if (newActivity.ActivityCost == null)
                parameters.Add(new SqlParameter("@ActivityCost", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCost", newActivity.ActivityCost));

            if (newActivity.ActivityRevenue == null)
                parameters.Add(new SqlParameter("@ActivityRevenue", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRevenue", newActivity.ActivityRevenue));

            parameters.Add(new SqlParameter("@ActivityEntryDate", newActivity.ActivityEntryDate));
            parameters.Add(new SqlParameter("@ActivityEntryUserID", newActivity.ActivityEntryUserID));
            parameters.Add(new SqlParameter("@ActivityEvaluatorID", newActivity.ActivityEvaluatorID));

            if (newActivity.ActivityRequiredVolunteers == null)
                parameters.Add(new SqlParameter("@ActivityRequiredVolunteers", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequiredVolunteers", newActivity.ActivityRequiredVolunteers));

            if (newActivity.ActivityComments == null)
                parameters.Add(new SqlParameter("@ActivityComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityComments", newActivity.ActivityComments));

            if (newActivity.ActivityDepartmentOpinion == null)
                parameters.Add(new SqlParameter("@ActivityDepartmentOpinion", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDepartmentOpinion", newActivity.ActivityDepartmentOpinion));

            if (newActivity.ActivityVolunteerDepartmentOpinion == null)
                parameters.Add(new SqlParameter("@ActivityVolunteerDepartmentOpinion", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityVolunteerDepartmentOpinion", newActivity.ActivityVolunteerDepartmentOpinion));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivitiesInsert", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Activities_CodeNo"))
                {
                    throw new Exception("رقم تعريف النشاط " + newActivity.ActivityCodeNo.ToString() + "مكرر, من فضلك إدخل رقم أخر ");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        public int InsertActivity(Activity newActivity, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (newActivity.ActivityCodeNo == null)
                parameters.Add(new SqlParameter("@ActivityCodeNo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCodeNo", newActivity.ActivityCodeNo));

            parameters.Add(new SqlParameter("@ActivityName", newActivity.ActivityName));

            if (newActivity.ActivityRequestDate == null)
                parameters.Add(new SqlParameter("@ActivityRequestDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequestDate", newActivity.ActivityRequestDate));

            if (newActivity.ActivityPlaceID == null)
                parameters.Add(new SqlParameter("@ActivityPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityPlaceID", newActivity.ActivityPlaceID));

            parameters.Add(new SqlParameter("@ActivityFieldID", newActivity.ActivityFieldID));
            parameters.Add(new SqlParameter("@ActivityDateFrom", newActivity.ActivityDateFrom));
            parameters.Add(new SqlParameter("@ActivityDateTo", newActivity.ActivityDateTo));
            parameters.Add(new SqlParameter("@ActivityDetails", newActivity.ActivityDetails));
            parameters.Add(new SqlParameter("@ActivityRequirments", newActivity.ActivityRequirments));


            if (newActivity.ActivityDocument == null)
                parameters.Add(new SqlParameter("@ActivityDocument", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDocument", newActivity.ActivityDocument));

            if (newActivity.ActivityCost == null)
                parameters.Add(new SqlParameter("@ActivityCost", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCost", newActivity.ActivityCost));

            if (newActivity.ActivityRevenue == null)
                parameters.Add(new SqlParameter("@ActivityRevenue", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRevenue", newActivity.ActivityRevenue));

            parameters.Add(new SqlParameter("@ActivityEntryDate", newActivity.ActivityEntryDate));
            parameters.Add(new SqlParameter("@ActivityEntryUserID", newActivity.ActivityEntryUserID));
            parameters.Add(new SqlParameter("@ActivityEvaluatorID", newActivity.ActivityEvaluatorID));

            if (newActivity.ActivityRequiredVolunteers == null)
                parameters.Add(new SqlParameter("@ActivityRequiredVolunteers", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequiredVolunteers", newActivity.ActivityRequiredVolunteers));

            if (newActivity.ActivityComments == null)
                parameters.Add(new SqlParameter("@ActivityComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityComments", newActivity.ActivityComments));

            if (newActivity.ActivityDepartmentOpinion == null)
                parameters.Add(new SqlParameter("@ActivityDepartmentOpinion", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDepartmentOpinion", newActivity.ActivityDepartmentOpinion));

            if (newActivity.ActivityVolunteerDepartmentOpinion == null)
                parameters.Add(new SqlParameter("@ActivityVolunteerDepartmentOpinion", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityVolunteerDepartmentOpinion", newActivity.ActivityVolunteerDepartmentOpinion));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivitiesInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Activities_CodeNo"))
                {
                    throw new Exception("رقم تعريف النشاط " + newActivity.ActivityCodeNo.ToString() + "مكرر, من فضلك إدخل رقم أخر ");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        public void UpdateActivity(Activity updatedActivity, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ActivityID", updatedActivity.ActivityID));

            if (updatedActivity.ActivityCodeNo == null)
                parameters.Add(new SqlParameter("@ActivityCodeNo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCodeNo", updatedActivity.ActivityCodeNo));

            parameters.Add(new SqlParameter("@ActivityName", updatedActivity.ActivityName));
            if (updatedActivity.ActivityRequestDate == null)
                parameters.Add(new SqlParameter("@ActivityRequestDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequestDate", updatedActivity.ActivityRequestDate));

            if (updatedActivity.ActivityPlaceID == null)
                parameters.Add(new SqlParameter("@ActivityPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityPlaceID", updatedActivity.ActivityPlaceID));

            parameters.Add(new SqlParameter("@ActivityFieldID", updatedActivity.ActivityFieldID));
            parameters.Add(new SqlParameter("@ActivityDateFrom", updatedActivity.ActivityDateFrom));
            parameters.Add(new SqlParameter("@ActivityDateTo", updatedActivity.ActivityDateTo));
            parameters.Add(new SqlParameter("@ActivityDetails", updatedActivity.ActivityDetails));
            parameters.Add(new SqlParameter("@ActivityRequirments", updatedActivity.ActivityRequirments));

            if (updatedActivity.ActivityDocument == null)
                parameters.Add(new SqlParameter("@ActivityDocument", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDocument", updatedActivity.ActivityDocument));

            if (updatedActivity.ActivityCost == null)
                parameters.Add(new SqlParameter("@ActivityCost", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCost", updatedActivity.ActivityCost));

            if (updatedActivity.ActivityRevenue == null)
                parameters.Add(new SqlParameter("@ActivityRevenue", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRevenue", updatedActivity.ActivityRevenue));

            parameters.Add(new SqlParameter("@ActivityEntryDate", updatedActivity.ActivityEntryDate));
            parameters.Add(new SqlParameter("@ActivityEntryUserID", updatedActivity.ActivityEntryUserID));
            parameters.Add(new SqlParameter("@ActivityEvaluatorID", updatedActivity.ActivityEvaluatorID));

            if (updatedActivity.ActivityRequiredVolunteers == null)
                parameters.Add(new SqlParameter("@ActivityRequiredVolunteers", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequiredVolunteers", updatedActivity.ActivityRequiredVolunteers));

            if (updatedActivity.ActivityComments == null)
                parameters.Add(new SqlParameter("@ActivityComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityComments", updatedActivity.ActivityComments));

            if (updatedActivity.ActivityDepartmentOpinion == null)
                parameters.Add(new SqlParameter("@ActivityDepartmentOpinion", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDepartmentOpinion", updatedActivity.ActivityDepartmentOpinion));

            if (updatedActivity.ActivityVolunteerDepartmentOpinion == null)
                parameters.Add(new SqlParameter("@ActivityVolunteerDepartmentOpinion", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityVolunteerDepartmentOpinion", updatedActivity.ActivityVolunteerDepartmentOpinion));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivitiesUpdate", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Activities_CodeNo"))
                {
                    throw new Exception("رقم تعريف النشاط " + updatedActivity.ActivityCodeNo.ToString() + "مكرر, من فضلك إدخل رقم أخر ");
                }
                else
                    throw exceptionInstance;
            }

        }

        public void DeleteActivity(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@ActivityId", ActivityId);
            try
            {
                ExecuteNonQuery("ActivitiesDelete", idParameter);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("There is data in the database related to this activity. This activity cannot be deleted.");
                }
                else
                    throw ex;
            }
        }

        public void DeleteActivityRelatedTablesByActivityId(int ActivityId, SqlTransaction transactionInstance)
        {
            SqlParameter idParameter = new SqlParameter("@ActivityID", ActivityId);

            try
            {
                ExecuteNonQuery("ActivitiesDeleteRelatedTablesByActivityId", idParameter, transactionInstance);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("There is data in the database related to this activity. This activity cannot be deleted.");
                }
                else
                    throw ex;
            }
        }

        public List<string> GetActivityNames()
        {

            SqlDataReader reader = null;

            try
            {
                reader = ExecuteReader("ActivityNamesGetAll");

                if (!reader.HasRows)
                    // if there is no entry with the given prefix
                    return null;

                int activityNameOrdinal = reader.GetOrdinal("ActivityName");
                List<string> activityNames = new List<string>();
                while (reader.Read())
                {
                    activityNames.Add(reader.GetString(activityNameOrdinal));
                }
                return activityNames;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public int GetActivityVolunteersCount(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@ActivityId", ActivityId);
            object volunteersCount = ExecuteScalar("ActivityGetVolunteersCountByActivityId", idParameter);
            if (volunteersCount != DBNull.Value )
                return (int)volunteersCount;
            else
                return 0;
        }
            
        public int GetActivityDaysCount(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@ActivityId", ActivityId);
            object daysCount = ExecuteScalar("ActivityGetDaysCountByActivityId", idParameter);
            if (daysCount != DBNull.Value)
                return (int)daysCount;
            else
                return 0;
        }

        public int GetActivityHours(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@ActivityId", ActivityId);
            object activityHours= ExecuteScalar("ActivityGetHoursByActivityId", idParameter);
            if (activityHours != DBNull.Value)
                return (int)activityHours;
            else
                return 0;
        }
 
        public DataSet Search(ActivitySearchRecord searchRecord, int PageIndex, int PageSize)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (searchRecord.ActivityCodeNo == null)
                parameters.Add(new SqlParameter("@ActivityCodeNo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCodeNo", searchRecord.ActivityCodeNo));

            if (searchRecord.ActivityDepartmentId == null)
                parameters.Add(new SqlParameter("@ActivityDepartmentId", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDepartmentId", searchRecord.ActivityDepartmentId));

            if (searchRecord.ActivityFieldID == null)
                parameters.Add(new SqlParameter("@ActivityFieldID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityFieldID", searchRecord.ActivityFieldID));

            if (searchRecord.ActivityCityID == null)
                parameters.Add(new SqlParameter("@ActivityCityID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityCityID", searchRecord.ActivityCityID));

            if (searchRecord.ActivityPlaceID == null)
                parameters.Add(new SqlParameter("@ActivityPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityPlaceID", searchRecord.ActivityPlaceID));

            if (searchRecord.ActivityName == null)
                parameters.Add(new SqlParameter("@ActivityName", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityName", searchRecord.ActivityName));

            if (searchRecord.ActivityMissionsIDs == null)
                parameters.Add(new SqlParameter("@ActivityMissionsIDs", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityMissionsIDs", searchRecord.ActivityMissionsIDs));

            if (searchRecord.ActivityRequestDateFrom == null)
                parameters.Add(new SqlParameter("@ActivityRequestDateFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequestDateFrom", searchRecord.ActivityRequestDateFrom));

            if (searchRecord.ActivityRequestDateTo == null)
                parameters.Add(new SqlParameter("@ActivityRequestDateTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityRequestDateTo", searchRecord.ActivityRequestDateTo));

            if (searchRecord.ActivityDateFrom == null)
                parameters.Add(new SqlParameter("@ActivityDateFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDateFrom", searchRecord.ActivityDateFrom));

            if (searchRecord.ActivityDateTo == null)
                parameters.Add(new SqlParameter("@ActivityDateTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDateTo", searchRecord.ActivityDateTo));

            if (searchRecord.ActivityDaysCountFrom == null)
                parameters.Add(new SqlParameter("@ActivityDaysCountFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDaysCountFrom", searchRecord.ActivityDaysCountFrom));

            if (searchRecord.ActivityDaysCountTo == null)
                parameters.Add(new SqlParameter("@ActivityDaysCountTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityDaysCountTo", searchRecord.ActivityDaysCountTo));

            if (searchRecord.VolunteersCountFrom == null)
                parameters.Add(new SqlParameter("@VolunteersCountFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VolunteersCountFrom", searchRecord.VolunteersCountFrom));

            if (searchRecord.VolunteersCountTo == null)
                parameters.Add(new SqlParameter("@VolunteersCountTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VolunteersCountTo", searchRecord.VolunteersCountTo));

            if (searchRecord.ActivityHoursFrom == null)
                parameters.Add(new SqlParameter("@ActivityHoursFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityHoursFrom", searchRecord.ActivityHoursFrom));

            if (searchRecord.ActivityHoursTo == null)
                parameters.Add(new SqlParameter("@ActivityHoursTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@ActivityHoursTo", searchRecord.ActivityHoursTo));

            parameters.Add(new SqlParameter("@PageIndex", PageIndex));

            parameters.Add(new SqlParameter("@PageSize", PageSize));

            return GetDataSet("ActivitiesSearch", parameters);
        }
        #endregion

        #region ActivityResultMethods
        public int InsertActivityResult(ActivityResult newActivityResult, SqlTransaction tranasactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@RActivityID", newActivityResult.RActivityID));
            parameters.Add(new SqlParameter("@RDay", newActivityResult.RDay));
            parameters.Add(new SqlParameter("@RVolunteerID", newActivityResult.RVolunteerID));

            if (newActivityResult.RVolTimeFrom == null)
                parameters.Add(new SqlParameter("@RVolTimeFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RVolTimeFrom", newActivityResult.RVolTimeFrom));

            if (newActivityResult.RVolTimeTo == null)
                parameters.Add(new SqlParameter("@RVolTimeTo", DBNull.Value));
            else
            parameters.Add(new SqlParameter("@RVolTimeTo", newActivityResult.RVolTimeTo));

            if (newActivityResult.RVolWorkDetails == null)
                parameters.Add(new SqlParameter("@RVolWorkDetails", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RVolWorkDetails", newActivityResult.RVolWorkDetails));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivityResultInsert", parameters, tranasactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                //if (exceptionInstance.Message.Contains("UK_Fac_Activities_ActivityName"))
                //{
                //    throw new Exception("The activity name you entered \"" + newActivity.ActivityName + "\" already exist. Please insert another activity name.");
                //}
                //else
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }
        public DataTable GetActivityResultsByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultGetByActivityId", idParameter);
        }
        public DataTable GetActivityResultVolunteersByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultVolunteersGetByActivityId", idParameter);
        }
        public DataTable GetActivityResultDaysByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultDaysGetByActivityId", idParameter);
        }
        public DataTable GetActivityResultGroupedByVolunteerId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultGetByActivityIdGroupedByVolunteerId", idParameter);
        }
        #endregion

        #region ActivityResultRealMethods
        public int InsertActivityResultReal(ActivityResult newActivityResult, SqlTransaction tranasactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@RActivityID", newActivityResult.RActivityID));
            parameters.Add(new SqlParameter("@RDay", newActivityResult.RDay));
            parameters.Add(new SqlParameter("@RVolunteerID", newActivityResult.RVolunteerID));

            if (newActivityResult.RVolTimeFrom == null)
                parameters.Add(new SqlParameter("@RVolTimeFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RVolTimeFrom", newActivityResult.RVolTimeFrom));

            if (newActivityResult.RVolTimeTo == null)
                parameters.Add(new SqlParameter("@RVolTimeTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RVolTimeTo", newActivityResult.RVolTimeTo));


            if (newActivityResult.RVolWorkDetails == null)
                parameters.Add(new SqlParameter("@RVolWorkDetails", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RVolWorkDetails", newActivityResult.RVolWorkDetails));

            if (newActivityResult.RAttendanceState  == null)
                parameters.Add(new SqlParameter("@RAttendanceState", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RAttendanceState", newActivityResult.RAttendanceState));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivityResultRealInsert", parameters, tranasactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                //if (exceptionInstance.Message.Contains("UK_Fac_Activities_ActivityName"))
                //{
                //    throw new Exception("The activity name you entered \"" + newActivity.ActivityName + "\" already exist. Please insert another activity name.");
                //}
                //else
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }
        public DataTable GetActivityResultsRealByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultRealGetByActivityId", idParameter);
        }
        public DataTable GetActivityResultRealVolunteersByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultRealVolunteersGetByActivityId", idParameter);
        }
        public DataTable GetActivityResultRealDaysByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultRealDaysGetByActivityId", idParameter);
        }

        public DataTable GetActivityResultRealGroupedByVolunteerId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("@RActivityID", ActivityId);
            return GetTable("ActivityResultRealGetByActivityIdGroupedByVolunteerId", idParameter);
        }
        #endregion

        #region ActivtyDepartmentMethods
        public void InsertActivityDeopartment(ActivityDepartment newActivityDepartment, SqlTransaction tranasactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ActivityID", newActivityDepartment.ActivityID));
            parameters.Add(new SqlParameter("@DepartmentID", newActivityDepartment.DepartmentID));
            parameters.Add(new SqlParameter("@UserID", newActivityDepartment.UserID));

            try
            {
                ExecuteNonQuery("ActivityDepartmentInsert", parameters, tranasactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                //if (exceptionInstance.Message.Contains("UK_Fac_Activities_ActivityName"))
                //{
                //    throw new Exception("The activity name you entered \"" + newActivity.ActivityName + "\" already exist. Please insert another activity name.");
                //}
                //else
                throw exceptionInstance;
            }

        }

        public DataTable GetActivityDepartmentsByActivityId(int ActivityId)
        {
            SqlParameter idParameter = new SqlParameter("ActivityId", ActivityId);
            return GetTable("ActivityDepartmentsGetByActivityId", idParameter);
        }

        #endregion

        #region ActivityMissionMethods
        public void InsertActivityMission(ActivityMission newActivityMission, SqlTransaction tranasactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ActivityID", newActivityMission.ActivityID));
            parameters.Add(new SqlParameter("@MissionId", newActivityMission.MissionId));

            try
            {
                ExecuteNonQuery("ActivityMissionInsert", parameters, tranasactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                //if (exceptionInstance.Message.Contains("UK_Fac_Activities_ActivityName"))
                //{
                //    throw new Exception("The activity name you entered \"" + newActivity.ActivityName + "\" already exist. Please insert another activity name.");
                //}
                //else
                throw exceptionInstance;
            }
        }
        public DataTable GetActivityMissionsByActivityId(int activityId)
        {
            SqlParameter idParameter = new SqlParameter("@ActivityID", activityId);
            return GetTable("ActivityMissionGetByActivityId", idParameter);
        }
        #endregion

        #region ActivityResultMissionMethods
        public void InsertActivityResultMission(ResultMission newResultMission, SqlTransaction tranasactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ResultID", newResultMission.ResultID));
            parameters.Add(new SqlParameter("@RMissionID", newResultMission.RMissionID));

            try
            {
                ExecuteNonQuery("ResultMissionInsert", parameters, tranasactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                //if (exceptionInstance.Message.Contains("UK_Fac_Activities_ActivityName"))
                //{
                //    throw new Exception("The activity name you entered \"" + newActivity.ActivityName + "\" already exist. Please insert another activity name.");
                //}
                //else
                throw exceptionInstance;
            }
        }

        public DataTable GetActivityResultMissionsByResultId(int ResultId)
        {
            SqlParameter idParameter = new SqlParameter("@ResultID", ResultId);
            return GetTable("ResultMissionGetByResultId", idParameter);
        }

        #endregion

        #region ActivityResultRealMissionMethods
        public void InsertActivityResultRealMission(ResultMission newResultMission, SqlTransaction tranasactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ResultID", newResultMission.ResultID));
            parameters.Add(new SqlParameter("@RMissionID", newResultMission.RMissionID));

            try
            {
                ExecuteNonQuery("ResultRealMissionInsert", parameters, tranasactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                //if (exceptionInstance.Message.Contains("UK_Fac_Activities_ActivityName"))
                //{
                //    throw new Exception("The activity name you entered \"" + newActivity.ActivityName + "\" already exist. Please insert another activity name.");
                //}
                //else
                throw exceptionInstance;
            }
        }

        public DataTable GetActivityResultRealMissionsByResultId(int ResultId)
        {
            SqlParameter idParameter = new SqlParameter("@ResultID", ResultId);
            return GetTable("ResultRealMissionGetByResultId", idParameter);
        }

        #endregion

        #region ActivityEvaluationMethods
        public int InsertActivityEvaluation(ActivityEvaluation ActivityEvaluation, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@EActivityID", ActivityEvaluation.EActivityID));
            parameters.Add(new SqlParameter("@EVolunteerID", ActivityEvaluation.EVolunteerID));
            parameters.Add(new SqlParameter("@EVolunteerWorkingHours", ActivityEvaluation.EVolunteerWorkingHours));
            parameters.Add(new SqlParameter("@EVolunteersWorkingDays", ActivityEvaluation.EVolunteersWorkingDays));

            if (ActivityEvaluation.EVolunteerIsRecommended == null)
                parameters.Add(new SqlParameter("@EVolunteerIsRecommended", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EVolunteerIsRecommended", ActivityEvaluation.EVolunteerIsRecommended));

            if (ActivityEvaluation.EVolunteerRecommendedComments == null)
                parameters.Add(new SqlParameter("@EVolunteerRecommendedComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EVolunteerRecommendedComments", ActivityEvaluation.EVolunteerRecommendedComments));

            if (string.IsNullOrEmpty( ActivityEvaluation.EVolunteerDepartmentEvaluation ))
                parameters.Add(new SqlParameter("@EVolunteerDepartmentEvaluation", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EVolunteerDepartmentEvaluation", ActivityEvaluation.EVolunteerDepartmentEvaluation));

            if (string.IsNullOrEmpty(ActivityEvaluation.EActivityDepartmentEvaluation ))
                parameters.Add(new SqlParameter("@EActivityDepartmentEvaluation", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EActivityDepartmentEvaluation", ActivityEvaluation.EActivityDepartmentEvaluation));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivityEvaluationInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;

        }
        public void UpdateActivityEvaluation(ActivityEvaluation ActivityEvaluation, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EvaluationID", ActivityEvaluation.EActivityID));
            parameters.Add(new SqlParameter("@EActivityID", ActivityEvaluation.EActivityID));
            parameters.Add(new SqlParameter("@EVolunteerID", ActivityEvaluation.EVolunteerID));
            parameters.Add(new SqlParameter("@EVolunteerWorkingHours", ActivityEvaluation.EVolunteerWorkingHours));
            parameters.Add(new SqlParameter("@EVolunteersWorkingDays", ActivityEvaluation.EVolunteersWorkingDays));

            if (ActivityEvaluation.EVolunteerIsRecommended == null)
                parameters.Add(new SqlParameter("@EVolunteerIsRecommended", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EVolunteerIsRecommended", ActivityEvaluation.EVolunteerIsRecommended));

            if (ActivityEvaluation.EVolunteerRecommendedComments == null)
                parameters.Add(new SqlParameter("@EVolunteerRecommendedComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EVolunteerRecommendedComments", ActivityEvaluation.EVolunteerRecommendedComments));

            if (ActivityEvaluation.EVolunteerDepartmentEvaluation == null)
                parameters.Add(new SqlParameter("@EVolunteerDepartmentEvaluation", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EVolunteerDepartmentEvaluation", ActivityEvaluation.EVolunteerDepartmentEvaluation));

            if (ActivityEvaluation.EActivityDepartmentEvaluation == null)
                parameters.Add(new SqlParameter("@EActivityDepartmentEvaluation", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EActivityDepartmentEvaluation", ActivityEvaluation.EActivityDepartmentEvaluation));

            try
            {
                ExecuteNonQuery("ActivityEvaluationUpdate", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"
                throw exceptionInstance;
            }
        }
        public DataTable GetActivityEvaluationByActivityId(int ActivityId)
        {
            SqlParameter ActivityIdParameter = new SqlParameter("@EActivityID", ActivityId);
            return GetTable("ActivityEvaluationGetByActivityId", ActivityIdParameter);
        }
        public ActivityEvaluation GetActivityEvaluationByEvaluationId(int EvaluationId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@EvaluationID", EvaluationId);
                reader = ExecuteReader("ActivityEvaluationGetByEvaluationId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int activityIdOrdinal = reader.GetOrdinal("EActivityID");
                int volunteerIdOrdinal = reader.GetOrdinal("EVolunteerID");
                int volunteerWorkingHoursOrdinal = reader.GetOrdinal("EVolunteerWorkingHours");
                int volunteersWorkingDaysOrdinal = reader.GetOrdinal("EVolunteersWorkingDays");
                int volunteerIsRecommendedOrdinal = reader.GetOrdinal("EVolunteerIsRecommended");
                int volunteerRecommendedCommentsOrdinal = reader.GetOrdinal("EVolunteerRecommendedComments");
                int volunteerDepartmentEvaluationOrdinal = reader.GetOrdinal("EVolunteerDepartmentEvaluation");
                int activityDepartmentEvaluationOrdinal = reader.GetOrdinal("EActivityDepartmentEvaluation");

                reader.Read();
                ActivityEvaluation evaluationInstance = new ActivityEvaluation();
                evaluationInstance.EvaluationID = EvaluationId;
                evaluationInstance.EActivityID = reader.GetInt32(activityIdOrdinal);
                evaluationInstance.EVolunteerID = reader.GetInt32(volunteerIdOrdinal);

                if (reader.IsDBNull(volunteerIsRecommendedOrdinal))
                    evaluationInstance.EVolunteerIsRecommended = null;
                else
                    evaluationInstance.EVolunteerIsRecommended = reader.GetBoolean(volunteerIsRecommendedOrdinal);

                if (reader.IsDBNull(volunteerRecommendedCommentsOrdinal))
                    evaluationInstance.EVolunteerRecommendedComments = null;
                else
                    evaluationInstance.EVolunteerRecommendedComments = reader.GetString(volunteerRecommendedCommentsOrdinal);

                evaluationInstance.EVolunteersWorkingDays = reader.GetInt32(volunteersWorkingDaysOrdinal);
                evaluationInstance.EVolunteerWorkingHours = (decimal)reader.GetDouble(volunteerWorkingHoursOrdinal);

                if (reader.IsDBNull(volunteerDepartmentEvaluationOrdinal))
                    evaluationInstance.EVolunteerDepartmentEvaluation= null;
                else
                    evaluationInstance.EVolunteerDepartmentEvaluation = reader.GetString(volunteerDepartmentEvaluationOrdinal);

                if (reader.IsDBNull(activityDepartmentEvaluationOrdinal))
                    evaluationInstance.EActivityDepartmentEvaluation = null;
                else
                    evaluationInstance.EActivityDepartmentEvaluation = reader.GetString(activityDepartmentEvaluationOrdinal);

                return evaluationInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }

        public ActivityEvaluation GetActivityEvaluationByEvaluationIdAndVolunteerId(int EvaluationId,int VolunteerId)
        {
            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@EvaluationID", EvaluationId));
                parameters.Add(new SqlParameter("@EvolunteerId", VolunteerId));

                reader = ExecuteReader("ActivityEvaluationGetByEvaluationIdAndVolunteerId", parameters );

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int activityIdOrdinal = reader.GetOrdinal("EActivityID");
                int volunteerIdOrdinal = reader.GetOrdinal("EVolunteerID");
                int volunteerWorkingHoursOrdinal = reader.GetOrdinal("EVolunteerWorkingHours");
                int volunteersWorkingDaysOrdinal = reader.GetOrdinal("EVolunteersWorkingDays");
                int volunteerIsRecommendedOrdinal = reader.GetOrdinal("EVolunteerIsRecommended");
                int volunteerRecommendedCommentsOrdinal = reader.GetOrdinal("EVolunteerRecommendedComments");
                int volunteerDepartmentEvaluationOrdinal = reader.GetOrdinal("EVolunteerDepartmentEvaluation");
                int activityDepartmentEvaluationOrdinal = reader.GetOrdinal("EActivityDepartmentEvaluation");

                reader.Read();
                ActivityEvaluation evaluationInstance = new ActivityEvaluation();
                evaluationInstance.EvaluationID = EvaluationId;
                evaluationInstance.EActivityID = reader.GetInt32(activityIdOrdinal);
                evaluationInstance.EVolunteerID = reader.GetInt32(volunteerIdOrdinal);

                if (reader.IsDBNull(volunteerIsRecommendedOrdinal))
                    evaluationInstance.EVolunteerIsRecommended = null;
                else
                    evaluationInstance.EVolunteerIsRecommended = reader.GetBoolean(volunteerIsRecommendedOrdinal);

                if (reader.IsDBNull(volunteerRecommendedCommentsOrdinal))
                    evaluationInstance.EVolunteerRecommendedComments = null;
                else
                    evaluationInstance.EVolunteerRecommendedComments = reader.GetString(volunteerRecommendedCommentsOrdinal);

                evaluationInstance.EVolunteersWorkingDays = reader.GetInt32(volunteersWorkingDaysOrdinal);
                evaluationInstance.EVolunteerWorkingHours = (decimal)reader.GetDouble(volunteerWorkingHoursOrdinal);

                if (reader.IsDBNull(volunteerDepartmentEvaluationOrdinal))
                    evaluationInstance.EVolunteerDepartmentEvaluation = null;
                else
                    evaluationInstance.EVolunteerDepartmentEvaluation = reader.GetString(volunteerDepartmentEvaluationOrdinal);

                if (reader.IsDBNull(activityDepartmentEvaluationOrdinal))
                    evaluationInstance.EActivityDepartmentEvaluation = null;
                else
                    evaluationInstance.EActivityDepartmentEvaluation = reader.GetString(activityDepartmentEvaluationOrdinal);

                return evaluationInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }

        #endregion

        #region ActivityEvaluationSkillsMethods
        public void ActivityEvaluationSkillsDeleteByEvaluationId(int EvaluationId, SqlTransaction transactionInstance)
        {
            SqlParameter idParameter = new SqlParameter("@EvalutionId", EvaluationId);
            try
            {
                ExecuteNonQuery("ActivityEvaluationSkillsDeleteByEvaluationId", idParameter, transactionInstance);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("There is data in the database related to this activity. This activity cannot be deleted.");
                }
                else
                    throw ex;
            }
        }
        public int InsertActivityEvaluationSkills(ActivityEvaluationSkill ActivityEvaluationSkill, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ESkillID", ActivityEvaluationSkill.ESkillID));
            parameters.Add(new SqlParameter("@ESkillLevel", ActivityEvaluationSkill.ESkillLevel));
            parameters.Add(new SqlParameter("@ESkillComments", ActivityEvaluationSkill.ESkillComments));
            parameters.Add(new SqlParameter("@EvaluationID", ActivityEvaluationSkill.EvaluationID));
            if (ActivityEvaluationSkill.EdepartmentID == null)
                parameters.Add(new SqlParameter("@EdepartmentID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EdepartmentID", ActivityEvaluationSkill.EdepartmentID));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivityEvaluationSkillsInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;


        }
        public DataTable ActivityEvaluationSkillsGetByActivityId(int ActivityId)
        {
            SqlParameter activityIdParameter = new SqlParameter("@EActivityID", ActivityId);
            return GetTable("ActivityEvaluationSkillsGetByActivityId", activityIdParameter);
        }
        #endregion

        #region ActivityEvaluationMissionsMethods
        public void ActivityEvaluationMissionsDeleteByEvaluationId(int EvaluationId, SqlTransaction transactionInstance)
        {
            SqlParameter idParameter = new SqlParameter("@EvalutionId", EvaluationId);
            try
            {
                ExecuteNonQuery("ActivityEvaluationMissionsDeleteByEvaluationId", idParameter, transactionInstance);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("There is data in the database related to this activity. This activity cannot be deleted.");
                }
                else
                    throw ex;
            }

        }
        public int InsertActivityEvaluationMissions(ActivityEvaluationMission ActivityEvaluationMission, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@EMissionID", ActivityEvaluationMission.EMissionID));
            parameters.Add(new SqlParameter("@EMissionLevel", ActivityEvaluationMission.EMissionLevel));
            parameters.Add(new SqlParameter("@EMissionComments", ActivityEvaluationMission.EMissionComments));
            parameters.Add(new SqlParameter("@EvaluationID", ActivityEvaluationMission.EvaluationID));
            if (ActivityEvaluationMission.EDepartmentID == null)
                parameters.Add(new SqlParameter("@EdepartmentID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EDepartmentID", ActivityEvaluationMission.EDepartmentID));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("ActivityEvaluationMissionsInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_Activities_ActivityName"
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }
        public DataTable ActivityEvaluationMissionsGetByActivityId(int ActivityId)
        {
            SqlParameter activityIdParameter = new SqlParameter("@EActivityID", ActivityId);
            return GetTable("ActivityEvaluationMissionsGetByActivityId", activityIdParameter);
        }
        #endregion

        #region Activity Reporting Methods
        public Activity GetFirstActivityByVolunteerId(int VolunteerId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter volunterIdParameter = new SqlParameter("@VolunteerId", VolunteerId);
                reader = ExecuteReader("ActivitiesGetFirstActivityByVolunteerId", volunterIdParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;
                int activityIdOrdinal = reader.GetOrdinal("ActivityID");
                int activityCodeNoOrdinal = reader.GetOrdinal("ActivityCodeNo");
                int activityNameOrdinal = reader.GetOrdinal("ActivityName");
                int activityRequestDateOrdinal = reader.GetOrdinal("ActivityRequestDate");
                int activityFieldIDOrdinal = reader.GetOrdinal("ActivityFieldID");
                int activityDateFromOrdinal = reader.GetOrdinal("ActivityDateFrom");
                int activityDateToOrdinal = reader.GetOrdinal("ActivityDateTo");
                int activityDetailsOrdinal = reader.GetOrdinal("ActivityDetails");
                int activityRequirmentsOrdinal = reader.GetOrdinal("ActivityRequirments");
                int activityPlaceIDOrdinal = reader.GetOrdinal("ActivityPlaceID");
                int activityDocumentOrdinal = reader.GetOrdinal("ActivityDocument");
                int activityCostOrdinal = reader.GetOrdinal("ActivityCost");
                int activityRevenueOrdinal = reader.GetOrdinal("ActivityRevenue");
                int activityEntryDateOrdinal = reader.GetOrdinal("ActivityEntryDate");
                int activityEntryUserIDOrdinal = reader.GetOrdinal("ActivityEntryUserID");
                int activityEvaluatorIDOrdinal = reader.GetOrdinal("ActivityEvaluatorID");
                int activityRequiredVolunteersOrdinal = reader.GetOrdinal("ActivityRequiredVolunteers");
                int activityCommentsOrdinal = reader.GetOrdinal("ActivityComments");
                int activityDepartmentOpinionOrdinal = reader.GetOrdinal("ActivityDepartmentOpinion");
                int activityVolunteerDepartmentOpinionOrdinal = reader.GetOrdinal("ActivityVolunteerDepartmentOpinion");

                reader.Read();
                Activity activityInstance = new Activity();

                activityInstance.ActivityID = reader.GetInt32(activityIdOrdinal);

                if (reader.IsDBNull(activityCodeNoOrdinal))
                    activityInstance.ActivityCodeNo = null;
                else
                    activityInstance.ActivityCodeNo = reader.GetInt32(activityCodeNoOrdinal);

                activityInstance.ActivityName = reader.GetString(activityNameOrdinal);

                if (reader.IsDBNull(activityRequestDateOrdinal))
                    activityInstance.ActivityRequestDate = null;
                else
                activityInstance.ActivityRequestDate = reader.GetDateTime(activityRequestDateOrdinal);

                activityInstance.ActivityFieldID = reader.GetInt32(activityFieldIDOrdinal);
                activityInstance.ActivityDateFrom = reader.GetDateTime(activityDateFromOrdinal);
                activityInstance.ActivityDateTo = reader.GetDateTime(activityDateToOrdinal);
                activityInstance.ActivityDetails = reader.GetString(activityDetailsOrdinal);
                activityInstance.ActivityRequirments = reader.GetString(activityRequirmentsOrdinal);

                if (reader.IsDBNull(activityPlaceIDOrdinal))
                    activityInstance.ActivityPlaceID = null;
                else
                    activityInstance.ActivityPlaceID = reader.GetInt32(activityPlaceIDOrdinal);

                if (reader.IsDBNull(activityDocumentOrdinal))
                    activityInstance.ActivityDocument = null;
                else
                    activityInstance.ActivityDocument = reader.GetString(activityDocumentOrdinal);

                if (reader.IsDBNull(activityCostOrdinal))
                    activityInstance.ActivityCost = null;
                else
                    activityInstance.ActivityCost = reader.GetInt32(activityCostOrdinal);

                if (reader.IsDBNull(activityRevenueOrdinal))
                    activityInstance.ActivityRevenue = null;
                else
                    activityInstance.ActivityRevenue = reader.GetInt32(activityRevenueOrdinal);

                activityInstance.ActivityEntryDate = reader.GetDateTime(activityEntryDateOrdinal);
                activityInstance.ActivityEntryUserID = reader.GetInt32(activityEntryUserIDOrdinal);
                activityInstance.ActivityEvaluatorID = reader.GetInt32(activityEvaluatorIDOrdinal);

                if (reader.IsDBNull(activityRequiredVolunteersOrdinal))
                    activityInstance.ActivityRequiredVolunteers = null;
                else
                    activityInstance.ActivityRequiredVolunteers = reader.GetInt32(activityRequiredVolunteersOrdinal);

                if (reader.IsDBNull(activityCommentsOrdinal))
                    activityInstance.ActivityComments = null;
                else
                    activityInstance.ActivityComments = reader.GetString(activityCommentsOrdinal);

                if (reader.IsDBNull(activityDepartmentOpinionOrdinal))
                    activityInstance.ActivityDepartmentOpinion = null;
                else
                    activityInstance.ActivityDepartmentOpinion = reader.GetString(activityDepartmentOpinionOrdinal);

                if (reader.IsDBNull(activityVolunteerDepartmentOpinionOrdinal))
                    activityInstance.ActivityVolunteerDepartmentOpinion = null;
                else
                    activityInstance.ActivityVolunteerDepartmentOpinion = reader.GetString(activityVolunteerDepartmentOpinionOrdinal);

                return activityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public DataTable GetActivityResultByVolunteerId(int VolunteerId)
        {
            SqlParameter volunteerIdParameter = new SqlParameter("@VolunteerId", VolunteerId);
            return GetTable("ActivityResultGetByVolunteerId", volunteerIdParameter);
        }
        #endregion
    }
}
