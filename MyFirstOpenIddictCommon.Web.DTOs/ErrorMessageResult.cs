using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace MyFirstOpenIddictCommon.Web.DTOs
{
    public class ErrorMessageResult : TableEntity
    {
        public string Code { get; set; }
                public string CodeType { get; set; }
        public string Message { get; set; }
        public ErrorMessageResult() : base()
        {

        }
        public ErrorMessageResult(string languageId, string errorId) : base(languageId, errorId)
        {

        }
    }
}
