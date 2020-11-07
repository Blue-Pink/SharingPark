using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SharingPark.IBLL;
using SharingPark.IDAL;
using SharingPark.Model;
using SharingPark.Model.SPEntities;
using SqlSugar;

namespace SharingPark.BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL _userDal;
        private SqlSugarClient DbClient => MySqlSharingPark.GetInstance();

        public UserBLL()
        {
        }

        public UserBLL(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public List<SpUserInfo> ObtainSpUserInfo(Expression<Func<SpUserInfo, bool>> expression)
        {
            return DbClient.Queryable<SpUserInfo>().Where(expression).ToList();
        }
    }
}