using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sanofi.Sap
{
    public class InvalidStateTransitionException : ApplicationException
    {
        public InvalidStateTransitionException()
        {
        }

        public InvalidStateTransitionException(string message) : base(message)
        {
        }

        public InvalidStateTransitionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidStateTransitionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
