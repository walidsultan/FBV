using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;

namespace FBV.DataAccessLayer
{
    public class JobPlacesManager:DatabaseManager
    {
        public DataTable GetAllJobPlaces()
        {
            return GetTable("JobPlacesGetAll");
        }

        public JobPlace GetJobPlaceByJobPlaceId(int jobPlaceId)
        { 

            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@JobPlaceID", jobPlaceId);
                reader = ExecuteReader("JobPlacesGetByJobPlaceID", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int jobPlaceNameOrdinal = reader.GetOrdinal("JobPlaceName");


                reader.Read();
                JobPlace jobPlaceNameInstance = new JobPlace();

                jobPlaceNameInstance.JobPlaceID  = jobPlaceId ;

                jobPlaceNameInstance.JobPlaceName  = reader.GetString(jobPlaceNameOrdinal ); 

                return jobPlaceNameInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public int InsertJobPlace(JobPlace newJobPlace)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@JobPlaceName", newJobPlace.JobPlaceName));

            //if UniversityName doesn't allow null
            //if (newFacUniversity .UniversityName ==null )
            //  parameters.Add(new SqlParameter("@UniversityName", DBNull.Value));
            //else
            //  parameters.Add(new SqlParameter("@UniversityName", newFacUniversity.UniversityName ));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("JobPlaceInsert", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_JobPlaces"))
                {
                    throw new Exception("المؤسسة \"" + newJobPlace.JobPlaceName + "\" تم تسجيلها من قبل");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        public JobPlace GetJobPlaceByJobPlaceName(string JobPlaceName)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@JobPlaceName", JobPlaceName);
                reader = ExecuteReader("JobPlacesGetByJobPlaceName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int jobPlaceIDOrdinal = reader.GetOrdinal("JobPlaceID");


                reader.Read();
                JobPlace jobPlaceInstance = new JobPlace();


                jobPlaceInstance.JobPlaceID = reader.GetInt32(jobPlaceIDOrdinal);

                jobPlaceInstance.JobPlaceName  = JobPlaceName ;

                return jobPlaceInstance ;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public void DeleteJobPlace(int JobPlaceID)
        {
            SqlParameter idParameter = new SqlParameter("@JobPlaceID", JobPlaceID);
            try
            {
                ExecuteNonQuery("JobPlaceDelete", idParameter);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_FBV_Tbl_JobPlaces"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("لا يمكنك حذف المؤسسة لأنها مرتبط بها متطوعين");
                }
                else
                    throw ex;
            }
        }

        public void UpdateJobPlace(JobPlace updatedJobPlace)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@JobPlaceID", updatedJobPlace.JobPlaceID));

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@JobPlaceName", updatedJobPlace.JobPlaceName));
            //if UniversityName doesn't allow null
            //if (updatedFacUniversity .UniversityName ==null )
            //  parameters.Add(new SqlParameter("@UniversityName", DBNull.Value));
            //else
            //  parameters.Add(new SqlParameter("@UniversityName", updatedFacUniversity.UniversityName ));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("JobPlaceUpdate", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_JobPlaces"))
                {
                    throw new Exception("المؤسسة  \"" + updatedJobPlace.JobPlaceName + "\" موجودة بالفعل من قبل. برجاء إدخال إسم جديد");
                }
                else
                    throw exceptionInstance;
            }

        }
    }

}
