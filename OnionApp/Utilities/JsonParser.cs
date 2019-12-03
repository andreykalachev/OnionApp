using System;
using System.Collections.Generic;
using System.Linq;

namespace OnionApp.Utilities
{
    public static class JsonParser
    {
        public static IEnumerable<Guid> ParseStringToIEnumerableGuids(string ids)
        {
            var result = new List<Guid>();
            var stringGuids = ids.Split(',');

            if (stringGuids == null || stringGuids.Length == 0) return result;

            result = stringGuids.Select(Guid.Parse).ToList();

            return result;
        }
    }
}
