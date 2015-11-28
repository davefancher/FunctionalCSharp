using System;
using System.IO;
using System.Text;

namespace FunctionalCSharp
{
    public static class StreamFactory
    {
        private static string GetLines() =>
            String.Join(
                Environment.NewLine,
                new[] {
                    "Hartnell", "Troughton", "Pertwee", "T. Baker",
                    "Davison", "C. Baker", "McCoy", "McGann", "Hurt",
                    "Eccleston", "Tennant", "Smith", "Capaldi" });

        public static Stream GetStream()
        {
            return
                new MemoryStream()
                    .Tee(stream =>
                        GetLines()
                            .Map(Encoding.UTF8.GetBytes)
                            .Tee(buffer => stream.Write(buffer, 0, buffer.Length)))
                    .Tee(stream => stream.Position = 0L);
        }
    }
}
