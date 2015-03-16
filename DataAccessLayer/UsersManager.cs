using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class UsersManager:DatabaseManager 
    {
        /// <summary>
        /// Gets the users by department id.
        /// </summary>
        /// <param name="DepartmentId">The department id.</param>
        /// <returns></returns>
        public DataTable GetUsersByDepartmentId(int DepartmentId)
        { 
            SqlParameter departmentIdParameter=new SqlParameter("@UDerpartmentID",DepartmentId);
            return GetTable("UsersgetByDepartmentId", departmentIdParameter);
        }

        /// <summary>
        /// Gets the users by department id and evaluation.
        /// </summary>
        /// <param name="DepartmentId">The department id.</param>
        /// <param name="Evaluation">if set to <c>true</c> [evaluation].</param>
        /// <returns></returns>
        public DataTable GetUsersByDepartmentIdAndEvaluation(int DepartmentId,bool Evaluation)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add( new SqlParameter("@UDerpartmentID", DepartmentId));
            parameters.Add(new SqlParameter("@UEvaluation", Evaluation));
            return GetTable("UsersgetByDepartmentIdAndEvaluation", parameters);
        }

        /// <summary>
        /// Gets the user by user id.
        /// </summary>
        /// <param name="UserId">The user id.</param>
        /// <returns></returns>
        public User GetUserByUserId(int UserId)
        {
            SqlDataReader reader = null;
            try
            {
               SqlParameter idParameter = new SqlParameter("@UserID", UserId );
                reader = ExecuteReader("UsersgetByUserId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int userIdOrdinal = reader.GetOrdinal("UserID"); 
                int userFullnameOrdinal = reader.GetOrdinal("UserFullname");  
                int usernameOrdinal = reader.GetOrdinal("Username");
                int userPasswordOrdinal = reader.GetOrdinal("UserPassword");
                int uDerpartmentIDOrdinal = reader.GetOrdinal("UDerpartmentID");
                int uAccessLevelOrdinal = reader.GetOrdinal("UAccessLevel");
                int uEvaluationOrdinal = reader.GetOrdinal("UEvaluation");

                reader.Read();
                User  userInstance = new User ();

                userInstance.UserID = UserId;
                userInstance.UserFullname = reader.GetString(userFullnameOrdinal);

                if (reader.IsDBNull(usernameOrdinal))
                    userInstance.Username = null;
                else
                userInstance.Username  = reader.GetString(usernameOrdinal );

                if (reader.IsDBNull(userPasswordOrdinal))
                    userInstance.UserPassword = null;
                else
                userInstance.UserPassword = reader.GetString(userPasswordOrdinal);

                userInstance.UDerpartmentID = reader.GetInt32 (uDerpartmentIDOrdinal);
                userInstance.UAccessLevel = reader.GetInt32(uAccessLevelOrdinal);
                if (reader.IsDBNull(uEvaluationOrdinal))
                    userInstance.UEvaluation = null;
                else
                userInstance.UEvaluation = reader.GetBoolean(uEvaluationOrdinal);

                return userInstance ;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public User GetUserByUserName(string UserName)
        { 
              SqlDataReader reader = null;
            try
            {
               SqlParameter userNameParameter = new SqlParameter("@Username", UserName  );
                reader = ExecuteReader("UsersgetByUserName", userNameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int userIdOrdinal = reader.GetOrdinal("UserID"); 
                int userFullnameOrdinal = reader.GetOrdinal("UserFullname");  
                int usernameOrdinal = reader.GetOrdinal("Username");
                int userPasswordOrdinal = reader.GetOrdinal("UserPassword");
                int uDerpartmentIDOrdinal = reader.GetOrdinal("UDerpartmentID");
                int uAccessLevelOrdinal = reader.GetOrdinal("UAccessLevel");
                int uEvaluationOrdinal = reader.GetOrdinal("UEvaluation");

                reader.Read();
                User  userInstance = new User ();

                userInstance.UserID = reader.GetInt32(userIdOrdinal );
                userInstance.UserFullname = reader.GetString(userFullnameOrdinal);

                if (reader.IsDBNull(usernameOrdinal))
                    userInstance.Username = null;
                else
                userInstance.Username  = reader.GetString(usernameOrdinal );

                if (reader.IsDBNull(userPasswordOrdinal))
                    userInstance.UserPassword = null;
                else
                userInstance.UserPassword = reader.GetString(userPasswordOrdinal);

                userInstance.UDerpartmentID = reader.GetInt32 (uDerpartmentIDOrdinal);
                userInstance.UAccessLevel = reader.GetInt32(uAccessLevelOrdinal);
                if (reader.IsDBNull(uEvaluationOrdinal))
                    userInstance.UEvaluation = null;
                else
                userInstance.UEvaluation = reader.GetBoolean(uEvaluationOrdinal);

                return userInstance ;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }
    }
}
