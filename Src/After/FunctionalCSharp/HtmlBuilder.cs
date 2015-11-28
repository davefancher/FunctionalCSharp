using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalCSharp
{
    public static class HtmlBuilder
    {
        public static Func<IDictionary<int, string>, string> BuildSelectBox(string id, bool includeUnknown) =>
            options =>
                new StringBuilder()
                    .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                    .When(
                        () => includeUnknown,
                        sb => sb.AppendFormattedLine("\t<option>{0}</option>", "unknown"))
                    .AppendSequence(
                        options,
                        (sb, opt) => sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                    .AppendLine("</option>")
                    .ToString();
    }
}
