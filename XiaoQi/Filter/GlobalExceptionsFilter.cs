
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XiaoQi.Filter
{
    public class GlobalExceptionsFilter : IExceptionFilter
    {

        private readonly IWebHostEnvironment _env;
   
        private readonly ILogger<GlobalExceptionsFilter> _loggerHelper;

        public GlobalExceptionsFilter(IWebHostEnvironment env, ILogger<GlobalExceptionsFilter> loggerHelper)
        {
            _env = env;
            _loggerHelper = loggerHelper;
          
        }

        public void OnException(ExceptionContext context)
        {
        
            if (_env.IsDevelopment())
            {
             
                Log4NetHelper.Error("Debug:"+context.Exception.StackTrace, null);
            }
            else
            {
                Log4NetHelper.Error("Real:"+context.Exception.StackTrace, null);
               
            }
        }
    }
}
