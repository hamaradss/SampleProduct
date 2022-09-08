using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleProduct.Models
{
    public class TrialException : Exception
    {
        public TrialException() : base() { }
        public TrialException(string message) : base(message) { }
        public TrialException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected TrialException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}