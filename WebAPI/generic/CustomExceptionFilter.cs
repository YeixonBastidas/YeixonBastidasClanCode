using Commun.Constant;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.generic
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger logger = Log.ForContext<ExceptionContext>();
        public override void OnException(ExceptionContext context)
        {
            ResultGameDTO result = new ResultGameDTO
            {
                IsError = true,
                Message = Constant.MsgGeneralAplicationError
            };

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.ExceptionHandled = true;
            context.Result = new JsonResult(result);
            logger.Error(context.Exception.Message);
            base.OnException(context);
        }
    }
}
