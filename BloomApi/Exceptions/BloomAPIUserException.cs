using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BloomApi.Exceptions
{
    public class BloomAPIUserException : SystemException
    {
        private string bloomExceptionName;

        public BloomAPIUserException () : base()
        {

        }

        public BloomAPIUserException(string message) : base(message)
        {

        }

        public BloomAPIUserException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public BloomAPIUserException(string name, string message, Exception innerException) : base(message, innerException)
        {
            this.bloomExceptionName = name;
        }

        public string BloomExceptionName { get { return bloomExceptionName; } }
    }
}
