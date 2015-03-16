using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class CitiesManager : DatabaseManager
    {
        public City GetCityByCityName(string CityName)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@CityName", CityName);
                reader = ExecuteReader("CitiesGetByCityName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int cityIdOrdinal = reader.GetOrdinal("CityID");


                reader.Read();
                City cityInstance = new City();


                cityInstance.CityID = reader.GetInt32(cityIdOrdinal);

                cityInstance.CityName = CityName;

                return cityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }

        public City GetCityByCityName(string CityName, SqlTransaction transactionInstance)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@CityName", CityName);
                reader = ExecuteReader("CitiesGetByCityName", nameParameter,transactionInstance );

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int cityIdOrdinal = reader.GetOrdinal("CityID");


                reader.Read();
                City cityInstance = new City();


                cityInstance.CityID = reader.GetInt32(cityIdOrdinal);

                cityInstance.CityName = CityName;

                return cityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }

        public int InsertCity(City CityInstance,SqlTransaction transactionInstance)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CityName", CityInstance.CityName));

            SqlParameter returnedIdParameter = new SqlParameter();
            returnedIdParameter.Direction = System.Data.ParameterDirection.ReturnValue;
            returnedIdParameter.DbType = System.Data.DbType.Int32;
            parameters.Add(returnedIdParameter);

            try
            {
                ExecuteNonQuery("CitiesInsert", parameters, transactionInstance);
            }
            catch (SqlException exceptionInstance)
            {
                throw exceptionInstance;
            }
            return (int)returnedIdParameter.Value;
        }

        public City GetCityByCityId(int CityId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@CityId", CityId);
                reader = ExecuteReader("CitiesGetByCityId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int cityNameOrdinal = reader.GetOrdinal("CityName");


                reader.Read();
                City cityInstance = new City();

                cityInstance.CityID = CityId;
                cityInstance.CityName = reader.GetString(cityNameOrdinal);

                return cityInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }

        public DataTable GetAllCities()
        {
            return GetTable("CitiesGetAll");
        }
    }
}
