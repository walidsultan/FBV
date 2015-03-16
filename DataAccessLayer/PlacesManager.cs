using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class PlacesManager:DatabaseManager 
    {
        /// <summary>
        /// Gets all places.
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllPlaces()
        {
            return GetTable("PlacesGetAll");
        }

        public DataTable GetPlacesByCityId(int CityId)
        {
            SqlParameter cityIdParameter = new SqlParameter("@CityID", CityId );
            return GetTable("PlacesGetByCityID",cityIdParameter );
        }
        public Place GetPlaceByPlaceName(string PlaceName)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@PlaceName", PlaceName);
                reader = ExecuteReader("PlacesGetByPlaceName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int placeIDOrdinal = reader.GetOrdinal("PlaceID");
                int cityIDOrdinal = reader.GetOrdinal("CityID");


                reader.Read();
                Place placeInstance = new Place();


                placeInstance.PlaceID = reader.GetInt32(placeIDOrdinal);
                placeInstance.CityID = reader.GetInt32(cityIDOrdinal);

                placeInstance.PlaceName  = PlaceName ;

                return placeInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
        public Place GetPlaceByPlaceId(int PlaceId)
        {

            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@PlaceId", PlaceId);
                reader = ExecuteReader("PlacesGetByPlaceId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int placeNameOrdinal = reader.GetOrdinal("PlaceName");
                int cityIDOrdinal = reader.GetOrdinal("CityID");

                reader.Read();
                Place placeInstance = new Place();

                placeInstance.PlaceID = PlaceId;
                placeInstance.CityID = reader.GetInt32(cityIDOrdinal);
                placeInstance.PlaceName = reader.GetString(placeNameOrdinal);

                return placeInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
    }
}
