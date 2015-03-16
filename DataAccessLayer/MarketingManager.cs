using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FBV.DataMapping;
namespace FBV.DataAccessLayer
{
    public class MarketingManager : DatabaseManager
    {
        public Marketing GetMarketingByMarketName(string MarketName)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter nameParameter = new SqlParameter("@MarketName", MarketName);
                reader = ExecuteReader("MarketingGetByMarketName", nameParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                int marketingIDOrdinal = reader.GetOrdinal("MarketingID");
                int vMarketWayIDOrdinal = reader.GetOrdinal("vMarketWayID");

                reader.Read();
                Marketing marketingInstance = new Marketing();


                marketingInstance.MarketingID = reader.GetInt32(marketingIDOrdinal);
                marketingInstance.vMarketWayID = reader.GetInt32(vMarketWayIDOrdinal);

                marketingInstance.MarketName = MarketName;

                return marketingInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }

        public Marketing GetMarketingByMarketId(int MarketingId)
        {
            SqlDataReader reader = null;
            try
            {
                SqlParameter idParameter = new SqlParameter("@MarketingId", MarketingId );
                reader = ExecuteReader("MarketingGetByMarketId", idParameter);

                if (!reader.HasRows)
                    // if there is no entry with the given id
                    return null;

                  int vMarketWayIDOrdinal = reader.GetOrdinal("vMarketWayID");
                  int vMarketNameOrdinal = reader.GetOrdinal("MarketName");
                
                reader.Read();
                Marketing marketingInstance = new Marketing();


                marketingInstance.MarketingID = MarketingId ;
                marketingInstance.vMarketWayID = reader.GetInt32(vMarketWayIDOrdinal);
                marketingInstance.MarketName = reader.GetString( vMarketNameOrdinal);

                return marketingInstance;
            }
            finally
            {
                if ((reader != null) && (!reader.IsClosed))
                    reader.Close();
            }

        }


        public DataTable GetAllMarketing()
        {
            return GetTable("MarketingGetAll");
        }
    }

}
