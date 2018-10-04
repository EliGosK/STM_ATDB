using STM.ATDB.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Core.ComponentModel
{
    public class ObjectResult
    {
        public ObjectResult() { }
        public ObjectResult(object data) : this(data, null) { }
        public ObjectResult(Exception error) : this(null, error) { }
        public ObjectResult(object data, Exception error)
        {
            this.DataState = data;
            this.Error = error;
        }
        public string message { get; set; }
        public object DataState { get; private set; }
        public Exception Error { get; private set; }
        public bool IsSucceed { get { return this.Error == null; } }

        public static ObjectResult Succeed() { return new ObjectResult(); }
        public static ObjectResult Succeed(object data) { return new ObjectResult(data); }

        public static ObjectResult Fail(string errorMessage) { return new ObjectResult(new Exception(errorMessage)); }
        public static ObjectResult Fail(Exception error) { return new ObjectResult(error); }
        public static ObjectResult Fail(object data, string errorMessage) { return new ObjectResult(data, new Exception(errorMessage)); }
        public static ObjectResult Fail(object data, Exception error) { return new ObjectResult(data, error); }

        public string GetErrorMessage()
        {
            if (this.Error == null) return null;
            return ExceptionUtility.GetLastExceptionMessage(this.Error);
        }
    }
}
