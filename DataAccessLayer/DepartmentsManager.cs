using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;

namespace FBV.DataAccessLayer
{
   public  class DepartmentsManager:DatabaseManager 
    {
       public DataTable GetAllDepartments()
       {
           return GetTable("DepartmentsGetAll");
       }

       public Department GetDepartmentById(int DepartmentId)
       {

           SqlDataReader reader = null;
           try
           {
               SqlParameter IdParameter = new SqlParameter("@DepartmentID", DepartmentId);
               reader = ExecuteReader("DepartmentsGetByDepartmentID", IdParameter);

               if (!reader.HasRows)
                   // if there is no entry with the given id
                   return null;

               int departmentIDOrdinal = reader.GetOrdinal("DepartmentID");
               int departmentNameOrdinal = reader.GetOrdinal("DepartmentName");


               reader.Read();
               Department departmentInstance = new Department();

               departmentInstance.DepartmentID = DepartmentId;
               departmentInstance.DepartmentName = reader.GetString(departmentNameOrdinal);

               return departmentInstance;
           }
           finally
           {
               if ((reader != null) && (!reader.IsClosed))
                   reader.Close();
           }
       }

       public Department GetDepartmentByName(string DepartmentName)
       {

           SqlDataReader reader = null;
           try
           {
               SqlParameter nameParameter = new SqlParameter("@DepartmentName", DepartmentName);
               reader = ExecuteReader("DepartmentsGetByDepartmentName", nameParameter);

               if (!reader.HasRows)
                   // if there is no entry with the given id
                   return null;

               int departmentIDOrdinal = reader.GetOrdinal("DepartmentID");
               int departmentNameOrdinal = reader.GetOrdinal("DepartmentName");


               reader.Read();
               Department departmentInstance = new Department();

               departmentInstance.DepartmentID = reader.GetInt32 (departmentIDOrdinal);
               departmentInstance.DepartmentName = reader.GetString(departmentNameOrdinal);

               return departmentInstance;
           }
           finally
           {
               if ((reader != null) && (!reader.IsClosed))
                   reader.Close();
           }
       }
    }
}
