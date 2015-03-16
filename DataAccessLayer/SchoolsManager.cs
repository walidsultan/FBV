using System;
using System.Collections.Generic;
using System.Text;
using FBV.DataMapping;
using System.Data;
using System.Data.SqlClient;
namespace FBV.DataAccessLayer
{
    public class SchoolsManager : DatabaseManager
    {
        public School GetSchoolBySchoolID(int schoolId)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@SchoolId", schoolId);
                reader = ExecuteReader("SchoolsGetBySchoolId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int schoolIdOrdinal = reader.GetOrdinal("SchoolId");
                int schoolNameOrdinal = reader.GetOrdinal("SchoolName");

                reader.Read();
                School schoolInstance = new School();

                schoolInstance.SchoolId = schoolId;
                schoolInstance.SchoolName = reader.GetString(schoolNameOrdinal);

                return schoolInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public School GetSchoolBySchoolName(string SchoolName)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@SchoolName", SchoolName);
                reader = ExecuteReader("SchoolsGetBySchoolName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int schoolIdOrdinal = reader.GetOrdinal("SchoolId");
                int schoolNameOrdinal = reader.GetOrdinal("SchoolName");

                reader.Read();
                School schoolInstance = new School();

                schoolInstance.SchoolId = reader.GetInt32(schoolIdOrdinal);
                schoolInstance.SchoolName = SchoolName;

                return schoolInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public School GetSchoolBySchoolName(string SchoolName, SqlTransaction transactionInstance)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@SchoolName", SchoolName);
                reader = ExecuteReader("SchoolsGetBySchoolName", nameParameter,transactionInstance );

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int schoolIdOrdinal = reader.GetOrdinal("SchoolId");
                int schoolNameOrdinal = reader.GetOrdinal("SchoolName");

                reader.Read();
                School schoolInstance = new School();

                schoolInstance.SchoolId = reader.GetInt32(schoolIdOrdinal);
                schoolInstance.SchoolName = SchoolName;

                return schoolInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public DataTable GetAllSchools()
        {
            return GetTable("SchoolsGetAll");
        }

        public int InsertSchool(School SchoolInstance,SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SchoolName", SchoolInstance.SchoolName));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("SchoolsInsert", parameters,transactionInstance );
            }
            catch (SqlException exceptionInstance)
            {
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }


    }
}
