using System;
using System.Linq;
using System.Text;

namespace FunctionalCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Transformation Pipeline
            Disposable
                .Using(
                    StreamFactory.GetStream,
                    stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int)stream.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(HtmlBuilder.BuildSelectBox("theDoctors", true))
                .Tee(Console.WriteLine);

            // String Validation Pipeline
            "Doctor Who"
                .Map(Validator.IsNotNull)
                .Bind(Validator.IsNotEmpty)
                .Bind(Validator.MinLength(8))
                .Map(result => result.IsSuccess ? result.SuccessValue : result.FailureValue)
                .Tee(Console.WriteLine);

            Console.ReadLine();
        }
    }
}
