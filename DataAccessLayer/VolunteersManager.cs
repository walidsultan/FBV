using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class VolunteersManager : DatabaseManager
    {
        /// <summary>
        /// Inserts the volunteer.
        /// </summary>
        /// <param name="newVolunteer">The new volunteer.</param>
        /// <returns></returns>
        public int InsertVolunteer(Volunteer newVolunteer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (newVolunteer.vUsername == null)
                parameters.Add(new SqlParameter("@vUsername", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vUsername", newVolunteer.vUsername));

            if (newVolunteer.vPassword == null)
                parameters.Add(new SqlParameter("@vPassword", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vPassword", newVolunteer.vPassword));

            if (newVolunteer.vReceiveMail == null)
                parameters.Add(new SqlParameter("@vReceiveMail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vReceiveMail", newVolunteer.vReceiveMail));

    
                parameters.Add(new SqlParameter("@VolunteerManID", newVolunteer.VolunteerManID));


            parameters.Add(new SqlParameter("@vName", newVolunteer.vName));

            if (newVolunteer.VGender == null)
                parameters.Add(new SqlParameter("@VGender", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VGender", newVolunteer.VGender));

            if (newVolunteer.vBirthDate == null)
                parameters.Add(new SqlParameter("@vBirthDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vBirthDate", newVolunteer.vBirthDate));

            if (newVolunteer.VSchool == null)
                parameters.Add(new SqlParameter("@VSchool", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VSchool", newVolunteer.VSchool));

            if (newVolunteer.vEducationID == null)
                parameters.Add(new SqlParameter("@vEducationID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEducationID", newVolunteer.vEducationID));

            if (newVolunteer.VFacultyID == null)
                parameters.Add(new SqlParameter("@VFacultyID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VFacultyID", newVolunteer.VFacultyID));

            if (newVolunteer.VCurrentJob == null)
                parameters.Add(new SqlParameter("@VCurrentJob", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VCurrentJob", newVolunteer.VCurrentJob));

            if (newVolunteer.vJobPlaceID == null)
                parameters.Add(new SqlParameter("@vJobPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vJobPlaceID", newVolunteer.vJobPlaceID));

            if (newVolunteer.VAddress == null)
                parameters.Add(new SqlParameter("@VAddress", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VAddress", newVolunteer.VAddress));

            if (newVolunteer.vAreaID == null)
                parameters.Add(new SqlParameter("@vAreaID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vAreaID", newVolunteer.vAreaID));

            if (newVolunteer.vMobile == null)
                parameters.Add(new SqlParameter("@vMobile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMobile", newVolunteer.vMobile));

            if (newVolunteer.vTelephone == null)
                parameters.Add(new SqlParameter("@vTelephone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vTelephone", newVolunteer.vTelephone));

            if (newVolunteer.vEmail == null)
                parameters.Add(new SqlParameter("@vEmail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEmail", newVolunteer.vEmail));

            if (newVolunteer.vXexperience == null)
                parameters.Add(new SqlParameter("@vXexperience", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vXexperience", newVolunteer.vXexperience));

            if (newVolunteer.vComputer == null)
                parameters.Add(new SqlParameter("@vComputer", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputer", newVolunteer.vComputer));

            if (newVolunteer.vComputerSkills == null)
                parameters.Add(new SqlParameter("@vComputerSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputerSkills", newVolunteer.vComputerSkills));

            if (newVolunteer.vKnow == null)
                parameters.Add(new SqlParameter("@vKnow", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnow", newVolunteer.vKnow));

            if (newVolunteer.vKnowWay == null)
                parameters.Add(new SqlParameter("@vKnowWay", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnowWay", newVolunteer.vKnowWay));
            
            if (newVolunteer.vRegisterDate == null)
                parameters.Add(new SqlParameter("@vRegisterDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegisterDate", newVolunteer.vRegisterDate));

            if (newVolunteer.vFirstContactDate == null)
                parameters.Add(new SqlParameter("@vFirstContactDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactDate", newVolunteer.vFirstContactDate));

            if (newVolunteer.vRegistrationPlaceID == null)
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", newVolunteer.vRegistrationPlaceID));

            if (newVolunteer.vMeetingPlaceID == null)
                parameters.Add(new SqlParameter("@vMeetingPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingPlaceID", newVolunteer.vMeetingPlaceID));

            if (newVolunteer.vMeetingDate == null)
                parameters.Add(new SqlParameter("@vMeetingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDate", newVolunteer.vMeetingDate));

            if (newVolunteer.vComingDate == null)
                parameters.Add(new SqlParameter("@vComingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComingDate", newVolunteer.vComingDate));

            if (newVolunteer.vComments == null)
                parameters.Add(new SqlParameter("@vComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComments", newVolunteer.vComments));

            if (newVolunteer.vImage == null)
                parameters.Add(new SqlParameter("@vImage", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vImage", newVolunteer.vImage));

            if (newVolunteer.vCV == null)
                parameters.Add(new SqlParameter("@vCV", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vCV", newVolunteer.vCV));

            if (newVolunteer.vOtherFile == null)
                parameters.Add(new SqlParameter("@vOtherFile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vOtherFile", newVolunteer.vOtherFile));

            if (newVolunteer.RegisterVia == null)
                parameters.Add(new SqlParameter("@RegisterVia", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RegisterVia", newVolunteer.RegisterVia));

            if (newVolunteer.EntryDate == null)
                parameters.Add(new SqlParameter("@EntryDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryDate", newVolunteer.EntryDate));

            if (newVolunteer.EntryUserID == null)
                parameters.Add(new SqlParameter("@EntryUserID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryUserID", newVolunteer.EntryUserID));

            if (newVolunteer.vFirstContactPlaceID == null)
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", newVolunteer.vFirstContactPlaceID));

            if (newVolunteer.vSkills == null)
                parameters.Add(new SqlParameter("@vSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vSkills", newVolunteer.vSkills));

            if (newVolunteer.vMeetingDone == null)
                parameters.Add(new SqlParameter("@vMeetingDone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDone", newVolunteer.vMeetingDone));

            if (newVolunteer.vMeetingApology == null)
                parameters.Add(new SqlParameter("@vMeetingApology", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApology", newVolunteer.vMeetingApology));

            if (newVolunteer.vMeetingApologyDate == null)
                parameters.Add(new SqlParameter("@vMeetingApologyDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApologyDate", newVolunteer.vMeetingApologyDate));

            if (newVolunteer.vMeetingApologyPlace == null)
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", newVolunteer.vMeetingApologyPlace));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("VolunteersInsert", parameters);
            }
            catch (SqlException exceptionInstance)
            {

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Volunteers"))
                {
                    throw new Exception("اسم المتطوع \"" + newVolunteer.vName + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل اسم اخر.");
                }
                else if (exceptionInstance.Message.Contains("Uk_Volunteers_VolunteerManId"))
                {
                    throw new Exception("رقم التعريف \"" + newVolunteer.VolunteerManID + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل رقم تعريف أخر.");
                }
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        /// <summary>
        /// Inserts the volunteer.
        /// </summary>
        /// <param name="newVolunteer">The new volunteer.</param>
        /// <param name="transactionInstance">The transaction instance.</param>
        /// <returns></returns>
        public int InsertVolunteer(Volunteer newVolunteer, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (newVolunteer.vUsername == null)
                parameters.Add(new SqlParameter("@vUsername", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vUsername", newVolunteer.vUsername));

            if (newVolunteer.vPassword == null)
                parameters.Add(new SqlParameter("@vPassword", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vPassword", newVolunteer.vPassword));

            if (newVolunteer.vReceiveMail == null)
                parameters.Add(new SqlParameter("@vReceiveMail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vReceiveMail", newVolunteer.vReceiveMail));


                parameters.Add(new SqlParameter("@VolunteerManID", newVolunteer.VolunteerManID));


            parameters.Add(new SqlParameter("@vName", newVolunteer.vName));

            if (newVolunteer.VGender == null)
                parameters.Add(new SqlParameter("@VGender", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VGender", newVolunteer.VGender));

            if (newVolunteer.vBirthDate == null)
                parameters.Add(new SqlParameter("@vBirthDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vBirthDate", newVolunteer.vBirthDate));

            if (newVolunteer.VSchool == null)
                parameters.Add(new SqlParameter("@VSchool", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VSchool", newVolunteer.VSchool));

            if (newVolunteer.vEducationID == null)
                parameters.Add(new SqlParameter("@vEducationID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEducationID", newVolunteer.vEducationID));

            if (newVolunteer.VFacultyID == null)
                parameters.Add(new SqlParameter("@VFacultyID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VFacultyID", newVolunteer.VFacultyID));

            if (newVolunteer.VCurrentJob == null)
                parameters.Add(new SqlParameter("@VCurrentJob", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VCurrentJob", newVolunteer.VCurrentJob));

            if (newVolunteer.vJobPlaceID == null)
                parameters.Add(new SqlParameter("@vJobPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vJobPlaceID", newVolunteer.vJobPlaceID));

            if (newVolunteer.VAddress == null)
                parameters.Add(new SqlParameter("@VAddress", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VAddress", newVolunteer.VAddress));

            if (newVolunteer.vAreaID == null)
                parameters.Add(new SqlParameter("@vAreaID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vAreaID", newVolunteer.vAreaID));

            if (newVolunteer.vMobile == null)
                parameters.Add(new SqlParameter("@vMobile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMobile", newVolunteer.vMobile));

            if (newVolunteer.vTelephone == null)
                parameters.Add(new SqlParameter("@vTelephone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vTelephone", newVolunteer.vTelephone));

            if (newVolunteer.vEmail == null)
                parameters.Add(new SqlParameter("@vEmail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEmail", newVolunteer.vEmail));

            if (newVolunteer.vXexperience == null)
                parameters.Add(new SqlParameter("@vXexperience", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vXexperience", newVolunteer.vXexperience));

            if (newVolunteer.vComputer == null)
                parameters.Add(new SqlParameter("@vComputer", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputer", newVolunteer.vComputer));

            if (newVolunteer.vComputerSkills == null)
                parameters.Add(new SqlParameter("@vComputerSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputerSkills", newVolunteer.vComputerSkills));

            if (newVolunteer.vKnow == null)
                parameters.Add(new SqlParameter("@vKnow", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnow", newVolunteer.vKnow));

            if (newVolunteer.vKnowWay == null)
                parameters.Add(new SqlParameter("@vKnowWay", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnowWay", newVolunteer.vKnowWay));

            if (newVolunteer.vRegisterDate == null)
                parameters.Add(new SqlParameter("@vRegisterDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegisterDate", newVolunteer.vRegisterDate));

            if (newVolunteer.vFirstContactDate == null)
                parameters.Add(new SqlParameter("@vFirstContactDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactDate", newVolunteer.vFirstContactDate));

            if (newVolunteer.vRegistrationPlaceID == null)
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", newVolunteer.vRegistrationPlaceID));

            if (newVolunteer.vMeetingPlaceID == null)
                parameters.Add(new SqlParameter("@vMeetingPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingPlaceID", newVolunteer.vMeetingPlaceID));

            if (newVolunteer.vMeetingDate == null)
                parameters.Add(new SqlParameter("@vMeetingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDate", newVolunteer.vMeetingDate));

            if (newVolunteer.vComingDate == null)
                parameters.Add(new SqlParameter("@vComingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComingDate", newVolunteer.vComingDate));

            if (newVolunteer.vComments == null)
                parameters.Add(new SqlParameter("@vComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComments", newVolunteer.vComments));

            if (newVolunteer.vImage == null)
                parameters.Add(new SqlParameter("@vImage", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vImage", newVolunteer.vImage));

            if (newVolunteer.vCV == null)
                parameters.Add(new SqlParameter("@vCV", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vCV", newVolunteer.vCV));

            if (newVolunteer.vOtherFile == null)
                parameters.Add(new SqlParameter("@vOtherFile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vOtherFile", newVolunteer.vOtherFile));

            if (newVolunteer.RegisterVia == null)
                parameters.Add(new SqlParameter("@RegisterVia", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RegisterVia", newVolunteer.RegisterVia));

            if (newVolunteer.EntryDate == null)
                parameters.Add(new SqlParameter("@EntryDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryDate", newVolunteer.EntryDate));

            if (newVolunteer.EntryUserID == null)
                parameters.Add(new SqlParameter("@EntryUserID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryUserID", newVolunteer.EntryUserID));

            if (newVolunteer.vFirstContactPlaceID == null)
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", newVolunteer.vFirstContactPlaceID));


            if (newVolunteer.vSkills == null)
                parameters.Add(new SqlParameter("@vSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vSkills", newVolunteer.vSkills));

            if (newVolunteer.vMeetingDone == null)
                parameters.Add(new SqlParameter("@vMeetingDone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDone", newVolunteer.vMeetingDone));

            if (newVolunteer.vMeetingApology == null)
                parameters.Add(new SqlParameter("@vMeetingApology", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApology", newVolunteer.vMeetingApology));

            if (newVolunteer.vMeetingApologyDate == null)
                parameters.Add(new SqlParameter("@vMeetingApologyDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApologyDate", newVolunteer.vMeetingApologyDate));

            if (newVolunteer.vMeetingApologyPlace == null)
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", newVolunteer.vMeetingApologyPlace));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("VolunteersInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Volunteers"))
                {
                    throw new Exception("اسم المتطوع \"" + newVolunteer.vName + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل اسم اخر.");
                }
                else if (exceptionInstance.Message.Contains("Uk_Volunteers_VolunteerManId"))
                {
                    throw new Exception("رقم التعريف \"" + newVolunteer.VolunteerManID + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل رقم تعريف أخر.");
                }
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        /// <summary>
        /// Updates the volunteer.
        /// </summary>
        /// <param name="updatedVolunteer">The updated volunteer.</param>
        /// <returns></returns>
        public int UpdateVolunteer(Volunteer updatedVolunteer)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@VolunteerID", updatedVolunteer.VolunteerID));
            if (updatedVolunteer.vUsername == null)
                parameters.Add(new SqlParameter("@vUsername", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vUsername", updatedVolunteer.vUsername));

            if (updatedVolunteer.vPassword == null)
                parameters.Add(new SqlParameter("@vPassword", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vPassword", updatedVolunteer.vPassword));

            if (updatedVolunteer.vReceiveMail == null)
                parameters.Add(new SqlParameter("@vReceiveMail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vReceiveMail", updatedVolunteer.vReceiveMail));


                parameters.Add(new SqlParameter("@VolunteerManID", updatedVolunteer.VolunteerManID));


            parameters.Add(new SqlParameter("@vName", updatedVolunteer.vName));

            if (updatedVolunteer.VGender == null)
                parameters.Add(new SqlParameter("@VGender", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VGender", updatedVolunteer.VGender));

            if (updatedVolunteer.vBirthDate == null)
                parameters.Add(new SqlParameter("@vBirthDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vBirthDate", updatedVolunteer.vBirthDate));

            if (updatedVolunteer.VSchool == null)
                parameters.Add(new SqlParameter("@VSchool", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VSchool", updatedVolunteer.VSchool));

            if (updatedVolunteer.vEducationID == null)
                parameters.Add(new SqlParameter("@vEducationID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEducationID", updatedVolunteer.vEducationID));

            if (updatedVolunteer.VFacultyID == null)
                parameters.Add(new SqlParameter("@VFacultyID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VFacultyID", updatedVolunteer.VFacultyID));

            if (updatedVolunteer.VCurrentJob == null)
                parameters.Add(new SqlParameter("@VCurrentJob", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VCurrentJob", updatedVolunteer.VCurrentJob));

            if (updatedVolunteer.vJobPlaceID == null)
                parameters.Add(new SqlParameter("@vJobPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vJobPlaceID", updatedVolunteer.vJobPlaceID));

            if (updatedVolunteer.VAddress == null)
                parameters.Add(new SqlParameter("@VAddress", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VAddress", updatedVolunteer.VAddress));

            if (updatedVolunteer.vAreaID == null)
                parameters.Add(new SqlParameter("@vAreaID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vAreaID", updatedVolunteer.vAreaID));

            if (updatedVolunteer.vMobile == null)
                parameters.Add(new SqlParameter("@vMobile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMobile", updatedVolunteer.vMobile));

            if (updatedVolunteer.vTelephone == null)
                parameters.Add(new SqlParameter("@vTelephone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vTelephone", updatedVolunteer.vTelephone));

            if (updatedVolunteer.vEmail == null)
                parameters.Add(new SqlParameter("@vEmail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEmail", updatedVolunteer.vEmail));

            if (updatedVolunteer.vXexperience == null)
                parameters.Add(new SqlParameter("@vXexperience", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vXexperience", updatedVolunteer.vXexperience));

            if (updatedVolunteer.vComputer == null)
                parameters.Add(new SqlParameter("@vComputer", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputer", updatedVolunteer.vComputer));

            if (updatedVolunteer.vComputerSkills == null)
                parameters.Add(new SqlParameter("@vComputerSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputerSkills", updatedVolunteer.vComputerSkills));

            if (updatedVolunteer.vKnow == null)
                parameters.Add(new SqlParameter("@vKnow", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnow", updatedVolunteer.vKnow));

            if (updatedVolunteer.vKnowWay == null)
                parameters.Add(new SqlParameter("@vKnowWay", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnowWay", updatedVolunteer.vKnowWay));

            if (updatedVolunteer.vRegisterDate == null)
                parameters.Add(new SqlParameter("@vRegisterDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegisterDate", updatedVolunteer.vRegisterDate));

            if (updatedVolunteer.vFirstContactDate == null)
                parameters.Add(new SqlParameter("@vFirstContactDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactDate", updatedVolunteer.vFirstContactDate));

            if (updatedVolunteer.vRegistrationPlaceID == null)
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", updatedVolunteer.vRegistrationPlaceID));

            if (updatedVolunteer.vMeetingPlaceID == null)
                parameters.Add(new SqlParameter("@vMeetingPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingPlaceID", updatedVolunteer.vMeetingPlaceID));

            if (updatedVolunteer.vMeetingDate == null)
                parameters.Add(new SqlParameter("@vMeetingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDate", updatedVolunteer.vMeetingDate));

            if (updatedVolunteer.vComingDate == null)
                parameters.Add(new SqlParameter("@vComingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComingDate", updatedVolunteer.vComingDate));

            if (updatedVolunteer.vComments == null)
                parameters.Add(new SqlParameter("@vComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComments", updatedVolunteer.vComments));

            if (updatedVolunteer.vImage == null)
                parameters.Add(new SqlParameter("@vImage", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vImage", updatedVolunteer.vImage));

            if (updatedVolunteer.vCV == null)
                parameters.Add(new SqlParameter("@vCV", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vCV", updatedVolunteer.vCV));

            if (updatedVolunteer.vOtherFile == null)
                parameters.Add(new SqlParameter("@vOtherFile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vOtherFile", updatedVolunteer.vOtherFile));

            if (updatedVolunteer.RegisterVia == null)
                parameters.Add(new SqlParameter("@RegisterVia", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RegisterVia", updatedVolunteer.RegisterVia));

            if (updatedVolunteer.EntryDate == null)
                parameters.Add(new SqlParameter("@EntryDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryDate", updatedVolunteer.EntryDate));

            if (updatedVolunteer.EntryUserID == null)
                parameters.Add(new SqlParameter("@EntryUserID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryUserID", updatedVolunteer.EntryUserID));

            if (updatedVolunteer.vFirstContactPlaceID == null)
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", updatedVolunteer.vFirstContactPlaceID));

            if (updatedVolunteer.vSkills == null)
                parameters.Add(new SqlParameter("@vSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vSkills", updatedVolunteer.vSkills));

            if (updatedVolunteer.vMeetingDone == null)
                parameters.Add(new SqlParameter("@vMeetingDone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDone", updatedVolunteer.vMeetingDone));

            if (updatedVolunteer.vMeetingApology == null)
                parameters.Add(new SqlParameter("@vMeetingApology", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApology", updatedVolunteer.vMeetingApology));

            if (updatedVolunteer.vMeetingApologyDate == null)
                parameters.Add(new SqlParameter("@vMeetingApologyDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApologyDate", updatedVolunteer.vMeetingApologyDate));

            if (updatedVolunteer.vMeetingApologyPlace == null)
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", updatedVolunteer.vMeetingApologyPlace));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("VolunteersUpdate", parameters);
            }
            catch (SqlException exceptionInstance)
            {

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Volunteers"))
                {
                    throw new Exception("اسم المتطوع \"" + updatedVolunteer.vName + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل اسم اخر.");
                }
                else if (exceptionInstance.Message.Contains("Uk_Volunteers_VolunteerManId"))
                {
                    throw new Exception("رقم التعريف \"" + updatedVolunteer.VolunteerManID + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل رقم تعريف أخر.");
                }
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        /// <summary>
        /// Updates the volunteer.
        /// </summary>
        /// <param name="updatedVolunteer">The updated volunteer.</param>
        /// <param name="transactionInstance">The transaction instance.</param>
        /// <returns></returns>
        public int UpdateVolunteer(Volunteer updatedVolunteer, SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@VolunteerID", updatedVolunteer.VolunteerID));
            if (updatedVolunteer.vUsername == null)
                parameters.Add(new SqlParameter("@vUsername", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vUsername", updatedVolunteer.vUsername));

            if (updatedVolunteer.vPassword == null)
                parameters.Add(new SqlParameter("@vPassword", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vPassword", updatedVolunteer.vPassword));

            if (updatedVolunteer.vReceiveMail == null)
                parameters.Add(new SqlParameter("@vReceiveMail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vReceiveMail", updatedVolunteer.vReceiveMail));

            parameters.Add(new SqlParameter("@VolunteerManID", updatedVolunteer.VolunteerManID));


            parameters.Add(new SqlParameter("@vName", updatedVolunteer.vName));

            if (updatedVolunteer.VGender == null)
                parameters.Add(new SqlParameter("@VGender", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VGender", updatedVolunteer.VGender));

            if (updatedVolunteer.vBirthDate == null)
                parameters.Add(new SqlParameter("@vBirthDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vBirthDate", updatedVolunteer.vBirthDate));

            if (updatedVolunteer.VSchool == null)
                parameters.Add(new SqlParameter("@VSchool", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VSchool", updatedVolunteer.VSchool));

            if (updatedVolunteer.vEducationID == null)
                parameters.Add(new SqlParameter("@vEducationID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEducationID", updatedVolunteer.vEducationID));

            if (updatedVolunteer.VFacultyID == null)
                parameters.Add(new SqlParameter("@VFacultyID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VFacultyID", updatedVolunteer.VFacultyID));

            if (updatedVolunteer.VCurrentJob == null)
                parameters.Add(new SqlParameter("@VCurrentJob", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VCurrentJob", updatedVolunteer.VCurrentJob));

            if (updatedVolunteer.vJobPlaceID == null)
                parameters.Add(new SqlParameter("@vJobPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vJobPlaceID", updatedVolunteer.vJobPlaceID));

            if (updatedVolunteer.VAddress == null)
                parameters.Add(new SqlParameter("@VAddress", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VAddress", updatedVolunteer.VAddress));

            if (updatedVolunteer.vAreaID == null)
                parameters.Add(new SqlParameter("@vAreaID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vAreaID", updatedVolunteer.vAreaID));

            if (updatedVolunteer.vMobile == null)
                parameters.Add(new SqlParameter("@vMobile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMobile", updatedVolunteer.vMobile));

            if (updatedVolunteer.vTelephone == null)
                parameters.Add(new SqlParameter("@vTelephone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vTelephone", updatedVolunteer.vTelephone));

            if (updatedVolunteer.vEmail == null)
                parameters.Add(new SqlParameter("@vEmail", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEmail", updatedVolunteer.vEmail));

            if (updatedVolunteer.vXexperience == null)
                parameters.Add(new SqlParameter("@vXexperience", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vXexperience", updatedVolunteer.vXexperience));

            if (updatedVolunteer.vComputer == null)
                parameters.Add(new SqlParameter("@vComputer", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputer", updatedVolunteer.vComputer));

            if (updatedVolunteer.vComputerSkills == null)
                parameters.Add(new SqlParameter("@vComputerSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComputerSkills", updatedVolunteer.vComputerSkills));

            if (updatedVolunteer.vKnow == null)
                parameters.Add(new SqlParameter("@vKnow", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnow", updatedVolunteer.vKnow));

            if (updatedVolunteer.vKnowWay == null)
                parameters.Add(new SqlParameter("@vKnowWay", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnowWay", updatedVolunteer.vKnowWay));

            if (updatedVolunteer.vRegisterDate == null)
                parameters.Add(new SqlParameter("@vRegisterDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegisterDate", updatedVolunteer.vRegisterDate));

            if (updatedVolunteer.vFirstContactDate == null)
                parameters.Add(new SqlParameter("@vFirstContactDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactDate", updatedVolunteer.vFirstContactDate));

            if (updatedVolunteer.vRegistrationPlaceID == null)
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", updatedVolunteer.vRegistrationPlaceID));

            if (updatedVolunteer.vMeetingPlaceID == null)
                parameters.Add(new SqlParameter("@vMeetingPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingPlaceID", updatedVolunteer.vMeetingPlaceID));

            if (updatedVolunteer.vMeetingDate == null)
                parameters.Add(new SqlParameter("@vMeetingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDate", updatedVolunteer.vMeetingDate));

            if (updatedVolunteer.vComingDate == null)
                parameters.Add(new SqlParameter("@vComingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComingDate", updatedVolunteer.vComingDate));

            if (updatedVolunteer.vComments == null)
                parameters.Add(new SqlParameter("@vComments", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vComments", updatedVolunteer.vComments));

            if (updatedVolunteer.vImage == null)
                parameters.Add(new SqlParameter("@vImage", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vImage", updatedVolunteer.vImage));

            if (updatedVolunteer.vCV == null)
                parameters.Add(new SqlParameter("@vCV", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vCV", updatedVolunteer.vCV));

            if (updatedVolunteer.vOtherFile == null)
                parameters.Add(new SqlParameter("@vOtherFile", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vOtherFile", updatedVolunteer.vOtherFile));

            if (updatedVolunteer.RegisterVia == null)
                parameters.Add(new SqlParameter("@RegisterVia", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@RegisterVia", updatedVolunteer.RegisterVia));

            if (updatedVolunteer.EntryDate == null)
                parameters.Add(new SqlParameter("@EntryDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryDate", updatedVolunteer.EntryDate));

            if (updatedVolunteer.EntryUserID == null)
                parameters.Add(new SqlParameter("@EntryUserID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@EntryUserID", updatedVolunteer.EntryUserID));

            if (updatedVolunteer.vFirstContactPlaceID == null)
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", updatedVolunteer.vFirstContactPlaceID));

            if (updatedVolunteer.vSkills == null)
                parameters.Add(new SqlParameter("@vSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vSkills", updatedVolunteer.vSkills));

            if (updatedVolunteer.vMeetingDone == null)
                parameters.Add(new SqlParameter("@vMeetingDone", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDone", updatedVolunteer.vMeetingDone));

            if (updatedVolunteer.vMeetingApology == null)
                parameters.Add(new SqlParameter("@vMeetingApology", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApology", updatedVolunteer.vMeetingApology));

            if (updatedVolunteer.vMeetingApologyDate == null)
                parameters.Add(new SqlParameter("@vMeetingApologyDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingApologyDate", updatedVolunteer.vMeetingApologyDate));

            if (updatedVolunteer.vMeetingApologyPlace == null)
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vmeetingApologyPlace", updatedVolunteer.vMeetingApologyPlace));


            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("VolunteersUpdate", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {

                //check if the exception is caused by the unique field constraint on the name column in the database while insertion
                if (exceptionInstance.Message.Contains("UK_FBV_Tbl_Volunteers"))
                {
                    throw new Exception("اسم المتطوع \"" + updatedVolunteer.vName + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل اسم اخر.");
                }
                else if (exceptionInstance.Message.Contains("Uk_Volunteers_VolunteerManId"))
                {
                    throw new Exception("رقم التعريف \"" + updatedVolunteer.VolunteerManID + "\" موجود مسبقا فى قاعدة البيانات, من فضلك ادخل رقم تعريف أخر.");
                }
                else
                    throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        /// <summary>
        /// Gets the name of the volunteer by name.
        /// </summary>
        /// <param name="VolunteerName">Name of the volunteer.</param>
        /// <param name="VolunteerBirthDate">The volunteer birth date.</param>
        /// <returns></returns>
        public Volunteer GetVolunteerByNameAndBirthdate(string VolunteerName, DateTime VolunteerBirthDate)
        {
            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> Parameters = new List<SqlParameter>();
                Parameters.Add(new SqlParameter("@vName", VolunteerName));
                Parameters.Add(new SqlParameter("@vBirthDate", VolunteerBirthDate));
                reader = ExecuteReader("VolunteersGetNameAndBirthDate", Parameters);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int volunteerIDOrdinal = reader.GetOrdinal("VolunteerID");
                int usernameOrdinal = reader.GetOrdinal("vUsername");
                int passwordOrdinal = reader.GetOrdinal("vPassword");
                int receiveMailOrdinal = reader.GetOrdinal("vReceiveMail");
                int volunteerManIDOrdinal = reader.GetOrdinal("VolunteerManID");
                int nameOrdinal = reader.GetOrdinal("vName");
                int genderOrdinal = reader.GetOrdinal("VGender");
                int birthDateOrdinal = reader.GetOrdinal("vBirthDate");
                int schoolOrdinal = reader.GetOrdinal("VSchool");
                int educationIDOrdinal = reader.GetOrdinal("vEducationID");
                int facultyIDOrdinal = reader.GetOrdinal("VFacultyID");
                int currentJobOrdinal = reader.GetOrdinal("VCurrentJob");
                int jobPlaceIDOrdinal = reader.GetOrdinal("vJobPlaceID");
                int addressOrdinal = reader.GetOrdinal("VAddress");
                int areaIDOrdinal = reader.GetOrdinal("vAreaID");
                int mobileOrdinal = reader.GetOrdinal("vMobile");
                int telephoneOrdinal = reader.GetOrdinal("vTelephone");
                int emailOrdinal = reader.GetOrdinal("vEmail");
                int xexperienceOrdinal = reader.GetOrdinal("vXexperience");
                int computerOrdinal = reader.GetOrdinal("vComputer");
                int computerSkillsOrdinal = reader.GetOrdinal("vComputerSkills");
                int knowOrdinal = reader.GetOrdinal("vKnow");
                int knowWayOrdinal = reader.GetOrdinal("vKnowWay");
                int registerDateOrdinal = reader.GetOrdinal("vRegisterDate");
                int firstContactDateOrdinal = reader.GetOrdinal("vFirstContactDate");
                int registrationPlaceIDOrdinal = reader.GetOrdinal("vRegistrationPlaceID");
                int meetingPlaceIDOrdinal = reader.GetOrdinal("vMeetingPlaceID");
                int meetingDateOrdinal = reader.GetOrdinal("vMeetingDate");
                int comingDateOrdinal = reader.GetOrdinal("vComingDate");
                int commentsOrdinal = reader.GetOrdinal("vComments");
                int imageOrdinal = reader.GetOrdinal("vImage");
                int cvOrdinal = reader.GetOrdinal("vCV");
                int otherFileOrdinal = reader.GetOrdinal("vOtherFile");
                int registerViaOrdinal = reader.GetOrdinal("RegisterVia");
                int entryDateOrdinal = reader.GetOrdinal("EntryDate");
                int entryUserIDOrdinal = reader.GetOrdinal("EntryUserID");
                int firstContactPlaceOrdinal = reader.GetOrdinal("vFirstContactPlaceID");
                int skillsOrdinal = reader.GetOrdinal("vSkills");
                int meetingDoneOrdinal = reader.GetOrdinal("vMeetingDone");
                int meetingApologyOrdinal = reader.GetOrdinal("vMeetingApology");
                int meetingApologyDateOrdinal = reader.GetOrdinal("vMeetingApologyDate");
                int meetingApologyPlaceOrdinal = reader.GetOrdinal("vmeetingApologyPlace");

                reader.Read();
                Volunteer volunteerInstance = new Volunteer();

                volunteerInstance.VolunteerID = reader.GetInt32(volunteerIDOrdinal);

                if (reader.IsDBNull(usernameOrdinal))
                    volunteerInstance.vUsername = null;
                else
                    volunteerInstance.vUsername = reader.GetString(usernameOrdinal);

                if (reader.IsDBNull(passwordOrdinal))
                    volunteerInstance.vPassword = null;
                else
                    volunteerInstance.vPassword = reader.GetString(passwordOrdinal);

                if (reader.IsDBNull(receiveMailOrdinal))
                    volunteerInstance.vReceiveMail = null;
                else
                    volunteerInstance.vReceiveMail = reader.GetInt32(receiveMailOrdinal);


                volunteerInstance.VolunteerManID = reader.GetInt32(volunteerManIDOrdinal);

                volunteerInstance.vName = reader.GetString(nameOrdinal);

                if (reader.IsDBNull(genderOrdinal))
                    volunteerInstance.VGender = null;
                else
                    volunteerInstance.VGender = reader.GetString(genderOrdinal);

                if (reader.IsDBNull(birthDateOrdinal))
                    volunteerInstance.vBirthDate = null;
                else
                    volunteerInstance.vBirthDate = reader.GetDateTime(birthDateOrdinal);

                if (reader.IsDBNull(schoolOrdinal))
                    volunteerInstance.VSchool = null;
                else
                    volunteerInstance.VSchool = reader.GetInt32(schoolOrdinal);

                if (reader.IsDBNull(educationIDOrdinal))
                    volunteerInstance.vEducationID = null;
                else
                    volunteerInstance.vEducationID = reader.GetInt32(educationIDOrdinal);

                if (reader.IsDBNull(facultyIDOrdinal))
                    volunteerInstance.VFacultyID = null;
                else
                    volunteerInstance.VFacultyID = reader.GetInt32(facultyIDOrdinal);

                if (reader.IsDBNull(currentJobOrdinal))
                    volunteerInstance.VCurrentJob = null;
                else
                    volunteerInstance.VCurrentJob = reader.GetString(currentJobOrdinal);

                if (reader.IsDBNull(jobPlaceIDOrdinal))
                    volunteerInstance.vJobPlaceID = null;
                else
                    volunteerInstance.vJobPlaceID = reader.GetInt32(jobPlaceIDOrdinal);

                if (reader.IsDBNull(addressOrdinal))
                    volunteerInstance.VAddress = null;
                else
                    volunteerInstance.VAddress = reader.GetString(addressOrdinal);

                if (reader.IsDBNull(areaIDOrdinal))
                    volunteerInstance.vAreaID = null;
                else
                    volunteerInstance.vAreaID = reader.GetInt32(areaIDOrdinal);

                if (reader.IsDBNull(mobileOrdinal))
                    volunteerInstance.vMobile = null;
                else
                    volunteerInstance.vMobile = reader.GetString(mobileOrdinal);

                if (reader.IsDBNull(telephoneOrdinal))
                    volunteerInstance.vTelephone = null;
                else
                    volunteerInstance.vTelephone = reader.GetString(telephoneOrdinal);

                if (reader.IsDBNull(emailOrdinal))
                    volunteerInstance.vEmail = null;
                else
                    volunteerInstance.vEmail = reader.GetString(emailOrdinal);

                if (reader.IsDBNull(xexperienceOrdinal))
                    volunteerInstance.vXexperience = null;
                else
                    volunteerInstance.vXexperience = reader.GetString(xexperienceOrdinal);

                if (reader.IsDBNull(computerOrdinal))
                    volunteerInstance.vComputer = null;
                else
                    volunteerInstance.vComputer = reader.GetInt32(computerOrdinal);

                if (reader.IsDBNull(computerSkillsOrdinal))
                    volunteerInstance.vComputerSkills = null;
                else
                    volunteerInstance.vComputerSkills = reader.GetString(computerSkillsOrdinal);

                if (reader.IsDBNull(knowOrdinal))
                    volunteerInstance.vKnow = null;
                else
                    volunteerInstance.vKnow = reader.GetInt32(knowOrdinal);

                if (reader.IsDBNull(knowWayOrdinal))
                    volunteerInstance.vKnowWay = null;
                else
                    volunteerInstance.vKnowWay = reader.GetString(knowWayOrdinal);

                if (reader.IsDBNull(registerDateOrdinal))
                    volunteerInstance.vRegisterDate = null;
                else
                    volunteerInstance.vRegisterDate = reader.GetDateTime(registerDateOrdinal);

                if (reader.IsDBNull(firstContactDateOrdinal))
                    volunteerInstance.vFirstContactDate = null;
                else
                    volunteerInstance.vFirstContactDate = reader.GetDateTime(firstContactDateOrdinal);

                if (reader.IsDBNull(registrationPlaceIDOrdinal))
                    volunteerInstance.vRegistrationPlaceID = null;
                else
                    volunteerInstance.vRegistrationPlaceID = reader.GetInt32(registrationPlaceIDOrdinal);

                if (reader.IsDBNull(meetingPlaceIDOrdinal))
                    volunteerInstance.vMeetingPlaceID = null;
                else
                    volunteerInstance.vMeetingPlaceID = reader.GetInt32(meetingPlaceIDOrdinal);

                if (reader.IsDBNull(meetingDateOrdinal))
                    volunteerInstance.vMeetingDate = null;
                else
                    volunteerInstance.vMeetingDate = reader.GetDateTime(meetingDateOrdinal);

                if (reader.IsDBNull(comingDateOrdinal))
                    volunteerInstance.vComingDate = null;
                else
                    volunteerInstance.vComingDate = reader.GetDateTime(comingDateOrdinal);

                if (reader.IsDBNull(commentsOrdinal))
                    volunteerInstance.vComments = null;
                else
                    volunteerInstance.vComments = reader.GetString(commentsOrdinal);

                if (reader.IsDBNull(imageOrdinal))
                    volunteerInstance.vImage = null;
                else
                    volunteerInstance.vImage = reader.GetString(imageOrdinal);

                if (reader.IsDBNull(cvOrdinal))
                    volunteerInstance.vCV = null;
                else
                    volunteerInstance.vCV = reader.GetString(cvOrdinal);

                if (reader.IsDBNull(otherFileOrdinal))
                    volunteerInstance.vOtherFile = null;
                else
                    volunteerInstance.vOtherFile = reader.GetString(otherFileOrdinal);

                if (reader.IsDBNull(registerViaOrdinal))
                    volunteerInstance.RegisterVia = null;
                else
                    volunteerInstance.RegisterVia = reader.GetInt32(registerViaOrdinal);

                if (reader.IsDBNull(entryDateOrdinal))
                    volunteerInstance.EntryDate = null;
                else
                    volunteerInstance.EntryDate = reader.GetDateTime(entryDateOrdinal);

                if (reader.IsDBNull(entryUserIDOrdinal))
                    volunteerInstance.EntryUserID = null;
                else
                    volunteerInstance.EntryUserID = reader.GetInt32(entryUserIDOrdinal);

                if (reader.IsDBNull(firstContactPlaceOrdinal))
                    volunteerInstance.vFirstContactPlaceID = null;
                else
                    volunteerInstance.vFirstContactPlaceID = reader.GetInt32(firstContactPlaceOrdinal);

                if (reader.IsDBNull(skillsOrdinal))
                    volunteerInstance.vSkills = null;
                else
                    volunteerInstance.vSkills = reader.GetString(skillsOrdinal);

                if (reader.IsDBNull(meetingDoneOrdinal))
                    volunteerInstance.vMeetingDone = null;
                else
                    volunteerInstance.vMeetingDone = reader.GetBoolean(meetingDoneOrdinal);

                if (reader.IsDBNull(meetingApologyOrdinal))
                    volunteerInstance.vMeetingApology = null;
                else
                    volunteerInstance.vMeetingApology = reader.GetBoolean(meetingApologyOrdinal);

                if (reader.IsDBNull(meetingApologyDateOrdinal))
                    volunteerInstance.vMeetingApologyDate = null;
                else
                    volunteerInstance.vMeetingApologyDate = reader.GetDateTime(meetingApologyDateOrdinal);

                if (reader.IsDBNull(meetingApologyPlaceOrdinal))
                    volunteerInstance.vMeetingApologyPlace = null;
                else
                    volunteerInstance.vMeetingApologyPlace = reader.GetInt32(meetingApologyPlaceOrdinal);

                return volunteerInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        /// <summary>
        /// Gets the volunteer by name and birthdate.
        /// </summary>
        /// <param name="VolunteerName">Name of the volunteer.</param>
        /// <param name="VolunteerBirthDate">The volunteer birth date.</param>
        /// <param name="transactionInstance">The transaction instance.</param>
        /// <returns></returns>
        public DataTable GetVolunteersByName(string VolunteerName)
        {
            SqlParameter nameParameter = new SqlParameter("@vName", VolunteerName);
            return GetTable("VolunteersGetByName", nameParameter);
        }

        public DataTable GetVolunteersByFieldId(int FieldId)
        {
            SqlParameter fieldIdParameter = new SqlParameter("@FieldWorkID", FieldId);
            return GetTable("VolunteersGetByFieldId", fieldIdParameter);
        }

        public Volunteer GetVolunteerByVolunteerId(int VolunteerId)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@VolunteerID", VolunteerId);
                reader = ExecuteReader("VolunteersGetByVolunteerID", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int volunteerIDOrdinal = reader.GetOrdinal("VolunteerID");
                int usernameOrdinal = reader.GetOrdinal("vUsername");
                int passwordOrdinal = reader.GetOrdinal("vPassword");
                int receiveMailOrdinal = reader.GetOrdinal("vReceiveMail");
                int volunteerManIDOrdinal = reader.GetOrdinal("VolunteerManID");
                int nameOrdinal = reader.GetOrdinal("vName");
                int genderOrdinal = reader.GetOrdinal("VGender");
                int birthDateOrdinal = reader.GetOrdinal("vBirthDate");
                int schoolOrdinal = reader.GetOrdinal("VSchool");
                int educationIDOrdinal = reader.GetOrdinal("vEducationID");
                int facultyIDOrdinal = reader.GetOrdinal("VFacultyID");
                int currentJobOrdinal = reader.GetOrdinal("VCurrentJob");
                int jobPlaceIDOrdinal = reader.GetOrdinal("vJobPlaceID");
                int addressOrdinal = reader.GetOrdinal("VAddress");
                int areaIDOrdinal = reader.GetOrdinal("vAreaID");
                int mobileOrdinal = reader.GetOrdinal("vMobile");
                int telephoneOrdinal = reader.GetOrdinal("vTelephone");
                int emailOrdinal = reader.GetOrdinal("vEmail");
                int xexperienceOrdinal = reader.GetOrdinal("vXexperience");
                int computerOrdinal = reader.GetOrdinal("vComputer");
                int computerSkillsOrdinal = reader.GetOrdinal("vComputerSkills");
                int knowOrdinal = reader.GetOrdinal("vKnow");
                int knowWayOrdinal = reader.GetOrdinal("vKnowWay");
                int registerDateOrdinal = reader.GetOrdinal("vRegisterDate");
                int firstContactDateOrdinal = reader.GetOrdinal("vFirstContactDate");
                int registrationPlaceIDOrdinal = reader.GetOrdinal("vRegistrationPlaceID");
                int meetingPlaceIDOrdinal = reader.GetOrdinal("vMeetingPlaceID");
                int meetingDateOrdinal = reader.GetOrdinal("vMeetingDate");
                int comingDateOrdinal = reader.GetOrdinal("vComingDate");
                int commentsOrdinal = reader.GetOrdinal("vComments");
                int imageOrdinal = reader.GetOrdinal("vImage");
                int cvOrdinal = reader.GetOrdinal("vCV");
                int otherFileOrdinal = reader.GetOrdinal("vOtherFile");
                int registerViaOrdinal = reader.GetOrdinal("RegisterVia");
                int entryDateOrdinal = reader.GetOrdinal("EntryDate");
                int entryUserIDOrdinal = reader.GetOrdinal("EntryUserID");
                int firstContactPlaceOrdinal = reader.GetOrdinal("vFirstContactPlaceID");
                int skillsOrdinal = reader.GetOrdinal("vSkills");
                int meetingDoneOrdinal = reader.GetOrdinal("vMeetingDone");
                int meetingApologyOrdinal = reader.GetOrdinal("vMeetingApology");
                int meetingApologyDateOrdinal = reader.GetOrdinal("vMeetingApologyDate");
                int meetingApologyPlaceOrdinal = reader.GetOrdinal("vmeetingApologyPlace");

                reader.Read();
                Volunteer volunteerInstance = new Volunteer();

                volunteerInstance.VolunteerID = reader.GetInt32(volunteerIDOrdinal);

                if (reader.IsDBNull(usernameOrdinal))
                    volunteerInstance.vUsername = null;
                else
                    volunteerInstance.vUsername = reader.GetString(usernameOrdinal);

                if (reader.IsDBNull(passwordOrdinal))
                    volunteerInstance.vPassword = null;
                else
                    volunteerInstance.vPassword = reader.GetString(passwordOrdinal);

                if (reader.IsDBNull(receiveMailOrdinal))
                    volunteerInstance.vReceiveMail = null;
                else
                    volunteerInstance.vReceiveMail = reader.GetInt32(receiveMailOrdinal);

                volunteerInstance.VolunteerManID = reader.GetInt32(volunteerManIDOrdinal);

                volunteerInstance.vName = reader.GetString(nameOrdinal);

                if (reader.IsDBNull(genderOrdinal))
                    volunteerInstance.VGender = null;
                else
                    volunteerInstance.VGender = reader.GetString(genderOrdinal);

                if (reader.IsDBNull(birthDateOrdinal))
                    volunteerInstance.vBirthDate = null;
                else
                    volunteerInstance.vBirthDate = reader.GetDateTime(birthDateOrdinal);

                if (reader.IsDBNull(schoolOrdinal))
                    volunteerInstance.VSchool = null;
                else
                    volunteerInstance.VSchool = reader.GetInt32(schoolOrdinal);

                if (reader.IsDBNull(educationIDOrdinal))
                    volunteerInstance.vEducationID = null;
                else
                    volunteerInstance.vEducationID = reader.GetInt32(educationIDOrdinal);

                if (reader.IsDBNull(facultyIDOrdinal))
                    volunteerInstance.VFacultyID = null;
                else
                    volunteerInstance.VFacultyID = reader.GetInt32(facultyIDOrdinal);

                if (reader.IsDBNull(currentJobOrdinal))
                    volunteerInstance.VCurrentJob = null;
                else
                    volunteerInstance.VCurrentJob = reader.GetString(currentJobOrdinal);

                if (reader.IsDBNull(jobPlaceIDOrdinal))
                    volunteerInstance.vJobPlaceID = null;
                else
                    volunteerInstance.vJobPlaceID = reader.GetInt32(jobPlaceIDOrdinal);

                if (reader.IsDBNull(addressOrdinal))
                    volunteerInstance.VAddress = null;
                else
                    volunteerInstance.VAddress = reader.GetString(addressOrdinal);

                if (reader.IsDBNull(areaIDOrdinal))
                    volunteerInstance.vAreaID = null;
                else
                    volunteerInstance.vAreaID = reader.GetInt32(areaIDOrdinal);

                if (reader.IsDBNull(mobileOrdinal))
                    volunteerInstance.vMobile = null;
                else
                    volunteerInstance.vMobile = reader.GetString(mobileOrdinal);

                if (reader.IsDBNull(telephoneOrdinal))
                    volunteerInstance.vTelephone = null;
                else
                    volunteerInstance.vTelephone = reader.GetString(telephoneOrdinal);

                if (reader.IsDBNull(emailOrdinal))
                    volunteerInstance.vEmail = null;
                else
                    volunteerInstance.vEmail = reader.GetString(emailOrdinal);

                if (reader.IsDBNull(xexperienceOrdinal))
                    volunteerInstance.vXexperience = null;
                else
                    volunteerInstance.vXexperience = reader.GetString(xexperienceOrdinal);

                if (reader.IsDBNull(computerOrdinal))
                    volunteerInstance.vComputer = null;
                else
                    volunteerInstance.vComputer = reader.GetInt32(computerOrdinal);

                if (reader.IsDBNull(computerSkillsOrdinal))
                    volunteerInstance.vComputerSkills = null;
                else
                    volunteerInstance.vComputerSkills = reader.GetString(computerSkillsOrdinal);

                if (reader.IsDBNull(knowOrdinal))
                    volunteerInstance.vKnow = null;
                else
                    volunteerInstance.vKnow = reader.GetInt32(knowOrdinal);

                if (reader.IsDBNull(knowWayOrdinal))
                    volunteerInstance.vKnowWay = null;
                else
                    volunteerInstance.vKnowWay = reader.GetString (knowWayOrdinal);

                if (reader.IsDBNull(registerDateOrdinal))
                    volunteerInstance.vRegisterDate = null;
                else
                    volunteerInstance.vRegisterDate = reader.GetDateTime(registerDateOrdinal);

                if (reader.IsDBNull(firstContactDateOrdinal))
                    volunteerInstance.vFirstContactDate = null;
                else
                    volunteerInstance.vFirstContactDate = reader.GetDateTime(firstContactDateOrdinal);

                if (reader.IsDBNull(registrationPlaceIDOrdinal))
                    volunteerInstance.vRegistrationPlaceID = null;
                else
                    volunteerInstance.vRegistrationPlaceID = reader.GetInt32(registrationPlaceIDOrdinal);

                if (reader.IsDBNull(meetingPlaceIDOrdinal))
                    volunteerInstance.vMeetingPlaceID = null;
                else
                    volunteerInstance.vMeetingPlaceID = reader.GetInt32(meetingPlaceIDOrdinal);

                if (reader.IsDBNull(meetingDateOrdinal))
                    volunteerInstance.vMeetingDate = null;
                else
                    volunteerInstance.vMeetingDate = reader.GetDateTime(meetingDateOrdinal);

                if (reader.IsDBNull(comingDateOrdinal))
                    volunteerInstance.vComingDate = null;
                else
                    volunteerInstance.vComingDate = reader.GetDateTime(comingDateOrdinal);

                if (reader.IsDBNull(commentsOrdinal))
                    volunteerInstance.vComments = null;
                else
                    volunteerInstance.vComments = reader.GetString(commentsOrdinal);

                if (reader.IsDBNull(imageOrdinal))
                    volunteerInstance.vImage = null;
                else
                    volunteerInstance.vImage = reader.GetString(imageOrdinal);

                if (reader.IsDBNull(cvOrdinal))
                    volunteerInstance.vCV = null;
                else
                    volunteerInstance.vCV = reader.GetString(cvOrdinal);

                if (reader.IsDBNull(otherFileOrdinal))
                    volunteerInstance.vOtherFile = null;
                else
                    volunteerInstance.vOtherFile = reader.GetString(otherFileOrdinal);

                if (reader.IsDBNull(registerViaOrdinal))
                    volunteerInstance.RegisterVia = null;
                else
                    volunteerInstance.RegisterVia = reader.GetInt32(registerViaOrdinal);

                if (reader.IsDBNull(entryDateOrdinal))
                    volunteerInstance.EntryDate = null;
                else
                    volunteerInstance.EntryDate = reader.GetDateTime(entryDateOrdinal);

                if (reader.IsDBNull(entryUserIDOrdinal))
                    volunteerInstance.EntryUserID = null;
                else
                    volunteerInstance.EntryUserID = reader.GetInt32(entryUserIDOrdinal);

                if (reader.IsDBNull(firstContactPlaceOrdinal))
                    volunteerInstance.vFirstContactPlaceID = null;
                else
                    volunteerInstance.vFirstContactPlaceID = reader.GetInt32(firstContactPlaceOrdinal);

                if (reader.IsDBNull(skillsOrdinal))
                    volunteerInstance.vSkills = null;
                else
                    volunteerInstance.vSkills = reader.GetString(skillsOrdinal);

                if (reader.IsDBNull(meetingDoneOrdinal))
                    volunteerInstance.vMeetingDone = null;
                else
                    volunteerInstance.vMeetingDone = reader.GetBoolean(meetingDoneOrdinal);

                if (reader.IsDBNull(meetingApologyOrdinal))
                    volunteerInstance.vMeetingApology = null;
                else
                    volunteerInstance.vMeetingApology = reader.GetBoolean(meetingApologyOrdinal);

                if (reader.IsDBNull(meetingApologyDateOrdinal))
                    volunteerInstance.vMeetingApologyDate = null;
                else
                    volunteerInstance.vMeetingApologyDate = reader.GetDateTime(meetingApologyDateOrdinal);

                if (reader.IsDBNull(meetingApologyPlaceOrdinal))
                    volunteerInstance.vMeetingApologyPlace = null;
                else
                    volunteerInstance.vMeetingApologyPlace = reader.GetInt32(meetingApologyPlaceOrdinal);


                return volunteerInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public Volunteer GetVolunteerByManIdAndName(int VolunteerManId, string VolunteerName, SqlTransaction transactionInstance)
        {

            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> Parameters = new List<SqlParameter>();
                Parameters.Add(new SqlParameter("@VolunteerManID", VolunteerManId));
                Parameters.Add(new SqlParameter("@vName", VolunteerName));

                reader = ExecuteReader("VolunteersGetByVolunteerManIdAndName", Parameters, transactionInstance);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int volunteerIDOrdinal = reader.GetOrdinal("VolunteerID");
                int usernameOrdinal = reader.GetOrdinal("vUsername");
                int passwordOrdinal = reader.GetOrdinal("vPassword");
                int receiveMailOrdinal = reader.GetOrdinal("vReceiveMail");
                int volunteerManIDOrdinal = reader.GetOrdinal("VolunteerManID");
                int nameOrdinal = reader.GetOrdinal("vName");
                int genderOrdinal = reader.GetOrdinal("VGender");
                int birthDateOrdinal = reader.GetOrdinal("vBirthDate");
                int schoolOrdinal = reader.GetOrdinal("VSchool");
                int educationIDOrdinal = reader.GetOrdinal("vEducationID");
                int facultyIDOrdinal = reader.GetOrdinal("VFacultyID");
                int currentJobOrdinal = reader.GetOrdinal("VCurrentJob");
                int jobPlaceIDOrdinal = reader.GetOrdinal("vJobPlaceID");
                int addressOrdinal = reader.GetOrdinal("VAddress");
                int areaIDOrdinal = reader.GetOrdinal("vAreaID");
                int mobileOrdinal = reader.GetOrdinal("vMobile");
                int telephoneOrdinal = reader.GetOrdinal("vTelephone");
                int emailOrdinal = reader.GetOrdinal("vEmail");
                int xexperienceOrdinal = reader.GetOrdinal("vXexperience");
                int computerOrdinal = reader.GetOrdinal("vComputer");
                int computerSkillsOrdinal = reader.GetOrdinal("vComputerSkills");
                int knowOrdinal = reader.GetOrdinal("vKnow");
                int knowWayOrdinal = reader.GetOrdinal("vKnowWay");
                int registerDateOrdinal = reader.GetOrdinal("vRegisterDate");
                int firstContactDateOrdinal = reader.GetOrdinal("vFirstContactDate");
                int registrationPlaceIDOrdinal = reader.GetOrdinal("vRegistrationPlaceID");
                int meetingPlaceIDOrdinal = reader.GetOrdinal("vMeetingPlaceID");
                int meetingDateOrdinal = reader.GetOrdinal("vMeetingDate");
                int comingDateOrdinal = reader.GetOrdinal("vComingDate");
                int commentsOrdinal = reader.GetOrdinal("vComments");
                int imageOrdinal = reader.GetOrdinal("vImage");
                int cvOrdinal = reader.GetOrdinal("vCV");
                int otherFileOrdinal = reader.GetOrdinal("vOtherFile");
                int registerViaOrdinal = reader.GetOrdinal("RegisterVia");
                int entryDateOrdinal = reader.GetOrdinal("EntryDate");
                int entryUserIDOrdinal = reader.GetOrdinal("EntryUserID");
                int firstContactPlaceOrdinal = reader.GetOrdinal("vFirstContactPlaceID");
                int skillsOrdinal = reader.GetOrdinal("vSkills");
                int meetingDoneOrdinal = reader.GetOrdinal("vMeetingDone");
                int meetingApologyOrdinal = reader.GetOrdinal("vMeetingApology");
                int meetingApologyDateOrdinal = reader.GetOrdinal("vMeetingApologyDate");
                int meetingApologyPlaceOrdinal = reader.GetOrdinal("vmeetingApologyPlace");

                reader.Read();
                Volunteer volunteerInstance = new Volunteer();

                volunteerInstance.VolunteerID = reader.GetInt32(volunteerIDOrdinal);

                if (reader.IsDBNull(usernameOrdinal))
                    volunteerInstance.vUsername = null;
                else
                    volunteerInstance.vUsername = reader.GetString(usernameOrdinal);

                if (reader.IsDBNull(passwordOrdinal))
                    volunteerInstance.vPassword = null;
                else
                    volunteerInstance.vPassword = reader.GetString(passwordOrdinal);

                if (reader.IsDBNull(receiveMailOrdinal))
                    volunteerInstance.vReceiveMail = null;
                else
                    volunteerInstance.vReceiveMail = reader.GetInt32(receiveMailOrdinal);

                volunteerInstance.VolunteerManID = reader.GetInt32(volunteerManIDOrdinal);

                volunteerInstance.vName = reader.GetString(nameOrdinal);

                if (reader.IsDBNull(genderOrdinal))
                    volunteerInstance.VGender = null;
                else
                    volunteerInstance.VGender = reader.GetString(genderOrdinal);

                if (reader.IsDBNull(birthDateOrdinal))
                    volunteerInstance.vBirthDate = null;
                else
                    volunteerInstance.vBirthDate = reader.GetDateTime(birthDateOrdinal);

                if (reader.IsDBNull(schoolOrdinal))
                    volunteerInstance.VSchool = null;
                else
                    volunteerInstance.VSchool = reader.GetInt32(schoolOrdinal);

                if (reader.IsDBNull(educationIDOrdinal))
                    volunteerInstance.vEducationID = null;
                else
                    volunteerInstance.vEducationID = reader.GetInt32(educationIDOrdinal);

                if (reader.IsDBNull(facultyIDOrdinal))
                    volunteerInstance.VFacultyID = null;
                else
                    volunteerInstance.VFacultyID = reader.GetInt32(facultyIDOrdinal);

                if (reader.IsDBNull(currentJobOrdinal))
                    volunteerInstance.VCurrentJob = null;
                else
                    volunteerInstance.VCurrentJob = reader.GetString(currentJobOrdinal);

                if (reader.IsDBNull(jobPlaceIDOrdinal))
                    volunteerInstance.vJobPlaceID = null;
                else
                    volunteerInstance.vJobPlaceID = reader.GetInt32(jobPlaceIDOrdinal);

                if (reader.IsDBNull(addressOrdinal))
                    volunteerInstance.VAddress = null;
                else
                    volunteerInstance.VAddress = reader.GetString(addressOrdinal);

                if (reader.IsDBNull(areaIDOrdinal))
                    volunteerInstance.vAreaID = null;
                else
                    volunteerInstance.vAreaID = reader.GetInt32(areaIDOrdinal);

                if (reader.IsDBNull(mobileOrdinal))
                    volunteerInstance.vMobile = null;
                else
                    volunteerInstance.vMobile = reader.GetString(mobileOrdinal);

                if (reader.IsDBNull(telephoneOrdinal))
                    volunteerInstance.vTelephone = null;
                else
                    volunteerInstance.vTelephone = reader.GetString(telephoneOrdinal);

                if (reader.IsDBNull(emailOrdinal))
                    volunteerInstance.vEmail = null;
                else
                    volunteerInstance.vEmail = reader.GetString(emailOrdinal);

                if (reader.IsDBNull(xexperienceOrdinal))
                    volunteerInstance.vXexperience = null;
                else
                    volunteerInstance.vXexperience = reader.GetString(xexperienceOrdinal);

                if (reader.IsDBNull(computerOrdinal))
                    volunteerInstance.vComputer = null;
                else
                    volunteerInstance.vComputer = reader.GetInt32(computerOrdinal);

                if (reader.IsDBNull(computerSkillsOrdinal))
                    volunteerInstance.vComputerSkills = null;
                else
                    volunteerInstance.vComputerSkills = reader.GetString(computerSkillsOrdinal);

                if (reader.IsDBNull(knowOrdinal))
                    volunteerInstance.vKnow = null;
                else
                    volunteerInstance.vKnow = reader.GetInt32(knowOrdinal);

                if (reader.IsDBNull(knowWayOrdinal))
                    volunteerInstance.vKnowWay = null;
                else
                    volunteerInstance.vKnowWay = reader.GetString(knowWayOrdinal);

                if (reader.IsDBNull(registerDateOrdinal))
                    volunteerInstance.vRegisterDate = null;
                else
                    volunteerInstance.vRegisterDate = reader.GetDateTime(registerDateOrdinal);

                if (reader.IsDBNull(firstContactDateOrdinal))
                    volunteerInstance.vFirstContactDate = null;
                else
                    volunteerInstance.vFirstContactDate = reader.GetDateTime(firstContactDateOrdinal);

                if (reader.IsDBNull(registrationPlaceIDOrdinal))
                    volunteerInstance.vRegistrationPlaceID = null;
                else
                    volunteerInstance.vRegistrationPlaceID = reader.GetInt32(registrationPlaceIDOrdinal);

                if (reader.IsDBNull(meetingPlaceIDOrdinal))
                    volunteerInstance.vMeetingPlaceID = null;
                else
                    volunteerInstance.vMeetingPlaceID = reader.GetInt32(meetingPlaceIDOrdinal);

                if (reader.IsDBNull(meetingDateOrdinal))
                    volunteerInstance.vMeetingDate = null;
                else
                    volunteerInstance.vMeetingDate = reader.GetDateTime(meetingDateOrdinal);

                if (reader.IsDBNull(comingDateOrdinal))
                    volunteerInstance.vComingDate = null;
                else
                    volunteerInstance.vComingDate = reader.GetDateTime(comingDateOrdinal);

                if (reader.IsDBNull(commentsOrdinal))
                    volunteerInstance.vComments = null;
                else
                    volunteerInstance.vComments = reader.GetString(commentsOrdinal);

                if (reader.IsDBNull(imageOrdinal))
                    volunteerInstance.vImage = null;
                else
                    volunteerInstance.vImage = reader.GetString(imageOrdinal);

                if (reader.IsDBNull(cvOrdinal))
                    volunteerInstance.vCV = null;
                else
                    volunteerInstance.vCV = reader.GetString(cvOrdinal);

                if (reader.IsDBNull(otherFileOrdinal))
                    volunteerInstance.vOtherFile = null;
                else
                    volunteerInstance.vOtherFile = reader.GetString(otherFileOrdinal);

                if (reader.IsDBNull(registerViaOrdinal))
                    volunteerInstance.RegisterVia = null;
                else
                    volunteerInstance.RegisterVia = reader.GetInt32(registerViaOrdinal);

                if (reader.IsDBNull(entryDateOrdinal))
                    volunteerInstance.EntryDate = null;
                else
                    volunteerInstance.EntryDate = reader.GetDateTime(entryDateOrdinal);

                if (reader.IsDBNull(entryUserIDOrdinal))
                    volunteerInstance.EntryUserID = null;
                else
                    volunteerInstance.EntryUserID = reader.GetInt32(entryUserIDOrdinal);

                if (reader.IsDBNull(firstContactPlaceOrdinal))
                    volunteerInstance.vFirstContactPlaceID = null;
                else
                    volunteerInstance.vFirstContactPlaceID = reader.GetInt32(firstContactPlaceOrdinal);

                if (reader.IsDBNull(skillsOrdinal))
                    volunteerInstance.vSkills = null;
                else
                    volunteerInstance.vSkills = reader.GetString(skillsOrdinal);

                if (reader.IsDBNull(meetingDoneOrdinal))
                    volunteerInstance.vMeetingDone = null;
                else
                    volunteerInstance.vMeetingDone = reader.GetBoolean(meetingDoneOrdinal);

                if (reader.IsDBNull(meetingApologyOrdinal))
                    volunteerInstance.vMeetingApology = null;
                else
                    volunteerInstance.vMeetingApology = reader.GetBoolean(meetingApologyOrdinal);

                if (reader.IsDBNull(meetingApologyDateOrdinal))
                    volunteerInstance.vMeetingApologyDate = null;
                else
                    volunteerInstance.vMeetingApologyDate = reader.GetDateTime(meetingApologyDateOrdinal);

                if (reader.IsDBNull(meetingApologyPlaceOrdinal))
                    volunteerInstance.vMeetingApologyPlace = null;
                else
                    volunteerInstance.vMeetingApologyPlace = reader.GetInt32(meetingApologyPlaceOrdinal);

                return volunteerInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public List<string> GetVolunteerNames(string Prefix)
        {
              SqlDataReader reader = null;

              try 
              {
                  SqlParameter prefixParameter = new SqlParameter("@Prefix", Prefix);
                  reader = ExecuteReader("VolunteersGetByPrefix", prefixParameter);

                  if (!reader.HasRows)
                      // if there is no entry with the given prefix
                      return null;

                  int vNameOrdinal = reader.GetOrdinal("vName");
                  List<string> volunteerNames = new List<string>();
                  while (reader.Read())
                  {
                      volunteerNames.Add(reader.GetString(vNameOrdinal));
                  }
                  return volunteerNames;
              }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        
        }


        public DataSet Search(VolunteerSearchRecord SearchRecord, int PageIndex, int PageSize)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (SearchRecord.vName == null)
                parameters.Add(new SqlParameter("@vName", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vName", SearchRecord.vName));

            if (SearchRecord.VolunteerManIdStart == null)
                parameters.Add(new SqlParameter("@VolunteerManIdStart", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VolunteerManIdStart", SearchRecord.VolunteerManIdStart));

            if (SearchRecord.VolunteerManIdEnd == null)
                parameters.Add(new SqlParameter("@VolunteerManIdEnd", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VolunteerManIdEnd", SearchRecord.VolunteerManIdEnd));

            if (SearchRecord.vBirthDateFrom == null)
                parameters.Add(new SqlParameter("@vBirthDateFrom", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vBirthDateFrom", SearchRecord.vBirthDateFrom));

            if (SearchRecord.vBirthDateTo == null)
                parameters.Add(new SqlParameter("@vBirthDateTo", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vBirthDateTo", SearchRecord.vBirthDateTo));

            if (SearchRecord.VUniversityID == null)
                parameters.Add(new SqlParameter("@VUniversityID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VUniversityID", SearchRecord.VUniversityID));

            if (SearchRecord.VFacultyID == null)
                parameters.Add(new SqlParameter("@VFacultyID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@VFacultyID", SearchRecord.VFacultyID));

            if (SearchRecord.vEducationID == null)
                parameters.Add(new SqlParameter("@vEducationID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vEducationID", SearchRecord.vEducationID));

            if (SearchRecord.vCityID == null)
                parameters.Add(new SqlParameter("@vCityID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vCityID", SearchRecord.vCityID));

            if (SearchRecord.vAreaID == null)
                parameters.Add(new SqlParameter("@vAreaID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vAreaID", SearchRecord.vAreaID));

            if (SearchRecord.vJobPlaceID == null)
                parameters.Add(new SqlParameter("@vJobPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vJobPlaceID", SearchRecord.vJobPlaceID));

            if (SearchRecord.vDesiredFields == null)
                parameters.Add(new SqlParameter("@vDesiredFields", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vDesiredFields", SearchRecord.vDesiredFields));

            if (SearchRecord.vRecommendedFields == null)
                parameters.Add(new SqlParameter("@vRecommendedFields", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRecommendedFields", SearchRecord.vRecommendedFields));

            if (SearchRecord.vSkills == null)
                parameters.Add(new SqlParameter("@vSkills", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vSkills", SearchRecord.vSkills));

            if (SearchRecord.vKnow == null)
                parameters.Add(new SqlParameter("@vKnow", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vKnow", SearchRecord.vKnow));

            if (SearchRecord.vRegisterDate == null)
                parameters.Add(new SqlParameter("@vRegisterDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegisterDate", SearchRecord.vRegisterDate));

            if (SearchRecord.vRegistrationPlaceID == null)
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRegistrationPlaceID", SearchRecord.vRegistrationPlaceID));

            if (SearchRecord.vFirstContactDate == null)
                parameters.Add(new SqlParameter("@vFirstContactDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactDate", SearchRecord.vFirstContactDate));

            if (SearchRecord.vFirstContactPlaceID == null)
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vFirstContactPlaceID", SearchRecord.vFirstContactPlaceID));

            if (SearchRecord.vMeetingDate == null)
                parameters.Add(new SqlParameter("@vMeetingDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingDate", SearchRecord.vMeetingDate));

            if (SearchRecord.vMeetingPlaceID == null)
                parameters.Add(new SqlParameter("@vMeetingPlaceID", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vMeetingPlaceID", SearchRecord.vMeetingPlaceID));

            parameters.Add(new SqlParameter("@PageIndex", PageIndex));

            if (SearchRecord.vSchool == null)
                parameters.Add(new SqlParameter("@vSchool", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vSchool", SearchRecord.vSchool));

              if (SearchRecord.AvActivityStartDate == null)
                parameters.Add(new SqlParameter("@AvActivityStartDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@AvActivityStartDate", SearchRecord.AvActivityStartDate));

                 if (SearchRecord.AvActivityEndDate == null)
                parameters.Add(new SqlParameter("@AvActivityEndDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@AvActivityEndDate", SearchRecord.AvActivityEndDate));
             
            if (SearchRecord.AvActivityCodeNoStart == null)
                parameters.Add(new SqlParameter("@AvActivityCodeNoStart", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@AvActivityCodeNoStart", SearchRecord.AvActivityCodeNoStart));
        
            if (SearchRecord.AvActivityCodeNoEnd == null)
                parameters.Add(new SqlParameter("@AvActivityCodeNoEnd", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@AvActivityCodeNoEnd", SearchRecord.AvActivityCodeNoEnd));
        
            if (SearchRecord. AvFields== null)
                parameters.Add(new SqlParameter("@AvFields", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@AvFields", SearchRecord.AvFields));

            if (SearchRecord.NvActivityStartDate == null)
                parameters.Add(new SqlParameter("@NvActivityStartDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@NvActivityStartDate", SearchRecord.NvActivityStartDate));

            if (SearchRecord.NvActivityEndDate == null)
                parameters.Add(new SqlParameter("@NvActivityEndDate", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@NvActivityEndDate", SearchRecord.NvActivityEndDate));

            if (SearchRecord.NvActivityCodeNoStart == null)
                parameters.Add(new SqlParameter("@NvActivityCodeNoStart", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@NvActivityCodeNoStart", SearchRecord.NvActivityCodeNoStart));

            if (SearchRecord.NvActivityCodeNoEnd == null)
                parameters.Add(new SqlParameter("@NvActivityCodeNoEnd", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@NvActivityCodeNoEnd", SearchRecord.NvActivityCodeNoEnd));

            if (SearchRecord.NvFields == null)
                parameters.Add(new SqlParameter("@NvFields", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@NvFields", SearchRecord.NvFields));

            if (SearchRecord.vRecommendedVolunteerFields == null)
                parameters.Add(new SqlParameter("@vRecommendedVolunteerFields", DBNull.Value));
            else
                parameters.Add(new SqlParameter("@vRecommendedVolunteerFields", SearchRecord.vRecommendedVolunteerFields));

            parameters.Add(new SqlParameter("@PageSize", PageSize));

            return GetDataSet("VolunteersSearch", parameters);
        }

        public void DeleteVolunteer(int VolunteerId)
        {
            SqlParameter idParameter = new SqlParameter("@VolunteerId", VolunteerId);
            try
            {
                ExecuteNonQuery("VolunteersDelete", idParameter);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("FK_"))
                {
                    //the delete operation is violating a forign key constraint 
                    throw new Exception("There is data in the database related to this Volunteer. This volunteer cannot be deleted.");
                }
                else
                    throw ex;
            }
        }
    }
}
