using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloomApi.Exceptions
{
    public class BloomApiInternalException : SystemException {
        public BloomApiInternalException() : base()
        {

        }

        public BloomApiInternalException(string message) : base(message)
        {

        }

        public BloomApiInternalException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
