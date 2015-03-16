using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FBV.DataAccessLayer
{
    /// <summary>
    /// A base class that is inherited by all data access layer classes that access the database.
    /// This class contains methods to perform basic database operations such as opening connections, closing connections and executing commands.
    /// </summary>
    public abstract class DatabaseManager
    {
        private SqlConnection _Connection = new SqlConnection();
        private SqlCommand _Command = new SqlCommand();
        private SqlTransaction _AssociatedTransaction;

        public DatabaseManager()
        {
            
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;
            _Command.Connection = _Connection;
            _Command.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public SqlTransaction BeginTransaction()
        {
            _Connection.Open();
            _AssociatedTransaction = _Connection.BeginTransaction();
            return _AssociatedTransaction;
        }
        public void RollBackTransaction()
        {
            if (_AssociatedTransaction != null)
            {
                _AssociatedTransaction.Rollback();
                _AssociatedTransaction = null;
                _Connection.Close();
            }
        }
        public void CommitTransaction()
        {
            if (_AssociatedTransaction != null)
            {
                _AssociatedTransaction.Commit();
                _AssociatedTransaction = null;
                _Connection.Close();
            }
            else
                throw new ApplicationException("There is no transaction to commit");
        }

        /// <summary>
        /// Executes a stored procedure and returns the number of rows affected
        /// </summary>
        /// <param name="storedProcedureName">List of parameters that will be passed to the stored procedure.</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string storedProcedureName, List<SqlParameter> parameters)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();

            if (parameters != null)
            {
                foreach (SqlParameter parameterInstance in parameters)
                    _Command.Parameters.Add(parameterInstance);
            }
            _Connection.Open();
            try
            {
                int returnedInt = _Command.ExecuteNonQuery();
                return returnedInt;
            }
            finally
            {
                _Connection.Close();
            }

        }


        // <summary>
        /// Executes a stored procedure that takes a single parameter and returns the number of rows affected
        /// </summary>
        protected int ExecuteNonQuery(string storedProcedureName, SqlParameter parameterInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();

            if (parameterInstance != null)
                _Command.Parameters.Add(parameterInstance);
            _Connection.Open();
            try
            {
                int returnedInt = _Command.ExecuteNonQuery();
                return returnedInt;
            }
            finally
            {
                _Connection.Close();
            }

        }

        // <summary>
        /// Executes a stored procedure that takes no parameters and returns the number of rows affected
        /// </summary>
        protected int ExecuteNonQuery(string storedProcedureName)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();

            _Connection.Open();
            try
            {
                int returnedInt = _Command.ExecuteNonQuery();
                return returnedInt;
            }
            finally
            {
                _Connection.Close();
            }

        }

        /// <summary>
        /// Executes a stored procedure and returns the number of rows affected.
        /// </summary>
        /// <param name="parameters">single parameter.</param>
        /// <param name="transactionInstance">A transaction object that will be used to share this operation with another database operation</param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string storedProcedureName, SqlParameter parameterInstance, SqlTransaction transactionInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Connection = transactionInstance.Connection;
            _Command.Transaction = transactionInstance;
            _Command.Parameters.Clear();

            if (parameterInstance != null)
                _Command.Parameters.Add(parameterInstance);


            int returnedInt = _Command.ExecuteNonQuery();

            //return back to using the object's connection
            _Command.Connection = _Connection;
            //don't bind to this transaction any more
            _Command.Transaction = null;

            return returnedInt;
        }

        /// <summary>
        /// Executes a stored procedure and returns the number of rows affected.
        /// </summary>
        /// <param name="parameters">List of parameters that will be passed to the stored procedure.</param>
        /// <param name="transactionInstance">A transaction object that will be used to share this operation with another database operation</param>
        /// <returns></returns>
        protected int ExecuteNonQuery(string storedProcedureName, List<SqlParameter> parameters, SqlTransaction transactionInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Connection = transactionInstance.Connection;
            _Command.Transaction = transactionInstance;
            _Command.Parameters.Clear();

            if (parameters != null)
            {
                foreach (SqlParameter parameterInstance in parameters)
                    _Command.Parameters.Add(parameterInstance);
            }


            int returnedInt = _Command.ExecuteNonQuery();

            //return back to using the object's connection
            _Command.Connection = _Connection;
            //don't bind to this transaction any more
            _Command.Transaction = null;

            return returnedInt;
        }

        /// <summary>
        /// Executes a stored procedure and returns the first column of the first row in the result set returned by
        /// the procedure
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters">List of parameters that will be passed to the stored procedure.</param>
        /// <returns></returns>
        protected object ExecuteScalar(string storedProcedureName, List<SqlParameter> parameters)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();

            if (parameters != null)
            {
                foreach (SqlParameter parameterInstance in parameters)
                    _Command.Parameters.Add(parameterInstance);
            }
            _Connection.Open();
            try
            {

                object returnedObject = _Command.ExecuteScalar();
                _Connection.Close();
                return returnedObject;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Executes a stored procedure that takes a single parameter and returns the first column of the first row in 
        /// the result set returned by the procedure
        /// </summary>
        protected object ExecuteScalar(string storedProcedureName, SqlParameter parameterInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();

            if (parameterInstance != null)
                _Command.Parameters.Add(parameterInstance);
            _Connection.Open();
            try
            {

                object returnedObject = _Command.ExecuteScalar();

                return returnedObject;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Executes a stored procedure that takes no parameters and returns the first column of the first row in 
        /// the result set returned by the procedure
        /// </summary>
        protected object ExecuteScalar(string storedProcedureName)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();
            _Connection.Open();
            try
            {

                object returnedObject = _Command.ExecuteScalar();

                return returnedObject;
            }
            finally
            {
                _Connection.Close();
            }
        }

        /// <summary>
        /// Executes a stored procedure that takes a single parameter and returns the number of rows affected
        /// </summary>
        protected object ExecuteScalar(string storedProcedureName, SqlParameter parameterInstance, SqlTransaction transactionInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Connection = transactionInstance.Connection;
            _Command.Transaction = transactionInstance;
            _Command.Parameters.Clear();

            if (parameterInstance != null)
                _Command.Parameters.Add(parameterInstance);

            object returnedObject = _Command.ExecuteScalar();

            //return back to using the object's connection
            _Command.Connection = _Connection;
            //don't bind to this transaction any more
            _Command.Transaction = null;

            return returnedObject;
        }

        /// <summary>
        /// Executes a stored procedure that takes a list of parameters and returns the number of rows affected
        /// </summary>
        protected object ExecuteScalar(string storedProcedureName, List<SqlParameter> parameters, SqlTransaction transactionInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Connection = transactionInstance.Connection;
            _Command.Transaction = transactionInstance;
            _Command.Parameters.Clear();

            if (parameters != null)
            {
                foreach (SqlParameter parameterInstance in parameters)
                    _Command.Parameters.Add(parameterInstance);
            }

            object returnedObject = _Command.ExecuteScalar();

            //return back to using the object's connection
            _Command.Connection = _Connection;
            //don't bind to this transaction any more
            _Command.Transaction = null;

            return returnedObject;
        }

        /// <summary>
        /// Executes a stored procedure that takes a single parameter and returns a datareader.
        /// </summary>

        protected SqlDataReader ExecuteReader(string storedProcedureName, SqlParameter parameterInstance)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();
            if (parameterInstance != null)
                _Command.Parameters.Add(parameterInstance);
            _Connection.Open();
            try
            {
                return _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _Connection.Close();
                //re throw the exception to be handled by higher classes
                throw ex;
            }
        }

        /// <summary>
        /// Executes a stored procedure that takes no parameters and returns a datareader.
        /// </summary>
        protected SqlDataReader ExecuteReader(string storedProcedureName)
        {
            _Command.CommandText = storedProcedureName;
            _Command.Parameters.Clear();
            _Connection.Open();
            try
            {
                return _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _Connection.Close();
                //re throw the exception to be handled by higher classes
                throw ex;
            }
        }

        /// <summary>
        /// Executes a stored procedure and returns a datareader.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters">List of parameters that will be passed to the stored procedure.</param>
        /// <returns></returns>
        /// <remarks>The connection will be closed automatically when the reader is closed</remarks>
        protected SqlDataReader ExecuteReader(string storedProcedureName, List<SqlParameter> parameters)
        {
            _Command.Parameters.Clear();
            if (parameters != null)
            {
                foreach (SqlParameter parameterInstance in parameters)
                    _Command.Parameters.Add(parameterInstance);
            }
            _Command.CommandText = storedProcedureName;
            _Connection.Open();
            try
            {
                return _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _Connection.Close();
                //re throw the exception to be handled by higher classes
                throw ex;
            }

        }

        /// <summary>
        /// Executes a stored procedure and returns a datareader.
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="parameters">List of parameters that will be passed to the stored procedure.</param>
        /// <returns></returns>
        /// <remarks>The connection will be closed automatically when the reader is closed</remarks>
        protected SqlDataReader ExecuteReader(string storedProcedureName, List<SqlParameter> parameters, SqlTransaction transactionInstance)
        {
            _Command.Parameters.Clear();
            if (parameters != null)
            {
                foreach (SqlParameter parameterInstance in parameters)
                    _Command.Parameters.Add(parameterInstance);
            }
            _Command.CommandText = storedProcedureName;
            _Command.Transaction = transactionInstance;
            _Command.Connection = transactionInstance.Connection;
            return _Command.ExecuteReader();
        }

        /// <summary>
        /// Executes a stored procedure and returns a datareader.
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameterInstance">parameter that will be passed to the stored procedure</param>
        /// <param name="transactionInstance">A transaction object that will be used to share this operation with another database operation</param>
        /// <returns></returns>
        protected SqlDataReader ExecuteReader(string storedProcedureName, SqlParameter parameterInstance, SqlTransaction transactionInstance)
        {
            _Command.Parameters.Clear();
            if (parameterInstance != null)
                _Command.Parameters.Add(parameterInstance);

            _Command.CommandText = storedProcedureName;
            _Command.Transaction = transactionInstance;
            _Command.Connection = transactionInstance.Connection;
            return _Command.ExecuteReader();
        }

        /// <summary>
        /// Executes a stored procedure and returns the result in a data set
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected DataSet GetDataSet(string storedProcedureName, List<SqlParameter> parameters)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = storedProcedureName;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                adapter.SelectCommand.Parameters.Add(parameter);
            }
            adapter.SelectCommand.Connection = _Connection;
            DataSet resultDataSet = new DataSet();
            adapter.Fill(resultDataSet );
            return resultDataSet;
        }


        /// <summary>
        /// Executes a stored procedure and returns the result in a data table
        /// </summary>
        protected DataTable GetTable(string storedProcedureName, List<SqlParameter> parameters)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = storedProcedureName;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                adapter.SelectCommand.Parameters.Add(parameter);
            }
            adapter.SelectCommand.Connection = _Connection;
            DataTable resultDataTable = new DataTable();
            adapter.Fill(resultDataTable);
            return resultDataTable;
        }

        /// <summary>
        /// Executes a stored procedure and returns the result in a data table
        /// </summary>
        protected DataTable GetTable(string storedProcedureName, SqlParameter parameter)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = storedProcedureName;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(parameter);
            adapter.SelectCommand.Connection = _Connection;
            DataTable resultDataTable = new DataTable();
            adapter.Fill(resultDataTable);
            return resultDataTable;
        }

        /// <summary>
        /// Executes a stored procedure and returns the result in a data table
        /// </summary>
        protected DataTable GetTable(string storedProcedureName, SqlParameter parameter, SqlTransaction transactionInstance)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = storedProcedureName;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(parameter);
            adapter.SelectCommand.Connection = transactionInstance.Connection;
            adapter.SelectCommand.Transaction = transactionInstance;
            DataTable resultDataTable = new DataTable();
            adapter.Fill(resultDataTable);
            return resultDataTable;
        }
        /// <summary>
        /// Executes a stored procedure and returns the result in a data table
        /// </summary>
        protected DataTable GetTable(string storedProcedureName)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = storedProcedureName;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Connection = _Connection;
            DataTable resultDataTable = new DataTable();
            adapter.Fill(resultDataTable);
            return resultDataTable;
        }

        /// <summary>
        /// Executes a stored procedure and returns the result in a data table
        /// </summary>
        /// <param name="storedProcedureName"></param>
        /// <param name="transactionInstance">A transaction object that will be used to share this operation with another database operation</param>
        /// <returns></returns>
        protected DataTable GetTable(string storedProcedureName, SqlTransaction transactionInstance)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand();
            adapter.SelectCommand.CommandText = storedProcedureName;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Connection = transactionInstance.Connection;
            adapter.SelectCommand.Transaction = transactionInstance;
            DataTable resultDataTable = new DataTable();
            adapter.Fill(resultDataTable);
            return resultDataTable;
        }
    }
}
