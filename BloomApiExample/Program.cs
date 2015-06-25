using BloomApi;
using BloomApi.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BloomService s = new BloomService();

            BloomApiSearchResponse res = s.Search("usgov.hhs.npi", new BloomApiSearchOptions{
                Limit = 50,
                Offset = 50,
                Terms = new List<BloomApiSearchTerm>{
                    new BloomApiSearchTerm{
                        Key = "first_name",
                        Operation = BloomApiSearchOperation.Fuzzy,
                        Value = "robret"
                    },
                    new BloomApiSearchTerm{
                        Key = "last_name",
                        Operation = BloomApiSearchOperation.Prefix,
                        Value = "jone"
                    }
                }
            });

            Console.ReadKey();
        }
    }
}
