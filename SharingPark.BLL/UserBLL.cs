using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BluePink.Framework.BPIOC;
using SharingPark.IBLL;
using SharingPark.IDAL;
using SharingPark.Model.SPMySQL;
using SqlSugar;

namespace SharingPark.BLL
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDal;

        [AppointConstructor]
        public UserBLL(IUserDAL userDal)
        {
            _userDal = userDal;
        }

        public SpUserInfo FindSpUserInfo(Expression<Func<SpUserInfo, bool>> exception)
        {
            return _userDal.FindSpUserInfo(exception);
        }

        public List<SpUserInfo> ObtainSpUserInfo(Expression<Func<SpUserInfo, bool>> expression)
        {
            return _userDal.ObtainSpUserInfo(expression);
        }

    }
}