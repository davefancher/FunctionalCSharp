using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixingOO
{
    public static class Validator
    {
        public static Result<T, string> IsNotNull<T>(T value)
            where T : class
        {
            return
                value == null
                    ? Result<T, string>.FailWith("Value cannot be null")
                    : Result<T, string>.SucceedWith(value);
        }

        public static Result<string, string> IsNotEmpty(string value)
        {
            return
                value.Length == 0
                    ? Result<string, string>.FailWith("Value cannot be empty")
                    : Result<string, string>.SucceedWith(value);
        }

        public static Func<string, Result<string, string>> MinLength(int minLength)
        {
            return
                value =>
                    value.Length < minLength
                        ? Result<string, string>.FailWith(String.Format("Value must be at least {0} characters long", minLength))
                        : Result<string, string>.SucceedWith(value);
        }
    }
}
