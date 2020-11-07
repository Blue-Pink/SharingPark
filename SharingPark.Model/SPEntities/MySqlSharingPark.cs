using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SharingPark.Model.SPEntities
{
    public class MySqlSharingPark
    {
        //创建SqlSugarClient 
        public static SqlSugarClient GetInstance()
        {
            //创建数据库对象
            var sqlSugarClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=localhost:3306;Database=sharing_park;Uid=root;Pwd=123456;",//连接符字串
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute//从特性读取主键自增信息
            });

            //添加Sql打印事件，开发中可以删掉这个代码
            //sqlSugarClient.Aop.OnLogExecuting = (sql, pars) =>
            //{
            //    Console.WriteLine(sql + "\r\n" + sqlSugarClient.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
            //    Console.WriteLine();
            //};
            return sqlSugarClient;
        }

    }
}
