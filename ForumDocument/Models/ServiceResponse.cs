using ForumDocument.Helpers.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Models
{
    public class ServiceResponse
    {
        public const string DEFAULT_ERRORMESSAGE = "Có lỗi trong quá trình xử lý";

        public bool Success { get; set; } = true;

        public ServiceResponseCode Code { get; set; } = ServiceResponseCode.Success;

        public object Data { get; set; }

        public string UserMessage { get; set; }

        public string SystemMessage { get; set; }

        public ServiceResponse OnSuccess(object data = null)
        {
            this.Data = data;
            return this;
        }

        public ServiceResponse OnExeption(Exception ex)
        {
            if (ex != null)
            {
                this.Success = false;
                this.Code = ServiceResponseCode.Error;
                this.UserMessage = DEFAULT_ERRORMESSAGE;
                this.SystemMessage = ex.Message;
            }

            return this;
        }
    }
}
