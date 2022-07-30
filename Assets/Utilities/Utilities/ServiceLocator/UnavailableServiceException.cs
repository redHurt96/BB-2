using System;

namespace RH.Utilities.ServiceLocator
{
    public class UnavailableServiceException : Exception
    {
        public UnavailableServiceException(Type service) 
            : base($"There is no registered service with type {service}")
        {}
    }
}