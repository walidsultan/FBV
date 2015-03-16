using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class MissionsManager:DatabaseManager 
    {
        #region MissionsMainMethods
         public DataTable GetAllMissions()
        {
            return GetTable("MissionsGetAll");
         }
        public DataTable GetMissionsByFieldId(int FieldId)
        {
            SqlParameter FieldIdParamter = new SqlParameter("@FieldId", FieldId);
            return GetTable("MissionsGetByFieldId", FieldIdParamter);
        }

        public Mission GetMissionByMissionId(int MissionId)
        { 
          SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@MissionID", MissionId );
                reader = ExecuteReader("MissionsGetByMissionId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int missionNameOrdinal = reader.GetOrdinal("MissionName");
                int fieldIdOrdinal = reader.GetOrdinal("FieldID");

                reader.Read();
                Mission  missionInstance = new Mission();

                missionInstance.MissionID   = MissionId ;
                missionInstance.MissionName  = reader.GetString(missionNameOrdinal);
                missionInstance.FieldID  = reader.GetInt32 (fieldIdOrdinal);

                return missionInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
#endregion

        #region MissionResultMethods
        public DataTable GetResultMissionsByResultId(int resultId)
        {
            SqlParameter idParameter = new SqlParameter("@ResultID", resultId);
            return GetTable("ResultMissionGetByResultId", idParameter);
        }

        #endregion

        #region MissionResultRealMethods
        public DataTable GetResultRealMissionsByResultId(int resultId)
        {
            SqlParameter idParameter = new SqlParameter("@ResultID", resultId);
            return GetTable("ResultRealMissionGetByResultId", idParameter);
        }

        #endregion
    }
}
