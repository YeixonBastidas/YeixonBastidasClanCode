using Commun.Constant;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;

namespace WebAPI
{
    public static class Headers
    {
        public static ResultGameDTO GetUserByTokenHeader(HttpRequest httpRequest)
        {
            ResultGameDTO result = new ResultGameDTO();
            httpRequest.Headers.TryGetValue("UserId", out StringValues headerValues);
            var userId = headerValues[0];
            if (string.IsNullOrEmpty(userId))
            {
                result.IsError = true;
                result.Message = Messages.UserIdIsNUll;
                return result;
            }

            result.ResultObject = Convert.ToInt32(userId);
            return result;
        }
    }
}
