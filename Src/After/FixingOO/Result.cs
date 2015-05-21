using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixingOO
{
    public class Result<TSuccess, TFailure>
    {
        private readonly bool _isSuccess;

        private Result(bool isSuccess)
        {
            _isSuccess = isSuccess;
        }

        public TSuccess SuccessValue { get; private set; }
        public TFailure FailureValue { get; private set; }
        public bool IsSuccess { get { return _isSuccess; } }


        public static Result<TSuccess, TFailure> SucceedWith(TSuccess value)
        {
            return
                new Result<TSuccess, TFailure>(true)
                {
                    SuccessValue = value
                };
        }

        public static Result<TSuccess, TFailure> FailWith(TFailure value)
        {
            return
                new Result<TSuccess, TFailure>(false)
                {
                    FailureValue = value
                };
        }

        public Result<TSuccess, TFailure> Bind(Func<TSuccess, Result<TSuccess, TFailure>> fn)
        {
            return
                this.IsSuccess
                    ? fn(this.SuccessValue)
                    : this;
        }
    }
}
