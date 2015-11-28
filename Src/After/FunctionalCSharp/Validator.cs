using System;

namespace FunctionalCSharp
{
    public static class Validator
    {
        public static Result<T, string> IsNotNull<T>(T value)
            where T : class =>
                value == null
                    ? Result<T, string>.FailWith("Value cannot be null")
                    : Result<T, string>.SucceedWith(value);

        public static Result<string, string> IsNotEmpty(string value) =>
            value.Length == 0
                ? Result<string, string>.FailWith("Value cannot be empty")
                : Result<string, string>.SucceedWith(value);

        public static Func<string, Result<string, string>> MinLength(int minLength) =>
            value =>
                value.Length < minLength
                    ? Result<string, string>.FailWith($"Value must be at least {minLength} characters long")
                    : Result<string, string>.SucceedWith(value);
    }
}
