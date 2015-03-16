using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class AreasManager:DatabaseManager 
    {
        public Area GetAreaByAreaNameAndCityId(string AreaName,int CityId)
        {
            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add( new SqlParameter("@AreaName", AreaName ));
                parameters.Add(new SqlParameter("@CityID", CityId));

                reader = ExecuteReader("AreasGetByAreaNameAndCityId", parameters);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int areaIDOrdinal = reader.GetOrdinal("AreaID");


                reader.Read();
                Area  areaInstance = new Area ();


                areaInstance.AreaID  = reader.GetInt32(areaIDOrdinal);
                areaInstance.CityID = CityId;

                areaInstance.AreaName  = AreaName ;

                return areaInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public Area GetAreaByAreaNameAndCityId(string AreaName, int CityId, SqlTransaction transactionInstance)
        {
            SqlDataReader reader = null;
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@AreaName", AreaName));
                parameters.Add(new SqlParameter("@CityID", CityId));

                reader = ExecuteReader("AreasGetByAreaNameAndCityId", parameters, transactionInstance);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int areaIDOrdinal = reader.GetOrdinal("AreaID");


                reader.Read();
                Area areaInstance = new Area();


                areaInstance.AreaID = reader.GetInt32(areaIDOrdinal);
                areaInstance.CityID = CityId;

                areaInstance.AreaName = AreaName;

                return areaInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
              public int InsertArea(Area  AreaInstance,SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AreaName", AreaInstance.AreaName ));
            parameters.Add(new SqlParameter("@CityID", AreaInstance.CityID));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("AreasInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        public Area GetAreaByAreaId(int AreaId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter areaIdParameter = new SqlParameter("@AreaId", AreaId);

                 reader = ExecuteReader("AreasGetByAreaId", areaIdParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int areaIDOrdinal = reader.GetOrdinal("AreaID");
                int areaNameOrdinal = reader.GetOrdinal("AreaName");
                int cityIdOrdinal = reader.GetOrdinal("CityID");

                reader.Read();
                Area areaInstance = new Area();


                areaInstance.AreaID = reader.GetInt32(areaIDOrdinal);
                areaInstance.AreaName = reader.GetString(areaNameOrdinal);
                areaInstance.CityID = reader.GetInt32(cityIdOrdinal);

                return areaInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }

        public DataTable  GetAllAreas()
        {
            return GetTable ("AreasGetAll");
        }
        public DataTable GetAreasByCityId(int CityId)
        { 
            SqlParameter cityIdParameter=new SqlParameter("@CityId",CityId);
            return GetTable ("AreasGetByCityId",cityIdParameter);
        }
    }
}
