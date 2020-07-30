
using Commun.Constant;

namespace Entities.DTO
{
    public class ResultGameDTO
    {        
        public ResultGameDTO()
        {
            this.IsError = false;
            this.Message = Messages.MessageSuccessful;
        }

        public bool IsError { get; set; }
        public string Message { get; set; }
        public object ResultObject { get; set; }
    }
}
