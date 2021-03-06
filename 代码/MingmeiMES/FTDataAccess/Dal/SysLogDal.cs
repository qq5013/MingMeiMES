﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using FTDataAccess.DBUtility;//Please add references
namespace FTDataAccess.DAL
{
    /// <summary>
    /// 数据访问类:SysLog
    /// </summary>
    public partial class SysLogDal
    {
        public SysLogDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(FTDataAccess.Model.SysLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SysLog(");
            strSql.Append("LogContent,LogTime,LogLevel,LogSourceObject,LogSourceModule)");
            strSql.Append(" values (");
            strSql.Append("@LogContent,@LogTime,@LogLevel,@LogSourceObject,@LogSourceModule)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LogContent", SqlDbType.NVarChar,1000),
					new SqlParameter("@LogTime", SqlDbType.DateTime),
					new SqlParameter("@LogLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@LogSourceObject", SqlDbType.NVarChar,50),
					new SqlParameter("@LogSourceModule", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.LogContent;
            parameters[1].Value = model.LogTime;
            parameters[2].Value = model.LogLevel;
            parameters[3].Value = model.LogSourceObject;
            parameters[4].Value = model.LogSourceModule;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FTDataAccess.Model.SysLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SysLog set ");
            strSql.Append("LogContent=@LogContent,");
            strSql.Append("LogTime=@LogTime,");
            strSql.Append("LogLevel=@LogLevel,");
            strSql.Append("LogSourceObject=@LogSourceObject,");
            strSql.Append("LogSourceModule=@LogSourceModule");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogContent", SqlDbType.NVarChar,1000),
					new SqlParameter("@LogTime", SqlDbType.DateTime),
					new SqlParameter("@LogLevel", SqlDbType.NVarChar,50),
					new SqlParameter("@LogSourceObject", SqlDbType.NVarChar,50),
					new SqlParameter("@LogSourceModule", SqlDbType.NVarChar,50),
					new SqlParameter("@LogID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.LogContent;
            parameters[1].Value = model.LogTime;
            parameters[2].Value = model.LogLevel;
            parameters[3].Value = model.LogSourceObject;
            parameters[4].Value = model.LogSourceModule;
            parameters[5].Value = model.LogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long LogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysLog ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.BigInt)
			};
            parameters[0].Value = LogID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string LogIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SysLog ");
            strSql.Append(" where LogID in (" + LogIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FTDataAccess.Model.SysLog GetModel(long LogID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 LogID,LogContent,LogTime,LogLevel,LogSourceObject,LogSourceModule from SysLog ");
            strSql.Append(" where LogID=@LogID");
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.BigInt)
			};
            parameters[0].Value = LogID;

            FTDataAccess.Model.SysLog model = new FTDataAccess.Model.SysLog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FTDataAccess.Model.SysLog DataRowToModel(DataRow row)
        {
            FTDataAccess.Model.SysLog model = new FTDataAccess.Model.SysLog();
            if (row != null)
            {
                if (row["LogID"] != null && row["LogID"].ToString() != "")
                {
                    model.LogID = long.Parse(row["LogID"].ToString());
                }
                if (row["LogContent"] != null)
                {
                    model.LogContent = row["LogContent"].ToString();
                }
                if (row["LogTime"] != null && row["LogTime"].ToString() != "")
                {
                    model.LogTime = DateTime.Parse(row["LogTime"].ToString());
                }
                if (row["LogLevel"] != null)
                {
                    model.LogLevel = row["LogLevel"].ToString();
                }
                if (row["LogSourceObject"] != null)
                {
                    model.LogSourceObject = row["LogSourceObject"].ToString();
                }
                if (row["LogSourceModule"] != null)
                {
                    model.LogSourceModule = row["LogSourceModule"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select LogID as 日志ID,LogContent as 内容,LogLevel as 类别,LogSourceObject as 日志来源,LogTime as 时间");
            strSql.Append(" FROM SysLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

      

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SysLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
       

        
         ///<summary>
         ///分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize, int PageIndex, string strWhere, int Asc)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@currPage", SqlDbType.Int),
                    new SqlParameter("@showColumn",SqlDbType.VarChar,255),
                    new SqlParameter("@tabName", SqlDbType.VarChar, 255),
                    new SqlParameter("@strCondition", SqlDbType.VarChar,1000),
                    new SqlParameter("@ascColumn",SqlDbType.VarChar,255),
                    new SqlParameter("@bitOrderType", SqlDbType.Bit),
                    new SqlParameter("@pkColumn", SqlDbType.VarChar, 255),
                    new SqlParameter("@pageSize", SqlDbType.Int)
                    };
            parameters[0].Value = PageIndex;//"SysLog";
            parameters[1].Value = "LogID as 日志ID,LogContent as 内容,LogLevel as 类别,LogSourceObject as 日志来源,LogTime as 时间";
            parameters[2].Value = "SysLog";
            parameters[3].Value = strWhere;
            parameters[4].Value = "LogTime";
            parameters[5].Value = Asc;
            parameters[6].Value = "LogID";
            parameters[7].Value = PageSize;
            return DbHelperSQL.RunProcedure("prcPageResult", parameters,  "SysLog");
        }
        
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList2(int PageSize,int PageIndex,string strWhere)
        //{
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@fldName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@PageSize", SqlDbType.Int),
        //            new SqlParameter("@PageIndex", SqlDbType.Int),
        //            new SqlParameter("@IsReCount", SqlDbType.Bit),
        //            new SqlParameter("@OrderType", SqlDbType.Bit),
        //            new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
        //            };
        //    parameters[0].Value = "SysLog";
        //    parameters[1].Value = "LogID";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;
        //    return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "SysLog");
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


