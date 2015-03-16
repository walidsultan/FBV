using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class SkillsManager : DatabaseManager
    {
        #region Skills Main  Methods
        public DataTable GetAllSkills()
        {
            return GetTable("SkillsGetAll");
        }

        public Skill GetSkillById(int SkillId)
        {
              SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@SkillID", SkillId );
                reader = ExecuteReader("SkillsGetBySkillId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int skillNameOrdinal = reader.GetOrdinal("SkillName");
                int skillIDOrdinal = reader.GetOrdinal("SkillID");

                reader.Read();
                Skill  skillInstance = new Skill();

                skillInstance.SkillID  = SkillId ;
                skillInstance.SkillName = reader.GetString(skillNameOrdinal );

                return skillInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        #endregion

        #region Skills Volunteer Methods
        public DataTable GetVolunteerSkillsByVolunteerId(int VolunteerId)
        {
            SqlParameter idParameter = new SqlParameter("@VolunteerID", VolunteerId);
            return GetTable("SkillVolunteersGetByVolunteerId", idParameter);
        }

       public void InsertSkillVolunteer(int SkillId, int VolunteerId,SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@VolunteerID", VolunteerId));
            parameters.Add(new SqlParameter("@SkillID", SkillId));

            try
            {
                ExecuteNonQuery("SkillVolunteersInsert", parameters, transactionInstance);
            }
            catch
            {
                throw;
            }
        }

       public void DeleteVolunteerSkillsByVolunteerId(int VolunteerId, SqlTransaction transactionInstance)
        {

            SqlParameter idParameter = new SqlParameter("@VolunteerId", VolunteerId);

            try
            {
                ExecuteNonQuery("SkillVolunteersDeleteByVolunteerId", idParameter, transactionInstance);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
