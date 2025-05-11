using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Domain.Entities.Progress
{
    public class Result<T>
    {
        public bool IsSuccess { get; protected set; }
        public string Error { get; protected set; }
        public T Value { get; protected set; }

        protected Result(bool isSuccess, string error, T value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result<T> Success(T value) => new Result<T>(true, null, value);
        public static Result<T> Failure(string error) => new Result<T>(false, error, default);
    }

    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public string Error { get; protected set; }
        public object Value { get; protected set; }

        protected Result(bool isSuccess, string error, object value)
        {
            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public static Result Success(object value) => new Result(true, null, value);
        public static Result Failure(string error) => new Result(false, error, null);
    }
    
}
