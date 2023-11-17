﻿using System.Runtime.Serialization;

namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found")
        {
        }

    }
}
