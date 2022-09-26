using System;

namespace Project.Domain.Exceptions
{
    public class EntityValidationException : Exception
    {
        public EntityValidationException() : base()
        {

        }
        public EntityValidationException(string message) : base(message)
        {

        }
    }
}
