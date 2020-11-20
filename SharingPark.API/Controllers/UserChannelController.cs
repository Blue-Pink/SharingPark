using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharingPark.BLL;
using SharingPark.DAL;
using SharingPark.IBLL;

namespace SharingPark.API.Controllers
{
    [Route("api/UserChannel")]
    [ApiController]
    public class UserChannelController : BaseController
    {
        private IUserBLL _userBLL;

        public UserChannelController(ILogger logger, IUserBLL userBLL) : base(logger)
        {
            _userBLL = userBLL;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("ObtainSpUserInfo")]
        public dynamic ObtainSpUserInfo()
        {
            try
            {
                return new
                {
                    result
                };
            }
            catch (Exception e)
            {
                return ErrorResult(e);
            }
        }
    }
}
