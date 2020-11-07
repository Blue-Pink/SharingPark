using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;

namespace SharingPark.Model.SQLServerTest
{
    public class SQLServerTest
    {
        private SqlSugarClient db;
        public SqlSugarClient Db => db ??= GetInstance();

        //创建SqlSugarClient 
        private SqlSugarClient GetInstance()
        {
            //创建数据库对象
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=139.129.237.90;database=CloudPlatFormUserData;uid=chfl;pwd=chfl;",//连接符字串
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute//从特性读取主键自增信息
            });

            //添加Sql打印事件，开发中可以删掉这个代码
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };
            return db;
        }

    }
}
