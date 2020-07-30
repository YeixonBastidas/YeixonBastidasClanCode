using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class ResultGameDTO
    {        
        public ResultGameDTO()
        {
            this.IsError = false;
            this.Message = string.Empty;
        }

        public bool IsError { get; set; }
        public string Message { get; set; }
        public object ResultObject { get; set; }
    }
}
