using System;

namespace Exemplo.Dominio
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }

        public static void When(bool hasErro, string error)
        {
            if (hasErro)
                throw new DomainException(error);
        }
    }
}