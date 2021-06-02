﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace AuthPermissions.SetupParts.Internal
{
    internal static class CommaDelimitedHandler
    {
        public static List<string> DecodeCodeNameWithTrimming(this string line, int charNum, Action<string, int> checkValid)
        {
            var trimmedNames = new List<string>();
            while (charNum < line.Length)
            {
                if (!char.IsLetterOrDigit(line[charNum]))
                {
                    charNum++;
                    continue;
                }

                var foundName = "";
                var startOfName = charNum;
                while (charNum < line.Length && char.IsLetterOrDigit(line[charNum]))
                {
                    foundName += line[charNum];
                    charNum++;
                }
                if (foundName.Length > 0)
                {
                    checkValid(foundName, startOfName);
                    trimmedNames.Add(foundName);
                }
            }

            return trimmedNames;
        }

        public static string FormErrorString(this string line, int lineNum, int charNum, string error)
        {
            var charPart = charNum < 0 ? "" : $", char: {charNum + 1}";
            var result = $"Line/index {lineNum + 1:####}{charPart}: {error}{Environment.NewLine}{line}";
            if (charNum > -1)
                result += Environment.NewLine + new string(' ', charNum) + "|";

            return result;
        }
    }
}