using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataAccessLayer;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class EducationManager:DatabaseManager
    {
        public DataTable GetAllEducations()
        {
            return GetTable("EducationsGetAll");
        }


        public int InsertEducation(Education newEducation)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@EducationName", newEducation.EducationName));

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
                ExecuteNonQuery("EducationInsert", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Educations"))
                {
                    throw new Exception("المؤهل \"" + newEducation.EducationName + "\" تم تسجيله من قبل");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }


        public void UpdateEducation(Education updatedEducation)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@EducationID", updatedEducation.EducationID));

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@EducationName", updatedEducation.EducationName));
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
                ExecuteNonQuery("EducationUpdate", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Educations"))
                {
                    throw new Exception("المؤهل  \"" + updatedEducation.EducationName + "\" موجود بالفعل من قبل. برجاء إدخال إسم جديد");
                }
                else
                    throw exceptionInstance;
            }

        }

        public void DeleteEducation(int EducationID)
        {
            SqlParameter idParameter = new SqlParameter("@EducationID", EducationID);
            try
            {
                ExecuteNonQuery("EducationDelete", idParameter);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("UK_FBV_Tbl_Educations"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("لا يمكنك حذف المؤهل لأنه مرتبط به متطوعين");
                }
                else
                    throw ex;
            }
        }



        public Education GetEducationByEducationName(string EducationName)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@EducationName", EducationName);
                reader = ExecuteReader("EducationGetByEducationName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int educationIDOrdinal = reader.GetOrdinal("EducationID");
               

                reader.Read();
                Education  educationInstance = new Education  ();


                educationInstance.EducationID = reader.GetInt32(educationIDOrdinal);

                educationInstance.EducationName  = EducationName ;

                return educationInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public Education GetEducationByEducationId(int EducationId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@EducationId", EducationId);
                reader = ExecuteReader("EducationGetByEducationId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int educationNameOrdinal = reader.GetOrdinal("EducationName");


                reader.Read();
                Education educationInstance = new Education();


                educationInstance.EducationID = EducationId;

                educationInstance.EducationName = reader.GetString (educationNameOrdinal);

                return educationInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

    }
}
