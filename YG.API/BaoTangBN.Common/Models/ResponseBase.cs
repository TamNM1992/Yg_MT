using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Common.Models
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = ErrorCodeMessage.Success.Value;
            Code = ErrorCodeMessage.Success.Key;
        }
        public int Count { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }

        public bool IsSuccessful => Code == ErrorCodeMessage.Success.Key;

        public object Data { get; set; }
    }
}
