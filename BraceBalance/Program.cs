using System;
using System.Collections.Generic;

namespace BraceBalance
{
    internal static class Program
    {
        private static readonly Dictionary<char, char> Pairs = new()
        {
            {'{', '}'},
            {'(', ')'},
            {'[', ']'}
        };

        private static void Main()
        {
            Console.WriteLine(IsBalanced("()[][{}]")); // true
            Console.WriteLine(IsBalanced("[}")); // false
            Console.WriteLine(IsBalanced("})[]{}")); // false
            Console.WriteLine(IsBalanced("(}")); // false
            Console.WriteLine(IsBalanced("({https://t.me/platinum_tech_talks})")); // true!
            Console.WriteLine(IsBalanced("({}a)")); // true
        }

        private static bool IsBalanced(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            var stack = new Stack<char>();
            foreach (var symbol in text)
            {
                if (Pairs.ContainsKey(symbol))
                {
                    stack.Push(symbol);
                }
                else if (!Pairs.ContainsValue(symbol)) continue;
                else if (stack.Count == 0) return false;
                else if (Pairs[stack.Pop()] != symbol)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}