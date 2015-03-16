using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class LanguagesManager : DatabaseManager
    {
        #region Language Main  Methods
        public DataTable GetAllLanguages()
        {
            return GetTable("LanguagesGetAll");
        }
        #endregion

        public Language  GetLanguageByLanguageId(int languageId)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@LanguageID", languageId);
                reader = ExecuteReader("LanguagesGetByLanguageId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int languageNameOrdinal = reader.GetOrdinal("LanguageName");


                reader.Read();
                Language languageInstance = new Language();

                languageInstance.LanguageID  = languageId ;

                languageInstance.LanguageName = reader.GetString(languageNameOrdinal);

                return languageInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        #region Language Volunteer Methods
        public DataTable GetVolunteerLanguagesByVolunteerId(int VolunteerId)
        {
            SqlParameter idParameter = new SqlParameter("@VolunteerID", VolunteerId);
            return GetTable("LangVolunteersGetByVolunteerId", idParameter);
        }

        public void InsertLanguageVolunteer(int LanguageId, int VolunteerId, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@VolunteerID",VolunteerId));
            parameters.Add(new SqlParameter("@LanguageID",LanguageId ));

            try
            {
                ExecuteNonQuery("LangVolunteersInsert", parameters, transactionInstance);
            }
            catch 
            {
                throw ;
            }
        }

        public void DeleteVolunteerLanguagesByVolunteerId(int VolunteerId, SqlTransaction transactionInstance)
        {

            SqlParameter idParameter = new SqlParameter("@VolunteerId", VolunteerId);

            try
            {
                ExecuteNonQuery("LangVolunteersDeleteByVolunteerId", idParameter, transactionInstance);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
