using System.Collections.Generic;
using ConsoleTables;
using Extensions.Pack;
using ObjectsComparer;

namespace Testing.Extensions
{
    internal static class DifferenceExtensions
    {
        internal static string ToResultTable(this IEnumerable<Difference> differences, string objectName1,
            string tObjectName2)
        {
            if (differences.IsEmpty())
                return string.Empty;

            var aTable = new ConsoleTable(nameof(Difference.MemberPath), objectName1, tObjectName2,
                nameof(Difference.DifferenceType));
            differences.ForEach(tDif => aTable.AddRow(tDif.MemberPath, tDif.Value1, tDif.Value2, tDif.DifferenceType));
            return aTable.ToString();
        }
    }
}