using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SharingPark.IDAL;
using SharingPark.Model;
using SharingPark.Model.SPMySQL;

namespace SharingPark.DAL
{
    public class UserDAL : BaseDAL,IUserDAL
    {
        public SpUserInfo FindSpUserInfo(Expression<Func<SpUserInfo, bool>> exception)
        {
            throw new NotImplementedException();
        }

        public List<SpUserInfo> ObtainSpUserInfo(Expression<Func<SpUserInfo, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
