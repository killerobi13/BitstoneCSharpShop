using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public class DuplicateProductException : Exception
    {
        public DuplicateProductException() : base("The product you have entered already exists")
        {
        }

        public DuplicateProductException(string message)
            : base(message)
        {
        }

        public DuplicateProductException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
