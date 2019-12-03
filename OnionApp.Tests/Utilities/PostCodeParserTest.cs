using System.Collections.Generic;
using Xunit;
using static OnionApp.Domain.Services.Utilities.PostCodeParser;

namespace OnionApp.Tests.Utilities
{
    public class PostCodeParserTest
    {
        public static IEnumerable<object[]> ParseTestData =>
            new List<object[]>
            {
                new object[] { "ma523", "LLNNN", "MA523" },
                new object[] { "Mda421asdasdasd", "lLLNNN", "mDA421" },
                new object[] { null, "NLNNN", null },
                new object[] {"dfs1", null, "dfs1" },
                new object[] { "f1a", "LL", "FA" },
                new object[] { "rl11", "l---lNN", "r---l11" },
                new object[] { "sdf", " ", "sdf" },
                new object[] { "abc1", "L--N", "A--1" },
            };

        [Theory]
        [MemberData(nameof(ParseTestData))]
        public void ApplyMaskToPostCodeTest(string srt, string mask, string expected)
        {
            var actual = ApplyMaskToPostCode(srt, mask);

            Assert.Equal(expected, actual);
        }
    }
}
