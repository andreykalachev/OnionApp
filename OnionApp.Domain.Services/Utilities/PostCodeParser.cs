using System;
using System.Linq;

namespace OnionApp.Domain.Services.Utilities
{
    public static class PostCodeParser
    {
        public static string ApplyMaskToPostCode(string srt, string postalCodeMask)
        {
            var address = new string(srt?.ToCharArray().Where(Char.IsLetterOrDigit).ToArray());
            if (string.IsNullOrEmpty(address)) return null;
            if (string.IsNullOrEmpty(postalCodeMask?.Trim())) return address;

            var pos = 0;
            var result = "";
            var addressLength = address.Length;

            foreach (var c in postalCodeMask)
            {
                if (pos >= addressLength) return result;

                while (char.ToLower(c) == 'l' && !char.IsLetter(address[pos]) ||
                       c == 'N' && !char.IsNumber(address[pos]))
                {
                    pos++;
                    if (pos >= addressLength) return result;
                }

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