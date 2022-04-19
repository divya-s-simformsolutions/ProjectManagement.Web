using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Entities
{
    public class ResponseModel<T>
    {
        public T Result { get; set; }
        public bool Status { get { return !HasError; } }
        public bool HasError { private get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public string[] Errors { get; set; }
    }
}
