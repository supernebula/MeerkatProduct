using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace Nebula.FirstEC.WebSite.Core
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        ILog logerror = log4net.LogManager.GetLogger("logerror");

        //
        // 摘要:
        //     在派生类中重写时，将同步处理异常。
        //
        // 参数:
        //   context:
        //     异常处理程序上下文。
        public override void Handle(ExceptionHandlerContext context)
        {
            logerror.Error("NotImplementedException");
            //todo:具体异常处理类
            throw new NotImplementedException();

        }

        //
        // 摘要:
        //     确定是否应处理异常。
        //
        // 参数:
        //   context:
        //     异常处理程序上下文。
        //
        // 返回结果:
        //     如果应处理异常，则为 true；否则为 false。
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            return context.Exception is Error && base.ShouldHandle(context);
        }
    }
}
