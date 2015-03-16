using System;
using System.Collections.Generic;
using System.Text;
using FBV.DataMapping;
using System.Data;
using System.Data.SqlClient;
namespace FBV.DataAccessLayer
{
    public class FacUniversitiesManager:DatabaseManager
    {
       
        public DataTable GetAllFacUniversities()
        {
            return GetTable("FacUniversityGetAll");
        }

        public FacUniversity  GetFacUniversityByUniversityId(int UniversityID)
        {
            SqlDataReader reader = null;
            try
            {
                //List<SqlParameter> parameters = new List<SqlParameter>();
                //parameters.Add(new SqlParameter("@UniversityId",UniversityID));
                //parameters.Add(new SqlParameter("@otherparameter",otherpaarametervalue));


                SqlParameter idParameter = new SqlParameter("@UniversityId", UniversityID);
                reader = ExecuteReader("FacUniversityGetByUniversityID",idParameter);
               
                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int universityNameOrdinal = reader.GetOrdinal("UniversityName");
                


                reader.Read();
                FacUniversity facUniversityInstance = new FacUniversity();

                //if UniversityName doesn't allow null
                facUniversityInstance.UniversityName = reader.GetString(universityNameOrdinal);
                
                //if Universityname allow null
                //if (reader.IsDBNull(universityNameOrdinal))
                //    facUniversityInstance.UniversityName  = null;
                //else
                //    facUniversityInstance.UniversityName = reader.GetString(universityNameOrdinal);

                facUniversityInstance.UniversityID  = UniversityID ;

                return facUniversityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public FacUniversity GetFacUniversityByUniversityName(string UniversityName)
        {
            SqlDataReader reader = null;
            try
            {

                SqlParameter nameParameter = new SqlParameter("@UniversityName", UniversityName);
                reader = ExecuteReader("FacUniversityGetByUniversityName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int universityIdOrdinal = reader.GetOrdinal("UniversityID");



                reader.Read();
                FacUniversity facUniversityInstance = new FacUniversity();

                //if UniversityName doesn't allow null
                facUniversityInstance.UniversityID = reader.GetInt32(universityIdOrdinal);

                facUniversityInstance.UniversityName = UniversityName;

                return facUniversityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public FacUniversity GetFacUniversityByUniversityName(string UniversityName, SqlTransaction transactionInstance)
        {
            SqlDataReader reader = null;
            try
            {

                SqlParameter nameParameter = new SqlParameter("@UniversityName", UniversityName);
                reader = ExecuteReader("FacUniversityGetByUniversityName", nameParameter,transactionInstance );

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int universityIdOrdinal = reader.GetOrdinal("UniversityID");



                reader.Read();
                FacUniversity facUniversityInstance = new FacUniversity();

                //if UniversityName doesn't allow null
                facUniversityInstance.UniversityID = reader.GetInt32(universityIdOrdinal);

                facUniversityInstance.UniversityName  = UniversityName ;

                return facUniversityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public int InsertFacUniversity(FacUniversity newFacUniversity, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@UniversityName", newFacUniversity.UniversityName ));
           
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
                ExecuteNonQuery("FacUniversityInsert", parameters,transactionInstance );
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_Fac_University_Name"))
                {
                    throw new Exception("الجامعة \"" + newFacUniversity.UniversityName + "\" تم تسجيلها من قبل");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }
        public int InsertFacUniversity(FacUniversity newFacUniversity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@UniversityName", newFacUniversity.UniversityName));

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
                ExecuteNonQuery("FacUniversityInsert", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_Fac_University_Name"))
                {
                    throw new Exception("الجامعة \"" + newFacUniversity.UniversityName + "\" تم تسجيلها من قبل");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }
        public void UpdateFacUniversity(FacUniversity updatedFacUniversity)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UniversityID", updatedFacUniversity.UniversityID ));

            //if UniversityName allows null
            parameters.Add(new SqlParameter("@UniversityName", updatedFacUniversity.UniversityName));
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
                ExecuteNonQuery("FacUniversityUpdate", parameters);
            }
            catch (SqlException exceptionInstance)
            {
                //We should create a unique key in the database with name "UK_Fac_University_Name"

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_Fac_University_Name"))
                {
                    throw new Exception("The university name you entered \"" + updatedFacUniversity.UniversityName + "\" already exist. Please insert another university name.");
                }
                else
                    throw exceptionInstance;
            }
            
        }

        public void DeleteFacUniversity(int UniversityID)
        {
            SqlParameter idParameter = new SqlParameter("@UniversityID", UniversityID);
            try
            {
                ExecuteNonQuery("FacUniversityDelete", idParameter);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("There is data in the database related to this University. This user cannot be deleted.");
                }
                else
                    throw ex;
            }
        }

    }
}
