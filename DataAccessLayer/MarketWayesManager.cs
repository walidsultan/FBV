using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class MarketWayesManager:DatabaseManager 
    {
        public DataTable GetAllMarketWayes()
        {
            return GetTable("marketWayGetAll");
        }

        
        public MarketWay GetMarketWayByMarketWayName(string MarketWayName)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@MarketWayName", MarketWayName);
                reader = ExecuteReader("marketWayGetMarketWayName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int marketWayIDOrdinal = reader.GetOrdinal("MarketWayID");


                reader.Read();
                MarketWay marketWayInstance = new MarketWay();


                marketWayInstance.MarketWayID = reader.GetInt32(marketWayIDOrdinal);

                marketWayInstance.MarketWayName  = MarketWayName ;

                return marketWayInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }
        }
    }
}
