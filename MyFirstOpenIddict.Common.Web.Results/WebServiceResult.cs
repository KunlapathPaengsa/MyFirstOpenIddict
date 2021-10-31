using MyFirstOpenIddictCommon.Web.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstOpenIddict.Common.Web.Results
{
        public class WebServiceResult<T>
    {
        public virtual bool IsSuccess { get; set; }
        public virtual T Data { get; set; }
        public virtual List<ErrorResponseResult> Errors { get; set; }
        public Guid? TransactionId { get; set; }

        public WebServiceResult()
        { }

        public WebServiceResult(bool isSuccess) : this(isSuccess, default(T), default(List<ErrorResponseResult>))
        {
        }

        public WebServiceResult(List<ErrorResponseResult> errors)
            : this(false, default(T), errors)
        { }

        public WebServiceResult(ErrorResponseResult error)
            : this(false, default(T), new List<ErrorResponseResult> { error })
        { }

        public WebServiceResult(Exception exception) : this(new ErrorResponseResult
        {
            Id = nameof(Exception),
            Code = nameof(Exception),
        })
        { }

        public WebServiceResult(bool isSuccess, T data)
            : this(isSuccess, data, default(List<ErrorResponseResult>))
        { }

        public WebServiceResult(bool isSuccess, List<ErrorResponseResult> errors)
            : this(isSuccess, default(T), errors)
        { }

        public WebServiceResult(bool isSuccess, ErrorResponseResult error)
            : this(isSuccess, default(T), new List<ErrorResponseResult> { error })
        { }

        public WebServiceResult(bool isSuccess, T data, ErrorResponseResult error)
            : this(isSuccess, data, new List<ErrorResponseResult> { error })
        { }

        public WebServiceResult(Guid transactionId, T data)
           : this(true, data, null, transactionId)
        { }

        public WebServiceResult(Guid transactionId, string errorMessage)
            : this(false, default(T), new List<ErrorResponseResult> { new ErrorResponseResult { Message = errorMessage } }, transactionId)
        { }

        public WebServiceResult(bool isSuccess, T data, List<ErrorResponseResult> errors, Guid? transactionId = null)
        {
            IsSuccess = isSuccess;
            Data = data;
            Errors = errors;
            TransactionId = transactionId;
        }

        #region Initial class with ErrorMessageResult
        public WebServiceResult(bool isSuccess, ErrorMessageResult messageResult)
            : this(isSuccess, new List<ErrorMessageResult> { messageResult })
        { }

        public WebServiceResult(bool isSuccess, List<ErrorMessageResult> messageResults)
            : this(isSuccess, default(T), messageResults.Select(s => new ErrorResponseResult
            {
                Code = s.Code,
                Id = s.RowKey,
                Message = s.Message
            }).ToList())
        { }

        public WebServiceResult(ErrorMessageResult messageResult)
            : this(new List<ErrorMessageResult> { messageResult })
        { }

        public WebServiceResult(List<ErrorMessageResult> messageResults)
            : this(messageResults.Select(s => new ErrorResponseResult
            {
                Code = s.Code,
                Id = s.RowKey,
                Message = s.Message
            }).ToList())
        { }
        #endregion
    }

    public class WebServiceResult : WebServiceResult<object>
    {
        public WebServiceResult()
        { }

        public WebServiceResult(bool isSuccess) : base(isSuccess, default(object), default(List<ErrorResponseResult>))
        {

        }

        public WebServiceResult(bool isSuccess, object data)
            : base(isSuccess, data, default(List<ErrorResponseResult>))
        { }

        public WebServiceResult(List<ErrorResponseResult> errors)
            : this(false, default(object), errors)
        { }

        public WebServiceResult(ErrorResponseResult error)
            : this(false, default(object), new List<ErrorResponseResult> { error })
        { }

        public WebServiceResult(Exception exception) : base(exception)
        { }

        public WebServiceResult(bool isSuccess, List<ErrorResponseResult> errors)
            : base(isSuccess, default(object), errors)
        { }

        public WebServiceResult(bool isSuccess, ErrorResponseResult error)
            : base(isSuccess, default(object), new List<ErrorResponseResult> { error })
        { }

        public WebServiceResult(bool isSuccess, object data, ErrorResponseResult error)
            : base(isSuccess, data, new List<ErrorResponseResult> { error })
        { }

        public WebServiceResult(bool isSuccess, object data, List<ErrorResponseResult> errors)
            : base(isSuccess, data, errors)
        { }

        #region Initial class with ErrorMessageResult
        public WebServiceResult(bool isSuccess, ErrorMessageResult messageResult) : base(isSuccess, messageResult)
        { }

        public WebServiceResult(bool isSuccess, List<ErrorMessageResult> messageResults) : base(isSuccess, messageResults)
        { }

        public WebServiceResult(ErrorMessageResult messageResult) : base(messageResult)
        { }

        public WebServiceResult(List<ErrorMessageResult> messageResults) : base(messageResults)
        { }
        #endregion
    }
}
