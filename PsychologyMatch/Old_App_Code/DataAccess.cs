using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace PsychMatch
{
    public class DAOObject
    {
        //private String _ConnectionName;

        //public DAOObject()
        //{
        //}

        //public DAOObject(string ConnectionName)
        //{
        //    _ConnectionName = ConnectionName;
        //}

        //private SqlConnection GetConnection()
        //{
        //    try
        //    {
        //        SqlConnection ret_conn;

        //        if (_ConnectionName == null)
        //        {
        //            ret_conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnOAAADB"].ConnectionString);
        //        }
        //        else
        //        {
        //            ret_conn = new SqlConnection(_ConnectionName);
        //        }
        //        ret_conn.Open();
        //        return ret_conn;
        //    }
        //    catch (Exception e)
        //    {
        //        HttpContext.Current.Response.Write(e.Message);
        //        HttpContext.Current.Response.End();
        //        return null;
        //    }
        //}

        //private void CloseConnection(SqlConnection conn)
        //{
        //    conn.Close();
        //    conn = null;
        //}

        //public void RunSPReturnNothing(string strSP, params SqlParameter[] commandParameters)
        //{
        //    SqlConnection cn = GetConnection();

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(strSP, cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        foreach (SqlParameter p in commandParameters)
        //        {
        //            cmd.Parameters.Add(p);
        //            p.Direction = ParameterDirection.Input;
        //        }

        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (SqlException e)
        //    {
        //        CloseConnection(cn);
        //        HttpContext.Current.Response.Write(DisplaySqlErrors(e));
        //        HttpContext.Current.Response.End();
        //    }
        //    finally
        //    {
        //        CloseConnection(cn);
        //    }
        //}

        //public object ExecuteScalar(SqlCommand comm)
        //{
        //    SqlConnection cn = GetConnection();
        //    comm.Connection = cn;
        //    comm.Connection.Open();

        //    return comm.ExecuteScalar();
        //}

        //public SqlDataReader RunPassSQL(string strSQL)
        //{
        //    SqlDataReader rdr = default(SqlDataReader);
        //    try
        //    {
        //        SqlConnection cn = GetConnection();
        //        SqlCommand cmd = new SqlCommand(strSQL, cn);
        //        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Dispose();
        //    }
        //    catch (SqlException e)
        //    {
        //        HttpContext.Current.Response.Write(DisplaySqlErrors(e));
        //        HttpContext.Current.Response.End();
        //    }
        //    return rdr;
        //}

        //public void RunActionQuery(string strSQL)
        //{
        //    SqlConnection cn = GetConnection();
        //    SqlCommand cmd = new SqlCommand(strSQL, cn);

        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        cmd.Dispose();
        //    }
        //    catch (SqlException e)
        //    {
        //        CloseConnection(cn);
        //        HttpContext.Current.Response.Write(DisplaySqlErrors(e));
        //        HttpContext.Current.Response.End();
        //    }
        //    finally
        //    {
        //        CloseConnection(cn);
        //    }
        //}

        //public DataTable RunSQLReturnDataTable(string strSQL, string DataTableName)
        //{
        //    SqlDataReader rdr = default(SqlDataReader);
        //    try
        //    {
        //        SqlConnection cn = GetConnection();
        //        SqlCommand cmd = new SqlCommand(strSQL, cn);
        //        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Dispose();
        //    }
        //    catch (SqlException e)
        //    {
        //        HttpContext.Current.Response.Write(DisplaySqlErrors(e));
        //        HttpContext.Current.Response.End();
        //    }

        //    DataTable dt = new DataTable(DataTableName);
        //    dt.Load(rdr);
        //    return dt;
        //}

        //public DataTable RunSPReturnDataTable(string strSP, string DataTableName, params SqlParameter[] commandParameters)
        //{
        //    SqlConnection cn = GetConnection();
        //    SqlDataReader rdr = null;

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(strSP, cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        foreach (SqlParameter p in commandParameters)
        //        {
        //            cmd.Parameters.Add(p);
        //            p.Direction = ParameterDirection.Input;
        //        }

        //        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Dispose();
        //    }
        //    catch (SqlException e)
        //    {
        //        HttpContext.Current.Response.Write(DisplaySqlErrors(e));
        //        HttpContext.Current.Response.End();
        //    }

        //    DataTable dt = new DataTable(DataTableName);
        //    dt.Load(rdr);
        //    return dt;
        //}

        //public DataSet RunSPReturnDataSet(string strSP, string DataTableName)
        //{
        //    SqlConnection cn = GetConnection();
        //    DataSet ds = new DataSet();

        //    SqlDataAdapter da = new SqlDataAdapter(strSP, cn);
        //    da.Fill(ds, DataTableName);

        //    CloseConnection(cn);
        //    da.Dispose();

        //    return ds;
        //}

        //public DataSet RunSQLReturnDataSet(string strSQL, string DataTableName)
        //{
        //    SqlConnection cn = GetConnection();
        //    DataSet ds = new DataSet();

        //    SqlDataAdapter da = new SqlDataAdapter(strSQL, cn);
        //    da.Fill(ds, DataTableName);

        //    CloseConnection(cn);
        //    da.Dispose();

        //    return ds;
        //}

        //public DataSet RunSPReturnDataSet(string strSP, string DataTableName, params SqlParameter[] commandParameters)
        //{
        //    SqlConnection cn = GetConnection();
        //    DataSet ds = new DataSet();

        //    SqlDataAdapter da = new SqlDataAdapter(strSP, cn);
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    foreach (SqlParameter p in commandParameters)
        //    {
        //        da.SelectCommand.Parameters.Add(p);
        //        p.Direction = ParameterDirection.Input;
        //    }

        //    da.Fill(ds, DataTableName);

        //    CloseConnection(cn);
        //    da.Dispose();

        //    return ds;
        //}

        //public SqlDataReader RunSPReturnRS(string strSP, params SqlParameter[] commandParameters)
        //{
        //    SqlConnection cn = GetConnection();
        //    SqlDataReader rdr = null;

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(strSP, cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        foreach (SqlParameter p in commandParameters)
        //        {
        //            cmd.Parameters.Add(p);
        //            p.Direction = ParameterDirection.Input;
        //        }

        //        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        //        cmd.Dispose();
        //    }
        //    catch (SqlException)
        //    {
        //        // HttpContext.Current.Response.Write("Sorry, there was an error connecting to the database.");
        //        // HttpContext.Current.Response.End();
        //    }

        //    return rdr;
        //}

        //public int RunSPReturnInteger(string strSP, params SqlParameter[] commandParameters)
        //{
        //    SqlConnection cn = GetConnection();
        //    int retVal = 0;

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(strSP, cn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter p = null;

        //        foreach (var tmp in commandParameters)
        //        {
        //            p = tmp;
        //            cmd.Parameters.Add(p);
        //            p.Direction = ParameterDirection.Input;
        //        }

        //        p = cmd.Parameters.Add(new SqlParameter("@RetVal", SqlDbType.Int));
        //        p.Direction = ParameterDirection.Output;

        //        cmd.ExecuteNonQuery();
        //        retVal = Convert.ToInt32(cmd.Parameters["@RetVal"].Value);
        //        cmd.Dispose();
        //    }
        //    catch (SqlException e)
        //    {
        //        HttpContext.Current.Response.Write("Sorry, there was an error connecting to the database.");
        //        HttpContext.Current.Response.Write(e.Message);
        //        HttpContext.Current.Response.End();
        //    }
        //    finally
        //    {
        //        CloseConnection(cn);
        //    }

        //    return retVal;
        //}

        //public void AddDataTableToDataSet(string strSP, string DataTableName, DataSet DS, params SqlParameter[] commandParameters)
        //{
        //    //Allows us to add new DataTables to an exisiting DataSet
        //    SqlConnection cn = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter(strSP, cn);

        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    SqlParameter p = null;

        //    foreach (var tmp in commandParameters)
        //    {
        //        p = tmp;
        //        da.SelectCommand.Parameters.Add(p);
        //        p.Direction = ParameterDirection.Input;
        //    }

        //    da.Fill(DS, DataTableName);

        //    CloseConnection(cn);
        //    da.Dispose();
        //}

        //public void AddDataTableToDataSet(string strSP, string DataTableName, DataSet DS)
        //{
        //    //Allows us to add new DataTables to an exisiting DataSet
        //    SqlConnection cn = GetConnection();
        //    SqlDataAdapter da = new SqlDataAdapter(strSP, cn);

        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;

        //    da.Fill(DS, DataTableName);

        //    CloseConnection(cn);
        //    da.Dispose();
        //}

        //public static string DisplaySqlErrors(SqlException myException)
        //{
        //    int i = 0;
        //    string ErrorReturn = string.Empty;

        //    for (i = 0; i <= myException.Errors.Count - 1; i++)
        //    {
        //        ErrorReturn += myException.Errors[i].ToString() + ", <br>";
        //    }

        //    return ErrorReturn;
        //}
    }
}