using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloomApi.Entities
{
    public enum BloomApiSearchOperation { Equals, Prefix, Fuzzy, GreaterThan, LessThan, GreaterThanEquals, LessThanEquals }

    public class BloomApiSearchTerm
    {
        public string Key { get; set; }
        public BloomApiSearchOperation Operation { get; set; }
        public string Value { get; set; }

        public string ToParameters(int index)
        {
            string apiOperation = this.ApiOperationName();
            return String.Format("key{0}={1}&op{0}={2}&value{0}={3}", index, this.Key, apiOperation, this.Value);
        }

        string ApiOperationName()
        {
            switch (this.Operation)
            {
                case BloomApiSearchOperation.Equals: return "eq";
                case BloomApiSearchOperation.Fuzzy: return "fuzzy";
                case BloomApiSearchOperation.GreaterThan: return "gt";
                case BloomApiSearchOperation.GreaterThanEquals: return "gte";
                case BloomApiSearchOperation.LessThan: return "lt";
                case BloomApiSearchOperation.LessThanEquals: return "lte";
                case BloomApiSearchOperation.Prefix: return "prefix";
            }

            throw new ArgumentException("Unknown Operation " + this.Operation.ToString());
        }
    }
}
