using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
   public  class EduFacultiesManager:DatabaseManager 
    {
         /// <summary>
        /// Gets all faculties.
        /// </summary>
        /// <returns></returns>
         public DataTable GetAllFaculties()
       {
           return GetTable("EduFacultyGetAll");
       }

         /// <summary>
       /// Gets the faculties by university id.
       /// </summary>
       /// <param name="UniversityId">The university id.</param>
       /// <returns></returns>
         public DataTable GetFacultiesByUniversityId(int UniversityId)
       {
             SqlParameter idParameter=new SqlParameter("@FUniversityID",UniversityId);
           return GetTable("EduFacultiesGetByUniversityID",idParameter );
       }

         /// <summary>
         /// Gets the faculty by id.
         /// </summary>
         /// <param name="FacultyId">The faculty id.</param>
         /// <returns></returns>
         public EduFaculty GetFacultyById(int FacultyId)
         {
             SqlDataReader reader = null;
             try
             {
                 SqlParameter idParameter = new SqlParameter("@FacultyId", FacultyId);
                 reader = ExecuteReader("EduFacultiesGetByFacultyId", idParameter);

                 if (!reader.HasRows)
                     // if there is no entry with the given id
                     return null;

                 int facultyNameOrdinal = reader.GetOrdinal("FacultyName");
                 int fUniversityIdOrdinal = reader.GetOrdinal("FUniversityID");

                 reader.Read();
                 EduFaculty eduFacultyInstance = new EduFaculty();

                 //if UniversityName doesn't allow null
                 eduFacultyInstance.FacultyName = reader.GetString(facultyNameOrdinal);
                 eduFacultyInstance.FUniversityID = reader.GetInt32(fUniversityIdOrdinal);

                 eduFacultyInstance.FacultyID = FacultyId;

                 return eduFacultyInstance;
             }
             finally
             {
                 if ((reader != null) && (!reader.IsClosed))
                     reader.Close();
             }
         }

         public int InsertFaculty(EduFaculty newFaculty, SqlTransaction transactionInstance)
         {
             List<SqlParameter> parameters = new List<SqlParameter>();

             //if UniversityName allows null
             parameters.Add(new SqlParameter("@FacultyName", newFaculty.FacultyName));
             parameters.Add(new SqlParameter("@FUniversityID", newFaculty.FUniversityID));

             //if UniversityName doesn't allow null
             //if (newFaculty .UniversityName ==null )
             //  parameters.Add(new SqlParameter("@UniversityName", DBNull.Value));
             //else
             //  parameters.Add(new SqlParameter("@UniversityName", newFaculty.UniversityName ));

             SqlParameter returnedIdParameter = new SqlParameter();
             returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
             returnedIdParameter.DbType = System.Data.DbType.Int32;
             parameters.Add(returnedIdParameter);

             try
             {
                 ExecuteNonQuery("FacultyInsert", parameters,transactionInstance );
             }
             catch (SqlException exceptionInstance)
             {
                 //We should create a unique key in the database with name "UK_Fac_University_Name"

                 //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                 ////if (exceptionInstance.Message.Contains("UK_Fac_University_Name"))
                 ////{
                 ////    throw new Exception("الجامعة \"" + newFaculty.UniversityName + "\" تم تسجيلها من قبل");
                 ////}
                 ////else
             throw exceptionInstance;
             }
             return (int)returnedIdParameter.Value;
         }

         public int InsertFaculty(EduFaculty newFaculty)
         {
             List<SqlParameter> parameters = new List<SqlParameter>();

             //if UniversityName allows null
             parameters.Add(new SqlParameter("@FacultyName", newFaculty.FacultyName));
             parameters.Add(new SqlParameter("@FUniversityID", newFaculty.FUniversityID));

             //if UniversityName doesn't allow null
             //if (newFaculty .UniversityName ==null )
             //  parameters.Add(new SqlParameter("@UniversityName", DBNull.Value));
             //else
             //  parameters.Add(new SqlParameter("@UniversityName", newFaculty.UniversityName ));

             SqlParameter returnedIdParameter = new SqlParameter();
             returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
             returnedIdParameter.DbType = System.Data.DbType.Int32;
             parameters.Add(returnedIdParameter);

             try
             {
                 ExecuteNonQuery("FacultyInsert", parameters);
             }
             catch (SqlException exceptionInstance)
             {
                 //We should create a unique key in the database with name "UK_Fac_University_Name"

                 //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                 ////if (exceptionInstance.Message.Contains("UK_Fac_University_Name"))
                 ////{
                 ////    throw new Exception("الجامعة \"" + newFaculty.UniversityName + "\" تم تسجيلها من قبل");
                 ////}
                 ////else
                 throw exceptionInstance;
             }
             return (int)returnedIdParameter.Value;
         }

         /// <summary>
         /// Gets the name of the faculty by faculty name.
         /// </summary>
         /// <param name="FacultyName">Name of the faculty.</param>
         /// <returns></returns>
         public EduFaculty GetFacultyByFacultyNameAndUniversityId(string FacultyName,int UniversityId)
         {
             SqlDataReader reader = null;
             try
             {
                 List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add( new SqlParameter("@FacultyName", FacultyName));
                    parameters.Add(new SqlParameter("@FUniversityID", UniversityId));
                    reader = ExecuteReader("EduFacultiesGetByFacultyNameAndUniversityId", parameters);

                 if (!reader.HasRows)
                     // if there is no entry with the given id
                     return null;

                 int facultyIdOrdinal = reader.GetOrdinal("FacultyID");

                 reader.Read();
                 EduFaculty eduFacultyInstance = new EduFaculty();

                
                 eduFacultyInstance.FacultyID = reader.GetInt32(facultyIdOrdinal);
                 eduFacultyInstance.FUniversityID = UniversityId ;

                 eduFacultyInstance.FacultyName  = FacultyName ;

                 return eduFacultyInstance;
             }
             finally
             {
                 if ((reader != null) && (!reader.IsClosed))
                     reader.Close();
             }
         }

         public EduFaculty GetFacultyByFacultyNameAndUniversityId(string FacultyName, int UniversityId, SqlTransaction transactionInstance)
         {
             SqlDataReader reader = null;
             try
             {
                 List<SqlParameter> parameters = new List<SqlParameter>();
                 parameters.Add(new SqlParameter("@FacultyName", FacultyName));
                 parameters.Add(new SqlParameter("@FUniversityID", UniversityId));
                 reader = ExecuteReader("EduFacultiesGetByFacultyNameAndUniversityId", parameters, transactionInstance);

                 if (!reader.HasRows)
                     // if there is no entry with the given id
                     return null;

                 int facultyIdOrdinal = reader.GetOrdinal("FacultyID");

                 reader.Read();
                 EduFaculty eduFacultyInstance = new EduFaculty();


                 eduFacultyInstance.FacultyID = reader.GetInt32(facultyIdOrdinal);
                 eduFacultyInstance.FUniversityID = UniversityId;

                 eduFacultyInstance.FacultyName = FacultyName;

                 return eduFacultyInstance;
             }
             finally
             {
                 if ((reader != null) && (!reader.IsClosed))
                     reader.Close();
             }
         }
    }
}
