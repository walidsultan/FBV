using System;

using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class FieldsManager : DatabaseManager
    {
        #region Fields Main Methods
        /// <summary>
        /// Gets all fields.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllFields()
        {
            return GetTable("FieldsGetAll");
        }
        public Field GetFieldByFieldName(string FieldName, SqlTransaction transactionInstance)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@FieldName", FieldName);
                reader = ExecuteReader("FieldsGetByFieldName", nameParameter, transactionInstance);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int fieldIDOrdinal = reader.GetOrdinal("FieldID");


                reader.Read();
                Field fieldInstance = new Field();


                fieldInstance.FieldID = reader.GetInt32(fieldIDOrdinal);

                fieldInstance.FieldName = FieldName;

                return fieldInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public Field GetFieldByFieldId(int FieldId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@FieldId", FieldId);
                reader = ExecuteReader("FieldsGetByFieldId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int fieldNameOrdinal = reader.GetOrdinal("FieldName");


                reader.Read();
                Field fieldInstance = new Field();


                fieldInstance.FieldID = FieldId;

                fieldInstance.FieldName = reader.GetString(fieldNameOrdinal); ;

                return fieldInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        #endregion

        #region FieldVolWork Methods
        public void InsertFieldVolunteerWork(int FieldId, int VolunteerId, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@FieldWorkID", FieldId));
            parameters.Add(new SqlParameter("@VolunteerID", VolunteerId));

            try
            {
                ExecuteNonQuery("FieldVolWorkInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {

                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Field_Vol_Work"))
                {
                    throw new Exception("This field is already assigned to that volunteer");
                }
                else
                    throw exceptionInstance;
            }

        }
        public FieldVolunteerWork GetFieldVolunteerWorkByVolunteerIdAndFieldId(int VolunteerId, int FieldId, SqlTransaction transactionInstance)
        {
            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@VolunteerID", VolunteerId));
                parameters.Add(new SqlParameter("@FieldWorkID", FieldId));
                reader = ExecuteReader("FieldVolWorkGetByVolunteerIdAndFieldId", parameters, transactionInstance);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;


                FieldVolunteerWork fieldVolunteerInstance = new FieldVolunteerWork();


                fieldVolunteerInstance.FieldWorkID = FieldId;

                fieldVolunteerInstance.VolunteerID = VolunteerId;

                return fieldVolunteerInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }
        public void DeleteFieldVolunteerWorkByVolunteerId(int VolunteerId)
        {
            try
            {
                SqlParameter idParameter = new SqlParameter("@VolunteerId", VolunteerId);
                ExecuteNonQuery("FieldVolWorkDeleteByVolunteerId", idParameter);
            }
            catch
            {
                throw;
            }
        }
        public DataTable GetAllFieldVolunteerWorkByVolunteerId(int VolunteerId)
        {
            SqlParameter idParameter = new SqlParameter("@VolunteerID", VolunteerId);
            return GetTable("FieldVolWorkGetByVolunteerId", idParameter);
        }
        #endregion

        #region FieldVolDesired Methods
        public void DeleteFieldVolunteerDesiredByVolunteerId(int VolunteerId)
        {
            try
            {
                SqlParameter idParameter = new SqlParameter("@VolunteerId", VolunteerId);
                ExecuteNonQuery("FieldVolDesiredDeleteByVolunteerId", idParameter);
            }
            catch
            {
                throw;
            }
        }
        public void InsertFieldVolunteerDesired(int FieldId, int VolunteerId, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@FieldDesiredID", FieldId));
            parameters.Add(new SqlParameter("@VolunteerID", VolunteerId));

            try
            {
                ExecuteNonQuery("FieldVolDesiredInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {

                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Field_Vol_Work"))
                {
                    throw new Exception("This field is already assigned to that volunteer");
                }
                else
                    throw exceptionInstance;
            }

        }
        public FieldVolunteerWork GetFieldVolunteerDesiredByVolunteerIdAndFieldId(int VolunteerId, int FieldId, SqlTransaction transactionInstance)
        {
            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@VolunteerID", VolunteerId));
                parameters.Add(new SqlParameter("@FieldWorkID", FieldId));
                reader = ExecuteReader("FieldVolDesiredGetByVolunteerIdAndFieldId", parameters, transactionInstance);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;


                FieldVolunteerWork fieldVolunteerInstance = new FieldVolunteerWork();


                fieldVolunteerInstance.FieldWorkID = FieldId;

                fieldVolunteerInstance.VolunteerID = VolunteerId;

                return fieldVolunteerInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }
        public DataTable GetAllFieldVolunteerDesiredByVolunteerId(int VolunteerId)
        {
            SqlParameter idParameter = new SqlParameter("@VolunteerID", VolunteerId);
            return GetTable("FieldVolDesiredGetByVolunteerId", idParameter);
        }
        #endregion
    }
}
