using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormattedLine(
            this StringBuilder @this,
            string format,
            params object[] args)
        {
            return @this.AppendFormat(format, args).AppendLine();
        }

        public static StringBuilder AppendSequence<T>(
            this StringBuilder @this,
            IEnumerable<T> sequence,
            Func<StringBuilder, T, StringBuilder> fn)
        {
            return sequence.Aggregate(@this, fn);
        }
    }
}
