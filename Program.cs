using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace cfg
{
    class Program
    {
        static Dictionary<string, List<string[]>> ParseGrammar(string filename) {
            var rules = new Dictionary<string, List<string[]>>();
            foreach (var line in File.ReadAllLines(filename))
            {
                if(line.Trim().Length == 0 || line.StartsWith("#")) continue;
                var split = line.Split("->", 2, StringSplitOptions.RemoveEmptyEntries);
                if(split.Length == 1) continue;
                var rule = split[0].Trim();
                var productions = split[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if(!rules.ContainsKey(rule)) {
                    rules[rule] = new List<string[]>();
                }
                rules[rule].Add(productions);
            }
            return rules;
        }
        static void Main(string[] args)
        {
            var rules = ParseGrammar("grammar.txt");
            foreach (var rule in rules)
            {
                Console.WriteLine(rule.Key + ":");
                foreach (var productions in rule.Value)
                {
                    Console.WriteLine("  " + String.Join(' ', productions));
                }
            }
            
        }
    }
}
