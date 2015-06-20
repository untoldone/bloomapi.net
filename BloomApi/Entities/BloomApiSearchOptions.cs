using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloomApi.Entities
{
    public class BloomApiSearchOptions
    {
        public uint Limit { get; set; }
        public uint Offset { get; set; }
        public IEnumerable<BloomApiSearchTerm> Terms { get; set; }

        public string ToParameters()
        {
            List<string> seperatedParams = this.Terms
                                        .Select((x, i) => x.ToParameters(i + 1))
                                        .ToList();
            
            if (this.Limit != 0)
            {
                string limitParam = String.Format("limit={0}", this.Limit);
                seperatedParams.Add(limitParam);
            }

            if (this.Offset != 0)
            {
                string offsetParam = String.Format("offset={0}", this.Offset);
                seperatedParams.Add(offsetParam);
            }

            return String.Join("&", seperatedParams.ToArray());
        }
    }
}
