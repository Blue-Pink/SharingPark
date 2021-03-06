using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SharingPark.Model;
using SharingPark.Model.SPMySQL;

namespace SharingPark.IBLL
{
    public interface IUserBLL
    {
        public SpUserInfo FindSpUserInfo(Expression<Func<SpUserInfo, bool>> exception);

        public List<SpUserInfo> ObtainSpUserInfo(Expression<Func<SpUserInfo, bool>> expression);

    }
}