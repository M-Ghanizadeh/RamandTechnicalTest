using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Api
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public StatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class ApiResult<TData> : ApiResult
    {
        public TData Data { get; set; }
    }

    public enum StatusCode
    {
        Success = 1,
        BadRequest = 2,
        ServerError = 3,
        NotFound = 4,
        NotAuothorized = 5,
        ListEmpty = 6,
    }
}
