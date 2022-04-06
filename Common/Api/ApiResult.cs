using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public ApiResult(bool isSuccess, StatusCode statusCode, string message = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Message = message;
        }

        #region Implicit Operators
        public static implicit operator ApiResult(OkResult result)
        {
            return new ApiResult(true, StatusCode.Success, "عملیات با موفقیت انجام شد");
        }
        public static implicit operator ApiResult(BadRequestResult result)
        {
            return new ApiResult(false, StatusCode.BadRequest, "پارامتر های ارسالی معتبر نیستند");
        }
        public static implicit operator ApiResult(NotFoundResult result)
        {
            return new ApiResult(false, StatusCode.NotFound, "یافت نشد");
        }
        public static implicit operator ApiResult(EmptyResult result)
        {
            return new ApiResult(false, StatusCode.ListEmpty, "لیست خالی است");
        }
        public static implicit operator ApiResult(UnauthorizedResult result)
        {
            return new ApiResult(false, StatusCode.UnAuthorized, "خطای احراز هویت");
        }
        #endregion

    }

    public class ApiResult<TData> : ApiResult
        where TData : class
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public TData Data { get; set; }

        public ApiResult(bool isSuccess, StatusCode statusCode, TData data, string message = null)
            : base(isSuccess, statusCode, message)
        {
            Data = data;
        }

        #region Implicit Operators
        public static implicit operator ApiResult<TData>(TData data)
        {
            return new ApiResult<TData>(true, StatusCode.Success, data, "عملیات با موفقیت انجام شد");
        }
        public static implicit operator ApiResult<TData>(BadRequestResult result)
        {
            return new ApiResult<TData>(false, StatusCode.BadRequest, null, "پارامتر های ارسالی معتبر نیستند");
        }
        public static implicit operator ApiResult<TData>(NotFoundResult result)
        {
            return new ApiResult<TData>(false, StatusCode.NotFound, null, "یافت نشد");
        }
        public static implicit operator ApiResult<TData>(EmptyResult result)
        {
            return new ApiResult<TData>(false, StatusCode.ListEmpty, null, "لیست خالی است");
        }
        public static implicit operator ApiResult<TData>(UnauthorizedResult result)
        {
            return new ApiResult<TData>(false, StatusCode.UnAuthorized, null, "خطای احراز هویت");
        }
        #endregion
    }

    public enum StatusCode
    {
        Success = 1,
        BadRequest = 2,
        ServerError = 3,
        NotFound = 4,
        UnAuthorized = 5,
        ListEmpty = 6,
    }
}
