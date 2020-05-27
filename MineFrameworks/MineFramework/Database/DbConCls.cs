﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace MineFramework
{
    public class DbConCls
    {
        public static string constring = string.Empty;
        public static string dbipaddr = string.Empty;
        public static string dbport = string.Empty;
        public static string dbname = string.Empty;
        public static string dbid = string.Empty;
        public static string dbpw = string.Empty;
        public string sqlitepath = string.Empty;

        protected static SqlConnection _conn;
        //protected SQLiteConnection _connlite;
        protected static OracleConnection _oraconn;

        public enum DatabaseType
        {
            MSSQL = 0,
            SQLITE = 1,
            ORACLE = 2,
            MYSQL = 3
        }

        /// <summary>
        /// Database Type
        /// Default : MS-SQL Server
        /// </summary>
        protected static DatabaseType _dbType = DatabaseType.MSSQL;

        /// <summary>
        /// Database 접속정보를 셋팅합니다.
        /// </summary>
        /// <param name="_dbip">Database IP Address</param>
        /// <param name="_dbport">Database Port</param>
        /// <param name="_dbname">Database Name</param>
        /// <param name="_dbid">Database connect id</param>
        /// <param name="_dbpw">Database connect pw</param>
        public static void constrSet(string _dbip, string _dbport, string _dbname, string _dbid, string _dbpw)
        {
            dbipaddr = _dbip;
            dbport = _dbport;
            dbname = _dbname;
            dbid = _dbid;
            dbpw = _dbpw;

            // Connection String Setting
            connectionString = "Data Source=" + dbipaddr + "," + dbport + ";Database=" + dbname + ";UID=" + dbid + ";PWD=" + dbpw + ";Connection Timeout=3600";
        }

        public void constrSet(string _sqlitepath)
        {
            sqlitepath = _sqlitepath;
        }

        public DatabaseType getDbType
        {
            get { return _dbType; }
            set { _dbType = value; }
        }

        public static string connectionString
        {
            get { return constring; }
            set { constring = value; }
        }
        
        public static SqlConnection connObject
        {
            get { return _conn; }
        }

        /// <summary>
        /// Database에 접속합니다. (Timeout 10초)
        /// </summary>
        /// <param name="constr">DB연결 String</param>
        /// <returns></returns>
        public static int Connect(string constr)
        {
            try
            {
                if (_dbType == DatabaseType.MSSQL)
                {
                    _conn = (SqlConnection)new SqlConnection();
                    if (string.IsNullOrEmpty(constr))
                    {
                        _conn.ConnectionString = "Data Source=" + dbipaddr + "," + dbport + ";Database=" + dbname + ";UID=" + dbid + ";PWD=" + dbpw + ";Connection Timeout=10";
                    }
                    else
                    {
                        _conn.ConnectionString = constr;
                    }                    
                    _conn.StateChange += _conn_StateChange;
                    _conn.Open();
                }
                else if (_dbType == DatabaseType.SQLITE)
                {
                    //_connlite = new SQLiteConnection("Data Source=" + sqlitepath + ";Version=3;");
                    //_connlite.StateChange += _connlite_StateChange;
                    //_connlite.Open();
                }
                else if (_dbType == DatabaseType.ORACLE)
                {
                    //_oraconn = new OracleConnection($"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={dbipaddr})(PORT={dbport})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={dbname})));User ID={dbid};Password={dbpw};Connection Timeout=30;");
                    //_oraconn.Open();
                }

                LogCls.writeLog("", "ConnLog.log", "DatabaseType : " + _dbType + " | DatabaseIp : " + dbipaddr + " | Connection Complete(" + DateTime.Now.ToString() + ")");

                return 0;
            }
            catch(Exception ex)
            {
                LogCls.writeLog("", "ConnLog.log", "DatabaseType : " + _dbType + " | DatabaseIp : " + dbipaddr + " | Connection Fail(" + DateTime.Now.ToString() + ") | Reason : " + ex.Message);

                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    // Connection 객체연결 닫기
                    _conn.Close();

                    // Connection 객체연결 삭제
                    _conn.Dispose();
                }

                return 99;
            }
            finally
            {
                
            }
        }

        public static SqlConnection MultiConnect(string constr)
        {
            if (string.IsNullOrEmpty(constr))
            {
                return null;
            }

            SqlConnection mConn = (SqlConnection)new SqlConnection();

            try
            {
                if (_dbType == DatabaseType.MSSQL)
                {                    
                    mConn.ConnectionString = constr;
                    mConn.StateChange += mConn_StateChange;
                    mConn.Open();

                    return mConn;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                LogCls.writeLog("", "ConnLog.log", "DatabaseType : " + _dbType + " | DatabaseIp : " + dbipaddr + " | Connection Fail(" + DateTime.Now.ToString() + ") | Reason : " + ex.Message);

                if (mConn.State == System.Data.ConnectionState.Open)
                {
                    // Connection 객체연결 닫기
                    mConn.Close();

                    // Connection 객체연결 삭제
                    mConn.Dispose();
                }

                return null;
            }
        }

        private static void mConn_StateChange(object sender, StateChangeEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void _connlite_StateChange(object sender, StateChangeEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void _conn_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #region 조회쿼리를 실행합니다. (MSsqlQueryExec)
        /// <summary>
        /// MS-SQL Query를 실행합니다.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet MSsqlQueryExec(string query)
        {
            DataSet sData = new DataSet();
            SqlDataAdapter myCmdUser = new SqlDataAdapter();
            SqlCommand cmd = _conn.CreateCommand();

            try
            {
                cmd.CommandText = query;
                cmd.CommandTimeout = 10000;
                myCmdUser.SelectCommand = cmd;
                myCmdUser.Fill(sData);
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                myCmdUser.Dispose();
                cmd.Dispose();
            }

            return sData;
        }
        #endregion

        #region 조회쿼리를 실행합니다. (MSsqlQueryExec) - Connection받는버전
        /// <summary>
        /// MS-SQL Query를 실행합니다.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static DataSet MSsqlQueryExec(SqlConnection _connlocal, string query)
        {
            DataSet sData = new DataSet();
            SqlDataAdapter myCmdUser = new SqlDataAdapter();
            SqlCommand cmd = _connlocal.CreateCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 10000;
            myCmdUser.SelectCommand = cmd;
            myCmdUser.Fill(sData);

            return sData;
        }
        #endregion

        #region 실행쿼리를 실행합니다. (ExecuteNonQuery) - 파라미터1개
        /// <summary>
        /// 실행(저장, 삭제, 수정)용 쿼리를 실행합니다.
        /// </summary>
        /// <param name="szQuery">쿼리를 받습니다.</param>
        /// <returns>
        /// 쿼리없는경우 : 7
        /// 데이터베이스연결실패 : 1
        /// 성공 : 0
        /// 예외오류 : 9
        /// </returns>
        public static int ExecuteNonQuery(string szQuery)
        {
            DbCommand dcd = null;

            try
            {
                dcd = _conn.CreateCommand();

                // 트랜잭션을 시작합니다.
                dcd.Transaction = _conn.BeginTransaction();

                // DB TimeOut은 3분으로 셋팅
                dcd.CommandTimeout = 180;
                dcd.CommandText = szQuery;
                int sRow = dcd.ExecuteNonQuery();

                // 트랜잭션을 커밋합니다.
                dcd.Transaction.Commit();

                return 0;

            }
            catch (Exception ex)
            {
                // 트랜잭션을 RollBack 합니다.
                //dcd.Transaction.Rollback();

                return 9;
            }
            finally
            {
                // DB커넥션을 종료합니다.
                //dcd.Dispose();
            }
        }
        #endregion 

        #region 실행쿼리를 실행합니다. (ExecuteNonQuery) - 파라미터1개
        /// <summary>
        /// 실행(저장, 삭제, 수정)용 쿼리를 실행합니다.
        /// </summary>
        /// <param name="szQuery">쿼리를 받습니다.</param>
        /// <returns>
        /// 쿼리없는경우 : 7
        /// 데이터베이스연결실패 : 1
        /// 성공 : 0
        /// 예외오류 : 9
        /// </returns>
        public static int ExecuteNonQuery(string szQuery, out string rmsg)
        {
            DbCommand dcd = null;

            try
            {
                dcd = _conn.CreateCommand();

                // 트랜잭션을 시작합니다.
                //dcd.Transaction = conn.BeginTransaction();
                // DB TimeOut은 3분으로 셋팅
                dcd.CommandTimeout = 180;
                dcd.CommandText = szQuery;
                int sRow = dcd.ExecuteNonQuery();

                // 트랜잭션을 커밋합니다.
                //dcd.Transaction.Commit();

                rmsg = "";
                return 0;

            }
            catch (Exception ex)
            {
                // 트랜잭션을 RollBack 합니다.
                //dcd.Transaction.Rollback();

                rmsg = ex.Message;
                return 9;
            }
            finally
            {
                // DB커넥션을 종료합니다.
                //dcd.Dispose();
            }
        }
        #endregion 

        #region 실행쿼리를 실행합니다. (ExecuteNonQuery) - 파라미터 2개
        /// <summary>
        /// 실행(저장, 삭제, 수정)용 쿼리를 실행합니다.
        /// </summary>
        /// <param name="szQuery">쿼리를 받습니다.</param>
        /// <returns>
        /// 쿼리없는경우 : 7
        /// 데이터베이스연결실패 : 1
        /// 성공 : 0
        /// 예외오류 : 9
        /// </returns>
        public static int ExecuteNonQuery(SqlConnection _conn, string szQuery, out string rmsg)
        {
            DbCommand dcd = null;

            try
            {
                dcd = _conn.CreateCommand();

                // 트랜잭션을 시작합니다.
                //dcd.Transaction = conn.BeginTransaction();
                // DB TimeOut은 3분으로 셋팅
                dcd.CommandTimeout = 180;
                dcd.CommandText = szQuery;
                int sRow = dcd.ExecuteNonQuery();

                // 트랜잭션을 커밋합니다.
                //dcd.Transaction.Commit();

                rmsg = "";
                return 0;

            }
            catch (Exception ex)
            {
                // 트랜잭션을 RollBack 합니다.
                //dcd.Transaction.Rollback();

                rmsg = ex.Message;
                return 9;
            }
            finally
            {
                // DB커넥션을 종료합니다.
                //dcd.Dispose();
            }
        }
        #endregion
    }
}
