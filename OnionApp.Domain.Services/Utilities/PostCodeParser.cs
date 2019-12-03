using System;
using System.Linq;

namespace OnionApp.Domain.Services.Utilities
{
    public static class PostCodeParser
    {
        public static string Parse(string srt, string postalCodeMask)
        {
            var address = new string(srt?.ToCharArray().Where(c => Char.IsLetter(c) || Char.IsDigit(c)).ToArray());
            if (string.IsNullOrEmpty(address)) return null;
            if (postalCodeMask == null) return address;

            var result = "";
            var pos = 0;

            foreach (var c in postalCodeMask)
            {
                    switch (c)
                {
                    case 'l':
                        result += Char.ToLower(address[pos++]);
                        break;
                    case 'L':
                        result += Char.ToUpper(address[pos++]);
                        break;
                    case 'N':
                        result += address[pos++];
                        break;
                    default:
                        result += c;
                        break;
                }
            }

            return result;
        }
    }
}
