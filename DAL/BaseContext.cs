using Commun.Constant;
using System;

namespace DAL
{    
    public static class BaseContext
    {     
        public static string GetParameterConnection()
        {
            return Environment.GetEnvironmentVariable(Constant.DataBaseModel) ?? Environment.GetEnvironmentVariable(Constant.DataBaseModel, EnvironmentVariableTarget.Machine);
        }
    }
}
