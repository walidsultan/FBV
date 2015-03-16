using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data.OleDb;
using System.Configuration;
using System.Globalization;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class ActivitiesExcelSheetManager
    {
        public List<ExcelRecord> GetActivitiesExcelSheetRecords(string FilePath)
        {
            List<ExcelRecord> ExcelVolunteers = new List<ExcelRecord>();

            String excelConnectionString = ConfigurationManager.ConnectionStrings["ExcelConnectionString"].ConnectionString;
            excelConnectionString = excelConnectionString.Replace("{ExcelFileName}", FilePath);

            OleDbConnection objConn = new OleDbConnection(excelConnectionString);
            objConn.Open();
            string excelSheetName = ConfigurationManager.AppSettings["ExcelSheetName"].ToString();
            OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [" + excelSheetName + "$]", objConn);

            int rowCount = 2;
            try
            {
                using (DbDataReader dr = objCmdSelect.ExecuteReader())
                {

                    int ManIdOrdinal = dr.GetOrdinal("ID");
                    int nameOrdinal = dr.GetOrdinal("الإسم ");
                    int typeOrdinal = dr.GetOrdinal("النوع ");
                    int dayOfBirthOrdinal = dr.GetOrdinal("تاريخ الميلاد يوم ");
                    int monthOfBirthOrdinal = dr.GetOrdinal("تاريخ الميلاد الشهر ");
                    int yearOfBirthOrdinal = dr.GetOrdinal("تاريخ الميلاد السنة");
                    int academicDegreeOrdinal = dr.GetOrdinal("نوع الدراسة / المؤهل ");
                    int schoolOrdinal = dr.GetOrdinal("المدرسة");
                    int universityOrdinal = dr.GetOrdinal("الجامعة");
                    int currentJobOrdinal = dr.GetOrdinal("الوظيفة ");
                    int jobPlaceOrdinal = dr.GetOrdinal("المؤسسة");
                    int areaOrdinal = dr.GetOrdinal("المنطقة");
                    int cityOrdinal = dr.GetOrdinal("المحافظة ");
                    int addressOrdinal = dr.GetOrdinal("العنوان");
                    int emailOrdinal = dr.GetOrdinal("البريد  الإلكترونى ");
                    int landlineTelephoneOrdinal = dr.GetOrdinal("رقم التليفون  الأرضى ");
                    int mobiletelephoneOrdinal = dr.GetOrdinal("رقم التليفون المحمول ");
                    int howDidYouKnowOrdinal = dr.GetOrdinal("كيف علمت عن بنك الطعام");
                    int KnowWayOrdinal = dr.GetOrdinal("تفاصيل كيف علمت عن بنك الطعام");
                    int firstContactPlaceOrdinal = dr.GetOrdinal("أول إتصال بالمتطوع ( المكان )");
                    int firstContactDateOrdinal = dr.GetOrdinal("أول إتصال بالمتطوع ( التاريخ )");
                    int registerationDateOrdinal = dr.GetOrdinal("إستيفاء الإستمارة ( التاريخ )");
                    int registerationPlaceOrdinal = dr.GetOrdinal("إستيفاء الإستمارة ( المكان )");
                    int MeetingPlaceOrdinal = dr.GetOrdinal("لقاء التعريف ( المكان )");
                    int MeetingDateOrdinal = dr.GetOrdinal("لقاء التعريف( التاريخ )");
                    int firstActivityTypeOrdinal = dr.GetOrdinal("نوع النشاط");
                    int activityTypeOrdinal = dr.GetOrdinal("نوع النشاط المرشح له");
                    int additionalActivitiesOrdinal = dr.GetOrdinal("أنشطة إضافية");
                    int previousVolunteerExperinceOrdinal = dr.GetOrdinal(" خبرات سابقة فى العمل الخيرى");
                    int generalNotesOrdinal = dr.GetOrdinal("ملاحظات عامة");

                    while (dr.Read())
                    {
                        ExcelRecord excelRecordInstance = new ExcelRecord();
                        try
                        {
                            if (dr.IsDBNull(ManIdOrdinal))
                                throw new FormatException("تحت عمود ID,هذة القيمة لا تقبل ان تكون فارغه");
                            else
                                excelRecordInstance.VolunteerManID = int.Parse(dr.GetDouble(ManIdOrdinal).ToString());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود ID, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(nameOrdinal))
                                throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                            else
                                excelRecordInstance.Name = dr.GetString(nameOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود الإسم, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(typeOrdinal))
                                excelRecordInstance.Gender = null;
                            else
                                excelRecordInstance.Gender = dr.GetString(typeOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود النوع, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(dayOfBirthOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.BirthDay = null;
                            else
                            {
                                excelRecordInstance.BirthDay = int.Parse(dr.GetDouble(dayOfBirthOrdinal).ToString());
                                //validate the birthday isn't larger than 31
                                if (excelRecordInstance.BirthDay > 31) throw new Exception("تاريخ الميلاد يوم can't be larger than 31");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود تاريخ الميلاد يوم, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(monthOfBirthOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.BirthMonth = null;
                            else
                            {
                                excelRecordInstance.BirthMonth = int.Parse(dr.GetDouble(monthOfBirthOrdinal).ToString());
                                //validate the month isn't greater than 12
                                if (excelRecordInstance.BirthMonth > 12) throw new Exception("تاريخ الميلاد الشهر can't be larger than 12");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود تاريخ الميلاد الشهر, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(yearOfBirthOrdinal))
                                // throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.BirthYear = null;
                            else
                            {
                                excelRecordInstance.BirthYear = int.Parse(dr.GetDouble(yearOfBirthOrdinal).ToString());
                                //validate the year is 4 characters exactly
                                if (excelRecordInstance.BirthYear.ToString().Length != 4 && excelRecordInstance.BirthYear.ToString().Length != 2) throw new Exception("تاريخ الميلاد السنة must be 4 or 2 characters only");
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود تاريخ الميلاد السنة, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(academicDegreeOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.Education = null;
                            else
                                excelRecordInstance.Education = dr.GetString(academicDegreeOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود نوع الدراسة / المؤهل, " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(schoolOrdinal))
                                excelRecordInstance.School = null;
                            else
                                excelRecordInstance.School = dr.GetString(schoolOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود  المدرسة, " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(universityOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.University = null;
                            else
                                excelRecordInstance.University = dr.GetString(universityOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود  الجامعة, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(currentJobOrdinal))
                                excelRecordInstance.CurrentJob = null;
                            else
                                excelRecordInstance.CurrentJob = dr.GetString(currentJobOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود الوظيفة, " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(jobPlaceOrdinal))
                                // throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.JobPlace = null;
                            else
                                excelRecordInstance.JobPlace = dr.GetString(jobPlaceOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود المؤسسة, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(areaOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.Area = null;
                            else
                                excelRecordInstance.Area = dr.GetString(areaOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود المنطقة, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(cityOrdinal))
                                excelRecordInstance.City = null;
                            else
                                excelRecordInstance.City = dr.GetString(cityOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود المحافظة, " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(addressOrdinal))
                                excelRecordInstance.Address = null;
                            else
                                excelRecordInstance.Address = dr.GetString(addressOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود العنوان, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(emailOrdinal))
                                excelRecordInstance.Email = null;
                            else
                                excelRecordInstance.Email = dr.GetString(emailOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود البريد  الإلكترونى, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(landlineTelephoneOrdinal))
                                //  throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.Telephone = null;
                            else
                                excelRecordInstance.Telephone = dr.GetString(landlineTelephoneOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود رقم التليفون  الأرضى, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(mobiletelephoneOrdinal))
                                // throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.Mobile = null;
                            else
                                excelRecordInstance.Mobile = dr.GetString(mobiletelephoneOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود رقم التليفون المحمول, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(howDidYouKnowOrdinal))
                                excelRecordInstance.Know = null;
                            else
                                excelRecordInstance.Know = dr.GetString(howDidYouKnowOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود كيف علمت عن بنك الطعام, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(KnowWayOrdinal))
                                excelRecordInstance.KnowWay = null;
                            else
                                excelRecordInstance.KnowWay = dr.GetString(KnowWayOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود تفاصيل كيف علمت عن بنك الطعام, " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(firstContactPlaceOrdinal))
                                excelRecordInstance.FirstContactPlace = null;
                            else
                                excelRecordInstance.FirstContactPlace = dr.GetString(firstContactPlaceOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود أول إتصال بالمتطوع ( المكان ), " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(firstContactDateOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.FirstContactDate = null;
                            else
                                excelRecordInstance.FirstContactDate = dr.GetDateTime(firstContactDateOrdinal);
                        }
                        catch (InvalidCastException)
                        {
                            try
                            {
                                string Date = dr.GetString(firstContactDateOrdinal);
                                Date = Date.Replace("\\", "/");
                                excelRecordInstance.RegisterDate = DateTime.Parse(Date, new CultureInfo("fr-FR", true));
                            }
                            catch (Exception DateException)
                            {
                                throw new Exception("تحت عمود أول إتصال بالمتطوع ( التاريخ ) , " + DateException.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود أول إتصال بالمتطوع ( التاريخ ), " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(registerationDateOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.RegisterDate = null;
                            else
                                excelRecordInstance.RegisterDate = dr.GetDateTime(registerationDateOrdinal);
                        }
                        catch (InvalidCastException)
                        {
                            try
                            {
                                string Date = dr.GetString(registerationDateOrdinal);
                                Date = Date.Replace("\\", "/");
                                excelRecordInstance.RegisterDate = DateTime.Parse(Date, new CultureInfo("fr-FR", true));
                            }
                            catch (Exception DateException)
                            {
                                throw new Exception("تحت عمود إستيفاء الإستمارة ( التاريخ ) , " + DateException.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود إستيفاء الإستمارة ( التاريخ ), " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(registerationPlaceOrdinal))
                                excelRecordInstance.RegistrationPlace = null;
                            else
                                excelRecordInstance.RegistrationPlace = dr.GetString(registerationPlaceOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود إستيفاء الإستمارة ( المكان ), " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(MeetingPlaceOrdinal))
                                excelRecordInstance.MeetingPlace = null;
                            else
                                excelRecordInstance.MeetingPlace = dr.GetString(MeetingPlaceOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود لقاء التعريف ( المكان ) , " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(MeetingDateOrdinal))
                                //throw new FormatException("هذة القيمة لا تقبل ان تكون فارغه");
                                excelRecordInstance.MeetingDate = null;
                            else
                                excelRecordInstance.MeetingDate = dr.GetDateTime(MeetingDateOrdinal);
                        }
                        catch (InvalidCastException)
                        {
                            try
                            {
                                string Date = dr.GetString(MeetingDateOrdinal);
                                Date = Date.Replace("\\", "/");
                                excelRecordInstance.RegisterDate = DateTime.Parse(Date, new CultureInfo("fr-FR", true));
                            }
                            catch (Exception DateException)
                            {
                                throw new Exception("تحت عمود لقاء التعريف( التاريخ ), " + DateException.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود لقاء التعريف( التاريخ ), " + ex.Message);
                        }


                        try
                        {
                            if (dr.IsDBNull(firstActivityTypeOrdinal))
                                excelRecordInstance.FirstFieldWork = null;
                            else
                                excelRecordInstance.FirstFieldWork = dr.GetString(firstActivityTypeOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود نوع النشاط, " + ex.Message);
                        }



                        try
                        {
                            if (dr.IsDBNull(activityTypeOrdinal))
                                excelRecordInstance.FieldWork = null;
                            else
                                excelRecordInstance.FieldWork = dr.GetString(activityTypeOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود نوع النشاط المرشح له, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(additionalActivitiesOrdinal))
                                excelRecordInstance.AdditionalFieldWork = null;
                            else
                                excelRecordInstance.AdditionalFieldWork = dr.GetString(additionalActivitiesOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود أنشطة إضافية, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(previousVolunteerExperinceOrdinal))
                                excelRecordInstance.Experience = null;
                            else
                                excelRecordInstance.Experience = dr.GetString(previousVolunteerExperinceOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود خبرات سابقة فى العمل الخيرى, " + ex.Message);
                        }

                        try
                        {
                            if (dr.IsDBNull(generalNotesOrdinal))
                                excelRecordInstance.Comments = null;
                            else
                                excelRecordInstance.Comments = dr.GetString(generalNotesOrdinal);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("تحت عمود ملاحظات عامة, " + ex.Message);
                        }

                        ExcelVolunteers.Add(excelRecordInstance);

                        rowCount++;
                    }
                }
                return ExcelVolunteers;
            }
            catch (IndexOutOfRangeException exOutOfRange)
            {
                throw new Exception("هذا العمود غير موجود فى ملف الإكسل \"" + exOutOfRange.Message + "\"");
            }
            catch (Exception ex)
            {
                throw new Exception("خطأ فى قراءة ملف الإكسل فى سطر " + rowCount + ", " + ex.Message);
            }

            finally
            {
                if (objConn.State == ConnectionState.Open) objConn.Close();
            }


        }
    }
}
