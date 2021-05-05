﻿using System;

namespace InterstellarLogistic.Shared
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }
    }
}