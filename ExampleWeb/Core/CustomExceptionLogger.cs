using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Services.Description;
using log4net;

namespace ExampleWeb.Core
{
    /// <summary>
    /// 全局错误日志记录， 可以多个
    /// </summary>
    public class CustomExceptionLogger : ExceptionLogger
    {
        //
        // 摘要:
        //     在派生类中重写时，将同步记录异常。
        //
        // 参数:
        //   context:
        //     异常记录器上下文。
        public override void Log(ExceptionLoggerContext context)
        {
            ILog log = log4net.LogManager.GetLogger("error");
            log.Error(new Exception("测试异常"));
            //todo:具体日志记录逻辑
            throw new NotImplementedException();
        }


        //
        // 摘要:
        //     确定是否应记录异常。
        //
        // 参数:
        //   context:
        //     异常记录器上下文。
        //
        // 返回结果:
        //     如果应记录异常，则为 true；否则为 false。
        public override bool ShouldLog(ExceptionLoggerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            return context.Exception is Error && base.ShouldLog(context);
        }
    }
}
