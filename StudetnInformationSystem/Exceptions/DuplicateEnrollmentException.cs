using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Exceptions
{
    internal class DuplicateEnrollmentException:Exception
    {
        public DuplicateEnrollmentException()
        {
        }

        public DuplicateEnrollmentException(string message) : base(message)
        {
        }

        public DuplicateEnrollmentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
