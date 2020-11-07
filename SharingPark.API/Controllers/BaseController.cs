using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SharingPark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ILogger Logger;

        public BaseController(ILogger logger)
        {
            Logger = logger;
        }

        protected dynamic ErrorResult(Exception exception)
        {
            var stackTrace = new System.Diagnostics.StackTrace(true).GetFrame(1);
            //todo 记录错误日志 Controller/Action - Time : exception
            Logger.LogError($"{stackTrace.GetMethod().DeclaringType.Name}/{stackTrace.GetMethod().Name} - {DateTime.Now} : {exception}");
            return new
            {
                data = exception.Message,
                msg = "程序出现异常!请联系管理员!",
            };
        }
    }
}
